using System.Collections.Generic;
using System.Linq;
using ClimbFind.Model.Objects;
using LinqToSql_AdClient = ClimbFind.Model.LinqToSqlMapping.AdClient;

namespace ClimbFind.Model.DataAccess
{
    public class AdClientDA : AbstractBaseDA<AdClient, LinqToSql_AdClient, int>
    {
    }

}
