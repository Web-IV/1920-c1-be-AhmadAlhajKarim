using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PostApi.Models;
using RecipeApi.Models;

namespace PostApi.Data.Repositories
{
    public class UserRepository : IUserRepository
    {

        private readonly UserContext _context;
        private readonly DbSet<User> _users;

        public UserRepository(UserContext dbContext)
        {
            _context = dbContext;
            _users = dbContext.Users;
        }

        public void Add(User user)
        {
            throw new NotImplementedException();
        }

        public void Delete(User user)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public User GetBy(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetBy(string name = null)
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }

        public bool TryGetUser(int id, out User user)
        {
            throw new NotImplementedException();
        }

        public void Update(User user)
        {
            throw new NotImplementedException();
        }
    }
}
