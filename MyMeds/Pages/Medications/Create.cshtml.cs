using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using MyMeds.Models;
using MyMeds.Services;

namespace MyMeds.Pages.Medications
{
    public class CreateModel : PageModel
    {
        private readonly IUserServices _userServices;

        public CreateModel(IUserServices userServices)
        {
            _userServices = userServices;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public MedicationModel MedicationModel { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var user = _userServices.GrabDataForUser(User.Identity.Name);
            await _userServices.CreateMedicationTask(MedicationModel, user.LoginId);

            return RedirectToPage("./Index");
        }
    }
}
