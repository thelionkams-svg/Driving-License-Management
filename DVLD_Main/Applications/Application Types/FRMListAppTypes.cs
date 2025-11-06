using System;
using DVLD_Business;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;







namespace DVLD_Main.Applications.Application_Types
{

    public partial class FRMListAppTypes : Form
    {

        private DataTable _dtApplicationTypes;


        private void _LoadData()
        {

            _dtApplicationTypes = CLSAppTypesBusiness.GetAllApplicationTypes();


            dgvApplicationTypes.DataSource = _dtApplicationTypes;

            lblRecordsCount.Text = _dtApplicationTypes.Rows.Count.ToString();


            if (dgvApplicationTypes.Rows.Count > 0)
            {

                dgvApplicationTypes.Columns[0].HeaderText = "App Type ID";

                dgvApplicationTypes.Columns[0].Width = 120;


                dgvApplicationTypes.Columns[1].HeaderText = "Title";

                dgvApplicationTypes.Columns[1].Width = 350;


                dgvApplicationTypes.Columns[2].HeaderText = "Fees";

                dgvApplicationTypes.Columns[2].Width = 142;

            }

        }


        public FRMListAppTypes()
        {

            InitializeComponent();

        }

        private void FRMListAppTypes_Load(object sender, EventArgs e)
        {

            _LoadData();

        }


        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (dgvApplicationTypes.SelectedCells.Count > 0)
            {

                int ApplicationTypeID = (int)dgvApplicationTypes.CurrentRow.Cells[0].Value;


                FRMEditAppTypes frm = new FRMEditAppTypes(ApplicationTypeID);

                frm.ShowDialog();


                _LoadData();

            }

        }


        private void dgvApplicationTypes_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {

            if (e.Button == MouseButtons.Right)
            {

                if (e.RowIndex >= 0)
                {

                    dgvApplicationTypes.ClearSelection();

                    dgvApplicationTypes.Rows[e.RowIndex].Selected = true;


                    dgvApplicationTypes.CurrentCell = dgvApplicationTypes.Rows[e.RowIndex].Cells[e.ColumnIndex];



                    CMSEditAppTypes.Show(Cursor.Position);
                }


            }

        }


        private void btnClose_Click(object sender, EventArgs e)
        {

            this.Close();

        }


    }

}







