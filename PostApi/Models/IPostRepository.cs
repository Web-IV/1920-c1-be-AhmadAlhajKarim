using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RecipeApi.Models;

namespace PostApi.Models
{
    public interface IPostRepository
    {
        Post GetBy(int id);
        IEnumerable<Post> GetAll();
        public IEnumerable<Post> GetBy(string location = null);
       
        void Update(Post post);
        void SaveChanges();
    }
}
