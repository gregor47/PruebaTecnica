#pragma checksum "C:\Users\Gregory\source\repos\PruebaTecnicaa\PruebaTecnicaa\Views\Admin\Auditoria.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "381ebc0056093bb2d00c03b9e6f3706f2968a84d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Admin_Auditoria), @"mvc.1.0.view", @"/Views/Admin/Auditoria.cshtml")]
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
#line 1 "C:\Users\Gregory\source\repos\PruebaTecnicaa\PruebaTecnicaa\Views\_ViewImports.cshtml"
using PruebaTecnicaa;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Gregory\source\repos\PruebaTecnicaa\PruebaTecnicaa\Views\_ViewImports.cshtml"
using PruebaTecnicaa.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"381ebc0056093bb2d00c03b9e6f3706f2968a84d", @"/Views/Admin/Auditoria.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"38a1f8148b2fab146512e6bc459267fb96a4fc06", @"/Views/_ViewImports.cshtml")]
    public class Views_Admin_Auditoria : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<PruebaTecnicaa.Models.PruebaTecnica.Auditoria>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"
<div class=""row mt-5"">
    <div class=""col-md text-center"">
        <h1>Auditoria</h1>
    </div>
</div>
<hr />
<div class=""row mt-3"">
    <div class=""col-md"">
        <table class=""table table-striped table-bordered table-hover"" id=""tableRadicados"">
            <thead>
                <tr>
                    <th class=""text-center"">#</th>
                    <th class=""text-center"">Accion</th>
                    <th class=""text-center"">Usuario Id</th>
                    <th class=""text-center"">Fecha</th>
                </tr>
            </thead>
            <tbody>
");
#nullable restore
#line 26 "C:\Users\Gregory\source\repos\PruebaTecnicaa\PruebaTecnicaa\Views\Admin\Auditoria.cshtml"
                 foreach (var item in Model)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <tr>\r\n                        <td class=\"text-center\">\r\n                            ");
#nullable restore
#line 30 "C:\Users\Gregory\source\repos\PruebaTecnicaa\PruebaTecnicaa\Views\Admin\Auditoria.cshtml"
                       Write(item.AuditoriaId);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                        <td class=\"text-center\">\r\n                            ");
#nullable restore
#line 33 "C:\Users\Gregory\source\repos\PruebaTecnicaa\PruebaTecnicaa\Views\Admin\Auditoria.cshtml"
                       Write(item.Accion);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                        <td class=\"text-center\">\r\n                            ");
#nullable restore
#line 36 "C:\Users\Gregory\source\repos\PruebaTecnicaa\PruebaTecnicaa\Views\Admin\Auditoria.cshtml"
                       Write(item.UsuarioNombre);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                        <td class=\"text-center\" data-order=\"");
#nullable restore
#line 38 "C:\Users\Gregory\source\repos\PruebaTecnicaa\PruebaTecnicaa\Views\Admin\Auditoria.cshtml"
                                                       Write(Convert.ToDateTime(item.Fecha).Ticks);

#line default
#line hidden
#nullable disable
            WriteLiteral("\">\r\n                            ");
#nullable restore
#line 39 "C:\Users\Gregory\source\repos\PruebaTecnicaa\PruebaTecnicaa\Views\Admin\Auditoria.cshtml"
                       Write(item.Fecha);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                    </tr>\r\n");
#nullable restore
#line 42 "C:\Users\Gregory\source\repos\PruebaTecnicaa\PruebaTecnicaa\Views\Admin\Auditoria.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </tbody>\r\n        </table>\r\n    </div>\r\n</div>\r\n\r\n<script>\r\n    $(document).ready(function () {\r\n        $(\'#tableRadicados\').DataTable({\r\n            //\"scrollX\": true\r\n        });\r\n    });\r\n</script>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<PruebaTecnicaa.Models.PruebaTecnica.Auditoria>> Html { get; private set; }
    }
}
#pragma warning restore 1591
