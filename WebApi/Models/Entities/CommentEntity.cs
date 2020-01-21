using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace WebApi.Models.Entities
{
    [Table("comments")]
    public class CommentEntity
    {
        public CommentEntity()
        {
        }

        [Key]
        [Column("id")]
        public long Id { get; set; }
        
        [Column("content")]
        public string Content { get; set; }
        
        [ForeignKey("author_id")]
        public AuthorEntity Author { get; set; }
        
        [JsonIgnore]
        [ForeignKey("post_id")]
        public PostEntity Post { get; set; }
    }
    
    
}