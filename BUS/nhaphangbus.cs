using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DTO;
using DAO;
using System.Data;

namespace BUS
{
    public class nhaphangbus
    {
        nhaphangdao nhd = new nhaphangdao();
        public DataTable listnhaphang()
        {
            return nhd.listnhaphang();
        }
        public bool add(nhaphangdto nhaphang)
        {
            return nhd.add(nhaphang);
        }
        public bool update(nhaphangdto nhaphang)
        {
            return nhd.update(nhaphang);
        }
        public bool delete(nhaphangdto nhaphang)
        {
            return nhd.delete(nhaphang);
        }
    }
}
