using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using ClimbFind.Controller;
using ClimbFind.Model.Objects;

namespace ClimbFind.Web.Mvc.Views.Admin
{
    public partial class ExceptionsList : ViewPage
    {
        protected int i = 1;
        
        public List<LogExceptionEvent> LogEvents { get; set; }
       
        public void Page_Load(Object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LogEvents = CFLogger.GetLast30Exceptions();
                LogLV.DataSource = LogEvents;
                LogLV.DataBind();
            }
        }


        public void DelteLogs_Click(Object sender, EventArgs e)
        {
            CFController cf = new CFController();
            SaveLogEvents(l => cf.DeleteLogExceptionEvent(l));
        }

        public void ArchiveLogs_Click(Object sender, EventArgs e)
        {
            throw new NotImplementedException();

            //CFController cf = new CFController();
            //SaveLogEvents(l => cf.ArchiveLogExceptionEvent(l));
        }

        public delegate void SetterDelegate(int id);

        public void SaveLogEvents(SetterDelegate setMethod)
        {
            foreach (ListViewDataItem item in LogLV.Items)
            {
                CheckBox toDeleteCB = item.FindControl("DelCB") as CheckBox;
                if (toDeleteCB.Checked)
                {
                    int logEventID = int.Parse((item.FindControl("eID") as Literal).Text);
                    setMethod.DynamicInvoke(logEventID);
                }
            }

            Response.Redirect(Page.Request.Url.ToString(), false);
        }
    }
}
