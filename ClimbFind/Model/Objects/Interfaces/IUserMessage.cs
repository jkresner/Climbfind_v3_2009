using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClimbFind.Model.Objects.Interfaces
{
    public interface IUserMessage
    {
        int ID { get; set; }
        string Message { get; set; }
        string Subjcet { get; set; }
        Guid SendingUserID { get; set; }
        Guid ReceivingUserID { get; set; }
        DateTime SentDateTime { get; set; }
    }
}
