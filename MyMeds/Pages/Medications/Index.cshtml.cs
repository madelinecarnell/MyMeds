using Microsoft.AspNetCore.Mvc.RazorPages;

using MyMeds.Models;
using MyMeds.Services;

namespace MyMeds.Pages.Medications
{
    public class IndexModel : PageModel
    {
        private readonly IUserServices _userServices;

        public IndexModel(IUserServices userServices)
        {
            _userServices = userServices;
        }

        public IList<MedicationModel> MedicationModel { get; set; }

        public void OnGet()
        {
            MedicationModel = _userServices.GrabMedicationsOnlyToList(User.Identity.Name);
        }
    }
}
