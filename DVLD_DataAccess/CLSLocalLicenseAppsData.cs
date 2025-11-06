using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;









namespace DVLD_DataAccess
{

    public class CLSLocalLicenseAppsData
    {



        public static bool GetLocalDrivingLicenseApplicationInfoByApplicationID(int ApplicationID, ref int LocalDrivingLicenseApplicationID, ref int LicenseClassID)
        {

            bool IsFound = false;


            string Query = @"SELECT * FROM LocalDrivingLicenseApplications WHERE ApplicationID = @ApplicationID;";

            using (SqlConnection connection = new SqlConnection(CLSDataAccessSettings.ConnectionString))

            using (SqlCommand command = new SqlCommand(Query, connection))
            {

                command.Parameters.AddWithValue("@ApplicationID", ApplicationID);


                try
                {

                    connection.Open();


                    using (SqlDataReader Reader = command.ExecuteReader())
                    {

                        if (Reader.Read())
                        {

                            IsFound = true;


                            LocalDrivingLicenseApplicationID = (int)Reader["LocalDrivingLicenseApplicationID"];

                            LicenseClassID = (int)Reader["LicenseClassID"];

                        }

                    }

                }

                catch (Exception ex)
                {

                    IsFound = false;

                }
            }


            return IsFound;


        }

        public static bool GetLocalDrivingLicenseApplicationInfoByID(int LocalDrivingLicenseApplicationID, ref int ApplicationID, ref int LicenseClassID)
        {

            bool IsFound = false;


            string Query = @"SELECT * FROM LocalDrivingLicenseApplications 
                      WHERE LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID;";

            using (SqlConnection connection = new SqlConnection(CLSDataAccessSettings.ConnectionString))
  
            using (SqlCommand command = new SqlCommand(Query, connection))
            {

                command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);


                try
                {

                    connection.Open();


                    using (SqlDataReader Reader = command.ExecuteReader())
                    {

                        if (Reader.Read())
                        {

                            IsFound = true;


                            ApplicationID = (int)Reader["ApplicationID"];

                            LicenseClassID = (int)Reader["LicenseClassID"];

                        }

                    }

                }

                catch (Exception ex)
                {

                    IsFound = false;

                }

            }


            return IsFound;

        }



        public static bool DoesAttendTestType(int LocalDrivingLicenseApplicationID, int TestTypeID)
        {

            bool DoesAttend = false;


            string Query = @"SELECT FOUND = 1 
                             FROM Tests INNER JOIN TestAppointments
                             ON Tests.TestAppointmentID = TestAppointments.TestAppointmentID
                             WHERE TestAppointments.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID
                             AND TestAppointments.TestTypeID = @TestTypeID";

            using (SqlConnection connection = new SqlConnection(CLSDataAccessSettings.ConnectionString))
         
            using (SqlCommand command = new SqlCommand(Query, connection))
            {

                command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
               
                command.Parameters.AddWithValue("@TestTypeID", TestTypeID);


                try
                {

                    connection.Open();

                    object Result = command.ExecuteScalar();


                    if (Result != null)
                    {

                        DoesAttend = true;

                    }

                }

                catch (Exception ex)
                {

                    DoesAttend = false;

                }

            }


            return DoesAttend;

        }

        public static bool DoesPassTestType(int LocalDrivingLicenseApplicationID, int TestTypeID)
        {

            bool DoesPass = false;

            string Query = @"SELECT Found = 1 
                     FROM Tests 
                     INNER JOIN TestAppointments 
                        ON Tests.TestAppointmentID = TestAppointments.TestAppointmentID
                     WHERE TestAppointments.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID 
                       AND TestAppointments.TestTypeID = @TestTypeID
                       AND Tests.IsLocked = 1  
                       AND Tests.IsPassed = 1;";

            using (SqlConnection connection = new SqlConnection(CLSDataAccessSettings.ConnectionString))

            using (SqlCommand command = new SqlCommand(Query, connection))
            {

                command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);

                command.Parameters.AddWithValue("@TestTypeID", TestTypeID);


                try
                {

                    connection.Open();

                    object Result = command.ExecuteScalar();


                    if (Result != null)
                    {

                        DoesPass = true; 

                    }

                }

                catch (Exception ex)
                {

                    DoesPass = false;

                }

            }


            return DoesPass;

        }



        public static int TotalTrialsPerTest(int LocalDrivingLicenseApplicationID, int TestTypeID)
        {

            int TotalTrials = 0;


            string Query = @"SELECT COUNT(Tests.TestID) 
                     FROM Tests 
                     INNER JOIN TestAppointments 
                        ON Tests.TestAppointmentID = TestAppointments.TestAppointmentID
                     WHERE TestAppointments.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID 
                       AND TestAppointments.TestTypeID = @TestTypeID;";


            using (SqlConnection connection = new SqlConnection(CLSDataAccessSettings.ConnectionString))

            using (SqlCommand command = new SqlCommand(Query, connection))
            {

                command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);

                command.Parameters.AddWithValue("@TestTypeID", TestTypeID);


                try
                {

                    connection.Open();

                    object Result = command.ExecuteScalar();


                    if (Result != null && int.TryParse(Result.ToString(), out int ParsedTrials))
                    {

                        TotalTrials = ParsedTrials;

                    }

                }

                catch (Exception ex)
                {

                    TotalTrials = 0;

                }

            }


            return TotalTrials;

        }

        public static bool IsThereAnActiveScheduledTest(int LocalDrivingLicenseApplicationID, int TestTypeID)
        {

            bool IsActive = false;


            string Query = @"SELECT FOUND = 1 FROM TestAppointments
                             WHERE  LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID
                             AND    TestTypeID = @TestTypeID AND IsLocked = 0;";

            using (SqlConnection connection = new SqlConnection(CLSDataAccessSettings.ConnectionString))

            using (SqlCommand command = new SqlCommand(Query, connection))
            {

                command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
              
                command.Parameters.AddWithValue("@TestTypeID", TestTypeID);


                try
                {

                    connection.Open();

                    object Result = command.ExecuteScalar();


                    if (Result != null)
                    {

                        IsActive = true;

                    }

                }

                catch (Exception ex)
                {

                    IsActive = false;

                }

            }


            return IsActive;

        }



        public static int AddNewLocalDrivingLicenseApplication(int ApplicationID, int LicenseClassID)
        {

            int LocalDrivingLicenseApplicationID = -1;


            string Query = @"INSERT INTO LocalDrivingLicenseApplications 
                        (ApplicationID, LicenseClassID) 
                     VALUES 
                        (@ApplicationID, @LicenseClassID);
                     SELECT SCOPE_IDENTITY();";

            using (SqlConnection connection = new SqlConnection(CLSDataAccessSettings.ConnectionString))

            using (SqlCommand command = new SqlCommand(Query, connection))
            {

                command.Parameters.AddWithValue("@ApplicationID", ApplicationID);

                command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);


                try
                {

                    connection.Open();

                    object Result = command.ExecuteScalar();


                    if (Result != null && decimal.TryParse(Result.ToString(), out decimal insertedID))
                    {

                        LocalDrivingLicenseApplicationID = (int)insertedID;

                    }

                }

                catch (Exception ex)
                {

                    LocalDrivingLicenseApplicationID = -1;

                }
            }


            return LocalDrivingLicenseApplicationID;

        }

        public static bool UpdateLocalDrivingLicenseApplication(int LocalDrivingLicenseApplicationID, int LicenseClassID)
        {

            int RowsAffected = 0;


            string Query = @"UPDATE LocalDrivingLicenseApplications 
                     SET LicenseClassID = @LicenseClassID
                     WHERE LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID;";


            using (SqlConnection connection = new SqlConnection(CLSDataAccessSettings.ConnectionString))

            using (SqlCommand command = new SqlCommand(Query, connection))
            {

                command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);

                command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);


                try
                {

                    connection.Open();

                    RowsAffected = command.ExecuteNonQuery();

                }

                catch (Exception ex)
                {

                    // Logging

                }

            }


            return (RowsAffected > 0);

        }

        public static bool DeleteLocalDrivingLicenseApplication(int LocalDrivingLicenseApplicationID)
        {

            int RowsAffected = 0;


            string Query = @"DELETE FROM LocalDrivingLicenseApplications 
                     WHERE LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID;";


            using (SqlConnection connection = new SqlConnection(CLSDataAccessSettings.ConnectionString))
       
            using (SqlCommand command = new SqlCommand(Query, connection))
            {
          
                command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);


                try
                {

                    connection.Open();

                    RowsAffected = command.ExecuteNonQuery();

                }

                catch (Exception ex)
                {

                    // في حال وجود قيود (Foreign Key Constraints)، سيفشل الحذف هنا
                    // يجب أن يتم التعامل مع الحذف في طبقة الأعمال

                }

            }


            return (RowsAffected > 0);

        }



        public static DataTable GetAllLocalDrivingLicenseApplications()
        {

            DataTable dt = new DataTable();


            string Query = @"SELECT * FROM LocalDrivingLicenseApplications_View ORDER BY LocalDrivingLicenseApplicationID DESC;";

            using (SqlConnection connection = new SqlConnection(CLSDataAccessSettings.ConnectionString))
          
            using (SqlCommand command = new SqlCommand(Query, connection))
            {

                try
                {

                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {

                        if (reader.HasRows)
                        {

                            dt.Load(reader);

                        }

                    }

                }

                catch (Exception ex)
                {

                    // Logging

                }

            }


            return dt;

        }



    }

}






























