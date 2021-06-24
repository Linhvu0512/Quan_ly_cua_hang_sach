using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quanlycuahangsasch
{
    public partial class Hethong : Form
    {
        public Hethong()
        {
            InitializeComponent();
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
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

        private void quanlyluongtoolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Bangtinhluong form = new Bangtinhluong();
            this.Hide();
            form.Show();
        }
    }   
}
