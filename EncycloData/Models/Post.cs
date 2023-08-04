using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EncycloData.Models
{
    public abstract class Post
    {
        public Post()
        {
            Comments = new List<Comment>();
            Likes = new List<Like>();
            YearDiscovered = DateTime.Now;
        }

        public int Id { get; set; }
        [Required]
        [MinLength(3)]
        [MaxLength(75)]
        public string DiscoveredBy { get; set; }
        [Required]
        public DateTime YearDiscovered { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(50)]
        public string Title { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "yyyy-MM-dd", ApplyFormatInEditMode = true)]
        public DateTime PublishedOn { get; set; }

        public string ImgURL { get; set; }
 

        [MinLength(15)]
        [MaxLength(750)]
        public string Description { get; set; }

        [Required]
        [ForeignKey("Publisher")]
        public Guid PublisherId { get; set; }

        public ApplicationUser Publisher { get; set; }

        public virtual ICollection<Like> Likes { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
    }
}
