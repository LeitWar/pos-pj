using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
namespace point_of_sale_system
{
    public partial class frmMainMenu : Form
    {
        public frmMainMenu()
        {
            InitializeComponent();
        }

        private void productToolStripMenuItem_Click(object sender, EventArgs e)
        {

            frmProductsRecord frm = new frmProductsRecord();
            frm.Show();
        }
        private void customerToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            frmCustomersRecord frm = new frmCustomersRecord();
            frm.Show();
        }

        private void saleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSales frm = new frmSales();
            frm.Show();
        }
        private void invoiceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSalesRecord1 frm = new frmSalesRecord1();
            frm.Show();
        }
        private void supplierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSuppliersRecord frm = new frmSuppliersRecord();
            frm.Show();
        }
        private void categoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCategoryRecord frm = new frmCategoryRecord();
            frm.Show();
        }
        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmCategory o1 = new frmCategory();
            o1.Hide();
          
            frmProduct o3 = new frmProduct();
            o3.Hide();
          
            frmCustomersRecord o7 = new frmCustomersRecord();
            o7.Hide();
            frmLogin frm = new frmLogin();
            frm.Show();
            frm.txtUserId.Text = "";
            frm.txtPassword.Text = "";
            frm.ProgressBar1.Visible = false;
            frm.txtUserId.Focus();
        }

        private void frmMainMenu_Load(object sender, EventArgs e)
        {
         //ToolStripStatusLabel4.Text = System.DateTime.Now.ToString();
         //GetData();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            ToolStripStatusLabel4.Text = System.DateTime.Now.ToString();
        }

   
      
        private void frmMainMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Dispose();
            
        }

        
    }
}
