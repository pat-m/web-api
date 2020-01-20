using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Models.Entities
{
    [Table("posts")]
    public class PostEntity
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }
        
        [Column("title")]
        public string Title { get; set; }
        
        [Column("content", Order = 2)]
        public string Content { get; set; }
        
        [Column("created_at", TypeName = "datetime")]
        public DateTime CreatedAt { get; set; }
        
        [ForeignKey("author_id")]
        public AuthorEntity Author { get; set; }
        public ICollection<CommentEntity> Comments { get; set; }
    }
}