using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace NetCoreDemo.Models
{
    public class DonhangDiachi
    {
        public List<DonHang> DonHang { get; set; }
        public SelectList Diachis { get; set; }
        public string DonhangDC { get; set; }
        public string SearchString { get; set; }
    }
}