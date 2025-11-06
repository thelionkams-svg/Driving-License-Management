using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD_Business; 
using DVLD_Main.People.User_Controls; 
using DVLD_Main.Users2;  




namespace DVLD_Main.Users2
{

    public partial class FRMAddEditUser : Form
    {

        // تعريف واطلاق الحدث

        public delegate void UserSavedEventHandler(object sender, EventArgs e);

        public event UserSavedEventHandler UserSaved;

        protected virtual void OnUserSaved(EventArgs e)
        {

            UserSaved?.Invoke(this, e);

        }



        public enum enMode { AddNew = 0 , Update = 1}



        private enMode _Mode;

        private int _UserID = -1;

        private CLSUsersBusiness _User;




        private void _ResetDefaultValues()
        {

            if (_Mode == enMode.AddNew)
            {

                LBLTitle.Text = "Add New User";

                this.Text = "Add New User";


                _User = new CLSUsersBusiness();


                TPLoginInfo.Enabled = false;


                ctrlPersonCardWithFilter1.FilterFocus();

            }

            else
            {

                LBLTitle.Text = "Update User";

                this.Text = "Update User";


                TPLoginInfo.Enabled = true;

                BTNSave.Enabled = true;


            }


            TXTUserName.Text = "";

            TXTPassword.Text = "";

            TXTCPassword.Text = "";

            CHKIsActive.Checked = true;

        }

        private void _LoadData()
        {

            _User = CLSUsersBusiness.FindUserID(_UserID);


            ctrlPersonCardWithFilter1.FilterEnabled = false;


            if (_User == null)
            {

                MessageBox.Show("No User with ID = " + _UserID, "User Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                
                this.Close();

                return;

            }


            LBLUserID.Text = _User.UserID.ToString();

            TXTUserName.Text = _User.UserName;

            TXTPassword.Text = _User.Password;

            TXTCPassword.Text = _User.Password;

            CHKIsActive.Checked = _User.IsActive;


            ctrlPersonCardWithFilter1.LoadPersonInfo(_User.PersonID);

        }




        public FRMAddEditUser()
        {

            InitializeComponent();

            _Mode = enMode.AddNew;

        }

        public FRMAddEditUser(int UserID)
        {

            InitializeComponent();

            _UserID = UserID;

            _Mode = enMode.Update;


        }




        private void FRMAddEditUser_Load(object sender, EventArgs e)
        {

            _ResetDefaultValues();


            if (_Mode == enMode.Update)
            {

                _LoadData();

            }


        }



        private void BTNNext_Click(object sender, EventArgs e)
        {

            if (_Mode == enMode.Update)
            {

                BTNSave.Enabled = true;

                TPLoginInfo.Enabled = true;


                TCUserInfo.SelectedTab = TCUserInfo.TabPages["TPLoginInfo"];


                return;

            }


            if (ctrlPersonCardWithFilter1.PersonID != -1)
            {

                if (CLSUsersBusiness.IsPersonHasUser(ctrlPersonCardWithFilter1.PersonID))
                {

                    MessageBox.Show("Selected Person already has a user, choose another one.", "Select another Person", MessageBoxButtons.OK, MessageBoxIcon.Error);
                   
                    ctrlPersonCardWithFilter1.FilterFocus();

                }

                else
                {

                    BTNSave.Enabled = true;

                    TPLoginInfo.Enabled = true;

                    TCUserInfo.SelectedTab = TCUserInfo.TabPages["TPLoginInfo"];

                }

            }

            else
            {

                MessageBox.Show("Please Select a Person", "Select a Person", MessageBoxButtons.OK, MessageBoxIcon.Error);
               
                ctrlPersonCardWithFilter1.FilterFocus();

            }

        }


        private void BTNSave_Click(object sender, EventArgs e)
        {

            if (!this.ValidateChildren())
            {

                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro",
                          "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;

            }



            _User.PersonID = ctrlPersonCardWithFilter1.PersonID;

            if (_User.PersonID == -1)
            {
                MessageBox.Show("Please select a valid person before saving.", "Missing Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            _User.UserName = TXTUserName.Text.Trim();

            _User.Password = TXTPassword.Text.Trim();

            _User.IsActive = CHKIsActive.Checked;


            if (_User.Save())
            {

                LBLUserID.Text = _User.UserID.ToString();


                _Mode = enMode.Update;


                LBLTitle.Text = "Update User";

                this.Text = "Update User";


                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

            else
            {

                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }



        }

        private void BTNClose_Click_1(object sender, EventArgs e)
        {

            this.Close();

        }




        private void TXTUserName_Validating(object sender, CancelEventArgs e)
        {

            if (string.IsNullOrEmpty(TXTUserName.Text.Trim()))
            {

                e.Cancel = true;

                errorProvider1.SetError(TXTUserName, "Username cannot be blank");

                return;

            }

            else
            {

                errorProvider1.SetError(TXTUserName , null);

            }


            if (_Mode == enMode.AddNew)
            {

                if (CLSUsersBusiness.IsUserExist(TXTUserName.Text.Trim()))
                {

                    e.Cancel = true;

                    errorProvider1.SetError(TXTUserName, "username is used by another user");

                }

                else
                {

                    errorProvider1.SetError(TXTUserName, null);

                }

            }

            else
            {

                if (_User.UserName != TXTUserName.Text.Trim())
                {

                    if (CLSUsersBusiness.IsUserExist(TXTUserName.Text.Trim()))
                    {

                        e.Cancel = true;

                        errorProvider1.SetError(TXTUserName, "username is used by another user");

                        return;

                    }

                    else
                    {

                        errorProvider1.SetError(TXTUserName, null);

                    }

                }

            }

        }

        private void TXTPassword_Validating(object sender, CancelEventArgs e)
        {

            if (string.IsNullOrEmpty(TXTPassword.Text.Trim()))
            {

                e.Cancel = true;

                errorProvider1.SetError(TXTPassword, "Password cannot be blank");
           
            }

            else
            {

                errorProvider1.SetError(TXTPassword, null);

            }

        }

        private void TXTCPassword_Validating(object sender, CancelEventArgs e)
        {

            if (string.IsNullOrEmpty(TXTCPassword.Text.Trim()))
            {

                e.Cancel = true;

                errorProvider1.SetError(TXTCPassword, "Password cannot be blank");

            }

            else
            {

                errorProvider1.SetError(TXTCPassword, null);

            }

        }



        private void FRMAddEditUser_Activated(object sender, EventArgs e)
        {

            ctrlPersonCardWithFilter1.FilterFocus();

        }





    }

}











