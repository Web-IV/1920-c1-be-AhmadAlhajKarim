using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PostApi.Models;
using RecipeApi.Models;

namespace PostApi.Data
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<User>()
                .HasMany(u => u.Posts)
                .WithOne()
                .IsRequired()
                .HasForeignKey("UserId"); //Shadow property
                                          /*           builder.Entity<Recipe>().Property(r => r.Name).IsRequired().HasMaxLength(50);
                                                     builder.Entity<Recipe>().Property(r => r.Chef).HasMaxLength(50);
                                                     builder.Entity<Ingredient>().Property(r => r.Name).IsRequired().HasMaxLength(50);
                                                     builder.Entity<Ingredient>().Property(r => r.Unit).HasMaxLength(10);*/

            //Another way to seed the database
            builder.Entity<User>().HasData(
                 new User { Id = 1, Name = "Ahmad", Password= "ahmad", Location = "Gent" },
                 new User { Id = 2, Name = "Test",Password = "test", Location = "Brugge"}
  );

            builder.Entity<Post>().HasData(
                    //Shadow property can be used for the foreign key, in combination with anaonymous objects
                    new { Id = 1, Title= "Pos1", UserId = 1, Location = "Gent" },
                    new { Id = 2, Name = "Post2", UserId = 1, Location = "Hasselt" },
                    new { Id = 3, Name = "Pos3" , UserId = 1, Location = "Brugge" }
                 );
        }

        public DbSet<User> Users { get; set; }
    }

}
