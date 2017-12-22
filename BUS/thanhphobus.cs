using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using DAO;
using DTO;

namespace BUS
{
    public class thanhphobus
    {
        thanhphodao tpd = new thanhphodao();
        public DataTable listthanhpho()
        {
            return tpd.listthanhpho();
        }
        public bool add(thanhphodto thanhpho)
        {
            return tpd.add(thanhpho);
        }
        public bool update(thanhphodto thanhpho)
        {
            return tpd.update(thanhpho);
        }
        public bool delete(thanhphodto thanhpho)
        {
            return tpd.delete(thanhpho);
        }
    }
}
