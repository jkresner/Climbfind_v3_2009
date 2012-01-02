using System.Collections.Generic;
using System.Linq;
using ClimbFind.Model.Objects;
using LinqToSql_AdProduct = ClimbFind.Model.LinqToSqlMapping.AdProduct;

namespace ClimbFind.Model.DataAccess
{
    public class AdProductDA : AbstractBaseDA<AdProduct, LinqToSql_AdProduct, int>
    {
        public List<AdProduct> GetClientsProducts(int clientID)
        {
            return MapList((from c in EntityTable where c.ClientID == clientID select c).ToList());
        }
    }

}
