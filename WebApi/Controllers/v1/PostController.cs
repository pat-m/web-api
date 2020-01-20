using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApi.Config;
using WebApi.Models.Entities;

namespace WebApi.Controllers.v1
{
    [ApiController]
    [Route("api/v1/posts")]
    public class PostController
    {
        private DatabaseContext db;

        public PostController(DatabaseContext context)
        {
            db = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PostEntity>>> GetAll()
        {
            return db.Posts.ToList();
        }
        
        [HttpPost]
        public string Create()
        {
            db.Posts.Add(new PostEntity());
            return "create";
        }
        
        [HttpGet("{id}")]
        public string Get(long id)
        {
            return "ok";
        }
        
        [HttpPut("{id}")]
        public string Update(long id)
        {
            return "update";
        }
        
        [HttpDelete("{id}")]
        public string Delete(long id)
        {
            return "delete";
        }
    }
}