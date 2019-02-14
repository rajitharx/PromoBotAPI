
namespace PromoBotAPI.Functions
{
    using System;
    using System.IO;

    public class UserManagment
    {
        public void RecordUser()
        {
            var test = System.Security.Principal.WindowsIdentity.GetCurrent().Name;

            using (StreamWriter writer = new StreamWriter("log.txt", true))
            {
                writer.WriteLine("UserName: " + test + ". Login Time: " + DateTime.Now.ToString() + "<br />");

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
