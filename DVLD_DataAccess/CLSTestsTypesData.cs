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

    public class CLSTestsTypesData
    {

        public static DataTable GetAllTestTypes()
        {

            DataTable dt = new DataTable();


            using (SqlConnection connection = new SqlConnection(CLSDataAccessSettings.ConnectionString))
            {

                string query = "SELECT * FROM TestTypes ORDER BY TestTypeID";


                using (SqlCommand command = new SqlCommand(query, connection))
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

                        // يجب تسجيل الخطأ (Logging) هنا

                    }

                }

            }


            return dt;

        }


        public static bool GetTestTypeInfoByID(int TestTypeID, ref string Title, ref string Description, ref decimal Fees)
        {

            bool IsFound = false;


            using (SqlConnection connection = new SqlConnection(CLSDataAccessSettings.ConnectionString))
            {

                string query = "SELECT * FROM TestTypes WHERE TestTypeID = @TestTypeID";


                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    command.Parameters.AddWithValue("@TestTypeID", TestTypeID);


                    try
                    {

                        connection.Open();


                        using (SqlDataReader reader = command.ExecuteReader())
                        {

                            if (reader.Read())
                            {

                                IsFound = true;


                                Title = (string)reader["TestTypeTitle"];

                                Description = (string)reader["TestTypeDescription"];

                                Fees = (decimal)reader["TestTypeFees"];

                            }

                        }

                    }

                    catch (Exception ex)
                    {

                        IsFound = false;

                    }

                }

            }


            return IsFound;

        }


        public static int AddNewTestType(string Title, string Description, decimal Fees)
        {

            int TestTypeID = -1;


            using (SqlConnection connection = new SqlConnection(CLSDataAccessSettings.ConnectionString))
            {

                string query = @"INSERT INTO TestTypes (TestTypeTitle, TestTypeDescription, TestTypeFees)
                         VALUES (@Title, @Description, @Fees);
                         SELECT SCOPE_IDENTITY();";


                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    command.Parameters.AddWithValue("@Title", Title);

                    command.Parameters.AddWithValue("@Description", Description);

                    command.Parameters.AddWithValue("@Fees", Fees);


                    try
                    {

                        connection.Open();

                        object result = command.ExecuteScalar();


                        if (result != null && int.TryParse(result.ToString(), out int insertedID))
                        {

                            TestTypeID = insertedID;

                        }

                    }

                    catch (Exception ex)
                    {

                        // يجب تسجيل الخطأ هنا

                    }

                } 

            }


            return TestTypeID;

        }

        public static bool UpdateTestType(int TestTypeID, string Title, string Description, decimal Fees)
        {

            int rowsAffected = 0;


            using (SqlConnection connection = new SqlConnection(CLSDataAccessSettings.ConnectionString))
            {

                string query = @"UPDATE TestTypes
                                 SET TestTypeTitle = @Title,
                                     TestTypeDescription = @Description,
                                     TestTypeFees = @Fees
                                 WHERE TestTypeID = @TestTypeID";


                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

                    command.Parameters.AddWithValue("@Title", Title);

                    command.Parameters.AddWithValue("@Description", Description);

                    command.Parameters.AddWithValue("@Fees", Fees); 


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

    }

}















