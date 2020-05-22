using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PostApi.Data.Repositories;
using PostApi.Models;
using RecipeApi.Models;

namespace PostApi.Controllers
{
    [ApiConventionType(typeof(DefaultApiConventions))]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    public class PostsController : ControllerBase
    {

        private readonly IPostRepository _postRepo;
        private readonly IEnumerable<Post> _posts;
        public PostsController(IPostRepository postRepository)
        {
            _postRepo = postRepository;
/*            _posts = postRepository.GetAll();
*/        }

        // GET: api/posts
        /// <summary>
        /// Get all posts ordered by date
        /// </summary>
        /// <returns>array of post</returns>
        [HttpGet]
        public IEnumerable<Post> GetPosts(string location = null)
        {
            if (string.IsNullOrEmpty(location) )
                return _postRepo.GetAll().OrderByDescending(post => post.Date);

            return _postRepo.GetBy(location);
        }


        // PUT: api/posts/5
        /// <summary>
        /// Modifies a post
        /// </summary>
        /// <param name="id">id of the post to be modified</param>
        /// <param name="post">the modified post</param>
        [HttpPost("{id}")]
        public IActionResult PutPost(int id)
        {
            
            Post post = this.GetPosts().Where(p => p.Id == id).FirstOrDefault();
            if (post == null)
            {
                return BadRequest();
            }
            else
            {
                post.Reserved = true;
                _postRepo.Update(post);
                _postRepo.SaveChanges();
                return NoContent();
            }
               
        }


        // GET: api/Posts/2
        /// <summary>
        /// Get the post with given id
        /// </summary>
        /// <param name="id">the id of the post</param>
        /// <returns>The post</returns>
        [HttpGet("{id}")]
        public ActionResult<Post> GetPost(int id)
        {
            Post post= _postRepo.GetBy(id);
            if (post == null) return NotFound();
            return post;
        }



    }
}