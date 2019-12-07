using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Project_CSharp_QuanLySinhVien
{
    public partial class frmSinhVien : Form
    {
        public frmSinhVien()
        {
            InitializeComponent();
        }
        clsHandleManegeStudentDatabase dbManegeStudent = new clsHandleManegeStudentDatabase();
        clsSinhVien sinhVien = new clsSinhVien();
        private void frmSinhVien_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result;
            result = MessageBox.Show("Bạn chắc chắn muốn thoát chương trình?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(result != DialogResult.Yes)
            {
                e.Cancel = true;
            }
        }

        private void frmSinhVien_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void frmSinhVien_Load(object sender, EventArgs e)
        {
            dgvDanhmucSV.DataSource = dbManegeStudent.getDataFromTable("GETSTUDENT");
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            sinhVien.MaSV = txtMaSV.Text;
            sinhVien.HoTenSV = txtTenSV.Text;
            if (cboGioitinh.Text == "Nam")
                sinhVien.GioiTinh = 1;
            else if (cboGioitinh.Text == "Nữ")
                sinhVien.GioiTinh = 0;
            sinhVien.NoiSinh = txtNoisinhSV.Text;
            sinhVien.NgaySinh = dtpNgaysinhSV.Value;
            sinhVien.MaLop = txtMalopSV.Text;

            int result = dbManegeStudent.insertDataIntoStudentTable("INSERTSTUDENT", sinhVien);
            
            if(result != 0)
            {
                MessageBox.Show("Thêm sinh viên thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            dgvDanhmucSV.DataSource = dbManegeStudent.getDataFromTable("GETSTUDENT");
        }

        private void dgvDanhmucSV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = dgvDanhmucSV.CurrentCell.RowIndex;
            txtMaSV.Text = dgvDanhmucSV.Rows[rowIndex].Cells[0].Value.ToString();
            txtTenSV.Text = dgvDanhmucSV.Rows[rowIndex].Cells[1].Value.ToString();
            if(dgvDanhmucSV.Rows[rowIndex].Cells[2].Value.ToString() == "True")
            {
                cboGioitinh.Text = "Nam";
            }
            else
            {
                cboGioitinh.Text = "Nữ";
            }
            txtNoisinhSV.Text = dgvDanhmucSV.Rows[rowIndex].Cells[3].Value.ToString();
            dtpNgaysinhSV.Text = dgvDanhmucSV.Rows[rowIndex].Cells[4].Value.ToString();
            txtMalopSV.Text = dgvDanhmucSV.Rows[rowIndex].Cells[5].Value.ToString();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtMaSV.Text != string.Empty && txtTenSV.Text != string.Empty && cboGioitinh.Text != string.Empty
                && txtNoisinhSV.Text != string.Empty && dtpNgaysinhSV.Text != string.Empty && txtMalopSV.Text != string.Empty)
            {
                sinhVien.MaSV = txtMaSV.Text;
                sinhVien.HoTenSV = txtTenSV.Text;
                if (cboGioitinh.Text == "Nam")
                    sinhVien.GioiTinh = 1;
                else if (cboGioitinh.Text == "Nữ")
                    sinhVien.GioiTinh = 0;
                sinhVien.NoiSinh = txtNoisinhSV.Text;
                sinhVien.NgaySinh = dtpNgaysinhSV.Value;
                sinhVien.MaLop = txtMalopSV.Text;

                int result = dbManegeStudent.updateDataIntoStudentTable("UPDATESTUDENT", sinhVien);

                if (result != 0)
                {
                    MessageBox.Show("Cập nhật thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                dgvDanhmucSV.DataSource = dbManegeStudent.getDataFromTable("GETSTUDENT");
            }
        }
    }
}
