using System;
using System.ComponentModel;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Callboard.App.Web.HtmlHelpers
{
    public static class HtmlImageExtension
    {
        public static IHtmlString RenderImage(this HtmlHelper helper, byte[] image, string extension, string imgclass = null,
                                   object htmlAttributes = null)
        {
            var builder = new TagBuilder("img");
            builder.MergeAttribute("class", imgclass);
            builder.MergeAttributes(AnonymousObjectToHtmlAttributes(htmlAttributes));

            var imageString = image != null ? Convert.ToBase64String(image) : "";
            var img = string.Format("data:image/" + extension + ";base64,{0}", imageString);
            builder.MergeAttribute("src", img);

            return MvcHtmlString.Create(builder.ToString(TagRenderMode.SelfClosing));
        }

        private static RouteValueDictionary AnonymousObjectToHtmlAttributes(object htmlAttributes)
        {
            RouteValueDictionary result = new RouteValueDictionary();
            if (htmlAttributes != null)
            {
                foreach (PropertyDescriptor property in TypeDescriptor.GetProperties(htmlAttributes))
                {
                    result.Add(property.Name.Replace('_', '-'), property.GetValue(htmlAttributes));
                }
            }
            return result;
        }
    }
}