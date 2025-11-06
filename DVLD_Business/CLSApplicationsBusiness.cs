using DVLD_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;







namespace DVLD_Business
{

    public class CLSApplicationsBusiness
    {

        public enum enMode { AddNew = 0, Update = 1 };

        protected enMode Mode = enMode.AddNew;

        public enum enApplicationStatus { New = 1, Cancelled = 2, Completed = 3 };

        public enum enApplicationType
        {

            NewDrivingLicense = 1, RenewDrivingLicense = 2, ReplaceLostDrivingLicense = 3, ReplaceDamagedDrivingLicense = 4,

            ReleaseDetainedDrivingLicsense = 5, NewInternationalLicense = 6, RetakeTest = 7

        };



        public CLSUsersBusiness CreatedByUserInfo;

        public CLSAppTypesBusiness ApplicationType;



        public int ApplicationID { set; get; }
        public int ApplicantPersonID { set; get; }
        public DateTime ApplicationDate { set; get; }
        public int ApplicationTypeID { set; get; }
        public DateTime LastStatusDate { set; get; }
        public decimal PaidFees { set; get; }
        public int CreatedByUserID { set; get; }
        public enApplicationStatus ApplicationStatus { set; get; }


        public CLSPeopleBusiness PersonInfo { set; get; }

        public string AppStatusText
        {

            get
            {

                switch (ApplicationStatus)
                {

                    case enApplicationStatus.New:

                        return "New";

                    case enApplicationStatus.Cancelled:

                        return "Cancelled";

                    case enApplicationStatus.Completed:

                        return "Completed";

                    default:

                        return "Unknown";

                }

            }

        }

        public string ApplicantFullName
        {

            get
            {

                return PersonInfo?.FullName;

            }

        }





        public CLSApplicationsBusiness()
        {

            this.ApplicationID = -1;

            this.ApplicantPersonID = -1;

            this.ApplicationDate = DateTime.Now;

            this.ApplicationTypeID = -1;

            this.LastStatusDate = DateTime.Now;

            this.PaidFees = 0;

            this.CreatedByUserID = -1;

            this.ApplicationStatus = enApplicationStatus.New;


            this.Mode = enMode.AddNew;


            this.CreatedByUserInfo = null;

            this.ApplicationType = null;


        }

        public CLSApplicationsBusiness(int ApplicationID, int ApplicantPersonID, DateTime ApplicationDate, int ApplicationTypeID,
            DateTime LastStatusDate, decimal PaidFees, int CreatedByUserID, enApplicationStatus ApplicationStatus)
        {

            this.ApplicationID = ApplicationID;

            this.ApplicantPersonID = ApplicantPersonID;

            this.ApplicationDate = ApplicationDate;

            this.ApplicationTypeID = ApplicationTypeID;

            this.LastStatusDate = LastStatusDate;

            this.PaidFees = PaidFees;

            this.CreatedByUserID = CreatedByUserID;

            this.ApplicationStatus = ApplicationStatus;


            this.Mode = enMode.Update;


            this.PersonInfo = CLSPeopleBusiness.Find(ApplicantPersonID);

            this.CreatedByUserInfo = CLSUsersBusiness.FindUserID(CreatedByUserID);

            this.ApplicationType = CLSAppTypesBusiness.Find(ApplicationTypeID);

        }




        private bool _AddNewApplication()
        {

            this.ApplicationID = CLSApplicationsData.AddNewApplication(this.ApplicantPersonID, this.ApplicationTypeID, (byte)this.ApplicationStatus,
           
                this.ApplicationDate, this.PaidFees, this.LastStatusDate, this.CreatedByUserID);


            return (ApplicationID != -1);

        }

        private bool _UpdateApplicatoin()
        {

            return CLSApplicationsData.UpdateApplication(this.ApplicationID, this.ApplicantPersonID, this.ApplicationTypeID,
                
              (byte)this.ApplicationStatus, this.ApplicationDate, this.PaidFees, this.LastStatusDate,this.CreatedByUserID);

        }

        public bool Save()
        {

            switch (Mode)
            {

                case enMode.AddNew:

                    if (_AddNewApplication())
                    {

                        Mode = enMode.Update;

                        return true;

                    }

                    else
                    {

                        return false;

                    }


                case enMode.Update:

                    if (this.ApplicationID == -1)

                        return false;


                    return _UpdateApplicatoin();


                default :
                    
                    return false;

            }

        }



        public bool SetComplete()
        {

            return CLSApplicationsData.UpdateStatus(ApplicationID , 3);

        }

        public bool Cancel()
        {

            return CLSApplicationsData.UpdateStatus(ApplicationID, 2);

        }

        public bool Delete()
        {

            return CLSApplicationsData.DeleteApplication(this.ApplicationID);    

        }



        public static CLSApplicationsBusiness FindApplication(int ApplicationID)
        {

            int ApplicantPersonID = -1; DateTime ApplicationDate = DateTime.MinValue; int ApplicationTypeID = -1; byte ApplicationStatus = 1;
       
            DateTime LastStatusDate = DateTime.MinValue; decimal PaidFees = 0; int CreatedByUserID = -1;


            bool IsFound = CLSApplicationsData.GetApplicationInfoByID(ApplicationID, ref ApplicantPersonID, ref ApplicationTypeID, 
                
                ref ApplicationStatus, ref ApplicationDate, ref PaidFees, ref LastStatusDate, ref CreatedByUserID);


            if (IsFound)
            {

                return new CLSApplicationsBusiness( ApplicationID, ApplicantPersonID, ApplicationDate, ApplicationTypeID,
                    
                    LastStatusDate, PaidFees, CreatedByUserID,(enApplicationStatus)ApplicationStatus );


            }

            else
            {

                return null;

            }

        }

        public static bool IsApplicarionExist(int ApplicationID)
        {

            return CLSApplicationsData.IsApplicationExist(ApplicationID);

        }


        public static bool DoesPersonHaveActiveApplication(int ApplicantPersonID, int ApplicationTypeID)
        {

            return CLSApplicationsData.DoesPersonHaveActiveApplication(ApplicantPersonID, ApplicationTypeID);

        }

        public bool DoesPersonHaveActiveApplication(int ApplicationTypeID)
        {

            return CLSApplicationsData.DoesPersonHaveActiveApplication(this.ApplicantPersonID, ApplicationTypeID);


        }


        public static int GetActiveApplicationID(int ApplicationPersonID , CLSApplicationsBusiness.enApplicationType ApplicationTypeID)
        {

            return CLSApplicationsData.GetActiveApplicationID(ApplicationPersonID, (int) ApplicationTypeID);

        }

        public int GetActiveApplicationID(CLSApplicationsBusiness.enApplicationType ApplicationTypeID)
        {

            return CLSApplicationsData.GetActiveApplicationID(this.ApplicantPersonID , (int) ApplicationTypeID);

        }


        public static int GetActiveApplicationIDForLicenseClass(int ApplicationPersonID, CLSApplicationsBusiness.enApplicationType ApplicationTypeID, int LicenseClassID)
        {

            return CLSApplicationsData.GetActiveApplicationIDForLicenseClass(ApplicationPersonID, (int) ApplicationTypeID, LicenseClassID);

        }



        public static DataTable GetAllApplications()
        {

            return CLSApplicationsData.GetAllApplications();

        }



    }

}







