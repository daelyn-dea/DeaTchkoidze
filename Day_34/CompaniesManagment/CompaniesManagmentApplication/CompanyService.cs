using CompaniesManagmentApplication.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompaniesManagmentApplication
{
    public class CompanyService : ICompanyService
    {
        private List<Company> Companies { get; set; } = new List<Company>();

        public CompanyService()
        {
            Companies = new()
            {
                new Company(1, "TBC"),
                new Company(2, "BOG")
            };
        }

        public List<Company> GetCompanies() => Companies;

        public Company GetCompanyById(int id)
        {
            Company company = Companies.SingleOrDefault(x => x.CompanyID == id);    
           if(company == null)
            {
                throw new CompanyNotFoundException();
            }
           return company;
        }

        public bool Delete(int id) => Companies.Remove(GetCompanyById(id));

        public bool AddCompany()
        {
            throw new MethodIsNotAllowedException();
        }
    }
}
