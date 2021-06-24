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
    public partial class Quanlybanhang : Form
    {
        public Quanlybanhang()
        {
            InitializeComponent();
        }

        private void Quanlybanhang_Load(object sender, EventArgs e)
        {
            cleartext();
            getdata("");
            getThongTinHoaDon();
            txt_SoLuong.Text = "0";
        }
        private void getdata(string Mahd)
        {
            SqlCommand cmd = new SqlCommand("Select * from Chitiethoadon where Mahd='" + Mahd + "'", DB.conn);
            DB.conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds, "banhang");
            dgvHoaDonBanHang.DataSource = ds.Tables["banhang"];
            DB.conn.Close();
        }
        private void getThongTinHoaDon()
        {
            SqlCommand cmd = new SqlCommand("Select * from Hoadonbanhangg", DB.conn);
            DB.conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds, "hoadon");
            dgvThongTinHoaDon.DataSource = ds.Tables["hoadon"];
            DB.conn.Close();
        }
        private void cleartext()
        {
           
            txt_DonGia.Clear();
            txt_MaHoaDon.Clear();
            txt_SoDienThoai.Clear();
            txt_SoLuong.Clear();
            txt_TenKhachHang.Clear();
            txt_TenNhanVien.Clear();
            txt_TenSanPham.Clear();
            txt_TongTien.Clear();
            cbo_MaNhanVien.ResetText();
            txt_ThanhTien.Text = "0";
            cbo_MaSP.ResetText();
            getNhanvien();
            getSanPham();
        }
        private void getNhanvien()
        {
            SqlCommand cmd = new SqlCommand("Select * from Thongtinnhanvien", DB.conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds, "nhanvien");
            cbo_MaNhanVien.DataSource = ds.Tables["nhanvien"];
            cbo_MaNhanVien.DisplayMember = "Manv";
            cbo_MaNhanVien.ValueMember = "Manv";

            ///cbo_MaNhanVien.DataSource = ds.Tables["nhanvien"];
            ///cbo_MaNhanVien.DisplayMember = "MaNV";
            ///cbo_MaNhanVien.ValueMember = "MaNV";
        }
        private void getSanPham()
        {
            SqlCommand cmd = new SqlCommand("Select * from SanPham", DB.conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds, "sanpham");
            cbo_MaSP.DataSource = ds.Tables["sanpham"];
            cbo_MaSP.DisplayMember = "Masp";
            cbo_MaSP.ValueMember = "Masp";

            ///cbo_MaSP.DataSource = ds.Tables["sanpham"];
            ///cbo_MaSP.DisplayMember = "TenSP";
            ///cbo_MaSP.ValueMember = "MaSP";
        }

        private void btn_ThemHoaDon_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Select count(*) from Hoadonbanhangg where Mahd=@mahd", DB.conn);
            DB.conn.Open();
            cmd.Parameters.AddWithValue("@mahd", txt_MaHoaDon.Text);
            int check = Convert.ToInt32(cmd.ExecuteScalar().ToString());
            DB.conn.Close();
            if (check == 1)
            {
                MessageBox.Show("Mã hoá đơn đã bị trùng !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cleartext();
            }
            else
            {
                SqlCommand cmd1 = new SqlCommand("insert into Hoadonbanhangg(Mahd,Manv,Tennv,Ngayban,Thanhtien,Tenkh,Sdt) values(@mahd,@manv,@tennv,@ngayban,@thanhtien,@tenkh,@sodt); Select @@Identity", DB.conn);
                cmd1.Parameters.AddWithValue("@mahd", txt_MaHoaDon.Text);     
                cmd1.Parameters.AddWithValue("@manv", cbo_MaNhanVien.SelectedValue.ToString());
                cmd1.Parameters.AddWithValue("@tennv", txt_TenNhanVien.Text);
                cmd1.Parameters.AddWithValue("@ngayban", dtp_NgayBan.Value);
                cmd1.Parameters.AddWithValue("@thanhtien", txt_ThanhTien.Text);
                cmd1.Parameters.AddWithValue("@tenkh", txt_TenKhachHang.Text);
                cmd1.Parameters.AddWithValue("@sodt", txt_SoDienThoai.Text);
                
                DB.conn.Open();
                cmd1.ExecuteNonQuery();

                DataTable dt = (DataTable)dgvHoaDonBanHang.DataSource;
                for (int i = 0; i < dt.Rows.Count; i++)
                {

                    SqlCommand cmd2 = new SqlCommand("insert into Chitiethoadon(Mahd, Masp, Soluong,Dongia,Tongtien) values(@mahd,@masp,@soluong,@dongia,@tongtien); Select @@Identity", DB.conn);
                    cmd2.Parameters.AddWithValue("@mahd", dt.Rows[i]["Mahd"].ToString());
                    cmd2.Parameters.AddWithValue("@masp", dt.Rows[i]["Masp"].ToString());
                    cmd2.Parameters.AddWithValue("@soluong", dt.Rows[i]["Soluong"].ToString());
                    cmd2.Parameters.AddWithValue("@dongia", dt.Rows[i]["Dongia"].ToString());
                    cmd2.Parameters.AddWithValue("@tongtien", dt.Rows[i]["Tongtien"].ToString());
                    cmd2.ExecuteNonQuery();
                }

                DB.conn.Close();
                MessageBox.Show("Thêm thành công hoá đơn !!!", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                getThongTinHoaDon();
                cleartext();
            }
        }

        private void btn_SuaHoaDon_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("update Hoadonbanhangg set Mahd=@mahd,Manv=@manv,Tennv=@tennv,Ngayban=@ngayban,Thanhtien=@thanhtien,Tenkh=@tenkh,Sdt=@sodt where Mahd=@mahd", DB.conn);
            DB.conn.Open();
            cmd.Parameters.AddWithValue("@mahd", txt_MaHoaDon.Text);
            cmd.Parameters.AddWithValue("@manv", cbo_MaNhanVien.SelectedValue.ToString());
            cmd.Parameters.AddWithValue("@tennv", txt_TenNhanVien.Text);
            cmd.Parameters.AddWithValue("@ngayban", dtp_NgayBan.Value);
            cmd.Parameters.AddWithValue("@thanhtien", txt_ThanhTien.Text);
            cmd.Parameters.AddWithValue("@tenkh", txt_TenKhachHang.Text);
            cmd.Parameters.AddWithValue("@sodt", txt_SoDienThoai.Text);
            
            cmd.ExecuteNonQuery();

            SqlCommand cmd2 = new SqlCommand("Delete from Chitiethoadon where Mahd=@mahd", DB.conn);
            cmd2.Parameters.AddWithValue("@mahd", txt_MaHoaDon.Text);
            cmd2.ExecuteNonQuery();

            DataTable dt = (DataTable)dgvHoaDonBanHang.DataSource;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                SqlCommand cmd1 = new SqlCommand("Insert into Chitiethoadon(Mahd, Masp, Soluong, Dongia,Tongtien) values(@mahd, @masp, @soluong, @dongia,@tongtien); Select @@Identity", DB.conn);
                //Na.conn.Open();
                cmd1.Parameters.AddWithValue("@mahd", dt.Rows[i]["Mahd"].ToString());
                cmd1.Parameters.AddWithValue("@masp", dt.Rows[i]["Masp"].ToString());
                cmd1.Parameters.AddWithValue("@soluong", dt.Rows[i]["Soluong"].ToString());
                cmd1.Parameters.AddWithValue("@dongia", dt.Rows[i]["Dongia"].ToString());
                cmd1.Parameters.AddWithValue("@tongtien", dt.Rows[i]["Tongtien"].ToString());
                cmd1.ExecuteNonQuery();
            }
            DB.conn.Close();
            MessageBox.Show("Sửa thành công thông tin hoá đơn !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //getdata();
            getThongTinHoaDon();
            cleartext();
        }

        private void dgvThongTinHoaDon_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvThongTinHoaDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int id = e.RowIndex;
            if (id >= 0)
            {
                txt_MaHoaDon.Text = dgvThongTinHoaDon.Rows[id].Cells["Mahd"].Value.ToString();
                dtp_NgayBan.Value = Convert.ToDateTime(dgvThongTinHoaDon.Rows[id].Cells["Ngayban"].Value.ToString());
                cbo_MaNhanVien.SelectedValue = dgvThongTinHoaDon.Rows[id].Cells["Manv"].Value.ToString();
                txt_TenNhanVien.Text = dgvThongTinHoaDon.Rows[id].Cells["Tennv"].Value.ToString();
                txt_ThanhTien.Text = dgvThongTinHoaDon.Rows[id].Cells["Thanhtien"].Value.ToString();
                txt_TenKhachHang.Text = dgvThongTinHoaDon.Rows[id].Cells["Tenkh"].Value.ToString();
                txt_SoDienThoai.Text = dgvThongTinHoaDon.Rows[id].Cells["Sdt"].Value.ToString();
                getdata(txt_MaHoaDon.Text);
            }
            txt_MaHoaDon.Enabled = false;
        }

        private void dgvHoaDonBanHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int id = e.RowIndex;
            if (id >= 0)
            {
                txt_MaHoaDon.Text = dgvHoaDonBanHang.Rows[id].Cells["Mahd"].Value.ToString();
                cbo_MaSP.SelectedValue = dgvHoaDonBanHang.Rows[id].Cells["Masp"].Value.ToString();
                txt_SoLuong.Text = dgvHoaDonBanHang.Rows[id].Cells["Soluong"].Value.ToString();
                txt_DonGia.Text = dgvHoaDonBanHang.Rows[id].Cells["Dongia"].Value.ToString();
                txt_TongTien.Text = dgvHoaDonBanHang.Rows[id].Cells["Tongtien"].Value.ToString();

            }
            txt_MaHoaDon.Enabled = false;
        }

        private void txt_SoLuong_EnabledChanged(object sender, EventArgs e)
        {
            int soluong = txt_SoLuong.Text == "" ? 0 : Convert.ToInt32(txt_SoLuong.Text);
            int dongia = txt_DonGia.Text == "" ? 0 : Convert.ToInt32(txt_DonGia.Text);
            txt_TongTien.Text = (soluong * dongia).ToString();
        }

        private void cbo_MaNhanVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataRowView ht = (DataRowView)cbo_MaNhanVien.SelectedItem;
            txt_TenNhanVien.Text = ht.Row["Tennv"].ToString();
        }

        private void cbo_MaSP_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataRowView ht = (DataRowView)cbo_MaSP.SelectedItem;
            txt_TenSanPham.Text = ht.Row["Tensp"].ToString();
            txt_DonGia.Text = ht.Row["Dongia"].ToString();
        }

        private void btn_LamMoi_Click(object sender, EventArgs e)
        {
            cleartext();
            getThongTinHoaDon();
            getdata("");
            txt_MaHoaDon.Enabled = true;
        }
        public void tinhtien()
        {
            int thanhtien = 0;
            for (int i = 0; i < dgvHoaDonBanHang.Rows.Count - 1; i++)
            {
                thanhtien = thanhtien + int.Parse(dgvHoaDonBanHang.Rows[i].Cells["Tongtien"].Value.ToString());
            }
            txt_ThanhTien.Text = thanhtien.ToString();
        }

        private void btn_Tinh_Click(object sender, EventArgs e)
        {
            tinhtien();
        }

        private void btn_Luu_Click(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)dgvHoaDonBanHang.DataSource;

            bool kt = false;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (cbo_MaSP.SelectedValue.ToString() == dt.Rows[i]["Masp"].ToString())
                {
                    int soluong = Convert.ToInt32(dt.Rows[i]["Soluong"].ToString());
                    int soluongmoi = Convert.ToInt32(txt_SoLuong.Text);
                    dt.Rows[i]["Soluong"] = soluong + soluongmoi;

                    int tongtien = Convert.ToInt32(dt.Rows[i]["Tongtien"].ToString());
                    int tongtienmoi = Convert.ToInt32(txt_TongTien.Text);
                    dt.Rows[i]["Tongtien"] = tongtien + tongtienmoi;

                    kt = true;
                }
            }
            if (kt == false)
            {
                DataRow dr = dt.NewRow();

                dr["Mahd"] = txt_MaHoaDon.Text;
                dr["Masp"] = cbo_MaSP.SelectedValue.ToString();
                dr["Soluong"] = txt_SoLuong.Text;
                dr["Dongia"] = txt_DonGia.Text;
                dr["Tongtien"] = txt_TongTien.Text;

                dt.Rows.Add(dr);
                dgvHoaDonBanHang.DataSource = dt;
            }
        }

        private void btn_XoaHoaDon_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Bạn có chắc chắn muốn xoá không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                SqlCommand cmd = new SqlCommand("delete from Hoadonbanhangg where Mahd=@mahd", DB.conn);
                DB.conn.Open();
                cmd.Parameters.AddWithValue("@mahd", txt_MaHoaDon.Text);

                cmd.ExecuteNonQuery();
                DB.conn.Close();
                MessageBox.Show("Xoá thành công hoá đơn !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                getThongTinHoaDon();
                cleartext();
            }
        }

        private void btn_InHoaDon_Click(object sender, EventArgs e)
        {
            
        }

        private void txt_SoLuong_TextChanged(object sender, EventArgs e)
        {
            int soluong = txt_SoLuong.Text == "" ? 0 : Convert.ToInt32(txt_SoLuong.Text);
            int dongia = txt_DonGia.Text == "" ? 0 : Convert.ToInt32(txt_DonGia.Text);
            txt_TongTien.Text = (soluong * dongia).ToString();
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

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Bangtinhluong form = new Bangtinhluong();
            this.Hide();
            form.Show();
        }
    }
}
