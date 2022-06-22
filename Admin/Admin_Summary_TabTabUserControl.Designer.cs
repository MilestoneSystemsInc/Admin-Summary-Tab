namespace Admin_Summary_Tab.Admin
{
    partial class Admin_Summary_TabTabUserControl
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
            this.label1 = new System.Windows.Forms.Label();
            this.labelItemName = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dGridViewLogAudit = new System.Windows.Forms.DataGridView();
            this.dGridViewLogSystem = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbSearchPeriod = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGridViewLogAudit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dGridViewLogSystem)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Associated object:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // labelItemName
            // 
            this.labelItemName.AutoSize = true;
            this.labelItemName.Location = new System.Drawing.Point(121, 30);
            this.labelItemName.Name = "labelItemName";
            this.labelItemName.Size = new System.Drawing.Size(0, 13);
            this.labelItemName.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbSearchPeriod);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.checkBox1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.dGridViewLogAudit);
            this.groupBox1.Controls.Add(this.dGridViewLogSystem);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.labelItemName);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1270, 850);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Logging Tab";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(830, 87);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(127, 33);
            this.button1.TabIndex = 9;
            this.button1.Text = "Export Results to CSV";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(830, 30);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(95, 17);
            this.checkBox1.TabIndex = 8;
            this.checkBox1.Text = "Include Parent";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 453);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Audit Logs";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 107);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "System Logs";
            // 
            // dGridViewLogAudit
            // 
            this.dGridViewLogAudit.AllowUserToAddRows = false;
            this.dGridViewLogAudit.AllowUserToDeleteRows = false;
            this.dGridViewLogAudit.AllowUserToOrderColumns = true;
            this.dGridViewLogAudit.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dGridViewLogAudit.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGridViewLogAudit.Location = new System.Drawing.Point(24, 469);
            this.dGridViewLogAudit.Name = "dGridViewLogAudit";
            this.dGridViewLogAudit.ReadOnly = true;
            this.dGridViewLogAudit.Size = new System.Drawing.Size(999, 251);
            this.dGridViewLogAudit.TabIndex = 5;
            // 
            // dGridViewLogSystem
            // 
            this.dGridViewLogSystem.AllowUserToAddRows = false;
            this.dGridViewLogSystem.AllowUserToDeleteRows = false;
            this.dGridViewLogSystem.AllowUserToOrderColumns = true;
            this.dGridViewLogSystem.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dGridViewLogSystem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGridViewLogSystem.Location = new System.Drawing.Point(24, 126);
            this.dGridViewLogSystem.Name = "dGridViewLogSystem";
            this.dGridViewLogSystem.ReadOnly = true;
            this.dGridViewLogSystem.Size = new System.Drawing.Size(999, 312);
            this.dGridViewLogSystem.TabIndex = 4;
            this.dGridViewLogSystem.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dGridViewLogSystem_CellContentClick);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(324, 30);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Search Period";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // cmbSearchPeriod
            // 
            this.cmbSearchPeriod.AllowDrop = true;
            this.cmbSearchPeriod.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbSearchPeriod.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbSearchPeriod.FormattingEnabled = true;
            this.cmbSearchPeriod.Items.AddRange(new object[] {
            "1 Hour",
            "6 Hours",
            "12 Hours",
            "1 Day",
            "2 Days",
            "5 Days",
            "7 Days",
            "1 Month",
            "Eternity (may take some time)"});
            this.cmbSearchPeriod.Location = new System.Drawing.Point(467, 30);
            this.cmbSearchPeriod.Name = "cmbSearchPeriod";
            this.cmbSearchPeriod.Size = new System.Drawing.Size(121, 21);
            this.cmbSearchPeriod.TabIndex = 11;
            this.cmbSearchPeriod.SelectedIndexChanged += new System.EventHandler(this.cmbSearchPeriod_SelectedIndexChanged);
            // 
            // Admin_Summary_TabTabUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "Admin_Summary_TabTabUserControl";
            this.Size = new System.Drawing.Size(1035, 732);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGridViewLogAudit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dGridViewLogSystem)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelItemName;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dGridViewLogSystem;
        private System.Windows.Forms.DataGridView dGridViewLogAudit;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbSearchPeriod;
    }
}
