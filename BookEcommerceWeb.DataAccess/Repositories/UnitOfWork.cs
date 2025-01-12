﻿using BookEcommerceWeb.DataAccess.Data;
using BookEcommerceWeb.DataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookEcommerceWeb.DataAccess.Repositories
{
    public class UnitOfWork : IUnitofWork
    {
        public ApplicationDbContext _db;
        public ICategoryRepository CategoryRepository { get; private set; }

        public IProductRepository ProductRepository { get; private set; }

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            CategoryRepository = new CategoryRepository(_db);
            ProductRepository = new ProductRepository(_db);
        }
        public async Task SaveChangeAsync()
        {
            await _db.SaveChangesAsync();
        }
        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
