using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DTO;

namespace DAO
{
    public class nhaphangdao
    {
        private dbConnection conn;

        public nhaphangdao()
        {
            conn = new dbConnection();
        }

        public DataTable listnhaphang()
        {
            string query = string.Format("select * from NHAPHANG");            
            return conn.executeSelectQuery(query);
        }
         public bool add(nhaphangdto nhaphang)
        {
            string insert = string.Format("insert into NHAPHANG (MANHAPHANG,NGAYNHAPHANG,MACHINHANH) values (@manh,@ngaynh,@machinhanh)");

            SqlParameter[] sqlParameters = new SqlParameter[3];
            sqlParameters[0] = new SqlParameter("@manh", SqlDbType.NVarChar,15);
            sqlParameters[0].Value = Convert.ToString(nhaphang.Manhaphang);
            sqlParameters[1] = new SqlParameter("@ngaynh", SqlDbType.Date);
            sqlParameters[1].Value = Convert.ToString(nhaphang.Ngaynhaphang);
            sqlParameters[2] = new SqlParameter("@machinhanh", SqlDbType.Int);
            sqlParameters[2].Value = nhaphang.Machinhanh;
            return conn.executeInsertQuery(insert,sqlParameters);
        }
        public bool update(nhaphangdto nhaphang)
        {
            string update = string.Format("update NHAPHANG SET NGAYNHAPHANG = @ngaynh, MACHINHANH = @machinhanh WHERE MANHAPHANG = @manh");
            SqlParameter[] sqlParameters = new SqlParameter[3];
            sqlParameters[0] = new SqlParameter("@ngaynh", SqlDbType.Date);
            sqlParameters[0].Value = Convert.ToString(nhaphang.Ngaynhaphang);
            sqlParameters[1] = new SqlParameter("@manh", SqlDbType.NVarChar,15);
            sqlParameters[1].Value = Convert.ToString(nhaphang.Manhaphang);
            sqlParameters[2] = new SqlParameter("@machinhanh", SqlDbType.Int);
            sqlParameters[2].Value = nhaphang.Machinhanh;
            return conn.executeUpdateQuery(update,sqlParameters);
        }
        public bool delete(nhaphangdto nhaphang)
        {
            string delete = string.Format("delete from NHAPHANG where MANHAPHANG= @manh");
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@manh", SqlDbType.NVarChar,15);
            sqlParameters[0].Value = nhaphang.Manhaphang;
            return conn.executeDeleteQuery(delete,sqlParameters);
        }
    }
}
