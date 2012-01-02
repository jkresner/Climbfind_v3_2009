using System;
using System.Linq;
using ClimbFind.Model.Objects;
using LinqToSql_ClimberProfileExtended = ClimbFind.Model.LinqToSqlMapping.ClimberProfileExtended;
using System.Collections.Generic;


namespace ClimbFind.Model.DataAccess
{
    public class ClimberProfileExtendedDA : AbstractBaseDA<ClimberProfileExtended, LinqToSql_ClimberProfileExtended, Guid>
    {
        public List<ClimberProfileExtended> GetExtendedProfilesWithLike()
        {
            return MapList((from c in ctx.ClimberProfileExtendeds
                    where c.LikeAboutClimbfind.ToString() != ""
                    select c).ToList());
        }
    }

}
