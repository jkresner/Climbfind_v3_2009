using System;
using System.Collections.Generic;
using System.Linq;
using ClimbFind.Model.Objects;
using LinqToSql_MessageBoardMessage = ClimbFind.Model.LinqToSqlMapping.MessageBoardMessage;


namespace ClimbFind.Model.DataAccess
{
    public class MessageBoardMessageDA : AbstractBaseDA<MessageBoardMessage, LinqToSql_MessageBoardMessage, Guid>
    {
        public MessageBoardMessageDA() : base() { }
        public MessageBoardMessageDA(IDATransactionContext transactionContext) : base(transactionContext) { }

        /// <summary>
        /// 
        /// </summary>
        protected override MessageBoardMessage MapLinqTypeToOOType(LinqToSql_MessageBoardMessage o)
        {
            MessageBoardMessage o2 = new MessageBoardMessage();
            MapValues(o2, o.GetProperyNameAndValues());

            o2.PosterUserID = o.UserID;
            o2.PostersName = o.ClimberProfile.FullName;
            o2.ProfilePictureFile = o.ClimberProfile.ProfilePictureFile;

            return (o2);
        }

        /// <summary>
        /// 
        /// </summary>
        public List<MessageBoardMessage> GetMessagesForMessageBoard(Guid messageBoardID)
        {
            return MapList( (from c in ctx.MessageBoardMessages 
                             where c.MessageBoardID == messageBoardID
                             orderby c.PostedDateTime descending
                             select c).ToList() );
        }


        public List<MessageBoardMessage> GetLastN(int n)
        {
            return MapList((from c in EntityTable orderby c.ID descending select c).Take(n).ToList());
        }


    }
}
