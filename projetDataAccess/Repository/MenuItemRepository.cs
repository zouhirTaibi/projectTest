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
    public class MenuItemRepository : Repository<MenuItem>, IMenuItemRepository
    {
        private readonly ApplicationDbContext _db;
        public MenuItemRepository(ApplicationDbContext db):base(db)
        {
            _db = db;

        }
      
        public void Update(MenuItem obj)
        {
            var objFrmDb = _db.MenuItem.FirstOrDefault(u => u.Id == obj.Id);
                objFrmDb.Name= obj.Name;
                objFrmDb.Description = obj.Description;
                objFrmDb.Price = obj.Price;
                objFrmDb.CategoryId = obj.CategoryId;
                objFrmDb.FoodTypeId = obj.FoodTypeId;
                objFrmDb.Name = obj.Name;
                if(objFrmDb.Image!=null)
                    {
                        objFrmDb.Image = obj.Image;
                    }

        }
    }
}
