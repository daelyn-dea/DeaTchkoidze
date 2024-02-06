using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompaniesManagmentApplication.Exceptions
{
    public class CompanyNotFoundException : Exception
    {
        public string Code = "CompanyNotFound";

        public CompanyNotFoundException(string message = "Company not found.") : base(message) { }
    }
}
