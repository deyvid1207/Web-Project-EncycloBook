﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncycloBook.Data.Models.Properties
{
    public class Food
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; } = null!;
    }
}
