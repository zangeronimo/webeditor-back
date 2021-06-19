using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    public class BaseEntity
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("created_at")]
        public DateTime? CreatedAt { get; set; }

        [Column("updated_at")]

        public DateTime? UpdatedAt { get; set; }
        
        [Column("deleted_at")]
        
        public DateTime? DeletedAt { get; set; }
    }
}