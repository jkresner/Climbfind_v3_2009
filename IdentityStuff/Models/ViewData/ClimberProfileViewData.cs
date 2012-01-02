using System;
using System.Linq;
using System.Collections.Generic;
using ClimbFind.Controller;
using ClimbFind.Model.Objects;

namespace ClimbFind.Web.Mvc.Models.ViewData
{
    public class ClimberProfileViewData : ISessionViewData
    {
        public ClimberProfile Profile { get; set; }
        public List<PartnerCall> UsersCalls { get; set; }

        public ClimberProfileViewData()
        {
        }

        public ClimberProfileViewData(Guid id)
        {
            Profile = new CFController().GetClimberProfile(id);
            UsersCalls = (from c in new CFController().GetUsersPartnerCalls(id) orderby c.PostedDateTime descending select c).ToList();
        }
    }
}
