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
    public partial class Thongtinnhanvien : Form
    {
        public Thongtinnhanvien()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Thongtinnhanvien_Load(object sender, EventArgs e)
        {
            getData();
            ClearText();
        }
        public void getData()
        {
            SqlCommand cmd = new SqlCommand("select * from Thongtinnhanvien", DB.conn);
            DB.conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds, "tbNhanvien");
            dgvThongtinnhanvien.DataSource = ds.Tables["tbNhanvien"];
            DB.conn.Close();
        }
        public void ClearText()
        {
            txtManv.Clear();
            txtTennv.Clear();
            chkNam.Checked = false;
            chkNu.Checked = false;
            txtDiachi.Clear();
            txtCMND.Clear();
            txtSDT.Clear();

        }

        private void dgvThongtinnhanvien_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void btnLammoi_Click(object sender, EventArgs e)
        {
            getData();
            ClearText();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
           
            
            SqlCommand cmd = new SqlCommand("Insert Into Thongtinnhanvien(Manv,Tennv,Gioitinh,Diachi,CMND,SDT) Values(@manv,@tennv,@gioitinh,@diachi,@cmnd,@sdt)", DB.conn);
            DB.conn.Open();
            cmd.Parameters.AddWithValue("@manv", txtManv.Text);
            cmd.Parameters.AddWithValue("@tennv", txtTennv.Text);
            if (chkNam.Checked == true)
            {
                cmd.Parameters.AddWithValue("@gioitinh", "Nam");
            }
            else
            //if (chkNu.Checked == true)
            {

                cmd.Parameters.AddWithValue("@gioitinh", "Nữ");
            }
            cmd.Parameters.AddWithValue("@diachi", txtDiachi.Text);
            cmd.Parameters.AddWithValue("@cmnd", txtCMND.Text);
            cmd.Parameters.AddWithValue("@sdt", txtSDT.Text);
            cmd.ExecuteNonQuery();
            DB.conn.Close();
            MessageBox.Show("Thêm mới thành công", "Thông báo", MessageBoxButtons.OK);
            getData();
            ClearText();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            
           
            SqlCommand cmd = new SqlCommand("Update Thongtinnhanvien Set Manv=@manv,Tennv=@tennv,Gioitinh=@gioitinh,Diachi=@diachi,CMND=@cmnd,SDT=@sdt where Manv=@manv", DB.conn);
            DB.conn.Open();
            cmd.Parameters.AddWithValue("@manv", txtManv.Text);
            cmd.Parameters.AddWithValue("@tennv", txtTennv.Text);
            if (chkNam.Checked == true)
            {
                cmd.Parameters.AddWithValue("@gioitinh", "Nam");
            }
            else
            //if (chkNu.Checked == true)
            {

                cmd.Parameters.AddWithValue("@gioitinh", "Nữ");
            }

            cmd.Parameters.AddWithValue("@diachi", txtDiachi.Text);
            cmd.Parameters.AddWithValue("@cmnd", txtCMND.Text);
            cmd.Parameters.AddWithValue("@sdt", txtSDT.Text);
            cmd.ExecuteNonQuery();
            DB.conn.Close();
            MessageBox.Show("Sửa thành công", "Thông báo", MessageBoxButtons.OK);
            getData();
            ClearText();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Delete Thongtinnhanvien where Manv=@manv", DB.conn);
            DB.conn.Open();
            cmd.Parameters.AddWithValue("@manv", txtManv.Text);
            cmd.ExecuteNonQuery();
            DB.conn.Close();
            MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK);
            getData();
            ClearText();

        }


        private void btnTimkiem_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("select * from Thongtinnhanvien where Manv = '" + txtTimkiem.Text + "'", DB.conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds, "tb");
            dgvThongtinnhanvien.DataSource = ds.Tables["tb"];
        }

        private void dgvThongtinnhanvien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int id = e.RowIndex;
            if (id >= 0)
            {
                txtManv.Text = dgvThongtinnhanvien.Rows[id].Cells["Manv"].Value.ToString();
                txtTennv.Text = dgvThongtinnhanvien.Rows[id].Cells["Tennv"].Value.ToString();
                txtDiachi.Text = dgvThongtinnhanvien.Rows[id].Cells["Diachi"].Value.ToString();
                txtCMND.Text = dgvThongtinnhanvien.Rows[id].Cells["CMND"].Value.ToString();
                txtSDT.Text = dgvThongtinnhanvien.Rows[id].Cells["SDT"].Value.ToString();
                string gioitinh = dgvThongtinnhanvien.Rows[id].Cells["Gioitinh"].Value.ToString();
                if (gioitinh == "Nam")
                {
                    chkNam.Checked = true;
                }
                else
                {
                    chkNam.Checked = false;
                }
                if (gioitinh == "Nữ")
                {
                    chkNu.Checked = true;
                }
                else
                {
                    chkNu.Checked = false;
                }
            }
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn đăng xuất không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Dangnhap form = new Dangnhap();
                this.Hide();
                form.Show();
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
    }
}
