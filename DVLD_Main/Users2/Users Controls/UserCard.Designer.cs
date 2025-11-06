namespace DVLD_Main.Users2.Users_Controls
{
    partial class CTRLUserCard
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ctrlPersonCard1 = new DVLD_Main.People.User_Controls.CTRLPersonCard();
            this.GRBLoginInformation = new System.Windows.Forms.GroupBox();
            this.LBLIsActive = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.LBLUserName = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.LBLUserID = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.GRBLoginInformation.SuspendLayout();
            this.SuspendLayout();
            // 
            // ctrlPersonCard1
            // 
            this.ctrlPersonCard1.Location = new System.Drawing.Point(17, 15);
            this.ctrlPersonCard1.Name = "ctrlPersonCard1";
            this.ctrlPersonCard1.Size = new System.Drawing.Size(1072, 395);
            this.ctrlPersonCard1.TabIndex = 0;
            this.ctrlPersonCard1.Load += new System.EventHandler(this.ctrlPersonCard1_Load);
            // 
            // GRBLoginInformation
            // 
            this.GRBLoginInformation.Controls.Add(this.LBLIsActive);
            this.GRBLoginInformation.Controls.Add(this.label5);
            this.GRBLoginInformation.Controls.Add(this.LBLUserName);
            this.GRBLoginInformation.Controls.Add(this.label3);
            this.GRBLoginInformation.Controls.Add(this.LBLUserID);
            this.GRBLoginInformation.Controls.Add(this.label1);
            this.GRBLoginInformation.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GRBLoginInformation.Location = new System.Drawing.Point(29, 406);
            this.GRBLoginInformation.Name = "GRBLoginInformation";
            this.GRBLoginInformation.Size = new System.Drawing.Size(1040, 100);
            this.GRBLoginInformation.TabIndex = 1;
            this.GRBLoginInformation.TabStop = false;
            this.GRBLoginInformation.Text = "Login Information";
            // 
            // LBLIsActive
            // 
            this.LBLIsActive.AutoSize = true;
            this.LBLIsActive.Location = new System.Drawing.Point(774, 48);
            this.LBLIsActive.Name = "LBLIsActive";
            this.LBLIsActive.Size = new System.Drawing.Size(67, 25);
            this.LBLIsActive.TabIndex = 5;
            this.LBLIsActive.Text = "?????";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(671, 48);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(97, 25);
            this.label5.TabIndex = 4;
            this.label5.Text = "Is Active :";
            // 
            // LBLUserName
            // 
            this.LBLUserName.AutoSize = true;
            this.LBLUserName.Location = new System.Drawing.Point(455, 48);
            this.LBLUserName.Name = "LBLUserName";
            this.LBLUserName.Size = new System.Drawing.Size(67, 25);
            this.LBLUserName.TabIndex = 3;
            this.LBLUserName.Text = "?????";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(333, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 25);
            this.label3.TabIndex = 2;
            this.label3.Text = "UserName :";
            // 
            // LBLUserID
            // 
            this.LBLUserID.AutoSize = true;
            this.LBLUserID.Location = new System.Drawing.Point(126, 48);
            this.LBLUserID.Name = "LBLUserID";
            this.LBLUserID.Size = new System.Drawing.Size(67, 25);
            this.LBLUserID.TabIndex = 1;
            this.LBLUserID.Text = "?????";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(32, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "User ID :";
            // 
            // CTRLUserCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.GRBLoginInformation);
            this.Controls.Add(this.ctrlPersonCard1);
            this.Name = "CTRLUserCard";
            this.Size = new System.Drawing.Size(1107, 544);
            this.Load += new System.EventHandler(this.CTRLUserCard_Load);
            this.GRBLoginInformation.ResumeLayout(false);
            this.GRBLoginInformation.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private People.User_Controls.CTRLPersonCard ctrlPersonCard1;
        private System.Windows.Forms.GroupBox GRBLoginInformation;
        private System.Windows.Forms.Label LBLIsActive;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label LBLUserName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label LBLUserID;
        private System.Windows.Forms.Label label1;
    }
}
