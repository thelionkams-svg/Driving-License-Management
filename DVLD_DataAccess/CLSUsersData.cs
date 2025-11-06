using System;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Data;







namespace DVLD_DataAccess
{

    public class CLSUsersData
    {


        // دوال البحث والاسترجاع

        public static bool GetUserInfoByUserID(int UserID, ref int PersonID, ref string UserName, ref string Password, ref bool IsActive)
        {

            bool IsFound = false;


            SqlConnection connection = new SqlConnection(CLSDataAccessSettings.ConnectionString);

            string query = "SELECT * FROM Users WHERE UserID = @UserID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@UserID", UserID);


            try
            {

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();


                if (reader.Read())
                {

                    IsFound = true;


                    PersonID = (int)reader["PersonID"];

                    UserName = (string)reader["UserName"];

                    Password = (string)reader["Password"];

                    IsActive = (bool)reader["IsActive"];

                }


                reader.Close();

            }

            catch (Exception ex)
            {

                IsFound = false;

            }

            finally
            {

                connection.Close();

            }


            return IsFound;

        }


        public static bool GetUserInfoByPersonID(int PersonID, ref int UserID, ref string UserName, ref string Password, ref bool IsActive)
        {

            bool IsFound = false;


            SqlConnection connection = new SqlConnection(CLSDataAccessSettings.ConnectionString);

            string query = "SELECT * FROM Users WHERE PersonID = @PersonID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PersonID", PersonID);


            try
            {

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();


                if (reader.Read())
                {

                    IsFound = true;


                    UserID = (int)reader["UserID"];

                    UserName = (string)reader["UserName"];

                    Password = (string)reader["Password"];

                    IsActive = (bool)reader["IsActive"];

                }


                reader.Close();

            }

            catch (Exception ex)
            {

                IsFound = false;

            }

            finally
            {

                connection.Close();

            }


            return IsFound;

        }


        public static bool GetUserInfoByUsernameAndPassword(string Username, string Password, ref int UserID, ref int PersonID, ref bool IsActive)
        {

            bool IsFound = false;


            SqlConnection connection = new SqlConnection(CLSDataAccessSettings.ConnectionString);

            string query = "SELECT * FROM Users WHERE Username = @Username and Password=@Password;";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@Username", Username);

            command.Parameters.AddWithValue("@Password", Password);



            try
            {

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                

                if (reader.Read())
                {

                    IsFound = true;


                    UserID = (int)reader["UserID"];

                    PersonID = (int)reader["PersonID"];

                    Username = (string)reader["UserName"];

                    Password = (string)reader["Password"];

                    IsActive = (bool)reader["IsActive"];

                }


                reader.Close();

            }

            catch (Exception ex)
            {

                IsFound = false;

            }

            finally
            {

                connection.Close();

            }


            return IsFound;

        }



        // دوال التحقق

        public static bool IsUserExist(int UserID)
        {

            bool IsFound = false;


            SqlConnection connection = new SqlConnection(CLSDataAccessSettings.ConnectionString);

            string query = "SELECT Found=1 FROM Users WHERE UserID = @UserID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@UserID", UserID);


            try
            {

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                IsFound = reader.HasRows;

                reader.Close();

            }

            catch (Exception ex)
            {

                IsFound = false;

            }

            finally
            {

                connection.Close();

            }


            return IsFound;

        }


        public static bool IsUserExist(string Username)
        {

            bool IsFound = false;


            SqlConnection connection = new SqlConnection(CLSDataAccessSettings.ConnectionString);

            string query = "SELECT Found=1 FROM Users WHERE UserName = @UserName";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@UserName", Username);


            try
            {

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                IsFound = reader.HasRows;

                reader.Close();

            }

            catch (Exception ex)
            {

                IsFound = false;

            }

            finally
            {

                connection.Close();

            }


            return IsFound;

        }


        public static bool IsPersonHasUser(int PersonID)
        {

            bool IsFound = false;
            

            SqlConnection connection = new SqlConnection(CLSDataAccessSettings.ConnectionString);

            string query = "SELECT Found=1 FROM Users WHERE PersonID = @PersonID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PersonID", PersonID);


            try
            {

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                IsFound = reader.HasRows;

                reader.Close();

            }

            catch (Exception ex)
            {

                IsFound = false;

            }

            finally
            {

                connection.Close();

            }


            return IsFound;

        }



        // دوال الإدارة

        /*

        public static int AddNewUser(int PersonID, string UserName, string Password, bool IsActive)
        {

            int UserID = -1;


            SqlConnection connection = new SqlConnection(CLSDataAccessSettings.ConnectionString);

            string query = @"INSERT INTO Users (PersonID, UserName, Password, IsActive, CreatedDate)
                     VALUES (@PersonID, @UserName, @Password, @IsActive);
                     SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);


            command.Parameters.AddWithValue("@PersonID", PersonID);

            command.Parameters.AddWithValue("@UserName", UserName);

            command.Parameters.AddWithValue("@Password", Password);

            command.Parameters.AddWithValue("@IsActive", IsActive);


            try
            {

                connection.Open();

                object result = command.ExecuteScalar();


                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {

                    UserID = insertedID;

                }

            }

            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);

            }

            finally
            {

                connection.Close();

            }


            return UserID;

        }

        */

        public static int AddNewUser(int PersonID, string UserName, string Password, bool IsActive)
        {

            int UserID = -1;


            using (SqlConnection connection = new SqlConnection(CLSDataAccessSettings.ConnectionString))
            {

                string query = @"INSERT INTO Users (PersonID, UserName, Password, IsActive)
                         VALUES (@PersonID, @UserName, @Password, @IsActive);
                         SELECT SCOPE_IDENTITY();";


                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    command.Parameters.AddWithValue("@PersonID", PersonID);

                    command.Parameters.AddWithValue("@UserName", UserName);

                    command.Parameters.AddWithValue("@Password", Password);

                    command.Parameters.AddWithValue("@IsActive", IsActive);


                    try
                    {
                        connection.Open();

                        object result = command.ExecuteScalar();


                        if (result != null && int.TryParse(result.ToString(), out int insertedID))
                        {

                            UserID = insertedID;

                        }

                    }

                    catch (SqlException ex)
                    {

                        // عرض رسالة الخطأ بالتفصيل لمعرفة السبب الحقيقي

                        throw new Exception("Database Error: " + ex.Message, ex);

                    }
                    
                }

            }


            return UserID;

        }


        public static bool UpdateUser(int UserID, int PersonID, string UserName, string Password, bool IsActive)
        {

            int rowsAffected = 0;


            SqlConnection connection = new SqlConnection(CLSDataAccessSettings.ConnectionString);

            string query = @"UPDATE Users 
                     SET PersonID = @PersonID,
                         UserName = @UserName, 
                         Password = @Password, 
                         IsActive = @IsActive
                     WHERE UserID = @UserID";

            SqlCommand command = new SqlCommand(query, connection);


            command.Parameters.AddWithValue("@UserID", UserID);

            command.Parameters.AddWithValue("@PersonID", PersonID);

            command.Parameters.AddWithValue("@UserName", UserName);

            command.Parameters.AddWithValue("@Password", Password);

            command.Parameters.AddWithValue("@IsActive", IsActive);


            try
            {

                connection.Open();

                rowsAffected = command.ExecuteNonQuery();

            }

            catch (Exception ex)
            {

                // معالجة الخطأ

            }

            finally
            {

                connection.Close();

            }


            return (rowsAffected > 0);

        }


        public static bool DeleteUser(int UserID)
        {

            int rowsAffected = 0;


            SqlConnection connection = new SqlConnection(CLSDataAccessSettings.ConnectionString);

            string query = "DELETE FROM Users WHERE UserID = @UserID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@UserID", UserID);


            try
            {

                connection.Open();

                rowsAffected = command.ExecuteNonQuery();

            }

            catch (Exception ex)
            {

                // معالجة الخطأ

            }

            finally
            {

                connection.Close();

            }


            return (rowsAffected > 0);

        }



        // دوال إدارة كلمة المرور

        public static bool ChangePassword(int UserID, string NewPassword)
        {

            int rowsAffected = 0;


            SqlConnection connection = new SqlConnection(CLSDataAccessSettings.ConnectionString);

            string query = "UPDATE Users SET Password = @Password WHERE UserID = @UserID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@UserID", UserID);

            command.Parameters.AddWithValue("@Password", NewPassword);


            try
            {

                connection.Open();

                rowsAffected = command.ExecuteNonQuery();

            }

            catch (Exception ex)
            {

                // معالجة الخطأ

            }

            finally
            {

                connection.Close();

            }


            return (rowsAffected > 0);

        }



        // دالة قائمة المستخدمين

        public static DataTable GetAllUsers()
        {

            DataTable dt = new DataTable();


            SqlConnection connection = new SqlConnection(CLSDataAccessSettings.ConnectionString);

            string query = @"SELECT  Users.UserID, Users.PersonID,
                            FullName = People.FirstName + ' ' + People.SecondName + ' ' + ISNULL( People.ThirdName,'') +' ' + People.LastName,
                             Users.UserName, Users.IsActive
                             FROM  Users INNER JOIN
                                    People ON Users.PersonID = People.PersonID";

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

                // معالجة الخطأ

            }

            finally
            {

                connection.Close();

            }


            return dt;

        }




    //*****************************************************************************************************************************************************





        /*


        // دالة التاكد من ان كلمة المرور صحيحة


        public static bool CheckIfPasswordCorrect(int UserID, string Password)
        {

            bool IsCorrect = false;


            SqlConnection connection = new SqlConnection(CLSDataAccessSettings.ConnectionString);

            string query = "SELECT Found=1 FROM Users WHERE UserID = @UserID AND Password = @Password";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@UserID", UserID);

            command.Parameters.AddWithValue("@Password", Password);


            try
            {

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                IsCorrect = reader.HasRows;

                reader.Close();

            }

            catch (Exception ex)
            {

                IsCorrect = false;

            }

            finally
            {

                connection.Close();

            }


            return IsCorrect;

        }





        // دالة تسجيل الدخول

        public static bool ValidateUserCredentials(string Username, string Password, ref int UserID, ref bool IsActive)
        {

            bool IsValid = false;


            SqlConnection connection = new SqlConnection(CLSDataAccessSettings.ConnectionString);

            string query = @"SELECT UserID, IsActive FROM Users 
                     WHERE UserName = @UserName AND Password = @Password";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@UserName", Username);

            command.Parameters.AddWithValue("@Password", Password);


            try
            {

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();


                if (reader.Read())
                {

                    UserID = (int)reader["UserID"];

                    IsActive = (bool)reader["IsActive"];

                    IsValid = true;
                }


                reader.Close();

            }

            catch (Exception ex)
            {

                IsValid = false;

            }

            finally
            {

                connection.Close();

            }


            return IsValid;

        }





        // دوال حالة المستخدم


        // 1. دالة تفعيل المستخدم

        public static bool ActivateUser(int UserID)
        {
            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(CLSDataAccessSettings.ConnectionString);

            string query = "UPDATE Users SET IsActive = 1 WHERE UserID = @UserID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@UserID", UserID);

            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                // معالجة الخطأ
            }
            finally
            {
                connection.Close();
            }

            return (rowsAffected > 0);
        }


        // 2. دالة إلغاء تفعيل المستخدم
        public static bool DeactivateUser(int UserID)
        {
            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(CLSDataAccessSettings.ConnectionString);

            string query = "UPDATE Users SET IsActive = 0 WHERE UserID = @UserID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@UserID", UserID);

            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                // معالجة الخطأ
            }
            finally
            {
                connection.Close();
            }

            return (rowsAffected > 0);
        }


        // 3. دالة تبديل حالة المستخدم (اختيارية - مفيدة)
        public static bool ToggleUserStatus(int UserID)
        {
            // نجلب حالة المستخدم الحالية أولاً
            bool currentStatus = false;
            int personID = -1;
            string userName = "", password = "";

            if (!GetUserInfoByUserID(UserID, ref personID, ref userName, ref password, ref currentStatus))
                return false;

            // نبدل الحالة
            if (currentStatus)
                return DeactivateUser(UserID); // إذا كان نشطاً، نلغى التفعيل
            else
                return ActivateUser(UserID);   // إذا كان غير نشط، نفعله
        }


        // دالة التحقق من حالة المستخدم (هل هو نشط أم لا)
        public static bool IsUserActive(int UserID)
        {
            bool IsActive = false;
            SqlConnection connection = new SqlConnection(CLSDataAccessSettings.ConnectionString);

            string query = "SELECT IsActive FROM Users WHERE UserID = @UserID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@UserID", UserID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    IsActive = (bool)reader["IsActive"];
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                IsActive = false;
            }
            finally
            {
                connection.Close();
            }

            return IsActive;
        }



        */




    }

}









