using DVLD_Business;
using DVLD_DataAccess;
using System;
using System.Data;





namespace DVLD_Buisness
{

    public class CLSTestAppointment
    {

        public enum enMode { AddNew = 0, Update = 1 };

        public enMode Mode = enMode.AddNew;


        public int TestAppointmentID { set; get; }
        public int LocalDrivingLicenseApplicationID { set; get; }
        public DateTime AppointmentDate { set; get; }
        public float PaidFees { set; get; }
        public int CreatedByUserID { set; get; }
        public bool IsLocked { set; get; }
        public int RetakeTestApplicationID { set; get; }


        public CLSApplicationsBusiness RetakeTestAppInfo { set; get; }
        public CLSTestsTypesBusiness.enTestType TestTypeID { set; get; }


        public int TestID
        {

            get { return _GetTestID(); }

        }





        public CLSTestAppointment()
        {

            this.TestAppointmentID = -1;
            this.LocalDrivingLicenseApplicationID = -1;
            this.AppointmentDate = DateTime.Now;
            this.PaidFees = 0;
            this.CreatedByUserID = -1;
            this.IsLocked = false;
            this.RetakeTestApplicationID = -1;
            this.RetakeTestAppInfo = null;

            this.TestTypeID = CLSTestsTypesBusiness.enTestType.VisionTest;

            Mode = enMode.AddNew;

        }

        public CLSTestAppointment(int TestAppointmentID, CLSTestsTypesBusiness.enTestType TestTypeID, int LocalDrivingLicenseApplicationID,
            DateTime AppointmentDate, float PaidFees, int CreatedByUserID, bool IsLocked, int RetakeTestApplicationID)
        {

            this.TestAppointmentID = TestAppointmentID;
            this.TestTypeID = TestTypeID;
            this.LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            this.AppointmentDate = AppointmentDate;
            this.PaidFees = PaidFees;
            this.CreatedByUserID = CreatedByUserID;
            this.IsLocked = IsLocked;
            this.RetakeTestApplicationID = RetakeTestApplicationID;

            if (this.RetakeTestApplicationID != -1)
            {
           
                this.RetakeTestAppInfo = CLSApplicationsBusiness.FindApplication(this.RetakeTestApplicationID);
        
            }
        
            else
            {

                this.RetakeTestAppInfo = null;

            }

            Mode = enMode.Update;

        }





        private bool _AddNewTestAppointment()
        {

            int? OptionalRetakeID = (this.RetakeTestApplicationID == -1) ? (int?)null : this.RetakeTestApplicationID;

            this.TestAppointmentID = CLSTestAppointmentData.AddNewTestAppointment((int)this.TestTypeID, this.LocalDrivingLicenseApplicationID,
                this.AppointmentDate, this.PaidFees, this.CreatedByUserID, OptionalRetakeID);


            return (this.TestAppointmentID != -1);

        }

        private bool _UpdateTestAppointment()
        {

            int? OptionalRetakeID = (this.RetakeTestApplicationID == -1) ? (int?)null : this.RetakeTestApplicationID;


            return CLSTestAppointmentData.UpdateTestAppointment(this.TestAppointmentID, (int)this.TestTypeID, this.LocalDrivingLicenseApplicationID,
                this.AppointmentDate, this.PaidFees, this.CreatedByUserID, OptionalRetakeID);
       
        }

        public bool Save()
        {

            switch (Mode)
            {

                case enMode.AddNew:

                    if (_AddNewTestAppointment())
                    {

                        Mode = enMode.Update;

                        return true;

                    }

                    else
                    {

                        return false;

                    }

                case enMode.Update:

                    return _UpdateTestAppointment();

            }


            return false;

        }




        public static CLSTestAppointment Find(int TestAppointmentID)
        {

            int TestTypeID = -1; int LocalDrivingLicenseApplicationID = -1; DateTime AppointmentDate = DateTime.MinValue;

            float PaidFees = 0; int CreatedByUserID = -1; bool IsLocked = false; int? RetakeTestApplicationID = null;


            if (CLSTestAppointmentData.GetTestAppointmentInfoByID(TestAppointmentID, ref TestTypeID, ref LocalDrivingLicenseApplicationID,
                ref AppointmentDate, ref PaidFees, ref CreatedByUserID, ref IsLocked, ref RetakeTestApplicationID))
            {

                return new CLSTestAppointment(TestAppointmentID, (CLSTestsTypesBusiness.enTestType)TestTypeID, LocalDrivingLicenseApplicationID,
                 AppointmentDate, PaidFees, CreatedByUserID, IsLocked, RetakeTestApplicationID.GetValueOrDefault(-1));

            }

            else
            { 

                return null;

            }

        }

        public static CLSTestAppointment GetLastTestAppointment(int LocalDrivingLicenseApplicationID, CLSTestsTypesBusiness.enTestType TestTypeID)
        {

            int TestAppointmentID = -1; DateTime AppointmentDate = DateTime.MinValue; float PaidFees = 0;
         
            int CreatedByUserID = -1; bool IsLocked = false; int? RetakeTestApplicationID = null;


            if (CLSTestAppointmentData.GetLastTestAppointment(LocalDrivingLicenseApplicationID, (int)TestTypeID,
                ref TestAppointmentID, ref AppointmentDate, ref PaidFees, ref CreatedByUserID, ref IsLocked, ref RetakeTestApplicationID))
            {

                return new CLSTestAppointment(TestAppointmentID, TestTypeID, LocalDrivingLicenseApplicationID,

                    AppointmentDate, PaidFees, CreatedByUserID, IsLocked, RetakeTestApplicationID.GetValueOrDefault(-1));

            }

            else
            {

                return null;

            }

        }




        private int _GetTestID()
        {

            return CLSTestAppointmentData.GetTestID(this.TestAppointmentID);
       
        }

        public DataTable GetApplicationTestAppointmentsPerTestType(CLSTestsTypesBusiness.enTestType TestTypeID)
        {
      
            return CLSTestAppointmentData.GetApplicationTestAppointmentsPerTestType(this.LocalDrivingLicenseApplicationID, (int)TestTypeID);
       
        }




        public static DataTable GetApplicationTestAppointmentsPerTestType(int LocalDrivingLicenseApplicationID, CLSTestsTypesBusiness.enTestType TestTypeID)
        {
      
            return CLSTestAppointmentData.GetApplicationTestAppointmentsPerTestType(LocalDrivingLicenseApplicationID, (int)TestTypeID);
       
        }

        public static DataTable GetAllTestAppointments()
        {
    
            return CLSTestAppointmentData.GetAllTestAppointments();
     
        }
   



    }

}























