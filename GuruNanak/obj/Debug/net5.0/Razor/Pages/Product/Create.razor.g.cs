#pragma checksum "E:\GN_Shop\GuruNanak\GuruNanak\GuruNanak\Pages\Product\Create.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3c175c69e1129f08ce4a38438c934a0318f1e2ff"
// <auto-generated/>
#pragma warning disable 1591
namespace GuruNanak.Pages.Product
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "E:\GN_Shop\GuruNanak\GuruNanak\GuruNanak\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\GN_Shop\GuruNanak\GuruNanak\GuruNanak\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "E:\GN_Shop\GuruNanak\GuruNanak\GuruNanak\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "E:\GN_Shop\GuruNanak\GuruNanak\GuruNanak\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "E:\GN_Shop\GuruNanak\GuruNanak\GuruNanak\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "E:\GN_Shop\GuruNanak\GuruNanak\GuruNanak\_Imports.razor"
using Microsoft.AspNetCore.Components.Web.Virtualization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "E:\GN_Shop\GuruNanak\GuruNanak\GuruNanak\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "E:\GN_Shop\GuruNanak\GuruNanak\GuruNanak\_Imports.razor"
using GuruNanak;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "E:\GN_Shop\GuruNanak\GuruNanak\GuruNanak\_Imports.razor"
using GuruNanak.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\GN_Shop\GuruNanak\GuruNanak\GuruNanak\Pages\Product\Create.razor"
using GuruNanak.Database;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "E:\GN_Shop\GuruNanak\GuruNanak\GuruNanak\Pages\Product\Create.razor"
using GuruNanak.Services;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "E:\GN_Shop\GuruNanak\GuruNanak\GuruNanak\Pages\Product\Create.razor"
using System.IO;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "E:\GN_Shop\GuruNanak\GuruNanak\GuruNanak\Pages\Product\Create.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/Product/Create")]
    public partial class Create : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.AddMarkupContent(0, "<h2 class=\"esh-body-title py-2 mt-3\">Create</h2>\n\n");
            __builder.OpenElement(1, "div");
            __builder.OpenComponent<Microsoft.AspNetCore.Components.Forms.EditForm>(2);
            __builder.AddAttribute(3, "Model", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Object>(
#nullable restore
#line 12 "E:\GN_Shop\GuruNanak\GuruNanak\GuruNanak\Pages\Product\Create.razor"
                     _item

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(4, "OnValidSubmit", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<Microsoft.AspNetCore.Components.Forms.EditContext>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Forms.EditContext>(this, 
#nullable restore
#line 12 "E:\GN_Shop\GuruNanak\GuruNanak\GuruNanak\Pages\Product\Create.razor"
                                            Create_Click

#line default
#line hidden
#nullable disable
            )));
            __builder.AddAttribute(5, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment<Microsoft.AspNetCore.Components.Forms.EditContext>)((context) => (__builder2) => {
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Forms.DataAnnotationsValidator>(6);
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(7, "\n        ");
                __builder2.OpenElement(8, "div");
                __builder2.AddAttribute(9, "class", "row");
                __builder2.OpenElement(10, "div");
                __builder2.AddAttribute(11, "class", "col-md-3");
                __builder2.OpenElement(12, "div");
                __builder2.AddAttribute(13, "class", "form-group");
                __builder2.AddMarkupContent(14, "<label class=\"control-label col-md-2\">Name</label>\n           \n                ");
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Forms.InputText>(15);
                __builder2.AddAttribute(16, "class", "form-control");
                __builder2.AddAttribute(17, "Value", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 19 "E:\GN_Shop\GuruNanak\GuruNanak\GuruNanak\Pages\Product\Create.razor"
                                                             _item.Name

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(18, "ValueChanged", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.String>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.String>(this, global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => _item.Name = __value, _item.Name))));
                __builder2.AddAttribute(19, "ValueExpression", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Linq.Expressions.Expression<System.Func<System.String>>>(() => _item.Name));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(20, "\n                ");
                __Blazor.GuruNanak.Pages.Product.Create.TypeInference.CreateValidationMessage_0(__builder2, 21, 22, 
#nullable restore
#line 20 "E:\GN_Shop\GuruNanak\GuruNanak\GuruNanak\Pages\Product\Create.razor"
                                        (() => _item.Name)

#line default
#line hidden
#nullable disable
                );
                __builder2.CloseElement();
                __builder2.CloseElement();
                __builder2.AddMarkupContent(23, "\n        ");
                __builder2.OpenElement(24, "div");
                __builder2.AddAttribute(25, "class", "col-md-3");
                __builder2.OpenElement(26, "div");
                __builder2.AddAttribute(27, "class", "form-group");
                __builder2.AddMarkupContent(28, "<label class=\"control-label col-md-2\">Category</label>\n            \n                ");
                __Blazor.GuruNanak.Pages.Product.Create.TypeInference.CreateInputSelect_1(__builder2, 29, 30, "form-control", 31, 
#nullable restore
#line 27 "E:\GN_Shop\GuruNanak\GuruNanak\GuruNanak\Pages\Product\Create.razor"
                                          _item.ProductCategoryId

#line default
#line hidden
#nullable disable
                , 32, Microsoft.AspNetCore.Components.EventCallback.Factory.Create(this, global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => _item.ProductCategoryId = __value, _item.ProductCategoryId)), 33, () => _item.ProductCategoryId, 34, (__builder3) => {
#nullable restore
#line 28 "E:\GN_Shop\GuruNanak\GuruNanak\GuruNanak\Pages\Product\Create.razor"
                     foreach (var type in _types)
                    {

#line default
#line hidden
#nullable disable
                    __builder3.OpenElement(35, "option");
                    __builder3.AddAttribute(36, "value", 
#nullable restore
#line 30 "E:\GN_Shop\GuruNanak\GuruNanak\GuruNanak\Pages\Product\Create.razor"
                                        type.Id

#line default
#line hidden
#nullable disable
                    );
#nullable restore
#line 30 "E:\GN_Shop\GuruNanak\GuruNanak\GuruNanak\Pages\Product\Create.razor"
__builder3.AddContent(37, type.Type);

#line default
#line hidden
#nullable disable
                    __builder3.CloseElement();
#nullable restore
#line 31 "E:\GN_Shop\GuruNanak\GuruNanak\GuruNanak\Pages\Product\Create.razor"
                    }

#line default
#line hidden
#nullable disable
                }
                );
                __builder2.AddMarkupContent(38, "\n                ");
                __Blazor.GuruNanak.Pages.Product.Create.TypeInference.CreateValidationMessage_2(__builder2, 39, 40, 
#nullable restore
#line 33 "E:\GN_Shop\GuruNanak\GuruNanak\GuruNanak\Pages\Product\Create.razor"
                                        (() => _item.ProductCategoryId)

#line default
#line hidden
#nullable disable
                );
                __builder2.CloseElement();
                __builder2.CloseElement();
                __builder2.AddMarkupContent(41, "\n   ");
                __builder2.OpenElement(42, "div");
                __builder2.AddAttribute(43, "class", "col-md-3");
                __builder2.OpenElement(44, "div");
                __builder2.AddAttribute(45, "class", "form-group");
                __builder2.AddMarkupContent(46, "<label class=\"control-label col-md-2\">Price</label>\n           \n                ");
                __Blazor.GuruNanak.Pages.Product.Create.TypeInference.CreateInputNumber_3(__builder2, 47, 48, "form-control", 49, 
#nullable restore
#line 40 "E:\GN_Shop\GuruNanak\GuruNanak\GuruNanak\Pages\Product\Create.razor"
                                          _item.Price

#line default
#line hidden
#nullable disable
                , 50, Microsoft.AspNetCore.Components.EventCallback.Factory.Create(this, global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => _item.Price = __value, _item.Price)), 51, () => _item.Price);
                __builder2.AddMarkupContent(52, "\n                ");
                __Blazor.GuruNanak.Pages.Product.Create.TypeInference.CreateValidationMessage_4(__builder2, 53, 54, 
#nullable restore
#line 41 "E:\GN_Shop\GuruNanak\GuruNanak\GuruNanak\Pages\Product\Create.razor"
                                        (() => _item.Price)

#line default
#line hidden
#nullable disable
                );
                __builder2.CloseElement();
                __builder2.CloseElement();
                __builder2.AddMarkupContent(55, "\n        ");
                __builder2.OpenElement(56, "div");
                __builder2.AddAttribute(57, "class", "col-md-3");
                __builder2.OpenElement(58, "div");
                __builder2.AddAttribute(59, "class", "form-group");
                __builder2.AddMarkupContent(60, "<label class=\"control-label\">Image Upload</label>\n            \n                ");
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Forms.InputFile>(61);
                __builder2.AddAttribute(62, "OnChange", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<Microsoft.AspNetCore.Components.Forms.InputFileChangeEventArgs>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Forms.InputFileChangeEventArgs>(this, 
#nullable restore
#line 48 "E:\GN_Shop\GuruNanak\GuruNanak\GuruNanak\Pages\Product\Create.razor"
                                      LoadFiles

#line default
#line hidden
#nullable disable
                )));
                __builder2.AddAttribute(63, "accept", "image/x-png");
                __builder2.AddAttribute(64, "title", "Upload png image");
                __builder2.CloseComponent();
                __builder2.CloseElement();
                __builder2.CloseElement();
                __builder2.CloseElement();
                __builder2.AddMarkupContent(65, "\n      \n\n        ");
                __builder2.AddMarkupContent(66, @"<div class=""form-group mt-3""><div class=""col-md-offset-2 col-md-3 text-right esh-button-actions""><a href=""/Product/Index"" class=""btn btn-secondary"">
                    [ Cancel ]
                </a>
                <button type=""submit"" class=""btn btn-primary"">
                    [ Create ]
                </button></div></div>");
            }
            ));
            __builder.CloseComponent();
            __builder.CloseElement();
        }
        #pragma warning restore 1998
#nullable restore
#line 67 "E:\GN_Shop\GuruNanak\GuruNanak\GuruNanak\Pages\Product\Create.razor"
       
    private readonly Product _item = new Product();

    private IEnumerable<ProductCategory> _types;

    protected override void OnInitialized()
    {
        _types = CatalogService.GetCatalogTypes();
        _item.ProductCategoryId = _types.First().Id;
    }

    private void Create_Click()
    {
        CatalogService.CreateCatalogItem(_item);

        NavigationManager.NavigateTo("/Product/Index");
    }
    //IFileListEntry file;
    private async Task LoadFiles(InputFileChangeEventArgs e)
    {
        var file = e.File;
        var path = Path.Combine(@"wwwroot/Pics/", file.Name);
        await using FileStream fs = new(path, FileMode.Create);
        await file.OpenReadStream().CopyToAsync(fs);
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private NavigationManager NavigationManager { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private ICatalogService CatalogService { get; set; }
    }
}
namespace __Blazor.GuruNanak.Pages.Product.Create
{
    #line hidden
    internal static class TypeInference
    {
        public static void CreateValidationMessage_0<TValue>(global::Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder, int seq, int __seq0, global::System.Linq.Expressions.Expression<global::System.Func<TValue>> __arg0)
        {
        __builder.OpenComponent<global::Microsoft.AspNetCore.Components.Forms.ValidationMessage<TValue>>(seq);
        __builder.AddAttribute(__seq0, "For", __arg0);
        __builder.CloseComponent();
        }
        public static void CreateInputSelect_1<TValue>(global::Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder, int seq, int __seq0, System.Object __arg0, int __seq1, TValue __arg1, int __seq2, global::Microsoft.AspNetCore.Components.EventCallback<TValue> __arg2, int __seq3, global::System.Linq.Expressions.Expression<global::System.Func<TValue>> __arg3, int __seq4, global::Microsoft.AspNetCore.Components.RenderFragment __arg4)
        {
        __builder.OpenComponent<global::Microsoft.AspNetCore.Components.Forms.InputSelect<TValue>>(seq);
        __builder.AddAttribute(__seq0, "class", __arg0);
        __builder.AddAttribute(__seq1, "Value", __arg1);
        __builder.AddAttribute(__seq2, "ValueChanged", __arg2);
        __builder.AddAttribute(__seq3, "ValueExpression", __arg3);
        __builder.AddAttribute(__seq4, "ChildContent", __arg4);
        __builder.CloseComponent();
        }
        public static void CreateValidationMessage_2<TValue>(global::Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder, int seq, int __seq0, global::System.Linq.Expressions.Expression<global::System.Func<TValue>> __arg0)
        {
        __builder.OpenComponent<global::Microsoft.AspNetCore.Components.Forms.ValidationMessage<TValue>>(seq);
        __builder.AddAttribute(__seq0, "For", __arg0);
        __builder.CloseComponent();
        }
        public static void CreateInputNumber_3<TValue>(global::Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder, int seq, int __seq0, System.Object __arg0, int __seq1, TValue __arg1, int __seq2, global::Microsoft.AspNetCore.Components.EventCallback<TValue> __arg2, int __seq3, global::System.Linq.Expressions.Expression<global::System.Func<TValue>> __arg3)
        {
        __builder.OpenComponent<global::Microsoft.AspNetCore.Components.Forms.InputNumber<TValue>>(seq);
        __builder.AddAttribute(__seq0, "class", __arg0);
        __builder.AddAttribute(__seq1, "Value", __arg1);
        __builder.AddAttribute(__seq2, "ValueChanged", __arg2);
        __builder.AddAttribute(__seq3, "ValueExpression", __arg3);
        __builder.CloseComponent();
        }
        public static void CreateValidationMessage_4<TValue>(global::Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder, int seq, int __seq0, global::System.Linq.Expressions.Expression<global::System.Func<TValue>> __arg0)
        {
        __builder.OpenComponent<global::Microsoft.AspNetCore.Components.Forms.ValidationMessage<TValue>>(seq);
        __builder.AddAttribute(__seq0, "For", __arg0);
        __builder.CloseComponent();
        }
    }
}
#pragma warning restore 1591
