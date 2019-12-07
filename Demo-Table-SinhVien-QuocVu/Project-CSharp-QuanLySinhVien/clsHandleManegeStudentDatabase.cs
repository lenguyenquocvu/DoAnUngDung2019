using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Project_CSharp_QuanLySinhVien
{
    class clsHandleManegeStudentDatabase
    {
        private SqlConnection connection = new SqlConnection();
        public clsHandleManegeStudentDatabase()
        {
            try
            {
                connection.ConnectionString = "Data Source=DESKTOP-I9RFICL\\SQLEXPRESS;Initial Catalog=MANAGE_STUDENT;Integrated Security=True";
                connection.Open();
            }
            catch(SqlException sqlEx)
            {
                MessageBox.Show("Lỗi kết nối database: " + sqlEx.Message);
            }
        }
        public DataTable getDataFromTable(String spName)
        {
            DataTable dtResult = new DataTable();
            SqlCommand sqlCmdGetDataSV = new SqlCommand(spName, connection);
            sqlCmdGetDataSV.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter dtAdapter = new SqlDataAdapter(sqlCmdGetDataSV);
            dtAdapter.Fill(dtResult);
            return dtResult;
        }

        public int insertDataIntoStudentTable(String spName, clsSinhVien sinhVien)
        {
            int result = 0;
            try
            {
                SqlCommand sqlCmdInsertSV = new SqlCommand(spName, connection);
                sqlCmdInsertSV.CommandType = CommandType.StoredProcedure;
                sqlCmdInsertSV.Parameters.AddWithValue("@StudentCode", sinhVien.MaSV);
                sqlCmdInsertSV.Parameters.AddWithValue("@StudentName", sinhVien.HoTenSV);
                sqlCmdInsertSV.Parameters.AddWithValue("@StudentGender", sinhVien.GioiTinh);
                sqlCmdInsertSV.Parameters.AddWithValue("@PlaceOfBirth", sinhVien.NoiSinh);
                sqlCmdInsertSV.Parameters.AddWithValue("@DataOfBirth", sinhVien.NgaySinh);
                sqlCmdInsertSV.Parameters.AddWithValue("@ClassCode", sinhVien.MaLop);
                result = sqlCmdInsertSV.ExecuteNonQuery();
            }
            catch (SqlException sqlEx)
            {
                result = 0;
            }
            return result;
        }

        public int updateDataIntoStudentTable(String spName, clsSinhVien sinhVien)
        {
            int result = 0;
            try
            {
                SqlCommand sqlCmdInsertSV = new SqlCommand(spName, connection);
                sqlCmdInsertSV.CommandType = CommandType.StoredProcedure;
                sqlCmdInsertSV.Parameters.AddWithValue("@StudentCode", sinhVien.MaSV);
                sqlCmdInsertSV.Parameters.AddWithValue("@StudentName", sinhVien.HoTenSV);
                sqlCmdInsertSV.Parameters.AddWithValue("@StudentGender", sinhVien.GioiTinh);
                sqlCmdInsertSV.Parameters.AddWithValue("@PlaceOfBirth", sinhVien.NoiSinh);
                sqlCmdInsertSV.Parameters.AddWithValue("@DataOfBirth", sinhVien.NgaySinh);
                sqlCmdInsertSV.Parameters.AddWithValue("@ClassCode", sinhVien.MaLop);
                result = sqlCmdInsertSV.ExecuteNonQuery();
            }
            catch (SqlException sqlEx)
            {
                result = 0;
            }
            return result;
        }
    }
}
