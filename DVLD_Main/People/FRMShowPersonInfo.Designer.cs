namespace DVLD_Main.People
{
    partial class FRMShowPersonInfo
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
            this.ctrlUserCard11 = new DVLD_Main.People.User_Controls.CTRLPersonCard();
            this.BTNClose = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ctrlUserCard11
            // 
            this.ctrlUserCard11.Location = new System.Drawing.Point(31, 95);
            this.ctrlUserCard11.Name = "ctrlUserCard11";
            this.ctrlUserCard11.Size = new System.Drawing.Size(1072, 395);
            this.ctrlUserCard11.TabIndex = 0;
            this.ctrlUserCard11.Load += new System.EventHandler(this.ctrlUserCard11_Load);
            // 
            // BTNClose
            // 
            this.BTNClose.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BTNClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTNClose.Location = new System.Drawing.Point(884, 496);
            this.BTNClose.Name = "BTNClose";
            this.BTNClose.Size = new System.Drawing.Size(164, 47);
            this.BTNClose.TabIndex = 3;
            this.BTNClose.Text = "Close";
            this.BTNClose.UseVisualStyleBackColor = false;
            this.BTNClose.Click += new System.EventHandler(this.BTNClose_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(426, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(244, 48);
            this.label1.TabIndex = 4;
            this.label1.Text = "Person Info";
            // 
            // FRMShowPersonInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1131, 571);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BTNClose);
            this.Controls.Add(this.ctrlUserCard11);
            this.Name = "FRMShowPersonInfo";
            this.Text = "FRMShowPersonInfo";
            this.Load += new System.EventHandler(this.FRMShowPersonInfo_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private User_Controls.CTRLPersonCard ctrlUserCard11;
        private System.Windows.Forms.Button BTNClose;
        private System.Windows.Forms.Label label1;
    }
}