﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EncycloBook.Data.Models.Posts;

namespace EncycloBook.Data.Models.Posts
{
    public class Plant : Post
    {
      
        public string Location { get; set; } = null!;

        [Required]
        public string Color { get; set; } = null!;
    
        [Required]
        [MinLength(3)]
        [MaxLength(50)]
        public string PlantClass { get; set; } = null!;

        [Required]
        public string LeaveType { get; set; } = null!;


        [Required]
        public string RootType { get; set; } = null!;
        [Required]
        public string StemType { get; set; } = null!;

    }
}
