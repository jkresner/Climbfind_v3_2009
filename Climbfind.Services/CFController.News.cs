using System;
using System.Collections.Generic;
using ClimbFind.Model.DataAccess;
using ClimbFind.Model.Objects;

namespace ClimbFind.Controller
{
    public partial class CFController
    {                  
        /// <summary>
        /// News stuff
        /// </summary>

        public Competition GetClimbingCompetition(DateTime dateTime, string friendlyUrl)
        {
            Competition comp = new CompetitionDA().Get(dateTime, friendlyUrl);
            if (!comp.MessageBoardID.HasValue) 
            {
                comp.MessageBoardID = InsertNewMessageBoard();
                new CompetitionDA().Update(comp);
            }

            return comp;
        }

        public List<FeatureArticle> GetAllFeatureArticle()
        {
            return new FeatureArticleDA().GetAll();
        }

        public List<Competition> GetAllClimbingCompetitions()
        {
            return new CompetitionDA().GetAll();
        }

        public FeatureArticle GetFeatureArticle(DateTime dateTime, string friendlyUrl)
        {
            FeatureArticle articles = new FeatureArticleDA().Get(dateTime, friendlyUrl);
            if (!articles.MessageBoardID.HasValue)
            {
                articles.MessageBoardID = InsertNewMessageBoard();
                new FeatureArticleDA().Update(articles);
            }

            return articles;
        }    
    }
}
