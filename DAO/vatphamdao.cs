using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DTO;

namespace DAO
{
   public class vatphamdao
    {
        private dbConnection conn;

        public vatphamdao()
        {
            conn = new dbConnection();
        }

        public DataTable listvatpham()
        {
            string query = string.Format("select * from VATPHAM");            
            return conn.executeSelectQuery(query);
        }
        public DataTable listvatpham(string dieukien)
        {
            string query = string.Format("select * from VATPHAM where TENVP=@tenvp");
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@tenvp", SqlDbType.NVarChar, 100);
            sqlParameters[0].Value = Convert.ToString(dieukien);
            return conn.executeSelectQuery(query,sqlParameters);
        }
         public bool add(vatphamdto vp)
        {
            string insert = string.Format("insert into VATPHAM (HINHANH,TENVP,LOAIVP,GIA,TUKHOA) values (@hinhanh,@tenvp,@loaivp,@gia,@tukhoa)");

            SqlParameter[] sqlParameters = new SqlParameter[5];
            sqlParameters[0] = new SqlParameter("@hinhanh", SqlDbType.NVarChar,100);
            sqlParameters[0].Value = Convert.ToString(vp.Hinhanh);
            sqlParameters[1] = new SqlParameter("@tenvp", SqlDbType.NVarChar,100);
            sqlParameters[1].Value = Convert.ToString(vp.Tenvatpham);
            sqlParameters[2] = new SqlParameter("@loaivp", SqlDbType.NVarChar,15);
            sqlParameters[2].Value = Convert.ToString(vp.Loaivatpham);
            sqlParameters[3] = new SqlParameter("@gia", SqlDbType.Decimal);
            sqlParameters[3].Value = Convert.ToString(vp.Gia);
            sqlParameters[4] = new SqlParameter("@tukhoa", SqlDbType.NVarChar,100);
            sqlParameters[4].Value = Convert.ToString(vp.Tukhoa);
            return conn.executeInsertQuery(insert,sqlParameters);
        }
        public bool update(vatphamdto vp)
        {
            string update = string.Format("update VATPHAM SET HINHANH = @hinhanh, TENVP = @tenvp, LOAIVP = @loaivp, GIA = @gia, TUKHOA = @tukhoa WHERE MAVP = @mavp");
            SqlParameter[] sqlParameters = new SqlParameter[6];
            sqlParameters[0] = new SqlParameter("@hinhanh", SqlDbType.NVarChar,100);
            sqlParameters[0].Value = Convert.ToString(vp.Hinhanh);
            sqlParameters[1] = new SqlParameter("@tenvp", SqlDbType.NVarChar,100);
            sqlParameters[1].Value = Convert.ToString(vp.Tenvatpham);
            sqlParameters[2] = new SqlParameter("@loaivp", SqlDbType.NVarChar,15);
            sqlParameters[2].Value = Convert.ToString(vp.Loaivatpham);
            sqlParameters[3] = new SqlParameter("@gia", SqlDbType.Decimal);
            sqlParameters[3].Value = Convert.ToString(vp.Gia);
            sqlParameters[4] = new SqlParameter("@tukhoa", SqlDbType.NVarChar,100);
            sqlParameters[4].Value = Convert.ToString(vp.Tukhoa);
            sqlParameters[5] = new SqlParameter("@mavp", SqlDbType.Int);
            sqlParameters[5].Value = Convert.ToString(vp.Mavatpham);
            return conn.executeUpdateQuery(update,sqlParameters);
        }
        public bool delete(vatphamdto vp)
        {
            string delete = string.Format("delete from VATPHAM where MAVP= @mavp");
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@mavp", SqlDbType.Int);
            sqlParameters[0].Value = vp.Mavatpham;
            return conn.executeDeleteQuery(delete,sqlParameters);
        }
    }
}
