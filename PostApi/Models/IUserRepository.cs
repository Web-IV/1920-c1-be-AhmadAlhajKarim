using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RecipeApi.Models;

namespace PostApi.Models
{
    public interface IUserRepository
    {
        User GetBy(int id);
        bool TryGetUser(int id, out User user);
        IEnumerable<User> GetAll();
        User GetBy(string name = null);
        void Add(User user);
        void Delete(User user);
        void Update(User user);
        void SaveChanges();
    }
}
