using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using BlogData;
using BlogWeb.Models;

namespace BlogWeb
{
    public class StaticConfig
    {
        public static void LoadStaticCache()
        {
            //EXAMPLE OF HOW TO USE WITH A ORM TOOL
            //using (var context = new MDMContext())
            //{
            //    HttpContext.Current.Application["communicationType"] = context.CommunicationType.ToList();
            //}
            HttpContext.Current.Application["someVarName"] = "This is a test.  Normally a  list of objects but since no DB connection is made it's only a string...le sigh, poor string.";
            try
            {
                using (var context = new BlogEntities())
                {
                    List<Tag> tags = context.Tags.ToList();
                    HttpContext.Current.Application["allTags"] = tags;
                }
            }
            catch (Exception ex)
            {
                ErrorModel err = new ErrorModel();
                err.InsertError(ex);
            }

        }
        //EXAMPLE OF HOW TO USE WITH A ORM TOOL
        //public static List<CommunicationType> AllCommunicationTypes
        //{
        //    get
        //    {
        //        return HttpContext.Current.Application["communicationType"] as List<CommunicationType>;
        //    }
        //}


        public static string SiteName
        {
            get
            {
                return System.Configuration.ConfigurationManager.AppSettings["SiteName"] as string;
            }
        }

        public static string LunceneIndexLocation
        {
            get
            {
                return System.Configuration.ConfigurationManager.AppSettings["LuceneIndexLocation"] as string;
            }
        }
        
        public static string WebConfigSettingTest
        {
            get
            {
                return System.Configuration.ConfigurationManager.AppSettings["TestAppSetting"].ToString();
            }
        }

        public static string BaseSiteUrl
        {
            get
            {
                return System.Configuration.ConfigurationManager.AppSettings["URL"] as string;
            }
        }

        #region Static Mail Settings

        public static string MailSenderAddress
        {
            get
            {
                return System.Configuration.ConfigurationManager.AppSettings["SenderAddress"].ToString();
            }
        }

        public static string MailErrorAddress
        {
            get
            {
                return System.Configuration.ConfigurationManager.AppSettings["ErrorAddress"].ToString();
            }
        
        
        }

        public static List<string> TopNavItems
        {
            get
            {
                List<string> _topNavItems = new List<string>();
                _topNavItems.Add("science");
                _topNavItems.Add("tech");
                _topNavItems.Add("manufacturing");
                _topNavItems.Add("natuer");
                _topNavItems.Add("other");
                return _topNavItems;
            }
        }

        public static List<Tag> AllTags
        {
            get
            {
                return HttpContext.Current.Application["allTages"] as List<Tag>;
            }
        } 

        #endregion

    }
}