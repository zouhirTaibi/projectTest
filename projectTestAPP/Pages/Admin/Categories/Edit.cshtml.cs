using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using projetDataAccess.Data;
using projetDataAccess.Repository.IRepository;
using projetModels;

namespace projectTestAPP.Pages.Admin.Categories
{
    [BindProperties]
    public class EditModel : PageModel
    {
        //private readonly ApplicationDbContext _db;
        private readonly IUnitOfWork _unitOfWork;
        public Category Category { get; set; }
        public EditModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void OnGet(int id)
        {
             Category = _unitOfWork.Category.GetFirstOrDefault(u=>u.Id==id);
            //Category = _db.Category.FirstOrDefault(u=>u.Int==id);
            //Category = _db.Category.SingleOrDefault(u => u.Int == id);
            //Category = _db.Category.Where(u => u.Int == id).FirstOrDefault();
        }
        public async Task<IActionResult> OnPost()
        {
            if(Category.Name==Category.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Category.Name", "The Display Order cannot exactly match the name");
            }
            if (ModelState.IsValid)
            {

                _unitOfWork.Category.Update(Category);
                _unitOfWork.Save();
                TempData["success"] = "Category Updated successfully";
                return RedirectToPage("Index");
            }
            return Page();//meme page
            

        }

    }
}
