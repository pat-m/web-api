using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Models.Entities
{
    [Table("posts")]
    public class PostEntity
    {
        [Key]
        public long Id { get; set; }
        public string Content { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
    }
}