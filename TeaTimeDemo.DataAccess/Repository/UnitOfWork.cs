using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeaTimeDemo.DataAccess.Data;
using TeaTimeDemo.DataAccess.Repository.IRepository;

namespace TeaTimeDemo.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _db;
        public ICategoryRepository Category { get; private set; }
        public IProductRepository Product { get; private set; }
        public IStoreRepository Store { get; private set; }
        public IShoppingCartRepository ShoppingCart { get; private set; }
        public IApplicationUserRepository ApplicationUser { get; private set; }
        public IOrderHeaderRepository OrderHeader { get; private set; }
        public IOrderDetailRepository OrderDetail { get; private set; }
        public ICustomTemplateRepository CustomTemplate { get; private set; }
        public ICustomGroupRepository CustomGroup { get; private set; }
        public ICustomOptionRepository CustomOption { get; private set; }
        public ICustomTemplateGroupRepository CustomTemplateGroup { get; private set; }
        public IProductCustomGroupRepository ProductCustomGroup { get; private set; }
        public IShoppingCartCustomOptionRepository ShoppingCartCustomOption { get; private set; }
        public IOrderDetailCustomOptionRepository OrderDetailCustomOption { get; private set; }

        public UnitOfWork(ApplicationDbContext db)
        { 
            _db = db;
            Category = new CategoryRepository(_db);
            Product = new ProductRepository(_db);
            Store = new StoreRepository(_db);
            ShoppingCart = new ShoppingCartRepository(_db);
            ApplicationUser = new ApplicationUserRepository(_db);
            OrderHeader = new OrderHeaderRepository(_db);
            OrderDetail = new OrderDetailRepository(_db);
            CustomTemplate = new CustomTemplateRepository(_db);
            CustomGroup = new CustomGroupRepository(_db);
            CustomOption = new CustomOptionRepository(_db);
            CustomTemplateGroup = new CustomTemplateGroupRepository(_db);
            ProductCustomGroup = new ProductCustomGroupRepository(_db);
            ShoppingCartCustomOption = new ShoppingCartCustomOptionRepository(_db);
            OrderDetailCustomOption = new OrderDetailCustomOptionRepository(_db);
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
