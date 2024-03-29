#pragma checksum "C:\Users\bluem\Documents\projects\StudentExercisesMVC\StudentExercisesMVC\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5dc1b5ef7a12e035541cc2b97748530218563e44"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/Index.cshtml", typeof(AspNetCore.Views_Home_Index))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5dc1b5ef7a12e035541cc2b97748530218563e44", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bae3dac0dc5d195cfb606d7b7ac9ff8ae977575d", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<StudentExercisesMVC.Models.ViewModels.StudentInstructorViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(73, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\bluem\Documents\projects\StudentExercisesMVC\StudentExercisesMVC\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "Students & Instructors";

#line default
#line hidden
            BeginContext(133, 6, true);
            WriteLiteral("\r\n<h2>");
            EndContext();
            BeginContext(140, 17, false);
#line 7 "C:\Users\bluem\Documents\projects\StudentExercisesMVC\StudentExercisesMVC\Views\Home\Index.cshtml"
Write(ViewData["Title"]);

#line default
#line hidden
            EndContext();
            BeginContext(157, 159, true);
            WriteLiteral("</h2>\r\n\r\n<h4>Students</h4>\r\n\r\n<table class=\"table\">\r\n    <thead>\r\n        <tr>\r\n            <th> Student Name </th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
            EndContext();
#line 18 "C:\Users\bluem\Documents\projects\StudentExercisesMVC\StudentExercisesMVC\Views\Home\Index.cshtml"
         foreach (var student in Model.Students)
        {

#line default
#line hidden
            BeginContext(377, 60, true);
            WriteLiteral("            <tr>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(438, 47, false);
#line 22 "C:\Users\bluem\Documents\projects\StudentExercisesMVC\StudentExercisesMVC\Views\Home\Index.cshtml"
               Write(Html.DisplayFor(modelItem => student.FirstName));

#line default
#line hidden
            EndContext();
            BeginContext(485, 22, true);
            WriteLiteral("\r\n                    ");
            EndContext();
            BeginContext(508, 46, false);
#line 23 "C:\Users\bluem\Documents\projects\StudentExercisesMVC\StudentExercisesMVC\Views\Home\Index.cshtml"
               Write(Html.DisplayFor(modelItem => student.LastName));

#line default
#line hidden
            EndContext();
            BeginContext(554, 44, true);
            WriteLiteral("\r\n                </td>\r\n            </tr>\r\n");
            EndContext();
#line 26 "C:\Users\bluem\Documents\projects\StudentExercisesMVC\StudentExercisesMVC\Views\Home\Index.cshtml"
        }

#line default
#line hidden
            BeginContext(609, 182, true);
            WriteLiteral("    </tbody>\r\n</table>\r\n\r\n<h4>Instructors</h4>\r\n\r\n<table class=\"table\">\r\n    <thead>\r\n        <tr>\r\n            <th> Instructor Name </th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
            EndContext();
#line 39 "C:\Users\bluem\Documents\projects\StudentExercisesMVC\StudentExercisesMVC\Views\Home\Index.cshtml"
         foreach (var instructor in Model.Instructors)
        {

#line default
#line hidden
            BeginContext(858, 60, true);
            WriteLiteral("            <tr>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(919, 50, false);
#line 43 "C:\Users\bluem\Documents\projects\StudentExercisesMVC\StudentExercisesMVC\Views\Home\Index.cshtml"
               Write(Html.DisplayFor(modelItem => instructor.FirstName));

#line default
#line hidden
            EndContext();
            BeginContext(969, 22, true);
            WriteLiteral("\r\n                    ");
            EndContext();
            BeginContext(992, 49, false);
#line 44 "C:\Users\bluem\Documents\projects\StudentExercisesMVC\StudentExercisesMVC\Views\Home\Index.cshtml"
               Write(Html.DisplayFor(modelItem => instructor.LastName));

#line default
#line hidden
            EndContext();
            BeginContext(1041, 44, true);
            WriteLiteral("\r\n                </td>\r\n            </tr>\r\n");
            EndContext();
#line 47 "C:\Users\bluem\Documents\projects\StudentExercisesMVC\StudentExercisesMVC\Views\Home\Index.cshtml"
        }

#line default
#line hidden
            BeginContext(1096, 22, true);
            WriteLiteral("    </tbody>\r\n</table>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<StudentExercisesMVC.Models.ViewModels.StudentInstructorViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
