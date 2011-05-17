using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ISIS.Web
{
    public static class TemplateActionLinkExtensions
    {

        public static MvcHtmlString TemplateActionLink(this HtmlHelper htmlHelper, string linkText, string actionName)
        {
            return TemplateActionLink(htmlHelper, linkText, actionName, null /* controllerName */,
                                      new RouteValueDictionary(), new RouteValueDictionary());
        }

        public static MvcHtmlString TemplateActionLink(this HtmlHelper htmlHelper, string linkText, string actionName,
                                                       object routeValues)
        {
            return TemplateActionLink(htmlHelper, linkText, actionName, null /* controllerName */,
                                      new RouteValueDictionary(routeValues), new RouteValueDictionary());
        }

        public static MvcHtmlString TemplateActionLink(this HtmlHelper htmlHelper, string linkText, string actionName,
                                                       object routeValues, object htmlAttributes)
        {
            return TemplateActionLink(htmlHelper, linkText, actionName, null /* controllerName */,
                                      new RouteValueDictionary(routeValues),
                                      HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        }

        public static MvcHtmlString TemplateActionLink(this HtmlHelper htmlHelper, string linkText, string actionName,
                                                       RouteValueDictionary routeValues)
        {
            return TemplateActionLink(htmlHelper, linkText, actionName, null /* controllerName */, routeValues,
                                      new RouteValueDictionary());
        }

        public static MvcHtmlString TemplateActionLink(this HtmlHelper htmlHelper, string linkText, string actionName,
                                                       RouteValueDictionary routeValues,
                                                       IDictionary<string, object> htmlAttributes)
        {
            return TemplateActionLink(htmlHelper, linkText, actionName, null /* controllerName */, routeValues,
                                      htmlAttributes);
        }

        public static MvcHtmlString TemplateActionLink(this HtmlHelper htmlHelper, string linkText, string actionName,
                                                       string controllerName)
        {
            return TemplateActionLink(htmlHelper, linkText, actionName, controllerName, new RouteValueDictionary(),
                                      new RouteValueDictionary());
        }

        public static MvcHtmlString TemplateActionLink(this HtmlHelper htmlHelper, string linkText, string actionName,
                                                       string controllerName, object routeValues, object htmlAttributes)
        {
            return TemplateActionLink(htmlHelper, linkText, actionName, controllerName,
                                      new RouteValueDictionary(routeValues),
                                      HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        }

        public static MvcHtmlString TemplateActionLink(this HtmlHelper htmlHelper, string linkText, string actionName,
                                                       string controllerName, RouteValueDictionary routeValues,
                                                       IDictionary<string, object> htmlAttributes)
        {
            if (String.IsNullOrEmpty(linkText))
            {
                throw new ArgumentException("linkText can't be null or empty", "linkText");
            }
            return
                MvcHtmlString.Create(GenerateLink(htmlHelper.ViewContext.RequestContext, htmlHelper.RouteCollection,
                                                  linkText, null /* routeName */, actionName, controllerName,
                                                  routeValues, htmlAttributes));
        }

        public static MvcHtmlString TemplateActionLink(this HtmlHelper htmlHelper, string linkText, string actionName,
                                                       string controllerName, string protocol, string hostName,
                                                       string fragment, object routeValues, object htmlAttributes)
        {
            return TemplateActionLink(htmlHelper, linkText, actionName, controllerName, protocol, hostName, fragment,
                                      new RouteValueDictionary(routeValues),
                                      HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        }

        public static MvcHtmlString TemplateActionLink(this HtmlHelper htmlHelper, string linkText, string actionName,
                                                       string controllerName, string protocol, string hostName,
                                                       string fragment, RouteValueDictionary routeValues,
                                                       IDictionary<string, object> htmlAttributes)
        {
            if (String.IsNullOrEmpty(linkText))
            {
                throw new ArgumentException("linkText can't be null or empty", "linkText");
            }
            return
                MvcHtmlString.Create(GenerateLink(htmlHelper.ViewContext.RequestContext, htmlHelper.RouteCollection,
                                                  linkText, null /* routeName */, actionName, controllerName, protocol,
                                                  hostName, fragment, routeValues, htmlAttributes));
        }

        private static string GenerateLink(RequestContext requestContext, RouteCollection routeCollection,
                                           string linkText, string routeName, string actionName, string controllerName,
                                           RouteValueDictionary routeValues, IDictionary<string, object> htmlAttributes)
        {
            return GenerateLink(requestContext, routeCollection, linkText, routeName, actionName, controllerName, null
                                /* protocol */, null /* hostName */, null /* fragment */, routeValues, htmlAttributes);
        }

        private static string GenerateLink(RequestContext requestContext, RouteCollection routeCollection,
                                           string linkText, string routeName, string actionName, string controllerName,
                                           string protocol, string hostName, string fragment,
                                           RouteValueDictionary routeValues, IDictionary<string, object> htmlAttributes)
        {
            return GenerateLinkInternal(requestContext, routeCollection, linkText, routeName, actionName, controllerName,
                                        protocol, hostName, fragment, routeValues, htmlAttributes, true
                /* includeImplicitMvcValues */);
        }

        private static string GenerateLinkInternal(RequestContext requestContext, RouteCollection routeCollection,
                                                   string linkText, string routeName, string actionName,
                                                   string controllerName, string protocol, string hostName,
                                                   string fragment, RouteValueDictionary routeValues,
                                                   IDictionary<string, object> htmlAttributes,
                                                   bool includeImplicitMvcValues)
        {
            var tokenMap = BuildTokenMap(routeValues);
            var patternRouteValues = Transform(routeValues, tokenMap);

            string url = UrlHelper.GenerateUrl(routeName, actionName, controllerName, protocol, hostName, fragment,
                                               patternRouteValues,
                                               routeCollection, requestContext, includeImplicitMvcValues);

            url = Transform(url, tokenMap);

            TagBuilder tagBuilder = new TagBuilder("a")
                                        {
                                            InnerHtml =
                                                (!String.IsNullOrEmpty(linkText))
                                                    ? HttpUtility.HtmlEncode(linkText)
                                                    : String.Empty
                                        };
            tagBuilder.MergeAttributes(htmlAttributes);
            tagBuilder.MergeAttribute("href", url);
            return tagBuilder.ToString(TagRenderMode.Normal);
        }

        private static IDictionary<Guid, Token> BuildTokenMap(RouteValueDictionary routeValues)
        {
            var tokens = routeValues.Values.OfType<Token>();
            return tokens.ToDictionary(
                t => Guid.NewGuid(),
                t => t);
        }

        private static RouteValueDictionary Transform(RouteValueDictionary values,
            IDictionary<Guid, Token> tokenMap)
        {
            var reverseMap = tokenMap.ToDictionary(
                item => (object) item.Value,
                item => item.Key);

            return new RouteValueDictionary(
                values.ToDictionary(
                    item => item.Key,
                    item => reverseMap.ContainsKey(item.Value)
                                ? reverseMap[item.Value]
                                : item.Value));
        }

        private static string Transform(string url, IDictionary<Guid, Token> tokenMap)
        {
            foreach (var item in tokenMap)
                url = url.Replace(item.Key.ToString(), item.Value.ToString());
            return url;
        }

    }
}