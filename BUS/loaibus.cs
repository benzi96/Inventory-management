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
    public class loaibus
    {
        loaidao ld = new loaidao();
        public DataTable listloai()
        {
            return ld.listloai();
        }
        public bool add(loaidto loai)
        {
            return ld.add(loai);
        }
        public bool update(loaidto loai)
        {
            return ld.update(loai);
        }
        public bool delete(loaidto loai)
        {
            return ld.delete(loai);
        }
    }
}
