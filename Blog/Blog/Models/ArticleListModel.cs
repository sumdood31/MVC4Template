using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BlogData;

namespace BlogWeb.Models
{
    public class ArticleListModel
    {
        public ApplicationModel AppModel { get; set; }
        public List<BlogData.Article> Articles { get; set; }

        public List<TagCategory> AllTags { get; set; }

        public List<sp_GetTrendingPosts_Result> TrendingPosts { get; set; }

        public void SetSEO()
        {
            
        }
    }
}