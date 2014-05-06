using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net.Mime;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using BlogData;
using BlogWeb.Models;
using System.Data;

namespace BlogWeb.Controllers
{
    public class HomeController : ApplicationController
    {
        public ActionResult Index()
        {
            
            PageModel.ActiveTopNavLink = "";
            PageModel.Description = "";
            PageModel.Keywords = "";
            PageModel.Title = "DaToof";

            ArticleListModel model = new ArticleListModel();
            try
            {
                using (var context = new BlogEntities())
                {
                    model.Articles = 
                        context.Articles.OrderByDescending(a => a.CreatedDate)
                            .Include(a => a.ArticleTags.Select(ab=>ab.Tag))
                            .Include(a => a.ArticleComments).ToList();

                    model.AllTags = context.TagCategories
                                            .Include(at => at.Tag)
                                            .Include(at => at.Category).ToList();

                    model.TrendingPosts = context.sp_GetTrendingPosts().ToList();

                }
                model.AppModel = PageModel;

            }
            catch (Exception ex)
            {
                ErrorModel err = new ErrorModel();
                err.InsertError(ex);
            }

            int itemIndex = 0;
            string tagName = "";
            foreach (Tag tag in model.AllTags.Where(at => at.CategoryId == 1).Select(at => at.Tag))
            {
                tagName = tag.TagName;
                itemIndex++;
            }

            return View(model);
        }

        public ActionResult List(string textId)
        {
            PageModel.ActiveTopNavLink = StaticConfig.TopNavItems.FirstOrDefault(n => n == textId);
            return View();
        }

        public ActionResult Tag(string textId)
        {

            return View();
        }

        public ActionResult Article(string categoryUrl, string subCategoryUrl, string subSubCategoryUrl, string textId)
        {
            ArticleModel model = new ArticleModel();
            model.AppModel = new ApplicationModel();
            
            try
            {
                using (var context = new BlogEntities())
                {
                    model.Article =
                        context.Articles.Where(a => a.URLLink == textId + ".html")
                            .Include(a => a.ArticleTags.Select(ab => ab.Tag))
                            .Include(a => a.ArticleComments).FirstOrDefault();
                }

                if (model.Article == null)
                {
                    throw new HttpException(404, "Are you sure you're in the right place?");
                }

            }
            catch (Exception ex)
            {
                ErrorModel err = new ErrorModel();
                err.InsertError(ex);
            }

            return View(model);

        }

        public ActionResult PostComment(ArticleComment comment)
        {
            var data = new object();
            try
            {
                comment.CreatedDate = DateTime.Now;
                using (var context = new BlogEntities())
                {
                    context.Entry(comment).State = EntityState.Added;
                    context.SaveChanges();
                }

                data = new { success = true };

            }catch(Exception ex)
            {
                data = new { success = false, message = "Failed to insert new comment." };
                return Json(data);
            }

            return Json(data);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        
    }
}
