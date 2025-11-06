using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DVLD_DataAccess.CLSCountryData;
using System.Net;
using System.Security.Policy;






namespace DVLD_DataAccess
{

    public class CLSAppTypesData
    {

        public static bool GetApplicationTypeInfoByID(int ApplicationTypeID, ref string ApplicationTypeTitle, ref decimal ApplicationFees)
        {

            bool IsFound = false;


            using (SqlConnection connection = new SqlConnection(CLSDataAccessSettings.ConnectionString))
            {

                string query = "SELECT * FROM ApplicationTypes WHERE ApplicationTypeID = @ApplicationTypeID";


                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);


                    try
                    {

                        connection.Open();

                        SqlDataReader reader = command.ExecuteReader();


                        if (reader.Read())
                        {

                            IsFound = true;


                            ApplicationTypeTitle = (string)reader["ApplicationTypeTitle"];

                            ApplicationFees = (decimal)reader["ApplicationFees"];

                        }
                    
                        else
                        {

                            IsFound = false;

                        }


                        reader.Close(); 
                    
                    }
                    catch (Exception ex)
                    {
                        // إزالة واجهة المستخدم من طبقة البيانات
                        // Console.WriteLine(ex.Message);
                        IsFound = false;
                    }
                } 
            
            } 


            return IsFound;

        }


        public static int AddNewApplicationType(string ApplicationTypeTitle, decimal ApplicationFees)
        {

            int ApplicationTypeID = -1;


            using (SqlConnection connection = new SqlConnection(CLSDataAccessSettings.ConnectionString))
            {

                string query = @"INSERT INTO ApplicationTypes (ApplicationTypeTitle, ApplicationFees)
                         VALUES (@ApplicationTypeTitle, @ApplicationFees);
                         
                         SELECT SCOPE_IDENTITY();"; 


                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    command.Parameters.AddWithValue("@ApplicationTypeTitle", ApplicationTypeTitle);
                  
                    command.Parameters.AddWithValue("@ApplicationFees", ApplicationFees);


                    try
                    {

                        connection.Open();


                        object result = command.ExecuteScalar();


                        if (result != null && int.TryParse(result.ToString(), out int insertedID))
                        {

                            ApplicationTypeID = insertedID;

                        }

                    }

                    catch (Exception ex)
                    {

                        // Console.WriteLine(ex.Message); 

                    }

                } 
            
            } 


            return ApplicationTypeID;

        }

        public static bool UpdateApplicationType(int ApplicationTypeID, string ApplicationTypeTitle, decimal ApplicationFees)
        { 

            int rowsAffected = 0;


            using (SqlConnection connection = new SqlConnection(CLSDataAccessSettings.ConnectionString))
            {

                string query = @"UPDATE ApplicationTypes
                                     SET ApplicationTypeTitle = @ApplicationTypeTitle,
                                         ApplicationFees = @ApplicationFees
                                     WHERE ApplicationTypeID = @ApplicationTypeID";


                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);
                    
                    command.Parameters.AddWithValue("@ApplicationTypeTitle", ApplicationTypeTitle);
                    
                    command.Parameters.AddWithValue("@ApplicationFees", ApplicationFees);


                    try
                    {

                        connection.Open();

                        rowsAffected = command.ExecuteNonQuery();

                    }

                    catch (Exception ex)
                    {

                        rowsAffected = 0;

                    }
                     
                } 

            } 


            return (rowsAffected > 0);

        }



        public static DataTable GetAllApplicationTypes()
        {

            DataTable dt = new DataTable();


            using (SqlConnection connection = new SqlConnection(CLSDataAccessSettings.ConnectionString))
            {

                string query = "SELECT * FROM ApplicationTypes ORDER BY ApplicationTypeID";


                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    try
                    {

                        connection.Open();

                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.HasRows)
                        {

                            dt.Load(reader);

                        }

                    }

                    catch (Exception ex)
                    {

                        // Console.WriteLine(ex.Message); 

                    }

                }

            }

            return dt;

        }


    }

}









