using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PromoBotAPI.Pages
{
    public class IndexModel : PageModel
    {
        public void OnGet()
        {
            var test = System.Security.Principal.WindowsIdentity.GetCurrent().Name;

            using (StreamWriter writer = new StreamWriter("log.txt", true))
            {
                writer.WriteLine("UserName: " + test + ". Login Time: " + DateTime.Now.ToString() + "<br />");
                
            }
        }
    }
}
