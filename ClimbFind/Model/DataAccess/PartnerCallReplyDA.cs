using System;
using System.Collections.Generic;
using System.Linq;
using ClimbFind.Model.Objects;
using LinqToSql_PartnerCallReply = ClimbFind.Model.LinqToSqlMapping.PartnerCallReply;


namespace ClimbFind.Model.DataAccess
{
    public class PartnerCallReplyDA : AbstractBaseDA<PartnerCallReply, LinqToSql_PartnerCallReply, Guid>
    {
        public PartnerCallReplyDA() : base() { }
        public PartnerCallReplyDA(IDATransactionContext transactionContext) : base(transactionContext) { }
     
        
        protected override PartnerCallReply MapLinqTypeToOOType(LinqToSql_PartnerCallReply o)
        {
            PartnerCallReply o2 = new PartnerCallReply();
            MapValues(o2, o.GetProperyNameAndValues());
           
            o2.OriginalCall = new PartnerCallDA().GetByID(o.PartnerCallID);
            o2.ReplyingName = o.ClimberProfile.FullName;

            return (o2);
        }

        /// <summary>
        /// 
        /// </summary>
        public List<PartnerCallReply> GetRepliesForPartnerCall(Guid partnerCallID)
        {
            return MapList((from c in ctx.PartnerCallReplies
                            where c.PartnerCallID == partnerCallID select c).ToList());
        }

        /// <summary>
        /// 
        /// </summary>
        public List<PartnerCallReply> GetUserPartnerCallReplies(Guid userID)
        {
            List<PartnerCallReply> replies = MapList((from c in ctx.PartnerCallReplies
                            where c.ReplyingUserID == userID 
                                       select c).ToList());

            return replies;
        }


        public List<UserMessage> GetUserPartnerCallRepliesAsMessages(Guid userID)
        {
            List<UserMessage> msgs = (from pc in ctx.PartnerCalls
                                      from pcr in ctx.PartnerCallReplies
                                      where pc.ID == pcr.PartnerCallID
                                            && pcr.ReplyingUserID == userID
                                      select new UserMessage
                                      {
                                        ID = pcr.ID,
                                        SentDateTime = pcr.ReplyDateTime,
                                        SendingUserID = userID,
                                        Subject = "Reply to " + pc.ClimberProfile.FullName + "'s partner call",
                                         ReceivingUserID = pc.ClimberProfileID,
                                         ReceiverDeleted = false,
                                         Message = pcr.Message,
                                         SenderDeleted = false
                                      }).ToList();

            return msgs;
        }
        

        public List<UserMessage> GetRepliesToUsersPartnerCalls(Guid userID)
        {
            List<UserMessage> msgs = (from pc in ctx.PartnerCalls
                                      from pcr in ctx.PartnerCallReplies
                                      where pc.ID == pcr.PartnerCallID
                                            && pc.ClimberProfileID == userID
                                      select new UserMessage
                                      {
                                        ID = pcr.ID,
                                        SentDateTime = pcr.ReplyDateTime,
                                        SendingUserID = pcr.ReplyingUserID,
                                        Subject = "Reply to your partner call",
                                         ReceivingUserID = userID,
                                         ReceiverDeleted = false,
                                         Message = pcr.Message,
                                         SenderDeleted = false
                                      }).ToList();

            return msgs;
        }


    }
}
