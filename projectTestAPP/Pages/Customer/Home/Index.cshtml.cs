using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using projetDataAccess.Repository.IRepository;
using projetModels;

namespace projectTestAPP.Pages.Customer.Home
{
    public class IndexModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        public IndexModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork; 
        }
        public IEnumerable<MenuItem>? MenuItems { get; set; }
		public IEnumerable<Category>? CategoryList { get; set; }
		public void OnGet()
        {
            MenuItems = _unitOfWork.MenuItem.GetAll(includeProperties:"Category,FoodType");
            CategoryList = _unitOfWork.Category.GetAll(orderby:u=>u.OrderBy(c=>c.DisplayOrder));
        }
    }
}

