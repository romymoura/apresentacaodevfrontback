using Apresentacao.Domain.Entities;
using Apresentacao.Domain.Interfaces;
using Apresentacao.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;

namespace Apresentacao.Domain.Services
{
    public class UserApplicationService : BaseApplicationService<User>, IUserApplicationService
    {
        protected readonly IUserApplicationRepository UserRepository;
        public UserApplicationService(IUserApplicationRepository userRepository) : base(userRepository)
        {
            UserRepository = userRepository;
        }
               
        public User Login(string username, string password)
        {
            return UserRepository.Login(username, password);
        }
        public IEnumerable<User> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
