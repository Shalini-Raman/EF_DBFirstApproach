using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace EFDBFirstApproachNew.HtmlHelpers
{
    public static class FileHelper
    {
        public static MvcHtmlString File(this HtmlHelper htmlHelper,string CSSClassName)
        {
            TagBuilder tagBuilder = new TagBuilder("input");
            tagBuilder.MergeAttribute("id", "Image");
            tagBuilder.MergeAttribute("name", "Photo");
            tagBuilder.MergeAttribute("type", "file");
            tagBuilder.MergeAttribute("class", CSSClassName);
            return MvcHtmlString.Create(tagBuilder.ToString(TagRenderMode.SelfClosing));
        }
    }
}