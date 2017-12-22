using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTO
{
    public class loaidto
    {
        private string table = "LOAI";
        private string maloai;
        private string tenloai;
     

        public string Table
        {
            get { return table; }
            set { table = value; }
        }


        public string Maloai
        {
            get { return maloai; }
            set { maloai = value; }
        }

        public string Tenloai
        {
            get { return tenloai; }
            set { tenloai = value; }
        }

       
    }
}
