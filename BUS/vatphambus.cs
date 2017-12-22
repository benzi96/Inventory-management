using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DTO;
using DAO;
using System.Data;

namespace BUS
{
    public class vatphambus
    {
        vatphamdao vpd = new vatphamdao();
        public DataTable listvatpham()
        {
            return vpd.listvatpham();
        }
        public DataTable listvatpham(string dieukien)
        {
            return vpd.listvatpham(dieukien);
        }
        public bool add(vatphamdto vatpham)
        {
            return vpd.add(vatpham);
        }
        public bool update(vatphamdto vatpham)
        {
            return vpd.update(vatpham);
        }
        public bool delete(vatphamdto vatpham)
        {
            return vpd.delete(vatpham);
        }
    }
}
