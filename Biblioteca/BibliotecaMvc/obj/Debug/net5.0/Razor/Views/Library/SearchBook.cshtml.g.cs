#pragma checksum "/home/fabio/Documentos/Linguagens de Programação/C#.NET/ProjetosC#/Biblioteca/BibliotecaMvc/Views/Library/SearchBook.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "63e58b4cc83d2fb7306c61835f8acedd020c4688"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Library_SearchBook), @"mvc.1.0.view", @"/Views/Library/SearchBook.cshtml")]
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
#line 1 "/home/fabio/Documentos/Linguagens de Programação/C#.NET/ProjetosC#/Biblioteca/BibliotecaMvc/Views/_ViewImports.cshtml"
using BibliotecaMvc;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "/home/fabio/Documentos/Linguagens de Programação/C#.NET/ProjetosC#/Biblioteca/BibliotecaMvc/Views/_ViewImports.cshtml"
using BibliotecaMvc.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"63e58b4cc83d2fb7306c61835f8acedd020c4688", @"/Views/Library/SearchBook.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5d02d13a470987329d5abfeb4565ca8779b06ae8", @"/Views/_ViewImports.cshtml")]
    public class Views_Library_SearchBook : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<BibliotecaEntitiesLib.Books>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "POST", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\n");
#nullable restore
#line 3 "/home/fabio/Documentos/Linguagens de Programação/C#.NET/ProjetosC#/Biblioteca/BibliotecaMvc/Views/Library/SearchBook.cshtml"
  
    ViewData["Title"] = "Search Book";


#line default
#line hidden
#nullable disable
            WriteLiteral("\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "63e58b4cc83d2fb7306c61835f8acedd020c46884241", async() => {
                WriteLiteral("\n    <legend>Book Information</legend>\n    <label>Id: </label>\n        <input class=\"form-control\" name=\"id\" required/>\n    <input class=\"btn btn-dark\" type=\"submit\">\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n\n");
#nullable restore
#line 15 "/home/fabio/Documentos/Linguagens de Programação/C#.NET/ProjetosC#/Biblioteca/BibliotecaMvc/Views/Library/SearchBook.cshtml"
 if(Model != null){

#line default
#line hidden
#nullable disable
            WriteLiteral(@"   <table class=""table table-bordered table-stripped table-hover"">
       <thead class=""thead-dark"">
           <th>Id</th>
           <th>Title</th>
           <th>Author</th>
           <th>Genre</th>
           <th>Year</th>
       </thead>
       <tbody>
           <tr>
               <td>");
#nullable restore
#line 26 "/home/fabio/Documentos/Linguagens de Programação/C#.NET/ProjetosC#/Biblioteca/BibliotecaMvc/Views/Library/SearchBook.cshtml"
              Write(Model.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n               <td>");
#nullable restore
#line 27 "/home/fabio/Documentos/Linguagens de Programação/C#.NET/ProjetosC#/Biblioteca/BibliotecaMvc/Views/Library/SearchBook.cshtml"
              Write(Model.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n               <td>");
#nullable restore
#line 28 "/home/fabio/Documentos/Linguagens de Programação/C#.NET/ProjetosC#/Biblioteca/BibliotecaMvc/Views/Library/SearchBook.cshtml"
              Write(Model.Author);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n               <td>");
#nullable restore
#line 29 "/home/fabio/Documentos/Linguagens de Programação/C#.NET/ProjetosC#/Biblioteca/BibliotecaMvc/Views/Library/SearchBook.cshtml"
              Write(Model.Genre);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n               <td>");
#nullable restore
#line 30 "/home/fabio/Documentos/Linguagens de Programação/C#.NET/ProjetosC#/Biblioteca/BibliotecaMvc/Views/Library/SearchBook.cshtml"
              Write(Model.Year);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n           </tr>\n       </tbody>\n   </table>\n");
#nullable restore
#line 34 "/home/fabio/Documentos/Linguagens de Programação/C#.NET/ProjetosC#/Biblioteca/BibliotecaMvc/Views/Library/SearchBook.cshtml"

}

#line default
#line hidden
#nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<BibliotecaEntitiesLib.Books> Html { get; private set; }
    }
}
#pragma warning restore 1591
