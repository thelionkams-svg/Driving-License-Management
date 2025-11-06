using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;






namespace DVLD_DataAccess
{

    public class CLSCountryData
    {


        public static bool GetCountryInfoByID(int CountryID, ref string CountryName)
        {

            bool isFound = false;

            SqlConnection connection = new SqlConnection(CLSDataAccessSettings.ConnectionString);

            string query = "SELECT CountryName FROM Countries WHERE CountryID = @CountryID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@CountryID", CountryID);


            try
            {

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {

                    isFound = true;

                    CountryName = (string)reader["CountryName"];

                }

                else
                {

                    isFound = false;

                }

                reader.Close();

            }

            catch (Exception ex)
            {

                isFound = false;

            }

            finally
            {

                connection.Close();

            }


            return isFound;

        }

        public static bool GetCountryInfoByName(string CountryName, ref int CountryID)
        {

            bool isFound = false;


            SqlConnection connection = new SqlConnection(CLSDataAccessSettings.ConnectionString);

            string query = "SELECT CountryID FROM Countries WHERE CountryName = @CountryName";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@CountryName", CountryName);


            try
            {

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();


                if (reader.Read())
                {

                    isFound = true;

                    CountryID = (int)reader["CountryID"];

                }

                else
                {

                    isFound = false;

                }


                reader.Close();

            }

            catch (Exception ex)
            {

                isFound = false;

            }

            finally
            {

                connection.Close();

            }


            return isFound;

        }


        public static DataTable GetAllCountries()
        {

            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(CLSDataAccessSettings.ConnectionString);

            string query = "SELECT * FROM Countries ORDER BY CountryName";

            SqlCommand command = new SqlCommand(query, connection);


            try
            {

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();


                if (reader.HasRows)
                {

                    dt.Load(reader);

                }


                reader.Close();

            }

            catch (Exception ex)
            {

                // يمكنك هنا تسجيل الخطأ

            }

            finally
            {

                connection.Close();

            }


            return dt;

        }


    }

}







