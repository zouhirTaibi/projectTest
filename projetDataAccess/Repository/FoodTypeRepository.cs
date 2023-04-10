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
    public class FoodTypeRepository : Repository<FoodType>, IFoodRepository
    {
        private readonly ApplicationDbContext _db;
        public FoodTypeRepository(ApplicationDbContext db):base(db)
        {
            _db = db;

        }

        public void Update(FoodType obj)
        {
            var objFrmDb = _db.FoodType.FirstOrDefault(u => u.Id == obj.Id);
                objFrmDb.Name= obj.Name;

        }
    }
}
