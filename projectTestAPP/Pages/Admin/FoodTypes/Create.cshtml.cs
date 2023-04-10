using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using projetDataAccess.Data;
using projetDataAccess.Repository;
using projetDataAccess.Repository.IRepository;
using projetModels;

namespace projectTestAPP.Pages.Admin.FoodTypes
{
    [BindProperties]
    public class CreateModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        public FoodType FoodType { get; set; }
        public CreateModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork =unitOfWork;
        }
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPost()
        {
            
            if (ModelState.IsValid)
            {

                _unitOfWork.FoodType.Add(FoodType);
               _unitOfWork.Save();
                TempData["success"] = "FoodType Created successfully";
                return RedirectToPage("Index");
            }
            return Page();//meme page
            

        }

    }
}
