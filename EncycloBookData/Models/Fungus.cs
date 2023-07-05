using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace EncycloBookData.Models
{
    public class Fungus
    {
        public Fungus()
        {
            this.Comments = new List<Comment>();
        }
        [Key]
        public int Id { get; set; }
        [Required]
        [MinLength(3)]
        [MaxLength(20)]

        public string Name { get; set; } = null!;
        [Required]
        [MinLength(3)]
        [MaxLength(20)]
        public string Location { get; set; } = null!;

        [Required]
        public string Color { get; set; } = null!;

        [Required]
        public string GillsType { get; set; } = null!;
        public bool IsPoisonous { get; set; }
        public int Likes { get; set; } = 0;
        [Required]
        [MinLength(3)]
        [MaxLength(20)]
        public string FungusClass { get; set; } = null!;

        [Required]
        public string ImgURL { get; set; } = null!;
        [Required]
        [DisplayFormat(DataFormatString = "yyyy-MM-dd", ApplyFormatInEditMode = true)]
        public DateTime PublishedOn { get; set; }
        [MinLength(15)]
        [MaxLength(150)]
        public string Description { get; set; } = null!;

        [Required]
        [ForeignKey("Publisher")]
        public string PublisherId { get; set; }
        [Required]
        public IdentityUser Publisher { get; set; } = null!;


        public ICollection<Comment> Comments { get; set; }
    }
}
