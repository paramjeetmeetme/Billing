using GuruNanak.Database;
using GuruNanak.Model;
using GuruNanak.ViewModel;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace GuruNanak.Services
{
    public class OrderService : IOrderService
    {
        private GuruNanakSweetsContext db;

        public OrderService(GuruNanakSweetsContext db)
        {
            this.db = db;
        }

        public PaginatedItemsViewModel<OrderPage> GetCatalogItemsPaginated(int pageSize, int pageIndex, int SelectedValue)
        {
            var totalItems = db.Products.LongCount();

            var itemsOnPage = db.Products
                .Include(c => c.ProductCategory)
                .Where(c => c.ProductCategoryId == SelectedValue)
                .OrderBy(c => c.Id)
                .Skip(pageSize * pageIndex)
                .Take(pageSize)
                .ToList();
            List<OrderPage> orderPages = new List<OrderPage>();
            foreach (var item in itemsOnPage)
            {
                OrderPage orderPage = new OrderPage();
                orderPage.ProductName = item.Name;
                orderPage.UnitPrice = item.Price;
                orderPages.Add(orderPage);
            }

            return new PaginatedItemsViewModel<OrderPage>(
                pageIndex, pageSize, totalItems, orderPages);
        }

        public IEnumerable<ProductCategory> GetCatalogTypes()
        {
            return db.ProductCategories.ToList();
        }

        public void CreateCatalogItem(OrderDetail catalogItem)
        {
            db.OrderDetails.Add(catalogItem);
            db.SaveChanges();
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}


