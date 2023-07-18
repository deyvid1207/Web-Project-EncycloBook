using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncycloData.Models
{
    public class Like
    {

        [Key]
        public int Id { get; set; }
        [Required]
        [MinLength(1)]
        [MaxLength(50)]

        [ForeignKey("Post")]
        public int PostId { get; set; }
        [ForeignKey("User")]
        public Guid UserId { get; set; }
        public DateTime LikedOn { get; set; }

        // Navigation properties
        public virtual Post Post { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}
