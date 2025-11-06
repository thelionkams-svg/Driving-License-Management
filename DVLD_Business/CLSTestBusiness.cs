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

    public class CLSTestBusiness
    {


        public enum enMode { AddNew = 0, Update = 1 };

        public enMode Mode { get; set; } = enMode.AddNew;



        public int TestID { get; set; }

        public int TestAppointmentID { get; set; }

        public bool TestResult { get; set; }

        public string Notes { get; set; }

        public int CreatedByUserID { get; set; }

 
        public CLSTestAppointment TestAppointmentInfo { get; set; }




        public CLSTestBusiness()
        {

            this.TestID = -1;

            this.TestAppointmentID = -1;

            this.TestResult = false; 

            this.Notes = "";

            this.CreatedByUserID = -1;

            this.TestAppointmentInfo = null;
            

            this.Mode = enMode.AddNew;

        }

        private CLSTestBusiness(int TestID, int TestAppointmentID, bool TestResult, string Notes, int CreatedByUserID)
        {

            this.TestID = TestID;

            this.TestAppointmentID = TestAppointmentID;

            this.TestResult = TestResult;

            this.Notes = Notes;

            this.CreatedByUserID = CreatedByUserID;

            this.TestAppointmentInfo = null;


            this.Mode = enMode.Update;

        }



        public static CLSTestBusiness Find(int TestID)
        {

            int TestAppointmentID = -1; bool TestResult = false; string Notes = ""; int CreatedByUserID = -1;


            if (CLSTestData.GetTestInfoByID(TestID, ref TestAppointmentID, ref TestResult, ref Notes, ref CreatedByUserID))
            {

                CLSTestBusiness Test = new CLSTestBusiness(TestID, TestAppointmentID, TestResult, Notes, CreatedByUserID);

                return Test;

            }

            else
            {

                return null;

            }

        }

        public static CLSTestBusiness GetLastTest(int PersonID, int LicenseClassID, CLSTestsTypesBusiness.enTestType TestTypeID)
        {

            int TestID = -1; int TestAppointmentID = -1; bool TestResult = false; string Notes = ""; int CreatedByUserID = -1;


            if (CLSTestData.GetLastTestByPersonAndTestTypeAndLicenseClass(PersonID, LicenseClassID, (int)TestTypeID,
                ref TestID, ref TestAppointmentID, ref TestResult, ref Notes, ref CreatedByUserID))
            {

                CLSTestBusiness Test = new CLSTestBusiness(TestID, TestAppointmentID, TestResult, Notes, CreatedByUserID);

                return Test;

            }

            else
            {

                return null;

            }

        }


        public static byte GetPassedTestsCount(int LocalDrivingLicenseApplicationID)
        {

            return CLSTestData.GetPassedTestCount(LocalDrivingLicenseApplicationID);

        }

        public static bool IsPassedAllTests(int LocalDrivingLicenseApplicationID)
        {

            return (GetPassedTestsCount(LocalDrivingLicenseApplicationID) == 3);

        }




        private bool _AddNewTest()
        {

            this.TestID = CLSTestData.AddNewTest( this.TestAppointmentID, this.TestResult, this.Notes, this.CreatedByUserID );

            return (this.TestID != -1);

        }

        private bool _UpdateTest()
        {

            return CLSTestData.UpdateTest( this.TestID, this.TestResult, this.Notes, this.CreatedByUserID );

        }

        public bool Save()
        {

            switch (Mode)
            {

                case enMode.AddNew:

                    if (_AddNewTest())
                    {

                        Mode = enMode.Update;

                        return true;

                    }

                    else
                    {

                        return false;

                    }

                case enMode.Update:

                            return _UpdateTest();


                default:

                            return false;

            }

        }





        public static DataTable GetAllTests()
        {

            return CLSTestData.GetAllTests();

        }


    }

}




















