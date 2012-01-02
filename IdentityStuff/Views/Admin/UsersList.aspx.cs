using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;
using ClimbFind.Model.DataAccess;
using ClimbFind.Model.Objects;

namespace IdentityStuff.Views.Admin
{
    public partial class UsersList : ViewPage
    {
        public List<MembershipUser> SiteMembers = new List<MembershipUser>();
        public List<ClimberProfile> CFMembers { get; set; }

        protected void Page_Load(Object o, EventArgs e)
        {
            CFMembers = new ClimberProfileDA().GetAll();

            List<MembershipUser> siteMembers = new List<MembershipUser>();
            foreach (MembershipUser user in Membership.GetAllUsers()) { siteMembers.Add(user); }

            if (Request.QueryString["ProfileComplete"] != null)
            {
                string profileCompletedFilter = Request.QueryString["ProfileComplete"].ToString();
                if (profileCompletedFilter == "True") { siteMembers = GetCompletedProfiles(siteMembers, true); }
                else if (profileCompletedFilter == "False") { siteMembers = GetCompletedProfiles(siteMembers, false); }
            }

            if (Request.QueryString["ActiveOnly"] != null)
            {
                siteMembers = (from c in siteMembers where (c.LastLoginDate > DateTime.Now.AddDays(-7)) select c).ToList();
            }

            SiteMembers = (from c in siteMembers orderby c.CreationDate descending select c).ToList();        
        }

        protected string GetFullName(string email)
        {
            return (from c in CFMembers where c.Email == email select c.FullName).SingleOrDefault();
        }

        protected string GetIsModerator(string email)
        {
            if ((from c in CFMembers where c.Email == email select c.IsModerator).SingleOrDefault()) { return @"<img src=""/images/UI/elite/page.gif"" />"; }
            else return "";
        }

        protected bool IsModerator(string email)
        {
            return (from c in CFMembers where c.Email == email select c.IsModerator).SingleOrDefault();
        }

        protected string GetIsFinished(string email)
        {
            if (!(from c in CFMembers where c.Email == email select c.IsUnfinished).SingleOrDefault()) { return @"<img src=""/images/UI/icons/yes.gif"" />"; }
            else { return @"<img src=""/images/UI/icons/Warning.png"" />"; }
        }
    
        protected List<MembershipUser> GetCompletedProfiles(List<MembershipUser> siteMembers, bool profileComplete)
        {
            List<ClimberProfile> profilesToShow = CFMembers;
            if (!profileComplete) { profilesToShow = (from c in CFMembers where c.IsUnfinished select c).ToList(); }
            else if (profileComplete) { profilesToShow = (from c in CFMembers where !c.IsUnfinished select c).ToList(); }
     
            List<MembershipUser> filteredSiteMembers = new List<MembershipUser>();
            foreach (ClimberProfile profile in profilesToShow) 
            {
                MembershipUser u = (from c in siteMembers where (Guid)c.ProviderUserKey == profile.ID select c).SingleOrDefault();
                if (u == null) { throw new Exception(profile.ID.ToString()); }
                else { filteredSiteMembers.Add(u); }
            }
            
            return filteredSiteMembers;
        }

        protected string GetEmailVerified(string email)
        {
            if ((from c in CFMembers where c.Email == email select c.EmailVerified).SingleOrDefault()) { return @"<img src=""/images/UI/icons/yes.gif"" />"; }
            else { return @"<img src=""/images/UI/icons/Warning.png"" />"; }
        }
       
}}

