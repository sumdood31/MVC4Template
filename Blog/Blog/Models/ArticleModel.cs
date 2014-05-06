using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogWeb.Models
{
    public class ArticleModel
    {
        public ApplicationModel AppModel { get; set; }
        public BlogData.Article Article { get; set; }
    }
}