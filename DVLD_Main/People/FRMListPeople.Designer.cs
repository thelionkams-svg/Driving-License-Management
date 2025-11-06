namespace DVLD_Main
{
    partial class FRMListPeople
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
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.label2 = new System.Windows.Forms.Label();
            this.CBFiletryBy = new System.Windows.Forms.ComboBox();
            this.TXTFilterValue = new System.Windows.Forms.TextBox();
            this.DVGPeopleList = new System.Windows.Forms.DataGridView();
            this.BTNClose = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.LBLRecordsCount = new System.Windows.Forms.Label();
            this.CMSShowDetails = new System.Windows.Forms.ToolStripMenuItem();
            this.CMSAddNewPerson = new System.Windows.Forms.ToolStripMenuItem();
            this.CMSEditPerson = new System.Windows.Forms.ToolStripMenuItem();
            this.CMSDeletePerson = new System.Windows.Forms.ToolStripMenuItem();
            this.CMSSendEmail = new System.Windows.Forms.ToolStripMenuItem();
            this.CMSPhoneCall = new System.Windows.Forms.ToolStripMenuItem();
            this.CBFindPerson = new System.Windows.Forms.ToolStripMenuItem();
            this.BTNAddNewPerson = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DVGPeopleList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BTNAddNewPerson)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(596, 204);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(236, 36);
            this.label1.TabIndex = 1;
            this.label1.Text = "Manage People";
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
            this.toolStripSeparator1,
            this.CMSSendEmail,
            this.CMSPhoneCall,
            this.toolStripSeparator3,
            this.CBFindPerson});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(227, 316);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(223, 6);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(223, 6);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(21, 259);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 29);
            this.label2.TabIndex = 4;
            this.label2.Text = "Filter By :";
            // 
            // CBFiletryBy
            // 
            this.CBFiletryBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CBFiletryBy.FormattingEnabled = true;
            this.CBFiletryBy.Items.AddRange(new object[] {
            "None",
            "Person ID",
            "National No.",
            "First Name",
            "Second Name",
            "Third Name",
            "Last Name",
            "Nationality",
            "Gendor",
            "Phone",
            "Email"});
            this.CBFiletryBy.Location = new System.Drawing.Point(169, 260);
            this.CBFiletryBy.Name = "CBFiletryBy";
            this.CBFiletryBy.Size = new System.Drawing.Size(233, 33);
            this.CBFiletryBy.TabIndex = 5;
            // 
            // TXTFilterValue
            // 
            this.TXTFilterValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TXTFilterValue.Location = new System.Drawing.Point(428, 261);
            this.TXTFilterValue.Name = "TXTFilterValue";
            this.TXTFilterValue.Size = new System.Drawing.Size(233, 32);
            this.TXTFilterValue.TabIndex = 6;
            this.TXTFilterValue.TextChanged += new System.EventHandler(this.TXTFilterValue_TextChanged);
            this.TXTFilterValue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TXTFilterValue_KeyPress);
            // 
            // DVGPeopleList
            // 
            this.DVGPeopleList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DVGPeopleList.ContextMenuStrip = this.contextMenuStrip1;
            this.DVGPeopleList.Location = new System.Drawing.Point(1, 314);
            this.DVGPeopleList.Name = "DVGPeopleList";
            this.DVGPeopleList.RowHeadersWidth = 51;
            this.DVGPeopleList.RowTemplate.Height = 24;
            this.DVGPeopleList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DVGPeopleList.Size = new System.Drawing.Size(1497, 346);
            this.DVGPeopleList.TabIndex = 7;
            this.DVGPeopleList.DoubleClick += new System.EventHandler(this.DVGPeopleList_DoubleClick);
            // 
            // BTNClose
            // 
            this.BTNClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTNClose.Location = new System.Drawing.Point(1303, 674);
            this.BTNClose.Name = "BTNClose";
            this.BTNClose.Size = new System.Drawing.Size(144, 41);
            this.BTNClose.TabIndex = 8;
            this.BTNClose.Text = "Close";
            this.BTNClose.UseVisualStyleBackColor = true;
            this.BTNClose.Click += new System.EventHandler(this.BTNClose_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(21, 682);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 25);
            this.label3.TabIndex = 9;
            this.label3.Text = "Records :";
            // 
            // LBLRecordsCount
            // 
            this.LBLRecordsCount.AutoSize = true;
            this.LBLRecordsCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBLRecordsCount.Location = new System.Drawing.Point(122, 682);
            this.LBLRecordsCount.Name = "LBLRecordsCount";
            this.LBLRecordsCount.Size = new System.Drawing.Size(56, 25);
            this.LBLRecordsCount.TabIndex = 10;
            this.LBLRecordsCount.Text = "????";
            // 
            // CMSShowDetails
            // 
            this.CMSShowDetails.Image = global::DVLD_Main.Properties.Resources.PersonDetails_321;
            this.CMSShowDetails.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.CMSShowDetails.Name = "CMSShowDetails";
            this.CMSShowDetails.Size = new System.Drawing.Size(226, 38);
            this.CMSShowDetails.Text = "Show Details";
            this.CMSShowDetails.Click += new System.EventHandler(this.CMSShowDetails_Click);
            // 
            // CMSAddNewPerson
            // 
            this.CMSAddNewPerson.Image = global::DVLD_Main.Properties.Resources.AddPerson_321;
            this.CMSAddNewPerson.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.CMSAddNewPerson.Name = "CMSAddNewPerson";
            this.CMSAddNewPerson.Size = new System.Drawing.Size(226, 38);
            this.CMSAddNewPerson.Text = "Add New Person";
            this.CMSAddNewPerson.Click += new System.EventHandler(this.CMSAddNewPerson_Click);
            // 
            // CMSEditPerson
            // 
            this.CMSEditPerson.Image = global::DVLD_Main.Properties.Resources.edit_32;
            this.CMSEditPerson.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.CMSEditPerson.Name = "CMSEditPerson";
            this.CMSEditPerson.Size = new System.Drawing.Size(226, 38);
            this.CMSEditPerson.Text = "Edit";
            this.CMSEditPerson.Click += new System.EventHandler(this.CMSEditPerson_Click);
            // 
            // CMSDeletePerson
            // 
            this.CMSDeletePerson.Image = global::DVLD_Main.Properties.Resources.Delete_32;
            this.CMSDeletePerson.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.CMSDeletePerson.Name = "CMSDeletePerson";
            this.CMSDeletePerson.Size = new System.Drawing.Size(226, 38);
            this.CMSDeletePerson.Text = "Delete";
            this.CMSDeletePerson.Click += new System.EventHandler(this.CMSDeletePerson_Click);
            // 
            // CMSSendEmail
            // 
            this.CMSSendEmail.Image = global::DVLD_Main.Properties.Resources.send_email_32;
            this.CMSSendEmail.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.CMSSendEmail.Name = "CMSSendEmail";
            this.CMSSendEmail.Size = new System.Drawing.Size(226, 38);
            this.CMSSendEmail.Text = "Send Email";
            this.CMSSendEmail.Click += new System.EventHandler(this.CMSSendEmail_Click);
            // 
            // CMSPhoneCall
            // 
            this.CMSPhoneCall.Image = global::DVLD_Main.Properties.Resources.call_32;
            this.CMSPhoneCall.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.CMSPhoneCall.Name = "CMSPhoneCall";
            this.CMSPhoneCall.Size = new System.Drawing.Size(226, 38);
            this.CMSPhoneCall.Text = "Phone Call";
            this.CMSPhoneCall.Click += new System.EventHandler(this.phoneCallToolStripMenuItem_Click);
            // 
            // CBFindPerson
            // 
            this.CBFindPerson.Image = global::DVLD_Main.Properties.Resources.SearchPerson3;
            this.CBFindPerson.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.CBFindPerson.Name = "CBFindPerson";
            this.CBFindPerson.Size = new System.Drawing.Size(226, 38);
            this.CBFindPerson.Text = "Find Person";
            this.CBFindPerson.Click += new System.EventHandler(this.CBFindPerson_Click);
            // 
            // BTNAddNewPerson
            // 
            this.BTNAddNewPerson.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.BTNAddNewPerson.Image = global::DVLD_Main.Properties.Resources.Add_Person_40;
            this.BTNAddNewPerson.Location = new System.Drawing.Point(1417, 230);
            this.BTNAddNewPerson.Name = "BTNAddNewPerson";
            this.BTNAddNewPerson.Size = new System.Drawing.Size(72, 63);
            this.BTNAddNewPerson.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.BTNAddNewPerson.TabIndex = 3;
            this.BTNAddNewPerson.TabStop = false;
            this.BTNAddNewPerson.Click += new System.EventHandler(this.BTNAddNewPerson_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DVLD_Main.Properties.Resources.People_4001;
            this.pictureBox1.Location = new System.Drawing.Point(615, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(194, 176);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(223, 6);
            // 
            // FRMListPeople
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1501, 727);
            this.Controls.Add(this.LBLRecordsCount);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.BTNClose);
            this.Controls.Add(this.DVGPeopleList);
            this.Controls.Add(this.TXTFilterValue);
            this.Controls.Add(this.CBFiletryBy);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.BTNAddNewPerson);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "FRMListPeople";
            this.Text = "Manage People";
            this.Load += new System.EventHandler(this.FRMListPeople_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DVGPeopleList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BTNAddNewPerson)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox BTNAddNewPerson;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox CBFiletryBy;
        private System.Windows.Forms.TextBox TXTFilterValue;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem CMSShowDetails;
        private System.Windows.Forms.ToolStripMenuItem CMSAddNewPerson;
        private System.Windows.Forms.ToolStripMenuItem CMSEditPerson;
        private System.Windows.Forms.ToolStripMenuItem CMSDeletePerson;
        private System.Windows.Forms.ToolStripMenuItem CMSSendEmail;
        private System.Windows.Forms.ToolStripMenuItem CMSPhoneCall;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.DataGridView DVGPeopleList;
        private System.Windows.Forms.Button BTNClose;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label LBLRecordsCount;
        private System.Windows.Forms.ToolStripMenuItem CBFindPerson;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
    }
}