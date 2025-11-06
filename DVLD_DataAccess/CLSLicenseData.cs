using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;














namespace DVLD_DataAccess
{

    public class CLSLicenseData
    {

        public static bool GetLicenseInfoByID( int LicenseID, ref int ApplicationID, ref int DriverID, ref int LicenseClassID,
            ref DateTime IssueDate, ref DateTime ExpirationDate, ref string Notes, ref float PaidFees, ref bool IsActive,
            ref int IssueReason, ref int CreatedByUserID)
        {

            bool isFound = false;


            SqlConnection connection = new SqlConnection(CLSDataAccessSettings.ConnectionString);

            string query = "SELECT * FROM Licenses WHERE LicenseID = @LicenseID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LicenseID", LicenseID);


            try
            {

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();


                if (reader.Read())
                {

                    isFound = true;


                    ApplicationID = (int)reader["ApplicationID"];

                    DriverID = (int)reader["DriverID"];

                    LicenseClassID = (int)reader["LicenseClassID"];

                    IssueDate = (DateTime)reader["IssueDate"];

                    ExpirationDate = (DateTime)reader["ExpirationDate"];

                    PaidFees = Convert.ToSingle(reader["PaidFees"]);

                    IsActive = (bool)reader["IsActive"];

                    IssueReason = (int)reader["IssueReason"];

                    CreatedByUserID = (int)reader["CreatedByUserID"];


                    if (reader["Notes"] != DBNull.Value)

                        Notes = (string)reader["Notes"];
                    else
                        Notes = "";

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


        public static int GetActiveLicenseIDByPersonID( int PersonID, int LicenseClassID)
        {

            int LicenseID = -1;


            SqlConnection connection = new SqlConnection(CLSDataAccessSettings.ConnectionString);

            string query = @"
                SELECT TOP 1 Licenses.LicenseID 
                FROM Licenses 
                INNER JOIN Drivers ON Licenses.DriverID = Drivers.DriverID
                WHERE Licenses.LicenseClassID = @LicenseClassID 
                  AND Drivers.PersonID = @PersonID 
                  AND Licenses.IsActive = 1
                ORDER BY Licenses.IssueDate DESC;"; 

            SqlCommand command = new SqlCommand(query, connection);


            command.Parameters.AddWithValue("@PersonID", PersonID);

            command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);


            try
            {

                connection.Open();

                object result = command.ExecuteScalar();


                if (result != null && int.TryParse(result.ToString(), out int foundLicenseID))
                {

                    LicenseID = foundLicenseID;

                }

            }

            catch (Exception)
            {

                LicenseID = -1;

            }

            finally
            {

                connection.Close();

            }


            return LicenseID;

        }




        public static int AddNewLicense( int ApplicationID, int DriverID, int LicenseClassID, DateTime IssueDate, 
            DateTime ExpirationDate, string Notes, float PaidFees, int IssueReason, int CreatedByUserID)
        {

            int LicenseID = -1;


            SqlConnection connection = new SqlConnection(CLSDataAccessSettings.ConnectionString);

            string query = @"INSERT INTO Licenses (ApplicationID, DriverID, LicenseClassID,  IssueDate, ExpirationDate, Notes,  PaidFees, IsActive, IssueReason, CreatedByUserID)
                            
                                           VALUES (@ApplicationID, @DriverID, @LicenseClassID,  @IssueDate, @ExpirationDate, @Notes,  @PaidFees, 1, @IssueReason, @CreatedByUserID); 
                  
                                           SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);


            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);

            command.Parameters.AddWithValue("@DriverID", DriverID);

            command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);

            command.Parameters.AddWithValue("@IssueDate", IssueDate);

            command.Parameters.AddWithValue("@ExpirationDate", ExpirationDate);

            command.Parameters.AddWithValue("@PaidFees", PaidFees);

            command.Parameters.AddWithValue("@IssueReason", IssueReason);

            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);


            if (string.IsNullOrEmpty(Notes))

                command.Parameters.AddWithValue("@Notes", DBNull.Value);
            else
                command.Parameters.AddWithValue("@Notes", Notes);


            try
            {

                connection.Open();

                object result = command.ExecuteScalar();


                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {

                    LicenseID = insertedID;

                }

            }

            catch (Exception)
            {

                LicenseID = -1;
           
            }

            finally
            {

                connection.Close();

            }


            return LicenseID;

        }


        public static bool UpdateLicense( int LicenseID, int ApplicationID, int DriverID, int LicenseClassID, DateTime IssueDate, 
            DateTime ExpirationDate, string Notes, float PaidFees, bool IsActive, int IssueReason, int CreatedByUserID)
        {

            int rowsAffected = 0;


            SqlConnection connection = new SqlConnection(CLSDataAccessSettings.ConnectionString);

            string query = @"UPDATE Licenses
                     SET ApplicationID = @ApplicationID,
                         DriverID = @DriverID,
                         LicenseClassID = @LicenseClassID,
                         IssueDate = @IssueDate,
                         ExpirationDate = @ExpirationDate,
                         Notes = @Notes,
                         PaidFees = @PaidFees,
                         IsActive = @IsActive,
                         IssueReason = @IssueReason,
                         CreatedByUserID = @CreatedByUserID
                     WHERE LicenseID = @LicenseID";

            SqlCommand command = new SqlCommand(query, connection);


            command.Parameters.AddWithValue("@LicenseID", LicenseID);

            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);

            command.Parameters.AddWithValue("@DriverID", DriverID);

            command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);

            command.Parameters.AddWithValue("@IssueDate", IssueDate);

            command.Parameters.AddWithValue("@ExpirationDate", ExpirationDate);

            command.Parameters.AddWithValue("@PaidFees", PaidFees);

            command.Parameters.AddWithValue("@IsActive", IsActive);

            command.Parameters.AddWithValue("@IssueReason", IssueReason);

            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);


            if (string.IsNullOrEmpty(Notes))

                command.Parameters.AddWithValue("@Notes", DBNull.Value);
            else
                command.Parameters.AddWithValue("@Notes", Notes);


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


        public static bool DeactivateLicense(int LicenseID)
        {

            int rowsAffected = 0;


            SqlConnection connection = new SqlConnection(CLSDataAccessSettings.ConnectionString);

            string query = @"UPDATE Licenses
                     SET IsActive = 0
                     WHERE LicenseID = @LicenseID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LicenseID", LicenseID);


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




        public static DataTable GetLicensesByDriverID(int DriverID)
        {

            DataTable dt = new DataTable();


            SqlConnection connection = new SqlConnection(CLSDataAccessSettings.ConnectionString);

            string query = @"SELECT * FROM Licenses 
                     WHERE DriverID = @DriverID
                     ORDER BY IsActive DESC, IssueDate DESC;"; 

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


        public static DataTable GetAllLicenses()
        {

            DataTable dt = new DataTable();


            SqlConnection connection = new SqlConnection(CLSDataAccessSettings.ConnectionString);

            string query = "SELECT * FROM Licenses ORDER BY IssueDate DESC";

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

















