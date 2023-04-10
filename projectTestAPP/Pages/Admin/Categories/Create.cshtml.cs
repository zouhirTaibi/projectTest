using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using projetDataAccess.Data;
using projetDataAccess.Repository.IRepository;
using projetModels;

namespace projectTestAPP.Pages.Admin.Categories
{
    [BindProperties]
    public class CreateModel : PageModel
    {
        //private readonly ApplicationDbContext _db;
        private readonly IUnitOfWork _unitOfWork;
        public Category Category { get; set; }
        public CreateModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPost(Category Category)
        {
            if(Category.Name==Category.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Category.Name", "The Display Order cannot exactly match the name");
            }
            if (ModelState.IsValid)
            {

                _unitOfWork.Category.Add(Category);
                _unitOfWork.Save();
                TempData["success"] = "Category Created successfully";
                return RedirectToPage("Index");
            }
            return Page();//meme page
            

        }

    }
}
