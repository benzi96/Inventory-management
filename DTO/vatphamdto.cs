using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTO
{
    public class vatphamdto
    {
        private string table = "VATPHAM";
        private int mavatpham;
        private string tenvatpham;
        private string tukhoa;
        private string loaivatpham;
        private string hinhanh;
        private decimal gia;

        public decimal Gia
        {
            get { return gia; }
            set { gia = value; }
        }

        public string Table
        {
            get { return table; }
            set { table = value; }
        }


        public int Mavatpham
        {
            get { return mavatpham; }
            set { mavatpham = value; }
        }

        public string Tenvatpham
        {
            get { return tenvatpham; }
            set { tenvatpham = value; }
        }
        public string Loaivatpham
        {
            get { return loaivatpham; }
            set { loaivatpham = value; }
        }

        public string Tukhoa
        {
            get { return tukhoa; }
            set { tukhoa = value; }
        }
        public string Hinhanh
        {
            get { return hinhanh; }
            set { hinhanh = value; }
        }

        
    }
}
