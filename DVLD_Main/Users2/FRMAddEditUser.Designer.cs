namespace DVLD_Main.Users2
{
    partial class FRMAddEditUser
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
            this.TCUserInfo = new System.Windows.Forms.TabControl();
            this.TPPesonalInfo = new System.Windows.Forms.TabPage();
            this.BTNNext = new System.Windows.Forms.Button();
            this.ctrlPersonCardWithFilter1 = new DVLD_Main.People.User_Controls.CTRLPersonCardWithFilter();
            this.TPLoginInfo = new System.Windows.Forms.TabPage();
            this.LBLUserID = new System.Windows.Forms.Label();
            this.CHKIsActive = new System.Windows.Forms.CheckBox();
            this.TXTCPassword = new System.Windows.Forms.TextBox();
            this.TXTPassword = new System.Windows.Forms.TextBox();
            this.TXTUserName = new System.Windows.Forms.TextBox();
            this.PCCPassword = new System.Windows.Forms.PictureBox();
            this.PCPassword = new System.Windows.Forms.PictureBox();
            this.PCUserName = new System.Windows.Forms.PictureBox();
            this.PCUserID = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.LBLTitle = new System.Windows.Forms.Label();
            this.BTNSave = new System.Windows.Forms.Button();
            this.BTNClose = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.TCUserInfo.SuspendLayout();
            this.TPPesonalInfo.SuspendLayout();
            this.TPLoginInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PCCPassword)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PCPassword)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PCUserName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PCUserID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // TCUserInfo
            // 
            this.TCUserInfo.Controls.Add(this.TPPesonalInfo);
            this.TCUserInfo.Controls.Add(this.TPLoginInfo);
            this.TCUserInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TCUserInfo.Location = new System.Drawing.Point(12, 81);
            this.TCUserInfo.Name = "TCUserInfo";
            this.TCUserInfo.SelectedIndex = 0;
            this.TCUserInfo.Size = new System.Drawing.Size(1114, 618);
            this.TCUserInfo.TabIndex = 1;
            // 
            // TPPesonalInfo
            // 
            this.TPPesonalInfo.Controls.Add(this.BTNNext);
            this.TPPesonalInfo.Controls.Add(this.ctrlPersonCardWithFilter1);
            this.TPPesonalInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TPPesonalInfo.Location = new System.Drawing.Point(4, 34);
            this.TPPesonalInfo.Name = "TPPesonalInfo";
            this.TPPesonalInfo.Padding = new System.Windows.Forms.Padding(3);
            this.TPPesonalInfo.Size = new System.Drawing.Size(1106, 580);
            this.TPPesonalInfo.TabIndex = 0;
            this.TPPesonalInfo.Text = "Pesonal Info";
            this.TPPesonalInfo.UseVisualStyleBackColor = true;
            // 
            // BTNNext
            // 
            this.BTNNext.BackColor = System.Drawing.Color.White;
            this.BTNNext.FlatAppearance.BorderSize = 2;
            this.BTNNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTNNext.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTNNext.Location = new System.Drawing.Point(863, 517);
            this.BTNNext.Name = "BTNNext";
            this.BTNNext.Size = new System.Drawing.Size(152, 44);
            this.BTNNext.TabIndex = 1;
            this.BTNNext.Text = "Next";
            this.BTNNext.UseVisualStyleBackColor = false;
            this.BTNNext.Click += new System.EventHandler(this.BTNNext_Click);
            // 
            // ctrlPersonCardWithFilter1
            // 
            this.ctrlPersonCardWithFilter1.AutoSize = true;
            this.ctrlPersonCardWithFilter1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ctrlPersonCardWithFilter1.FilterEnabled = true;
            this.ctrlPersonCardWithFilter1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrlPersonCardWithFilter1.Location = new System.Drawing.Point(15, 15);
            this.ctrlPersonCardWithFilter1.Name = "ctrlPersonCardWithFilter1";
            this.ctrlPersonCardWithFilter1.ShowAddPerson = true;
            this.ctrlPersonCardWithFilter1.Size = new System.Drawing.Size(954, 485);
            this.ctrlPersonCardWithFilter1.TabIndex = 0;
            // 
            // TPLoginInfo
            // 
            this.TPLoginInfo.Controls.Add(this.LBLUserID);
            this.TPLoginInfo.Controls.Add(this.CHKIsActive);
            this.TPLoginInfo.Controls.Add(this.TXTCPassword);
            this.TPLoginInfo.Controls.Add(this.TXTPassword);
            this.TPLoginInfo.Controls.Add(this.TXTUserName);
            this.TPLoginInfo.Controls.Add(this.PCCPassword);
            this.TPLoginInfo.Controls.Add(this.PCPassword);
            this.TPLoginInfo.Controls.Add(this.PCUserName);
            this.TPLoginInfo.Controls.Add(this.PCUserID);
            this.TPLoginInfo.Controls.Add(this.label5);
            this.TPLoginInfo.Controls.Add(this.label4);
            this.TPLoginInfo.Controls.Add(this.label3);
            this.TPLoginInfo.Controls.Add(this.label2);
            this.TPLoginInfo.Location = new System.Drawing.Point(4, 34);
            this.TPLoginInfo.Name = "TPLoginInfo";
            this.TPLoginInfo.Padding = new System.Windows.Forms.Padding(3);
            this.TPLoginInfo.Size = new System.Drawing.Size(1106, 580);
            this.TPLoginInfo.TabIndex = 1;
            this.TPLoginInfo.Text = "User Info";
            this.TPLoginInfo.UseVisualStyleBackColor = true;
            // 
            // LBLUserID
            // 
            this.LBLUserID.AutoSize = true;
            this.LBLUserID.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBLUserID.Location = new System.Drawing.Point(353, 75);
            this.LBLUserID.Name = "LBLUserID";
            this.LBLUserID.Size = new System.Drawing.Size(94, 31);
            this.LBLUserID.TabIndex = 13;
            this.LBLUserID.Text = "?????";
            // 
            // CHKIsActive
            // 
            this.CHKIsActive.AutoSize = true;
            this.CHKIsActive.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CHKIsActive.Location = new System.Drawing.Point(388, 374);
            this.CHKIsActive.Name = "CHKIsActive";
            this.CHKIsActive.Size = new System.Drawing.Size(140, 35);
            this.CHKIsActive.TabIndex = 12;
            this.CHKIsActive.Text = "Is Active";
            this.CHKIsActive.UseVisualStyleBackColor = true;
            // 
            // TXTCPassword
            // 
            this.TXTCPassword.Location = new System.Drawing.Point(350, 295);
            this.TXTCPassword.Name = "TXTCPassword";
            this.TXTCPassword.Size = new System.Drawing.Size(247, 30);
            this.TXTCPassword.TabIndex = 11;
            this.TXTCPassword.Validating += new System.ComponentModel.CancelEventHandler(this.TXTCPassword_Validating);
            // 
            // TXTPassword
            // 
            this.TXTPassword.Location = new System.Drawing.Point(350, 220);
            this.TXTPassword.Name = "TXTPassword";
            this.TXTPassword.Size = new System.Drawing.Size(247, 30);
            this.TXTPassword.TabIndex = 10;
            this.TXTPassword.Validating += new System.ComponentModel.CancelEventHandler(this.TXTPassword_Validating);
            // 
            // TXTUserName
            // 
            this.TXTUserName.Location = new System.Drawing.Point(350, 142);
            this.TXTUserName.Name = "TXTUserName";
            this.TXTUserName.Size = new System.Drawing.Size(247, 30);
            this.TXTUserName.TabIndex = 9;
            this.TXTUserName.Validating += new System.ComponentModel.CancelEventHandler(this.TXTUserName_Validating);
            // 
            // PCCPassword
            // 
            this.PCCPassword.Image = global::DVLD_Main.Properties.Resources.Number_325;
            this.PCCPassword.Location = new System.Drawing.Point(272, 292);
            this.PCCPassword.Name = "PCCPassword";
            this.PCCPassword.Size = new System.Drawing.Size(45, 41);
            this.PCCPassword.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PCCPassword.TabIndex = 7;
            this.PCCPassword.TabStop = false;
            // 
            // PCPassword
            // 
            this.PCPassword.Image = global::DVLD_Main.Properties.Resources.Number_324;
            this.PCPassword.Location = new System.Drawing.Point(272, 217);
            this.PCPassword.Name = "PCPassword";
            this.PCPassword.Size = new System.Drawing.Size(45, 41);
            this.PCPassword.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PCPassword.TabIndex = 6;
            this.PCPassword.TabStop = false;
            // 
            // PCUserName
            // 
            this.PCUserName.Image = global::DVLD_Main.Properties.Resources.Person_321;
            this.PCUserName.Location = new System.Drawing.Point(272, 139);
            this.PCUserName.Name = "PCUserName";
            this.PCUserName.Size = new System.Drawing.Size(45, 41);
            this.PCUserName.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PCUserName.TabIndex = 5;
            this.PCUserName.TabStop = false;
            // 
            // PCUserID
            // 
            this.PCUserID.Image = global::DVLD_Main.Properties.Resources.Number_323;
            this.PCUserID.Location = new System.Drawing.Point(272, 63);
            this.PCUserID.Name = "PCUserID";
            this.PCUserID.Size = new System.Drawing.Size(45, 43);
            this.PCUserID.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PCUserID.TabIndex = 4;
            this.PCUserID.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(60, 292);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(180, 31);
            this.label5.TabIndex = 3;
            this.label5.Text = "CPassword :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(60, 217);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(159, 31);
            this.label4.TabIndex = 2;
            this.label4.Text = "Password :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(60, 139);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(169, 31);
            this.label3.TabIndex = 1;
            this.label3.Text = "UserName :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(60, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(131, 31);
            this.label2.TabIndex = 0;
            this.label2.Text = "User ID :";
            // 
            // LBLTitle
            // 
            this.LBLTitle.AutoSize = true;
            this.LBLTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBLTitle.ForeColor = System.Drawing.Color.Red;
            this.LBLTitle.Location = new System.Drawing.Point(312, 30);
            this.LBLTitle.Name = "LBLTitle";
            this.LBLTitle.Size = new System.Drawing.Size(435, 48);
            this.LBLTitle.TabIndex = 2;
            this.LBLTitle.Text = "Edit Application Type";
            // 
            // BTNSave
            // 
            this.BTNSave.BackColor = System.Drawing.Color.White;
            this.BTNSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTNSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTNSave.ForeColor = System.Drawing.Color.Black;
            this.BTNSave.Location = new System.Drawing.Point(755, 723);
            this.BTNSave.Name = "BTNSave";
            this.BTNSave.Size = new System.Drawing.Size(154, 47);
            this.BTNSave.TabIndex = 3;
            this.BTNSave.Text = "Save";
            this.BTNSave.UseVisualStyleBackColor = false;
            this.BTNSave.Click += new System.EventHandler(this.BTNSave_Click);
            // 
            // BTNClose
            // 
            this.BTNClose.BackColor = System.Drawing.Color.White;
            this.BTNClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTNClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTNClose.Location = new System.Drawing.Point(944, 723);
            this.BTNClose.Name = "BTNClose";
            this.BTNClose.Size = new System.Drawing.Size(150, 47);
            this.BTNClose.TabIndex = 2;
            this.BTNClose.Text = "Close";
            this.BTNClose.UseVisualStyleBackColor = false;
            this.BTNClose.Click += new System.EventHandler(this.BTNClose_Click_1);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // FRMAddEditUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1150, 782);
            this.Controls.Add(this.BTNClose);
            this.Controls.Add(this.BTNSave);
            this.Controls.Add(this.LBLTitle);
            this.Controls.Add(this.TCUserInfo);
            this.Name = "FRMAddEditUser";
            this.Text = "Add/Edit User";
            this.Activated += new System.EventHandler(this.FRMAddEditUser_Activated);
            this.Load += new System.EventHandler(this.FRMAddEditUser_Load);
            this.TCUserInfo.ResumeLayout(false);
            this.TPPesonalInfo.ResumeLayout(false);
            this.TPPesonalInfo.PerformLayout();
            this.TPLoginInfo.ResumeLayout(false);
            this.TPLoginInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PCCPassword)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PCPassword)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PCUserName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PCUserID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private People.User_Controls.CTRLPersonCardWithFilter ctrlPersonCardWithFilter1;
        private System.Windows.Forms.TabControl TCUserInfo;
        private System.Windows.Forms.TabPage TPPesonalInfo;
        private System.Windows.Forms.TabPage TPLoginInfo;
        private System.Windows.Forms.Label LBLTitle;
        private System.Windows.Forms.Button BTNNext;
        private System.Windows.Forms.Button BTNSave;
        private System.Windows.Forms.Button BTNClose;
        private System.Windows.Forms.TextBox TXTCPassword;
        private System.Windows.Forms.TextBox TXTPassword;
        private System.Windows.Forms.TextBox TXTUserName;
        private System.Windows.Forms.PictureBox PCCPassword;
        private System.Windows.Forms.PictureBox PCPassword;
        private System.Windows.Forms.PictureBox PCUserName;
        private System.Windows.Forms.PictureBox PCUserID;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox CHKIsActive;
        private System.Windows.Forms.Label LBLUserID;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}