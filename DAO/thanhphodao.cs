using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using DTO;
namespace DAO
{
    public class thanhphodao
    {
        private dbConnection conn;

        public thanhphodao()
        {
            conn = new dbConnection();
        }

        public DataTable listthanhpho()
        {
            string query = string.Format("select * from THANHPHO");            
            return conn.executeSelectQuery(query);
        }
         public bool add(thanhphodto thanhpho)
        {
            string insert = string.Format("insert into THANHPHO (MATP,TENTP) values (@matp,@tentp)");

            SqlParameter[] sqlParameters = new SqlParameter[2];
            sqlParameters[0] = new SqlParameter("@matp", SqlDbType.NVarChar,15);
            sqlParameters[0].Value = Convert.ToString(thanhpho.Mathanhpho);
            sqlParameters[1] = new SqlParameter("@tentp", SqlDbType.NVarChar,100);
            sqlParameters[1].Value = Convert.ToString(thanhpho.Tenthanhpho);
            return conn.executeInsertQuery(insert,sqlParameters);
        }
        public bool update(thanhphodto thanhpho)
        {
            string update = string.Format("update THANHPHO SET TENTP = @tentp WHERE MATP = @matp");
            SqlParameter[] sqlParameters = new SqlParameter[2];
            sqlParameters[0] = new SqlParameter("@tentp", SqlDbType.NVarChar,100);
            sqlParameters[0].Value = Convert.ToString(thanhpho.Tenthanhpho);
            sqlParameters[1] = new SqlParameter("@matp", SqlDbType.NVarChar,15);
            sqlParameters[1].Value = Convert.ToString(thanhpho.Mathanhpho);
            return conn.executeUpdateQuery(update,sqlParameters);
        }
        public bool delete(thanhphodto thanhpho)
        {
            string delete = string.Format("delete from THANHPHO where MATP= @matp");
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@matp", SqlDbType.NVarChar,15);
            sqlParameters[0].Value = thanhpho.Mathanhpho;
            return conn.executeDeleteQuery(delete,sqlParameters);
        }
    }
}
