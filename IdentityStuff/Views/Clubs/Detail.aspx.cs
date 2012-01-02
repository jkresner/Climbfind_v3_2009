using System;
using System.Collections.Generic;
using System.Linq;
using ClimbFind.Model.Objects;
using ClimbFind.Web.UI;

namespace IdentityStuff.Views.Clubs
{
    public partial class Detail : ClimbFindViewPage<Club>
    {
        public Club club { get { return ViewData.Model; } }

        protected List<PartnerCall> ClubCalls { get; set; }

        protected List<ClimberProfile> Members { get; set; }
        protected List<Guid> MemberIDs { get { return (from c in Members select c.ID).ToList();} }

        public bool UserIsInClub { get { if (!UserLoggedIn) { return false; } else { return MemberIDs.Contains(UserID); } } }


        protected void Page_Init(Object s, EventArgs e)
        {
            Members = cfController.GetClubMembers(club.ID);
            //ClubCalls = cfController.GetClubsCalls(club.ID);
        }



    }
}
