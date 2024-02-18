using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompaniesManagmentApplication
{
    public interface ICompanyService
    {
        public List<Company> GetCompanies();
        public Company GetCompanyById(int id);
        public bool Delete(int id);
        public bool AddCompany();
    }
}
