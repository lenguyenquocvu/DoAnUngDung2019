using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project_CSharp_QuanLySinhVien
{
    class clsSinhVien
    {
        private String maSV;
        private String hoTenSV;
        private int gioiTinh;
        private String noiSinh;
        private DateTime ngaySinh;
        private String maLop;

        public clsSinhVien()
        {

        }

        public clsSinhVien(String maSV, String tenSV, int gioiTinh, String noiSinh, DateTime ngaySinh, String maLop)
        {
            this.MaSV = maSV;
            this.HoTenSV = tenSV;
            this.GioiTinh = gioiTinh;
            this.NoiSinh = noiSinh;
            this.NgaySinh = ngaySinh;
            this.MaLop = maLop;
        }

        public string MaSV { get => maSV; set => maSV = value; }
        public string HoTenSV { get => hoTenSV; set => hoTenSV = value; }
        public int GioiTinh { get => gioiTinh; set => gioiTinh = value; }
        public string NoiSinh { get => noiSinh; set => noiSinh = value; }
        public DateTime NgaySinh { get => ngaySinh; set => ngaySinh = value; }
        public string MaLop { get => maLop; set => maLop = value; }
    }
}
