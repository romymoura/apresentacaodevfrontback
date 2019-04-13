using Apresentacao.Domain.Entities;
using Apresentacao.Domain.Interfaces.Repository;
using System.Collections.Generic;
using System.Linq;

namespace Apresentacao.Data.EntityObjectsRepositorys
{
    public class UserApplicationRepository : BaseCrudApplicationRepository<User>, IUserApplicationRepository
    {
        public UserApplicationRepository(ApplicationDbContext context) : base(context)
        {
        }

        public User Login(string username, string password)
        {
            return Context.Users.Where(user =>
            (user.Username.Equals(username) ||
            user.Email.Equals(username))
            && user.Password.Equals(password)).FirstOrDefault();
        }
        public IEnumerable<User> GetAll()
        {
            return null;
        }
    }
}
