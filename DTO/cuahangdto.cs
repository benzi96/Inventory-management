using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTO
{
    public class cuahangdto
    {
        private string table = "CUAHANG";
        private int machinhanh;
        private string tenchinhanh;
        private string diachi;
        private string matp;

        public int Machinhanh
        {
            get { return machinhanh; }
            set { machinhanh = value; }
        }

        public string Tenchinhanh
        {
            get { return tenchinhanh; }
            set { tenchinhanh = value; }
        }
       

        public string Table
        {
            get { return table; }
            set { table = value; }
        }
        

        
       
        public string Diachi
        {
            get { return diachi; }
            set { diachi = value; }
        }

        

        public string Matp
        {
            get { return matp; }
            set { matp = value; }
        }
        
    }
}
