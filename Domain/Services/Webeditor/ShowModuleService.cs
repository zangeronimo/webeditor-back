using System.Collections.Generic;
using Domain.Interfaces;
using Domain.Models.Webeditor;

namespace Domain.Services.Webeditor
{
    public class ShowModuleService
    {
        private readonly IRepository<Module> _moduleRepository;

        public ShowModuleService(IRepository<Module> moduleRepository)
        {
            _moduleRepository = moduleRepository;
        }

        public IEnumerable<Module> Execute(string filter)
        {
            return _moduleRepository.GetAll();
        }
    }
}
