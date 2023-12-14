using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace point_of_sale_system
{
    public partial class frmLogin : Form
    {
        ConnectionString cs = new ConnectionString();
        SqlDataReader rdr = null;
        SqlConnection con = null;
        SqlCommand cmd = null;
        DataTable dt = new DataTable();
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (txtUserId.Text == "")
            {
                MessageBox.Show("Please enter user name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUserId.Focus();
                return;
            }
            if (txtPassword.Text == "")
            {
                MessageBox.Show("Please enter password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Focus();
                return;
            }
            try
            {
                SqlConnection myConnection = default(SqlConnection);
                myConnection = new SqlConnection(cs.DBConn);

                SqlCommand myCommand = default(SqlCommand);

                myCommand = new SqlCommand("SELECT UserId,Password FROM Registeration WHERE UserId = @UserId AND Password = @UserPassword", myConnection);
                SqlParameter uName = new SqlParameter("@UserId", SqlDbType.VarChar);
                SqlParameter uPassword = new SqlParameter("@UserPassword", SqlDbType.VarChar);
                uName.Value = txtUserId.Text;
                uPassword.Value = txtPassword.Text;
                myCommand.Parameters.Add(uName);
                myCommand.Parameters.Add(uPassword);

                myCommand.Connection.Open();

                SqlDataReader myReader = myCommand.ExecuteReader(CommandBehavior.CloseConnection);

                if (myReader.Read() == true)
                {
                    int i;
                    ProgressBar1.Visible = true;
                    ProgressBar1.Maximum = 5000;
                    ProgressBar1.Minimum = 0;
                    ProgressBar1.Value = 4;
                    ProgressBar1.Step = 1;

                    for (i = 0; i <= 5000; i++)
                    {
                        ProgressBar1.PerformStep();
                    }
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string ct = "select UserType from Registeration where UserId='" + txtUserId.Text + "' and Password='" + txtPassword.Text + "'";
                    cmd = new SqlCommand(ct);
                    cmd.Connection = con;
                    rdr = cmd.ExecuteReader();
                    if (rdr.Read())
                    {
                        txtUserType.Text = (rdr.GetString(0));
                    }
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                       
                    if (txtUserType.Text.Trim()== "Admin")
                    {
                        this.Hide();
                        frmMainMenu frm = new frmMainMenu();
                        frm.Show();
                        frm.lblUser.Text = txtUserId.Text;
                    }
                    if (txtUserType.Text.Trim() == "Cashier")
                    {
                        this.Hide();
                        frmMainMenu frm = new frmMainMenu();
                        frm.Show();
                        frm.lblUser.Text = txtUserId.Text;
                    }
                    if (txtUserType.Text.Trim() == "Customer")
                    {
                        this.Hide();
                        frmCustomerMainMenu frm1 = new frmCustomerMainMenu();                      
                        con = new SqlConnection(cs.DBConn);
                        con.Open();
                        cmd = con.CreateCommand();

                        cmd.CommandText = "SELECT CustomerId,CustomerName,TotalPoint,JoiningDate FROM Customer WHERE CustomerID = '" + txtUserId.Text.Trim() + "'";
                        rdr = cmd.ExecuteReader();

                        if (rdr.Read())
                        {
                            frm1.lblUser.Text = (rdr.GetString(0).Trim());
                            frm1.lblUserName.Text = (rdr.GetString(1).Trim());
                            frm1.lblTotalPoint.Text = (rdr.GetInt32(2).ToString().Trim());
                            frm1.lblJoinDate.Text = (rdr.GetDateTime(3).ToString());
                        }
                        frm1.Show();
                        if ((rdr != null))
                        {
                            rdr.Close();
                        }
                        if (con.State == ConnectionState.Open)
                        {
                            con.Close();
                        }
                    }
                    }
                

                else
                {
                    MessageBox.Show("Login is Failed...Try again !", "Login Denied", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    txtUserId.Clear();
                    txtPassword.Clear();
                    txtUserId.Focus();

                }
                if (myConnection.State == ConnectionState.Open)
                {
                    myConnection.Dispose();
                }

              

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
      
        private void Form1_Load(object sender, EventArgs e)
        {
            ProgressBar1.Visible = false;
            txtUserId.Focus();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
            
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Dispose();
            
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            frmChangePassword frm = new frmChangePassword();
            frm.Show();
            frm.txtUserName.Text = "";
            frm.txtNewPassword.Text = "";
            frm.txtOldPassword.Text = "";
            frm.txtConfirmPassword.Text = "";
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            frmRecoveryPassword frm = new frmRecoveryPassword();
            frm.txtEmail.Focus();
            frm.Show();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            frmCustomerRegistration frm = new frmCustomerRegistration();
            frm.txtUsername.Text = "";
            frm.txtPassword.Text = "";
            frm.txtAddress.Text = "";
            frm.txtContact_no.Text = "";
            frm.txtEmail_Address.Text = "";
            frm.txtUsername.Focus();
            frm.Show();

        }

    }
}
