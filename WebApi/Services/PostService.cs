using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApi.Config;
using WebApi.Models.Entities;

namespace WebApi.Services
{
    public class PostService
    {
        private DatabaseContext _db;
        
        public PostService(DatabaseContext db)
        {
            _db = db;
        }

        public Task<List<PostEntity>> GetAll()
        {
            return _db.Posts.ToListAsync();
        }

        public PostEntity Get(long Id)
        {
            throw new System.NotImplementedException();
        }

        public void Create(PostEntity author)
        {
            throw new System.NotImplementedException();
        }

        public void Update(PostEntity post)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(long Id)
        {
            throw new System.NotImplementedException();
        }
    }
}