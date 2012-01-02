using System;
using ClimbFind.Model.Objects;
using LinqToSql_MessageBoard = ClimbFind.Model.LinqToSqlMapping.MessageBoard;

namespace ClimbFind.Model.DataAccess
{
    public class MessageBoardDA : AbstractBaseDA<MessageBoard, LinqToSql_MessageBoard, Guid>
    {
        private MessageBoardMessageDA messageDA;

        public MessageBoardDA() : base() { messageDA = new MessageBoardMessageDA(ctx); }
        public MessageBoardDA(IDATransactionContext transactionContext) : base(transactionContext) { messageDA = new MessageBoardMessageDA(ctx); }

        /// <summary>
        /// 
        /// </summary>
        protected override MessageBoard MapLinqTypeToOOType(LinqToSql_MessageBoard o)
        {
            MessageBoard o2 = new MessageBoard();
            MapValues(o2, o.GetProperyNameAndValues());

            o2.Messages = messageDA.GetMessagesForMessageBoard(o.ID); //

            return (o2);
        }
    }
}
