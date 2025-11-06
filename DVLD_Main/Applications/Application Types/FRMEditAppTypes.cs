using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using DVLD_Business;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;







namespace DVLD_Main.Applications.Application_Types
{

    public partial class FRMEditAppTypes : Form
    {

        private int _ApplicationTypeID;

        private CLSAppTypesBusiness _ApplicationType;


        private void _LoadData()
        {

            _ApplicationType = CLSAppTypesBusiness.Find(this._ApplicationTypeID);


            if (_ApplicationType == null)
            {

                MessageBox.Show("Application Type Not Found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
               
                this.Close(); 
               
                return;

            }


            lblApplicationTypeID.Text = _ApplicationType.ApplicationTypeID.ToString();

            txtTitle.Text = _ApplicationType.ApplicationTypeTitle;

            txtFees.Text = _ApplicationType.ApplicationFees.ToString();

            _ApplicationType.Mode = CLSAppTypesBusiness.enMode.UpdateMode;

        }


        public FRMEditAppTypes(int ApplicationTypeID)
        {

            InitializeComponent();


            this._ApplicationTypeID = ApplicationTypeID;

        }

        private void FRMEditAppTypes_Load(object sender, EventArgs e)
        {

            _LoadData();

        }


        private void txtTitle_Validating(object sender, CancelEventArgs e)
        {

            if (string.IsNullOrWhiteSpace(txtTitle.Text.Trim()))
            {

                e.Cancel = true;
           
                errorProvider1.SetError(txtTitle, "Title is required and cannot be empty.");
          
            }

            else
            {

                errorProvider1.SetError(txtTitle, null);

            }

        }

        private void txtFees_Validating(object sender, CancelEventArgs e)
        {

            if (string.IsNullOrWhiteSpace(txtFees.Text.Trim()))
            {

                e.Cancel = true;

                errorProvider1.SetError(txtFees, "Fees is required and cannot be empty.");

                return;

            }

            if (!decimal.TryParse(txtFees.Text.Trim(), out decimal result))
            {
                e.Cancel = true;

                errorProvider1.SetError(txtFees, "Fees must be a valid number.");

            }

            else
            {

                errorProvider1.SetError(txtFees, null);

            }

        }


        private void btnSave_Click(object sender, EventArgs e)
        {

            if (!ValidateChildren())
            {

                MessageBox.Show("Some fields are not valid! Please put the mouse over the red icon(s) to see the error", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
             
                return;

            }


            _ApplicationType.ApplicationTypeTitle = txtTitle.Text.Trim();

            _ApplicationType.ApplicationFees = Convert.ToDecimal(txtFees.Text.Trim());


            if (_ApplicationType.Save())
            {

                MessageBox.Show("Data Saved Successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                _ApplicationType.Mode = CLSAppTypesBusiness.enMode.UpdateMode;

                this.Close();

            }

            else
            {
          
                MessageBox.Show("Error: Data Is Not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
          
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {

            this.Close();

        }


    }

}













