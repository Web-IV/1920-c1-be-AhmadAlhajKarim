using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace RecipeApi.Models
{
    public class Post
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]

        public int UserId { set; get; }
        [Required]
        public string Location { set; get; }
        [Required]

        public string Picture { set; get; }
        [Required]
        public DateTime Date { get; set; }

        public Post()
        {
        }

        public Post(string title, string locationn, string picture, DateTime date) : this()
        {
            Title = title;
            Location = locationn;
            Picture = picture;
            Date = date;
        }
    }
}