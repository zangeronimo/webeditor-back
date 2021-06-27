using System.Collections.Generic;
using Domain.Interfaces;
using Domain.Models.Webeditor;

namespace Domain.Services.Webeditor
{
    public class ShowCompanyService
    {
        private readonly IRepository<Company> _companyRepository;

        public ShowCompanyService(IRepository<Company> companyRepository)
        {
            _companyRepository = companyRepository;
        }

        public IEnumerable<Company> Execute(string filter)
        {
            return _companyRepository.GetAll();
        }
    }
}
