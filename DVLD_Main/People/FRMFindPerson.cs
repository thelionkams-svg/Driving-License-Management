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

    public partial class FRMFindPerson : Form
    {

        public delegate void DataBackEventHandler(object sender, int PersonID);

        // Declare an event using the delegate
        public event DataBackEventHandler DataBack;




        public FRMFindPerson()
        {
            InitializeComponent();
        }

        private void FRMFindPerson_Load(object sender, EventArgs e)
        {

        }

        private void BTNClose_Click(object sender, EventArgs e)
        {

            DataBack?.Invoke(this, ctrlPersonCardWithFilter1.PersonID);

            this.Close();

        }


    }

}
