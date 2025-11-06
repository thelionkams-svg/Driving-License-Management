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




namespace DVLD_Main.Applications.Local_Driving_License
{

    public partial class FRMLocalDrivingLicenseApplicationInfo : Form
    {

        private int _ApplicationID = -1;


        public FRMLocalDrivingLicenseApplicationInfo(int ApplicationID)
        {

            InitializeComponent();


            _ApplicationID = ApplicationID;

        }

        private void FRMLocalDrivingLicenseApplicationInfo_Load(object sender, EventArgs e)
        {

            ctrlDrivingLicenseApplicationInfo1.LoadApplicationInfoByApplicationID(_ApplicationID);

        }


        private void btnClose_Click(object sender, EventArgs e)
        {

            this.Close();

        }


    }

}









