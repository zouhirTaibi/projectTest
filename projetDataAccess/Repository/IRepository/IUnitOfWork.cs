﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projetDataAccess.Repository.IRepository
{
    public interface IUnitOfWork:IDisposable
    {
        ICategoryRepository Category { get; }
        IFoodRepository FoodType { get; }
        IMenuItemRepository MenuItem { get; }
        void Save();
    }
}
