using CompaniesManagmentApplication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CompaniesManagment.Controllers
{
    [Route("api/[controller]")]//როუთისთვის, გაიპარსება ურლ და ამ კონტროლერთან მოვა
    [ApiController]//ეიპიაის კონტროლერივით რომ მოიქცეს
    public class CompanyController : ControllerBase
    {
        private ICompanyService CompanyService { get; set; }

        public CompanyController()
        {
            CompanyService = new CompanyService();
        }

        [HttpGet]
        public List<Company> Get() => CompanyService.GetCompanies();

        [HttpGet("{id}")]
        public Company Get(int id) => CompanyService.GetCompanyById(id);

        [HttpDelete("{id}")]
        public bool Delete(int id) => CompanyService.Delete(id);

        [HttpPost]
        public bool AddCompany() => CompanyService.AddCompany();
    }
}
