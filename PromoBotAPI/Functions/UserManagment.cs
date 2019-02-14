
namespace PromoBotAPI.Functions
{
    using System;
    using System.IO;
    using System.Security.Principal;

    public class UserManagment
    {
        public void RecordUser()
        {
           //var test = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
            //  var test = this.User.Identity.Name;

            string username = WindowsIdentity.GetCurrent().Name;

            using (StreamWriter writer = new StreamWriter("log.txt", true))
            {
                writer.WriteLine("UserName: " + username + ". Login Time: " + DateTime.Now.ToString() + "<br />");

            }
        }

        public string ReadFile()
        {
            string line = string.Empty;
            FileStream fileStream = new FileStream("log.txt", FileMode.Open);
            using (StreamReader reader = new StreamReader(fileStream))
            {
                line = reader.ReadToEnd();
            }

            return line;
            
        }
    }
}
