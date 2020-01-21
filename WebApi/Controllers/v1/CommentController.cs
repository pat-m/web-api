using System.Collections.Generic;
using System.Linq;
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
    [Route("api/v1/comments")]
    public class CommentController : ApiController
    {
        private readonly DatabaseContext _db;

        public CommentController(DatabaseContext context)
        {
            _db = context;
        }
        
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Produces(MediaTypeNames.Application.Json, MediaTypeNames.Application.Xml)]
        public async Task<IEnumerable<CommentEntity>> Get()
        {
            return await _db.Comments
                .Include(x => x.Author)
                .ToListAsync();
        }
        
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [Consumes(MediaTypeNames.Application.Json, MediaTypeNames.Application.Xml)]
        [Produces(MediaTypeNames.Application.Json, MediaTypeNames.Application.Xml)]
        public void Create(CommentEntity commentEntity)
        {
            _db.Comments.Add(commentEntity);
            _db.SaveChanges();
        }
        
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Produces(MediaTypeNames.Application.Json, MediaTypeNames.Application.Xml)]
        public async Task<CommentEntity> Get(long id)
        {
            return await _db.Comments
                .Include(x => x.Author)
                .SingleOrDefaultAsync(u => u.Id == id);
        }
        
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Consumes(MediaTypeNames.Application.Json, MediaTypeNames.Application.Xml)]
        [Produces(MediaTypeNames.Application.Json, MediaTypeNames.Application.Xml)]
        public async Task<CommentEntity> UpdateComment(long id, CommentEntity commentEntity)
        {
            commentEntity.Id = id;
            _db.Comments.Update(commentEntity);
            _db.SaveChanges();
            CommentEntity comment = _db.Comments.Include(x => x.Author).SingleOrDefault(x => x.Id == id);
            return comment;
        }
        
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Consumes(MediaTypeNames.Application.Json, MediaTypeNames.Application.Xml)]
        [Produces(MediaTypeNames.Application.Json, MediaTypeNames.Application.Xml)]
        public void DeleteComment(long id)
        {
            CommentEntity comment = _db.Comments.Find(id);
            if (comment == null) return;
            _db.Comments.Remove(comment);
            _db.SaveChanges();
        }
    }
}