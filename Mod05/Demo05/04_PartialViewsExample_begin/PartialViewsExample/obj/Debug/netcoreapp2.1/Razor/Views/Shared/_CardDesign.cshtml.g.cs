#pragma checksum "D:\20_610\20486\20486D_Tareas\Mod05\Demo05\04_PartialViewsExample_begin\PartialViewsExample\Views\Shared\_CardDesign.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "93531c1f1fea5bf53a1e8f30f2f7f6e0954efbf3"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__CardDesign), @"mvc.1.0.view", @"/Views/Shared/_CardDesign.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shared/_CardDesign.cshtml", typeof(AspNetCore.Views_Shared__CardDesign))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"93531c1f1fea5bf53a1e8f30f2f7f6e0954efbf3", @"/Views/Shared/_CardDesign.cshtml")]
    public class Views_Shared__CardDesign : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<int>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(14, 27, true);
            WriteLiteral("<td>\r\n    <div>First Name: ");
            EndContext();
            BeginContext(42, 31, false);
#line 4 "D:\20_610\20486\20486D_Tareas\Mod05\Demo05\04_PartialViewsExample_begin\PartialViewsExample\Views\Shared\_CardDesign.cshtml"
                Write(ViewBag.People[Model].FirstName);

#line default
#line hidden
            EndContext();
            BeginContext(73, 28, true);
            WriteLiteral("</div>\r\n    <div>Last Name: ");
            EndContext();
            BeginContext(102, 30, false);
#line 5 "D:\20_610\20486\20486D_Tareas\Mod05\Demo05\04_PartialViewsExample_begin\PartialViewsExample\Views\Shared\_CardDesign.cshtml"
               Write(ViewBag.People[Model].LastName);

#line default
#line hidden
            EndContext();
            BeginContext(132, 28, true);
            WriteLiteral("</div>\r\n    <div>Residence: ");
            EndContext();
            BeginContext(161, 29, false);
#line 6 "D:\20_610\20486\20486D_Tareas\Mod05\Demo05\04_PartialViewsExample_begin\PartialViewsExample\Views\Shared\_CardDesign.cshtml"
               Write(ViewBag.People[Model].Address);

#line default
#line hidden
            EndContext();
            BeginContext(190, 24, true);
            WriteLiteral("</div>\r\n    <div>Phone: ");
            EndContext();
            BeginContext(215, 33, false);
#line 7 "D:\20_610\20486\20486D_Tareas\Mod05\Demo05\04_PartialViewsExample_begin\PartialViewsExample\Views\Shared\_CardDesign.cshtml"
           Write(ViewBag.People[Model].PhoneNumber);

#line default
#line hidden
            EndContext();
            BeginContext(248, 13, true);
            WriteLiteral("</div>\r\n</td>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<int> Html { get; private set; }
    }
}
#pragma warning restore 1591