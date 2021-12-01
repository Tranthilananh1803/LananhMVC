using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace NetCoreDemo.Models
{
    public class DonHang : Person
    {
        
        [Display(Name = "Mã Đơn Hàng")]
        public string MaDonHang{ get; set; }
        [Display(Name = "Số")]
        public string DonHangnumber{ get; set; }
        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
        [Required]
        [StringLength(20)]
         [Display(Name = "Tên mặt hàng")]
        public string Tenhang {get; set;}
        [Display(Name = "Số điện thoại")]
        public string SoDienThoai{ get; set; }
        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
        [Required]
        [StringLength(30)]
        [Display(Name = "Địa chỉ")]
        public string DiaChi {get; set;}


    }
}