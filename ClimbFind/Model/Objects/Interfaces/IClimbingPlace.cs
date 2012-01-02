using System;

namespace ClimbFind.Model.Objects.Interfaces
{
    public interface IClimbingPlace
    {
        int ID { get; set; }
        string Name { get; set; }
        string ShortName { get; set; }
        string Description { get; set; } 
        string MetaKeywords { get; set; }
        string MetaDescription { get; set; }
        string FriendlyUrlName { get; set; }
        string FriendlyUrlLocation { get; set; }
        bool IsIndoor { get; }
        Guid MessageBoardID { get; set; }
        short CountryID { get; set; }

        string ClimbfindUrl { get; }
        //string PrimaryImageUrl { get; }

        decimal Latitude { get; set; }
        decimal Longitude { get; set; }
    }
}
