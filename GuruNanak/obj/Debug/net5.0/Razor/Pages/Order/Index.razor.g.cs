#pragma checksum "E:\GN_Shop\GuruNanak\GuruNanak\GuruNanak\Pages\Order\Index.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b4cddac70250feaacfd881bd3cac3d7adf7b0d7d"
// <auto-generated/>
#pragma warning disable 1591
namespace GuruNanak.Pages.Order
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
#line 4 "E:\GN_Shop\GuruNanak\GuruNanak\GuruNanak\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

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
#line 2 "E:\GN_Shop\GuruNanak\GuruNanak\GuruNanak\Pages\Order\Index.razor"
using GuruNanak.Database;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "E:\GN_Shop\GuruNanak\GuruNanak\GuruNanak\Pages\Order\Index.razor"
using GuruNanak.Model;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "E:\GN_Shop\GuruNanak\GuruNanak\GuruNanak\Pages\Order\Index.razor"
using GuruNanak.Services;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "E:\GN_Shop\GuruNanak\GuruNanak\GuruNanak\Pages\Order\Index.razor"
using GuruNanak.ViewModel;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "E:\GN_Shop\GuruNanak\GuruNanak\GuruNanak\Pages\Order\Index.razor"
using Append.Blazor.Printing;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/Order/Index")]
    public partial class Index : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenElement(0, "div");
            __builder.AddAttribute(1, "class", "order-page py-4");
            __builder.AddMarkupContent(2, "<label> Select Category</label>\r\n");
            __builder.OpenElement(3, "select");
            __builder.AddAttribute(4, "id", "myselect");
            __builder.AddAttribute(5, "class", "form-control select-cat");
            __builder.AddAttribute(6, "onchange", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.ChangeEventArgs>(this, 
#nullable restore
#line 12 "E:\GN_Shop\GuruNanak\GuruNanak\GuruNanak\Pages\Order\Index.razor"
                                                                                 selectedValue

#line default
#line hidden
#nullable disable
            ));
            __builder.AddElementReferenceCapture(7, (__value) => {
#nullable restore
#line 12 "E:\GN_Shop\GuruNanak\GuruNanak\GuruNanak\Pages\Order\Index.razor"
              myselect = __value;

#line default
#line hidden
#nullable disable
            }
            );
            __builder.OpenElement(8, "option");
            __builder.AddAttribute(9, "selected");
            __builder.AddAttribute(10, "value", "-1");
            __builder.AddContent(11, "select one Category");
            __builder.CloseElement();
#nullable restore
#line 14 "E:\GN_Shop\GuruNanak\GuruNanak\GuruNanak\Pages\Order\Index.razor"
     foreach (var item in _types)
    {

#line default
#line hidden
#nullable disable
            __builder.OpenElement(12, "option");
            __builder.AddAttribute(13, "value", 
#nullable restore
#line 16 "E:\GN_Shop\GuruNanak\GuruNanak\GuruNanak\Pages\Order\Index.razor"
                        item.Id

#line default
#line hidden
#nullable disable
            );
#nullable restore
#line 16 "E:\GN_Shop\GuruNanak\GuruNanak\GuruNanak\Pages\Order\Index.razor"
__builder.AddContent(14, item.Type);

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
#nullable restore
#line 17 "E:\GN_Shop\GuruNanak\GuruNanak\GuruNanak\Pages\Order\Index.razor"
    }

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
            __builder.AddMarkupContent(15, "\r\n\r\n");
            __builder.OpenElement(16, "div");
            __builder.AddAttribute(17, "class", "row order-sections");
            __builder.OpenElement(18, "div");
            __builder.AddAttribute(19, "class", "col-md-8 order-details");
            __builder.OpenElement(20, "div");
            __builder.AddAttribute(21, "class", "esh-table");
#nullable restore
#line 24 "E:\GN_Shop\GuruNanak\GuruNanak\GuruNanak\Pages\Order\Index.razor"
         if (paginatedCatalogItems == null || !paginatedCatalogItems.Data.Any())
        {

#line default
#line hidden
#nullable disable
            __builder.AddMarkupContent(22, "<table><tr><td>No data was returned.</td></tr></table>");
#nullable restore
#line 31 "E:\GN_Shop\GuruNanak\GuruNanak\GuruNanak\Pages\Order\Index.razor"
        }
        else
        {

#line default
#line hidden
#nullable disable
            __builder.OpenElement(23, "table");
            __builder.AddAttribute(24, "class", "table");
            __builder.AddMarkupContent(25, @"<thead><tr class=""esh-table-header""><th>Product Img</th>
                        <th>Name</th>
                        <th>Unit Price</th>
                        <th>Quantity</th>
                        <th>Actions</th></tr></thead>
                ");
            __builder.OpenElement(26, "tbody");
#nullable restore
#line 45 "E:\GN_Shop\GuruNanak\GuruNanak\GuruNanak\Pages\Order\Index.razor"
                     foreach (var catalogItem in paginatedCatalogItems.Data)
                    {

#line default
#line hidden
#nullable disable
            __builder.OpenElement(27, "tr");
            __builder.OpenElement(28, "td");
            __builder.OpenElement(29, "img");
            __builder.AddAttribute(30, "class", "esh-thumbnail");
            __builder.AddAttribute(31, "src", 
#nullable restore
#line 49 "E:\GN_Shop\GuruNanak\GuruNanak\GuruNanak\Pages\Order\Index.razor"
                                                                  $"/Pics/{catalogItem.ProductName}.png"

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(32, "\r\n                            ");
            __builder.OpenElement(33, "td");
            __builder.OpenElement(34, "p");
#nullable restore
#line 52 "E:\GN_Shop\GuruNanak\GuruNanak\GuruNanak\Pages\Order\Index.razor"
__builder.AddContent(35, catalogItem.ProductName);

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(36, "\r\n                            ");
            __builder.OpenElement(37, "td");
            __builder.OpenElement(38, "span");
            __builder.AddAttribute(39, "class", "esh-price");
#nullable restore
#line 55 "E:\GN_Shop\GuruNanak\GuruNanak\GuruNanak\Pages\Order\Index.razor"
__builder.AddContent(40, catalogItem.UnitPrice);

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(41, "\r\n                            ");
            __builder.OpenElement(42, "td");
            __builder.OpenElement(43, "input");
            __builder.AddAttribute(44, "type", "number");
            __builder.AddAttribute(45, "placeholder", "Type Quantity");
            __builder.AddAttribute(46, "id", "qty");
            __builder.AddAttribute(47, "value", Microsoft.AspNetCore.Components.BindConverter.FormatValue(
#nullable restore
#line 58 "E:\GN_Shop\GuruNanak\GuruNanak\GuruNanak\Pages\Order\Index.razor"
                                                                                                        catalogItem.Quatity

#line default
#line hidden
#nullable disable
            , culture: global::System.Globalization.CultureInfo.InvariantCulture));
            __builder.AddAttribute(48, "onchange", Microsoft.AspNetCore.Components.EventCallback.Factory.CreateBinder(this, __value => catalogItem.Quatity = __value, catalogItem.Quatity, culture: global::System.Globalization.CultureInfo.InvariantCulture));
            __builder.SetUpdatesAttributeName("value");
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(49, "\r\n                            ");
            __builder.OpenElement(50, "td");
            __builder.OpenElement(51, "span");
            __builder.AddAttribute(52, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 61 "E:\GN_Shop\GuruNanak\GuruNanak\GuruNanak\Pages\Order\Index.razor"
                                                () => addtoCart(catalogItem)

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(53, "class", "esh-table-link");
            __builder.AddMarkupContent(54, "\r\n                                    Add to Cart |\r\n                                ");
            __builder.CloseElement();
            __builder.AddMarkupContent(55, "\r\n                                ");
            __builder.OpenElement(56, "span");
            __builder.AddAttribute(57, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 64 "E:\GN_Shop\GuruNanak\GuruNanak\GuruNanak\Pages\Order\Index.razor"
                                                () => remove(catalogItem)

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(58, "class", "esh-table-link");
            __builder.AddMarkupContent(59, "\r\n                                    Remove\r\n                                ");
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
#nullable restore
#line 69 "E:\GN_Shop\GuruNanak\GuruNanak\GuruNanak\Pages\Order\Index.razor"
                    }

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
            __builder.CloseElement();
#nullable restore
#line 72 "E:\GN_Shop\GuruNanak\GuruNanak\GuruNanak\Pages\Order\Index.razor"
        }

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
#nullable restore
#line 74 "E:\GN_Shop\GuruNanak\GuruNanak\GuruNanak\Pages\Order\Index.razor"
     if (paginatedCatalogItems != null)
    {

#line default
#line hidden
#nullable disable
            __builder.OpenElement(60, "div");
            __builder.AddAttribute(61, "class", "esh-pager");
            __builder.OpenElement(62, "div");
            __builder.AddAttribute(63, "class", "container");
            __builder.OpenElement(64, "article");
            __builder.AddAttribute(65, "class", "esh-pager-wrapper row");
            __builder.OpenElement(66, "nav");
#nullable restore
#line 80 "E:\GN_Shop\GuruNanak\GuruNanak\GuruNanak\Pages\Order\Index.razor"
                         if (pageIndex > 0)
                        {

#line default
#line hidden
#nullable disable
            __builder.OpenElement(67, "a");
            __builder.AddAttribute(68, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 82 "E:\GN_Shop\GuruNanak\GuruNanak\GuruNanak\Pages\Order\Index.razor"
                                         Previous

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(69, "class", "esh-pager-item esh-pager-item--navigable");
            __builder.AddMarkupContent(70, "\r\n                                Previous\r\n                            ");
            __builder.CloseElement();
#nullable restore
#line 85 "E:\GN_Shop\GuruNanak\GuruNanak\GuruNanak\Pages\Order\Index.razor"
                        }

#line default
#line hidden
#nullable disable
            __builder.OpenElement(71, "span");
            __builder.AddAttribute(72, "class", "esh-pager-item");
            __builder.AddMarkupContent(73, "\r\n                            Showing ");
#nullable restore
#line 88 "E:\GN_Shop\GuruNanak\GuruNanak\GuruNanak\Pages\Order\Index.razor"
__builder.AddContent(74, paginatedCatalogItems.ItemsPerPage);

#line default
#line hidden
#nullable disable
            __builder.AddContent(75, " of ");
#nullable restore
#line 88 "E:\GN_Shop\GuruNanak\GuruNanak\GuruNanak\Pages\Order\Index.razor"
__builder.AddContent(76, paginatedCatalogItems.TotalItems);

#line default
#line hidden
#nullable disable
            __builder.AddContent(77, " products - Page ");
#nullable restore
#line 88 "E:\GN_Shop\GuruNanak\GuruNanak\GuruNanak\Pages\Order\Index.razor"
__builder.AddContent(78, paginatedCatalogItems.ActualPage + 1);

#line default
#line hidden
#nullable disable
            __builder.AddContent(79, " - ");
#nullable restore
#line 88 "E:\GN_Shop\GuruNanak\GuruNanak\GuruNanak\Pages\Order\Index.razor"
__builder.AddContent(80, paginatedCatalogItems.TotalPages);

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
#nullable restore
#line 91 "E:\GN_Shop\GuruNanak\GuruNanak\GuruNanak\Pages\Order\Index.razor"
                         if (pageIndex < paginatedCatalogItems.TotalPages - 1)
                        {

#line default
#line hidden
#nullable disable
            __builder.OpenElement(81, "a");
            __builder.AddAttribute(82, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 93 "E:\GN_Shop\GuruNanak\GuruNanak\GuruNanak\Pages\Order\Index.razor"
                                         Next

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(83, "class", "esh-pager-item esh-pager-item--navigable");
            __builder.AddMarkupContent(84, "\r\n                                Next\r\n                            ");
            __builder.CloseElement();
#nullable restore
#line 96 "E:\GN_Shop\GuruNanak\GuruNanak\GuruNanak\Pages\Order\Index.razor"
                        }

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
#nullable restore
#line 101 "E:\GN_Shop\GuruNanak\GuruNanak\GuruNanak\Pages\Order\Index.razor"
    }

#line default
#line hidden
#nullable disable
            __builder.OpenElement(85, "div");
            __builder.AddAttribute(86, "class", "row cal-section py-2");
            __builder.OpenElement(87, "div");
            __builder.AddAttribute(88, "class", "col-md-6");
            __builder.AddMarkupContent(89, "<label>Discount</label>\r\n              ");
            __builder.OpenElement(90, "input");
            __builder.AddAttribute(91, "type", "number");
            __builder.AddAttribute(92, "class", "form-control");
            __builder.AddAttribute(93, "placeholder", "Type discount");
            __builder.AddAttribute(94, "id", "dis");
            __builder.AddAttribute(95, "value", Microsoft.AspNetCore.Components.BindConverter.FormatValue(
#nullable restore
#line 106 "E:\GN_Shop\GuruNanak\GuruNanak\GuruNanak\Pages\Order\Index.razor"
                                                                                                           discount

#line default
#line hidden
#nullable disable
            , culture: global::System.Globalization.CultureInfo.InvariantCulture));
            __builder.AddAttribute(96, "onchange", Microsoft.AspNetCore.Components.EventCallback.Factory.CreateBinder(this, __value => discount = __value, discount, culture: global::System.Globalization.CultureInfo.InvariantCulture));
            __builder.SetUpdatesAttributeName("value");
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(97, "\r\n       ");
            __builder.OpenElement(98, "div");
            __builder.AddAttribute(99, "class", "col-md-6");
            __builder.OpenElement(100, "button");
            __builder.AddAttribute(101, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 110 "E:\GN_Shop\GuruNanak\GuruNanak\GuruNanak\Pages\Order\Index.razor"
                              () => submit()

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(102, "class", "btn btn-success btn-sm");
            __builder.AddContent(103, "Calculate");
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(104, "\r\n\r\n");
            __builder.OpenElement(105, "div");
            __builder.AddAttribute(106, "class", "col-md-4 py-4");
            __builder.AddAttribute(107, "id", "printsec");
            __builder.OpenElement(108, "div");
            __builder.AddAttribute(109, "id", "printbill");
            __builder.AddMarkupContent(110, "<h3 class=\"head-tittle\">Guru Nanak</h3>\r\n    ");
            __builder.AddMarkupContent(111, "<span style=\" margin-bottom:0;padding:1px 0;\">Sweets | Dairy | Snacks</span><br>\r\n    ");
            __builder.AddMarkupContent(112, "<span style=\" margin-bottom:0;padding:1px 0;\">Add.: Malwal Road, Near Markfed Sale Office,Ferozepur City, Punjab</span><br>\r\n    ");
            __builder.AddMarkupContent(113, "<span style=\" margin-bottom:0;padding:1px 0;\">Mob.: 8556990949, 8360059217</span><br>\r\n    ");
            __builder.AddMarkupContent(114, "<span style=\" margin-bottom:0;padding:1px 0;\">---------------------------------------</span><br>\r\n    ");
            __builder.OpenElement(115, "table");
            __builder.OpenElement(116, "tbody");
#nullable restore
#line 126 "E:\GN_Shop\GuruNanak\GuruNanak\GuruNanak\Pages\Order\Index.razor"
             foreach (var catalogItem in orderPages)
            {

#line default
#line hidden
#nullable disable
            __builder.OpenElement(117, "tr");
            __builder.OpenElement(118, "td");
            __builder.OpenElement(119, "span");
#nullable restore
#line 130 "E:\GN_Shop\GuruNanak\GuruNanak\GuruNanak\Pages\Order\Index.razor"
__builder.AddContent(120, catalogItem.Quatity);

#line default
#line hidden
#nullable disable
            __builder.AddContent(121, " x ");
#nullable restore
#line 130 "E:\GN_Shop\GuruNanak\GuruNanak\GuruNanak\Pages\Order\Index.razor"
__builder.AddContent(122, catalogItem.ProductName);

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(123, "\r\n                    ");
            __builder.OpenElement(124, "td");
            __builder.OpenElement(125, "span");
            __builder.AddAttribute(126, "class", "esh-price");
#nullable restore
#line 133 "E:\GN_Shop\GuruNanak\GuruNanak\GuruNanak\Pages\Order\Index.razor"
__builder.AddContent(127, catalogItem.TotalPrice);

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
#nullable restore
#line 136 "E:\GN_Shop\GuruNanak\GuruNanak\GuruNanak\Pages\Order\Index.razor"
            }

#line default
#line hidden
#nullable disable
            __builder.AddMarkupContent(128, "<tr>---------------------------</tr>");
#nullable restore
#line 138 "E:\GN_Shop\GuruNanak\GuruNanak\GuruNanak\Pages\Order\Index.razor"
             if (discount > 0)
            {

#line default
#line hidden
#nullable disable
            __builder.OpenElement(129, "tr");
            __builder.AddMarkupContent(130, "<td><b>Discount</b></td>\r\n                    ");
            __builder.OpenElement(131, "td");
            __builder.OpenElement(132, "span");
            __builder.AddAttribute(133, "class", "esh-price");
#nullable restore
#line 142 "E:\GN_Shop\GuruNanak\GuruNanak\GuruNanak\Pages\Order\Index.razor"
__builder.AddContent(134, discount);

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
#nullable restore
#line 144 "E:\GN_Shop\GuruNanak\GuruNanak\GuruNanak\Pages\Order\Index.razor"
            }

#line default
#line hidden
#nullable disable
            __builder.OpenElement(135, "tr");
            __builder.AddMarkupContent(136, "<td><b>Total Price</b></td>\r\n                ");
            __builder.OpenElement(137, "td");
            __builder.OpenElement(138, "b");
            __builder.OpenElement(139, "span");
            __builder.AddAttribute(140, "class", "esh-price");
#nullable restore
#line 147 "E:\GN_Shop\GuruNanak\GuruNanak\GuruNanak\Pages\Order\Index.razor"
__builder.AddContent(141, total);

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(142, "\r\n    ");
            __builder.AddMarkupContent(143, "<span style=\" margin-bottom:0;padding:1px 0;\">---------------------------------------</span>\r\n    ");
            __builder.AddMarkupContent(144, "<p>Thanks!! Visit again.</p>");
            __builder.CloseElement();
            __builder.AddMarkupContent(145, "\r\n    ");
            __builder.OpenElement(146, "button");
            __builder.AddAttribute(147, "class", "btn btn-sm btn-success");
            __builder.AddAttribute(148, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 154 "E:\GN_Shop\GuruNanak\GuruNanak\GuruNanak\Pages\Order\Index.razor"
                                                       () => PrintingService.Print("printbill", PrintType.Html)

#line default
#line hidden
#nullable disable
            ));
            __builder.AddMarkupContent(149, "\r\n        Print bill\r\n    ");
            __builder.CloseElement();
            __builder.AddMarkupContent(150, "\r\n    ");
            __builder.OpenElement(151, "button");
            __builder.AddAttribute(152, "class", "btn btn-sm btn-dark");
            __builder.AddAttribute(153, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 157 "E:\GN_Shop\GuruNanak\GuruNanak\GuruNanak\Pages\Order\Index.razor"
                                                     () => reset()

#line default
#line hidden
#nullable disable
            ));
            __builder.AddMarkupContent(154, "\r\n        Reset\r\n    ");
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
        }
        #pragma warning restore 1998
#nullable restore
#line 164 "E:\GN_Shop\GuruNanak\GuruNanak\GuruNanak\Pages\Order\Index.razor"
       
    private ElementReference myselect;
    public int SelectedValue;
    private IEnumerable<ProductCategory> _types;
    int pageSize = 5;
    int pageIndex = 0;
    PaginatedItemsViewModel<OrderPage> paginatedCatalogItems;
    List<OrderPage> orderPages = new List<OrderPage>();
    public decimal discount = 0;
    public decimal total = 0;
    void Previous()
    {
        pageIndex--;
        LoadPage(SelectedValue);
    }

    void Next()
    {
        pageIndex++;
        LoadPage(SelectedValue);
    }

    void LoadPage(int SelectedValue)
    {
        paginatedCatalogItems = CatalogService.GetCatalogItemsPaginated(pageSize, pageIndex, SelectedValue);
    }

    public void selectedValue(ChangeEventArgs args)
    {
        SelectedValue = Int16.Parse(args.Value.ToString());
        LoadPage(SelectedValue);
    }

    public void addtoCart(OrderPage orderPage)
    {
        orderPage.TotalPrice = orderPage.UnitPrice * orderPage.Quatity;
        orderPages.Add(orderPage);
        total = orderPages.Sum(x => x.TotalPrice) - discount;
    }
    public void remove(OrderPage orderPage)
    {
        orderPages.Remove(orderPage);
        total = orderPages.Sum(x => x.TotalPrice) - discount;
    }

    public void reset()
    {
        orderPages = new List<OrderPage>();
        discount = 0;
        total = 0;
        LoadPage(SelectedValue);
    }

    public void submit()
    {
        total = total - discount;
    }

    protected override void OnInitialized()
    {
        _types = CatalogService.GetCatalogTypes();
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IOrderService CatalogService { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IPrintingService PrintingService { get; set; }
    }
}
#pragma warning restore 1591
