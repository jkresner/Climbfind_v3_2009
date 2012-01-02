using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Configuration;
using System.Data.Linq;
using System.Linq;
using System.Reflection;
using ClimbFind.Model.LinqToSqlMapping;
using ClimbFind.Model.Objects;
using ClimbFind.Model.Objects.Interfaces;


namespace ClimbFind.Model.DataAccess
{
    /// <summary>
    /// AbstractDA is our base Data Access class which exposes public methods that work on OOT (our desired Object Orientated Type).
    /// 
    /// Under the covers, it does all the work to map OOT -> LT (LinqToSql Type) and visa versa so that we can persit our 
    /// objects in the database via the LinqToSqlMapping classes (and hence develop really quickly!)
    /// 
    /// This class also implements IObjectOrientatedDA, so theoretically you can wap out any of the child DAs that inherit
    /// from this base class with your own implementation and if it also IObjectOrientatedDA it should work like plug n play
    /// </summary>
    /// <typeparam name="OOT">Our Object Orientated type as defined in ClimbFind.Model.Objects</typeparam>
    /// <typeparam name="LT">Linq type as defined in our LinqToSqlMapping .dbml designer file</typeparam>
    /// <typeparam name="KeyType">The type of key, either an 'int' or 'Guid' but could be something else</typeparam>
    public abstract class AbstractBaseDA<OOT, LT, KeyType> : IObjectOrientatedDA<OOT, KeyType>
        where OOT : class, IKeyObject<KeyType>, new()
        where LT : class, IKeyObject<KeyType>, new()
        where KeyType : IEquatable<KeyType>
    {
        /// <summary>
        /// Members
        /// </summary>

        protected ClimbfindLinqModelDataContext ctx;
        public Table<LT> EntityTable { get { return ctx.GetTable<LT>(); } }

        /// <summary>
        /// Contructors
        /// </summary>

        public AbstractBaseDA()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ClimbFindDB"].ToString();
            ctx = new ClimbfindLinqModelDataContext(connectionString);
        }

        public AbstractBaseDA(string connectionString)
        {
            ctx = new ClimbfindLinqModelDataContext(connectionString);
        }

        public AbstractBaseDA(IDATransactionContext transactionContext)
        {
            if (transactionContext == null) { throw new Exception("Cannot run AbstractBaseDA in transaction mode with a null data context"); }
            ctx = transactionContext as ClimbfindLinqModelDataContext;
        }

        /// <summary>
        /// Base virtual Mapping Methods that we can override in each inheriting DA if necessary 
        /// </summary>

        protected virtual LT MapOOTypeToLinqType(OOT t)
        {
            return MapValues(new LT(), t);
        }

        /// <summary>
        /// ** If required, Add additional Custom property mappings then we override this method ** --//
        /// </summary>
        /// <param name="lt"></param>
        /// <returns></returns>
        protected virtual OOT MapLinqTypeToOOType(LT lt)
        {
            return MapValues(new OOT(), lt);
        }

        /// <summary>
        /// Base Mapping Methods 
        /// </summary>

        protected OOT MapType(LT lt)
        {
            if (lt == null) { return null; }
            else { return MapLinqTypeToOOType(lt); }
        }

        protected LT MapType(OOT t)
        {
            if (t == null) { return null; }
            else { return MapOOTypeToLinqType(t); }
        }

        protected List<OOT> MapList(List<LT> listOfLT)
        {
            return (from lt in listOfLT select MapType(lt)).ToList();
        }

        protected List<LT> MapList(List<OOT> listOfOOT)
        {
            return (from t in listOfOOT select MapType(t)).ToList();
        }

        protected LT MapValues(LT lt, OOT t)
        {
            MapValues(lt, t.GetProperyNameAndValues());

            return lt;
        }

        protected OOT MapValues(OOT t, LT lt)
        {
            MapValues(t, lt.GetProperyNameAndValues());

            return t;
        }

        protected LT MapValues(LT lt, NameValueCollection keysAndValue)
        {
            MapNameValuesCollectionToObject(lt, keysAndValue);

            return lt;
        }

        protected OOT MapValues(OOT t, NameValueCollection keysAndValue)
        {
            MapNameValuesCollectionToObject(t, keysAndValue);

            return t;
        }

        /// <summary>
        /// Get Methods
        /// </summary>
        /// <returns></returns>

        public List<OOT> GetAll()
        {
            return MapList((from c in EntityTable select c).ToList());
        }

        /// <summary>
        /// Insert Methods
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>

        public OOT Insert(OOT t)
        {
            return Insert(MapType(t));
        }

        protected OOT Insert(LT lt)
        {
            EntityTable.InsertOnSubmit(lt);
            CommitChanges();

            return MapType(lt);
        }

        public List<OOT> Insert(List<OOT> listOfT)
        {
            return Insert(MapList(listOfT));
        }

        protected List<OOT> Insert(List<LT> listOfT)
        {
            EntityTable.InsertAllOnSubmit(listOfT);
            CommitChanges();

            return MapList(listOfT);
        }

        protected void InsertReference(ITable table, object entity)
        {
            table.InsertOnSubmit(entity);
            CommitChanges();
        }

        /// <summary>
        /// Base update methods
        /// </summary>
        /// <param name="lt"></param>
        /// <returns></returns>

        public OOT Update(OOT t)
        {
            LT lt = MapValues(GetLinqTypeByID(t.ID), t);
            return Update(lt);
        }

        protected OOT Update(LT lt)
        {
            CommitChanges();
            return MapType(lt);
        }

        /// <summary>
        /// Getter Methods
        /// </summary>

        public OOT GetByID(KeyType id)
        {
            return MapType(GetLinqTypeByID(id));
        }

        /// <summary>
        /// GetLinqTypeByID is defined here as a virtual method as sometimes in the
        /// case of AbstractDeprecableDA we want to add a !Deprecated selection criteria
        /// to the basic GetByID query.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        protected virtual LT GetLinqTypeByID(KeyType id)
        {
            return (from c in EntityTable where id.Equals(c.ID) select c).SingleOrDefault();
        }

        /// <summary>
        /// Delete methods
        /// </summary>

        public void Delete(KeyType id)
        {
            LT t = (from c in EntityTable where id.Equals(c.ID) select c).SingleOrDefault();
            EntityTable.DeleteOnSubmit(t);
            CommitChanges();
        }

        public void Delete(List<KeyType> idsToDelete)
        {
            List<LT> listOfLT = (from c in EntityTable where idsToDelete.Contains(c.ID) select c).ToList();
            EntityTable.DeleteAllOnSubmit(listOfLT);
            CommitChanges();
        }


        /// <summary>
        /// CommitChanges causes the LinqToSql data context to update the database in a single consistent
        /// fasion throughout our DA
        /// </summary>
        protected void CommitChanges()
        {
            ctx.SubmitChanges(ConflictMode.FailOnFirstConflict);
        }


        /// <summary>
        /// MapNameValuesCollectionToObject: Awesome reflection method, sets properties on objects
        /// using the Name / Value pairs in the NameValueCollection
        /// </summary>
        private static object MapNameValuesCollectionToObject(object value, NameValueCollection values)
        {
            Type objType = value.GetType();
            string objName = objType.Name;

            PropertyInfo[] fields = objType.GetProperties();

            foreach (PropertyInfo property in fields)
            {
                if (values[property.Name] != null)
                {
                    TypeConverter conv = TypeDescriptor.GetConverter(property.PropertyType);
                    object thisValue = values[property.Name];

                    if (conv.CanConvertFrom(typeof(string)))
                    {
                        thisValue = conv.ConvertFrom(values[property.Name]);
                        property.SetValue(value, thisValue, null);
                    }
                }
            }

            return value;
        }
    }



}

