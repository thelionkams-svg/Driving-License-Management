using DVLD_Business;
using DVLD_Main.People;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;




namespace DVLD_Main
{

    public partial class FRMListPeople : Form
    {


        private static DataTable _dtAllPeople = CLSPeopleBusiness.GetAllPeople();

        private static DataTable _dtPeople = _dtAllPeople.DefaultView.ToTable(

            false, "PersonID", "NationalNo", "FirstName", "SecondName", "ThirdName", "LastName",
            
            "GendorCaption", "DateOfBirth", "CountryName", "Phone", "Email"

        );    



        private void _RefreshPeopleList()
        {

            _dtAllPeople = CLSPeopleBusiness.GetAllPeople();

            _dtPeople = _dtAllPeople.DefaultView.ToTable(

                false, "PersonID", "NationalNo", "FirstName", "SecondName", "ThirdName", "LastName",

                "GendorCaption", "DateOfBirth", "CountryName", "Phone", "Email"

            );



            DVGPeopleList.DataSource = _dtPeople;

            LBLRecordsCount.Text = DVGPeopleList.Rows.Count.ToString();


        }



        public FRMListPeople()
        {

            InitializeComponent();

        }



        private void FRMListPeople_Load(object sender, EventArgs e)
        {

            DVGPeopleList.DataSource= _dtPeople;

            LBLRecordsCount.Text = DVGPeopleList.Rows.Count.ToString();

            CBFiletryBy.SelectedIndex = 0;


            if (DVGPeopleList.Rows.Count > 0)
            {


                DVGPeopleList.Columns[0].HeaderText = "PersonID";
                DVGPeopleList.Columns[0].Width = 110;


                DVGPeopleList.Columns[1].HeaderText = "National No.";
                DVGPeopleList.Columns[1].Width = 120;


                DVGPeopleList.Columns[2].HeaderText = "First Name";
                DVGPeopleList.Columns[2].Width = 120;

                DVGPeopleList.Columns[3].HeaderText = "Second Name";
                DVGPeopleList.Columns[3].Width = 140;


                DVGPeopleList.Columns[4].HeaderText = "Third Name";
                DVGPeopleList.Columns[4].Width = 120;

                DVGPeopleList.Columns[5].HeaderText = "Last Name";
                DVGPeopleList.Columns[5].Width = 120;

                DVGPeopleList.Columns[6].HeaderText = "Gendor";
                DVGPeopleList.Columns[6].Width = 120;

                DVGPeopleList.Columns[7].HeaderText = "Date Of Birth";
                DVGPeopleList.Columns[7].Width = 140;

                DVGPeopleList.Columns[8].HeaderText = "Nationality";
                DVGPeopleList.Columns[8].Width = 120;


                DVGPeopleList.Columns[9].HeaderText = "Phone";
                DVGPeopleList.Columns[9].Width = 120;


                DVGPeopleList.Columns[10].HeaderText = "Email";
                DVGPeopleList.Columns[10].Width = 170;


            }


            DVGPeopleList.AllowUserToAddRows = false;


        }



        private void CBFiletryBy_SelectedIndexChanged(object sender, EventArgs e)
        {

            TXTFilterValue.Visible = (CBFiletryBy.Text != "None");

            if (TXTFilterValue.Visible)
            {
                TXTFilterValue.Text = "";
                TXTFilterValue.Focus();
            }


        }

        private void TXTFilterValue_TextChanged(object sender, EventArgs e)
        {

            // هذا التعريف لتعريف اسم العمود الذي سيتم البحث فيه

            string FilterColumn = "";



            // الجزء الاول خاص باختيار العمود الذي سيتم البحث فيه بناءا علي خيار الفلترة

            switch (CBFiletryBy.Text)
            {

                case "Person ID":

                    FilterColumn = "PersonID";

                    break;

                case "National No.":

                    FilterColumn = "NationalNo";

                    break;

                case "First Name":

                    FilterColumn = "FirstName";

                    break;

                case "Second Name":

                    FilterColumn = "SecondName";

                    break;

                case "Third Name":

                    FilterColumn = "ThirdName";

                    break;

                case "Last Name":

                    FilterColumn = "LastName";

                    break;

                case "Nationality":

                    FilterColumn = "CountryName";

                    break;

                case "Gendor":

                    FilterColumn = "GendorCaption";

                    break;

                case "Phone":

                    FilterColumn = "Phone";

                    break;

                case "Email":

                    FilterColumn = "Email";

                    break;

                default:

                    FilterColumn = "None";

                    break;

            }


            // هذا الجزء لعرض جميع البيانات اذا لم يكن هناك فلترة او بحث

            if (TXTFilterValue.Text.Trim() == "" || FilterColumn == "None")
            {

                _dtPeople.DefaultView.RowFilter = "";

                LBLRecordsCount.Text = DVGPeopleList.Rows.Count.ToString();

                return;

            }


            // هذا الجزء لتطبيق الفلترة والتفاعل مع كلمات البحث

            if (FilterColumn == "PersonID")

                _dtPeople.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, TXTFilterValue.Text.Trim());

            else

                _dtPeople.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, TXTFilterValue.Text.Trim());



            // هذا الجزء لكتابة عدد العناصر

            LBLRecordsCount.Text = DVGPeopleList.Rows.Count.ToString();

            


        }



        private void CMSShowDetails_Click(object sender, EventArgs e)
        {

            if (DVGPeopleList.CurrentRow != null)
            {

                int PersonID = (int)DVGPeopleList.CurrentRow.Cells[0].Value;

                Form frm = new FRMShowPersonInfo(PersonID);

                frm.ShowDialog();
            }


        }



        private void CMSEditPerson_Click(object sender, EventArgs e)
        {

            Form frm = new FRMAddUpdatePerson((int)DVGPeopleList.CurrentRow.Cells[0].Value);
            
            frm.ShowDialog();

            _RefreshPeopleList();

        }

        private void CMSDeletePerson_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Are you sure you want to delete Person [" + DVGPeopleList.CurrentRow.Cells[0].Value + "]", "Confirm Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {

                if (CLSPeopleBusiness.DeletePerson((int)DVGPeopleList.CurrentRow.Cells[0].Value))
                {

                    MessageBox.Show("Person Deleted Successfully.", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    _RefreshPeopleList();

                }

                else

                    MessageBox.Show("Person was not deleted because it has data linked to it.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }


        }



        private void phoneCallToolStripMenuItem_Click(object sender, EventArgs e)
        {

            MessageBox.Show("This Feature Is Not Implemented Yet!", "Not Ready!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

        }

        private void CMSSendEmail_Click(object sender, EventArgs e)
        {

            MessageBox.Show("This Feature Is Not Implemented Yet!", "Not Ready!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

        }



        private void CMSAddNewPerson_Click(object sender, EventArgs e)
        {

            Form frm = new FRMAddUpdatePerson();

            frm.ShowDialog();

            _RefreshPeopleList();

        }

        private void BTNAddNewPerson_Click(object sender, EventArgs e)
        {

            Form frm1 = new FRMAddUpdatePerson();

            frm1.ShowDialog();

            _RefreshPeopleList();

        }



        private void BTNClose_Click(object sender, EventArgs e)
        {

            this.Close();

        }



        private void DVGPeopleList_DoubleClick(object sender, EventArgs e)
        {

            Form frm = new FRMShowPersonInfo((int)DVGPeopleList.CurrentRow.Cells[0].Value);

            frm.ShowDialog();

        }



        private void TXTFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (CBFiletryBy.Text == "Person ID")

                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);


        }


        private void CBFindPerson_Click(object sender, EventArgs e)
        {

            Form form = new FRMFindPerson();

            form.ShowDialog();

        }



    }

}














