using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogWeb.Models
{
    public class ArticleListModel
    {
        public ApplicationModel AppModel { get; set; }
        public List<BlogData.Article> Articles { get; set; }

        public void SetSEO()
        {
            
        }
    }
}