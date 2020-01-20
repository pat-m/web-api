using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.v1
{
    [ApiController]
    [Route("api/v1/comments")]
    public class CommentController : ApiController
    {
        
        [HttpGet]
        public string GetComments()
        {
            return"ok";
        }
        
        [HttpPost]
        public string Create()
        {
            return "create";
        }
        
        [HttpGet("{id}")]
        public string GetComment(long id)
        {
            return "get";
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