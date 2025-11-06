using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;





namespace DVLD_DataAccess
{

    public class CLSApplicationsData
    {

        public static bool GetApplicationInfoByID(int ApplicationID, ref int ApplicantPersonID, ref int ApplicationTypeID, ref Byte ApplicationStatus,
            ref DateTime ApplicationDate, ref decimal PaidFees, ref DateTime LastStatusDate,  ref int CreatedByUserID)
        {

            bool IsFound = false;


            string Query = "SELECT * FROM Applications WHERE ApplicationID = @ApplicationID;";

            using (SqlConnection connection = new SqlConnection(CLSDataAccessSettings.ConnectionString))

            using (SqlCommand command = new SqlCommand(Query , connection))
            {

                command.Parameters.AddWithValue("@ApplicationID" , ApplicationID);


                try
                {

                    connection.Open();


                    using (SqlDataReader Reader = command.ExecuteReader())
                    {

                        if (Reader.Read())
                        {

                            IsFound = true;


                            ApplicantPersonID = (int)Reader["ApplicantPersonID"];

                            ApplicationTypeID = (int)Reader["ApplicationTypeID"];

                            ApplicationStatus = (byte)Reader["ApplicationStatus"];

                            ApplicationDate = (DateTime)Reader["ApplicationDate"];

                            PaidFees = (decimal)Reader["PaidFees"];

                            LastStatusDate = (DateTime)Reader["LastStatusDate"];

                            CreatedByUserID = (int)Reader["CreatedByUserID"];

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

        public static bool IsApplicationExist(int ApplicationID)
        {

            bool IsFound = false;


            string Query = "SELECT FOUND = 1 FROM Applications WHERE ApplicationID = @ApplicationID;";

            using (SqlConnection connection = new SqlConnection(CLSDataAccessSettings.ConnectionString))

            using (SqlCommand command = new SqlCommand(Query, connection))
            {

                command.Parameters.AddWithValue("@ApplicationID" , ApplicationID);


                try
                {

                    connection.Open();


                    object result = command.ExecuteScalar();


                    if (result != null && int.TryParse(result.ToString(), out int FoundValue))
                    {

                        IsFound = true;

                    }

                }

                catch (Exception ex)
                {

                    IsFound = false;

                }

            }


            return IsFound;

        }


        public static int GetActiveApplicationID(int ApplicationPersonID , int ApplicationTypeID)
        {

            int ActiveApplicationID = -1;


            string Qruery = @"SELECT ApplicationID FROM Applications
                              WHERE ApplicationPersonID = @ApplicationPersonID
                              AND ApplicationTypeID = @ApplicationTypeID
                              AND ApplicationStatus = 1";

            using (SqlConnection connection = new SqlConnection(CLSDataAccessSettings.ConnectionString))

            using (SqlCommand command = new SqlCommand(Qruery , connection))
            {

                command.Parameters.AddWithValue("@ApplicationPersonID", ApplicationPersonID);

                command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);


                try
                {

                    connection.Open();

                    object result = command.ExecuteScalar();


                    if (result != null && int.TryParse(result.ToString(), out int AppID))
                    {

                        ActiveApplicationID = AppID;

                    }

                }

                catch (Exception ex)
                {

                    ActiveApplicationID = -1;

                }

            }


            return ActiveApplicationID;

        }

        public static int GetActiveApplicationIDForLicenseClass(int PersonID, int ApplicationTypeID, int LicenseClassID)
        {

            int ActiveApplicationID = -1;


            string Query = @"SELECT Applications.ApplicationID 
                 FROM Applications
                 INNER JOIN LocalDrivingLicenseApplications 
                 ON Applications.ApplicationID = LocalDrivingLicenseApplications.ApplicationID 
                 WHERE Applications.ApplicantPersonID = @ApplicantPersonID 
                 AND Applications.ApplicationTypeID = @ApplicationTypeID 
                 AND Applications.ApplicationStatus = 1
                 AND LocalDrivingLicenseApplications.LicenseClassID = @LicenseClassID";

            using (SqlConnection connection = new SqlConnection(CLSDataAccessSettings.ConnectionString))

            using (SqlCommand command = new SqlCommand(Query, connection))
            {

                command.Parameters.AddWithValue("@ApplicantPersonID", PersonID);

                command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);

                command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);


                try
                {

                    connection.Open();

                    object result = command.ExecuteScalar();


                    if (result != null && int.TryParse(result.ToString(), out int AppID))
                    {

                        ActiveApplicationID = AppID;

                    }

                }

                catch (Exception ex) {

                    ActiveApplicationID = -1;

                }

            }


            return ActiveApplicationID;

        }


        public static bool DoesPersonHaveActiveApplication(int ApplicationPersonID, int ApplicationTypeID)
        {

            return (GetActiveApplicationID(ApplicationPersonID, ApplicationTypeID) != -1);


        }




        public static int AddNewApplication(int ApplicantPersonID, int ApplicationTypeID, byte ApplicationStatus,
               DateTime ApplicationDate, decimal PaidFees, DateTime LastStatusDate, int CreatedByUserID)
        {

            int ApplicationID = -1;


            string Query = @"INSERT INTO Applications 
                     (ApplicantPersonID, ApplicationTypeID, ApplicationStatus, ApplicationDate, PaidFees, LastStatusDate, CreatedByUserID)
                     VALUES 
                     (@ApplicantPersonID, @ApplicationTypeID, @ApplicationStatus, @ApplicationDate, @PaidFees, @LastStatusDate, @CreatedByUserID);
                     SELECT SCOPE_IDENTITY();";

            using (SqlConnection connection = new SqlConnection(CLSDataAccessSettings.ConnectionString))
        
            using (SqlCommand command = new SqlCommand(Query, connection))
            {

                command.Parameters.AddWithValue("@ApplicantPersonID", ApplicantPersonID);

                command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);

                command.Parameters.AddWithValue("@ApplicationStatus", ApplicationStatus);

                command.Parameters.AddWithValue("@ApplicationDate", ApplicationDate);

                command.Parameters.AddWithValue("@PaidFees", PaidFees);

                command.Parameters.AddWithValue("@LastStatusDate", LastStatusDate); 

                command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);


                try
                {
                    connection.Open();

                    object result = command.ExecuteScalar();


                    if (result != null && decimal.TryParse(result.ToString(), out decimal insertedID))
                    {

                        ApplicationID = (int)insertedID;

                    }

                }

                catch (Exception ex)
                {

                    ApplicationID = -1;

                }

            }


            return ApplicationID;

        }


        public static bool UpdateApplication(int ApplicationID, int ApplicantPersonID, int ApplicationTypeID, byte ApplicationStatus,
                                    DateTime ApplicationDate, decimal PaidFees, DateTime LastStatusDate, int CreatedByUserID)
        {

            int RowsAffected = 0;


            string Query = @"UPDATE Applications
                     SET ApplicantPersonID = @ApplicantPersonID,
                         ApplicationTypeID = @ApplicationTypeID,
                         ApplicationStatus = @ApplicationStatus,
                         ApplicationDate = @ApplicationDate,
                         PaidFees = @PaidFees,
                         LastStatusDate = @LastStatusDate,
                         CreatedByUserID = @CreatedByUserID
                     WHERE ApplicationID = @ApplicationID";

            using (SqlConnection connection = new SqlConnection(CLSDataAccessSettings.ConnectionString))

            using (SqlCommand command = new SqlCommand(Query, connection))
            {

                command.Parameters.AddWithValue("@ApplicationID", ApplicationID);

                command.Parameters.AddWithValue("@ApplicantPersonID", ApplicantPersonID);

                command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);

                command.Parameters.AddWithValue("@ApplicationStatus", ApplicationStatus);

                command.Parameters.AddWithValue("@ApplicationDate", ApplicationDate);

                command.Parameters.AddWithValue("@PaidFees", PaidFees);

                command.Parameters.AddWithValue("@LastStatusDate", LastStatusDate);

                command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);


                try
                {

                    connection.Open();
                   
                    RowsAffected = command.ExecuteNonQuery();
               
                }

                catch (Exception ex)
                {

                    return false;

                }

            }


            return (RowsAffected > 0);

        }

        public static bool UpdateStatus(int ApplicationID, byte NewAppStatus)
        {

            int RowsAffected = 0;


            string Query = @"UPDATE Applications 
                             SET ApplicationStatus = @ApplicationStatus,
                                 LastStatusDate = GETDATE()
                           WHERE ApplicationID = @ApplicationID";

            using (SqlConnection connection = new SqlConnection(CLSDataAccessSettings.ConnectionString))

            using (SqlCommand command = new SqlCommand(Query, connection))
            {

                command.Parameters.AddWithValue("@ApplicationID", ApplicationID);

                command.Parameters.AddWithValue("@ApplicationStatus", NewAppStatus);


                try
                {

                    connection.Open();

                    RowsAffected = command.ExecuteNonQuery();

                }

                catch (Exception ex)
                {

                    return false;

                }

            }


            return (RowsAffected > 0);

        }


        public static bool DeleteApplication(int ApplicationID)
        {

            int RowsAffected = 0;


            string Query = @"DELETE FROM Applications
                     WHERE ApplicationID = @ApplicationID";

            using (SqlConnection connection = new SqlConnection(CLSDataAccessSettings.ConnectionString))

            using (SqlCommand command = new SqlCommand(Query, connection))
            {

                command.Parameters.AddWithValue("@ApplicationID", ApplicationID);


                try
                {

                    connection.Open();

                    RowsAffected = command.ExecuteNonQuery();

                }

                catch (Exception ex)
                {

                    return false;

                }

            }


            return (RowsAffected > 0);

        }




        public static DataTable GetAllApplications()
        {

            DataTable dt = new DataTable();


            string Query = "SELECT * FROM ApplicationsList_View order by ApplicationDate desc";

            using (SqlConnection connection = new SqlConnection(CLSDataAccessSettings.ConnectionString))

            using (SqlCommand command = new SqlCommand(Query, connection))
            {

                try
                {

                    connection.Open();


                    using (SqlDataReader Reader = command.ExecuteReader())
                    {

                        dt.Load(Reader);

                    }

                }

                catch (Exception ex)
                {



                }

            }


            return dt;

        }


    }

}
















