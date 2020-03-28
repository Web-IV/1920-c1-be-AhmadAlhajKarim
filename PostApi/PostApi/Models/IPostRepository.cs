using System.Collections.Generic;

namespace RecipeApi.Models
{
    public interface IPostRepository
    {
            Post GetBy(int id);
            bool TryGetPost(int id, out Post post);
            IEnumerable<Post> GetAll();
             IEnumerable<Post> GetBy(string name = null, string pictureUrl = null, string title = null);
            void Add(Post post);
            void Delete(Post post);
            void Update(Post post);
            void SaveChanges();
        }
    }

