using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using LinqToSql_FeatureArticlePhotoSet = ClimbFind.Model.LinqToSqlMapping.FeatureArticlePhotoSet;

namespace ClimbFind.Model.Objects
{
    public partial class PhotoSet : LinqToSql_FeatureArticlePhotoSet
    {
        private List<string> _photoImageNames;
        public List<string> PhotoImageNames { get { return GetImageNames(); } }
        public string ParentDirectory { get; set; }

        public string PhotoWebDirectory
        {
            get { return string.Format(@"/images/news/{0}/{1}", ParentDirectory, this.Directory); }
        }   
     
        public List<string> GetImageNames()
        {
            if (_photoImageNames != null) { return _photoImageNames; }
            else
            {
                string photoImageDirectory = string.Format(@"{0}images\news\{1}\{2}", 
                    AppDomain.CurrentDomain.BaseDirectory, ParentDirectory, this.Directory);

                string[] imagePaths1 = System.IO.Directory.GetFiles(photoImageDirectory);

                _photoImageNames = (from c in imagePaths1 select Path.GetFileName(c)).ToList();

                return _photoImageNames;
            }
        }

    }
}

