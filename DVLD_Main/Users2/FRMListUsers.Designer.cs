namespace DVLD_Main.Users2
{
    partial class FRMListUsers
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.DVGUsersList = new System.Windows.Forms.DataGridView();
            this.TXTFilterValue = new System.Windows.Forms.TextBox();
            this.CBFiletryBy = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.LBLRecordsCount = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.BTNClose = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.CMSShowDetails = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.CMSAddNewPerson = new System.Windows.Forms.ToolStripMenuItem();
            this.CMSEditPerson = new System.Windows.Forms.ToolStripMenuItem();
            this.CMSDeletePerson = new System.Windows.Forms.ToolStripMenuItem();
            this.changePasswordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.CMSSendEmail = new System.Windows.Forms.ToolStripMenuItem();
            this.CMSPhoneCall = new System.Windows.Forms.ToolStripMenuItem();
            this.BTNAddNewPerson = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.CBIsActive = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.DVGUsersList)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BTNAddNewPerson)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(608, 200);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(220, 36);
            this.label1.TabIndex = 3;
            this.label1.Text = "Manage Users";
            // 
            // DVGUsersList
            // 
            this.DVGUsersList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DVGUsersList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DVGUsersList.Location = new System.Drawing.Point(3, 307);
            this.DVGUsersList.Name = "DVGUsersList";
            this.DVGUsersList.RowHeadersWidth = 51;
            this.DVGUsersList.RowTemplate.Height = 24;
            this.DVGUsersList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DVGUsersList.Size = new System.Drawing.Size(1497, 346);
            this.DVGUsersList.TabIndex = 8;
            this.DVGUsersList.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DVGUsersList_CellContentDoubleClick);
            this.DVGUsersList.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DVGUsersList_CellMouseDown);
            // 
            // TXTFilterValue
            // 
            this.TXTFilterValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TXTFilterValue.Location = new System.Drawing.Point(420, 255);
            this.TXTFilterValue.Name = "TXTFilterValue";
            this.TXTFilterValue.Size = new System.Drawing.Size(233, 32);
            this.TXTFilterValue.TabIndex = 11;
            this.TXTFilterValue.TextChanged += new System.EventHandler(this.TXTFilterValue_TextChanged);
            this.TXTFilterValue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TXTFilterValue_KeyPress);
            // 
            // CBFiletryBy
            // 
            this.CBFiletryBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CBFiletryBy.FormattingEnabled = true;
            this.CBFiletryBy.Items.AddRange(new object[] {
            "None",
            "User ID",
            "Person ID",
            "User Name",
            "Full Name",
            "Is Active"});
            this.CBFiletryBy.Location = new System.Drawing.Point(161, 254);
            this.CBFiletryBy.Name = "CBFiletryBy";
            this.CBFiletryBy.Size = new System.Drawing.Size(233, 33);
            this.CBFiletryBy.TabIndex = 10;
            this.CBFiletryBy.SelectedIndexChanged += new System.EventHandler(this.CBFiletryBy_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(13, 253);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 29);
            this.label2.TabIndex = 9;
            this.label2.Text = "Filter By :";
            // 
            // LBLRecordsCount
            // 
            this.LBLRecordsCount.AutoSize = true;
            this.LBLRecordsCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBLRecordsCount.Location = new System.Drawing.Point(113, 682);
            this.LBLRecordsCount.Name = "LBLRecordsCount";
            this.LBLRecordsCount.Size = new System.Drawing.Size(56, 25);
            this.LBLRecordsCount.TabIndex = 14;
            this.LBLRecordsCount.Text = "????";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 682);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 25);
            this.label3.TabIndex = 13;
            this.label3.Text = "Records :";
            // 
            // BTNClose
            // 
            this.BTNClose.BackColor = System.Drawing.Color.White;
            this.BTNClose.FlatAppearance.BorderSize = 2;
            this.BTNClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTNClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTNClose.Location = new System.Drawing.Point(1334, 671);
            this.BTNClose.Name = "BTNClose";
            this.BTNClose.Size = new System.Drawing.Size(144, 41);
            this.BTNClose.TabIndex = 15;
            this.BTNClose.Text = "Close";
            this.BTNClose.UseVisualStyleBackColor = false;
            this.BTNClose.Click += new System.EventHandler(this.BTNClose_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CMSShowDetails,
            this.toolStripSeparator2,
            this.CMSAddNewPerson,
            this.CMSEditPerson,
            this.CMSDeletePerson,
            this.changePasswordToolStripMenuItem,
            this.toolStripSeparator1,
            this.CMSSendEmail,
            this.CMSPhoneCall});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(210, 282);
            // 
            // CMSShowDetails
            // 
            this.CMSShowDetails.Image = global::DVLD_Main.Properties.Resources.PersonDetails_321;
            this.CMSShowDetails.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.CMSShowDetails.Name = "CMSShowDetails";
            this.CMSShowDetails.Size = new System.Drawing.Size(209, 38);
            this.CMSShowDetails.Text = "Show Details";
            this.CMSShowDetails.Click += new System.EventHandler(this.CMSShowDetails_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(206, 6);
            // 
            // CMSAddNewPerson
            // 
            this.CMSAddNewPerson.Image = global::DVLD_Main.Properties.Resources.AddPerson_321;
            this.CMSAddNewPerson.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.CMSAddNewPerson.Name = "CMSAddNewPerson";
            this.CMSAddNewPerson.Size = new System.Drawing.Size(209, 38);
            this.CMSAddNewPerson.Text = "Add New Person";
            this.CMSAddNewPerson.Click += new System.EventHandler(this.CMSAddNewPerson_Click);
            // 
            // CMSEditPerson
            // 
            this.CMSEditPerson.Image = global::DVLD_Main.Properties.Resources.edit_32;
            this.CMSEditPerson.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.CMSEditPerson.Name = "CMSEditPerson";
            this.CMSEditPerson.Size = new System.Drawing.Size(209, 38);
            this.CMSEditPerson.Text = "Edit";
            this.CMSEditPerson.Click += new System.EventHandler(this.CMSEditPerson_Click);
            // 
            // CMSDeletePerson
            // 
            this.CMSDeletePerson.Image = global::DVLD_Main.Properties.Resources.Delete_32;
            this.CMSDeletePerson.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.CMSDeletePerson.Name = "CMSDeletePerson";
            this.CMSDeletePerson.Size = new System.Drawing.Size(209, 38);
            this.CMSDeletePerson.Text = "Delete";
            this.CMSDeletePerson.Click += new System.EventHandler(this.CMSDeletePerson_Click);
            // 
            // changePasswordToolStripMenuItem
            // 
            this.changePasswordToolStripMenuItem.Image = global::DVLD_Main.Properties.Resources.Password_321;
            this.changePasswordToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.changePasswordToolStripMenuItem.Name = "changePasswordToolStripMenuItem";
            this.changePasswordToolStripMenuItem.Size = new System.Drawing.Size(209, 38);
            this.changePasswordToolStripMenuItem.Text = "Change Password";
            this.changePasswordToolStripMenuItem.Click += new System.EventHandler(this.changePasswordToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(206, 6);
            // 
            // CMSSendEmail
            // 
            this.CMSSendEmail.Image = global::DVLD_Main.Properties.Resources.send_email_32;
            this.CMSSendEmail.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.CMSSendEmail.Name = "CMSSendEmail";
            this.CMSSendEmail.Size = new System.Drawing.Size(209, 38);
            this.CMSSendEmail.Text = "Send Email";
            // 
            // CMSPhoneCall
            // 
            this.CMSPhoneCall.Image = global::DVLD_Main.Properties.Resources.call_32;
            this.CMSPhoneCall.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.CMSPhoneCall.Name = "CMSPhoneCall";
            this.CMSPhoneCall.Size = new System.Drawing.Size(209, 38);
            this.CMSPhoneCall.Text = "Phone Call";
            // 
            // BTNAddNewPerson
            // 
            this.BTNAddNewPerson.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.BTNAddNewPerson.Image = global::DVLD_Main.Properties.Resources.Add_Person_40;
            this.BTNAddNewPerson.Location = new System.Drawing.Point(1406, 238);
            this.BTNAddNewPerson.Name = "BTNAddNewPerson";
            this.BTNAddNewPerson.Size = new System.Drawing.Size(72, 63);
            this.BTNAddNewPerson.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.BTNAddNewPerson.TabIndex = 12;
            this.BTNAddNewPerson.TabStop = false;
            this.BTNAddNewPerson.Click += new System.EventHandler(this.BTNAddNewPerson_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DVLD_Main.Properties.Resources.Users_2_4001;
            this.pictureBox1.Location = new System.Drawing.Point(623, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(194, 176);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // CBIsActive
            // 
            this.CBIsActive.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CBIsActive.FormattingEnabled = true;
            this.CBIsActive.Items.AddRange(new object[] {
            "Yes",
            "No"});
            this.CBIsActive.Location = new System.Drawing.Point(420, 254);
            this.CBIsActive.Name = "CBIsActive";
            this.CBIsActive.Size = new System.Drawing.Size(129, 33);
            this.CBIsActive.TabIndex = 16;
            this.CBIsActive.SelectedIndexChanged += new System.EventHandler(this.CBIsActive_SelectedIndexChanged);
            // 
            // FRMListUsers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1503, 724);
            this.ContextMenuStrip = this.contextMenuStrip1;
            this.Controls.Add(this.CBIsActive);
            this.Controls.Add(this.BTNClose);
            this.Controls.Add(this.LBLRecordsCount);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.BTNAddNewPerson);
            this.Controls.Add(this.TXTFilterValue);
            this.Controls.Add(this.CBFiletryBy);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.DVGUsersList);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "FRMListUsers";
            this.Text = "Manage Users";
            this.Load += new System.EventHandler(this.FRMListUsers_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DVGUsersList)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.BTNAddNewPerson)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridView DVGUsersList;
        private System.Windows.Forms.TextBox TXTFilterValue;
        private System.Windows.Forms.ComboBox CBFiletryBy;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox BTNAddNewPerson;
        private System.Windows.Forms.Label LBLRecordsCount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button BTNClose;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem CMSShowDetails;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem CMSAddNewPerson;
        private System.Windows.Forms.ToolStripMenuItem CMSEditPerson;
        private System.Windows.Forms.ToolStripMenuItem CMSDeletePerson;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem CMSSendEmail;
        private System.Windows.Forms.ToolStripMenuItem CMSPhoneCall;
        private System.Windows.Forms.ToolStripMenuItem changePasswordToolStripMenuItem;
        private System.Windows.Forms.ComboBox CBIsActive;
    }
}