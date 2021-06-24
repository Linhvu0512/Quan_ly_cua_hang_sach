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
    public partial class Dangnhap : Form
    {
        public Dangnhap()
        {
            InitializeComponent();
        }

        private void btnDangnhap_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("select count(*) from Nguoidung where Taikhoan = @taikhoan and Matkhau = @matkhau", DB.conn);
            DB.conn.Open();
            cmd.Parameters.AddWithValue("@taikhoan", txtTaikhoan.Text);
            cmd.Parameters.AddWithValue("@matkhau", txtMatkhau.Text);
            int soluong = Convert.ToInt32(cmd.ExecuteScalar().ToString());
            if (soluong == 1 )
            {

                MessageBox.Show("Đăng nhập thành công", "Thông báo", MessageBoxButtons.OK);
                Hethong ht = new Hethong();
                ht.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Đăng nhập không thành công", "Thông báo", MessageBoxButtons.OK);
            }
            DB.conn.Close();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Bạn có muốn thoát không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question)==DialogResult.OK)
            {
                this.Close();
            }
        }
    }
}
