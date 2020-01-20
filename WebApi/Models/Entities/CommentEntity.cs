using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Models
{
    [Table("comments")]
    public class CommentEntity
    {
        [Key]
        public long Id { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }
    }
}