using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PostApi.Models;
using RecipeApi.Models;

namespace PostApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {

        private readonly IUserRepository _userRepository;
        private readonly IEnumerable<Post> _posts;
        public PostsController(IUserRepository context)
        {
            _userRepository = context;
            _posts = _userRepository.GetAll().SelectMany(user => user.Posts).ToList();
        }

        // GET: api/posts
        /// <summary>
        /// Get all posts ordered by date
        /// </summary>
        /// <returns>array of post</returns>
        [HttpGet]
        public IEnumerable<Post> GetPosts()
        {
            return _posts.OrderBy(post => post.Date);
        }



    }
}