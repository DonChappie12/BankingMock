#pragma checksum "/Users/davidgonzalez/Documents/personal_code/banking/Views/Admin/ViewUserDetails.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "fa10c065374f9703eaba39bc102a365c17844cfb"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Admin_ViewUserDetails), @"mvc.1.0.view", @"/Views/Admin/ViewUserDetails.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Admin/ViewUserDetails.cshtml", typeof(AspNetCore.Views_Admin_ViewUserDetails))]
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
#line 1 "/Users/davidgonzalez/Documents/personal_code/banking/Views/_ViewImports.cshtml"
using banking;

#line default
#line hidden
#line 2 "/Users/davidgonzalez/Documents/personal_code/banking/Views/_ViewImports.cshtml"
using banking.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fa10c065374f9703eaba39bc102a365c17844cfb", @"/Views/Admin/ViewUserDetails.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4ea249d6fa83cc55e0867aed66f7610552559928", @"/Views/_ViewImports.cshtml")]
    public class Views_Admin_ViewUserDetails : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<User>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-light"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Admin", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "EditUser", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            BeginContext(12, 46, true);
            WriteLiteral("\n<div>\n    <h3>User Details here</h3>\n    <h3>");
            EndContext();
            BeginContext(59, 8, false);
#line 5 "/Users/davidgonzalez/Documents/personal_code/banking/Views/Admin/ViewUserDetails.cshtml"
   Write(Model.Id);

#line default
#line hidden
            EndContext();
            BeginContext(67, 6, true);
            WriteLiteral("</h3>\n");
            EndContext();
#line 6 "/Users/davidgonzalez/Documents/personal_code/banking/Views/Admin/ViewUserDetails.cshtml"
     if(@Model.FirstName == null)
    {

#line default
#line hidden
            BeginContext(113, 35, true);
            WriteLiteral("        <h3>Sorry no name yet</h3>\n");
            EndContext();
#line 9 "/Users/davidgonzalez/Documents/personal_code/banking/Views/Admin/ViewUserDetails.cshtml"
    }
    else{

#line default
#line hidden
            BeginContext(164, 12, true);
            WriteLiteral("        <h6>");
            EndContext();
            BeginContext(177, 15, false);
#line 11 "/Users/davidgonzalez/Documents/personal_code/banking/Views/Admin/ViewUserDetails.cshtml"
       Write(Model.FirstName);

#line default
#line hidden
            EndContext();
            BeginContext(192, 6, true);
            WriteLiteral("</h6>\n");
            EndContext();
#line 12 "/Users/davidgonzalez/Documents/personal_code/banking/Views/Admin/ViewUserDetails.cshtml"
    }

#line default
#line hidden
            BeginContext(204, 4, true);
            WriteLiteral("    ");
            EndContext();
            BeginContext(208, 116, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6a724db3ac8b41848d286d9b10db71c9", async() => {
                BeginContext(303, 17, true);
                WriteLiteral("Edit User Details");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 13 "/Users/davidgonzalez/Documents/personal_code/banking/Views/Admin/ViewUserDetails.cshtml"
                                                                            WriteLiteral(Model.Id);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(324, 1, true);
            WriteLiteral("\n");
            EndContext();
#line 14 "/Users/davidgonzalez/Documents/personal_code/banking/Views/Admin/ViewUserDetails.cshtml"
     if(@ViewBag.accounts == null)
    {

#line default
#line hidden
            BeginContext(366, 39, true);
            WriteLiteral("        <h2>Sorry no accounts yet</h2>\n");
            EndContext();
#line 17 "/Users/davidgonzalez/Documents/personal_code/banking/Views/Admin/ViewUserDetails.cshtml"
    }
    else{
        

#line default
#line hidden
#line 19 "/Users/davidgonzalez/Documents/personal_code/banking/Views/Admin/ViewUserDetails.cshtml"
         foreach(var act in @ViewBag.accounts){

#line default
#line hidden
            BeginContext(469, 16, true);
            WriteLiteral("            <h3>");
            EndContext();
            BeginContext(486, 17, false);
#line 20 "/Users/davidgonzalez/Documents/personal_code/banking/Views/Admin/ViewUserDetails.cshtml"
           Write(act.TypeOfAccount);

#line default
#line hidden
            EndContext();
            BeginContext(503, 23, true);
            WriteLiteral("</h3>\n            <h4>$");
            EndContext();
            BeginContext(527, 10, false);
#line 21 "/Users/davidgonzalez/Documents/personal_code/banking/Views/Admin/ViewUserDetails.cshtml"
            Write(act.Amount);

#line default
#line hidden
            EndContext();
            BeginContext(537, 6, true);
            WriteLiteral("</h4>\n");
            EndContext();
#line 22 "/Users/davidgonzalez/Documents/personal_code/banking/Views/Admin/ViewUserDetails.cshtml"
        }

#line default
#line hidden
#line 22 "/Users/davidgonzalez/Documents/personal_code/banking/Views/Admin/ViewUserDetails.cshtml"
         
    }

#line default
#line hidden
            BeginContext(559, 6, true);
            WriteLiteral("</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<User> Html { get; private set; }
    }
}
#pragma warning restore 1591
