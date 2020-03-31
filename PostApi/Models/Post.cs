using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace RecipeApi.Models
{
    public class Post
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public int UserId { set; get; }
        public string Location { set; get; }

        public string PictureUrl { get; set; }    

        public Post()
        {
        }

        public Post(string title, string locationn, string url) : this()
        {
            Title = title;
            Location = locationn;
            PictureUrl = url;
        }
    }
}