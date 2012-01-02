using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using ClimbFind.Model.Objects;
using LinqToSql_Club = ClimbFind.Model.LinqToSqlMapping.Club;
using LinqToSql_ClubArea = ClimbFind.Model.LinqToSqlMapping.ClubInArea;
using LinqToSql_ClubMember = ClimbFind.Model.LinqToSqlMapping.UserInClub;

namespace ClimbFind.Model.DataAccess
{
    public class ClubDA : AbstractBaseDA<Club, LinqToSql_Club, int>
    {
        public Club GetByUrlName(string friendlyUrlName)
        {
            LinqToSql_Club club = (from c in ctx.Clubs
                                     where c.FriendlyUrlName == friendlyUrlName
                                     select c).SingleOrDefault();

            if (club == default(LinqToSql_Club)) { return null; }
            else { return MapType(club); }
        }


        /// <summary>
        /// 
        /// </summary>
        public void DeleteAreaTag(int clubID, int areaTagID)
        {
            ctx.ClubInAreas.DeleteOnSubmit((from c in ctx.ClubInAreas
                                            where c.ClubID == clubID &&
                                              c.AreaTagID == areaTagID
                                              select c).SingleOrDefault());

            CommitChanges();
        }

        /// <summary>
        /// 
        /// </summary>
        public void InsertPlaceArea(int clubID, int areaTagID)
        {
            ctx.ClubInAreas.InsertOnSubmit(new LinqToSql_ClubArea { AreaTagID = areaTagID, ClubID = clubID });
            CommitChanges();
        }



        public void InsertMemeber(int clubID, Guid userID)
        {
            ctx.UserInClubs.InsertOnSubmit(new LinqToSql_ClubMember { ClubID = clubID, UserID = userID });
            ctx.SubmitChanges(ConflictMode.FailOnFirstConflict);
        }


        public void RemoveMemeber(int clubID, Guid userID)
        {
            LinqToSql_ClubMember member = (from c in ctx.UserInClubs
                                            where c.ClubID == clubID && c.UserID == userID
                                            select c).SingleOrDefault();

            ctx.UserInClubs.DeleteOnSubmit(member);

            ctx.SubmitChanges(ConflictMode.FailOnFirstConflict);
        }

        /// <summary>
        /// 
        /// </summary>
        public List<int> GetClubsUserBelongsTo(Guid userID)
        {
            return (from c in ctx.UserInClubs where c.UserID == userID select c.ClubID).ToList();
        }

        public List<Club> GetClubsInArea(int areaID)
        {
            return MapList((from cia in ctx.ClubInAreas from c in ctx.Clubs where cia.AreaTagID == areaID && cia.ClubID == c.ID select c).ToList());
        }

        /// <summary>
        /// 
        /// </summary>
        public bool UserBelongsToClub(Guid userID, int clubID)
        {
            return (from c in ctx.UserInClubs
                    where c.UserID == userID && c.ClubID == clubID
                    select c).Count() > 0;
        }
    }

}
