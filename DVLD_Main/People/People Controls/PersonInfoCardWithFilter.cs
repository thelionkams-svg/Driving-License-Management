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




namespace DVLD_Main.People.User_Controls
{

    public partial class CTRLPersonCardWithFilter : UserControl
    {

        public event Action<int> OnPersonSelected;

        protected virtual void PersonSelected(int PersonID){

            Action<int> Handler = OnPersonSelected;


            if (Handler != null)
            {

                Handler(PersonID);

            }

        }




        private bool _ShowAddPerson = true;

        private bool _FilterEnabled = true;

        private int _PersonID = -1;



        public bool ShowAddPerson
        {

            set {

                _ShowAddPerson =(value);
            
                BTNAddNew.Visible = _ShowAddPerson;
            
            }


            get { return _ShowAddPerson; }

        }

        public bool FilterEnabled
        {

            set
            {

                _FilterEnabled = value;

                GBFilter.Enabled = _FilterEnabled;

            }

            get { return _FilterEnabled; }

        }

        public int PersonID
        {

            get { return ctrlPersonCard1.PersonID; }

        }


        public CLSPeopleBusiness SelectedPersonInfo
        {

            get { return ctrlPersonCard1.PersonInfo; }

        }




        public CTRLPersonCardWithFilter()
        {
            InitializeComponent();
        }

        private void CTRLPersonCardWithFilter_Load(object sender, EventArgs e)
        {

            CBFilterBy.SelectedIndex = 0;

            TXTFilterValue.Focus(); 

        }

        private void ctrlUserCard11_Load(object sender, EventArgs e)
        {

        }



        private void FindNow()
        {

            switch (CBFilterBy.Text)
            {

                case "Person ID":

                    ctrlPersonCard1.LoadPersonInfo(int.Parse(TXTFilterValue.Text));

                    break;

                case "National No":

                    ctrlPersonCard1.LoadPersonInfo(TXTFilterValue.Text);

                    break;

                default:

                    break;

            }


            

            if (OnPersonSelected != null && FilterEnabled)

                OnPersonSelected(ctrlPersonCard1.PersonID);

            



        }

        private void BTNFind_Click_1(object sender, EventArgs e)
        {

            if (!this.ValidateChildren())
            {

                //Here we dont continue becuase the form is not valid

                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;

            }

            FindNow();


        }



        public void LoadPersonInfo(int PersonID)
        {

            /*

            CBFilterBy.SelectedIndex = 1; // Person ID


            TXTFilterValue.Text = PersonID.ToString();

            FindNow();

            */


            ctrlPersonCard1.LoadPersonInfo(PersonID);


            CBFilterBy.SelectedIndex = 1;

            TXTFilterValue.Text = PersonID.ToString();


            errorProvider1.SetError(TXTFilterValue, null);


            if (ctrlPersonCard1.PersonID != -1)
            {

                OnPersonSelected?.Invoke(ctrlPersonCard1.PersonID);

            }


        }

        public void LoadPersonInfoByNationalNo(string nationalNo)
        {
            CBFilterBy.SelectedIndex = 0; // National No.
            TXTFilterValue.Text = nationalNo;
            FindNow();
        }

        private void DataBackEvent(object sender, int PersonID)
        {

            CBFilterBy.SelectedIndex = 1;

            TXTFilterValue.Text = PersonID.ToString();

            ctrlPersonCard1.LoadPersonInfo(PersonID);

        }

        private void BTNAddNew_Click(object sender, EventArgs e)
        {

            FRMAddUpdatePerson frm1 = new FRMAddUpdatePerson();

            frm1.DataBack += DataBackEvent;

            frm1.ShowDialog();


        }



        private void TXTFilterValue_Validating(object sender, CancelEventArgs e)
        {

            if (string.IsNullOrEmpty(TXTFilterValue.Text.Trim()))
            {

                e.Cancel = true;

                errorProvider1.SetError(TXTFilterValue, "This field is required!");

            }

            else
            {

                errorProvider1.SetError(TXTFilterValue, null);

            }

        }

        private void TXTFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == (Char)13)
            {

                BTNFind.PerformClick();

            }

            if (CBFilterBy.Text == "Person ID")
            {

                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

            }

        }



        public void FilterFocus()
        {

            TXTFilterValue.Focus();

        }

        private void CBFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {

            TXTFilterValue.Text = "";

            TXTFilterValue.Focus();

        }





    }

}




