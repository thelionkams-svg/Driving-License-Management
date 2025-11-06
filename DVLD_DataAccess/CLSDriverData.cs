using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;











namespace DVLD_DataAccess
{

    public class CLSDriverData
    {


        public static bool GetDriverInfoByDriverID( int DriverID, ref int PersonID, ref int CreatedByUserID, ref DateTime CreatedDate)
        {

            bool isFound = false;


            SqlConnection connection = new SqlConnection(CLSDataAccessSettings.ConnectionString);

            string query = "SELECT * FROM Drivers WHERE DriverID = @DriverID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@DriverID", DriverID);


            try
            {

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();


                if (reader.Read())
                {

                    isFound = true;


                    PersonID = (int)reader["PersonID"];

                    CreatedByUserID = (int)reader["CreatedByUserID"];

                    CreatedDate = (DateTime)reader["CreatedDate"];

                }


                reader.Close();

            }

            catch (Exception)
            {

                isFound = false;

            }

            finally
            {

                connection.Close();

            }


            return isFound;

        }

        public static bool GetDriverInfoByPersonID( int PersonID, ref int DriverID, ref int CreatedByUserID, ref DateTime CreatedDate)
        {

            bool isFound = false;


            SqlConnection connection = new SqlConnection(CLSDataAccessSettings.ConnectionString);

            string query = "SELECT * FROM Drivers WHERE PersonID = @PersonID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PersonID", PersonID);


            try
            {

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();


                if (reader.Read())
                {

                    isFound = true;


                    DriverID = (int)reader["DriverID"];
                    CreatedByUserID = (int)reader["CreatedByUserID"];
                    CreatedDate = (DateTime)reader["CreatedDate"];
                }


                reader.Close();

            }

            catch (Exception)
            {

                isFound = false;

            }

            finally
            {

                connection.Close();
        
            }


            return isFound;

        }




        public static int AddNewDriver(int PersonID, int CreatedByUserID)
        {

            int DriverID = -1;


            SqlConnection connection = new SqlConnection(CLSDataAccessSettings.ConnectionString);

            string query = @"INSERT INTO Drivers (PersonID, CreatedByUserID, CreatedDate)
                     VALUES (@PersonID, @CreatedByUserID, GETDATE()); 
                     SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);


            command.Parameters.AddWithValue("@PersonID", PersonID);

            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);


            try
            {

                connection.Open();

                object result = command.ExecuteScalar();


                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {

                    DriverID = insertedID;
               
                }

            }

            catch (Exception)
            {

                DriverID = -1;

            }

            finally
            {
          
                connection.Close();
           
            }


            return DriverID;

        }

        public static bool UpdateDriver(int DriverID, int PersonID, int CreatedByUserID)
        {

            int rowsAffected = 0;


            SqlConnection connection = new SqlConnection(CLSDataAccessSettings.ConnectionString);

            string query = @"UPDATE Drivers
                     SET PersonID = @PersonID,
                         CreatedByUserID = @CreatedByUserID
                     WHERE DriverID = @DriverID";

            SqlCommand command = new SqlCommand(query, connection);


            command.Parameters.AddWithValue("@DriverID", DriverID);

            command.Parameters.AddWithValue("@PersonID", PersonID);

            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);


            try
            {

                connection.Open();

                rowsAffected = command.ExecuteNonQuery();

            }

            catch (Exception)
            {

                return false;

            }

            finally
            {

                connection.Close();

            }


            return (rowsAffected > 0);

        }




        public static DataTable GetAllDrivers()
        {

            DataTable dt = new DataTable();


            SqlConnection connection = new SqlConnection(CLSDataAccessSettings.ConnectionString);

            string query = "SELECT * FROM Drivers ORDER BY DriverID DESC";

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

                // تسجيل الخطأ

            }

            finally
            {

                connection.Close();

            }


            return dt;

        }




    }

}










































