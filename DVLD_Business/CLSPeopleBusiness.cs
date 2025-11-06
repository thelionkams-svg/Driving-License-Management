using System;
using System.Data;
using System.Xml.Linq;
using DVLD_DataAccess;












namespace DVLD_Business
{

    public class CLSPeopleBusiness
    {

        public enum enMode { AddNew = 0, Update = 1 };

        public enMode Mode = enMode.AddNew;


        public int PersonID { get; set; }

        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string ThirdName { get; set; }
        public string LastName { get; set; }
        public string FullName
        {
            get { return FirstName + " " + SecondName + " " + ThirdName + " " + LastName; }

        }



        public string NationalNo { get; set; }
        public short Gendor { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int NationalityCountryID { get; set; }

        // public clsCountry CountryInfo;

        private string _ImagePath;

        public string ImagePath
        {

            get { return _ImagePath; }

            set { _ImagePath = value; }

        }

        public DateTime DateOfBirth { get; set; }

        public CLSCountryBusiness CountryInfo;




        public CLSPeopleBusiness()
        {

            this.PersonID = -1;
            this.FirstName = "";
            this.SecondName = "";
            this.ThirdName = "";
            this.LastName = "";
            this.NationalNo = "";
            this.DateOfBirth = DateTime.Now;
            this.Gendor = 0;
            this.Address = "";
            this.Phone = "";
            this.Email = "";
            this.NationalityCountryID = -1;
            this.ImagePath = "";

            this.Mode = enMode.AddNew;

        }


        private CLSPeopleBusiness(int PersonID, string FirstName, string SecondName, string ThirdName, string LastName, string NationalNo,
            DateTime DateOfBirth, short Gendor, string Address, string Phone, string Email, int NationalityCountryID, string ImagePath)
        {

            this.PersonID = PersonID;

            this.FirstName = FirstName;

            this.SecondName = SecondName;

            this.ThirdName = ThirdName;

            this.LastName = LastName;

            this.NationalNo = NationalNo;

            this.DateOfBirth = DateOfBirth;

            this.Gendor = Gendor;

            this.Address = Address;

            this.Phone = Phone;

            this.Email = Email;

            this.ImagePath = ImagePath;



            // هذا السطر مهم جداً، حيث يربط كائن الشخص بكائن البلد الخاص به

            this.NationalityCountryID = NationalityCountryID;

            this.CountryInfo = CLSCountryBusiness.Find(NationalityCountryID);



            this.Mode = enMode.Update;

        }




        public static CLSPeopleBusiness Find(int PersonID)
        {

            string FirstName = "", SecondName = "", ThirdName = "", LastName = "", NationalNo = "", Address = "", Phone = "", Email = "",
               
                ImagePath = ""; int NationalityCountryID = -1; short Gendor = 0; DateTime DateOfBirth = DateTime.Now;


            if (CLSPeopleData.GetPersonInfoByID(PersonID, ref FirstName, ref SecondName, ref ThirdName, ref LastName,ref NationalNo, ref DateOfBirth,
                ref Gendor, ref Address, ref Phone, ref Email, ref NationalityCountryID, ref ImagePath))
            {

                return new CLSPeopleBusiness(PersonID, FirstName, SecondName, ThirdName, LastName,NationalNo, 

                    DateOfBirth, Gendor, Address, Phone, Email,NationalityCountryID, ImagePath);

            }

            else
            {

                return null;

            }

        }

        public static CLSPeopleBusiness Find(string NationalNo)
        {

            int PersonID = -1; string FirstName = "", SecondName = "", ThirdName = "", LastName = "", Address = "", Phone = "", Email = "", 
                
                ImagePath = ""; int NationalityCountryID = -1; short Gendor = 0; DateTime DateOfBirth = DateTime.Now;


            if (CLSPeopleData.GetPersonInfoByNationalNo(NationalNo, ref PersonID, ref FirstName, ref SecondName, ref ThirdName, ref LastName,
                  ref DateOfBirth, ref Gendor, ref Address, ref Phone, ref Email, ref NationalityCountryID, ref ImagePath))
            {

                return new CLSPeopleBusiness(PersonID, FirstName, SecondName, ThirdName, LastName, NationalNo, 
                    
                    DateOfBirth, Gendor, Address, Phone, Email, NationalityCountryID, ImagePath);

            }

            else
            {

                return null;

            }

        }

        public static bool IsPersonExist(int PersonID)
        {

            return CLSPeopleData.IsPersonExist(PersonID);

        }

        public static bool IsPersonExist(string NationalNo)
        {

            return CLSPeopleData.IsPersonExist(NationalNo);

        }




        private bool _AddNewPerson()
        {

            // Call DataAccess Layer to add new person

            this.PersonID = CLSPeopleData.AddNewPerson(this.FirstName, this.SecondName, this.ThirdName, this.LastName, this.NationalNo, 
                
                this.DateOfBirth, this.Gendor, this.Address, this.Phone, this.Email, this.NationalityCountryID, this.ImagePath);


            return (this.PersonID != -1);

        }

        private bool _UpdatePerson()
        {

            // Call DataAccess Layer to update person info

            return CLSPeopleData.UpdatePerson(this.PersonID, this.FirstName, this.SecondName, this.ThirdName, this.LastName, this.NationalNo,
                   
                this.DateOfBirth, this.Gendor, this.Address, this.Phone, this.Email, this.NationalityCountryID, this.ImagePath);

        }

        public bool Save()
        {

            switch (Mode)
            {

                case enMode.AddNew:

                    if (_AddNewPerson())
                    {

                        this.Mode = enMode.Update;

                        return true;

                    }

                    else
                    {

                        return false;

                    }

                case enMode.Update:

                    return _UpdatePerson();

            }


            return false;

        }

        public static bool DeletePerson(int PersonID)
        {

            return CLSPeopleData.DeletePerson(PersonID);

        }




        public static DataTable GetAllPeople()
        {

            return CLSPeopleData.GetAllPeople();

        }
        


    }



}
