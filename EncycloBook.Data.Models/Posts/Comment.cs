using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Common.GeneralApplicationConstants.PostConstants;

namespace EncycloBook.Data.Models.Posts
{
    public class Comment
    {
        [Required]
        [ForeignKey("Publisher")]
        public Guid PublisherId { get; set; }
        [Required]
        public ApplicationUser Publisher { get; set; } = null!;


        [Key]
        public int Id { get; set; }
        [Required]
        [MinLength(CommentContentMinLength)]
        [MaxLength(CommentContentMaxLength)]
        public string Content { get; set; }
        [Required]
        [DisplayFormat(DataFormatString = "yyyy-MM-dd", ApplyFormatInEditMode = true)]
        public DateTime PublishedOn { get; set; }
    }
}
