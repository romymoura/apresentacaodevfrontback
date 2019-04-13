using Apresentacao.Domain.Entities;
using System.Collections.Generic;

namespace Apresentacao.Domain.Interfaces
{
    public interface IUserApplicationService : IBaseApplicationService<User>
    {
        User Login(string username, string password);
        IEnumerable<User> GetAll();
    }
}
