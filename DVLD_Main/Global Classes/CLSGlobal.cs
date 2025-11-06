using System;
using System.IO;
using System.Linq;
using System.Text;
using DVLD_Business;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Collections.Generic;




namespace DVLD_Main.Global_Classes
{

    public static class CLSGlobal
    {


        public static int CurrentUserID { get; set; }
        public static string CurrentUserName { get; set; }
        public static int CurrentPersonID { get; set; }
        public static bool IsAdmin { get; set; }
    

        

        public static CLSUsersBusiness CurrentUser;


        public static bool RememberUserNameAndPassword(string Username, string Password)
        {

            /*

            try
            {

                string CurrentDirectry = System.IO.Directory.GetCurrentDirectory();


                string FilePath = CurrentDirectry + "\\ data.txt";


                if (File.Exists(FilePath) && Username == "")
                {

                    File.Delete(FilePath);

                    return true;

                }


                string DataToSave = Username + "#//#" + Password;


                using (StreamWriter writer = new StreamWriter(FilePath))
                {

                    writer.WriteLine(DataToSave);

                    return true;

                }

            }

            catch (Exception ex)
            {

                MessageBox.Show($"An error occurred: {ex.Message}");

                return false;

            }

            */

            try
            {

                Properties.Settings.Default.UserName = Username;

                Properties.Settings.Default.Password = Password;


                Properties.Settings.Default.Save();


                return true;

            }

            catch (Exception)
            {

                return false;

            }

        }

        public static bool GetStoredCredential(ref string Username, ref string Password)
        {

            /*

            try
            {

                string CurrentDirectory = System.IO.Directory.GetCurrentDirectory();

                string FilePath = CurrentDirectory + "\\ data.txt";



                if (File.Exists(FilePath))
                {

                    using (StreamReader reader = new StreamReader(FilePath))
                    {

                        string line;


                        while ((line = reader.ReadLine()) != null)
                        {

                            Console.WriteLine(line);

                            string[] result = line.Split(new string[] { "#//#" }, StringSplitOptions.None);

                            Username = result[0];

                            Password = result[1];

                        }


                        return true;

                    }

                }

                else
                {

                    return false;

                }


            }

            catch (Exception ex)
            {

                MessageBox.Show($"An error occurred: {ex.Message}");
              
                return false;

            }

            */

            Username = Properties.Settings.Default.UserName;

            Password = Properties.Settings.Default.Password;


            if (!string.IsNullOrEmpty(Username) && !string.IsNullOrEmpty(Password))
              
                return true;
            else
                return false;


        }



    }

}







