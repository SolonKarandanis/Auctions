using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Auctions.Models
{
    public class Listing:IModelIdentifier
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(200)]
        [Column(TypeName ="varchar(200)")]
        public string Title { get; set; }

        [MaxLength(1000)]
        [Column(TypeName ="varchar(1000)")]
        public string Description { get; set; }
        public double Price { get; set; }

        [MaxLength(200)]
        [Column(TypeName ="varchar(200)")]
        public string ImagePath { get; set; }
        public bool IsSold { get; set; } = false;

        [Required]
        public string? IdentityUserId { get; set; }
        [ForeignKey("IdentityUserId")]
        public IdentityUser? User { get; set; }

        public List<Bid>? Bids { get; set; }
        public List<Comment>? Comments { get; set; }
    }
}