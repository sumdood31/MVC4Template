//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BlogData
{
    using System;
    using System.Collections.Generic;
    
    public partial class ArticleComment
    {
        public int CommentId { get; set; }
        public int ArticleId { get; set; }
        public string PosterName { get; set; }
        public string PosterEmail { get; set; }
        public string PosterWebSite { get; set; }
        public string CommentText { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public int RepyToCommentId { get; set; }
    
        public virtual Article Article { get; set; }
    }
}
