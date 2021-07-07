using System;
using System.Threading.Tasks;
using Domain.Interfaces;
using Domain.Models.Webeditor;

namespace Domain.Services.Webeditor
{
    public class DeleteUserService
    {
        private readonly IRepository<User> _userRepository;

        public DeleteUserService(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> Execute(int Id)
        {
            try
            {
                if (Id > 0)
                {
                    // Verifica se usuário existe
                    var currentUser = _userRepository.GetById(Id);

                    if (currentUser == null) {
                        throw new Exception("Usuário inválido.");
                    }

                    currentUser.DeletedAt = DateTime.Now;

                    _userRepository.Update(currentUser);
                    await _userRepository.SaveAsync();

                    return currentUser;
                }
                else
                {
                    throw new Exception("Dados inválido");
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
