using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;




namespace DVLD_Main.Users2
{

    public partial class FRMUserInfo : Form
    {

        private int _UserID = -1;


        private void _LoadUserInfo(int UserID)
        {

            ctrlUserCard1.LoadUserInfo(UserID);

        }


        public FRMUserInfo(int UserID)
        {

            InitializeComponent();


            _UserID = UserID;

        }


        private void FRMUserInfo_Load(object sender, EventArgs e)
        {

            _LoadUserInfo(_UserID);

        }


        private void BTNClose_Click(object sender, EventArgs e)
        {

            this.Close();

        }


    }

}












