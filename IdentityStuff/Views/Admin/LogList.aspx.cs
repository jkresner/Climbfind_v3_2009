using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using ClimbFind.Controller;
using ClimbFind.Helpers;
using ClimbFind.Model.Enum;
using ClimbFind.Model.Objects;
using DDL_ListItem = System.Web.UI.WebControls.ListItem;

namespace ClimbFind.Web.Mvc.Views.Admin
{
    public partial class LogList : ViewPage
    {
        protected int i = 1;
        protected DateTime previousEventsDateTime = DateTime.MinValue;
        public Dictionary<Guid, string> Users { get; set; }

        private void PopulateDDL(List<LogEvent> logEvents)
        {
            SortedDictionary<string, Guid> UsersToListInDDL = new SortedDictionary<string, Guid>();
          
            Users = new CFController().GetAllClimberProfiles();

            UsersToListInDDL.Add("_ALL", Guid.Empty);
            IEnumerable<Guid> usersIDs = (from c in logEvents select c.UserID).Distinct();
            foreach (Guid userID in usersIDs) 
            {
                string userName = "Z_" + userID.ToString();
                if (Users.ContainsKey(userID)) { userName = Users[userID];  }

                UsersToListInDDL.Add(userName, userID);
            }

            //-- Populate UsersDDL
            foreach (string key in UsersToListInDDL.Keys)
            {
                UsersDDL.Items.Add(new DDL_ListItem { Text = key, Value = UsersToListInDDL[key].ToString() }); 
            }

            //-- Populate EventTypes
            foreach (CFLogEventType type in System.Enum.GetValues(typeof(CFLogEventType)))
            {
                EventTypeDDL.Items.Add(new DDL_ListItem { Text = type.ToString(), Value = ((int)type).ToString() });
            }
        }
        
        public void Page_Load(Object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                List<LogEvent> logEvents = CFLogger.GetLast10000();
                PopulateDDL(logEvents);
                List<LogEvent> logEventsToShow = logEvents.Take(120).Reverse().ToList();
                RenderLogs(logEventsToShow);
                
            }
        }


        public void FilterLogList_Click(Object sender, EventArgs e)
        {
            List<LogEvent> logEvents = CFLogger.Get(new Guid(UsersDDL.SelectedItem.Value), 
                    (CFLogEventType)int.Parse(EventTypeDDL.SelectedItem.Value));

            RenderLogs(logEvents);
        }


        public void DelteLogs_Click(Object sender, EventArgs e)
        {
            CFController cf = new CFController();
            SaveLogEvents(l => cf.DeleteLogEvent(l));
        }

        public void ArchiveLogs_Click(Object sender, EventArgs e)
        {
            throw new NotImplementedException();
            
            //CFController cf = new CFController();
            //SaveLogEvents(l => cf.ArchiveLogEvent(l));
        }

        public delegate void SetterDelegate(int id);

        /// <summary>
        /// 
        /// </summary>
        public void SaveLogEvents(SetterDelegate setMethod)
        {
            foreach (int logEventID in GetSelectedEventIDs())
            {
                setMethod.DynamicInvoke(logEventID);
            }

            Response.Redirect(Page.Request.Url.ToString(), false);
        }
        
        /// <summary>
        /// 
        /// </summary>
        public List<int> GetSelectedEventIDs()
        {
            List<int> selectedIDs = new List<int>();

            foreach (ListViewDataItem item in LogLV.Items)
            {
                CheckBox cb = item.FindControl("DelCB") as CheckBox;
                if (cb.Checked) { selectedIDs.Add(int.Parse((item.FindControl("eID") as Literal).Text)); }
            }

            return selectedIDs;
        }

        /// <summary>
        /// 
        /// </summary>
        private void RenderLogs(List<LogEvent> logEvents)
        {
            logEvents.Reverse();
            LogLV.DataSource = logEvents;
            LogLV.DataBind();

            if (logEvents.Count > 0)
            {
                EventDescriptionLb.Text = string.Format("{0} {1}",
                    logEvents[0].EventDateTime.GetAgoString(), logEvents[0].Name);
            }
            else
            {
                EventDescriptionLb.Text = "No events matching criteria";
            }
        }

        /// <summary>
        /// 
        /// </summary>
        protected void ShowTimeSpan_Click(Object sender, EventArgs e)
        {
            List<int> selectedIDs = GetSelectedEventIDs();

            if (selectedIDs.Count != 2) { EventDescriptionLb.Text = "<span style='color:red'>You must select only 2 events for this to work</span>"; }
            else
            {
                LogEvent secondEvent = CFLogger.GetByID(selectedIDs[0]);
                LogEvent firstEvent = CFLogger.GetByID(selectedIDs[1]);
                TimeSpan timeSpan = secondEvent.EventDateTime - firstEvent.EventDateTime;

                EventDescriptionLb.Text = string.Format("Time difference is {0}d {1}h {2}m", timeSpan.Days, timeSpan.Hours, timeSpan.Minutes);
            }

        }


        protected string ColorIfSpecialEvent(ClimbFind.Model.Enum.CFLogEventType eventType)
        {
            if (eventType == CFLogEventType.SignIn) { return " style='background:#D3D3D3'"; }
            if (eventType == CFLogEventType.Exception) { return " style='background:#ffcccc'"; }
            else { return ""; }
        }
    }
}
