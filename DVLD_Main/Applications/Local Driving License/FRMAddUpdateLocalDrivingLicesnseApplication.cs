using DVLD_Buisness;
using DVLD_Business;
using DVLD_Main.Global_Classes;
using DVLD_Main.People.User_Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;




namespace DVLD_Main.Applications.Local_Driving_License
{

    public partial class FRMAddUpdateLocalDrivingLicesnseApplication : Form
    {

        public enum enMode { AddNew = 0 , Update = 1 }

        private enMode _Mode;


        private int _SelectedPersonID = -1;

        private int _LocalDrivingLicenseApplicationID = -1;


        CLSLocalLicenseAppsBusiness _LocalDrivingLicenseApplication;



        private void _FillLicenseClassesInComoboBox()
        {

            DataTable dtLicenseClasses = CLSLicenseClassBusiness.GetAllLicenseClasses();

            foreach (DataRow Row in dtLicenseClasses.Rows)
            {

                cbLicenseClass.Items.Add(Row["ClassName"]);

            }

        }

        private void _ResetDefualtValues()
        {

            _FillLicenseClassesInComoboBox();


            if (_Mode == enMode.AddNew)
            {

                lblTitle.Text = "New Local Driving License Application";

                this.Text = "New Local Driving License Application";


                _LocalDrivingLicenseApplication = new CLSLocalLicenseAppsBusiness();

                ctrlPersonCardWithFilter1.FilterFocus();

                tpApplicationInfo.Enabled = false;


                cbLicenseClass.SelectedIndex = 2;

                lblFees.Text = CLSAppTypesBusiness.Find((int)CLSApplicationsBusiness.enApplicationType.NewDrivingLicense).ApplicationFees.ToString();

                lblApplicationDate.Text = DateTime.Now.ToShortDateString();

                lblCreatedByUser.Text = CLSGlobal.CurrentUser.UserName;

            }

            else
            {

                lblTitle.Text = "Update Local Driving License Application";

                this.Text = "Update Local Driving License Application";


                tpApplicationInfo.Enabled = true;

                btnSave.Enabled = true;

            }

        }

        private void _LoadData()
        {

            ctrlPersonCardWithFilter1.FilterEnabled = false;

            _LocalDrivingLicenseApplication = CLSLocalLicenseAppsBusiness.FindByApplicationID(_LocalDrivingLicenseApplicationID);


            if (_LocalDrivingLicenseApplication == null)
            {

                MessageBox.Show("No Application with ID = " + _LocalDrivingLicenseApplicationID, "Application Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                this.Close();


                return;

            }


            ctrlPersonCardWithFilter1.LoadPersonInfo(_LocalDrivingLicenseApplication.ApplicantPersonID);

            lblLocalDrivingLicebseApplicationID.Text = _LocalDrivingLicenseApplication.ApplicationID.ToString();

            lblApplicationDate.Text = CLSFormat.DateToShort(_LocalDrivingLicenseApplication.ApplicationDate);

            cbLicenseClass.SelectedIndex = cbLicenseClass.FindString(CLSLicenseClassBusiness.Find(_LocalDrivingLicenseApplication.LicenseClassID).ClassName);

            lblFees.Text = _LocalDrivingLicenseApplication.PaidFees.ToString();

            lblCreatedByUser.Text = CLSUsersBusiness.FindUserID(_LocalDrivingLicenseApplication.CreatedByUserID).UserName;

        }


        private void DataBackEvent(object Sender , int PersonID)
        {

            _SelectedPersonID = PersonID;

            ctrlPersonCardWithFilter1.LoadPersonInfo(PersonID);

        }

        private void ctrlPersonCardWithFilter1_OnPersonSelected(int obj)
        {

            _SelectedPersonID = obj;

        }




        public FRMAddUpdateLocalDrivingLicesnseApplication()
        {

            InitializeComponent();

            _Mode = enMode.AddNew;

        }

        public FRMAddUpdateLocalDrivingLicesnseApplication(int LocalDrivingLicenseApplicationID)
        {

            InitializeComponent();

            _Mode = enMode.Update;

            _LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;

        }


        private void FRMAddUpdateLocalDrivingLicesnseApplication_Load(object sender, EventArgs e)
        {

            _ResetDefualtValues();

            if (_Mode == enMode.Update)
            {

                _LoadData();

            }

        }



        private void btnApplicationInfoNext_Click(object sender, EventArgs e)
        {

            if (_Mode == enMode.Update)
            {

                btnSave.Enabled = true;
             
                tpApplicationInfo.Enabled = true;
            
                tcApplicationInfo.SelectedTab = tcApplicationInfo.TabPages["tpApplicationInfo"];
             
                
                return;

            }


            if (ctrlPersonCardWithFilter1.PersonID != -1)
            {

                btnSave.Enabled = true;
            
                tpApplicationInfo.Enabled = true;
            
                tcApplicationInfo.SelectedTab = tcApplicationInfo.TabPages["tpApplicationInfo"];

            }

            else
            {

                MessageBox.Show("Please Select a Person", "Select a Person", MessageBoxButtons.OK, MessageBoxIcon.Error);
               
                ctrlPersonCardWithFilter1.FilterFocus();

            }

        }


        private void btnSave_Click(object sender, EventArgs e)
        {

            if (!this.ValidateChildren())
            {

                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
             
                return;

            }


            int LicenseClassID = CLSLicenseClassBusiness.Find(cbLicenseClass.Text).LicenseClassID;

            int ActiveApplicationID = CLSApplicationsBusiness.GetActiveApplicationIDForLicenseClass(_SelectedPersonID,

                CLSApplicationsBusiness.enApplicationType.NewDrivingLicense, LicenseClassID);


            if (ActiveApplicationID != -1)
            {

                MessageBox.Show("Choose another License Class, the selected Person Already have an active application for the selected class with id=" + ActiveApplicationID, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            
                cbLicenseClass.Focus();
             
                return;

            }

            if (CLSLicenseBusiness.IsLicenseExistByPersonID(ctrlPersonCardWithFilter1.PersonID , LicenseClassID))
            {

                MessageBox.Show("Person already have a license with the same applied driving class, " + "Choose diffrent driving class",
                    
                    "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
              
                return;

            }


            _LocalDrivingLicenseApplication.ApplicantPersonID = ctrlPersonCardWithFilter1.PersonID; ;

            _LocalDrivingLicenseApplication.ApplicationDate = DateTime.Now;

            _LocalDrivingLicenseApplication.ApplicationTypeID = 1;

            _LocalDrivingLicenseApplication.ApplicationStatus = CLSApplicationsBusiness.enApplicationStatus.New;
        
            _LocalDrivingLicenseApplication.LastStatusDate = DateTime.Now;
         
            _LocalDrivingLicenseApplication.PaidFees = Convert.ToDecimal(lblFees.Text);
          
            _LocalDrivingLicenseApplication.CreatedByUserID = CLSGlobal.CurrentUser.UserID;
          
            _LocalDrivingLicenseApplication.LicenseClassID = LicenseClassID;


            if (_LocalDrivingLicenseApplication.Save())
            {

                lblLocalDrivingLicebseApplicationID.Text = _LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID.ToString();

                _Mode = enMode.Update;


                lblTitle.Text = "Update Local Driving License Application";

                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);


            }

            else
            {

                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }




        private void FRMAddUpdateLocalDrivingLicesnseApplication_Activated(object sender, EventArgs e)
        {

            ctrlPersonCardWithFilter1.FilterFocus();

        }








        /*


                    int SelectedPersonID = -1;


        public FRMAddUpdateLocalDrivingLicesnseApplication()
        {

            InitializeComponent();

        }

        private void FRMAddUpdateLocalDrivingLicesnseApplication_Load(object sender, EventArgs e)
        {





        }


        private void btnApplicationInfoNext_Click(object sender, EventArgs e)
        {

            SelectedPersonID = ctrlPersonCardWithFilter1.PersonID;


            if (SelectedPersonID == -1)
            {

                MessageBox.Show("Please select a person first.", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
              
                return;

            }


            CLSApplicationsBusiness AppBusiness = new CLSApplicationsBusiness();


            if (AppBusiness.DoesPersonHaveActiveApplication(SelectedPersonID))
            {

                MessageBox.Show("This person already has an active local driving license application. You cannot create a new one.",

                "Duplicate Application", MessageBoxButtons.OK, MessageBoxIcon.Error);


                return;

            }


            tcApplicationInfo.SelectedTab = tpApplicationInfo;

            btnApplicationInfoNext.Enabled = false;

            btnSave.Enabled = true;




            lblApplicationDate.Text = DateTime.Now.ToString("dd/MM/yyyy");

            lblFees.Text = "15";

            lblCreatedByUser.Text = "A12";


            cbLicenseClass.Items.AddRange(new string[]
            {

                "Class 1 : Small Motorcycle License", "Class 2 : Heavy Motorcycle License", "Class 3 : Ordinary Driving License", 
                
                "Class 4 : Comercial", "Class 5 : Agricultal", "Class 6 : Small And Medium Bus", "Class 7 : Truck And Heavy Vehicles"

            });


            cbLicenseClass.SelectedIndex = 0;


        }


        private void btnSave_Click(object sender, EventArgs e)
        {

            if (CLSLocalLicenseAppsBusiness.DoesPersonHaveActiveApplication(SelectedPersonID, 1))
            {

                MessageBox.Show("This person already has an active local driving license application.", "Duplicate Application", MessageBoxButtons.OK, MessageBoxIcon.Warning);
               
                return;

            }


            CLSLocalLicenseAppsBusiness LocalApp = new CLSLocalLicenseAppsBusiness();


            LocalApp.ApplicantPersonID = SelectedPersonID;

            LocalApp.ApplicationDate = DateTime.Now;

            LocalApp.ApplicationTypeID = 1;

            LocalApp.ApplicationStatus = CLSApplicationsBusiness.enApplicationStatus.New;

            LocalApp.LastStatusDate = DateTime.Now;

            LocalApp.PaidFees = Convert.ToDecimal(lblFees.Text);

            LocalApp.CreatedByUserID = 1; // رقم المستخدم الحالي

            LocalApp.LicenseClassID = cbLicenseClass.SelectedIndex + 1; // أو القيمة الفعلية من قاعدة البيانات


            if (LocalApp.Save())
            {
          
                MessageBox.Show("Application saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
          
                this.DialogResult = DialogResult.OK;

                this.Close();

            }

            else
            {
      
                MessageBox.Show("Error saving the application.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
     
            }

        }



        */




    }

}







