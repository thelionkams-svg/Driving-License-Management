using DVLD_Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;





namespace DVLD_Main.Users2
{

    public partial class FRMChangePassword : Form
    {

        int _UserID = -1;

        CLSUsersBusiness _User;



        private void _ResetDefaultValues()
        {

            TXTCurrentPassword.Text = "";

            TXTNewPassword.Text = "";

            TXTCNewPassword.Text = "";


            TXTCurrentPassword.Focus();

        }



        public FRMChangePassword(int userID)
        {

            InitializeComponent();

            _UserID = userID;

        }

        private void FRMChangePassword_Load(object sender, EventArgs e)
        {

            _ResetDefaultValues();


            _User = CLSUsersBusiness.FindUserID(_UserID);


            if (_User == null)
            {

                MessageBox.Show("Could not Find User with id = " + _UserID, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                this.Close();


                return;

            }


            ctrlUserCard1.LoadUserInfo(_UserID);

        }



        private void TXTCurrentPassword_Validating(object sender, CancelEventArgs e)
        {

            if (string.IsNullOrEmpty(TXTCurrentPassword.Text.Trim()))
            {

                e.Cancel = true;

                errorProvider1.SetError(TXTCurrentPassword, "Username cannot be blank");


                return;

            }

            else
            {
                errorProvider1.SetError(TXTCurrentPassword, null);

            }


            if (_User.Password != TXTCurrentPassword.Text.Trim())
            {

                e.Cancel = true;

                errorProvider1.SetError(TXTCurrentPassword, "Current password is wrong!");

                return;

            }

            else
            {

                errorProvider1.SetError(TXTCurrentPassword, null);

            }

        }

        private void TXTNewPassword_Validating(object sender, CancelEventArgs e)
        {

            if (string.IsNullOrEmpty(TXTNewPassword.Text.Trim()))
            {

                e.Cancel = true;

                errorProvider1.SetError(TXTNewPassword, "New Password cannot be blank");

            }

            else
            {

                errorProvider1.SetError(TXTNewPassword, null);

            }

        }

        private void TXTCNewPassword_Validating(object sender, CancelEventArgs e)
        {

            if (TXTCNewPassword.Text.Trim() != TXTNewPassword.Text.Trim())
            {

                e.Cancel = true;

                errorProvider1.SetError(TXTCNewPassword, "Password Confirmation does not match New Password!");

            }

            else
            {

                errorProvider1.SetError(TXTCNewPassword, null);

            }

        }



        private void BTNSave_Click(object sender, EventArgs e)
        {

            if (!ValidateChildren())
            {

                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;

            }


            _User.Password = TXTNewPassword.Text;


            if (_User.Save())
            {

                MessageBox.Show("Password Changed Successfully.", "Saved.", MessageBoxButtons.OK, MessageBoxIcon.Information);

                _ResetDefaultValues();

            }

            else
            {

                MessageBox.Show("An Erro Occured, Password did not change.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void BTNClose_Click(object sender, EventArgs e)
        {

            this.Close();

        }


    }

}















