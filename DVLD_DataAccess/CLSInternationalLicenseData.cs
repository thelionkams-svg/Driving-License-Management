using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;








namespace DVLD_DataAccess
{

    public class CLSInternationalLicenseData
    {


        public static bool GetInternationalLicenseInfoByID( int InternationalLicenseID, ref int ApplicationID, ref int DriverID,
            ref int IssuedUsingLocalLicenseID, ref DateTime IssueDate, ref DateTime ExpirationDate, ref bool IsActive, ref int CreatedByUserID)
        {

            bool isFound = false;


            SqlConnection connection = new SqlConnection(CLSDataAccessSettings.ConnectionString);

            string query = "SELECT * FROM InternationalLicenses WHERE InternationalLicenseID = @InternationalLicenseID";
         
            SqlCommand command = new SqlCommand(query, connection);
            
            command.Parameters.AddWithValue("@InternationalLicenseID", InternationalLicenseID);


            try
            {

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();


                if (reader.Read())
                {

                    isFound = true;


                    ApplicationID = (int)reader["ApplicationID"];

                    DriverID = (int)reader["DriverID"];

                    IssuedUsingLocalLicenseID = (int)reader["IssuedUsingLocalLicenseID"];

                    IssueDate = (DateTime)reader["IssueDate"];

                    ExpirationDate = (DateTime)reader["ExpirationDate"];

                    IsActive = (bool)reader["IsActive"];

                    CreatedByUserID = (int)reader["CreatedByUserID"];
             
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

        public static int GetActiveInternationalLicenseIDByDriverID(int DriverID)
        {

            int InternationalLicenseID = -1;


            SqlConnection connection = new SqlConnection(CLSDataAccessSettings.ConnectionString);

            string query = @"
                SELECT TOP 1 InternationalLicenseID 
                FROM InternationalLicenses 
                WHERE DriverID = @DriverID 
                  AND IsActive = 1 
                  AND ExpirationDate >= GETDATE() 
                ORDER BY ExpirationDate DESC;";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@DriverID", DriverID);


            try
            {

                connection.Open();

                object result = command.ExecuteScalar();


                if (result != null && int.TryParse(result.ToString(), out int foundID))
                {

                    InternationalLicenseID = foundID;

                }

            }

            catch (Exception)
            {

                InternationalLicenseID = -1;

            }

            finally
            {

                connection.Close();

            }


            return InternationalLicenseID;

        }





        public static int AddNewInternationalLicense(int ApplicationID, int DriverID, int IssuedUsingLocalLicenseID,
              DateTime IssueDate, DateTime ExpirationDate, int CreatedByUserID)
        {

            int InternationalLicenseID = -1;


            SqlConnection connection = new SqlConnection(CLSDataAccessSettings.ConnectionString);

            string query = @"INSERT INTO InternationalLicenses 
                             (ApplicationID, DriverID, IssuedUsingLocalLicenseID, 
                              IssueDate, ExpirationDate, IsActive, CreatedByUserID)
                             VALUES (@ApplicationID, @DriverID, @IssuedUsingLocalLicenseID, 
                                     @IssueDate, @ExpirationDate, 1, @CreatedByUserID); 
                             SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);


            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);

            command.Parameters.AddWithValue("@DriverID", DriverID);

            command.Parameters.AddWithValue("@IssuedUsingLocalLicenseID", IssuedUsingLocalLicenseID);

            command.Parameters.AddWithValue("@IssueDate", IssueDate);

            command.Parameters.AddWithValue("@ExpirationDate", ExpirationDate);

            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);


            try
            {

                connection.Open();

                object result = command.ExecuteScalar();


                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {

                    InternationalLicenseID = insertedID;

                }

            }

            catch (Exception)
            {

                InternationalLicenseID = -1;

            }

            finally
            {

                connection.Close();

            }


            return InternationalLicenseID;

        }

        public static bool UpdateInternationalLicense( int InternationalLicenseID, int ApplicationID, int DriverID, int IssuedUsingLocalLicenseID,
            DateTime IssueDate, DateTime ExpirationDate, bool IsActive, int CreatedByUserID)
        {

            int rowsAffected = 0;


            SqlConnection connection = new SqlConnection(CLSDataAccessSettings.ConnectionString);

            string query = @"UPDATE InternationalLicenses
                     SET ApplicationID = @ApplicationID,
                         DriverID = @DriverID,
                         IssuedUsingLocalLicenseID = @IssuedUsingLocalLicenseID,
                         IssueDate = @IssueDate,
                         ExpirationDate = @ExpirationDate,
                         IsActive = @IsActive,
                         CreatedByUserID = @CreatedByUserID
                     WHERE InternationalLicenseID = @InternationalLicenseID";

            SqlCommand command = new SqlCommand(query, connection);


            command.Parameters.AddWithValue("@InternationalLicenseID", InternationalLicenseID);

            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);

            command.Parameters.AddWithValue("@DriverID", DriverID);

            command.Parameters.AddWithValue("@IssuedUsingLocalLicenseID", IssuedUsingLocalLicenseID);

            command.Parameters.AddWithValue("@IssueDate", IssueDate);

            command.Parameters.AddWithValue("@ExpirationDate", ExpirationDate);

            command.Parameters.AddWithValue("@IsActive", IsActive);

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





        public static DataTable GetDriverInternationalLicenses(int DriverID)
        {

            DataTable dt = new DataTable();


            SqlConnection connection = new SqlConnection(CLSDataAccessSettings.ConnectionString);

            string query = @"SELECT InternationalLicenseID, ApplicationID, IssuedUsingLocalLicenseID,  IssueDate, ExpirationDate, IsActive 
                     FROM InternationalLicenses  WHERE DriverID = @DriverID ORDER BY InternationalLicenseID DESC";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@DriverID", DriverID);


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

        public static DataTable GetAllInternationalLicenses()
        {

            DataTable dt = new DataTable();


            SqlConnection connection = new SqlConnection(CLSDataAccessSettings.ConnectionString);

            string query = "SELECT * FROM InternationalLicenses ORDER BY InternationalLicenseID DESC";

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



























