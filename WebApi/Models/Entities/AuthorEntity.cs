using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Models.Entities
{
    [Table("authors")]
    public class AuthorEntity
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }
        
        [Column("firstname")]
        public string Firstname { get; set; }
        
        [Column("lastname")]
        public string Lastname { get; set; }
        
        [Column("created_at", TypeName = "datetime")]
        public DateTime CreatedAt { get; set; }
    }
}