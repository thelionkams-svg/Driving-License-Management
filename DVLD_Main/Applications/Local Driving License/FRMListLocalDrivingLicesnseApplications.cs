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








namespace DVLD_Main.Applications.Local_Driving_License
{

    public partial class FRMListLocalDrivingLicesnseApplications : Form
    {

        private DataTable _dtAllApplications;

        private void _RefreshData()
        {

            _dtAllApplications = CLSLocalLicenseAppsBusiness.GetAllLocalDrivingLicenseApplications();
          
            dgvLocalDrivingLicenseApplications.DataSource = _dtAllApplications;

            dgvLocalDrivingLicenseApplications.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;


            lblRecordsCount.Text = dgvLocalDrivingLicenseApplications.Rows.Count.ToString();
      
        }



        public FRMListLocalDrivingLicesnseApplications()
        {

            InitializeComponent();

        }

        private void FRMListLocalDrivingLicesnseApplications_Load(object sender, EventArgs e)
        {

            _RefreshData();


            cbFilterBy.SelectedIndex = 0;

            txtFilterValue.Visible = false;

        }



        private void dgvLocalDrivingLicenseApplications_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {



        }

        private void dgvLocalDrivingLicenseApplications_MouseDown(object sender, MouseEventArgs e)
        {

            if (e.Button == MouseButtons.Right)
            {

                var hitTest = dgvLocalDrivingLicenseApplications.HitTest(e.X, e.Y);


                if (hitTest.RowIndex >= 0)
                {

                    dgvLocalDrivingLicenseApplications.ClearSelection();

                    dgvLocalDrivingLicenseApplications.Rows[hitTest.RowIndex].Selected = true;


                    cmsApplications.Show(dgvLocalDrivingLicenseApplications, new Point(e.X, e.Y));

                }

            }

        }



        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {

            txtFilterValue.Visible = (cbFilterBy.Text != "None");

            if (txtFilterValue.Visible)
            {

                txtFilterValue.Text = "";

                txtFilterValue.Focus();

            }


            _dtAllApplications.DefaultView.RowFilter = "";

            lblRecordsCount.Text = dgvLocalDrivingLicenseApplications.Rows.Count.ToString();

        }

        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {

            string FilterColumn = "";


            switch (cbFilterBy.Text)
            {

                case "L.D.L.AppID":

                    FilterColumn = "LocalDrivingLicenseApplicationID";

                    break;

                case "National No.":

                    FilterColumn = "NationalNo";

                    break;

                case "Full Name":

                    FilterColumn = "FullName";

                    break;

                case "Status":

                    FilterColumn = "Status";

                    break;


                default:

                    FilterColumn = "None";

                    break;

            }


            if (txtFilterValue.Text.Trim() == "" || cbFilterBy.Text == "None")
            {

                _dtAllApplications.DefaultView.RowFilter = "";

                lblRecordsCount.Text = dgvLocalDrivingLicenseApplications.Rows.Count.ToString();


                return;

            }


            if (FilterColumn == "LocalDrivingLicenseApplicationID")
            {

                _dtAllApplications.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtFilterValue.Text.Trim());

            }

            else
            {

                _dtAllApplications.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, txtFilterValue.Text.Trim());


            }


            lblRecordsCount.Text = dgvLocalDrivingLicenseApplications.Rows.Count.ToString();

        }

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (cbFilterBy.Text == "L.D.L.AppID")
            {

                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

            }

        }



        private void btnAddNewApplication_Click(object sender, EventArgs e)
        {

            FRMAddUpdateLocalDrivingLicesnseApplication frm = new FRMAddUpdateLocalDrivingLicesnseApplication();

            frm.ShowDialog();


            FRMListLocalDrivingLicesnseApplications_Load(null , null);

        }





        private void CancelApplicaitonToolStripMenuItem_Click(object sender, EventArgs e)
        {





        }






        /*
         
                 private DataTable _dtAllApplications;

        private void _RefreshData()
        {

            _dtAllApplications = CLSLocalLicenseAppsBusiness.GetAllLocalDrivingLicenseApplications();
          
            dgvLocalDrivingLicenseApplications.DataSource = _dtAllApplications;

            dgvLocalDrivingLicenseApplications.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;


            lblRecordsCount.Text = dgvLocalDrivingLicenseApplications.Rows.Count.ToString();
      
        }



        public FRMListLocalDrivingLicesnseApplications()
        {

            InitializeComponent();

        }

        private void FRMListLocalDrivingLicesnseApplications_Load(object sender, EventArgs e)
        {

            _RefreshData();


            cbFilterBy.SelectedIndex = 0;

            txtFilterValue.Visible = false;

        }



        private void btnAddNewApplication_Click(object sender, EventArgs e)
        {

            FRMAddUpdateLocalDrivingLicesnseApplication frm = new FRMAddUpdateLocalDrivingLicesnseApplication();

            if (frm.ShowDialog() == DialogResult.OK)
            {
               
                _RefreshData(); 

            }

        }


        private void dgvLocalDrivingLicenseApplications_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {



        }

        private void dgvLocalDrivingLicenseApplications_MouseDown(object sender, MouseEventArgs e)
        {

            if (e.Button == MouseButtons.Right)
            {

                var hitTest = dgvLocalDrivingLicenseApplications.HitTest(e.X, e.Y);


                if (hitTest.RowIndex >= 0)
                {

                    dgvLocalDrivingLicenseApplications.ClearSelection();

                    dgvLocalDrivingLicenseApplications.Rows[hitTest.RowIndex].Selected = true;


                    cmsApplications.Show(dgvLocalDrivingLicenseApplications, new Point(e.X, e.Y));

                }

            }

        }



        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {

            string SelectedFilter = cbFilterBy.SelectedItem.ToString();

            txtFilterValue.Text = "";


            if (SelectedFilter == "None")
            {

                _RefreshData();

                txtFilterValue.Visible = false;

            }

            else
            {

                txtFilterValue.Visible = true;

                txtFilterValue.Focus();

            }


        }

        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {

            if (_dtAllApplications == null)

                return;


            string FilterType = cbFilterBy.SelectedItem?.ToString();

            string FilterValue = txtFilterValue.Text.Trim();



            if (FilterType == "None" || FilterValue == "")
            {

                dgvLocalDrivingLicenseApplications.DataSource = _dtAllApplications;

                lblRecordsCount.Text = dgvLocalDrivingLicenseApplications.Rows.Count.ToString();

            }


            DataView dv = _dtAllApplications.DefaultView;


            switch (FilterType)
            {

                case "L.D.L.AppID":

                    dv.RowFilter = $"Convert([LocalDrivingLicenseApplicationID], 'System.String') LIKE '%{FilterValue}%'";
                   
                    break;

                case "National No.":

                    dv.RowFilter = $"[NationalNo] LIKE '%{FilterValue}%'";

                    break;

                case "Full Name":

                    dv.RowFilter = $"[FullName] LIKE '%{FilterValue}%'";
                 
                    break;

                case "Status":

                    dv.RowFilter = $"[Status] LIKE '%{FilterValue}%'";

                    break;

            }


            dgvLocalDrivingLicenseApplications.DataSource = dv.ToTable();

            lblRecordsCount.Text = dgvLocalDrivingLicenseApplications.Rows.Count.ToString();


        }


        private void CancelApplicaitonToolStripMenuItem_Click(object sender, EventArgs e)
        {





        }


         
         
         */






    }

}







