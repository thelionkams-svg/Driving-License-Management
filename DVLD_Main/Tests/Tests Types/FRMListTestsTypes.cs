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





namespace DVLD_Main.Tests.Tests_Types
{

    public partial class FRMListTestsTypes : Form
    {

        private DataTable _DTTestsTypes;


        private void _LoadData()
        {

            _DTTestsTypes = CLSTestsTypesBusiness.GetAllTestTypes();


            dgvTestTypes.DataSource = _DTTestsTypes;


            lblRecordsCount.Text = _DTTestsTypes.Rows.Count.ToString();


            if (_DTTestsTypes.Rows.Count > 0)
            {

                dgvTestTypes.Columns[0].HeaderText = " Test Type ID ";

                dgvTestTypes.Columns[0].Width = 100;


                dgvTestTypes.Columns[1].HeaderText = " Title ";

                dgvTestTypes.Columns[1].Width = 150;


                dgvTestTypes.Columns[2].HeaderText = " Description ";

                dgvTestTypes.Columns[2].Width = 300;


                dgvTestTypes.Columns[3].HeaderText = " Fees ";

                dgvTestTypes.Columns[3].Width = 95;
            }

        }


        public FRMListTestsTypes()
        {

            InitializeComponent();

        }

        private void FRMListTestsTypes_Load(object sender, EventArgs e)
        {

            _LoadData();

        }


        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (dgvTestTypes.SelectedCells.Count > 0)
            {

                int TestTypeID = (int)dgvTestTypes.CurrentRow.Cells[0].Value;


                FRMEditTestType FRM = new FRMEditTestType(TestTypeID);

                FRM.ShowDialog();


                _LoadData();

            }

        }


        private void dgvTestTypes_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

            if (e.Button == MouseButtons.Right)
            {

                if (e.RowIndex >= 0)
                {

                    dgvTestTypes.ClearSelection();

                    dgvTestTypes.Rows[e.RowIndex].Selected = true;

                    dgvTestTypes.CurrentCell = dgvTestTypes.Rows[e.RowIndex].Cells[e.ColumnIndex];


                    cmsTestTypes.Show(Cursor.Position);

                }

            }

        }


        private void btnClose_Click(object sender, EventArgs e)
        {

            this.Close();

        }


    }

}





