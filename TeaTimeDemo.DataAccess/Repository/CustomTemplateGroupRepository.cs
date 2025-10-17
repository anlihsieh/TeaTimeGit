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
    public class CustomTemplateGroupRepository : Repository<CustomTemplateGroup>, ICustomTemplateGroupRepository
    {
        private ApplicationDbContext _db;
        public CustomTemplateGroupRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(CustomTemplateGroup obj)
        {
            _db.CustomTemplateGroups.Update(obj);
        } 
    
    }
}
