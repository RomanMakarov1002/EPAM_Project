using System;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace MvcPL.Infrastructure
{
    public static class PagingHelper
    {
        public static MvcHtmlString PageLink(this HtmlHelper html, Paging paging, Func<int, string> pageUrl)
        {
            StringBuilder result = new StringBuilder();
            for (int i = 1; i <= paging.TotalPages; i++)
            {
                TagBuilder tag = new TagBuilder("a");
                tag.MergeAttribute("href", pageUrl(i));
                tag.InnerHtml = i.ToString();
                if (i == paging.PageNumber)
                {
                    tag.AddCssClass("selected");
                    tag.AddCssClass("btn-primary");
                }
                tag.AddCssClass("btn btn-default");
                tag.GenerateId("page"+i.ToString());
                result.Append(tag.ToString());
            }
            return MvcHtmlString.Create(result.ToString());
        }
    }
}