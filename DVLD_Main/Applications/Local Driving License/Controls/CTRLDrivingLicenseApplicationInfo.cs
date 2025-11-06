using DVLD_Business;
using DVLD_Main.Licenses.Local_License;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;







namespace DVLD_Main.Applications.Local_Driving_License.Controls
{

    public partial class CTRLDrivingLicenseApplicationInfo : UserControl
    {

        private CLSLocalLicenseAppsBusiness _LocalDrivingLicenseApplication;

        private int _LocalDrivingLicenseApplicationID = -1;

        private int _LicenseID = -1;


        public int LocalDrivingLicenseApplicationID
        {

            get { return _LocalDrivingLicenseApplicationID; }

        }




        private void _ResetLocalDrivingLicenseApplicationInfo()
        {

            _LocalDrivingLicenseApplicationID = -1;

            lblLocalDrivingLicenseApplicationID.Text = "[????]";

            lblAppliedFor.Text = "[????]";


            ctrlApplicationBasicInfo1.ResetApplicationInfo();

        }

        private void _FillLocalDrivingLicenseApplicationInfo()
        {

            _LicenseID = _LocalDrivingLicenseApplication.GetActiveLicenseID();

            llShowLicenceInfo.Enabled = (_LicenseID != -1);


            lblLocalDrivingLicenseApplicationID.Text = _LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID.ToString();

            lblAppliedFor.Text = CLSLicenseClassBusiness.Find(_LocalDrivingLicenseApplication.LicenseClassID).ClassName;

            lblPassedTests.Text = _LocalDrivingLicenseApplication.GetPassedTestsCount().ToString() + "/3";


            ctrlApplicationBasicInfo1.LoadApplicationInfo(_LocalDrivingLicenseApplication.ApplicationID);

        }

        public void LoadApplicationInfoByApplicationID(int ApplicationID)
        {

            _LocalDrivingLicenseApplication = CLSLocalLicenseAppsBusiness.FindByApplicationID(ApplicationID);


            if (_LocalDrivingLicenseApplication == null)
            {
              
                _ResetLocalDrivingLicenseApplicationInfo();


                MessageBox.Show("No Application with ApplicationID = " + LocalDrivingLicenseApplicationID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
           
                return;
           
            }


            _FillLocalDrivingLicenseApplicationInfo();

        }

        public void LoadApplicationInfoByLocalDrivingAppID(int LocalDrivingLicenseApplicationID)
        {

            _LocalDrivingLicenseApplication = CLSLocalLicenseAppsBusiness.FindByApplicationID(LocalDrivingLicenseApplicationID);


            if (_LocalDrivingLicenseApplication == null)
            {
           
                _ResetLocalDrivingLicenseApplicationInfo();


                MessageBox.Show("No Application with ApplicationID = " + LocalDrivingLicenseApplicationID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
          
                return;
          
            }



            _FillLocalDrivingLicenseApplicationInfo();


        }




        public CTRLDrivingLicenseApplicationInfo()
        {
            InitializeComponent();
        }

        private void ctrlApplicationBasicInfo1_Load(object sender, EventArgs e)
        {



        }

        private void CTRLDrivingLicenseApplicationInfo_Load(object sender, EventArgs e)
        {





        }


        // يوجد جزء لم يكتمل هنا
        private void llShowLicenceInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            // FRMShowLicenseInfo frm = new FRMShowLicenseInfo(_LocalDrivingLicenseApplication.GetActiveLicenseID());


            // frm.ShowDialog();

        }



    }

}






