using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApi.Config;

namespace WebApi.Repositories
{
    public class Repository<T>:IRepository<T> where T : class
    {
        private DatabaseContext _context;

        public Repository(DatabaseContext db)
        {
            
        }

        public Task<List<T1>> FindAll<T1>() where T1 : class
        {
            throw new System.NotImplementedException();
        }

        public Task<T1> FindById<T1>(long id) where T1 : class
        {
            throw new System.NotImplementedException();
        }

        public Task CreateAsync<T1>(T1 entity) where T1 : class
        {
            throw new System.NotImplementedException();
        }

        public Task UpdateAsync<T1>(T1 entity) where T1 : class
        {
            throw new System.NotImplementedException();
        }

        public Task DeleteAsync<T1>(T1 entity) where T1 : class
        {
            throw new System.NotImplementedException();
        }
    }
}