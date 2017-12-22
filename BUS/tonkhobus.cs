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
    public class tonkhobus
    {
        tonkhodao tkd = new tonkhodao();
        public DataTable listtonkho()
        {
            return tkd.listtonkho();
        }
        public DataTable listtonkho(string dieukien)
        {
            return tkd.listtonkho(dieukien);
        }
        public bool add(tonkhodto tonkho)
        {
            return tkd.add(tonkho);
        }
        public bool update(tonkhodto tonkho)
        {
            return tkd.update(tonkho);
        }
        public bool delete(tonkhodto tonkho)
        {
            return tkd.delete(tonkho);
        }
    }
}
