using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DTO;
using System.Data;
using System.Data.SqlClient;

namespace DAO
{
    public class loaidao
    {
        private dbConnection conn;

        public loaidao()
        {
            conn = new dbConnection();
        }

        public DataTable listloai()
        {
            string query = string.Format("select * from LOAI");            
            return conn.executeSelectQuery(query);
        }
         public bool add(loaidto loai)
        {
            string insert = string.Format("insert into LOAI (MALOAI,TENLOAI) values (@maloai,@tenloai)");

            SqlParameter[] sqlParameters = new SqlParameter[2];
            sqlParameters[0] = new SqlParameter("@maloai", SqlDbType.NVarChar,15);
            sqlParameters[0].Value = Convert.ToString(loai.Maloai);
            sqlParameters[1] = new SqlParameter("@tenloai", SqlDbType.NVarChar,50);
            sqlParameters[1].Value = Convert.ToString(loai.Tenloai);
            return conn.executeInsertQuery(insert,sqlParameters);
        }
        public bool update(loaidto loai)
        {
            string update = string.Format("update LOAI SET TENLOAI = @tenloai WHERE MALOAI = @maloai");
            SqlParameter[] sqlParameters = new SqlParameter[2];
            sqlParameters[0] = new SqlParameter("@tenloai", SqlDbType.NVarChar,50);
            sqlParameters[0].Value = Convert.ToString(loai.Tenloai);
            sqlParameters[1] = new SqlParameter("@maloai", SqlDbType.NVarChar,15);
            sqlParameters[1].Value = Convert.ToString(loai.Maloai);
            return conn.executeUpdateQuery(update,sqlParameters);
        }
        public bool delete(loaidto loai)
        {
            string delete = string.Format("delete from LOAI where MALOAI= @maloai");
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@maloai", SqlDbType.NVarChar,15);
            sqlParameters[0].Value = loai.Maloai;
            return conn.executeDeleteQuery(delete,sqlParameters);
        }
    }
}
