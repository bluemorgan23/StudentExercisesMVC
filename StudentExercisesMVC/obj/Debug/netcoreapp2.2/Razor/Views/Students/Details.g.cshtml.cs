#pragma checksum "C:\Users\bluem\Documents\projects\StudentExercisesMVC\StudentExercisesMVC\Views\Students\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "55fbf9acfda899ee95da6cd658a2db5118183652"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Students_Details), @"mvc.1.0.view", @"/Views/Students/Details.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Students/Details.cshtml", typeof(AspNetCore.Views_Students_Details))]
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
#line 1 "C:\Users\bluem\Documents\projects\StudentExercisesMVC\StudentExercisesMVC\Views\_ViewImports.cshtml"
using StudentExercisesMVC;

#line default
#line hidden
#line 2 "C:\Users\bluem\Documents\projects\StudentExercisesMVC\StudentExercisesMVC\Views\_ViewImports.cshtml"
using StudentExercisesMVC.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"55fbf9acfda899ee95da6cd658a2db5118183652", @"/Views/Students/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bae3dac0dc5d195cfb606d7b7ac9ff8ae977575d", @"/Views/_ViewImports.cshtml")]
    public class Views_Students_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<StudentExercisesMVC.Models.ViewModels.StudentDetailsViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(70, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\bluem\Documents\projects\StudentExercisesMVC\StudentExercisesMVC\Views\Students\Details.cshtml"
  
    ViewData["Title"] = "Details";

#line default
#line hidden
            BeginContext(115, 130, true);
            WriteLiteral("\r\n<h1>Details</h1>\r\n\r\n<div>\r\n    <h4>Student</h4>\r\n    <hr />\r\n    <dl class=\"row\">\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(246, 46, false);
#line 14 "C:\Users\bluem\Documents\projects\StudentExercisesMVC\StudentExercisesMVC\Views\Students\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Student.Id));

#line default
#line hidden
            EndContext();
            BeginContext(292, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(356, 42, false);
#line 17 "C:\Users\bluem\Documents\projects\StudentExercisesMVC\StudentExercisesMVC\Views\Students\Details.cshtml"
       Write(Html.DisplayFor(model => model.Student.Id));

#line default
#line hidden
            EndContext();
            BeginContext(398, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(461, 52, false);
#line 20 "C:\Users\bluem\Documents\projects\StudentExercisesMVC\StudentExercisesMVC\Views\Students\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Student.CohortId));

#line default
#line hidden
            EndContext();
            BeginContext(513, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(577, 48, false);
#line 23 "C:\Users\bluem\Documents\projects\StudentExercisesMVC\StudentExercisesMVC\Views\Students\Details.cshtml"
       Write(Html.DisplayFor(model => model.Student.CohortId));

#line default
#line hidden
            EndContext();
            BeginContext(625, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(688, 53, false);
#line 26 "C:\Users\bluem\Documents\projects\StudentExercisesMVC\StudentExercisesMVC\Views\Students\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Student.FirstName));

#line default
#line hidden
            EndContext();
            BeginContext(741, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(805, 49, false);
#line 29 "C:\Users\bluem\Documents\projects\StudentExercisesMVC\StudentExercisesMVC\Views\Students\Details.cshtml"
       Write(Html.DisplayFor(model => model.Student.FirstName));

#line default
#line hidden
            EndContext();
            BeginContext(854, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(917, 52, false);
#line 32 "C:\Users\bluem\Documents\projects\StudentExercisesMVC\StudentExercisesMVC\Views\Students\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Student.LastName));

#line default
#line hidden
            EndContext();
            BeginContext(969, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(1033, 48, false);
#line 35 "C:\Users\bluem\Documents\projects\StudentExercisesMVC\StudentExercisesMVC\Views\Students\Details.cshtml"
       Write(Html.DisplayFor(model => model.Student.LastName));

#line default
#line hidden
            EndContext();
            BeginContext(1081, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(1144, 49, false);
#line 38 "C:\Users\bluem\Documents\projects\StudentExercisesMVC\StudentExercisesMVC\Views\Students\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Student.Slack));

#line default
#line hidden
            EndContext();
            BeginContext(1193, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(1257, 45, false);
#line 41 "C:\Users\bluem\Documents\projects\StudentExercisesMVC\StudentExercisesMVC\Views\Students\Details.cshtml"
       Write(Html.DisplayFor(model => model.Student.Slack));

#line default
#line hidden
            EndContext();
            BeginContext(1302, 171, true);
            WriteLiteral("\r\n        </dd>\r\n    </dl>\r\n</div>\r\n<table class=\"table\">\r\n    <thead>\r\n        <tr>\r\n            <th> Assigned Exercises </th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
            EndContext();
#line 52 "C:\Users\bluem\Documents\projects\StudentExercisesMVC\StudentExercisesMVC\Views\Students\Details.cshtml"
         foreach (var exercise in Model.Exercises)
        {

#line default
#line hidden
            BeginContext(1536, 60, true);
            WriteLiteral("            <tr>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(1597, 51, false);
#line 56 "C:\Users\bluem\Documents\projects\StudentExercisesMVC\StudentExercisesMVC\Views\Students\Details.cshtml"
               Write(Html.DisplayFor(modelItem => exercise.ExerciseName));

#line default
#line hidden
            EndContext();
            BeginContext(1648, 22, true);
            WriteLiteral("\r\n                    ");
            EndContext();
            BeginContext(1671, 55, false);
#line 57 "C:\Users\bluem\Documents\projects\StudentExercisesMVC\StudentExercisesMVC\Views\Students\Details.cshtml"
               Write(Html.DisplayFor(modelItem => exercise.ExerciseLanguage));

#line default
#line hidden
            EndContext();
            BeginContext(1726, 44, true);
            WriteLiteral("\r\n                </td>\r\n            </tr>\r\n");
            EndContext();
#line 60 "C:\Users\bluem\Documents\projects\StudentExercisesMVC\StudentExercisesMVC\Views\Students\Details.cshtml"
        }

#line default
#line hidden
            BeginContext(1781, 35, true);
            WriteLiteral("    </tbody>\r\n</table>\r\n<div>\r\n    ");
            EndContext();
            BeginContext(1817, 62, false);
#line 64 "C:\Users\bluem\Documents\projects\StudentExercisesMVC\StudentExercisesMVC\Views\Students\Details.cshtml"
Write(Html.ActionLink("Edit", "Edit", new { id = Model.Student.Id }));

#line default
#line hidden
            EndContext();
            BeginContext(1879, 8, true);
            WriteLiteral(" |\r\n    ");
            EndContext();
            BeginContext(1887, 38, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "55fbf9acfda899ee95da6cd658a2db511818365210683", async() => {
                BeginContext(1909, 12, true);
                WriteLiteral("Back to List");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1925, 10, true);
            WriteLiteral("\r\n</div>\r\n");
            EndContext();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<StudentExercisesMVC.Models.ViewModels.StudentDetailsViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
