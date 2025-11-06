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



namespace DVLD_Main.Tests.Tests_Types
{

    public partial class FRMEditTestType : Form
    {

        private int _TestTypeID;

        private CLSTestsTypesBusiness _TestType;


        private void _LoadData()
        {


            if (_TestType == null)
            {

                MessageBox.Show("Application Type Not Found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                this.Close();

                return;

            }


            lblTestTypeID.Text = _TestType.TestTypeID.ToString();

            txtTitle.Text = _TestType.TestTypeTitle.ToString();

            txtDescription.Text = _TestType.TestTypeDescription.ToString();

            txtFees.Text = _TestType.TestTypeFees.ToString();


            _TestType.Mode = CLSTestsTypesBusiness.enMode.UpdateMode;

        }


        public FRMEditTestType(int TestType)
        {

            InitializeComponent();

            this._TestTypeID = TestType;

        }

        private void FRMEditTestType_Load(object sender, EventArgs e)
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

        private void txtDescription_Validating(object sender, CancelEventArgs e)
        {

            if (string.IsNullOrWhiteSpace(txtDescription.Text.Trim()))
            {

                e.Cancel = true;

                errorProvider1.SetError(txtDescription, "Description is required and cannot be empty.");

            }

            else
            {

                errorProvider1.SetError(txtDescription, null);

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

            
            _TestType.TestTypeTitle = txtTitle.Text;

            _TestType.TestTypeDescription = txtDescription.Text;

            _TestType.TestTypeFees = Convert.ToDecimal(txtFees.Text.Trim());


            if (_TestType.Save())
            {

                MessageBox.Show("Data Saved Successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);


                _TestType.Mode = CLSTestsTypesBusiness.enMode.UpdateMode;


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






