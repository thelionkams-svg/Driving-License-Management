using System;
using System.Data;
using System.Security.Cryptography;
using System.Xml.Linq;
using DVLD_DataAccess;






namespace DVLD_Business
{

    public class CLSAppTypesBusiness
    {

        public enum enMode { AddNewMode = 0, UpdateMode = 1 };

        public enMode Mode { get; set; } = enMode.AddNewMode;



        public int ApplicationTypeID { get; set; }
        public string ApplicationTypeTitle { get; set; }
        public decimal ApplicationFees { get; set; }



        public CLSAppTypesBusiness()
        {

            this.ApplicationTypeID = -1; 

            this.ApplicationTypeTitle = "";

            this.ApplicationFees = 0;

            this.Mode = enMode.AddNewMode;

        }

        public CLSAppTypesBusiness(int ID , string Title , decimal AppFees)
        {

            this.ApplicationTypeID = ID;

            this.ApplicationTypeTitle = Title;

            this.ApplicationFees = AppFees;

            this.Mode = enMode.UpdateMode;

        }



        public static CLSAppTypesBusiness Find(int ApplicationTypeID)
        {

            string ApplicationTypeTitle = "";

            decimal ApplicationFees = 0;



            if (CLSAppTypesData.GetApplicationTypeInfoByID(ApplicationTypeID, ref ApplicationTypeTitle, ref ApplicationFees))
            {

                return new CLSAppTypesBusiness(ApplicationTypeID, ApplicationTypeTitle, ApplicationFees);

            }

            else
            {

                return null;

            }

        }




        private bool _AddNewAplicationType()
        {

            this.ApplicationTypeID = CLSAppTypesData.AddNewApplicationType(this.ApplicationTypeTitle,this.ApplicationFees);

            return (this.ApplicationTypeID != -1);

        }

        private bool _UpdateAplicationType()
        {

            return CLSAppTypesData.UpdateApplicationType(this.ApplicationTypeID, this.ApplicationTypeTitle, this.ApplicationFees);

        }

        public bool Save()
        {

            switch (Mode)
            {

                case enMode.AddNewMode:

                    if (_AddNewAplicationType())
                    {

                        Mode = enMode.UpdateMode;

                        return true;

                    }

                    else
                    {

                        return false;

                    }

                case enMode.UpdateMode:

                    return _UpdateAplicationType();

            }

            return false;

        }





        public static DataTable GetAllApplicationTypes()
        {

            return CLSAppTypesData.GetAllApplicationTypes();

        }


    }

}









