using System;
using System.Data;
using DVLD_DataAccess; 










namespace DVLD_Business
{

    public class CLSTestsTypesBusiness
    {

        public enum enMode { AddNewMode = 0, UpdateMode = 1 };
        public enMode Mode { get; set; } = enMode.AddNewMode;


        public enum enTestType { VisionTest = 1, WrittenTest = 2, StreetTest = 3 };


        public CLSTestsTypesBusiness.enTestType TestTypeID { get; set; }
        public string TestTypeTitle { get; set; }
        public string TestTypeDescription { get; set; } 
        public decimal TestTypeFees { get; set; }



        public CLSTestsTypesBusiness()
        {

            this.TestTypeID = CLSTestsTypesBusiness.enTestType.VisionTest;

            this.TestTypeTitle = "";

            this.TestTypeDescription = "";

            this.TestTypeFees = 0;

            this.Mode = enMode.AddNewMode;

        }

        public CLSTestsTypesBusiness(CLSTestsTypesBusiness.enTestType ID, string Title, string Description, decimal Fees)
        {

            this.TestTypeID = ID;

            this.TestTypeTitle = Title;

            this.TestTypeDescription = Description;

            this.TestTypeFees = Fees;

            this.Mode = enMode.UpdateMode;

        }


        public static CLSTestsTypesBusiness Find(CLSTestsTypesBusiness.enTestType TestTypeID)
        {

            string Title = "";

            string Description = "";

            decimal Fees = 0;


            if (CLSTestsTypesData.GetTestTypeInfoByID((int)TestTypeID, ref Title, ref Description, ref Fees))
            {

                return new CLSTestsTypesBusiness(TestTypeID, Title, Description, Fees);

            }

            else
            {

                return null;

            }

        }


        private bool _AddNewTestType()
        {

            this.TestTypeID = (CLSTestsTypesBusiness.enTestType)CLSTestsTypesData.AddNewTestType(this.TestTypeTitle, this.TestTypeDescription, this.TestTypeFees);

            return (this.TestTypeTitle != "");

        }

        private bool _UpdateTestType()
        {

            return CLSTestsTypesData.UpdateTestType((int)this.TestTypeID, this.TestTypeTitle, this.TestTypeDescription, this.TestTypeFees);
    
        }

        public bool Save()
        {

            switch (Mode)
            {

                case enMode.AddNewMode:

                    if (_AddNewTestType())
                    {

                        Mode = enMode.UpdateMode;

                        return true;

                    }

                    else
                    {

                        return false;

                    }

                case enMode.UpdateMode:

                    return _UpdateTestType();

            }

            return false;

        }


        public static DataTable GetAllTestTypes()
        {

            return CLSTestsTypesData.GetAllTestTypes();

        }


    }

}



















