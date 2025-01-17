#pragma checksum "C:\Users\Joshua\Dropbox (Personal)\ETSU\Fall-2019\Adv-web\Proman\Proman\Proman\Views\Person\PersonReport.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d3a6bc44693705a1b39cacddd6b33262cbd2349c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Person_PersonReport), @"mvc.1.0.view", @"/Views/Person/PersonReport.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Person/PersonReport.cshtml", typeof(AspNetCore.Views_Person_PersonReport))]
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
#line 1 "C:\Users\Joshua\Dropbox (Personal)\ETSU\Fall-2019\Adv-web\Proman\Proman\Proman\Views\_ViewImports.cshtml"
using Proman;

#line default
#line hidden
#line 2 "C:\Users\Joshua\Dropbox (Personal)\ETSU\Fall-2019\Adv-web\Proman\Proman\Proman\Views\_ViewImports.cshtml"
using Proman.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d3a6bc44693705a1b39cacddd6b33262cbd2349c", @"/Views/Person/PersonReport.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c4ab982f22e8e482a3940df03ab59fa61ed24436", @"/Views/_ViewImports.cshtml")]
    public class Views_Person_PersonReport : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Proman.Models.ViewModels.PersonReportVM>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-primary"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Home", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 2 "C:\Users\Joshua\Dropbox (Personal)\ETSU\Fall-2019\Adv-web\Proman\Proman\Proman\Views\Person\PersonReport.cshtml"
  
    ViewData["Title"] = "Person Report";

#line default
#line hidden
            BeginContext(97, 4, true);
            WriteLiteral("<h1>");
            EndContext();
            BeginContext(102, 17, false);
#line 5 "C:\Users\Joshua\Dropbox (Personal)\ETSU\Fall-2019\Adv-web\Proman\Proman\Proman\Views\Person\PersonReport.cshtml"
Write(ViewData["Title"]);

#line default
#line hidden
            EndContext();
            BeginContext(119, 505, true);
            WriteLiteral(@"</h1>
<div>
    <h4>View all the current people and the projects they are assigned to.</h4>
    <hr />
    <dl class=""row""></dl>
</div>
<table class=""m-5"">
    <thead>
        <tr>
            <th class=""p-3"">People</th>
            <th class=""p-3""># of Projects</th>
            <th class=""p-3"">Project assigned</th>
            <th class=""p-3"">Roles</th>
            <th class=""p-3"">Hourly Rate</th>
            <th class=""p-3"">Total Hourly</th>
        </tr>
    </thead>
    <tbody>
");
            EndContext();
#line 24 "C:\Users\Joshua\Dropbox (Personal)\ETSU\Fall-2019\Adv-web\Proman\Proman\Proman\Views\Person\PersonReport.cshtml"
         foreach (var eachPerson in Model.ListOfProjectsAndPeople.OrderBy(s => s.Key))
        {

#line default
#line hidden
            BeginContext(795, 59, true);
            WriteLiteral("            <tr>\r\n                <td class=\"border p-3\">\r\n");
            EndContext();
            BeginContext(900, 20, true);
            WriteLiteral("                    ");
            EndContext();
            BeginContext(921, 44, false);
#line 29 "C:\Users\Joshua\Dropbox (Personal)\ETSU\Fall-2019\Adv-web\Proman\Proman\Proman\Views\Person\PersonReport.cshtml"
               Write(Html.DisplayFor(modelItem => eachPerson.Key));

#line default
#line hidden
            EndContext();
            BeginContext(965, 66, true);
            WriteLiteral("\r\n                </td>\r\n                <td class=\"border p-3\">\r\n");
            EndContext();
            BeginContext(1100, 20, true);
            WriteLiteral("                    ");
            EndContext();
            BeginContext(1121, 52, false);
#line 33 "C:\Users\Joshua\Dropbox (Personal)\ETSU\Fall-2019\Adv-web\Proman\Proman\Proman\Views\Person\PersonReport.cshtml"
               Write(Html.DisplayFor(modelItem => eachPerson.Value.Count));

#line default
#line hidden
            EndContext();
            BeginContext(1173, 66, true);
            WriteLiteral("\r\n                </td>\r\n                <td class=\"border p-3\">\r\n");
            EndContext();
#line 37 "C:\Users\Joshua\Dropbox (Personal)\ETSU\Fall-2019\Adv-web\Proman\Proman\Proman\Views\Person\PersonReport.cshtml"
                     foreach (var eachProject in eachPerson.Value.OrderBy(s => s.Key.Name))
                    {

#line default
#line hidden
            BeginContext(1423, 32, true);
            WriteLiteral("                        <span>\r\n");
            EndContext();
            BeginContext(1510, 28, true);
            WriteLiteral("                            ");
            EndContext();
            BeginContext(1539, 50, false);
#line 41 "C:\Users\Joshua\Dropbox (Personal)\ETSU\Fall-2019\Adv-web\Proman\Proman\Proman\Views\Person\PersonReport.cshtml"
                       Write(Html.DisplayFor(modelItem => eachProject.Key.Name));

#line default
#line hidden
            EndContext();
            BeginContext(1589, 41, true);
            WriteLiteral("\r\n                        </span><br />\r\n");
            EndContext();
#line 43 "C:\Users\Joshua\Dropbox (Personal)\ETSU\Fall-2019\Adv-web\Proman\Proman\Proman\Views\Person\PersonReport.cshtml"
                    }

#line default
#line hidden
            BeginContext(1653, 64, true);
            WriteLiteral("                </td>\r\n                <td class=\"border p-3\">\r\n");
            EndContext();
#line 47 "C:\Users\Joshua\Dropbox (Personal)\ETSU\Fall-2019\Adv-web\Proman\Proman\Proman\Views\Person\PersonReport.cshtml"
                     foreach (var each in eachPerson.Value.OrderBy(s => s.Key.Name))
                    {

#line default
#line hidden
            BeginContext(1925, 32, true);
            WriteLiteral("                        <span>\r\n");
            EndContext();
#line 51 "C:\Users\Joshua\Dropbox (Personal)\ETSU\Fall-2019\Adv-web\Proman\Proman\Proman\Views\Person\PersonReport.cshtml"
                             foreach (var eachRole in each.Value.OrderBy(s => s.Key.Name))
                            {
                                        

#line default
#line hidden
            BeginContext(2220, 38, true);
            WriteLiteral("                                <span>");
            EndContext();
            BeginContext(2259, 47, false);
#line 54 "C:\Users\Joshua\Dropbox (Personal)\ETSU\Fall-2019\Adv-web\Proman\Proman\Proman\Views\Person\PersonReport.cshtml"
                                 Write(Html.DisplayFor(modelItem => eachRole.Key.Name));

#line default
#line hidden
            EndContext();
            BeginContext(2306, 11, true);
            WriteLiteral(", </span>\r\n");
            EndContext();
#line 55 "C:\Users\Joshua\Dropbox (Personal)\ETSU\Fall-2019\Adv-web\Proman\Proman\Proman\Views\Person\PersonReport.cshtml"
                            }

#line default
#line hidden
            BeginContext(2348, 39, true);
            WriteLiteral("                        </span><br />\r\n");
            EndContext();
#line 57 "C:\Users\Joshua\Dropbox (Personal)\ETSU\Fall-2019\Adv-web\Proman\Proman\Proman\Views\Person\PersonReport.cshtml"
                    }

#line default
#line hidden
            BeginContext(2410, 64, true);
            WriteLiteral("                </td>\r\n                <td class=\"border p-3\">\r\n");
            EndContext();
#line 61 "C:\Users\Joshua\Dropbox (Personal)\ETSU\Fall-2019\Adv-web\Proman\Proman\Proman\Views\Person\PersonReport.cshtml"
                     foreach (var each in eachPerson.Value)
                    {

#line default
#line hidden
            BeginContext(2640, 32, true);
            WriteLiteral("                        <span>\r\n");
            EndContext();
#line 65 "C:\Users\Joshua\Dropbox (Personal)\ETSU\Fall-2019\Adv-web\Proman\Proman\Proman\Views\Person\PersonReport.cshtml"
                             foreach (var eachRole in each.Value)
                            {
                                

#line default
#line hidden
            BeginContext(2891, 39, true);
            WriteLiteral("                                <span>$");
            EndContext();
            BeginContext(2931, 44, false);
#line 68 "C:\Users\Joshua\Dropbox (Personal)\ETSU\Fall-2019\Adv-web\Proman\Proman\Proman\Views\Person\PersonReport.cshtml"
                                  Write(Html.DisplayFor(modelItem => eachRole.Value));

#line default
#line hidden
            EndContext();
            BeginContext(2975, 11, true);
            WriteLiteral(", </span>\r\n");
            EndContext();
#line 69 "C:\Users\Joshua\Dropbox (Personal)\ETSU\Fall-2019\Adv-web\Proman\Proman\Proman\Views\Person\PersonReport.cshtml"
                            }

#line default
#line hidden
            BeginContext(3017, 39, true);
            WriteLiteral("                        </span><br />\r\n");
            EndContext();
#line 71 "C:\Users\Joshua\Dropbox (Personal)\ETSU\Fall-2019\Adv-web\Proman\Proman\Proman\Views\Person\PersonReport.cshtml"
                    }

#line default
#line hidden
            BeginContext(3079, 64, true);
            WriteLiteral("                </td>\r\n                <td class=\"border p-3\">\r\n");
            EndContext();
#line 75 "C:\Users\Joshua\Dropbox (Personal)\ETSU\Fall-2019\Adv-web\Proman\Proman\Proman\Views\Person\PersonReport.cshtml"
                                                                        
                        decimal total = 0;
                    

#line default
#line hidden
            BeginContext(3308, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 80 "C:\Users\Joshua\Dropbox (Personal)\ETSU\Fall-2019\Adv-web\Proman\Proman\Proman\Views\Person\PersonReport.cshtml"
                     foreach (var each in eachPerson.Value)
                    {

#line default
#line hidden
            BeginContext(3472, 32, true);
            WriteLiteral("                        <span>\r\n");
            EndContext();
#line 84 "C:\Users\Joshua\Dropbox (Personal)\ETSU\Fall-2019\Adv-web\Proman\Proman\Proman\Views\Person\PersonReport.cshtml"
                                                                      
                                total = total + each.Value.Values.Sum();
                            

#line default
#line hidden
            BeginContext(3713, 39, true);
            WriteLiteral("                        </span><br />\r\n");
            EndContext();
#line 88 "C:\Users\Joshua\Dropbox (Personal)\ETSU\Fall-2019\Adv-web\Proman\Proman\Proman\Views\Person\PersonReport.cshtml"
                    }

#line default
#line hidden
            BeginContext(3775, 20, true);
            WriteLiteral("                    ");
            EndContext();
            BeginContext(3845, 23, true);
            WriteLiteral("\r\n                    $");
            EndContext();
            BeginContext(3870, 5, false);
#line 90 "C:\Users\Joshua\Dropbox (Personal)\ETSU\Fall-2019\Adv-web\Proman\Proman\Proman\Views\Person\PersonReport.cshtml"
                 Write(total);

#line default
#line hidden
            EndContext();
            BeginContext(3876, 44, true);
            WriteLiteral("\r\n                </td>\r\n            </tr>\r\n");
            EndContext();
#line 93 "C:\Users\Joshua\Dropbox (Personal)\ETSU\Fall-2019\Adv-web\Proman\Proman\Proman\Views\Person\PersonReport.cshtml"
        }

#line default
#line hidden
            BeginContext(3931, 24, true);
            WriteLiteral("    </tbody>\r\n</table>\r\n");
            EndContext();
            BeginContext(3955, 89, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d3a6bc44693705a1b39cacddd6b33262cbd2349c14552", async() => {
                BeginContext(4023, 17, true);
                WriteLiteral("Back to Home Page");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(4044, 4, true);
            WriteLiteral("\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Proman.Models.ViewModels.PersonReportVM> Html { get; private set; }
    }
}
#pragma warning restore 1591
