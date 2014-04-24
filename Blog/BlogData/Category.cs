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
    
    public partial class Category
    {
        public Category()
        {
            this.ArticleCategories = new HashSet<ArticleCategory>();
            this.TagCategories = new HashSet<TagCategory>();
        }
    
        public int CategoryRowId { get; set; }
        public int TopNavIndex { get; set; }
        public Nullable<int> CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string CategoryUrl { get; set; }
    
        public virtual ICollection<ArticleCategory> ArticleCategories { get; set; }
        public virtual ICollection<TagCategory> TagCategories { get; set; }
    }
}