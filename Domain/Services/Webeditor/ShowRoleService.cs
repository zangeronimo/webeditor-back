using System.Collections.Generic;
using Domain.Interfaces;
using Domain.Models.Webeditor;

namespace Domain.Services.Webeditor
{
    public class ShowRoleService
    {
        private readonly IRepository<Role> _roleRepository;

        public ShowRoleService(IRepository<Role> roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public IEnumerable<Role> Execute(string filter)
        {
            return _roleRepository.GetAll();
        }
    }
}
