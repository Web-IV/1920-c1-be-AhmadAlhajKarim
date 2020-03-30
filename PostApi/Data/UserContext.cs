﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PostApi.Models;

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
/*            builder.Entity<Recipe>().HasData(
                 new Recipe { Id = 1, Name = "Spaghetti", Created = DateTime.Now, Chef = "Piet" },
                 new Recipe { Id = 2, Name = "Tomato soup", Created = DateTime.Now }
  );*/

/*            builder.Entity<Ingredient>().HasData(
                    //Shadow property can be used for the foreign key, in combination with anaonymous objects
                    new { Id = 1, Name = "Tomatoes", Amount = (double?)0.75, Unit = "liter", RecipeId = 1 },
                    new { Id = 2, Name = "Minced Meat", Amount = (double?)500, Unit = "grams", RecipeId = 1 },
                    new { Id = 3, Name = "Onion", Amount = (double?)2, RecipeId = 1 }
                 );*/
        }

        public DbSet<User> Users { get; set; }
    }

}
