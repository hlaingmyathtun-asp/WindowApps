using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace CarRentalApp
{
    internal class Utility
    {
       
        public static bool IsOpenForm(string formName)
        {
            var openForms = Application.OpenForms.Cast<Form>();
            var IsOpen = openForms.Any(q => q.Name == formName);
            return IsOpen;
        }


        public static string HashPassword(string password)
        {
            SHA256 sHA256 = SHA256.Create();
            var data = sHA256.ComputeHash(UTF8Encoding.UTF8.GetBytes(password));

            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                stringBuilder.Append(data[i].ToString());
            }

            return stringBuilder.ToString();
        }
        public static string DefaultHashPassword()
        {
            SHA256 sHA256 = SHA256.Create();
            var data = sHA256.ComputeHash(UTF8Encoding.UTF8.GetBytes("Password@123"));

            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                stringBuilder.Append(data[i].ToString());
            }

            return stringBuilder.ToString();
        }


    }
}
