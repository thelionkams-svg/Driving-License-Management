using DVLD_Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;




namespace DVLD_Main.Users2.Users_Controls
{

    public partial class CTRLUserCard : UserControl
    {

        private CLSUsersBusiness _User;

        private int _UserID = -1;


        public int UserID {
            
            get{ return _UserID; }
        
        }



        private void _ResetPersonInfo()
        {

            ctrlPersonCard1.ResetPersonInfo();

            LBLUserID.Text = "[????]";

            LBLUserID.Text = "[????]";

            LBLIsActive.Text = "[????]";

        }

        private void _FillUserInfo()
        {

            ctrlPersonCard1.LoadPersonInfo(_User.PersonID);


            LBLUserID.Text = _User.UserID.ToString();

            LBLUserName.Text = _User.UserName.ToString();



            if (_User.IsActive)

                LBLIsActive.Text = "Yes";
            else
                LBLIsActive.Text = "No";

        }

        public void LoadUserInfo(int UserID)
        {

            _User = CLSUsersBusiness.FindUserID(UserID);


            if (_User == null)
            {

                _ResetPersonInfo();


                MessageBox.Show("User information not found with ID: " + UserID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);


                return;

            }


            _FillUserInfo();

        }


        public CTRLUserCard()
        {

            InitializeComponent();

        }


        private void CTRLUserCard_Load(object sender, EventArgs e)
        {



        }

        private void ctrlPersonCard1_Load(object sender, EventArgs e)
        {

        }
    }

}


























