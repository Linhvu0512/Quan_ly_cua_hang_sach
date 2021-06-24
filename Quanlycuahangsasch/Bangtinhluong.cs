using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quanlycuahangsasch
{
    public partial class Bangtinhluong : Form
    {
        public int quanly = 0;
        public int nhanvien = 0;
        public Bangtinhluong()
        {
            InitializeComponent();
        }
        
        private void Bangtinhluong_Load(object sender, EventArgs e)
        {
            getData();
            ClearText();
        }
        public void getData()
        {
            SqlCommand cmd = new SqlCommand("select * from BangluongNV", DB.conn);
            DB.conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds, "tbBang");
            dgvQuanlyluongnhanvien.DataSource = ds.Tables["tbBang"];
            DB.conn.Close();
        }
        public void getChucvu()
        {
            SqlCommand cmd = new SqlCommand("Select * from Chucvu ", DB.conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds, "tbChucvu");
            cbCHucvu.DataSource = ds.Tables["tbChucvu"];
            cbCHucvu.DisplayMember = "Tencv";
            cbCHucvu.ValueMember = "Macv";
            cbluong.DataSource = ds.Tables["tbChucvu"];
            cbluong.DisplayMember = "Luongcoban";
            cbluong.ValueMember = "Luongcoban";
            
        }
        public void getThongtinnv()
        {
            SqlCommand cmd = new SqlCommand("Select * from Thongtinnhanvien ", DB.conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds, "tbNV");
            cbManv.DataSource = ds.Tables["tbNV"];
            cbManv.DisplayMember = "Tennv";
            cbManv.ValueMember = "Manv";

            cbTennv.DataSource = ds.Tables["tbNV"];
            cbTennv.DisplayMember = "Manv";
            cbTennv.ValueMember = "Tennv";

        }
        public void ClearText()
        {
            cbManv.ResetText();
            cbTennv.ResetText();
            chkNhanvien.Checked = false;
            chkQuanly.Checked = false;
            dateLuongnv.ResetText();
            cbluong.ResetText();
            txtThuong.Clear();
            txtTimkiem.Clear();
            getChucvu();
            getThongtinnv();
            txtThanhtien.Clear();
        }

        private void btnLammoi_Click(object sender, EventArgs e)
        {
            getData();
            ClearText();
        }

        private void dgvQuanlyluongnhanvien_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void btnThem_Click(object sender, EventArgs e)
        {

           //int quanly = 0;
           //int nhanvien = 0;
            if (chkQuanly.Checked == true)
            {
                quanly = 1;
            }
            if (chkNhanvien.Checked == true)
            {
                nhanvien = 1;
            }
            int luong = Convert.ToInt32(cbluong.SelectedValue.ToString());
            int thuong = Convert.ToInt32(txtThuong.Text);
            txtThanhtien.Text = (luong + thuong).ToString();
            SqlCommand cmd = new SqlCommand("Insert Into BangluongNV(Manv,Macv,Tennv,Thoigian,Luong,Nhanvien,Quanly,Thuong,Thanhtien) Values(@manv,@macv,@tennv,@thoigian,@luong,@nhanvien,@quanly,@thuong,@thanhtien)", DB.conn);
            DB.conn.Open();
            cmd.Parameters.AddWithValue("@manv", cbManv.SelectedValue.ToString());
            cmd.Parameters.AddWithValue("@macv", cbCHucvu.SelectedValue.ToString());
            cmd.Parameters.AddWithValue("@tennv", cbTennv.SelectedValue.ToString());
            cmd.Parameters.AddWithValue("@thoigian", dateLuongnv.Value);
            cmd.Parameters.AddWithValue("@thuong", txtThuong.Text);
           
                cmd.Parameters.AddWithValue("@nhanvien", chkNhanvien.Checked);
           
            
                cmd.Parameters.AddWithValue("@quanly", chkQuanly.Checked);
            
            cmd.Parameters.AddWithValue("@luong", cbluong.SelectedValue.ToString());
            cmd.Parameters.AddWithValue("@thanhtien", txtThanhtien.Text);
            cmd.ExecuteNonQuery();
            DB.conn.Close();
            MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK);
            getData();
            ClearText();



        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {

            
            if (chkQuanly.Checked == true)
            {
                quanly = 1;
            }
            if (chkNhanvien.Checked == true)
            {
                nhanvien = 1;
            }
            int luong = Convert.ToInt32(cbluong.SelectedValue.ToString());
            int thuong = Convert.ToInt32(txtThuong.Text);
            txtThanhtien.Text = (luong + thuong).ToString();
            SqlCommand cmd = new SqlCommand("Update BangluongNV Set Manv=@manv,Macv=@macv,Tennv=@tennv,Thoigian=@thoigian,Thuong=@thuong,Nhanvien=@nhanvien,Quanly=@quanly,Luong=@luong,Thanhtien=@thanhtien Where Manv=@manv", DB.conn);
            DB.conn.Open();
            cmd.Parameters.AddWithValue("@manv", cbManv.SelectedValue.ToString());
            cmd.Parameters.AddWithValue("@macv", cbCHucvu.SelectedValue.ToString());
            cmd.Parameters.AddWithValue("@tennv", cbTennv.SelectedValue.ToString());
            cmd.Parameters.AddWithValue("@thoigian", dateLuongnv.Value);
            cmd.Parameters.AddWithValue("@thuong", txtThuong.Text);
            
                cmd.Parameters.AddWithValue("@nhanvien", chkNhanvien.Checked);
            
                cmd.Parameters.AddWithValue("@quanly", chkQuanly.Checked);
            
            cmd.Parameters.AddWithValue("@luong", cbluong.SelectedValue.ToString());
            cmd.Parameters.AddWithValue("@thanhtien", txtThanhtien.Text);
            cmd.ExecuteNonQuery();
            DB.conn.Close();
            MessageBox.Show("Sửa thành công", "Thông báo", MessageBoxButtons.OK);
            getData();
            ClearText();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("delete from BangluongNV where Manv=@manv", DB.conn);
            DB.conn.Open();
            cmd.Parameters.AddWithValue("@manv", cbManv.SelectedValue.ToString());
            cmd.ExecuteNonQuery();
            DB.conn.Close();
            MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK);
            getData();
            ClearText();
        }

        private void btnTimkiem_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("select * from BangluongNV where Manv = '" + txtTimkiem.Text + "'", DB.conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds, "tb");
           dgvQuanlyluongnhanvien.DataSource = ds.Tables["tb"];
        }

        private void txtThuong_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void dgvQuanlyluongnhanvien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int id = e.RowIndex;
            if (id >= 0)
            {
                cbManv.SelectedValue = dgvQuanlyluongnhanvien.Rows[id].Cells["Manv"].Value.ToString();
                cbCHucvu.SelectedValue = dgvQuanlyluongnhanvien.Rows[id].Cells["Macv"].Value.ToString();
                cbTennv.SelectedValue = dgvQuanlyluongnhanvien.Rows[id].Cells["Tennv"].Value.ToString();
                dateLuongnv.Value = Convert.ToDateTime(dgvQuanlyluongnhanvien.Rows[id].Cells["Thoigian"].Value.ToString());
                txtThuong.Text = dgvQuanlyluongnhanvien.Rows[id].Cells["Thuong"].Value.ToString();
                cbluong.SelectedValue = dgvQuanlyluongnhanvien.Rows[id].Cells["Luong"].Value.ToString();
                txtThanhtien.Text = dgvQuanlyluongnhanvien.Rows[id].Cells["Thanhtien"].Value.ToString();
                string quanly = dgvQuanlyluongnhanvien.Rows[id].Cells["Quanly"].Value.ToString();
                if (quanly == "Quản lý")
                {
                    chkQuanly.Checked = true;
                }
                else
                {
                    chkQuanly.Checked = false;
                }
                string nhanvien = dgvQuanlyluongnhanvien.Rows[id].Cells["Nhanvien"].Value.ToString();
                if (nhanvien == "Nhân viên")
                {
                    chkNhanvien.Checked = true;
                }
                else
                {
                    chkNhanvien.Checked = false;
                }
            }
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void quảnLýNhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Thongtinnhanvien form = new Thongtinnhanvien();
            this.Hide();
            form.Show();
        }

        private void quảnLýSảnPhẩmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Quanlysanpham form = new Quanlysanpham();
            this.Hide();
            form.Show();
        }

        private void quảnLýBánHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Quanlybanhang form = new Quanlybanhang();
            this.Hide();
            form.Show();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }
    }
}
