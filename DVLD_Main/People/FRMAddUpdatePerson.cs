using DVLD_Business;
using DVLD_Main.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using System.Runtime.ConstrainedExecution;
using System.Text.RegularExpressions;
using DVLD_Main.Global_Classes;







namespace DVLD_Main.People
{

    public partial class FRMAddUpdatePerson : Form
    {


        public delegate void DataBackEventHandler(object sender , int PersonID);

        public event DataBackEventHandler DataBack;




        public enum enMode { AddNew = 0, Update = 1 };

        public enum enGendor { Male = 0 , Female = 1};





        private CLSPeopleBusiness _person;

        private int _personID = -1;

        private enMode _Mode;




        private void _FillCountriesInComboBox()
        {

            DataTable dtCountries = CLSCountryBusiness.GetAllCountries();



            foreach (DataRow Row in dtCountries.Rows)
            {

                cbCountry.Items.Add(Row["CountryName"]);

            }

        }

        private bool _HandlePersonImage()
        {

            if (_person.ImagePath != PBPersonImage.ImageLocation)
            {

                if (_person.ImagePath != "")
                {

                    try
                    {

                        File.Delete(_person.ImagePath);

                    }

                    catch (IOException)
                    {


                    }

                }


                // الجزء الخاص بتنظيم مسار الصور يجب اتمامه بعد اتمام صفحة الدوال المشتركة

                

                if (PBPersonImage.ImageLocation != null)
                {

                    string SourceImageFile = PBPersonImage.ImageLocation.ToString();


                    if (CLSUtil.CopyImageToProjectImagesFolder(ref SourceImageFile))
                    {

                        PBPersonImage.ImageLocation = SourceImageFile;

                        return true;
                    }

                    else
                    {

                        MessageBox.Show("Error Copying Image File", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        return false;

                    }

                }


            }


            return true;

        }


        private void _ResetDefaultValues()
        {


            _FillCountriesInComboBox();



            if (_Mode == enMode.AddNew)
            {

                LBLTitle.Text = "Add New Person";

                _person = new CLSPeopleBusiness();

            }

            else
            {

                LBLTitle.Text = "Update Person";

            }



            if (rbMale.Checked)
            {

                PBPersonImage.Image = Resources.Female_512;

            }

            else
            {

                PBPersonImage.Image= Resources.Female_512;

            }



            llRemoveImage.Visible = (PBPersonImage.ImageLocation != null);



            dtpDateOfBirth.MaxDate = DateTime.Now.AddYears(-18);

            dtpDateOfBirth.Value = dtpDateOfBirth.MaxDate;

            dtpDateOfBirth.MinDate = DateTime.Now.AddYears(-100);



            cbCountry.SelectedIndex = cbCountry.FindString("Egypt");



            txtFirstName.Text = ""; 

            txtSecondName.Text = "";

            txtThirdName.Text = "";

            txtLastName.Text = "";

            txtNationalNo.Text = "";

            rbMale.Checked = true;

            txtPhone.Text = "";

            txtEmail.Text = "";

            txtAddress.Text = "";




        }

        private void _LoadData()
        {

            _person = CLSPeopleBusiness.Find(_personID);


            if (_person == null)
            {

                MessageBox.Show("No Person with ID = " + _personID, "Person Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                
                this.Close();
                
                return;

            }


            LBLPersonID.Text = _personID.ToString();

            txtFirstName.Text = _person.FirstName;

            txtSecondName.Text = _person.SecondName;

            txtThirdName.Text = _person.ThirdName;

            txtLastName.Text = _person.LastName;

            txtNationalNo.Text = _person.NationalNo;

            dtpDateOfBirth.Value = _person.DateOfBirth;


            if (_person.Gendor == 0)
            {

                rbMale.Checked = true;

            }

            else
            {

                rbFemale.Checked = true;

            }


            txtAddress.Text = _person.Address;

            txtPhone.Text = _person.Phone;

            txtEmail.Text = _person.Email;

            cbCountry.SelectedIndex = cbCountry.FindString(_person.CountryInfo.CountryName);

            llRemoveImage.Visible = (_person.ImagePath != "");

            if (_person.ImagePath != "")
            {

                PBPersonImage.ImageLocation = _person.ImagePath;

            }








        }


        private void ValidateEmptyTextBox(object sender, CancelEventArgs e)
        {

            TextBox Temp = ((TextBox)sender);


            if (string.IsNullOrEmpty(Temp.Text.Trim()))
            {

                e.Cancel = true;

                errorProvider1.SetError(Temp, "This field is required!");

            }

            else
            {

                errorProvider1.SetError(Temp, null);

            }

        }






        public FRMAddUpdatePerson()
        {

            InitializeComponent();

        }

        public FRMAddUpdatePerson(int PersonID)
        {

            InitializeComponent();

            _Mode = enMode.Update;

            _personID = PersonID;


        }



        private void FRMAddUpdatePerson_Load(object sender, EventArgs e)
        {

            _ResetDefaultValues();


            if (_Mode == enMode.Update)
            {

                _LoadData();

            }

        }



        private void btnSave_Click(object sender, EventArgs e)
        {

            if (!this.ValidateChildren())
            {

                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;

            }

            if (!_HandlePersonImage())
            {

                return;

            }



            int NationalityCountryID = CLSCountryBusiness.Find(cbCountry.Text).ID;

            _person.FirstName = txtFirstName.Text.Trim();
            _person.SecondName = txtSecondName.Text.Trim();
            _person.ThirdName = txtThirdName.Text.Trim();
            _person.LastName = txtLastName.Text.Trim();
            _person.NationalNo = txtNationalNo.Text.Trim();
            _person.Email = txtEmail.Text.Trim();
            _person.Phone = txtPhone.Text.Trim();
            _person.Address = txtAddress.Text.Trim();
            _person.DateOfBirth = dtpDateOfBirth.Value;


            if (rbMale.Checked)

                _person.Gendor = (short)enGendor.Male;
            else
                _person.Gendor = (short)enGendor.Female;


            _person.NationalityCountryID = NationalityCountryID;


            if (PBPersonImage.ImageLocation != null)

                _person.ImagePath = PBPersonImage.ImageLocation;
            else
                _person.ImagePath = "";



            if (_person.Save())
            {

                LBLPersonID.Text = _person.PersonID.ToString();

                _Mode = enMode.Update;

                LBLTitle.Text = "Update Person";


                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);



                DataBack?.Invoke(this, _person.PersonID);

            }

            else

                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);




        }



        private void llSetImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";

            openFileDialog1.FilterIndex = 1;

            openFileDialog1.RestoreDirectory = true;


            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {

                string selectedFilePath = openFileDialog1.FileName;

                PBPersonImage.Load(selectedFilePath);

                llRemoveImage.Visible = true;

            }

        }

        private void llRemoveImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            PBPersonImage.ImageLocation = null;



            if (rbMale.Checked)

                PBPersonImage.Image = Resources.Female_512;

            else

                PBPersonImage.Image = Resources.Female_512;


            llRemoveImage.Visible = false;

        }



        private void rbMale_CheckedChanged(object sender, EventArgs e)
        {

            if (PBPersonImage.ImageLocation == null)

                PBPersonImage.Image = Resources.Female_512;

        }

        private void rbFemale_CheckedChanged(object sender, EventArgs e)
        {

            if (PBPersonImage.ImageLocation == null)

                PBPersonImage.Image = Resources.Female_512;

        }



        private void txtEmail_TextChanged(object sender, CancelEventArgs e)
        {

            if (txtEmail.Text.Trim() == "")

                return;


            // الجزء الخاص بوضع ايميل صحيح يتم ضبطه بعد ضبط الدوال المشتركة

            

            if (!CLSValidation.ValidateEmail(txtEmail.Text))
            {

                e.Cancel = true;

                errorProvider1.SetError(txtEmail, "Invalid Email Address Format!");

            }

            else
            {

                errorProvider1.SetError(txtEmail, null);

            };

            

        }

        private void txtNationalNo_Validating(object sender, CancelEventArgs e)
        {

            if (string.IsNullOrEmpty(txtNationalNo.Text.Trim()))
            {

                e.Cancel = true;

                errorProvider1.SetError(txtNationalNo, "This field is required!");

                return;

            }

            else
            {

                errorProvider1.SetError(txtNationalNo, null);

            }


            if (txtNationalNo.Text.Trim() != _person.NationalNo && CLSPeopleBusiness.IsPersonExist(txtNationalNo.Text.Trim()))
            {

                e.Cancel = true;

                errorProvider1.SetError(txtNationalNo, "National Number is used for another person!");

            }

            else
            {

                errorProvider1.SetError(txtNationalNo, null);

            }


        }









    }

}



