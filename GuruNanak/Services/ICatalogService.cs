﻿using GuruNanak.Database;
using GuruNanak.ViewModel;
using System;
using System.Collections.Generic;

namespace GuruNanak.Services
{
    public interface ICatalogService : IDisposable
    {
        Product FindCatalogItem(int id);
        PaginatedItemsViewModel<Product> GetCatalogItemsPaginated(int pageSize, int pageIndex);
        IEnumerable<ProductCategory> GetCatalogTypes();
        void CreateCatalogItem(Product catalogItem);
        void UpdateCatalogItem(Product catalogItem);
        void RemoveCatalogItem(Product catalogItem);
    }
}