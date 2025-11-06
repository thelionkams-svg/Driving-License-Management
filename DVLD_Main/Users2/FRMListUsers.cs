using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD_Business;






namespace DVLD_Main.Users2
{

    public partial class FRMListUsers : Form
    {

        private DataTable _dtAllUsers;


        public FRMListUsers()
        {

            InitializeComponent();

        }



        private void FRMListUsers_Load(object sender, EventArgs e)
        {

            _dtAllUsers = CLSUsersBusiness.GetAllUsers();

            DVGUsersList.DataSource = _dtAllUsers;


            CBFiletryBy.SelectedIndex = 0;

            LBLRecordsCount.Text = DVGUsersList.Rows.Count.ToString();



            DVGUsersList.Columns[0].HeaderText = "User ID";

            DVGUsersList.Columns[0].Width = 110;


            DVGUsersList.Columns[1].HeaderText = "Person ID";

            DVGUsersList.Columns[1].Width = 120;


            DVGUsersList.Columns[2].HeaderText = "Full Name";

            DVGUsersList.Columns[2].Width = 350;


            DVGUsersList.Columns[3].HeaderText = "UserName";

            DVGUsersList.Columns[3].Width = 120;


            DVGUsersList.Columns[4].HeaderText = "Is Active";

            DVGUsersList.Columns[4].Width = 120;

        }



        private void DVGUsersList_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {



        }

        private void DVGUsersList_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            FRMUserInfo FRM = new FRMUserInfo((int)DVGUsersList.CurrentRow.Cells[0].Value);

            FRM.ShowDialog();

        }




        private void CBFiletryBy_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (CBFiletryBy.Text == "Is Active")
            {

                TXTFilterValue.Visible = false;

                CBIsActive.Visible = true;


                CBIsActive.Focus(); 

                CBIsActive.SelectedIndex = 0;

            }

            else
            {

                TXTFilterValue.Visible = (CBFiletryBy.Text != "None");

                CBIsActive.Visible = false;


                if (CBFiletryBy.Text == "None")
                {

                    TXTFilterValue.Enabled = false;

                }

                else
                {

                    TXTFilterValue.Enabled = true;

                }


                TXTFilterValue.Text = "";

                TXTFilterValue.Focus();

            }

        }

        private void TXTFilterValue_TextChanged(object sender, EventArgs e)
        {

            string FilterColumn = "";

            string FilterValue = TXTFilterValue.Text.Trim();


            switch (CBFiletryBy.Text)
            {

                case "User ID":

                    FilterColumn = "UserID";

                    break;

                case "Person ID":

                    FilterColumn = "PersonID";

                    break;

                case "User Name":

                    FilterColumn = "UserName";

                    break;

                case "Full Name":

                    FilterColumn = "FullName";

                    break;

                case "Is Active":

                    FilterColumn = "IsActive";

                    break;

                default:

                    FilterColumn = "None";

                    break;

            }


            if (FilterValue == "" || FilterColumn == "None")
            {

                _dtAllUsers.DefaultView.RowFilter = "";

                LBLRecordsCount.Text = DVGUsersList.Rows.Count.ToString();

                return;

            }


            if (FilterColumn != "FullName" && FilterColumn != "UserName")
            {

                _dtAllUsers.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, TXTFilterValue.Text.Trim());

            }

            else
            {

                _dtAllUsers.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, TXTFilterValue.Text.Trim());

            }


            LBLRecordsCount.Text = DVGUsersList.Rows.Count.ToString();

        }

        private void TXTFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (CBFiletryBy.Text == "User ID" || CBFiletryBy.Text == "Person ID")
            {

                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

            }

        }



        private void CMSShowDetails_Click(object sender, EventArgs e)
        {

            FRMUserInfo FRM = new FRMUserInfo((int)DVGUsersList.CurrentRow.Cells[0].Value);

            FRM.ShowDialog();

        }



        private void BTNAddNewPerson_Click(object sender, EventArgs e)
        {

            Form frm = new FRMAddEditUser();

            frm.ShowDialog();


            FRMListUsers_Load(null, null);

        }

        private void CMSAddNewPerson_Click(object sender, EventArgs e)
        {

            Form frm = new FRMAddEditUser();

            frm.ShowDialog();


            FRMListUsers_Load(null, null);

        }



        private void CMSEditPerson_Click(object sender, EventArgs e)
        {

            FRMAddEditUser Frm1 = new FRMAddEditUser((int)DVGUsersList.CurrentRow.Cells[0].Value);

            Frm1.ShowDialog();


            FRMListUsers_Load(null, null);

        }

        private void CMSDeletePerson_Click(object sender, EventArgs e)
        {

            int UserID = (int)DVGUsersList.CurrentRow.Cells[0].Value;


            if (CLSUsersBusiness.Delete(UserID))
            {

                MessageBox.Show("User has been deleted successfully", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);

                FRMListUsers_Load(null, null);

            }

            else
            {

                MessageBox.Show("User is not delted due to data connected to it.", "Faild", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }



        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {

            int UserID = (int)DVGUsersList.CurrentRow.Cells[0].Value;

            FRMChangePassword Frm1 = new FRMChangePassword(UserID);

            Frm1.ShowDialog();

        }

        private void CBIsActive_SelectedIndexChanged(object sender, EventArgs e)
        {

            string FilterColumn = "IsActive";

            string FilterValue = CBIsActive.Text;


            switch (FilterValue)
            {

                case "All":

                    break;

                case "Yes":

                    FilterValue = "1";

                    break;

                case "No":

                    FilterValue = "0";

                    break;

            }


            if (FilterValue == "All")
            {

                _dtAllUsers.DefaultView.RowFilter = "";

            }

            else
            {

                _dtAllUsers.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, FilterValue);

            }


            LBLRecordsCount.Text = _dtAllUsers.Rows.Count.ToString();

        }



        private void BTNClose_Click(object sender, EventArgs e)
        {

            this.Close();

        }


    }












//************************************************************************************************************************************************************


    /*
     
             public partial class FRMListUsers : Form
    {

        private int _UserID = -1;

        private CLSUsersBusiness _User;



        private DataTable _dtAllUsers;

        private string _FilterColumn = "None";

        

        private void _LoadUsersList()
        {

            _dtAllUsers = CLSUsersBusiness.GetAllUsers();


            if (_dtAllUsers != null)
            {

                DVGUsersList.DataSource = _dtAllUsers;

                LBLRecordsCount.Text = DVGUsersList.Rows.Count.ToString();

            }

            else
            {

                MessageBox.Show("There Is A Mistake", "Wrong", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }


        }

        private void _OpenAddEditUserForm(int UserID = -1)
        {

            Form frm = new FRMAddEditUser(UserID);

            frm.ShowDialog();


            _LoadUsersList();

        } 

        private int _GetSelectedUserID()
        {

            if (DVGUsersList.CurrentRow != null && DVGUsersList.CurrentRow.Cells["UserID"].Value != null)
            {

                return Convert.ToInt32(DVGUsersList.CurrentRow.Cells["UserID"].Value);

            }

            return -1;

        }

        private void _SetupFilterComboBox()
        {

            CBFiletryBy.SelectedIndex = 0;

        }



        public FRMListUsers()
        {

            InitializeComponent();

        }

        public FRMListUsers(int UserID = -1)
        {

            InitializeComponent();

            _UserID = UserID;

        }



        private void FRMListUsers_Load(object sender, EventArgs e)
        {

            _LoadUsersList();


            _SetupFilterComboBox();


            TXTFilterValue.Visible = false;


            DVGUsersList.AllowUserToAddRows = false;

        } 



        private void DVGUsersList_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {

            if (e.Button == MouseButtons.Right)
            {

                if (e.RowIndex >= 0)
                {

                    DVGUsersList.ClearSelection();


                    DVGUsersList.Rows[e.RowIndex].Selected = true;

                    DVGUsersList.CurrentCell = DVGUsersList.Rows[e.RowIndex].Cells[e.ColumnIndex];

                }

            }

        }



        private void BTNAddNewPerson_Click(object sender, EventArgs e)
        {

            Form frm = new FRMAddEditUser();

            frm.ShowDialog();


            _LoadUsersList();

        } 

        private void CMSAddNewPerson_Click(object sender, EventArgs e)
        {

            Form frm = new FRMAddEditUser();

            frm.ShowDialog();


            _LoadUsersList();

        } 


        private void CMSEditPerson_Click(object sender, EventArgs e)
        {

            _UserID = _GetSelectedUserID();


            if (_UserID != -1)
            {

                _OpenAddEditUserForm(_UserID);

            }

            else
            {

                MessageBox.Show("Please select a user to edit.", "Wrong", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }

        }


        private void CMSShowDetails_Click(object sender, EventArgs e)
        {

            _UserID = _GetSelectedUserID();


            if (_UserID != -1)
            {

                FRMUserInfo frm = new FRMUserInfo(_UserID);

                frm.ShowDialog();

            }

            else
            {

                MessageBox.Show("Please select a user to view details", "Wrong");

            }

        }

        private void CMSDeletePerson_Click(object sender, EventArgs e)
        {

            _UserID = _GetSelectedUserID();


            if (CLSUsersBusiness.Delete(_UserID))
            {

                MessageBox.Show("User has been deleted successfully", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);

                FRMListUsers_Load(null, null);

            }

            else {

                MessageBox.Show("User is not delted due to data connected to it.", "Faild", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }


        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {

            int UserID = _GetSelectedUserID();


            FRMChangePassword FRM = new FRMChangePassword(UserID);

            FRM.ShowDialog();

        }


        private void CBFiletryBy_SelectedIndexChanged(object sender, EventArgs e)
        {

            TXTFilterValue.Visible = (CBFiletryBy.Text != "None" && CBFiletryBy.Text != "Is Active");

            TXTFilterValue.Text = "";


            if (_dtAllUsers != null)

                _dtAllUsers.DefaultView.RowFilter = "";


            if (CBFiletryBy.Text == "User ID" || CBFiletryBy.Text == "Person ID")
            {

                if (TXTFilterValue.Visible)

                    TXTFilterValue.Focus();

            }


            LBLRecordsCount.Text = DVGUsersList.Rows.Count.ToString();

        }

        private void TXTFilterValue_TextChanged(object sender, EventArgs e)
        {

            string FilterColumn = "";

            string FilterValue = TXTFilterValue.Text.Trim();


            switch (CBFiletryBy.Text)
            {

                case "User ID":
                    FilterColumn = "UserID";
                    break;

                case "Person ID":
                    FilterColumn = "PersonID";
                    break;

                case "User Name":
                    FilterColumn = "UserName";
                    break;

                case "Full Name":
                    FilterColumn = "FullName";
                    break;

                case "Is Active":
                    FilterColumn = "IsActive";
                    break;

                default:
                    FilterColumn = "None";
                    break;

            }


            if (FilterValue == "" || FilterColumn == "None")
            {
                _dtAllUsers.DefaultView.RowFilter = "";
                LBLRecordsCount.Text = DVGUsersList.Rows.Count.ToString();
                return;
            }


            if (FilterColumn == "UserID" || FilterColumn == "PersonID")
            {
                int ID;
                if (int.TryParse(FilterValue, out ID))
                {
                    _dtAllUsers.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, ID);
                }
                else
                {
                    _dtAllUsers.DefaultView.RowFilter = "0=1";
                }
            }

            else if (FilterColumn == "IsActive")
            {
                if (FilterValue.ToLower() == "yes" || FilterValue == "1")
                    _dtAllUsers.DefaultView.RowFilter = "[IsActive] = 1";
                else if (FilterValue.ToLower() == "no" || FilterValue == "0")
                    _dtAllUsers.DefaultView.RowFilter = "[IsActive] = 0";
                else
                    _dtAllUsers.DefaultView.RowFilter = "";
            }

            else
            {
                _dtAllUsers.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, FilterValue);
            }


            LBLRecordsCount.Text = DVGUsersList.Rows.Count.ToString();

        }

        private void TXTFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (CBFiletryBy.Text == "User ID" || CBFiletryBy.Text == "Person ID")
            {
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            }

        }


    }

     
     
     
     
     */



}









