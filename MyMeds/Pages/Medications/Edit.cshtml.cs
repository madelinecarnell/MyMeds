using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using MyMeds.Models;
using MyMeds.Services;

namespace MyMeds.Pages.Medications
{
    public class EditModel : PageModel
    {
        private readonly IUserServices _userServices;

        public EditModel(IUserServices userServices)
        {
            _userServices = userServices;
        }

        private IList<MedicationModel> Medications { get; set; }
        [BindProperty(SupportsGet = true)]
        public MedicationModel MedicationModel { get; set; }

        public IActionResult OnGet(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            Medications = _userServices.GrabMedicationsOnlyToList(User.Identity.Name);

            foreach (var med in Medications)
            {
                if (med.Id == id)
                {
                    MedicationModel = med;
                }
            }

            if (MedicationModel == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _userServices.UpdateMedicationTask(MedicationModel, id);
            return RedirectToPage("./Index");
        }
    }
}
