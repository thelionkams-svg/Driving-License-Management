namespace DVLD_Main.Users2
{
    partial class FRMChangePassword
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
            this.TXTCNewPassword = new System.Windows.Forms.TextBox();
            this.TXTNewPassword = new System.Windows.Forms.TextBox();
            this.TXTCurrentPassword = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.BTNSave = new System.Windows.Forms.Button();
            this.BTNClose = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.PCPassword = new System.Windows.Forms.PictureBox();
            this.PCUserID = new System.Windows.Forms.PictureBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.ctrlUserCard1 = new DVLD_Main.Users2.Users_Controls.CTRLUserCard();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PCPassword)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PCUserID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // TXTCNewPassword
            // 
            this.TXTCNewPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TXTCNewPassword.Location = new System.Drawing.Point(400, 661);
            this.TXTCNewPassword.Name = "TXTCNewPassword";
            this.TXTCNewPassword.Size = new System.Drawing.Size(247, 30);
            this.TXTCNewPassword.TabIndex = 19;
            this.TXTCNewPassword.Validating += new System.ComponentModel.CancelEventHandler(this.TXTCNewPassword_Validating);
            // 
            // TXTNewPassword
            // 
            this.TXTNewPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TXTNewPassword.Location = new System.Drawing.Point(400, 598);
            this.TXTNewPassword.Name = "TXTNewPassword";
            this.TXTNewPassword.Size = new System.Drawing.Size(247, 30);
            this.TXTNewPassword.TabIndex = 18;
            this.TXTNewPassword.Validating += new System.ComponentModel.CancelEventHandler(this.TXTNewPassword_Validating);
            // 
            // TXTCurrentPassword
            // 
            this.TXTCurrentPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TXTCurrentPassword.Location = new System.Drawing.Point(400, 537);
            this.TXTCurrentPassword.Name = "TXTCurrentPassword";
            this.TXTCurrentPassword.Size = new System.Drawing.Size(247, 30);
            this.TXTCurrentPassword.TabIndex = 17;
            this.TXTCurrentPassword.Validating += new System.ComponentModel.CancelEventHandler(this.TXTCurrentPassword_Validating);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(59, 661);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(276, 31);
            this.label4.TabIndex = 13;
            this.label4.Text = "Comfirm Password :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(59, 595);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(225, 31);
            this.label3.TabIndex = 12;
            this.label3.Text = "New Password :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(59, 534);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(265, 31);
            this.label2.TabIndex = 11;
            this.label2.Text = "Current Password :";
            // 
            // BTNSave
            // 
            this.BTNSave.BackColor = System.Drawing.Color.White;
            this.BTNSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTNSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTNSave.Location = new System.Drawing.Point(670, 732);
            this.BTNSave.Name = "BTNSave";
            this.BTNSave.Size = new System.Drawing.Size(143, 47);
            this.BTNSave.TabIndex = 21;
            this.BTNSave.Text = "Save";
            this.BTNSave.UseVisualStyleBackColor = false;
            this.BTNSave.Click += new System.EventHandler(this.BTNSave_Click);
            // 
            // BTNClose
            // 
            this.BTNClose.BackColor = System.Drawing.Color.White;
            this.BTNClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTNClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTNClose.Location = new System.Drawing.Point(867, 732);
            this.BTNClose.Name = "BTNClose";
            this.BTNClose.Size = new System.Drawing.Size(145, 47);
            this.BTNClose.TabIndex = 22;
            this.BTNClose.Text = "Close";
            this.BTNClose.UseVisualStyleBackColor = false;
            this.BTNClose.Click += new System.EventHandler(this.BTNClose_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DVLD_Main.Properties.Resources.Number_323;
            this.pictureBox1.Location = new System.Drawing.Point(341, 595);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(45, 43);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 20;
            this.pictureBox1.TabStop = false;
            // 
            // PCPassword
            // 
            this.PCPassword.Image = global::DVLD_Main.Properties.Resources.Number_324;
            this.PCPassword.Location = new System.Drawing.Point(341, 661);
            this.PCPassword.Name = "PCPassword";
            this.PCPassword.Size = new System.Drawing.Size(45, 41);
            this.PCPassword.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PCPassword.TabIndex = 16;
            this.PCPassword.TabStop = false;
            // 
            // PCUserID
            // 
            this.PCUserID.Image = global::DVLD_Main.Properties.Resources.Number_323;
            this.PCUserID.Location = new System.Drawing.Point(341, 534);
            this.PCUserID.Name = "PCUserID";
            this.PCUserID.Size = new System.Drawing.Size(45, 43);
            this.PCUserID.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PCUserID.TabIndex = 14;
            this.PCUserID.TabStop = false;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // ctrlUserCard1
            // 
            this.ctrlUserCard1.Location = new System.Drawing.Point(1, 2);
            this.ctrlUserCard1.Name = "ctrlUserCard1";
            this.ctrlUserCard1.Size = new System.Drawing.Size(1088, 520);
            this.ctrlUserCard1.TabIndex = 0;
            // 
            // FRMChangePassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1098, 803);
            this.Controls.Add(this.BTNClose);
            this.Controls.Add(this.BTNSave);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.TXTCNewPassword);
            this.Controls.Add(this.TXTNewPassword);
            this.Controls.Add(this.TXTCurrentPassword);
            this.Controls.Add(this.PCPassword);
            this.Controls.Add(this.PCUserID);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ctrlUserCard1);
            this.Name = "FRMChangePassword";
            this.Text = "Change Password";
            this.Load += new System.EventHandler(this.FRMChangePassword_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PCPassword)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PCUserID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Users_Controls.CTRLUserCard ctrlUserCard1;
        private System.Windows.Forms.TextBox TXTCNewPassword;
        private System.Windows.Forms.TextBox TXTNewPassword;
        private System.Windows.Forms.TextBox TXTCurrentPassword;
        private System.Windows.Forms.PictureBox PCPassword;
        private System.Windows.Forms.PictureBox PCUserID;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button BTNSave;
        private System.Windows.Forms.Button BTNClose;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}