using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogAdmin.Models
{
    public class NewArticleModel
    {
        public BlogData.Article Article { get; set; }

        public List<BlogData.Tag> TagList { get; set; }

        public List<BlogData.Category> CategoryList { get; set; }

    }
}