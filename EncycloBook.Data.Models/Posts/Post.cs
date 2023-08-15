using System;
using static Common.GeneralApplicationConstants.PostConstants;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EncycloBook.Data.Models.Posts
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
        [MinLength(DiscovererMinLength)]
        [MaxLength(DiscovererMaxLength)]
        public string DiscoveredBy { get; set; }
        [Required]
        public DateTime YearDiscovered { get; set; }

        [Required]
        [MinLength(TitleMinLength)]
        [MaxLength(TitleMaxLength)]
        public string Title { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "yyyy-MM-dd", ApplyFormatInEditMode = true)]
        public DateTime PublishedOn { get; set; }

        public string ImgURL { get; set; }



        [MinLength(DescriptionMinLength)]
        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; }

        [Required]
        [ForeignKey("Publisher")]
        public Guid PublisherId { get; set; }

        public ApplicationUser Publisher { get; set; }

        public virtual ICollection<Like> Likes { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
    }
}
