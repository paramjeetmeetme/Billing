using GuruNanak.Database;
using GuruNanak.Model;
using GuruNanak.ViewModel;

namespace GuruNanak.Services;

public interface IOrderService : IDisposable
{
    Order FindCatalogItem(int id);
    PaginatedItemsViewModel<OrderPage> GetCatalogItemsPaginated(int pageSize, int pageIndex, int SelectedValue);
    IEnumerable<ProductCategory> GetCatalogTypes();
    void CreateCatalogItem(Order catalogItem);
}
