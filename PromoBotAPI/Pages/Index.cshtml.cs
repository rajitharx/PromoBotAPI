
namespace PromoBotAPI.Pages
{
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using PromoBotAPI.Functions;

    public class IndexModel : PageModel
    {
        public void OnGet()
        {
            UserManagment userManagment = new UserManagment();

            userManagment.RecordUser();
        }
    }
}
