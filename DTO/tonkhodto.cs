using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTO
{
    public class tonkhodto
    {
        private string table = "TONKHO";
        private string manhaphang;
        private string mavp;
        private string ngayhethan;
        private int soluongton;
        private int soluongnhap;

        public string Table
        {
            get { return table; }
            set { table = value; }
        }


        public string Manhaphang
        {
            get { return manhaphang; }
            set { manhaphang = value; }
        }

        public string Mavp
        {
            get { return mavp; }
            set { mavp = value; }
        }
        
        public string Ngayhethan
        {
            get { return ngayhethan; }
            set { ngayhethan = value; }
        }
       
        public int Soluongton
        {
            get { return soluongton; }
            set { soluongton = value; }
        }
        public int Soluongnhap
        {
            get { return soluongnhap; }
            set { soluongnhap = value; }
        }
    }
}
