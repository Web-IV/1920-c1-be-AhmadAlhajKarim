using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PostApi.Models;

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
            _context.Add(user);
        }

        public void Delete(User user)
        {
            _context.Remove(user);
        }

        public IEnumerable<User> GetAll()
        {
            return _users.Include(u => u.Posts).ToList();
        }

        public User GetBy(int id)
        {          
            return _users.Include(u => u.Posts).SingleOrDefault(u => u.Id == id);
        }

        public User GetBy(string name = null)
        {
            return _users.Include(u => u.Posts).SingleOrDefault(u => u.Name.Contains(name));
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public bool TryGetUser(int id, out User user)
        {
            user = _context.Users.Include(u => u.Posts).FirstOrDefault(u => u.Id == id);
            return user != null;
        }

        public void Update(User user)
        {
            _context.Update(user);
        }
    }
}
