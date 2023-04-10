using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using projetDataAccess.Data;
using projetDataAccess.Repository.IRepository;
using projetModels;

namespace projectTestAPP.Pages.Admin.FoodTypes
{
    [BindProperties]
    public class DeleteModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        public FoodType FoodType { get; set; }
        public DeleteModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public void OnGet(int id)
        {
             FoodType = _unitOfWork.FoodType.GetFirstOrDefault(u=>u.Id==id);
            //Category = _db.Category.FirstOrDefault(u=>u.Int==id);
            //Category = _db.Category.SingleOrDefault(u => u.Int == id);
            //Category = _db.Category.Where(u => u.Int == id).FirstOrDefault();
        }
        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                 var foodFromDb = _unitOfWork.FoodType.GetFirstOrDefault(u => u.Id == FoodType.Id);

                if (foodFromDb != null)
                {
                    _unitOfWork.FoodType.Remove(foodFromDb);
                    _unitOfWork.Save();
                    TempData["success"] = "FoodType Deleted successfully";
                    return RedirectToPage("Index");
                }
            }
            return Page();//meme page
            

        }

    }
}
