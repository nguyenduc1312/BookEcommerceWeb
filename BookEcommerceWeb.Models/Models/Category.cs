﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookEcommerceWeb.Models.Models
{
    public class Category : BaseModel
    {
        [Required]
        public string Name { get; set; }
        public int DisplayOrder { get; set; }
    }
}
