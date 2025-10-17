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
    public class ShoppingCartCustomOptionRepository : Repository<ShoppingCartCustomOption>, IShoppingCartCustomOptionRepository
    {
        private ApplicationDbContext _db;
        public ShoppingCartCustomOptionRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(ShoppingCartCustomOption obj)
        {
            _db.ShoppingCartCustomOptions.Update(obj);
        } 
    
    }
}
