#pragma checksum "D:\20_610\20486\20486D_Tareas\Mod05\Labs05\01_CitiesWebsite_begin\CitiesWebsite\Views\Shared\Components\City\SelectCity.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5196fb6a7d760a7d01b817e0b853c1d518e5d074"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_City_SelectCity), @"mvc.1.0.view", @"/Views/Shared/Components/City/SelectCity.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shared/Components/City/SelectCity.cshtml", typeof(AspNetCore.Views_Shared_Components_City_SelectCity))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5196fb6a7d760a7d01b817e0b853c1d518e5d074", @"/Views/Shared/Components/City/SelectCity.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"82d9d1780bd75e3d56263f282ee216e17d571cbf", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Components_City_SelectCity : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "ShowDataForCity", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            BeginContext(0, 29, true);
            WriteLiteral("<div>\n    <h2>enlace\n        ");
            EndContext();
            BeginContext(29, 148, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4d16159d637745ef9d57d85e10058baf", async() => {
                BeginContext(107, 24, false);
#line 3 "D:\20_610\20486\20486D_Tareas\Mod05\Labs05\01_CitiesWebsite_begin\CitiesWebsite\Views\Shared\Components\City\SelectCity.cshtml"
                                                                                Write(ViewBag.CurrentCity.Name);

#line default
#line hidden
                EndContext();
                BeginContext(131, 13, true);
                WriteLiteral(" (Capital of ");
                EndContext();
                BeginContext(145, 27, false);
#line 3 "D:\20_610\20486\20486D_Tareas\Mod05\Labs05\01_CitiesWebsite_begin\CitiesWebsite\Views\Shared\Components\City\SelectCity.cshtml"
                                                                                                                      Write(ViewBag.CurrentCity.Country);

#line default
#line hidden
                EndContext();
                BeginContext(172, 1, true);
                WriteLiteral(")");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-cityname", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 3 "D:\20_610\20486\20486D_Tareas\Mod05\Labs05\01_CitiesWebsite_begin\CitiesWebsite\Views\Shared\Components\City\SelectCity.cshtml"
                                               WriteLiteral(ViewBag.CurrentCity.Name);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["cityname"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-cityname", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["cityname"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(177, 19, true);
            WriteLiteral("\n    </h2>\n    <img");
            EndContext();
            BeginWriteAttribute("src", " src=\"", 196, "\"", 270, 1);
#line 5 "D:\20_610\20486\20486D_Tareas\Mod05\Labs05\01_CitiesWebsite_begin\CitiesWebsite\Views\Shared\Components\City\SelectCity.cshtml"
WriteAttributeValue("", 202, Url.Action("GetImage", new { cityName = ViewBag.CurrentCity.Name }), 202, 68, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(271, 11, true);
            WriteLiteral(" />\n</div>\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
