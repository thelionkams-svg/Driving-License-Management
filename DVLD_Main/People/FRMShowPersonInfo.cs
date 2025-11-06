using DVLD_Main.People.User_Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;




namespace DVLD_Main.People
{

    public partial class FRMShowPersonInfo : Form
    {

        public FRMShowPersonInfo(int PersonID)
        {

            InitializeComponent();


            ctrlUserCard11.LoadPersonInfo(PersonID);

        }

        public FRMShowPersonInfo(string NationalNo)
        {

            InitializeComponent();


            ctrlUserCard11.LoadPersonInfo(NationalNo);

        }


        private void BTNClose_Click(object sender, EventArgs e)
        {

            this.Close();

        }


        private void FRMShowPersonInfo_Load(object sender, EventArgs e)
        {

        }

        private void ctrlUserCard11_Load(object sender, EventArgs e)
        {

        }


    }

}






