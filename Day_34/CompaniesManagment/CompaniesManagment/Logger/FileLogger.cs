using CompaniesManagment.Infrastructure;
using System.Diagnostics;

namespace CompaniesManagment.Logger
{
    public class FileLogger
    {
        public static void Log(Error error)
        {
            using (StreamWriter st = new StreamWriter("Logs.txt", true))
            {
                st.WriteLine(error.ToString());
            }
        }
    }
}
