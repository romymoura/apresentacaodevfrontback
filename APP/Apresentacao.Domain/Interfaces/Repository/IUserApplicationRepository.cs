using Apresentacao.Domain.Entities;
using System.Collections.Generic;

namespace Apresentacao.Domain.Interfaces.Repository
{
    public interface IUserApplicationRepository : IBaseCrudApplicationRepository<User>
    {
        User Login(string username, string password);
        IEnumerable<User> GetAll();
    }
}
