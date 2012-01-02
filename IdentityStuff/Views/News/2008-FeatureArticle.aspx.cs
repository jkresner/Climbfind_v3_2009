using System;
using System.Collections.Generic;
using System.Linq;
using ClimbFind.Model.DataAccess;
using ClimbFind.Model.Objects;
using ClimbFind.Web.UI;

namespace IdentityStuff.Views.News
{
    public partial class FeatureArticle2008 : ClimbFindViewPage<FeatureArticle>
    {
        public List<FeatureArticle> Articles { get; set; }        
        
        public FeatureArticle Article { get { return ViewData.Model; } }
        public List<PhotoSet> ArticlePhotoSets { get; set; }

        public void Page_Init(Object o, EventArgs e)
        {
            ClimbFind.Model.Objects.MessageBoard messageBoard = cfController.GetMessageBoard(Article.MessageBoardID.Value);
            MessageBoardUC.RenderMessageBoard(messageBoard);   
            
            ArticlePhotoSets = new PhotoSetDA().Get(Article.ID);
            
            //-- Absolutely TERRIBLE Hack
            foreach (PhotoSet set in ArticlePhotoSets) { set.ParentDirectory = Article.ContentDirectory; }

            Articles = new FeatureArticleDA().GetAll().OrderBy(c => c.Date).ToList();
            Articles.Reverse();        
        }
    }
}
