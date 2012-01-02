using System;
using System.Collections.Generic;
using ClimbFind.Model.Objects.Interfaces;

namespace ClimbFind.Model.Objects
{
    public class MessageBoard : IKeyObject<Guid>
    {
        public Guid ID { get; set; }
        public bool IsVisible { get; set; }
        public List<MessageBoardMessage> Messages { get; set; }       
    }
}
