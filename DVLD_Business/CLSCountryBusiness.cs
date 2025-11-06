using System;
using System.Data;
using DVLD_DataAccess;





namespace DVLD_Business
{

    public class CLSCountryBusiness
    {


        public int ID { get; set; }
        public string CountryName { get; set; }



        public CLSCountryBusiness()
        {

            this.ID = -1;

            this.CountryName = "";

        }

        private CLSCountryBusiness(int ID, string CountryName)
        {

            this.ID = ID;

            this.CountryName = CountryName;

        }




        public static CLSCountryBusiness Find(int ID)
        {

            string CountryName = "";


            if (CLSCountryData.GetCountryInfoByID(ID, ref CountryName))
            {

                return new CLSCountryBusiness(ID, CountryName);

            }

            else
            {

                return null;

            }

        }


        public static CLSCountryBusiness Find(string CountryName)
        {

            int ID = -1;


            if (CLSCountryData.GetCountryInfoByName(CountryName, ref ID))
            {
                
                return new CLSCountryBusiness(ID, CountryName);

            }

            else
            {

                return null;

            }

        }



        public static DataTable GetAllCountries()
        {

            return CLSCountryData.GetAllCountries();

        }



    }


}
