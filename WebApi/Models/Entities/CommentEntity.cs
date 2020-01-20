using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApi.Models.Entities;

namespace WebApi.Models
{
    [Table("comments")]
    public class CommentEntity
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }
        [Column("content")]
        public string Content { get; set; }
        [Column("created_at", TypeName = "datetime")]
        public DateTime CreatedAt { get; set; }
        [ForeignKey("author_id")]
        public AuthorEntity Author { get; set; }
        [ForeignKey("post_id")]
        public PostEntity Post { get; set; }
    }
}