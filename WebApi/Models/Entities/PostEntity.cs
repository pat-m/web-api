using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace WebApi.Models.Entities
{
    [Table("posts")]
    public class PostEntity
    {
        public PostEntity()
        {
            Comments = new List<CommentEntity>();
        }

        [Key]
        [Column("id")]
        public long Id { get; set; }
        
        [Column("title")]
        public string Title { get; set; }
        
        [Column("content", Order = 2)]
        public string Content { get; set; }
        
        [ForeignKey("author_id")]
        public AuthorEntity Author { get; set; }
        
        public ICollection<CommentEntity> Comments { get; set; }

        
    }
}