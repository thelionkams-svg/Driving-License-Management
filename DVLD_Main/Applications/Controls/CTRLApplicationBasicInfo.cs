using DVLD_Business;
using DVLD_Main.Global_Classes;
using DVLD_Main.People;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;






namespace DVLD_Main.Applications.Controls
{

    public partial class CTRLApplicationBasicInfo : UserControl
    {

        private CLSApplicationsBusiness _Application;

        private int _ApplicationID = -1;



        public int ApplicationID
        {

            get { return _ApplicationID; }

        }



        public void ResetApplicationInfo()
        {

            _ApplicationID = -1;


            lblApplicationID.Text = "[????]";

            lblStatus.Text = "[????]";

            lblType.Text = "[????]";

            lblFees.Text = "[????]";

            lblApplicant.Text = "[????]";

            lblDate.Text = "[????]";

            lblStatusDate.Text = "[????]";

            lblCreatedByUser.Text = "[????]";


        }

        private void _FillApplicationInfo()
        {

            _ApplicationID = _Application.ApplicationID;


            lblApplicationID.Text = _Application.ApplicationID.ToString();

            lblStatus.Text = _Application.AppStatusText;

            lblType.Text = _Application.ApplicationType.ApplicationTypeTitle;

            lblFees.Text = _Application.PaidFees.ToString();

            lblApplicant.Text = _Application.ApplicantFullName;

            lblDate.Text = CLSFormat.DateToShort(_Application.ApplicationDate);

            lblStatusDate.Text = CLSFormat.DateToShort(_Application.LastStatusDate);

            lblCreatedByUser.Text = _Application.CreatedByUserInfo.UserName;


        }

        public void LoadApplicationInfo(int ApplicationID)
        {

            _Application = CLSApplicationsBusiness.FindApplication(ApplicationID);


            if (_Application == null)
            {

                ResetApplicationInfo();

                MessageBox.Show("No Application with ApplicationID = " + ApplicationID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

            else
            {

                _FillApplicationInfo();

            }

        }




        public CTRLApplicationBasicInfo()
        {
            InitializeComponent();
        }

        private void CTRLApplicationBasicInfo_Load(object sender, EventArgs e)
        {



        }


        private void llViewPersonInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            FRMShowPersonInfo frm = new FRMShowPersonInfo(_Application.ApplicantPersonID);

            frm.ShowDialog();


            LoadApplicationInfo(ApplicationID);

        }




    }

}








