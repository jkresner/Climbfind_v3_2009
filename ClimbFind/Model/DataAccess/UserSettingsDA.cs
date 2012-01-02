using System;
using ClimbFind.Model.Objects;
using LinqToSql_UserSettings = ClimbFind.Model.LinqToSqlMapping.UserSetting;

namespace ClimbFind.Model.DataAccess
{
    public class UserSettingsDA : AbstractBaseDA<UserSettings, LinqToSql_UserSettings, Guid>
    {
        public UserSettingsDA() : base() { }
        public UserSettingsDA(IDATransactionContext transactionContext) : base(transactionContext) { }
    }
}
