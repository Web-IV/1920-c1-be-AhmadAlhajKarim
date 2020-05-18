using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using PostApi.Data;
using PostApi.Models;

namespace RecipeApi.Data
{
    public class UserDataInitializer
    {
        private readonly UserContext _dbContext;
        private readonly UserManager<IdentityUser> _userManager;

        public UserDataInitializer(UserContext dbContext, UserManager<IdentityUser> userManager)
        {
            _dbContext = dbContext;
            _userManager = userManager;

        }

    public async Task InitializeDataAsync()
        {
            _dbContext.Database.EnsureDeleted();
            if (_dbContext.Database.EnsureCreated())
            {
                //seeding the database with recipes, see DBContext         
                User user = new User { Email = "recipemaster@hogent.be", FirstName = "Adam", LastName = "Master" };
                _dbContext.Users.Add(user);
                await CreateUser(user.Email, "P@ssword1111");
                User student = new User { Email = "student@hogent.be", FirstName = "Student", LastName = "Hogent" };
                _dbContext.Users.Add(student);
                await CreateUser(student.Email, "P@ssword1111");
                _dbContext.SaveChanges();
            }
        }
        private async Task CreateUser(string email, string password)
        {
            var user = new IdentityUser { UserName = email, Email = email };
            await _userManager.CreateAsync(user, password);
        }

    }
    
}

