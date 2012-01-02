using System;
using ClimbFind.Model.Enum;
using ClimbFind.Model.Objects.Interfaces;

namespace ClimbFind.Model.Objects
{
    public class LogEvent : IKeyObject<int>
    {
        /// <summary>
        /// Data Properties
        /// </summary>
        public int ID { get; set; }
        public Guid UserID { get; set; }
        public int EventType { get; set; }
        public bool Archived { get; set; }
        public string Name { get; set; }
        public DateTime EventDateTime { get; set; }

        /// <summary>
        /// Friendly Display Properties
        /// </summary>
        public int RowCount { get; set; }
        public string EventDateTimeString { get { return EventDateTime.ToString("hh:mm dd/MM"); } }
        public CFLogEventType _EventType { get { return (CFLogEventType)EventType; } }
        public string EventTypeString { get { return _EventType.ToString(); } }
      


        /// <summary>
        /// Contructors
        /// </summary>
        public LogEvent() { }

        public LogEvent(Guid userID, CFLogEventType eventType, string name)
        {
            this.EventDateTime = DateTime.Now;
            this.UserID = userID;
            this.EventType = (int)eventType;
            this.Name = name;
        }

        public LogEvent(int ID, Guid userID, CFLogEventType eventType, string name,
            DateTime eventDateTime)
        {
            this.ID = ID;
            this.EventDateTime = eventDateTime;
            this.UserID = userID;
            this.EventType = (int)eventType;
            this.Name = name;
        }
    }
}

