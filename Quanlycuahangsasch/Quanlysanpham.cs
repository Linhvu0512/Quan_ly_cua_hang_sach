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
    public partial class Quanlysanpham : Form
    {
        public Quanlysanpham()
        {
            InitializeComponent();
        }

        private void Quanlysanpham_Load(object sender, EventArgs e)
        {
            getData();
            cleartext();
        }
        private void getData()
        {
            SqlCommand cmd = new SqlCommand("Select * from Sanpham", DB.conn);
            DB.conn.Open();
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            ad.Fill(ds, "mkd");
            dgvSanPham.DataSource = ds.Tables["mkd"];
            DB.conn.Close();
        }
        private void cleartext()
        {
            txt_DonGia.Clear();
            txt_GiaNhap.Clear();
            txt_MaSanPham.Clear();
            txt_SoLuong.Clear();
            txt_TenSanPham.Clear();
            txt_TimKiem.Clear();
            txt_TonKho.Clear();
        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Select count (*) from Sanpham where Masp=@masp", DB.conn);
            DB.conn.Open();
            cmd.Parameters.AddWithValue("@masp", txt_MaSanPham.Text);
            int check = Convert.ToInt32(cmd.ExecuteScalar().ToString());
            DB.conn.Close();
            if (check == 1)
            {
                MessageBox.Show("Mã sản phẩm đã bị trùng !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cleartext();
            }
            else
            {
                SqlCommand cmd1 = new SqlCommand("Insert into Sanpham(Masp,Tensp,Soluong,Dongia,Gianhap,Tonkho) values(@masp, @tensp, @soluong, @dongia, @gianhap, @tonkho)", DB.conn);
                DB.conn.Open();
                cmd1.Parameters.AddWithValue("@masp", txt_MaSanPham.Text);
                cmd1.Parameters.AddWithValue("@tensp", txt_TenSanPham.Text);
                cmd1.Parameters.AddWithValue("@soluong", txt_SoLuong.Text);
                cmd1.Parameters.AddWithValue("@dongia", txt_DonGia.Text);
                cmd1.Parameters.AddWithValue("@gianhap", txt_GiaNhap.Text);
                cmd1.Parameters.AddWithValue("@tonkho", txt_TonKho.Text);
                cmd1.ExecuteNonQuery();
                DB.conn.Close();
                MessageBox.Show("Thêm thành công thông tin sản phẩm !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                getData();
                cleartext();
            }
        }

        private void dgvSanPham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int id = e.RowIndex;
            if (id >= 0)
            {
                txt_DonGia.Text = dgvSanPham.Rows[id].Cells["DonGia"].Value.ToString();
                txt_GiaNhap.Text = dgvSanPham.Rows[id].Cells["GiaNhap"].Value.ToString();
                txt_MaSanPham.Text = dgvSanPham.Rows[id].Cells["MaSP"].Value.ToString();
                txt_SoLuong.Text = dgvSanPham.Rows[id].Cells["SoLuong"].Value.ToString();
                txt_TenSanPham.Text = dgvSanPham.Rows[id].Cells["TenSP"].Value.ToString();
                txt_TonKho.Text = dgvSanPham.Rows[id].Cells["TonKho"].Value.ToString();
            }
        }

        private void btn_Sua_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("update Sanpham set Masp=@masp, Tensp=@tensp, Soluong=@soluong, Dongia=@dongia, Gianhap=@gianhap, Tonkho=@tonkho where Masp=@masp", DB.conn);
            DB.conn.Open();
            cmd.Parameters.AddWithValue("@masp", txt_MaSanPham.Text);
            cmd.Parameters.AddWithValue("@tensp", txt_TenSanPham.Text);
            cmd.Parameters.AddWithValue("@soluong", txt_SoLuong.Text);
            cmd.Parameters.AddWithValue("@dongia", txt_DonGia.Text);
            cmd.Parameters.AddWithValue("@gianhap", txt_GiaNhap.Text);
            cmd.Parameters.AddWithValue("@tonkho", txt_TonKho.Text);
            cmd.ExecuteNonQuery();
            DB.conn.Close();
            MessageBox.Show("Sửa thành công thông tin sản phẩm !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            getData();
            cleartext();
        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn chắc chắn muốn xoá không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                SqlCommand cmd = new SqlCommand("delete from Sanpham where Masp=@masp", DB.conn);
                DB.conn.Open();
                cmd.Parameters.AddWithValue("@masp", txt_MaSanPham.Text);
                cmd.ExecuteNonQuery();
                DB.conn.Close();
                MessageBox.Show("Xoá thành công thông tin sản phẩm !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                getData();
                cleartext();
            }
        }

        private void btn_TimKiem_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Select * from Sanpham where Masp='" + txt_TimKiem.Text + "'or Tensp='" + txt_TimKiem.Text + "'", DB.conn);
            DB.conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds, "mkd");
            dgvSanPham.DataSource = ds.Tables["mkd"];
            DB.conn.Close();
        }

        private void btn_LamMoi_Click(object sender, EventArgs e)
        {
            getData();
            cleartext();
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

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Bangtinhluong form = new Bangtinhluong();
            this.Hide();
            form.Show();
        }
    }
}
