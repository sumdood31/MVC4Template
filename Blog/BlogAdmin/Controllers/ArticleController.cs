using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BlogAdmin.Models;
using BlogData;

namespace BlogAdmin.Controllers
{
    public class ArticleController : Controller
    {
        //
        // GET: /Article/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddArticle()
        {
            NewArticleModel article = new NewArticleModel();

            using (var context = new BlogEntities())
            {
                article.CategoryList = context.Categories.ToList();
                article.TagList = context.Tags.ToList();
            }

            return View();
        }

        public ActionResult EditArticle(int articleId)
        {
            NewArticleModel article = new NewArticleModel();

            using (var context = new BlogEntities())
            {
                article.Article =
                    context.Articles.Where(a => a.ArticleId == articleId).Include(a => a.ArticleTags).FirstOrDefault();
                //article.Article = context.Articles.FirstOrDefault(a => a.ArticleId == articleId);
                article.CategoryList = context.Categories.ToList();
                article.TagList = context.Tags.ToList();
            }

            return View(article);
        }

        public ActionResult UpdateArticle(Article post)
        {
            var data = new Object { };
            post.UpdateDate = DateTime.Now;
            using (var context = new BlogEntities())
            {

                context.Entry(post).State = EntityState.Modified;
   
                context.SaveChanges();

            }

            data = new { success = true};

            return Json(data, JsonRequestBehavior.AllowGet);

        }

        public ActionResult AddArticleTag(int tagId, int postId)
        {
            var data = new Object { };

            ArticleTag aTag = new ArticleTag();
            aTag.ArticleId = postId;
            aTag.TagId = tagId;
  
            using (var context = new BlogEntities())
            {
                context.Entry(aTag).State = EntityState.Added;
                context.SaveChanges();
            }

            data = new { success = true };

            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public ActionResult AddCategory(int catId, int postId)
        {
            var data = new Object { };

            ArticleCategory aCat = new ArticleCategory();
            aCat.CategoryId = catId;
            aCat.ArticleId = postId;
            
            using (var context = new BlogEntities())
            {
                context.Entry(aCat).State = EntityState.Added;
                context.SaveChanges();
            }

            data = new { success = true };

            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public ActionResult AllTags(string searchTerm)
        {
            var data = new Object { };

            List<Tag> tags = new List<Tag>();
            //var temp = System.Xml.Linq.XElement.Parse(test);
            using (var context = new BlogEntities())
            {
                tags = context.Tags.ToList();
            }

            var tagData = tags.Where(t => t.TagName.Contains(searchTerm) || t.TagName.ToLower().Contains(searchTerm)).Select(t => new
            {
                id = t.TagId,
                label = t.TagName,
                value = t.TagName
            });

            data = new { success = true, tags = tagData };

            return Json(tagData, JsonRequestBehavior.AllowGet);

        }

    }
}
