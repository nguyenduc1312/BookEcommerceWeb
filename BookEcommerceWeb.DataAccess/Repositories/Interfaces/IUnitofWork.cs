﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookEcommerceWeb.DataAccess.Repositories.Interfaces
{
    public interface IUnitofWork
    {
        public ICategoryRepository CategoryRepository { get; }
        public IProductRepository ProductRepository { get; }
        public ICompanyRepository CompanyRepository { get; }

        Task SaveChangeAsync();
        void Save();
    }
}
