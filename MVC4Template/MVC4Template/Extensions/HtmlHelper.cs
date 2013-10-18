using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

using MVC4Template;

namespace MVC4TemplateWebHelpers
{
    public static class HtmlHelpers
    {
        private const string Nbsp = "&nbsp;";

        public static HtmlString NbspIfEmpty(this HtmlHelper helper, string value)
        {
            return new HtmlString(string.IsNullOrEmpty(value) ? Nbsp : value);
        }

        public static MvcHtmlString Link(this HtmlHelper helper, string url, string text, string title, string styleClass)
        {
            string link = "<a class=\"" + styleClass + "\" href=\"" + StaticConfig.BaseSiteUrl + url + "\" title=\"" + title + "\">" + text + "</a>";
            return new MvcHtmlString(link);
        }

    }
}