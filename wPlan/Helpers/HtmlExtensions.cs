using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace OdrorirBoard.Helpers
{
    public static class Html
    {
        /// <summary>
        /// Creates and Action link with a clickable image instead of text.
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="controller">Controller</param>
        /// <param name="action">Action</param>
        /// <param name="parameters">Parameters</param>
        /// <param name="src">Image source</param>
        /// <param name="alt">Alternate text(Optional)</param>
        /// <returns>An HTML anchor tag with a nested image tag.</returns>
        /// 
        public static MvcHtmlString OdrorirDelete(this HtmlHelper html, string linkText, string action, string controllerName,  Guid id, object htmlAttributes)
        {
            var routeValues = new System.Web.Routing.RouteValueDictionary();
            routeValues.Add("id", id);

            //build the tag
            linkText = string.Format("{0} <span class='glyphicon glyphicon-trash'></span>", linkText);
            TagBuilder tagBuilder = new TagBuilder("a");
            tagBuilder.InnerHtml = linkText;

            //Add Url
            UrlHelper urlHelper = new UrlHelper(html.ViewContext.RequestContext);
            var url = urlHelper.Action(action, routeValues);//(action+"/"+id, controllerName);
            string modalVal = "deleteModal";
            tagBuilder.MergeAttribute("href", url);
            tagBuilder.MergeAttribute("odrorir-dialogs", modalVal);
            //put it all together    
            return MvcHtmlString.Create(tagBuilder.ToString(TagRenderMode.Normal));
        }

        public static MvcHtmlString OdrorirDetails(this HtmlHelper html,string linkText, string action, string controllerName, Guid id, object htmlAttributes)
        {
            var routeValues = new System.Web.Routing.RouteValueDictionary();
            routeValues.Add("id", id);

            //build the tag
            var mvcString = new MvcHtmlString(linkText);
            linkText = string.Format("{0}", linkText);
            TagBuilder tagBuilder = new TagBuilder("a");
            tagBuilder.InnerHtml = linkText;

            //Add Url
            UrlHelper urlHelper = new UrlHelper(html.ViewContext.RequestContext);
            var url = urlHelper.Action(action, routeValues);
            string modalVal = "detailsModal";
            tagBuilder.MergeAttribute("href", url);
            tagBuilder.MergeAttribute("odrorir-dialogs", modalVal);
            //put it all together    
            return MvcHtmlString.Create(tagBuilder.ToString(TagRenderMode.Normal));
        }
    }
}  
    
