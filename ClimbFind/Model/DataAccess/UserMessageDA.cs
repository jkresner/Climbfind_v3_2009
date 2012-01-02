using System;
using System.Collections.Generic;
using System.Linq;
using ClimbFind.Model.Objects;
using LinqToSql_UserMessage = ClimbFind.Model.LinqToSqlMapping.UserMessage;

namespace ClimbFind.Model.DataAccess
{
    public class UserMessageDA : AbstractBaseDA<UserMessage, LinqToSql_UserMessage, Guid>
    {
        public UserMessageDA() : base() { }
        public UserMessageDA(IDATransactionContext transactionContext) : base(transactionContext) { }

        public List<UserMessage> GetByUserID(Guid userID)
        {
            return MapList((from c in ctx.UserMessages where c.ReceivingUserID == userID && !c.ReceiverDeleted orderby c.SentDateTime select c).ToList());
        }

        public List<UserMessage> GetUsersSentMessages(Guid userID)
        {
            return MapList((from c in ctx.UserMessages where c.SendingUserID == userID && !c.SenderDeleted orderby c.SentDateTime select c).ToList());
        }
        
    
    }
}
