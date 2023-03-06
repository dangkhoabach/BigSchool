using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BachThaiDangKhoa_2011060468.Models
{
    public class Category
    {
            public byte Id { get; set; }
            [Required]
            [StringLength(255)]
            public string Name { get; set; }
    }
}