using System;
using System.Linq;
using System.Threading.Tasks;
using Domain.Interfaces;
using Domain.Models.Webeditor;

namespace Domain.Services.Webeditor
{
    public class UpdateUserService
    {
        private readonly IRepository<User> _userRepository;
        private readonly IPasswordHasher _passwordHasher;

        public UpdateUserService(IRepository<User> userRepository, IPasswordHasher passwordHasher)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
        }

        public async Task<User> Execute(User data)
        {
            try
            {
                if (data.IsValid)
                {
                    // Verifica se e-mail já cadastrado
                    var userWithTheSameEmail = _userRepository.GetAll().Where(r => r.Email == data.Email).Where(r => r.Id != data.Id);
                    if (userWithTheSameEmail.Any()) 
                    {
                        throw new Exception("E-mail já cadastrado no sistema.");
                    }

                    // Verifica se usuário existe
                    var currentUser = _userRepository.GetById(data.Id);

                    if (currentUser == null) {
                        throw new Exception("Usuário inválido.");
                    }

                    if (currentUser.CompanyId != data.CompanyId) {
                        throw new Exception("Usuário inválido.");
                    }


                    if (!string.IsNullOrEmpty(data.Password))
                    {
                        data.setPassword(_passwordHasher.Hash(data.Password));
                    }

                    currentUser.Update(data);

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
