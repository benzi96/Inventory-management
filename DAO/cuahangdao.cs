using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DTO;
using System.Data.SqlClient;
using System.Data;

namespace DAO
{
    public class cuahangdao
    {
        private dbConnection conn;

        public cuahangdao()
        {
            conn = new dbConnection();
        }
        public DataTable listcuahang()
        {
            string query = string.Format("select * from CUAHANG");
            return conn.executeSelectQuery(query);
        }
        public DataTable listcuahang(string dieukien)
        {
            string query = string.Format("select * from CUAHANG where TENCHINHANH = @tenchinhanh");
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@tenchinhanh", SqlDbType.NVarChar, 100);
            sqlParameters[0].Value = Convert.ToString(dieukien);
            return conn.executeSelectQuery(query,sqlParameters);
        }
        public bool add(cuahangdto cuahang)
        {
            string insert = string.Format("insert into CUAHANG (TENCHINHANH,DIACHI,MATP) values (@tenchinhanh,@diachi,@matp)");

            SqlParameter[] sqlParameters = new SqlParameter[3];
            sqlParameters[0] = new SqlParameter("@tenchinhanh", SqlDbType.NVarChar,100);
            sqlParameters[0].Value = Convert.ToString(cuahang.Tenchinhanh);
            sqlParameters[1] = new SqlParameter("@diachi", SqlDbType.NVarChar,100);
            sqlParameters[1].Value = Convert.ToString(cuahang.Diachi);
            sqlParameters[2] = new SqlParameter("@matp", SqlDbType.NVarChar,15);
            sqlParameters[2].Value = Convert.ToString(cuahang.Matp);

            return conn.executeInsertQuery(insert,sqlParameters);
        }
        public bool update(cuahangdto cuahang)
        {
            string update = string.Format("update CUAHANG SET TENCHINHANH = @tencuahang, DIACHI = @diachi, MATP = @matp WHERE MACUAHANG = @machinhanh");
            SqlParameter[] sqlParameters = new SqlParameter[4];
            sqlParameters[0] = new SqlParameter("@tenchinhanh", SqlDbType.NVarChar,100);
            sqlParameters[0].Value = Convert.ToString(cuahang.Tenchinhanh);
            sqlParameters[1] = new SqlParameter("@diachi", SqlDbType.NVarChar,100);
            sqlParameters[1].Value = Convert.ToString(cuahang.Diachi);
            sqlParameters[2] = new SqlParameter("@matp", SqlDbType.NVarChar,15);
            sqlParameters[2].Value = Convert.ToString(cuahang.Matp);
            sqlParameters[3] = new SqlParameter("@macuahang", SqlDbType.Int);
            sqlParameters[3].Value = cuahang.Machinhanh;
            return conn.executeUpdateQuery(update,sqlParameters);
        }
        public bool delete(cuahangdto cuahang)
        {
            string delete = string.Format("delete from CUAHANG where MACHINHANH = @machinhanh");
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@machinhanh", SqlDbType.Int);
            sqlParameters[0].Value = cuahang.Machinhanh;
            return conn.executeDeleteQuery(delete,sqlParameters);
        }
    }
}
