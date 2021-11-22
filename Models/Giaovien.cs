using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace NetCoreDemo.Models
{
    [Table("Giaoviens")]
    public class Giaovien
    {
        [Key]
        [Display(Name = "Mã giáo viên")]

        public string GiaovienID { get; set; }
        [Display(Name = "Tên giáo viên")]
        public string Tengiaovien {get; set;}
         public ICollection <LopHoc> LopHocs { get; set; }
        

    }
}