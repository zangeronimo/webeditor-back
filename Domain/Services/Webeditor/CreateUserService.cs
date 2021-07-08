using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Interfaces;
using Domain.Models.Webeditor;

namespace Domain.Services.Webeditor
{
    public class CreateUserService
    {
        private readonly IRepository<User> _userRepository;
        private readonly IPasswordHasher _passwordHasher;

        public CreateUserService(IRepository<User> userRepository, IPasswordHasher passwordHasher)
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
                    var userWithTheSameEmail = _userRepository.GetAll().Where(r => r.Email == data.Email);
                    if (userWithTheSameEmail.Any()) 
                    {
                        throw new Exception("E-mail já cadastrado no sistema.");
                    }

                    var now = DateTime.Now;
                    data.CreatedAt = now;
                    data.UpdatedAt = now;

                    data.setPassword(_passwordHasher.Hash(data.Password));

                    _userRepository.Add (data);
                    await _userRepository.SaveAsync();

                    return data;
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
