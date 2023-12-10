﻿using GameHub.CRUD.CategoriesCRUD;
using GameHub.CRUD.ProductsCRUD;
using GameHub.CRUD.ShoppingCartsCRUD;
using GameHub.Data;

namespace GameHub.CRUD
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _db;
        public ICategoryCRUD Category { get; private set; }

        public IProductCRUD Product { get; private set; }

        public IShoppingCartCRUD ShoppingCart { get; private set; }

        public IShoppingCartProductCRUD ShoppingCartProduct { get; private set; }
        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Category = new CategoryCRUD(_db);
            Product = new ProductCRUD(_db);
            ShoppingCart = new ShoppingCartCRUD(_db);
            ShoppingCartProduct = new ShoppingCartProductCRUD(_db);
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
