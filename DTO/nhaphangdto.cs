using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTO
{
    public class nhaphangdto
    {
        private string table = "NHAPHANG";
        private string manhaphang;
        private string ngaynhaphang;
        private int machinhanh;

        public int Machinhanh
        {
            get { return machinhanh; }
            set { machinhanh = value; }
        }
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
       
        public string Ngaynhaphang
        {
            get { return ngaynhaphang; }
            set { ngaynhaphang = value; }
        }

        
    }
    
}
