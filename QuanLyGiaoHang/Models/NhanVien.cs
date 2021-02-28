using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLyGiaoHang.Models
{
    public class NhanVien
    {
        public string MANHANVIEN { get; set; }
        public string HO { get; set; }
        public string TEN { get; set; }
        public DateTime NGAYSINH { get; set; }
        public DateTime NGAYLAMVIEC { get; set; }
        public string DIACHI { get; set; }
        public string DIENTHOAI { get; set; }
        public decimal LUONGCOBAN { get; set; }
        public decimal PHUCAP { get; set; }

    }
}
