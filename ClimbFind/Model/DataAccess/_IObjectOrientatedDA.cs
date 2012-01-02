using System;
using System.Collections.Generic;
using ClimbFind.Model.Objects.Interfaces;

namespace ClimbFind.Model.DataAccess
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IObjectOrientatedDA<T, KeyType>
        where T : class, IKeyObject<KeyType>, new()
        where KeyType : IEquatable<KeyType>
    {
        List<T> GetAll();

        T GetByID(KeyType id);

        T Insert(T t);

        List<T> Insert(List<T> listOfT);

        T Update(T t);

        void Delete(KeyType id);

        void Delete(List<KeyType> idsToDelete);
    }
}
