using System;
using System.Collections.Generic;
using System.Linq;
using ClimbFind.Helpers;
using ClimbFind.Model.DataAccess;
using ClimbFind.Model.Enum;
using ClimbFind.Model.Objects;


namespace ClimbFind.Controller
{
    public partial class CFController
    {
        public MediaShareDA msDA { get { return new MediaShareDA();  } }

        public Dictionary<MediaShare, int> GetLatestPlaceYouTubeMovies(int count)
        {
            return new MediaShareDA().GetLatestPlaceYouTubeMovies(count);
        }

        public List<FeedMoviePost> GetFeedMoviesBySettings(FeedSettings settings, int count)
        {
            List<FeedMoviePost> posts;
            
            if (settings.CurrentChannelType == (byte)FeedChannel.Place)
            {
                posts = msDA.GetLatestFeedMoviePostsForPlace(settings.PlaceID.Value, count);
            }
            else if (settings.CurrentChannelType == (byte)FeedChannel.Area)
            {
                posts = msDA.GetLatestFeedMoviePostsForArea(settings.AreaID.Value, count);
            }
            else if (settings.CurrentChannelType == (byte)FeedChannel.Climbers)
            {
                List<Guid> watchedUserIDs = (from c in settings.WatchedClimbers select c.WatchedUserID).ToList();
                if (watchedUserIDs.Count == 0) { return new List<FeedMoviePost>(); }
                else { posts =msDA.GetLatestFeedMoviePostsByClimbers(watchedUserIDs, count); }
            }
            else
            {
                posts= msDA.GetLatestFeedMoviePosts(count);
            }
            
            foreach (FeedMoviePost p in posts) { p.Comments = GetCommentsForMedia(p.PlaceMedia.MessageBoardID); }

            return posts;
        }

        public List<MediaShare> GetUsersYouTubeMovies(Guid userID, int count)
        {
            return new MediaShareDA().GetUsersYouTubeMovies(userID, count);
        }

        public List<FeedMoviePost> GetFeedMoviesForUser(Guid userID, int count)
        {
            return new MediaShareDA().GetUsersFeedMoviePosts(userID, count);
        }

        public List<FeedMoviePost> GetFeedMoviesForPlace(int placeID, int count)
        {
            List<FeedMoviePost> movies = new MediaShareDA().GetLatestFeedMoviePostsForPlace(placeID, count);
            foreach (FeedMoviePost p in movies) { p.Comments = GetCommentsForMedia(p.PlaceMedia.MessageBoardID); }
            return movies;
        }

        public List<MediaShare> GetAllUsersMedia(Guid userID)
        {
            int count = -1;
            return new MediaShareDA().GetUsersYouTubeMovies(userID, count);
        }

        public void DeleteMedia(Guid id)
        {
            new MediaShareDA().Delete(id);
        }
 


        public List<MediaShare> GetMediaForPlace(int placeID)
        {
            return new MediaShareDA().GetMediaForPlace(placeID);
        }

        public List<MediaShare> GetMediaForCrag(Guid cragID)
        {
            return new MediaShareDA().GetMediaForOutdoorCrag(cragID);
        }

        public MediaShare GetMedia(Guid id)
        {
            return new MediaShareDA().GetByID(id);
        }


        public MediaShare AddPlaceYouTubeMovie(int placeID, string url, string title, string description)
        {
            MediaShare media = new MediaShare
                {
                    MessageBoardID = InsertNewMessageBoard(),
                    ID = Guid.NewGuid(),
                    SubmittedByUserID = CurrentClimber.ID,
                    Uri = url,
                    Name = title,
                    Description = description,
                    SubmittedDateTime = DateTime.Now,
                    Type = (int)MediaType.YouTubeVideo
                };

            return new MediaShareDA().InsertPlaceMedia(media, placeID);
        }

        public MediaShare AddCragYouTubeMovie(Guid cragID, string url, string title, string description)
        {
            MediaShare media = new MediaShare
            {
                MessageBoardID = InsertNewMessageBoard(),
                ID = Guid.NewGuid(),
                SubmittedByUserID = CurrentClimber.ID,
                Uri = url,
                Name = title,
                Description = description,
                SubmittedDateTime = DateTime.Now,
                Type = (int)MediaType.YouTubeVideo
            };

            return new MediaShareDA().InsertCragMedia(media, cragID);
        }

    }
}
