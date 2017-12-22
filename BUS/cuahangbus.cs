using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using DTO;
using DAO;

namespace BUS
{
    public class cuahangbus
    {
        private cuahangdao chd = new cuahangdao();
        public bool add(cuahangdto cuahang)
        {
            //validate here

            return chd.add(cuahang);
        }
        public DataTable listcuahang()
        {
            return chd.listcuahang();
        }
        public DataTable listcuahang(string dieukien)
        {
            return chd.listcuahang(dieukien);
        }
        public bool update(cuahangdto cuahang)
        {
            return chd.update(cuahang);
        }
        public bool delete(cuahangdto cuahang)
        {
            return chd.delete(cuahang);
        }
    }
}
