using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using RecipeApi.Models;

namespace PostApi.Models
{
    public class User
    {
        public ICollection<Post> Posts { get; private set; }

        [Required]
        public int Id { get; set; }
        [Required]

        public string Location { set; get; }

        [Required]        
        public string Name { set; get; }
        [Required]
        public string Password { set; get; }

        public User()
        {
            Posts = new List<Post>();
        }

        public User(string name, string pass) : this()
        {
            Name = name;
            Password = pass;
        }

        public void AddPost(Post newPost) => Posts.Add(newPost);

        public Post GetPost(int id) => Posts.SingleOrDefault(i => i.Id == id);
    }
}
