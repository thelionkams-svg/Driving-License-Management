using System;
using System.Data;
using DVLD_DataAccess;
using DVLD_Business;






namespace DVLD_Buisness
{

    public class CLSLicenseBusiness
    {

        public enum enIssueReason { FirstTime = 1, Renew = 2, DamagedReplacement = 3, LostReplacement = 4 };
      
        public enum enMode { AddNew = 0, Update = 1 };
     
        public enMode Mode = enMode.AddNew;




        public CLSDriverBusiness DriverInfo;

        public CLSLicenseClassBusiness LicenseClassInfo;
        public CLSDetainedLicenseBusiness DetainedInfo { set; get; }


        

        public int LicenseID { set; get; }
        public int ApplicationID { set; get; }
        public int DriverID { set; get; }

        public int LicenseClassID { set; get; }
        public DateTime IssueDate { set; get; }
        public DateTime ExpirationDate { set; get; }
        public string Notes { set; get; }

        public float PaidFees { set; get; }
        public bool IsActive { set; get; }
        public enIssueReason IssueReason { set; get; }
        public int CreatedByUserID { set; get; }


        public string IssueReasonText
        {

            get
            {
         
                return GetIssueReasonText(this.IssueReason);
          
            }

        }

        public bool IsDetained
        {

            get { return CLSDetainedLicenseBusiness.IsLicenseDetained(this.LicenseID); }
       
        }






        public CLSLicenseBusiness()
        {

            this.LicenseID = -1;

            this.ApplicationID = -1;

            this.DriverID = -1;

            this.LicenseClassID = -1;

            this.IssueDate = DateTime.Now;

            this.ExpirationDate = DateTime.Now;

            this.Notes = "";

            this.PaidFees = 0.0f;

            this.IsActive = true;

            this.IssueReason = enIssueReason.FirstTime;

            this.CreatedByUserID = -1;


            this.DriverInfo = null;

            this.LicenseClassInfo = null;

            this.DetainedInfo = null;


            Mode = enMode.AddNew;

        }

        public CLSLicenseBusiness(int LicenseID, int ApplicationID, int DriverID, int LicenseClassID, DateTime IssueDate,
            DateTime ExpirationDate, string Notes, float PaidFees, bool IsActive, enIssueReason IssueReason, int CreatedByUserID)
        {

            this.LicenseID = LicenseID;

            this.ApplicationID = ApplicationID;

            this.DriverID = DriverID;

            this.LicenseClassID = LicenseClassID;

            this.IssueDate = IssueDate;

            this.ExpirationDate = ExpirationDate;

            this.Notes = Notes;

            this.PaidFees = PaidFees;

            this.IsActive = IsActive;

            this.IssueReason = IssueReason;

            this.CreatedByUserID = CreatedByUserID;


            this.DriverInfo = CLSDriverBusiness.Find(this.DriverID);
          
            this.LicenseClassInfo = CLSLicenseClassBusiness.Find(this.LicenseClassID);
           
            this.DetainedInfo = CLSDetainedLicenseBusiness.Find(this.LicenseID);


            Mode = enMode.Update;

        }





        private bool _AddNewLicense()
        {

            this.LicenseID = CLSLicenseData.AddNewLicense(this.ApplicationID, this.DriverID, this.LicenseClassID, this.IssueDate,
                this.ExpirationDate, this.Notes, this.PaidFees, (int)this.IssueReason, this.CreatedByUserID); 

            return (this.LicenseID != -1);

        }

        private bool _UpdateLicense()
        {

            return CLSLicenseData.UpdateLicense(this.LicenseID, this.ApplicationID, this.DriverID, this.LicenseClassID, this.IssueDate, 
               this.ExpirationDate, this.Notes, this.PaidFees, this.IsActive, (int)this.IssueReason, this.CreatedByUserID); 

        }

        public bool Save()
        {

            switch (Mode)
            {

                case enMode.AddNew:

                    if (_AddNewLicense())
                    {

                        Mode = enMode.Update;

                        return true;

                    }

                    else
                    {

                        return false;

                    }

                case enMode.Update:

                    return _UpdateLicense();

            }


            return false;

        }





        public int Detain(float FineFees, int CreatedByUserID)
        {

            CLSDetainedLicenseBusiness detainedLicense = new CLSDetainedLicenseBusiness();


            detainedLicense.LicenseID = this.LicenseID;

            detainedLicense.DetainDate = DateTime.Now;

            detainedLicense.FineFees = FineFees;

            detainedLicense.CreatedByUserID = CreatedByUserID;


            if (!detainedLicense.Save())
            {

                return -1;

            }


            return detainedLicense.DetainID;
        
        }

        public bool DeactivateCurrentLicense()
        {

            return (CLSLicenseData.DeactivateLicense(this.LicenseID));
       
        }


        public bool ReleaseDetainedLicense(int ReleasedByUserID, ref int ApplicationID)
        {

            CLSApplicationsBusiness Application = new CLSApplicationsBusiness();


            Application.ApplicantPersonID = this.DriverInfo.PersonID;

            Application.ApplicationDate = DateTime.Now;


            Application.ApplicationTypeID = (int)CLSApplicationsBusiness.enApplicationType.ReleaseDetainedDrivingLicsense;
           
            Application.ApplicationStatus = CLSApplicationsBusiness.enApplicationStatus.Completed;
          
            Application.LastStatusDate = DateTime.Now;


            Application.PaidFees = CLSAppTypesBusiness.Find((int)CLSApplicationsBusiness.enApplicationType.ReleaseDetainedDrivingLicsense).ApplicationFees;
         
      
            Application.CreatedByUserID = ReleasedByUserID;


            if (!Application.Save())
            {

                ApplicationID = -1;

                return false;

            }


            ApplicationID = Application.ApplicationID;


            return this.DetainedInfo.ReleaseDetainedLicense(ReleasedByUserID, Application.ApplicationID);

        }


        public CLSLicenseBusiness RenewLicense(string Notes, int CreatedByUserID)
        {

            CLSApplicationsBusiness Application = new CLSApplicationsBusiness();


            Application.ApplicantPersonID = this.DriverInfo.PersonID;

            Application.ApplicationDate = DateTime.Now;

            Application.LastStatusDate = DateTime.Now;


            Application.ApplicationTypeID = (int)CLSApplicationsBusiness.enApplicationType.RenewDrivingLicense;

            Application.ApplicationStatus = CLSApplicationsBusiness.enApplicationStatus.Completed;


            Application.PaidFees = CLSAppTypesBusiness.Find((int)CLSApplicationsBusiness.enApplicationType.RenewDrivingLicense).ApplicationFees;
          
            
            Application.CreatedByUserID = CreatedByUserID;


            if (!Application.Save())
            {

                return null;

            }


            // إنشاء رخصة جديدة

            CLSLicenseBusiness NewLicense = new CLSLicenseBusiness();


            NewLicense.ApplicationID = Application.ApplicationID;

            NewLicense.DriverID = this.DriverID;

            NewLicense.LicenseClassID = this.LicenseClassID;

            NewLicense.IssueDate = DateTime.Now;


            // استخدام معلومات فئة الرخصة لتحديد مدة الصلاحية

            int DefaultValidityLength = this.LicenseClassInfo.DefaultValidityLength;


            NewLicense.ExpirationDate = DateTime.Now.AddYears(DefaultValidityLength);

            NewLicense.Notes = Notes;

            NewLicense.PaidFees = this.LicenseClassInfo.ClassFees;

            NewLicense.IsActive = true;

            NewLicense.IssueReason = CLSLicenseBusiness.enIssueReason.Renew;

            NewLicense.CreatedByUserID = CreatedByUserID;


            if (!NewLicense.Save())
            {

                return null;

            }


            // 3.إلغاء تفعيل الرخصة القديمة
         
            DeactivateCurrentLicense();


            return NewLicense;

        }


        public CLSLicenseBusiness Replace(enIssueReason IssueReason, int CreatedByUserID)
        {

            // 1. إنشاء طلب استبدال (Application)

            CLSApplicationsBusiness Application = new CLSApplicationsBusiness();


            Application.ApplicantPersonID = this.DriverInfo.PersonID;

            Application.ApplicationDate = DateTime.Now;


            Application.ApplicationTypeID = (IssueReason == enIssueReason.DamagedReplacement) ?

                (int)CLSApplicationsBusiness.enApplicationType.ReplaceDamagedDrivingLicense :
                
                (int)CLSApplicationsBusiness.enApplicationType.ReplaceLostDrivingLicense;



            Application.ApplicationStatus = CLSApplicationsBusiness.enApplicationStatus.Completed;

            Application.LastStatusDate = DateTime.Now;


            // **التصحيح 3: تغيير اسم الخاصية من Fees إلى ApplicationFees**

            Application.PaidFees = CLSAppTypesBusiness.Find(Application.ApplicationTypeID).ApplicationFees;

            Application.CreatedByUserID = CreatedByUserID;


            if (!Application.Save())
            {

                return null;

            }



            // 2. إنشاء رخصة جديدة (New License)

            CLSLicenseBusiness NewLicense = new CLSLicenseBusiness();


            NewLicense.ApplicationID = Application.ApplicationID;

            NewLicense.DriverID = this.DriverID;

            NewLicense.LicenseClassID = this.LicenseClassID;

            NewLicense.IssueDate = DateTime.Now;

            NewLicense.ExpirationDate = this.ExpirationDate;

            NewLicense.Notes = this.Notes;

            NewLicense.PaidFees = 0.0f;

            NewLicense.IsActive = true;

            NewLicense.IssueReason = IssueReason;

            NewLicense.CreatedByUserID = CreatedByUserID;


            if (!NewLicense.Save())
            {

                return null;

            }


            // 3. إلغاء تفعيل الرخصة القديمة
         
            DeactivateCurrentLicense();


            return NewLicense;

        }




        public static CLSLicenseBusiness Find(int LicenseID)
        {

            int ApplicationID = -1; int DriverID = -1; int LicenseClassID = -1; DateTime IssueDate = DateTime.Now; DateTime ExpirationDate = DateTime.Now;
      
            string Notes = ""; float PaidFees = 0; bool IsActive = true; int CreatedByUserID = 1; int IssueReason = 1;


            if (CLSLicenseData.GetLicenseInfoByID(LicenseID, ref ApplicationID, ref DriverID, ref LicenseClassID, ref IssueDate, 
                ref ExpirationDate, ref Notes, ref PaidFees, ref IsActive, ref IssueReason, ref CreatedByUserID))
            {
             
                return new CLSLicenseBusiness(LicenseID, ApplicationID, DriverID, LicenseClassID, IssueDate, ExpirationDate, Notes,
                                    PaidFees, IsActive, (enIssueReason)IssueReason, CreatedByUserID);
          
            }

            else
                return null;

        }


        public static int GetActiveLicenseIDByPersonID(int PersonID, int LicenseClassID)
        {
      
            return CLSLicenseData.GetActiveLicenseIDByPersonID(PersonID, LicenseClassID);
     
        }

        public static bool IsLicenseExistByPersonID(int PersonID, int LicenseClassID)
        {

            return (GetActiveLicenseIDByPersonID(PersonID, LicenseClassID) != -1);
       
        }



        public static string GetIssueReasonText(enIssueReason IssueReason)
        {

            switch (IssueReason)
            {

                case enIssueReason.FirstTime:

                    return "First Time";

                case enIssueReason.Renew:

                    return "Renew";

                case enIssueReason.DamagedReplacement:

                    return "Replacement for Damaged";

                case enIssueReason.LostReplacement:

                    return "Replacement for Lost";

                default:

                    return "First Time";

            }

        }

        public Boolean IsLicenseExpired()
        {

            return (this.ExpirationDate < DateTime.Now);
      
        }




        public static DataTable GetDriverLicenses(int DriverID)
        {

            return CLSLicenseData.GetLicensesByDriverID(DriverID);

        }

        public static DataTable GetAllLicenses()
        {

            return CLSLicenseData.GetAllLicenses();

        }



    }

}















