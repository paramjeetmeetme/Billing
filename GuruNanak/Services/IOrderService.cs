using GuruNanak.Database;
using GuruNanak.Model;
using GuruNanak.ViewModel;
using System;
using System.Collections.Generic;

namespace GuruNanak.Services
{
    public interface IOrderService : IDisposable
    {
        PaginatedItemsViewModel<OrderPage> GetCatalogItemsPaginated(int pageSize, int pageIndex, int SelectedValue);
        IEnumerable<ProductCategory> GetCatalogTypes();
        void CreateCatalogItem(OrderDetail catalogItem);
    }
}