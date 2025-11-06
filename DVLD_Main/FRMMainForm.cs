using DVLD_Main.Applications.Application_Types;
using DVLD_Main.Applications.Local_Driving_License;
using DVLD_Main.Global_Classes;
using DVLD_Main.Login_Screen;
using DVLD_Main.People;
using DVLD_Main.Tests.Tests_Types;
using DVLD_Main.Users2;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;





namespace DVLD_Main
{

    public partial class FRMMainForm : Form
    {


        FRMLoginScreen _LoginScreen;



        public FRMMainForm(FRMLoginScreen frm)
        {

            InitializeComponent();

            _LoginScreen = frm;

        }

        private void FRMMainForm_Load(object sender, EventArgs e)
        {



        }



        private void peopleToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Form frm = new FRMListPeople();

            frm.ShowDialog();

        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Form form = new FRMListUsers();

            form.ShowDialog();


        }



        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {



        }

        private void applicationsToolStripMenuItem_Click(object sender, EventArgs e)
        {



        }



        private void currentUserInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {

            FRMUserInfo frm = new FRMUserInfo(CLSGlobal.CurrentUser.UserID);

            frm.ShowDialog();

        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {

            FRMChangePassword frm = new FRMChangePassword(CLSGlobal.CurrentUser.UserID);

            frm.ShowDialog();

        }

        private void signOutToolStripMenuItem_Click(object sender, EventArgs e)
        {

            CLSGlobal.CurrentUser = null;

            _LoginScreen.Show();

            this.Close();

        }



        private void manageApplicationsTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {

            FRMListAppTypes FRM = new FRMListAppTypes();

            FRM.ShowDialog();

        }

        private void manageTestsTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {

            FRMListTestsTypes FRM = new FRMListTestsTypes();

            FRM.ShowDialog();

        }



        private void localDrivingLinecesApplicationsToolStripMenuItem_Click(object sender, EventArgs e)
        {

            FRMListLocalDrivingLicesnseApplications FRM = new FRMListLocalDrivingLicesnseApplications();

            FRM.ShowDialog();

        }

        private void localLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {

            FRMAddUpdateLocalDrivingLicesnseApplication FRM = new FRMAddUpdateLocalDrivingLicesnseApplication();

            FRM.ShowDialog();

        }










    }

}









