using projetDataAccess.Data;
using projetDataAccess.Repository.IRepository;
using projetModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projetDataAccess.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private readonly ApplicationDbContext _db;
        public CategoryRepository(ApplicationDbContext db):base(db)
        {
            _db = db;

        }
      
        public void Update(Category category)
        {
            var objFrmDb = _db.Category.FirstOrDefault(u => u.Id == category.Id);
                objFrmDb.Name= category.Name;
                objFrmDb.DisplayOrder = category.DisplayOrder;

        }
    }
}
