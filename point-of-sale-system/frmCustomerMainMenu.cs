using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace point_of_sale_system
{
    public partial class frmCustomerMainMenu : Form
    {
        public frmCustomerMainMenu()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTime.Text = System.DateTime.Now.ToString();
        }

        private void frmCustomerMainMenu_Load(object sender, EventArgs e)
        {

        }
        private void btnUpdateProfile_Click(object sender, EventArgs e)
        {
            frmUpdateProfile frm = new frmUpdateProfile();
            frm.Getdata();
            frm.txtCustomerID.Text = lblUser.Text;
            frm.Show();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmCustomerRegistration o2 = new frmCustomerRegistration();
            o2.Hide();
            frmUpdateProfile o4 = new frmUpdateProfile();
            o4.Hide();
            frmCustomerOrders o5 = new frmCustomerOrders();
            o5.Hide();
            frmLogin frm = new frmLogin();
            frm.txtUserId.Text = "";
            frm.txtPassword.Text = "";
            frm.ProgressBar1.Visible = false;
            frm.txtUserId.Focus();
            frm.Show();
        }

        private void frmCustomerMainMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Are you sure want to quit?   ", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void btnPointHistory_Click(object sender, EventArgs e)
        {
            frmCustomerOrders frm = new frmCustomerOrders();
            frm.txtCustomerID.Text = lblUser.Text;
            frm.Show();
        }

        private void btnPurchaseHistory_Click(object sender, EventArgs e)
        {
            frmCustomerOrders frm = new frmCustomerOrders();
            frm.txtCustomerID.Text = lblUser.Text;
            frm.Show();
        }

    }
}
