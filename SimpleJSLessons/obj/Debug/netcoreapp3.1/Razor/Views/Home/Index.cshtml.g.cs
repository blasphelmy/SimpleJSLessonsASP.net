#pragma checksum "C:\Users\David Nguyen\Desktop\gitHub\SimpleJSLessonsASP.net\SimpleJSLessons\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "63cc30629a76f85450b404b9386b7ca0e0c96544"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"63cc30629a76f85450b404b9386b7ca0e0c96544", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4aca43440339f77659063bdc0cdc19bc518d3dd7", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<div class=\"row\">\r\n    <div class=\"col-10\">\r\n        <iframe scrolling=\"no\" id=\"iFrameMain\" name=\"iFrameMain\"");
            BeginWriteAttribute("src", " src=\"", 109, "\"", 115, 0);
            EndWriteAttribute();
            WriteLiteral(@" frameborder=""0""
                style=""position:relative; display:block;width:calc(100% + 15px);top:0px; right:15px; bottom:0; right:0; height:100%; border:none; margin:0; padding:0; overflow:hidden;""
                sandbox=""allow-scripts allow-same-origin"">
        </iframe>
    </div>
    <div class=""col-2"">

        <div style=""position:relative; width:calc(100% + 15px); right: 15px; height: 100vh; padding:10px; padding-top: 55px; color: rgb(255, 245, 245); background-color:rgb(61, 61, 61);
                     overflow: scroll; padding-bottom: 100px;"">

            <div class=""input-group mb-3"">
                <div class=""input-group-prepend"">
                    <span class=""input-group-text"" id=""basic-addon3"" readonly>Created By</span>
                </div>
                <input type=""text"" class=""form-control"" id=""basic-url""");
            BeginWriteAttribute("value", " value=\"", 978, "\"", 1005, 1);
#nullable restore
#line 17 "C:\Users\David Nguyen\Desktop\gitHub\SimpleJSLessonsASP.net\SimpleJSLessons\Views\Home\Index.cshtml"
WriteAttributeValue("", 986, ViewBag.AuthoredBy, 986, 19, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" aria-describedby=\"basic-addon3\">\r\n            </div>\r\n\r\n            <div id=\"commentsList\">\r\n\r\n");
#nullable restore
#line 22 "C:\Users\David Nguyen\Desktop\gitHub\SimpleJSLessonsASP.net\SimpleJSLessons\Views\Home\Index.cshtml"
             foreach (CommentsTable comment in ViewBag.thisComments)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <div class=\"comment\">\r\n                    <p><a");
            BeginWriteAttribute("href", " href=\'", 1251, "\'", 1308, 2);
            WriteAttributeValue("", 1258, "/home/user?username=", 1258, 20, true);
#nullable restore
#line 25 "C:\Users\David Nguyen\Desktop\gitHub\SimpleJSLessonsASP.net\SimpleJSLessons\Views\Home\Index.cshtml"
WriteAttributeValue("", 1278, comment.CommentAuthorUsername, 1278, 30, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 25 "C:\Users\David Nguyen\Desktop\gitHub\SimpleJSLessonsASP.net\SimpleJSLessons\Views\Home\Index.cshtml"
                                                                               Write(comment.CommentAuthorUsername);

#line default
#line hidden
#nullable disable
            WriteLiteral(" says on ");
#nullable restore
#line 25 "C:\Users\David Nguyen\Desktop\gitHub\SimpleJSLessonsASP.net\SimpleJSLessons\Views\Home\Index.cshtml"
                                                                                                                      Write(comment.Date.ToShortTimeString());

#line default
#line hidden
#nullable disable
            WriteLiteral("</a></p>\r\n                    <p>");
#nullable restore
#line 26 "C:\Users\David Nguyen\Desktop\gitHub\SimpleJSLessonsASP.net\SimpleJSLessons\Views\Home\Index.cshtml"
                  Write(comment.Comment);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                </div>\r\n");
#nullable restore
#line 28 "C:\Users\David Nguyen\Desktop\gitHub\SimpleJSLessonsASP.net\SimpleJSLessons\Views\Home\Index.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </div>\r\n\r\n");
#nullable restore
#line 31 "C:\Users\David Nguyen\Desktop\gitHub\SimpleJSLessonsASP.net\SimpleJSLessons\Views\Home\Index.cshtml"
             if (ViewBag.authorized == 1)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                <div class=""input-group input-group-sm"">
                    <textarea id=""submitcomment"" class=""form-control"" aria-label=""With textarea"" rows=""2""></textarea>
                    <div class=""input-group-append"">
                        <button class=""btn btn-outline-secondary btn-sm"" type=""button"" onclick=""submitComment()"">Submit</button>
                    </div>
                </div>
");
#nullable restore
#line 39 "C:\Users\David Nguyen\Desktop\gitHub\SimpleJSLessonsASP.net\SimpleJSLessons\Views\Home\Index.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
            </div>
    </div>
</div>

<script src=""/js/iFrameHelper.js""></script>
<style>
    body,
    html {
        overflow: hidden;
    }

    .comment {
        background: rgb(71, 71, 71);
        border-radius: 8px;
        margin-bottom: 20px;
        overflow-wrap: break-word;
    }

        .comment > p {
            font-family: ""Arial"", Times, serif;
            font-size: 13px;
        }

        .comment > p, h1, h2, h3 {
            padding: 10px;
            margin: 0;
        }
</style>
");
#nullable restore
#line 69 "C:\Users\David Nguyen\Desktop\gitHub\SimpleJSLessonsASP.net\SimpleJSLessons\Views\Home\Index.cshtml"
 if (ViewBag.authorized == 1)
{

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    <script>
    function submitComment(e) {
        var newComment = document.getElementById(""submitcomment"").value;
        let newPost = {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({
                dataHash: '");
#nullable restore
#line 80 "C:\Users\David Nguyen\Desktop\gitHub\SimpleJSLessonsASP.net\SimpleJSLessons\Views\Home\Index.cshtml"
                      Write(ViewBag.key);

#line default
#line hidden
#nullable disable
            WriteLiteral("\',\r\n                Username: \'");
#nullable restore
#line 81 "C:\Users\David Nguyen\Desktop\gitHub\SimpleJSLessonsASP.net\SimpleJSLessons\Views\Home\Index.cshtml"
                      Write(ViewBag.username);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"',
                comment: newComment
            })
        }
        console.log(newPost);
        fetch(""/home/postComment"", newPost).then((response) => response.json()).then(function (data) {
            console.log(data);
            if(data === 0){
                $(""#commentsList"").append($(`<div class=""comment"">
                    <p><a href='/home/user?username=");
#nullable restore
#line 90 "C:\Users\David Nguyen\Desktop\gitHub\SimpleJSLessonsASP.net\SimpleJSLessons\Views\Home\Index.cshtml"
                                               Write(ViewBag.username);

#line default
#line hidden
#nullable disable
            WriteLiteral("\'>");
#nullable restore
#line 90 "C:\Users\David Nguyen\Desktop\gitHub\SimpleJSLessonsASP.net\SimpleJSLessons\Views\Home\Index.cshtml"
                                                                  Write(ViewBag.username);

#line default
#line hidden
#nullable disable
            WriteLiteral(" says</a></p>\r\n                    <p>${newComment}</p>\r\n                </div>`));\r\n            }\r\n            document.getElementById(\"submitcomment\").value = \"\";\r\n        });\r\n}\r\n    </script>\r\n");
#nullable restore
#line 98 "C:\Users\David Nguyen\Desktop\gitHub\SimpleJSLessonsASP.net\SimpleJSLessons\Views\Home\Index.cshtml"

}

#line default
#line hidden
#nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
