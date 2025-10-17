using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeaTimeDemo.DataAccess.Data;
using TeaTimeDemo.DataAccess.Repository.IRepository;
using TeaTimeDemo.Models;

namespace TeaTimeDemo.DataAccess.Repository
{
    public class ProductCustomGroupRepository : Repository<ProductCustomGroup>, IProductCustomGroupRepository
    {
        private ApplicationDbContext _db;
        public ProductCustomGroupRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(ProductCustomGroup obj)
        {
            _db.ProductCustomGroups.Update(obj);
        } 
    
    }
}
