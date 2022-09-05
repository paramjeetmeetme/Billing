using GuruNanak.Database;
using GuruNanak.ViewModel;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace GuruNanak.Services
{
    public class CatalogService : ICatalogService
    {
        private GuruNanakSweetsContext db;

        public CatalogService(GuruNanakSweetsContext db)
        {
            this.db = db;
        }

        public PaginatedItemsViewModel<Product> GetCatalogItemsPaginated(int pageSize, int pageIndex)
        {
            var totalItems = db.Products.LongCount();

            var itemsOnPage = db.Products
                .Include(c => c.ProductCategory)
                .OrderBy(c => c.Id)
                .Skip(pageSize * pageIndex)
                .Take(pageSize)
                .ToList();

            return new PaginatedItemsViewModel<Product>(
                pageIndex, pageSize, totalItems, itemsOnPage);
        }

        public Product FindCatalogItem(int id)
        {
            return db.Products.Include(c => c.ProductCategory).FirstOrDefault(ci => ci.Id == id);
        }
        public IEnumerable<ProductCategory> GetCatalogTypes()
        {
            return db.ProductCategories.ToList();
        }

        public void CreateCatalogItem(Product catalogItem)
        {
            db.Products.Add(catalogItem);
            db.SaveChanges();
        }

        public void UpdateCatalogItem(Product catalogItem)
        {
            db.Entry(catalogItem).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void RemoveCatalogItem(Product catalogItem)
        {
            db.Products.Remove(catalogItem);
            db.SaveChanges();
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}