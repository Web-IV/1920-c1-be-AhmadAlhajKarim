using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

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
        public string PictureUrl { get; set; }
        [Required]
        public DateTime Date { get; set; }

        public Post()
        {
        }

        public Post(string title, string locationn, string url, DateTime date) : this()
        {
            Title = title;
            Location = locationn;
            PictureUrl = url;
            Date = date;
        }
    }
}