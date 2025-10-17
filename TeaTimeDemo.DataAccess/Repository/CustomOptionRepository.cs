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
    public class CustomOptionRepository : Repository<CustomOption>, ICustomOptionRepository
    {
        private ApplicationDbContext _db;
        public CustomOptionRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(CustomOption obj)
        {
            _db.CustomOptions.Update(obj);
        } 
    
    }
}
