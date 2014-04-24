using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using BlogData;
using BlogWeb.Models;

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
                        context.Articles.OrderBy(a => a.CreatedDate)
                            .Include(a => a.ArticleTags.Select(ab=>ab.Tag))
                            .Include(a => a.ArticleComments).ToList();
                    
                    
                    
                    
                }
                model.AppModel = PageModel;
               
            }
            catch (Exception ex)
            {
                ErrorModel err = new ErrorModel();
                err.InsertError(ex);
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
            return View();
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
