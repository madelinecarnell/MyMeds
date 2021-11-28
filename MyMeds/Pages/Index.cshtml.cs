using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using MyMeds.Models;
using MyMeds.Services;

namespace MyMeds.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        [BindProperty(SupportsGet = true)]
        public LogonModel UserModel { get; set; }
        private readonly IUserServices _userServices;

        public IndexModel(ILogger<IndexModel> logger, IUserServices userServices)
        {
            _logger = logger;
            _userServices = userServices;
        }

        public void OnGet()
        {
            UserModel = _userServices.GrabDataForUser(User.Identity.Name);
        }
    }
}