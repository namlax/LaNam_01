using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NamLa.Models
{
    public class SanPham
    {
        [Key]
        public int MaNhaCungCap { get; set; }
        [StringLength(maximumLength: 20, ErrorMessage = "Tối đa 20 kí tự")]
        public string MaSanPham { get; set; }
        [StringLength(maximumLength: 50, ErrorMessage = "Tối đa 50 kí tự")]
        public string TenSanPham { get; set; }

    }
}