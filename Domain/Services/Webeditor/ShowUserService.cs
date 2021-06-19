using System.Collections.Generic;
using Domain.Interfaces;
using Domain.Models.Webeditor;

namespace Domain.Services.Webeditor
{
    public class ShowUserService
    {
        private readonly IRepository<User> _userRepository;

        public ShowUserService(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public IEnumerable<User> Execute(string filter)
        {
            return _userRepository.GetAll();
        }
    }
}