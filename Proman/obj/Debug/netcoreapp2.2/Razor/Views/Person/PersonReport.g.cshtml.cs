#pragma checksum "C:\Users\Joshua\Dropbox\ETSU\Fall-2019\Adv-web\Proman - Copy\Proman\Views\Person\PersonReport.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "641748d06304ab2156fc982c058036be66625291"
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
#line 1 "C:\Users\Joshua\Dropbox\ETSU\Fall-2019\Adv-web\Proman - Copy\Proman\Views\_ViewImports.cshtml"
using Proman;

#line default
#line hidden
#line 2 "C:\Users\Joshua\Dropbox\ETSU\Fall-2019\Adv-web\Proman - Copy\Proman\Views\_ViewImports.cshtml"
using Proman.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"641748d06304ab2156fc982c058036be66625291", @"/Views/Person/PersonReport.cshtml")]
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
            BeginContext(48, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\Joshua\Dropbox\ETSU\Fall-2019\Adv-web\Proman - Copy\Proman\Views\Person\PersonReport.cshtml"
  
    ViewData["Title"] = "PersonReport";

#line default
#line hidden
            BeginContext(98, 435, true);
            WriteLiteral(@"
<h1>PersonReport</h1>

<div>
    <h4>PersonReportVM</h4>
    <hr />
    <dl class=""row""></dl>
</div>
<table>
    <thead>
        <tr>
            <th>People</th>
            <th># of Projects</th>

            <th>

                Project assigned

            </th>
            <th>Roles</th>
            <th>Hourly Rate</th>
            <th>Total Hourly</th>

        </tr>
    </thead>
    <tbody>



");
            EndContext();
#line 35 "C:\Users\Joshua\Dropbox\ETSU\Fall-2019\Adv-web\Proman - Copy\Proman\Views\Person\PersonReport.cshtml"
         foreach (var eachPerson in Model.ListOfProjectsAndPeople)
        {

#line default
#line hidden
            BeginContext(612, 75, true);
            WriteLiteral("            <tr>\r\n                <td class=\"border\">\r\n                    ");
            EndContext();
            BeginContext(688, 44, false);
#line 39 "C:\Users\Joshua\Dropbox\ETSU\Fall-2019\Adv-web\Proman - Copy\Proman\Views\Person\PersonReport.cshtml"
               Write(Html.DisplayFor(modelItem => eachPerson.Key));

#line default
#line hidden
            EndContext();
            BeginContext(732, 82, true);
            WriteLiteral("\r\n                </td>\r\n                <td class=\"border\">\r\n                    ");
            EndContext();
            BeginContext(815, 52, false);
#line 42 "C:\Users\Joshua\Dropbox\ETSU\Fall-2019\Adv-web\Proman - Copy\Proman\Views\Person\PersonReport.cshtml"
               Write(Html.DisplayFor(modelItem => eachPerson.Value.Count));

#line default
#line hidden
            EndContext();
            BeginContext(867, 62, true);
            WriteLiteral("\r\n                </td>\r\n                <td class=\"border\">\r\n");
            EndContext();
#line 46 "C:\Users\Joshua\Dropbox\ETSU\Fall-2019\Adv-web\Proman - Copy\Proman\Views\Person\PersonReport.cshtml"
                     foreach (var eachProject in eachPerson.Value)
                    {

#line default
#line hidden
            BeginContext(1088, 60, true);
            WriteLiteral("                        <span>\r\n                            ");
            EndContext();
            BeginContext(1149, 50, false);
#line 49 "C:\Users\Joshua\Dropbox\ETSU\Fall-2019\Adv-web\Proman - Copy\Proman\Views\Person\PersonReport.cshtml"
                       Write(Html.DisplayFor(modelItem => eachProject.Key.Name));

#line default
#line hidden
            EndContext();
            BeginContext(1199, 41, true);
            WriteLiteral("\r\n                        </span><br />\r\n");
            EndContext();
#line 51 "C:\Users\Joshua\Dropbox\ETSU\Fall-2019\Adv-web\Proman - Copy\Proman\Views\Person\PersonReport.cshtml"
                    }

#line default
#line hidden
            BeginContext(1263, 62, true);
            WriteLiteral("                </td>\r\n                <td class=\"border\">\r\n\r\n");
            EndContext();
#line 55 "C:\Users\Joshua\Dropbox\ETSU\Fall-2019\Adv-web\Proman - Copy\Proman\Views\Person\PersonReport.cshtml"
                     foreach (var each in eachPerson.Value)
                    {

#line default
#line hidden
            BeginContext(1409, 36, true);
            WriteLiteral("                        <span>\r\n\r\n\r\n");
            EndContext();
#line 60 "C:\Users\Joshua\Dropbox\ETSU\Fall-2019\Adv-web\Proman - Copy\Proman\Views\Person\PersonReport.cshtml"
                             foreach (var eachRole in each.Value)
                            {

#line default
#line hidden
            BeginContext(1543, 38, true);
            WriteLiteral("                                <span>");
            EndContext();
            BeginContext(1582, 47, false);
#line 62 "C:\Users\Joshua\Dropbox\ETSU\Fall-2019\Adv-web\Proman - Copy\Proman\Views\Person\PersonReport.cshtml"
                                 Write(Html.DisplayFor(modelItem => eachRole.Key.Name));

#line default
#line hidden
            EndContext();
            BeginContext(1629, 11, true);
            WriteLiteral(", </span>\r\n");
            EndContext();
#line 63 "C:\Users\Joshua\Dropbox\ETSU\Fall-2019\Adv-web\Proman - Copy\Proman\Views\Person\PersonReport.cshtml"

                            }

#line default
#line hidden
            BeginContext(1673, 39, true);
            WriteLiteral("                        </span><br />\r\n");
            EndContext();
#line 66 "C:\Users\Joshua\Dropbox\ETSU\Fall-2019\Adv-web\Proman - Copy\Proman\Views\Person\PersonReport.cshtml"
                    }

#line default
#line hidden
            BeginContext(1735, 62, true);
            WriteLiteral("                </td>\r\n                <td class=\"border\">\r\n\r\n");
            EndContext();
#line 70 "C:\Users\Joshua\Dropbox\ETSU\Fall-2019\Adv-web\Proman - Copy\Proman\Views\Person\PersonReport.cshtml"
                     foreach (var each in eachPerson.Value)
                    {

#line default
#line hidden
            BeginContext(1881, 34, true);
            WriteLiteral("                        <span>\r\n\r\n");
            EndContext();
#line 74 "C:\Users\Joshua\Dropbox\ETSU\Fall-2019\Adv-web\Proman - Copy\Proman\Views\Person\PersonReport.cshtml"
                             foreach (var eachRole in each.Value)
                            {

#line default
#line hidden
            BeginContext(2013, 39, true);
            WriteLiteral("                                <span>$");
            EndContext();
            BeginContext(2053, 44, false);
#line 76 "C:\Users\Joshua\Dropbox\ETSU\Fall-2019\Adv-web\Proman - Copy\Proman\Views\Person\PersonReport.cshtml"
                                  Write(Html.DisplayFor(modelItem => eachRole.Value));

#line default
#line hidden
            EndContext();
            BeginContext(2097, 11, true);
            WriteLiteral(", </span>\r\n");
            EndContext();
#line 77 "C:\Users\Joshua\Dropbox\ETSU\Fall-2019\Adv-web\Proman - Copy\Proman\Views\Person\PersonReport.cshtml"

                            }

#line default
#line hidden
            BeginContext(2141, 39, true);
            WriteLiteral("                        </span><br />\r\n");
            EndContext();
#line 80 "C:\Users\Joshua\Dropbox\ETSU\Fall-2019\Adv-web\Proman - Copy\Proman\Views\Person\PersonReport.cshtml"
                    }

#line default
#line hidden
            BeginContext(2203, 60, true);
            WriteLiteral("                </td>\r\n                <td class=\"border\">\r\n");
            EndContext();
#line 83 "C:\Users\Joshua\Dropbox\ETSU\Fall-2019\Adv-web\Proman - Copy\Proman\Views\Person\PersonReport.cshtml"
                      
                        decimal total = 0;

                    

#line default
#line hidden
            BeginContext(2356, 20, true);
            WriteLiteral("                    ");
            EndContext();
#line 87 "C:\Users\Joshua\Dropbox\ETSU\Fall-2019\Adv-web\Proman - Copy\Proman\Views\Person\PersonReport.cshtml"
                     foreach (var each in eachPerson.Value)
                    {


#line default
#line hidden
            BeginContext(2442, 38, true);
            WriteLiteral("                        <span>\r\n\r\n\r\n\r\n");
            EndContext();
#line 95 "C:\Users\Joshua\Dropbox\ETSU\Fall-2019\Adv-web\Proman - Copy\Proman\Views\Person\PersonReport.cshtml"
                                                                      
                                total = total + each.Value.Values.Sum();



                            

#line default
#line hidden
            BeginContext(2695, 39, true);
            WriteLiteral("                        </span><br />\r\n");
            EndContext();
#line 102 "C:\Users\Joshua\Dropbox\ETSU\Fall-2019\Adv-web\Proman - Copy\Proman\Views\Person\PersonReport.cshtml"
                    }

#line default
#line hidden
            BeginContext(2757, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(2831, 21, true);
            WriteLiteral("                    $");
            EndContext();
            BeginContext(2854, 5, false);
#line 105 "C:\Users\Joshua\Dropbox\ETSU\Fall-2019\Adv-web\Proman - Copy\Proman\Views\Person\PersonReport.cshtml"
                 Write(total);

#line default
#line hidden
            EndContext();
            BeginContext(2860, 46, true);
            WriteLiteral("\r\n                </td>\r\n\r\n            </tr>\r\n");
            EndContext();
#line 109 "C:\Users\Joshua\Dropbox\ETSU\Fall-2019\Adv-web\Proman - Copy\Proman\Views\Person\PersonReport.cshtml"
        }

#line default
#line hidden
            BeginContext(2917, 30, true);
            WriteLiteral("\r\n\r\n\r\n    </tbody>\r\n</table>\r\n");
            EndContext();
            BeginContext(2947, 89, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "641748d06304ab2156fc982c058036be6662529113441", async() => {
                BeginContext(3015, 17, true);
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
            BeginContext(3036, 2, true);
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Proman.Models.ViewModels.PersonReportVM> Html { get; private set; }
    }
}
#pragma warning restore 1591