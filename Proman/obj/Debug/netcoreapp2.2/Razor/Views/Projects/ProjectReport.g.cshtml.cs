#pragma checksum "C:\Users\Joshua\Dropbox\ETSU\Fall-2019\Adv-web\Proman - Copy\Proman\Views\Projects\ProjectReport.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b0cef01cd48bb4c4cdbf108672cb0999b5c19d78"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Projects_ProjectReport), @"mvc.1.0.view", @"/Views/Projects/ProjectReport.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Projects/ProjectReport.cshtml", typeof(AspNetCore.Views_Projects_ProjectReport))]
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
#line 1 "C:\Users\Joshua\Dropbox\ETSU\Fall-2019\Adv-web\Proman - Copy\Proman\Views\_ViewImports.cshtml"
using Proman;

#line default
#line hidden
#line 2 "C:\Users\Joshua\Dropbox\ETSU\Fall-2019\Adv-web\Proman - Copy\Proman\Views\_ViewImports.cshtml"
using Proman.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b0cef01cd48bb4c4cdbf108672cb0999b5c19d78", @"/Views/Projects/ProjectReport.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c4ab982f22e8e482a3940df03ab59fa61ed24436", @"/Views/_ViewImports.cshtml")]
    public class Views_Projects_ProjectReport : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Proman.Models.ViewModels.ProjectReportVM>
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
            BeginContext(49, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\Joshua\Dropbox\ETSU\Fall-2019\Adv-web\Proman - Copy\Proman\Views\Projects\ProjectReport.cshtml"
  
    ViewData["Title"] = "ProjectReport";



#line default
#line hidden
            BeginContext(104, 437, true);
            WriteLiteral(@"
<h1>ProjectReport</h1>

<div>
    <h4>ProjectReportVM</h4>
    <hr />
    <dl class=""row""></dl>
</div>
<table>
    <thead>
        <tr>
            <th>Project</th>
            <th># of People</th>

            <th>

                People on project

            </th>
            <th>Roles</th>
            <th>Hourly Rate</th>
            <th>Total Hourly</th>

        </tr>
    </thead>
    <tbody>



");
            EndContext();
#line 37 "C:\Users\Joshua\Dropbox\ETSU\Fall-2019\Adv-web\Proman - Copy\Proman\Views\Projects\ProjectReport.cshtml"
         foreach (var eachProject in Model.ListOfProjectsAndPeople)
        {

#line default
#line hidden
            BeginContext(621, 75, true);
            WriteLiteral("            <tr>\r\n                <td class=\"border\">\r\n                    ");
            EndContext();
            BeginContext(697, 50, false);
#line 41 "C:\Users\Joshua\Dropbox\ETSU\Fall-2019\Adv-web\Proman - Copy\Proman\Views\Projects\ProjectReport.cshtml"
               Write(Html.DisplayFor(modelItem => eachProject.Key.Name));

#line default
#line hidden
            EndContext();
            BeginContext(747, 82, true);
            WriteLiteral("\r\n                </td>\r\n                <td class=\"border\">\r\n                    ");
            EndContext();
            BeginContext(830, 53, false);
#line 44 "C:\Users\Joshua\Dropbox\ETSU\Fall-2019\Adv-web\Proman - Copy\Proman\Views\Projects\ProjectReport.cshtml"
               Write(Html.DisplayFor(modelItem => eachProject.Value.Count));

#line default
#line hidden
            EndContext();
            BeginContext(883, 64, true);
            WriteLiteral("\r\n                </td>\r\n                <td class=\"border\">\r\n\r\n");
            EndContext();
#line 48 "C:\Users\Joshua\Dropbox\ETSU\Fall-2019\Adv-web\Proman - Copy\Proman\Views\Projects\ProjectReport.cshtml"
                     foreach (var eachPerson in eachProject.Value)
                    {

#line default
#line hidden
            BeginContext(1038, 60, true);
            WriteLiteral("                        <span>\r\n                            ");
            EndContext();
            BeginContext(1099, 44, false);
#line 51 "C:\Users\Joshua\Dropbox\ETSU\Fall-2019\Adv-web\Proman - Copy\Proman\Views\Projects\ProjectReport.cshtml"
                       Write(Html.DisplayFor(modelItem => eachPerson.Key));

#line default
#line hidden
            EndContext();
            BeginContext(1143, 41, true);
            WriteLiteral("\r\n                        </span><br />\r\n");
            EndContext();
#line 53 "C:\Users\Joshua\Dropbox\ETSU\Fall-2019\Adv-web\Proman - Copy\Proman\Views\Projects\ProjectReport.cshtml"
                    }

#line default
#line hidden
            BeginContext(1207, 62, true);
            WriteLiteral("                </td>\r\n                <td class=\"border\">\r\n\r\n");
            EndContext();
#line 57 "C:\Users\Joshua\Dropbox\ETSU\Fall-2019\Adv-web\Proman - Copy\Proman\Views\Projects\ProjectReport.cshtml"
                     foreach (var eachPerson in eachProject.Value)
                    {

#line default
#line hidden
            BeginContext(1360, 34, true);
            WriteLiteral("                        <span>\r\n\r\n");
            EndContext();
#line 61 "C:\Users\Joshua\Dropbox\ETSU\Fall-2019\Adv-web\Proman - Copy\Proman\Views\Projects\ProjectReport.cshtml"
                             foreach (var eachRole in eachPerson.Value)
                            {

#line default
#line hidden
            BeginContext(1498, 38, true);
            WriteLiteral("                                <span>");
            EndContext();
            BeginContext(1537, 47, false);
#line 63 "C:\Users\Joshua\Dropbox\ETSU\Fall-2019\Adv-web\Proman - Copy\Proman\Views\Projects\ProjectReport.cshtml"
                                 Write(Html.DisplayFor(modelItem => eachRole.Key.Name));

#line default
#line hidden
            EndContext();
            BeginContext(1584, 11, true);
            WriteLiteral(", </span>\r\n");
            EndContext();
#line 64 "C:\Users\Joshua\Dropbox\ETSU\Fall-2019\Adv-web\Proman - Copy\Proman\Views\Projects\ProjectReport.cshtml"

                            }

#line default
#line hidden
            BeginContext(1628, 39, true);
            WriteLiteral("                        </span><br />\r\n");
            EndContext();
#line 67 "C:\Users\Joshua\Dropbox\ETSU\Fall-2019\Adv-web\Proman - Copy\Proman\Views\Projects\ProjectReport.cshtml"
                    }

#line default
#line hidden
            BeginContext(1690, 62, true);
            WriteLiteral("                </td>\r\n                <td class=\"border\">\r\n\r\n");
            EndContext();
#line 71 "C:\Users\Joshua\Dropbox\ETSU\Fall-2019\Adv-web\Proman - Copy\Proman\Views\Projects\ProjectReport.cshtml"
                     foreach (var eachPerson in eachProject.Value)
                    {

#line default
#line hidden
            BeginContext(1843, 34, true);
            WriteLiteral("                        <span>\r\n\r\n");
            EndContext();
#line 75 "C:\Users\Joshua\Dropbox\ETSU\Fall-2019\Adv-web\Proman - Copy\Proman\Views\Projects\ProjectReport.cshtml"
                             foreach (var eachRole in eachPerson.Value)
                            {

#line default
#line hidden
            BeginContext(1981, 39, true);
            WriteLiteral("                                <span>$");
            EndContext();
            BeginContext(2021, 44, false);
#line 77 "C:\Users\Joshua\Dropbox\ETSU\Fall-2019\Adv-web\Proman - Copy\Proman\Views\Projects\ProjectReport.cshtml"
                                  Write(Html.DisplayFor(modelItem => eachRole.Value));

#line default
#line hidden
            EndContext();
            BeginContext(2065, 11, true);
            WriteLiteral(", </span>\r\n");
            EndContext();
#line 78 "C:\Users\Joshua\Dropbox\ETSU\Fall-2019\Adv-web\Proman - Copy\Proman\Views\Projects\ProjectReport.cshtml"

                            }

#line default
#line hidden
            BeginContext(2109, 39, true);
            WriteLiteral("                        </span><br />\r\n");
            EndContext();
#line 81 "C:\Users\Joshua\Dropbox\ETSU\Fall-2019\Adv-web\Proman - Copy\Proman\Views\Projects\ProjectReport.cshtml"
                    }

#line default
#line hidden
            BeginContext(2171, 60, true);
            WriteLiteral("                </td>\r\n                <td class=\"border\">\r\n");
            EndContext();
#line 84 "C:\Users\Joshua\Dropbox\ETSU\Fall-2019\Adv-web\Proman - Copy\Proman\Views\Projects\ProjectReport.cshtml"
                      
                        decimal total = 0;

                    

#line default
#line hidden
            BeginContext(2324, 20, true);
            WriteLiteral("                    ");
            EndContext();
#line 88 "C:\Users\Joshua\Dropbox\ETSU\Fall-2019\Adv-web\Proman - Copy\Proman\Views\Projects\ProjectReport.cshtml"
                     foreach (var eachPerson in eachProject.Value)
                    {


#line default
#line hidden
            BeginContext(2417, 38, true);
            WriteLiteral("                        <span>\r\n\r\n\r\n\r\n");
            EndContext();
#line 96 "C:\Users\Joshua\Dropbox\ETSU\Fall-2019\Adv-web\Proman - Copy\Proman\Views\Projects\ProjectReport.cshtml"
                                                                      
                                total = total + eachPerson.Value.Values.Sum();



                            

#line default
#line hidden
            BeginContext(2676, 39, true);
            WriteLiteral("                        </span><br />\r\n");
            EndContext();
#line 103 "C:\Users\Joshua\Dropbox\ETSU\Fall-2019\Adv-web\Proman - Copy\Proman\Views\Projects\ProjectReport.cshtml"
                    }

#line default
#line hidden
            BeginContext(2738, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(2812, 21, true);
            WriteLiteral("                    $");
            EndContext();
            BeginContext(2835, 5, false);
#line 106 "C:\Users\Joshua\Dropbox\ETSU\Fall-2019\Adv-web\Proman - Copy\Proman\Views\Projects\ProjectReport.cshtml"
                 Write(total);

#line default
#line hidden
            EndContext();
            BeginContext(2841, 46, true);
            WriteLiteral("\r\n                </td>\r\n\r\n            </tr>\r\n");
            EndContext();
#line 110 "C:\Users\Joshua\Dropbox\ETSU\Fall-2019\Adv-web\Proman - Copy\Proman\Views\Projects\ProjectReport.cshtml"
        }

#line default
#line hidden
            BeginContext(2898, 30, true);
            WriteLiteral("\r\n\r\n\r\n    </tbody>\r\n</table>\r\n");
            EndContext();
            BeginContext(2928, 89, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b0cef01cd48bb4c4cdbf108672cb0999b5c19d7813581", async() => {
                BeginContext(2996, 17, true);
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
            BeginContext(3017, 2, true);
            WriteLiteral("\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Proman.Models.ViewModels.ProjectReportVM> Html { get; private set; }
    }
}
#pragma warning restore 1591
