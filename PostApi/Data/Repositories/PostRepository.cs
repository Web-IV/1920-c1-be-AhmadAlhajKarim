using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PostApi.Models;
using RecipeApi.Models;

namespace PostApi.Data.Repositories
{
    public class PostRepository : IPostRepository
    {

            private readonly UserContext _context;
            private readonly DbSet<Post> _posts;

            public PostRepository(UserContext dbContext)
            {
                _context = dbContext;
                _posts = dbContext.Posts;
            }


            public IEnumerable<Post> GetAll()
            {
                return _posts.ToList();
            }

            public Post GetBy(int id)
            {
                return _posts.SingleOrDefault(u => u.Id == id);
            }

        public void SaveChanges()
            {
                _context.SaveChanges();
            }


            public void Update(Post post)
            {
                _context.Update(post);
                
            }

        public IEnumerable<Post> GetBy(string location = null)
        {
        var posts = _posts.AsQueryable();
            if (!string.IsNullOrEmpty(location))
                posts = posts.Where(r => r.Location.IndexOf(location) >= 0);
           
            return posts.OrderByDescending(r => r.Date).ToList();
        }
    }

   



}
