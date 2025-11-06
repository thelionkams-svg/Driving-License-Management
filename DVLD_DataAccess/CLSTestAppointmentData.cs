using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;













namespace DVLD_DataAccess
{

    public class CLSTestAppointmentData
    {

        public static bool GetTestAppointmentInfoByID( int TestAppointmentID, ref int TestTypeID, ref int LocalDrivingLicenseApplicationID,
            ref DateTime AppointmentDate, ref float PaidFees, ref int CreatedByUserID, ref bool IsLocked, ref int? RetakeTestApplicationID)
        {

            bool isFound = false;

            SqlConnection connection = new SqlConnection(CLSDataAccessSettings.ConnectionString);

            string query = "SELECT * FROM TestAppointments WHERE TestAppointmentID = @TestAppointmentID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);


            try
            {

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();


                if (reader.Read())
                {

                    isFound = true;


                    TestTypeID = (int)reader["TestTypeID"];

                    LocalDrivingLicenseApplicationID = (int)reader["LocalDrivingLicenseApplicationID"];

                    AppointmentDate = (DateTime)reader["AppointmentDate"];

                    PaidFees = Convert.ToSingle(reader["PaidFees"]);

                    CreatedByUserID = (int)reader["CreatedByUserID"];

                    IsLocked = (bool)reader["IsLocked"];


                    if (reader["RetakeTestApplicationID"] != DBNull.Value)

                        RetakeTestApplicationID = (int)reader["RetakeTestApplicationID"];
                    else
                        RetakeTestApplicationID = null;

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


        public static bool GetLastTestAppointment( int LocalDrivingLicenseApplicationID, int TestTypeID, ref int TestAppointmentID,
            ref DateTime AppointmentDate, ref float PaidFees, ref int CreatedByUserID, ref bool IsLocked, ref int? RetakeTestApplicationID)
        {

            bool isFound = false;


            SqlConnection connection = new SqlConnection(CLSDataAccessSettings.ConnectionString);

            string query = @"SELECT TOP 1 *
                     FROM TestAppointments
                     WHERE LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID
                       AND TestTypeID = @TestTypeID
                     ORDER BY TestAppointmentID DESC;"; 

            SqlCommand command = new SqlCommand(query, connection);


            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);

            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);


            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();


                if (reader.Read())
                {

                    isFound = true;


                    TestAppointmentID = (int)reader["TestAppointmentID"];

                    AppointmentDate = (DateTime)reader["AppointmentDate"];

                    PaidFees = Convert.ToSingle(reader["PaidFees"]);

                    CreatedByUserID = (int)reader["CreatedByUserID"];

                    IsLocked = (bool)reader["IsLocked"];


                    if (reader["RetakeTestApplicationID"] != DBNull.Value)

                        RetakeTestApplicationID = (int)reader["RetakeTestApplicationID"];
                    else
                        RetakeTestApplicationID = null;

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


        public static int GetTestID(int TestAppointmentID)
        {

            int TestID = -1;


            SqlConnection connection = new SqlConnection(CLSDataAccessSettings.ConnectionString);

            string query = @"SELECT TestID
                     FROM Tests
                     WHERE TestAppointmentID = @TestAppointmentID;";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);


            try
            {

                connection.Open();

                object result = command.ExecuteScalar();


                if (result != null && int.TryParse(result.ToString(), out int foundTestID))
                {

                    TestID = foundTestID;

                }
          
            }

            catch (Exception)
            {

                TestID = -1;

            }

            finally
            {

                connection.Close();

            }


            return TestID;

        }




        public static int AddNewTestAppointment( int TestTypeID, int LocalDrivingLicenseApplicationID,
            DateTime AppointmentDate, float PaidFees, int CreatedByUserID, int? RetakeTestApplicationID)
        {

            int TestAppointmentID = -1;


            SqlConnection connection = new SqlConnection(CLSDataAccessSettings.ConnectionString);

            string query = @"INSERT INTO TestAppointments (TestTypeID, LocalDrivingLicenseApplicationID, 
                                                   AppointmentDate, PaidFees, CreatedByUserID, 
                                                   IsLocked, RetakeTestApplicationID)
                     VALUES (@TestTypeID, @LocalDrivingLicenseApplicationID, @AppointmentDate, 
                             @PaidFees, @CreatedByUserID, 0, @RetakeTestApplicationID); 
                     SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);


            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);

            command.Parameters.AddWithValue("@AppointmentDate", AppointmentDate);

            command.Parameters.AddWithValue("@PaidFees", PaidFees);

            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);


            if (RetakeTestApplicationID.HasValue)

                command.Parameters.AddWithValue("@RetakeTestApplicationID", RetakeTestApplicationID.Value);
            else
                command.Parameters.AddWithValue("@RetakeTestApplicationID", DBNull.Value); // يجب تمرير DBNull.Value للقيمة الفارغة


            try
            {

                connection.Open();

                object result = command.ExecuteScalar();


                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {

                    TestAppointmentID = insertedID;

                }
           
            }

            catch (Exception ex)
            {

                // تسجيل الخطأ

            }

            finally
            {

                connection.Close();

            }


            return TestAppointmentID;

        }


        public static bool UpdateTestAppointment( int TestAppointmentID, int TestTypeID, int LocalDrivingLicenseApplicationID, 
            DateTime AppointmentDate, float PaidFees, int CreatedByUserID, int? RetakeTestApplicationID)
        {

            int rowsAffected = 0;


            SqlConnection connection = new SqlConnection(CLSDataAccessSettings.ConnectionString);

            string query = @"UPDATE TestAppointments
                     SET TestTypeID = @TestTypeID,
                         LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID,
                         AppointmentDate = @AppointmentDate,
                         PaidFees = @PaidFees,
                         CreatedByUserID = @CreatedByUserID,
                         RetakeTestApplicationID = @RetakeTestApplicationID
                     WHERE TestAppointmentID = @TestAppointmentID 
                     AND IsLocked = 0;";

            SqlCommand command = new SqlCommand(query, connection);


            command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);

            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);

            command.Parameters.AddWithValue("@AppointmentDate", AppointmentDate);

            command.Parameters.AddWithValue("@PaidFees", PaidFees);

            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);


            if (RetakeTestApplicationID.HasValue)

                command.Parameters.AddWithValue("@RetakeTestApplicationID", RetakeTestApplicationID.Value);
            else
                command.Parameters.AddWithValue("@RetakeTestApplicationID", DBNull.Value);


            try
            {

                connection.Open();

                rowsAffected = command.ExecuteNonQuery();

            }

            catch (Exception ex)
            {

                return false;

            }

            finally
            {

                connection.Close();

            }


            return (rowsAffected > 0);

        }




        public static DataTable GetApplicationTestAppointmentsPerTestType(int LocalDrivingLicenseApplicationID, int TestTypeID)
        {

            DataTable dt = new DataTable();


            SqlConnection connection = new SqlConnection(CLSDataAccessSettings.ConnectionString);

            string query = @"SELECT TestAppointmentID, AppointmentDate, PaidFees, IsLocked, RetakeTestApplicationID
                     FROM TestAppointments
                     WHERE LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID
                       AND TestTypeID = @TestTypeID
                     ORDER BY AppointmentDate DESC;";

            SqlCommand command = new SqlCommand(query, connection);


            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);

            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);


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


        public static DataTable GetAllTestAppointments()
        {

            DataTable dt = new DataTable();


            SqlConnection connection = new SqlConnection(CLSDataAccessSettings.ConnectionString);

            string query = "SELECT * FROM TestAppointments ORDER BY AppointmentDate DESC";

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















