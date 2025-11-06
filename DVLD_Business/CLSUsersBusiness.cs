using System;
using System.Data;
using System.Xml.Linq;
using DVLD_DataAccess;




namespace DVLD_Business
{

    public class CLSUsersBusiness
    {


        // التعدادات

        public enum enMode { AddNew = 0 , Update = 1 };

        enMode Mode = enMode.AddNew;



        // الخصائص

        public int UserID { get; set; }

        public int PersonID { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public bool IsActive { get; set; }

        public CLSPeopleBusiness PersonInfo { get; set; }



        // المنشئ

        public CLSUsersBusiness()
        {

            this.UserID = -1;

            this.PersonID = -1;

            this.UserName = "";

            this.Password = "";

            this.IsActive = true;

            this.PersonInfo = null;

            this.Mode = enMode.AddNew;

        }

        private CLSUsersBusiness(int UserID, int PersonID, string UserName, string Password, bool IsActive)
        {

            this.UserID = UserID;

            this.PersonID = PersonID;

            this.UserName = UserName;

            this.Password = Password;

            this.IsActive = IsActive;

            // ربط بكائن الشخص المرتبط

            this.PersonInfo = CLSPeopleBusiness.Find(PersonID);

            this.Mode = enMode.Update;

        }



        // دوال البحث

        public static CLSUsersBusiness FindUserID(int UserID)
        {

            int PersonID = -1;

            string UserName = "", Password = "";

            bool IsActive = false;


            if (CLSUsersData.GetUserInfoByUserID(UserID, ref PersonID, ref UserName, ref Password, ref IsActive))
            {

                return new CLSUsersBusiness(UserID, PersonID, UserName, Password, IsActive);

            }

            else
            {

                return null;

            }

        }

        public static CLSUsersBusiness FindByPersonID(int PersonID)
        {

            int UserID = -1;

            string UserName = "", Password = "";

            bool IsActive = false;


            if (CLSUsersData.GetUserInfoByPersonID(PersonID, ref UserID, ref UserName, ref Password, ref IsActive))
            {

                return new CLSUsersBusiness(UserID, PersonID, UserName, Password, IsActive);

            }

            else
            {

                return null;

            }

        }

        public static CLSUsersBusiness FindUserNameAndPassword(string UserName , string Password = "")
        {

            int UserID = -1, PersonID = -1;
            
            bool IsActive = false;


            if (CLSUsersData.GetUserInfoByUsernameAndPassword(UserName, Password, ref UserID, ref PersonID, ref IsActive))
            {

                return new CLSUsersBusiness(UserID, PersonID, UserName, Password, IsActive);

            }

            else
            {

                return null;

            }

        }



        // دوال التحقق

        public static bool IsUserExist(int UserID)
        {

            return CLSUsersData.IsUserExist(UserID);

        }

        public static bool IsUserExist(string UserName)
        {

            return CLSUsersData.IsUserExist(UserName);

        }

        public static bool IsPersonHasUser(int PersonID)
        {

            return CLSUsersData.IsPersonHasUser(PersonID);

        }



        // دوال الادارة

        private bool _AddNewUser()
        {

            this.UserID = CLSUsersData.AddNewUser(this.PersonID, this.UserName, this.Password, this.IsActive);

            return (this.UserID != -1);

        }

        private bool _UpdateUser()
        {

            return CLSUsersData.UpdateUser(this.UserID, this.PersonID, this.UserName, this.Password, this.IsActive);

        }

        public bool Save()
        {

            switch (this.Mode)
            {

                case enMode.AddNew:

                    if (_AddNewUser())
                    {

                        this.Mode = enMode.Update;

                        return true;

                    }

                    else
                    {

                        return false;

                    }

                case enMode.Update:

                    return _UpdateUser();

                default:

                    return false;

            }

        }


        public static bool Delete(int UserID)
        {

            return CLSUsersData.DeleteUser(UserID);

        }

        public bool Delete()
        {

            return Delete(this.UserID);

        }




        // دالة القائمة

        public static DataTable GetAllUsers()
        {

            return CLSUsersData.GetAllUsers();

        }







         /*

            **🎯 ممتاز! دعني ألخص خطوات بناء طبقة الأعمال (Business Layer):**

            ## 📋 **الخطوات الأساسية لـ `CLSUsersBusiness`:**




            ### **1. إنشاء الخصائص (Properties)**
            ```csharp
            public int UserID { get; set; }
            public int PersonID { get; set; }
            public string UserName { get; set; }
            public string Password { get; set; }
            public bool IsActive { get; set; }
            public CLSPeopleBusiness PersonInfo { get; set; } // ربط بكائن الشخص
            ```




            ### **2. تعريف الأنماط (Enums)**
            ```csharp
            public enum enMode { AddNew = 0, Update = 1 };
            public enMode Mode = enMode.AddNew;
            ```




            ### **3. المنشئات (Constructors)**
            - **منشئ افتراضي** للإضافة
            - **منشئ خاص** للتعديل (بيانات موجودة)




            ### **4. دوال البحث (Find)**
            - `Find(int UserID)`
            - `Find(string UserName)` 
            - `FindByPersonID(int PersonID)`




            ### **5. دوال العمليات (Save, Delete)**
            - `_AddNewUser()` - خاص بالإضافة
            - `_UpdateUser()` - خاص بالتحديث  
            - `Save()` - دالة رئيسية تحدد الإضافة أو التحديث
            - `Delete()` - حذف المستخدم




            ### **6. دوال التحقق (Validation)**
            - `IsUserExist()`
            - `IsPersonHasUser()`




            ### **7. دوال الخدمات**
            - `ChangePassword()`
            - `ActivateUser()`
            - `DeactivateUser()`




            ### **8. دوال القوائم**
            - `GetAllUsers()` - ترجع DataTable

            ---

            ## 🔄 **النمط المتوقع (مثل CLSPeopleBusiness):**
            ```
            خاصية ← منشئ ← Find ← Save/Delete ← خدمات
            ```

            **هل تريد أن نبدأ في تنفيذ هذه الخطوات؟ أم تريد شرح أي جزء أولاً؟** 😊


         */








    }

}











