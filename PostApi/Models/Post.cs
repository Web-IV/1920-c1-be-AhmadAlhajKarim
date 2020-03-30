using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace RecipeApi.Models
{
    public class Post
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public int UserId { set; get; }
        [Required]
        public string Location { set; get; }
        [Required]
        public DateTime Created { get; set; }

        [Required]
        public string PictureUrl { get; set; }    

        public Post()
        {
            Created = DateTime.Now;
        }

        public Post(string title, string locationn, string url) : this()
        {
            Title = title;
            Location = locationn;
            PictureUrl = url;
        }
    }
}