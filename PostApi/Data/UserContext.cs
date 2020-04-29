
using System;
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
                .HasForeignKey("UserId");
        
            builder.Entity<User>().HasData(
                 new User { Id= 1, Name = "Ahmad", Password= "ahmad", Location = "Gent" },
                 new User {Id = 2, Name = "yaser",Password = "yaser", Location = "Brugge"},
                 new User { Id = 3, Name = "omar", Password = "omar", Location = "Brugge" },
                 new User { Id = 4, Name = "ammar", Password = "ammar", Location = "Brussel" }
  );

            builder.Entity<Post>().HasData(
                    //Shadow property can be used for the foreign key, in combination with anaonymous objects
                    new { Id = 1, Title = "Pos1", UserId = 1, Location = "Gent" , Date = DateTime.Today},
                    new { Id = 2, Title = "Post2", UserId = 1, Location = "Hasselt", Date = DateTime.Today.AddDays(-2) },
                    new { Id = 3, Title = "Pos3" , UserId = 1, Location = "Brugge", Date = DateTime.Now }
                 );
        }

        public DbSet<User> Users { get; set; }
    }

}
