using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using projetDataAccess.Data;
using projetDataAccess.Repository.IRepository;
using projetModels;

namespace projectTestAPP.Pages.Admin.Categories
{
    [BindProperties]
    public class DeleteModel : PageModel
    {
        //private readonly ApplicationDbContext _db;
        private readonly IUnitOfWork _unitOfWork;
        public Category Category { get; set; }
        public DeleteModel(IUnitOfWork unitOfWork)
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
            
            
                 var catFromDb = _unitOfWork.Category.GetFirstOrDefault(u => u.Id == Category.Id);
                
                if(catFromDb != null)
                {
                    _unitOfWork.Category.Remove(catFromDb);
                    _unitOfWork.Save();
                    TempData["success"] = "Category Deleted successfully";
                    return RedirectToPage("Index");
                } 
            return Page();//meme page
            

        }

    }
}
