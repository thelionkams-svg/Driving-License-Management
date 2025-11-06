using DVLD_Buisness;
using DVLD_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;










namespace DVLD_Business
{

    public class CLSLocalLicenseAppsBusiness : CLSApplicationsBusiness
    {


        public enum enMode { AddNew = 0, Update = 1 };

        private enMode _Mode = enMode.AddNew;



        public CLSLicenseClassBusiness LicenseClassInfo { get; set; }

        public int LocalDrivingLicenseApplicationID { get; set; }

        public int LicenseClassID { get; set; }

        public string FullName
        {

            get { return CLSPeopleBusiness.Find(ApplicantPersonID).FullName; }

        }




        public CLSLocalLicenseAppsBusiness()
        {

            this.LocalDrivingLicenseApplicationID = -1;

            this.LicenseClassID = -1;

            // this.LicenseClassName = "";

            this._Mode = enMode.AddNew;

        }

        private CLSLocalLicenseAppsBusiness(int LocalDrivingLicenseApplicationID, int ApplicationID, int ApplicantPersonID, DateTime ApplicationDate,
            int ApplicationTypeID, enApplicationStatus ApplicationStatus, DateTime LastStatusDate, decimal PaidFees, int CreatedByUserID, int LicenseClassID)
        {

            this.LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;

            this.ApplicationID = ApplicationID;

            this.ApplicantPersonID = ApplicantPersonID;

            this.ApplicationDate = ApplicationDate;

            this.ApplicationTypeID = (int)ApplicationTypeID;

            this.ApplicationStatus = ApplicationStatus;

            this.LastStatusDate = LastStatusDate;

            this.PaidFees = PaidFees;

            this.CreatedByUserID = CreatedByUserID;

            this.LicenseClassID = LicenseClassID;

            this.LicenseClassInfo = CLSLicenseClassBusiness.Find(LicenseClassID);


            _Mode = enMode.Update;


        }





        private bool _AddNewLocalDrivingLicenseApplication()
        {

            this.LocalDrivingLicenseApplicationID = CLSLocalLicenseAppsData.AddNewLocalDrivingLicenseApplication(
                this.ApplicationID, this.LicenseClassID);

            return (this.LocalDrivingLicenseApplicationID != -1);

        }

        private bool _UpdateLocalDrivingLicenseApplication()
        {

            return CLSLocalLicenseAppsData.UpdateLocalDrivingLicenseApplication(this.LocalDrivingLicenseApplicationID, this.LicenseClassID);

        }

        public bool Save()
        {

            if (!base.Save())
            {

                return false;

            }


            switch (_Mode)
            {

                case enMode.AddNew:


                    if (_AddNewLocalDrivingLicenseApplication())
                    {

                        _Mode = enMode.Update;

                        return true;

                    }

                    else
                    {

                        return false;

                    }

                case enMode.Update:

                    return _UpdateLocalDrivingLicenseApplication();

                default:

                    return false;

            }

        }

        public bool Delete()
        {

            if (this.LocalDrivingLicenseApplicationID == -1)
                return false;


            if (!CLSLocalLicenseAppsData.DeleteLocalDrivingLicenseApplication(this.LocalDrivingLicenseApplicationID))
            {

                return false;

            }


            return base.Delete();

        }





        public static CLSLocalLicenseAppsBusiness FindByLocalDrivingAppLicenseID(int LocalDrivingLicenseApplicationID)
        {

            int ApplicationID = -1; int LicenseClassID = -1;


            if (CLSLocalLicenseAppsData.GetLocalDrivingLicenseApplicationInfoByID(LocalDrivingLicenseApplicationID, ref ApplicationID, ref LicenseClassID))
            {

                CLSApplicationsBusiness BaseApplication = CLSApplicationsBusiness.FindApplication(ApplicationID);


                if (BaseApplication == null)
                    return null;


                return new CLSLocalLicenseAppsBusiness(LocalDrivingLicenseApplicationID, BaseApplication.ApplicationID, BaseApplication.ApplicantPersonID,
                    BaseApplication.ApplicationDate, BaseApplication.ApplicationTypeID, BaseApplication.ApplicationStatus, BaseApplication.LastStatusDate,
                    BaseApplication.PaidFees, BaseApplication.CreatedByUserID, LicenseClassID);

            }

            else
            {

                return null;

            }

        }

        public static CLSLocalLicenseAppsBusiness FindByApplicationID(int ApplicationID)
        {

            int LocalDrivingLicenseApplicationID = -1; int LicenseClassID = -1;


            if (CLSLocalLicenseAppsData.GetLocalDrivingLicenseApplicationInfoByApplicationID(ApplicationID, ref LocalDrivingLicenseApplicationID, ref LicenseClassID))
            {

                CLSApplicationsBusiness BaseApplication = CLSApplicationsBusiness.FindApplication(ApplicationID);


                if (BaseApplication == null)
                    return null;


                return new CLSLocalLicenseAppsBusiness(LocalDrivingLicenseApplicationID, BaseApplication.ApplicationID, BaseApplication.ApplicantPersonID,
                    BaseApplication.ApplicationDate, BaseApplication.ApplicationTypeID, BaseApplication.ApplicationStatus, BaseApplication.LastStatusDate,
                    BaseApplication.PaidFees, BaseApplication.CreatedByUserID, LicenseClassID);

            }

            else
            {

                return null;

            }

        }


        public bool DoesAttendTestType(CLSTestsTypesBusiness.enTestType TestTypeID)
        {

            return CLSLocalLicenseAppsData.DoesAttendTestType(this.LocalDrivingLicenseApplicationID, (int)TestTypeID);

        }

        public static bool DoesAttendTestType(int LocalDrivingLicenseApplicationID, CLSTestsTypesBusiness.enTestType TestTypeID)
        {

            return CLSLocalLicenseAppsData.DoesAttendTestType(LocalDrivingLicenseApplicationID, (int)TestTypeID);

        }


        public bool DoesPassTestType(CLSTestsTypesBusiness.enTestType TestTypeID)
        {

            return CLSLocalLicenseAppsData.DoesPassTestType(this.LocalDrivingLicenseApplicationID, (int)TestTypeID);

        }

        public static bool DoesPassTestType(int LocalDrivingLicenseApplicationID, CLSTestsTypesBusiness.enTestType TestTypeID)
        {

            return CLSLocalLicenseAppsData.DoesPassTestType(LocalDrivingLicenseApplicationID, (int)TestTypeID);

        }


        public int TotalTrialsPerTest(CLSTestsTypesBusiness.enTestType TestTypeID)
        {

            return CLSLocalLicenseAppsData.TotalTrialsPerTest(this.LocalDrivingLicenseApplicationID, (int)TestTypeID);

        }

        public static int TotalTrialsPerTest(int LocalDrivingLicenseApplicationID, CLSTestsTypesBusiness.enTestType TestTypeID)
        {

            return CLSLocalLicenseAppsData.TotalTrialsPerTest(LocalDrivingLicenseApplicationID, (int)TestTypeID);

        }


        public bool IsThereAnActiveScheduledTest(CLSTestsTypesBusiness.enTestType TestTypeID)
        {

            return CLSLocalLicenseAppsData.IsThereAnActiveScheduledTest(this.LocalDrivingLicenseApplicationID, (int)TestTypeID);

        }

        public static bool IsThereAnActiveScheduledTest(int LocalDrivingLicenseApplicationID, CLSTestsTypesBusiness.enTestType TestTypeID)
        {

            return CLSLocalLicenseAppsData.IsThereAnActiveScheduledTest(LocalDrivingLicenseApplicationID, (int)TestTypeID);

        }





        public CLSTestBusiness GetLastTestPerTestType(CLSTestsTypesBusiness.enTestType TestTypeID)
        {

            return CLSTestBusiness.GetLastTest(this.ApplicantPersonID ,this.LicenseClassID,TestTypeID);

        }



        public byte GetPassedTestsCount()
        {

            return CLSTestBusiness.GetPassedTestsCount(this.ApplicantPersonID);

        }

        public static byte GetPassedTestsCount(int LocalDrivingLicenseApplicationID)
        {

            return CLSTestBusiness.GetPassedTestsCount(LocalDrivingLicenseApplicationID);

        }



        public bool IsPassedAllTests()
        {

            return CLSTestBusiness.IsPassedAllTests(this.ApplicantPersonID);

        }

        public static bool IsPassedAllTests(int LocalDrivingLicenseApplicationID)
        {

            return CLSTestBusiness.IsPassedAllTests(LocalDrivingLicenseApplicationID);

        }



        
         
        public int IssueLicenseForTheFirtTime(string Notes, int CreatedByUserID)
        {

            int DriverID = -1;


            CLSDriverBusiness Driver = CLSDriverBusiness.FindByPersonID(this.ApplicantPersonID);


            if (Driver == null)
            {

                Driver = new CLSDriverBusiness();
               

                Driver.PersonID= this.ApplicantPersonID;

                Driver.CreatedByUserID= CreatedByUserID;


                if (Driver.Save())
                {

                    DriverID= Driver.DriverID;
           
                }

                else
                {
                    return -1;

                }

            }

            else
            {

                DriverID= Driver.DriverID;

            }


            CLSLicenseBusiness License = new CLSLicenseBusiness();


            License.ApplicationID = this.ApplicationID;

            License.DriverID= DriverID;

            License.LicenseClassID = this.LicenseClassID;

            License.IssueDate=DateTime.Now;

            License.ExpirationDate = DateTime.Now.AddYears(this.LicenseClassInfo.DefaultValidityLength);
        
            License.Notes = Notes;
         
            License.PaidFees = this.LicenseClassInfo.ClassFees;
         
            License.IsActive= true;
          
            License.IssueReason = CLSLicenseBusiness.enIssueReason.FirstTime;
           
            License.CreatedByUserID= CreatedByUserID;


            if (License.Save())
            {

                this.SetComplete();


                return License.LicenseID;

            }
               
            else
                return -1;

        }

        public bool IsLicenseIssued()
        {

            return (GetActiveLicenseID() !=-1);
      
        }



        public int GetActiveLicenseID() { 

            return CLSLicenseBusiness.GetActiveLicenseIDByPersonID(this.ApplicantPersonID, this.LicenseClassID);
      
        }






        public static DataTable GetAllLocalDrivingLicenseApplications()
        {

            return CLSLocalLicenseAppsData.GetAllLocalDrivingLicenseApplications();

        }





    }

}








