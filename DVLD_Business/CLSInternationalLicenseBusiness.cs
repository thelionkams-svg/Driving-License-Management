using DVLD_Business;
using DVLD_DataAccess;
using System;
using System.Data;
using static DVLD_Business.CLSApplicationsBusiness;









namespace DVLD_Buisness
{

    public class CLSInternationalLicenseBusiness : CLSApplicationsBusiness
    {

        public enum enMode { AddNew = 0, Update = 1 };

        public enMode Mode = enMode.AddNew;


        public CLSDriverBusiness DriverInfo;


        public int InternationalLicenseID { set; get; }
        public int DriverID { set; get; }
        public int IssuedUsingLocalLicenseID { set; get; }
        public DateTime IssueDate { set; get; }
        public DateTime ExpirationDate { set; get; }
        public bool IsActive { set; get; }






        public CLSInternationalLicenseBusiness()
        {

            this.ApplicationTypeID = (int)CLSApplicationsBusiness.enApplicationType.NewInternationalLicense;


            this.InternationalLicenseID = -1;

            this.DriverID = -1;

            this.IssuedUsingLocalLicenseID = -1;

            this.IssueDate = DateTime.Now;

            this.ExpirationDate = DateTime.Now;

            this.IsActive = true;

            this.DriverInfo = null;


            Mode = enMode.AddNew;

        }

        public CLSInternationalLicenseBusiness(int ApplicationID, int ApplicantPersonID, DateTime ApplicationDate, enApplicationStatus ApplicationStatus,
            DateTime LastStatusDate, decimal PaidFees, int CreatedByUserID, int InternationalLicenseID, int DriverID, int IssuedUsingLocalLicenseID,
            DateTime IssueDate, DateTime ExpirationDate, bool IsActive)
        {

            base.ApplicationID = ApplicationID;

            base.ApplicantPersonID = ApplicantPersonID;

            base.ApplicationDate = ApplicationDate;

            base.ApplicationStatus = ApplicationStatus;

            base.LastStatusDate = LastStatusDate;

            base.PaidFees = PaidFees;

            base.CreatedByUserID = CreatedByUserID;


            // تعيين خصائص الكلاس المشتق (Derived Class)

            this.InternationalLicenseID = InternationalLicenseID;

            this.DriverID = DriverID;

            this.IssuedUsingLocalLicenseID = IssuedUsingLocalLicenseID;

            this.IssueDate = IssueDate;

            this.ExpirationDate = ExpirationDate;

            this.IsActive = IsActive;


            // تعيين نوع الطلب في الكلاس الأساسي

            base.ApplicationTypeID = (int)CLSApplicationsBusiness.enApplicationType.NewInternationalLicense;


            this.DriverInfo = CLSDriverBusiness.Find(this.DriverID);


            Mode = enMode.Update;

        }






        private bool _AddNewInternationalLicense()
        {

            this.InternationalLicenseID = CLSInternationalLicenseData.AddNewInternationalLicense( this.ApplicationID,  this.DriverID, 
                this.IssuedUsingLocalLicenseID, this.IssueDate, this.ExpirationDate, this.CreatedByUserID);


            return (this.InternationalLicenseID != -1);

        }

        private bool _UpdateInternationalLicense()
        {

            return CLSInternationalLicenseData.UpdateInternationalLicense( this.InternationalLicenseID, this.ApplicationID,  this.DriverID,
                this.IssuedUsingLocalLicenseID, this.IssueDate, this.ExpirationDate, this.IsActive, this.CreatedByUserID);
      
        }

        public bool Save()
        {

            base.Mode = (CLSApplicationsBusiness.enMode)Mode;

            if (!base.Save())

                return false;


            switch (Mode)
            {

                case enMode.AddNew:

                    if (_AddNewInternationalLicense())
                    {

                        Mode = enMode.Update;

                        return true;

                    }

                    else
                    {

                        return false;

                    }


                case enMode.Update:

                    return _UpdateInternationalLicense();
         
            }


            return false;
       
        }





        public static CLSInternationalLicenseBusiness Find(int InternationalLicenseID)
        {

            int ApplicationID = -1; int DriverID = -1; int IssuedUsingLocalLicenseID = -1; DateTime IssueDate = DateTime.Now; 
         
            DateTime ExpirationDate = DateTime.Now; bool IsActive = true; int CreatedByUserID = 1;


            if (CLSInternationalLicenseData.GetInternationalLicenseInfoByID(InternationalLicenseID, ref ApplicationID, ref DriverID,
                ref IssuedUsingLocalLicenseID, ref IssueDate, ref ExpirationDate, ref IsActive, ref CreatedByUserID))
            {

                CLSApplicationsBusiness Application = CLSApplicationsBusiness.FindApplication(ApplicationID);

                if (Application == null) return null;

                return new CLSInternationalLicenseBusiness(Application.ApplicationID, Application.ApplicantPersonID, Application.ApplicationDate,
                    (CLSApplicationsBusiness.enApplicationStatus)Application.ApplicationStatus, Application.LastStatusDate, Application.PaidFees,
                    Application.CreatedByUserID, InternationalLicenseID, DriverID, IssuedUsingLocalLicenseID, IssueDate, ExpirationDate, IsActive);

            }

            else
            {

                return null;

            }

        }

        public static int GetActiveInternationalLicenseIDByDriverID(int DriverID)
        {

            return CLSInternationalLicenseData.GetActiveInternationalLicenseIDByDriverID(DriverID);
     
        }



        public static DataTable GetDriverInternationalLicenses(int DriverID)
        {

            return CLSInternationalLicenseData.GetDriverInternationalLicenses(DriverID);
      
        }

        public static DataTable GetAllInternationalLicenses()
        {
         
            return CLSInternationalLicenseData.GetAllInternationalLicenses();
        
        }


    }

}













