using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncycloBookData.Models
{
    public class Comment
    {
        [Required]
        [ForeignKey("Publisher")]
        public string PublisherId { get; set; }
        [Required]
        public PostUser Publisher { get; set; } = null!;


        [Key]
        public int Id { get; set; }
        [Required]
        [MinLength(1)]
        [MaxLength(50)]
        public string Content { get; set; }
        [Required]
        [DisplayFormat(DataFormatString = "yyyy-MM-dd", ApplyFormatInEditMode = true)]
        public DateTime PublishedOn { get; set; }
    }
}
