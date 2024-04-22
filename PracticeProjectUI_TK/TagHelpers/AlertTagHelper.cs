using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Diagnostics;

namespace PracticeProjectUI_TK.TagHelpers
{
    //custome tag helpers
    [HtmlTargetElement("bootstrap-alert")]
    public class AlertTagHelper:TagHelper
    {
        public string type { get; set; } = "info";
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";
            output.Attributes.SetAttribute("class",$"alert alert-{type}");
            output.TagMode = TagMode.StartTagAndEndTag;
        }
    }
}
