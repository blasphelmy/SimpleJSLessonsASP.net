#pragma checksum "C:\Users\David Nguyen\Desktop\gitHub\SimpleJSLessonsASP.net\SimpleJSLessons\Views\Home\user.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e38ba0bf150d2c9e75e8d32e941a17753e89af5b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_user), @"mvc.1.0.view", @"/Views/Home/user.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\David Nguyen\Desktop\gitHub\SimpleJSLessonsASP.net\SimpleJSLessons\Views\_ViewImports.cshtml"
using SimpleJSLessons;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\David Nguyen\Desktop\gitHub\SimpleJSLessonsASP.net\SimpleJSLessons\Views\_ViewImports.cshtml"
using SimpleJSLessons.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e38ba0bf150d2c9e75e8d32e941a17753e89af5b", @"/Views/Home/user.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4aca43440339f77659063bdc0cdc19bc518d3dd7", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Home_user : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<PublicUserInformationModel>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/masonaryEffect.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "e38ba0bf150d2c9e75e8d32e941a17753e89af5b3899", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n<br /><br />\r\n<h3>");
#nullable restore
#line 4 "C:\Users\David Nguyen\Desktop\gitHub\SimpleJSLessonsASP.net\SimpleJSLessons\Views\Home\user.cshtml"
Write(Model.username);

#line default
#line hidden
#nullable disable
            WriteLiteral(" authored demos</h3>\r\n<div class=\"container res\" style=\"max-width:95%\" data-masonry=\'{\"percentPosition\": true }\'>\r\n");
#nullable restore
#line 6 "C:\Users\David Nguyen\Desktop\gitHub\SimpleJSLessonsASP.net\SimpleJSLessons\Views\Home\user.cshtml"
     foreach (DataDataTable data in Model.AuthoredDemoed)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("    <a class=\"text-decoration-none\"");
            BeginWriteAttribute("href", " href=\"", 343, "\"", 370, 2);
            WriteAttributeValue("", 350, "/?key=", 350, 6, true);
#nullable restore
#line 8 "C:\Users\David Nguyen\Desktop\gitHub\SimpleJSLessonsASP.net\SimpleJSLessons\Views\Home\user.cshtml"
WriteAttributeValue("", 356, data.DataHash, 356, 14, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n        <div class=\"card\">\r\n");
#nullable restore
#line 10 "C:\Users\David Nguyen\Desktop\gitHub\SimpleJSLessonsASP.net\SimpleJSLessons\Views\Home\user.cshtml"
             if (data.ImageData != "null" && data.ImageData != null)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <img");
            BeginWriteAttribute("src", " src=\"", 507, "\"", 528, 1);
#nullable restore
#line 12 "C:\Users\David Nguyen\Desktop\gitHub\SimpleJSLessonsASP.net\SimpleJSLessons\Views\Home\user.cshtml"
WriteAttributeValue("", 513, data.ImageData, 513, 15, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("alt", " alt=\"", 529, "\"", 546, 1);
#nullable restore
#line 12 "C:\Users\David Nguyen\Desktop\gitHub\SimpleJSLessonsASP.net\SimpleJSLessons\Views\Home\user.cshtml"
WriteAttributeValue("", 535, data.Title, 535, 11, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n");
#nullable restore
#line 13 "C:\Users\David Nguyen\Desktop\gitHub\SimpleJSLessonsASP.net\SimpleJSLessons\Views\Home\user.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div class=\"text\">\r\n                <h3>");
#nullable restore
#line 15 "C:\Users\David Nguyen\Desktop\gitHub\SimpleJSLessonsASP.net\SimpleJSLessons\Views\Home\user.cshtml"
               Write(data.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n                <p>By ");
#nullable restore
#line 16 "C:\Users\David Nguyen\Desktop\gitHub\SimpleJSLessonsASP.net\SimpleJSLessons\Views\Home\user.cshtml"
                 Write(data.UploadedBy);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n            </div>\r\n        </div>\r\n    </a>\r\n");
#nullable restore
#line 20 "C:\Users\David Nguyen\Desktop\gitHub\SimpleJSLessonsASP.net\SimpleJSLessons\Views\Home\user.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n<script src=\"https://cdn.jsdelivr.net/npm/masonry-layout@4.2.2/dist/masonry.pkgd.min.js\" integrity=\"sha384-GNFwBvfVxBkLMJpYMOABq3c+d3KnQxudP/mGPkzpZSTYykLBNsZEnG2D9G/X/+7D\" crossorigin=\"anonymous\" async></script>");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<PublicUserInformationModel> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591