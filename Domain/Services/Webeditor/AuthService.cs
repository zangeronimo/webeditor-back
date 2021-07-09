using System;
using System.Linq;
using Domain.Interfaces;
using Domain.Models.Webeditor;
using Domain.View;
using Domain.View.Webeditor;

namespace Domain.Services.Webeditor
{
    public class AuthService
    { 
        private readonly IRepository<User> _userRepository;
        private readonly IPasswordHasher _passwordHasher;
        private readonly ITokenProvider _tokenProvider;

        public AuthService(IRepository<User> userRepository, IPasswordHasher passwordHasher, ITokenProvider tokenProvider)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
            _tokenProvider = tokenProvider;
        }

        public AuthView Execute(Auth model, string Secret)
        {
            try 
            {
                var userQuery = _userRepository.GetAll();
                User user = userQuery
                .Where(x => x.Email.ToLower().Contains(model.Email)).First();

                if (user is null) {
                    throw new Exception("Dados inválido");  
                }
                var (verified, _) = (_passwordHasher.Check(user.Password, model.Password));

                if (!verified) {
                    throw new Exception("Login inválido");
                }
                
                var token = _tokenProvider.GenerateToken(user, Secret);

                return new AuthView() { user = new UserView(user), token = token};
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        
    }
}