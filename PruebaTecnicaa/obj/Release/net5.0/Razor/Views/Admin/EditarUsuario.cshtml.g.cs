#pragma checksum "C:\Users\Gregory\source\repos\PruebaTecnicaa\PruebaTecnicaa\Views\Admin\EditarUsuario.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0c2cfe58ad1b283ce35f05b15aa79da57087365c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Admin_EditarUsuario), @"mvc.1.0.view", @"/Views/Admin/EditarUsuario.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0c2cfe58ad1b283ce35f05b15aa79da57087365c", @"/Views/Admin/EditarUsuario.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"38a1f8148b2fab146512e6bc459267fb96a4fc06", @"/Views/_ViewImports.cshtml")]
    public class Views_Admin_EditarUsuario : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<PruebaTecnicaa.Models.PruebaTecnica.Usuario>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<div class=\"row mt-5\">\r\n    <div class=\"col-md text-center\">\r\n        <h1>Crear Usuario</h1>\r\n    </div>\r\n</div>\r\n<hr />\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0c2cfe58ad1b283ce35f05b15aa79da57087365c3879", async() => {
                WriteLiteral("\r\n    <input type=\"hidden\" id=\"id\" name=\"id\"");
                BeginWriteAttribute("value", " value=\"", 544, "\"", 568, 1);
#nullable restore
#line 19 "C:\Users\Gregory\source\repos\PruebaTecnicaa\PruebaTecnicaa\Views\Admin\EditarUsuario.cshtml"
WriteAttributeValue("", 552, Model.UsuarioId, 552, 16, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" />\r\n    <div class=\"row mt-3\">\r\n        <div class=\"col-md\">\r\n            <label for=\"Nombre\">Nombre</label>\r\n            <input class=\"form-control\" type=\"text\" placeholder=\"Nombre\" id=\"Nombre\" name=\"Nombre\"");
                BeginWriteAttribute("value", " value=\"", 778, "\"", 799, 1);
#nullable restore
#line 23 "C:\Users\Gregory\source\repos\PruebaTecnicaa\PruebaTecnicaa\Views\Admin\EditarUsuario.cshtml"
WriteAttributeValue("", 786, Model.Nombre, 786, 13, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(@" autocomplete=""off"" required />
        </div>
        <div class=""col-md"">
            <label for=""Documento"">Documento</label>
            <input class=""form-control"" type=""number"" placeholder=""Documento"" name=""Documento"" id=""Documento"" autocomplete=""off""");
                BeginWriteAttribute("value", " value=\"", 1061, "\"", 1085, 1);
#nullable restore
#line 27 "C:\Users\Gregory\source\repos\PruebaTecnicaa\PruebaTecnicaa\Views\Admin\EditarUsuario.cshtml"
WriteAttributeValue("", 1069, Model.Documento, 1069, 16, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(@" onkeypress=""soloNumeros(this)"" required />
        </div>
    </div>
    <div class=""row mt-3"">
        <div class=""col-md"">
            <label for=""Email"">Email</label>
            <input  class=""form-control"" type=""email"" placeholder=""Email"" name=""Email"" id=""Email""");
                BeginWriteAttribute("value", " value=\"", 1360, "\"", 1380, 1);
#nullable restore
#line 33 "C:\Users\Gregory\source\repos\PruebaTecnicaa\PruebaTecnicaa\Views\Admin\EditarUsuario.cshtml"
WriteAttributeValue("", 1368, Model.Email, 1368, 12, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" autocomplete=\"off\" required />\r\n        </div>\r\n        <div class=\"col-md\">\r\n            <label for=\"Rol\">Rol</label>\r\n            <select class=\"form-control\" name=\"Rol\" id=\"Rol\" required>\r\n                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0c2cfe58ad1b283ce35f05b15aa79da57087365c6783", async() => {
                    WriteLiteral("Seleccione");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n");
#nullable restore
#line 39 "C:\Users\Gregory\source\repos\PruebaTecnicaa\PruebaTecnicaa\Views\Admin\EditarUsuario.cshtml"
                 foreach (var item in ViewBag.Perfiles)
                {
                    if (Model.PerfilId == item.PerfilId)
                    {

#line default
#line hidden
#nullable disable
                WriteLiteral("                        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0c2cfe58ad1b283ce35f05b15aa79da57087365c8191", async() => {
#nullable restore
#line 43 "C:\Users\Gregory\source\repos\PruebaTecnicaa\PruebaTecnicaa\Views\Admin\EditarUsuario.cshtml"
                                                           Write(item.Descripcion);

#line default
#line hidden
#nullable disable
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                BeginWriteTagHelperAttribute();
#nullable restore
#line 43 "C:\Users\Gregory\source\repos\PruebaTecnicaa\PruebaTecnicaa\Views\Admin\EditarUsuario.cshtml"
                           WriteLiteral(item.PerfilId);

#line default
#line hidden
#nullable disable
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("value", __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                BeginWriteTagHelperAttribute();
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __tagHelperExecutionContext.AddHtmlAttribute("selected", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.Minimized);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n");
#nullable restore
#line 44 "C:\Users\Gregory\source\repos\PruebaTecnicaa\PruebaTecnicaa\Views\Admin\EditarUsuario.cshtml"
                    }
                    else
                    {

#line default
#line hidden
#nullable disable
                WriteLiteral("                        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0c2cfe58ad1b283ce35f05b15aa79da57087365c10736", async() => {
#nullable restore
#line 47 "C:\Users\Gregory\source\repos\PruebaTecnicaa\PruebaTecnicaa\Views\Admin\EditarUsuario.cshtml"
                                                  Write(item.Descripcion);

#line default
#line hidden
#nullable disable
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                BeginWriteTagHelperAttribute();
#nullable restore
#line 47 "C:\Users\Gregory\source\repos\PruebaTecnicaa\PruebaTecnicaa\Views\Admin\EditarUsuario.cshtml"
                           WriteLiteral(item.PerfilId);

#line default
#line hidden
#nullable disable
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("value", __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n");
#nullable restore
#line 48 "C:\Users\Gregory\source\repos\PruebaTecnicaa\PruebaTecnicaa\Views\Admin\EditarUsuario.cshtml"
                    }
                }

#line default
#line hidden
#nullable disable
                WriteLiteral(@"            </select>
        </div>
    </div>
    <div class=""row mt-3"">
        <div class=""col-md-6"">
            <label for=""Pass"">Contrase??a</label>
            <input class=""form-control"" type=""password"" placeholder=""Contrase??a""  autocomplete=""off"" name=""Pass"" id=""Pass"" required />
        </div>
    </div>
    <div class=""row text-center mt-5"">
        <div class=""col-md "">
            <a class=""btn btn-danger""");
                BeginWriteAttribute("href", " href=\"", 2498, "\"", 2536, 1);
#nullable restore
#line 61 "C:\Users\Gregory\source\repos\PruebaTecnicaa\PruebaTecnicaa\Views\Admin\EditarUsuario.cshtml"
WriteAttributeValue("", 2505, Url.Action("Usuarios","Admin"), 2505, 31, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">Atras</a>\r\n        </div>\r\n        <div class=\"col-md \">\r\n            <input type=\"submit\" class=\"btn btn-success\" value=\"Guardar\" />\r\n        </div>\r\n\r\n    </div>\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "action", 1, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#nullable restore
#line 18 "C:\Users\Gregory\source\repos\PruebaTecnicaa\PruebaTecnicaa\Views\Admin\EditarUsuario.cshtml"
AddHtmlAttributeValue("", 462, Url.Action("EditarUsuario","Admin"), 462, 36, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<PruebaTecnicaa.Models.PruebaTecnica.Usuario> Html { get; private set; }
    }
}
#pragma warning restore 1591
