    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    namespace EncycloData.Models
    {
        public class Bacteria : Post
        {
            public Bacteria()
            {
                this.Comments = new List<Comment>();
            }

            [Required]
            public bool IsDeadly { get; set; }
            [Required]
            [MinLength(3)]
            [MaxLength(20)]
            public string BacteriaFamily { get; set; } = null!;

 


        }
    }
