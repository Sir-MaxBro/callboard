using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Callboard.App.Web.HtmlHelpers
{
    public static class HtmlPartialExtension
    {
        public static IHtmlString GetHtmlPartial(this HtmlHelper htmlHelper, string partialViewName, object model)
        {
            IDictionary<string, string> removedCharacters = new Dictionary<string, string>
            {
                { "\n", "" },
                { "\r", "" },
                { "\"", "\\\"" },
                { "\'", "\\\'" }
            };

            string partialView = System.Web.Mvc.Html.PartialExtensions.Partial(htmlHelper, partialViewName, model).ToString();

            StringBuilder partialViewHtml = new StringBuilder(partialView);

            foreach (var character in removedCharacters)
            {
                partialViewHtml.Replace(character.Key, character.Value);
            }

            return MvcHtmlString.Create(partialViewHtml.ToString());
        }
    }
}