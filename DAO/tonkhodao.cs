using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DTO;
using System.Data;
using System.Data.SqlClient;

namespace DAO
{
   public class tonkhodao
    {
        private dbConnection conn;

        public tonkhodao()
        {
            conn = new dbConnection();
        }

        public DataTable listtonkho()
        {
            string query = string.Format("select HINHANH, TONKHO.MANHAPHANG , NGAYNHAPHANG, TONKHO.MAVP, TENVP, SOLUONGNHAP,SOLUONGTON from TONKHO,NHAPHANG,VATPHAM "+
                                            "where TONKHO.MANHAPHANG = NHAPHANG.MANHAPHANG and TONKHO.MAVP=VATPHAM.MAVP");            
            return conn.executeSelectQuery(query);
        }
        public DataTable listtonkho(string dieukien)
        {
            string query = string.Format("select * from TONKHO where MANHAPHANG = @manh");
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@manh", SqlDbType.NVarChar, 15);
            sqlParameters[0].Value = Convert.ToString(dieukien);
            return conn.executeSelectQuery(query, sqlParameters);
        }
         public bool add(tonkhodto tonkho)
        {
            string insert = string.Format("insert into TONKHO (MANHAPHANG,MAVP,NGAYHETHAN,SOLUONGNHAP,SOLUONGTON) values (@manh,@mavp,@ngayhethan,@slnhap,@slton)");

            SqlParameter[] sqlParameters = new SqlParameter[5];
            sqlParameters[0] = new SqlParameter("@manh", SqlDbType.NVarChar,15);
            sqlParameters[0].Value = Convert.ToString(tonkho.Manhaphang);
            sqlParameters[1] = new SqlParameter("@mavp", SqlDbType.Int);
            sqlParameters[1].Value = Convert.ToString(tonkho.Mavp);
            sqlParameters[2] = new SqlParameter("@ngayhethan", SqlDbType.Date);
            sqlParameters[2].Value = Convert.ToString(tonkho.Ngayhethan);
            sqlParameters[3] = new SqlParameter("@slnhap", SqlDbType.Int);
            sqlParameters[3].Value = Convert.ToString(tonkho.Soluongnhap);
            sqlParameters[4] = new SqlParameter("@slton", SqlDbType.Int);
            sqlParameters[4].Value = Convert.ToString(tonkho.Soluongton);
            return conn.executeInsertQuery(insert,sqlParameters);
        }
        public bool update(tonkhodto tonkho)
        {
            string update = string.Format("update TONKHO SET MAVP= @mavp, NGAYHETHAN= @ngayhethan, SOLUONGNHAP= @slnhap, SOLUONGTON= @slton WHERE MANHAPHANG = @manh");
            SqlParameter[] sqlParameters = new SqlParameter[5];
            sqlParameters[0] = new SqlParameter("@mavp", SqlDbType.Int);
            sqlParameters[0].Value = Convert.ToString(tonkho.Mavp);
            sqlParameters[1] = new SqlParameter("@ngayhethan", SqlDbType.Date);
            sqlParameters[1].Value = Convert.ToString(tonkho.Ngayhethan);
            sqlParameters[2] = new SqlParameter("@slnhap", SqlDbType.Int);
            sqlParameters[2].Value = Convert.ToString(tonkho.Soluongnhap);
            sqlParameters[3] = new SqlParameter("@slton", SqlDbType.Int);
            sqlParameters[3].Value = Convert.ToString(tonkho.Soluongton);
            sqlParameters[4] = new SqlParameter("@manh", SqlDbType.NVarChar,15);
            sqlParameters[4].Value = Convert.ToString(tonkho.Manhaphang);
            return conn.executeUpdateQuery(update,sqlParameters);
        }
        public bool delete(tonkhodto tonkho)
        {
            string delete = string.Format("delete from TONKHO where MANHAPHANG= @manh");
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@manh", SqlDbType.NVarChar,15);
            sqlParameters[0].Value = tonkho.Manhaphang;
            return conn.executeDeleteQuery(delete,sqlParameters);
        }
    }
 }
