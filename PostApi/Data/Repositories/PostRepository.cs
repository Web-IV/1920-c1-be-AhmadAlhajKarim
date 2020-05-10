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

        public Post GetBy(string name = null)
        {
            return _posts.SingleOrDefault(u => u.Title  == name);
        }

        public void SaveChanges()
            {
                _context.SaveChanges();
            }


            public void Update(Post post)
            {
                _context.Update(post);
                
            }
        }
    


}
