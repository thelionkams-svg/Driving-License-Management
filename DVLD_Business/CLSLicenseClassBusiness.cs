using DVLD_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;










namespace DVLD_Business
{

    public class CLSLicenseClassBusiness
    {


        public enum enMode { AddNew = 0, Update = 1 };

        public enMode Mode = enMode.AddNew;



        public int LicenseClassID { get; set; }
        public string ClassName { get; set; }
        public string ClassDescription { get; set; }
        public byte MinimumAllowedAge { get; set; }
        public byte DefaultValidityLength { get; set; }
        public float ClassFees { get; set; }






        public CLSLicenseClassBusiness()
        {

            this.LicenseClassID = -1;

            this.ClassName = "";

            this.ClassDescription = "";

            this.MinimumAllowedAge = 0;

            this.DefaultValidityLength = 0;

            this.ClassFees = 0;


            this.Mode = enMode.AddNew;

        }

        public CLSLicenseClassBusiness(int LicenseClassID, string ClassName, string ClassDescription,
            byte MinimumAllowedAge, byte DefaultValidityLength, float ClassFees)
        {

            this.LicenseClassID = LicenseClassID;

            this.ClassName = ClassName;

            this.ClassDescription = ClassDescription;

            this.MinimumAllowedAge = MinimumAllowedAge;

            this.DefaultValidityLength = DefaultValidityLength;

            this.ClassFees = ClassFees;


            this.Mode = enMode.Update;

        }




        public static CLSLicenseClassBusiness Find(int LicenseClassID)
        {

            string ClassName = "", ClassDescription = ""; byte MinimumAllowedAge = 0,  DefaultValidityLength = 0; float ClassFees = 0;


            if (CLSLicenseClassData.GetLicenseClassInfoByID(LicenseClassID, ref ClassName, ref ClassDescription, ref MinimumAllowedAge, ref DefaultValidityLength, ref ClassFees))
            {

                return new CLSLicenseClassBusiness(LicenseClassID, ClassName, ClassDescription, MinimumAllowedAge, DefaultValidityLength, ClassFees);
      
            }

            else
            {

                return null;

            }

        }

        public static CLSLicenseClassBusiness Find(string ClassName)
        {

            int LicenseClassID = -1; string ClassDescription = "";  byte MinimumAllowedAge = 0, DefaultValidityLength = 0;  float ClassFees = 0;


            if (CLSLicenseClassData.GetLicenseClassInfoByClassName(ClassName, ref LicenseClassID, ref ClassDescription, ref MinimumAllowedAge, ref DefaultValidityLength, ref ClassFees))
            {

                return new CLSLicenseClassBusiness(LicenseClassID, ClassName, ClassDescription, MinimumAllowedAge, DefaultValidityLength, ClassFees);
           
            }

            else
            {

                return null;

            }

        }




        public static bool IsLicenseClassExist(int LicenseClassID)
        {

            return (Find(LicenseClassID) != null);

        }

        public static bool IsLicenseClassExist(string ClassName)
        {

            return (Find(ClassName) != null);

        }




        private bool _AddNewLicenseClass()
        {

            this.LicenseClassID = CLSLicenseClassData.AddNewLicenseClass( this.ClassName, this.ClassDescription, this.MinimumAllowedAge,
                this.DefaultValidityLength, this.ClassFees);


            if (this.LicenseClassID != -1)
            {

                this.Mode = enMode.Update;

                return true;

            }

            else
            {

                return false;

            }

        }

        private bool _UpdateLicenseClass()
        {

            return CLSLicenseClassData.UpdateLicenseClass( this.LicenseClassID, this.ClassName, this.ClassDescription,
                this.MinimumAllowedAge, this.DefaultValidityLength, this.ClassFees);
       
        }

        public bool Save()
        {

            switch (Mode)
            {

                case enMode.AddNew:

                    return _AddNewLicenseClass(); 

                case enMode.Update:

                    return _UpdateLicenseClass();

                default:

                    return false; 

            }
       
        }





        public static DataTable GetAllLicenseClasses()
        {

            return CLSLicenseClassData.GetAllLicenseClasses();

        }



    }

}





















