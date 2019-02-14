
namespace PromoBotAPI.Pages
{
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using PromoBotAPI.Functions;

    public class AboutModel : PageModel
    {
        public string Message { get; set; }

        public void OnGet()
        {
            UserManagment userManagment = new UserManagment();
            string value = userManagment.ReadFile();
            Message = value;
        }
    }
}
