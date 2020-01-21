using System.Collections.Generic;
using System.Net.Mime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Config;
using WebApi.Models.Entities;

namespace WebApi.Controllers.v1
{
    [ApiController]
    [Route("api/v1/posts")]
    public class PostController
    {
        private readonly DatabaseContext _db;
        private PostEntity post;

        public PostController(DatabaseContext context)
        {
            _db = context;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Produces(MediaTypeNames.Application.Json, MediaTypeNames.Application.Xml)]
        public async Task<IEnumerable<PostEntity>> GetAll()
        {
            return await _db.Posts
                .Include(x => x.Author)
                .Include(y => y.Comments)
                .ToListAsync();
        }
        
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [Consumes(MediaTypeNames.Application.Json, MediaTypeNames.Application.Xml)]
        [Produces(MediaTypeNames.Application.Json, MediaTypeNames.Application.Xml)]
        public void Create(PostEntity postEntity)
        {
            _db.Posts.Add(postEntity);
            _db.SaveChanges();
        }
        
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Produces(MediaTypeNames.Application.Json, MediaTypeNames.Application.Xml)]
        public async Task<PostEntity> Get(long id)
        {
            return await _db.Posts
                .Include(x => x.Author)
                .Include(x => x.Comments)
                .SingleOrDefaultAsync(u => u.Id == id);
        }
        
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Consumes(MediaTypeNames.Application.Json, MediaTypeNames.Application.Xml)]
        [Produces(MediaTypeNames.Application.Json, MediaTypeNames.Application.Xml)]
        public async Task<PostEntity> Update(long id, PostEntity postEntity)
        {
            postEntity.Id = id;
            _db.Posts.Update(postEntity);
            _db.SaveChanges();
            return postEntity;
        }
        
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Consumes(MediaTypeNames.Application.Json, MediaTypeNames.Application.Xml)]
        [Produces(MediaTypeNames.Application.Json, MediaTypeNames.Application.Xml)]
        public void Delete(long id)
        {
            post = _db.Posts.Find(id);
            _db.Posts.Remove(post);
        }
    }
}