namespace DVLD_Main.People.User_Controls
{
    partial class CTRLPersonCardWithFilter
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
            this.components = new System.ComponentModel.Container();
            this.GBFilter = new System.Windows.Forms.GroupBox();
            this.BTNAddNew = new System.Windows.Forms.Button();
            this.BTNFind = new System.Windows.Forms.Button();
            this.TXTFilterValue = new System.Windows.Forms.TextBox();
            this.CBFilterBy = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorProvider2 = new System.Windows.Forms.ErrorProvider(this.components);
            this.ctrlPersonCard1 = new DVLD_Main.People.User_Controls.CTRLPersonCard();
            this.GBFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider2)).BeginInit();
            this.SuspendLayout();
            // 
            // GBFilter
            // 
            this.GBFilter.Controls.Add(this.BTNAddNew);
            this.GBFilter.Controls.Add(this.BTNFind);
            this.GBFilter.Controls.Add(this.TXTFilterValue);
            this.GBFilter.Controls.Add(this.CBFilterBy);
            this.GBFilter.Controls.Add(this.label1);
            this.GBFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GBFilter.Location = new System.Drawing.Point(27, 17);
            this.GBFilter.Name = "GBFilter";
            this.GBFilter.Size = new System.Drawing.Size(1035, 97);
            this.GBFilter.TabIndex = 1;
            this.GBFilter.TabStop = false;
            this.GBFilter.Text = "Filter";
            // 
            // BTNAddNew
            // 
            this.BTNAddNew.BackgroundImage = global::DVLD_Main.Properties.Resources.AddPerson_322;
            this.BTNAddNew.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.BTNAddNew.Location = new System.Drawing.Point(809, 30);
            this.BTNAddNew.Name = "BTNAddNew";
            this.BTNAddNew.Size = new System.Drawing.Size(54, 46);
            this.BTNAddNew.TabIndex = 22;
            this.BTNAddNew.UseVisualStyleBackColor = true;
            this.BTNAddNew.Click += new System.EventHandler(this.BTNAddNew_Click);
            // 
            // BTNFind
            // 
            this.BTNFind.BackgroundImage = global::DVLD_Main.Properties.Resources.SearchPerson1;
            this.BTNFind.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.BTNFind.Location = new System.Drawing.Point(722, 30);
            this.BTNFind.Name = "BTNFind";
            this.BTNFind.Size = new System.Drawing.Size(54, 46);
            this.BTNFind.TabIndex = 21;
            this.BTNFind.UseVisualStyleBackColor = true;
            this.BTNFind.Click += new System.EventHandler(this.BTNFind_Click_1);
            // 
            // TXTFilterValue
            // 
            this.TXTFilterValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TXTFilterValue.Location = new System.Drawing.Point(421, 42);
            this.TXTFilterValue.Name = "TXTFilterValue";
            this.TXTFilterValue.Size = new System.Drawing.Size(230, 34);
            this.TXTFilterValue.TabIndex = 7;
            this.TXTFilterValue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TXTFilterValue_KeyPress);
            this.TXTFilterValue.Validating += new System.ComponentModel.CancelEventHandler(this.TXTFilterValue_Validating);
            // 
            // CBFilterBy
            // 
            this.CBFilterBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CBFilterBy.FormattingEnabled = true;
            this.CBFilterBy.Items.AddRange(new object[] {
            "Person ID",
            "National No"});
            this.CBFilterBy.Location = new System.Drawing.Point(147, 42);
            this.CBFilterBy.Name = "CBFilterBy";
            this.CBFilterBy.Size = new System.Drawing.Size(233, 33);
            this.CBFilterBy.TabIndex = 6;
            this.CBFilterBy.SelectedIndexChanged += new System.EventHandler(this.CBFilterBy_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(15, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "Find By :";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // errorProvider2
            // 
            this.errorProvider2.ContainerControl = this;
            // 
            // ctrlPersonCard1
            // 
            this.ctrlPersonCard1.Location = new System.Drawing.Point(15, 120);
            this.ctrlPersonCard1.Name = "ctrlPersonCard1";
            this.ctrlPersonCard1.Size = new System.Drawing.Size(1072, 395);
            this.ctrlPersonCard1.TabIndex = 2;
            this.ctrlPersonCard1.Load += new System.EventHandler(this.ctrlUserCard11_Load);
            // 
            // CTRLPersonCardWithFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.ctrlPersonCard1);
            this.Controls.Add(this.GBFilter);
            this.Name = "CTRLPersonCardWithFilter";
            this.Size = new System.Drawing.Size(1090, 518);
            this.Load += new System.EventHandler(this.CTRLPersonCardWithFilter_Load);
            this.GBFilter.ResumeLayout(false);
            this.GBFilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox GBFilter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TXTFilterValue;
        private System.Windows.Forms.ComboBox CBFilterBy;
        private CTRLPersonCard ctrlPersonCard1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.ErrorProvider errorProvider2;
        private System.Windows.Forms.Button BTNAddNew;
        private System.Windows.Forms.Button BTNFind;
    }
}
