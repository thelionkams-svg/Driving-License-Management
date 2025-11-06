using System;
using DVLD_Main.Properties;
using DVLD_Main.People;
using DVLD_Business;
using System.IO;
using System.Xml.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;





namespace DVLD_Main.People.User_Controls
{

    public partial class CTRLPersonCard : UserControl
    {


        private CLSPeopleBusiness _PersonInfo;

        private int _PersonID;



        public CLSPeopleBusiness PersonInfo
        {

            get { return _PersonInfo; }


        }

        public int PersonID
        {

            get { return _PersonID; }

        }



        public CTRLPersonCard()
        {
            InitializeComponent();
        }

        private void CTRLUserCard1_Load(object sender, EventArgs e)
        {

        }



        private void _LoadPersonImage()
        {

            if (_PersonInfo.Gendor == 0)
            {

                PBPersonImage.Image = Resources.Female_512;

            }

            else
            {


                PBPersonImage.Image = Resources.Female_512;

            }



            string ImagePath = _PersonInfo.ImagePath;


            if (ImagePath != "")

                if (File.Exists(ImagePath))
                {

                    PBPersonImage.ImageLocation = ImagePath;

                }

                else
                {

                    MessageBox.Show("Could not find this image: = " + ImagePath, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }

        }

        private void _FillPersonInfo()
        {

            LLEditPersonInfo.Enabled = true;


            _PersonID = _PersonInfo.PersonID;

            LBLPersonID.Text = _PersonInfo.PersonID.ToString();

            LBLNationalNo.Text = _PersonInfo.NationalNo;

            LBLName.Text = _PersonInfo.FullName;

            LBLGendor.Text = _PersonInfo.Gendor == 0 ? "Male" : "Female";

            LBLEmail.Text = _PersonInfo.Email;

            LBLPhone.Text = _PersonInfo.Phone;

            LBLDateBirth.Text = _PersonInfo.DateOfBirth.ToShortDateString();

            LBLCountry.Text = CLSCountryBusiness.Find(_PersonInfo.NationalityCountryID).CountryName;

            LBLAddress.Text = _PersonInfo.Address;


            _LoadPersonImage();


        }



        public void ResetPersonInfo()
        {

            _PersonID = -1;

            LBLPersonID.Text = "[????]";

            LBLNationalNo.Text = "[????]";

            LBLName.Text = "[????]";

            PBGendor.Image = Resources.Man_32;

            LBLGendor.Text = "[????]";

            LBLEmail.Text = "[????]";

            LBLPhone.Text = "[????]";

            LBLDateBirth.Text = "[????]";

            LBLCountry.Text = "[????]";

            LBLAddress.Text = "[????]";

            PBPersonImage.Image = Resources.Female_512;


        }



        public void LoadPersonInfo(int PersonID)
        {

            _PersonInfo = CLSPeopleBusiness.Find(PersonID);


            if (_PersonInfo == null)
            {

                ResetPersonInfo();

                MessageBox.Show("No Person with PersonID = " + PersonID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;

            }


            _FillPersonInfo();

        }

        public void LoadPersonInfo(string NationalNo)
        {

            _PersonInfo = CLSPeopleBusiness.Find(NationalNo);


            if (_PersonInfo == null)
            {

                ResetPersonInfo();

                MessageBox.Show("No Person with National No. = " + NationalNo.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
               
                return;
      
            }


            _FillPersonInfo();

        }



        private void LLEditPersonInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            FRMAddUpdatePerson FRM = new FRMAddUpdatePerson(_PersonID);

            FRM.ShowDialog();


            LoadPersonInfo(_PersonID);

        }





    }

}




