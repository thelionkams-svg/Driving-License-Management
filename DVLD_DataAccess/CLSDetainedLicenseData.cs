using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;









namespace DVLD_DataAccess
{

    public class CLSDetainedLicenseData
    {


        public static bool GetDetainedLicenseInfoByID( int DetainID, ref int LicenseID, ref DateTime DetainDate, ref float FineFees,
            ref int CreatedByUserID, ref bool IsReleased, ref DateTime? ReleaseDate, ref int? ReleasedByUserID, ref int? ReleaseApplicationID)
        {

            bool isFound = false;


            SqlConnection connection = new SqlConnection(CLSDataAccessSettings.ConnectionString);

            string query = "SELECT * FROM DetainedLicenses WHERE DetainID = @DetainID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@DetainID", DetainID);


            try
            {

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();


                if (reader.Read())
                {

                    isFound = true;



                    LicenseID = (int)reader["LicenseID"];
                    DetainDate = (DateTime)reader["DetainDate"];

                    FineFees = Convert.ToSingle(reader["FineFees"]);

                    CreatedByUserID = (int)reader["CreatedByUserID"];

                    IsReleased = (bool)reader["IsReleased"];


                    // التعامل مع القيم القابلة للقيمة الفارغة (Nullable Types)

                    ReleaseDate = reader["ReleaseDate"] != DBNull.Value ? (DateTime)reader["ReleaseDate"] : (DateTime?)null;
                
                    ReleasedByUserID = reader["ReleasedByUserID"] != DBNull.Value ? (int)reader["ReleasedByUserID"] : (int?)null;

                    ReleaseApplicationID = reader["ReleaseApplicationID"] != DBNull.Value ? (int)reader["ReleaseApplicationID"] : (int?)null;
          
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

        public static bool GetDetainedLicenseInfoByLicenseID( int LicenseID, ref int DetainID, ref DateTime DetainDate, ref float FineFees,
            ref int CreatedByUserID, ref bool IsReleased, ref DateTime? ReleaseDate, ref int? ReleasedByUserID, ref int? ReleaseApplicationID)
        {

            bool isFound = false;


            SqlConnection connection = new SqlConnection(CLSDataAccessSettings.ConnectionString);

            string query = @"SELECT TOP 1 * FROM DetainedLicenses 
                             WHERE LicenseID = @LicenseID 
                             ORDER BY DetainID DESC";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LicenseID", LicenseID);


            try
            {

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();


                if (reader.Read())
                {

                    isFound = true;


                    DetainID = (int)reader["DetainID"];

                    DetainDate = (DateTime)reader["DetainDate"];

                    FineFees = Convert.ToSingle(reader["FineFees"]);

                    CreatedByUserID = (int)reader["CreatedByUserID"];

                    IsReleased = (bool)reader["IsReleased"];


                    // التعامل مع القيم القابلة للقيمة الفارغة (Nullable Types)
              
                    ReleaseDate = reader["ReleaseDate"] != DBNull.Value ? (DateTime)reader["ReleaseDate"] : (DateTime?)null;
               
                    ReleasedByUserID = reader["ReleasedByUserID"] != DBNull.Value ? (int)reader["ReleasedByUserID"] : (int?)null;
              
                    ReleaseApplicationID = reader["ReleaseApplicationID"] != DBNull.Value ? (int)reader["ReleaseApplicationID"] : (int?)null;
               
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




        public static int AddNewDetainedLicense(int LicenseID, DateTime DetainDate, float FineFees, int CreatedByUserID)
        {

            int DetainID = -1;


            SqlConnection connection = new SqlConnection(CLSDataAccessSettings.ConnectionString);

            string query = @"INSERT INTO DetainedLicenses (LicenseID, DetainDate, FineFees, CreatedByUserID, IsReleased)
                             VALUES (@LicenseID, @DetainDate, @FineFees, @CreatedByUserID, 0); 
                             SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);


            command.Parameters.AddWithValue("@LicenseID", LicenseID);

            command.Parameters.AddWithValue("@DetainDate", DetainDate);

            command.Parameters.AddWithValue("@FineFees", FineFees);

            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);


            try
            {

                connection.Open();

                object result = command.ExecuteScalar();


                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
               
                    DetainID = insertedID;
               
                }

            }

            catch (Exception)
            {

                DetainID = -1;

            }

            finally
            {

                connection.Close();

            }


            return DetainID;

        }

        public static bool UpdateDetainedLicense(int DetainID, int LicenseID, DateTime DetainDate, float FineFees, int CreatedByUserID)
        {

            int rowsAffected = 0;


            SqlConnection connection = new SqlConnection(CLSDataAccessSettings.ConnectionString);

            string query = @"UPDATE DetainedLicenses
                     SET LicenseID = @LicenseID,
                         DetainDate = @DetainDate,
                         FineFees = @FineFees,
                         CreatedByUserID = @CreatedByUserID
                     WHERE DetainID = @DetainID AND IsReleased = 0"; 

            SqlCommand command = new SqlCommand(query, connection);


            command.Parameters.AddWithValue("@DetainID", DetainID);

            command.Parameters.AddWithValue("@LicenseID", LicenseID);

            command.Parameters.AddWithValue("@DetainDate", DetainDate);

            command.Parameters.AddWithValue("@FineFees", FineFees);

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



        public static bool IsLicenseDetained(int LicenseID)
        {

            bool isDetained = false;


            SqlConnection connection = new SqlConnection(CLSDataAccessSettings.ConnectionString);

            string query = "SELECT Found = 1 FROM DetainedLicenses WHERE LicenseID = @LicenseID AND IsReleased = 0";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LicenseID", LicenseID);


            try
            {

                connection.Open();

                object result = command.ExecuteScalar();


                if (result != null)
                {

                    isDetained = true;

                }

            }

            catch (Exception)
            {

                isDetained = false;

            }

            finally
            {

                connection.Close();

            }


            return isDetained;

        }

        public static bool ReleaseDetainedLicense(int DetainID, int ReleasedByUserID, int ReleaseApplicationID)
        {

            int rowsAffected = 0;


            SqlConnection connection = new SqlConnection(CLSDataAccessSettings.ConnectionString);

            string query = @"UPDATE DetainedLicenses
                             SET IsReleased = 1,
                                 ReleaseDate = GETDATE(),
                                 ReleasedByUserID = @ReleasedByUserID,
                                 ReleaseApplicationID = @ReleaseApplicationID
                           WHERE DetainID = @DetainID AND IsReleased = 0"; 

            SqlCommand command = new SqlCommand(query, connection);


            command.Parameters.AddWithValue("@DetainID", DetainID);

            command.Parameters.AddWithValue("@ReleasedByUserID", ReleasedByUserID);

            command.Parameters.AddWithValue("@ReleaseApplicationID", ReleaseApplicationID);


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




        public static DataTable GetAllDetainedLicenses()
        {

            DataTable dt = new DataTable();


            SqlConnection connection = new SqlConnection(CLSDataAccessSettings.ConnectionString);

            string query = "SELECT * FROM DetainedLicenses ORDER BY DetainID DESC";

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

            catch (Exception)
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















