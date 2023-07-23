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

        [NotMapped]
        public string ImgURL_2x
        {
            get
            {
                // Ensure that item.ImgURL already has the correct image URL without the suffix
                // Determine the image format (JPEG or PNG) based on the original ImgURL
                string formatSuffix = ImgURL.EndsWith(".png") ? ".png" : ".jpg";

                // Append the 2x suffix to the existing ImgURL for JPEG and PNG images
                return $"{ImgURL}@2x{formatSuffix}";
            }
        }

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
