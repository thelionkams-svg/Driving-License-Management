using System;
using DVLD_Business;
using DVLD_Main.Global_Classes;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;






namespace DVLD_Main.Login_Screen
{

    public partial class FRMLoginScreen : Form
    {

        public FRMLoginScreen()
        {

            InitializeComponent();

        }

        private void LoginScreen_Load(object sender, EventArgs e)
        {

            string UserName = Properties.Settings.Default.UserName;

            string Password = Properties.Settings.Default.Password;


            if (!string.IsNullOrEmpty(UserName) && !string.IsNullOrEmpty(Password))
            {

                TXTUserName.Text = UserName;

                TXTPassword.Text = Password;

                CHKRememberMe.Checked = true;

            }

            else
            {

                CHKRememberMe.Checked = false;

            }


        }


        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {



        }


        private void BTNLogin_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(TXTUserName.Text.Trim()) || string.IsNullOrEmpty(TXTPassword.Text.Trim()))
            {

                MessageBox.Show("Please enter your Username and Password.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
                return;

            }


            CLSUsersBusiness User = CLSUsersBusiness.FindUserNameAndPassword(TXTUserName.Text.Trim(), TXTPassword.Text.Trim());


            if (User != null)
            {

                if (User.IsActive == false)
                {

                    MessageBox.Show("Your account is suspended. Please contact the administrator.", "Inactive Account", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                
                    return;

                }


                if (CHKRememberMe.Checked)
                {

                    CLSGlobal.RememberUserNameAndPassword(TXTUserName.Text.Trim(),TXTPassword.Text.Trim());


                }

                else
                {

                    CLSGlobal.RememberUserNameAndPassword("" , "");

                }


                CLSGlobal.CurrentUser = User;

                this.Hide();


                FRMMainForm frm = new FRMMainForm(this);

                frm.ShowDialog();


            }

            else
            {

                TXTUserName.Focus();

                MessageBox.Show("Invalid Username or Password.", "Invalid Credentials", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void BTNClose_Click(object sender, EventArgs e)
        {

            this.Close();

        }







    }

}










