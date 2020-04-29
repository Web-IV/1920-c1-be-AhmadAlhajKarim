using System;
using System.Linq;
using PostApi.Data;

namespace RecipeApi.Data
{
    public class UserDataInitializer
    {
        private readonly UserContext _dbContext;

        public UserDataInitializer(UserContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void InitializeData()
        {
            _dbContext.Database.EnsureDeleted();
            if (_dbContext.Database.EnsureCreated())
            {
                //seeding the database with recipes, see DBContext      

            }
        }

             }
}

