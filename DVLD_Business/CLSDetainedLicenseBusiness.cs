using DVLD_DataAccess;
using System;
using System.Data;





namespace DVLD_Business
{

    public class CLSDetainedLicenseBusiness
    {

        public enum enMode { AddNew = 0, Update = 1 };

        public enMode Mode = enMode.AddNew;


        public int DetainID { set; get; }
        public int LicenseID { set; get; }
        public float FineFees { set; get; }
        public int CreatedByUserID { set; get; }
        public bool IsReleased { set; get; }

        public int? ReleasedByUserID { set; get; }      
        public int? ReleaseApplicationID { set; get; }  


        public DateTime DetainDate { set; get; }
        public DateTime? ReleaseDate { set; get; }     


        public object CreatedByUserInfo { set; get; }
        public object ReleasedByUserInfo { set; get; }





        public CLSDetainedLicenseBusiness()
        {

            this.DetainID = -1;

            this.LicenseID = -1;

            this.DetainDate = DateTime.Now;

            this.FineFees = 0;

            this.CreatedByUserID = -1;

            this.IsReleased = false;


            this.ReleaseDate = null;

            this.ReleasedByUserID = null;

            this.ReleaseApplicationID = null;


            Mode = enMode.AddNew;

        }

        private CLSDetainedLicenseBusiness(int DetainID, int LicenseID, DateTime DetainDate, float FineFees, int CreatedByUserID,
            bool IsReleased, DateTime? ReleaseDate, int? ReleasedByUserID, int? ReleaseApplicationID)
        {

            this.DetainID = DetainID;

            this.LicenseID = LicenseID;

            this.DetainDate = DetainDate;

            this.FineFees = FineFees;

            this.CreatedByUserID = CreatedByUserID;

            this.IsReleased = IsReleased;


            this.ReleaseDate = ReleaseDate;

            this.ReleasedByUserID = ReleasedByUserID;

            this.ReleaseApplicationID = ReleaseApplicationID;


            this.CreatedByUserInfo = CLSUsersBusiness.FindUserID(this.CreatedByUserID);

            if (this.ReleasedByUserID.HasValue)
            {

                this.ReleasedByUserInfo = CLSUsersBusiness.FindUserID(this.ReleasedByUserID.Value);

            }

            else
            {

                this.ReleasedByUserInfo = null;

            }


            this.Mode = enMode.Update;

        }




        private bool _AddNewDetainedLicense()
        {

            this.DetainID = CLSDetainedLicenseData.AddNewDetainedLicense(this.LicenseID, this.DetainDate, this.FineFees, this.CreatedByUserID);

            return (this.DetainID != -1);

        }

        private bool _UpdateDetainedLicense()
        {

            return CLSDetainedLicenseData.UpdateDetainedLicense(this.DetainID, this.LicenseID, this.DetainDate, this.FineFees, this.CreatedByUserID);

        }

        public bool Save()
        {

            switch (Mode)
            {

                case enMode.AddNew:

                    if (_AddNewDetainedLicense())
                    {

                        this.Mode = enMode.Update;

                        return true;

                    }

                    else
                    {

                        return false;

                    }

                case enMode.Update:

                    return _UpdateDetainedLicense();

                default:

                    return false;

            }

        }



        public static CLSDetainedLicenseBusiness Find(int DetainID)
        {

            int LicenseID = -1; DateTime DetainDate = DateTime.MinValue; float FineFees = 0; int CreatedByUserID = -1; bool IsReleased = false;

            DateTime? ReleaseDate = null; int? ReleasedByUserID = null; int? ReleaseApplicationID = null;


            if (CLSDetainedLicenseData.GetDetainedLicenseInfoByID(DetainID, ref LicenseID, ref DetainDate, ref FineFees, ref CreatedByUserID,
                 ref IsReleased, ref ReleaseDate, ref ReleasedByUserID, ref ReleaseApplicationID))
            {

                return new CLSDetainedLicenseBusiness(DetainID, LicenseID, DetainDate, FineFees, CreatedByUserID,
                    IsReleased, ReleaseDate, ReleasedByUserID, ReleaseApplicationID);
       
            }
         
            else
            {

                return null;

            }

        }

        public static CLSDetainedLicenseBusiness FindByLicenseID(int LicenseID)
        {

            int DetainID = -1; DateTime DetainDate = DateTime.MinValue; float FineFees = 0; int CreatedByUserID = -1; bool IsReleased = false;

            DateTime? ReleaseDate = null; int? ReleasedByUserID = null; int? ReleaseApplicationID = null;


            if (CLSDetainedLicenseData.GetDetainedLicenseInfoByLicenseID(LicenseID, ref DetainID, ref DetainDate, ref FineFees,
                ref CreatedByUserID, ref IsReleased, ref ReleaseDate, ref ReleasedByUserID, ref ReleaseApplicationID))
            {

                return new CLSDetainedLicenseBusiness(DetainID, LicenseID, DetainDate, FineFees, CreatedByUserID,
                    IsReleased, ReleaseDate, ReleasedByUserID, ReleaseApplicationID);
       
            }

            else
            {

                return null;

            }

        }




        public static bool IsLicenseDetained(int LicenseID)
        {

            return CLSDetainedLicenseData.IsLicenseDetained(LicenseID);
    
        }

        public bool ReleaseDetainedLicense(int ReleasedByUserID, int ReleaseApplicationID)
        {

            if (CLSDetainedLicenseData.ReleaseDetainedLicense(this.DetainID, ReleasedByUserID, ReleaseApplicationID))
            {

                this.IsReleased = true;

                this.ReleasedByUserID = ReleasedByUserID;

                this.ReleaseApplicationID = ReleaseApplicationID;

                this.ReleaseDate = DateTime.Now;


                return true;

            }


            return false;

        }




        public static DataTable GetAllDetainedLicenses()
        {

            return CLSDetainedLicenseData.GetAllDetainedLicenses();
       
        }


    }

}


























