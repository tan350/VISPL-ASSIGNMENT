namespace FHP.UI
{
    partial class FHPUIForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FHPUIForm));
            this.MenuStrip = new System.Windows.Forms.MenuStrip();
            this.NewItem = new System.Windows.Forms.ToolStripMenuItem();
            this.UpdateItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DeleteItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ClearSearchItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ViewItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ExitItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AboutUsItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.SrNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Prefix = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FirstName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MiddleName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LastName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DOB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DOJ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Qualification = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CurrentAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CurrentCompany = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SearchTextbox = new System.Windows.Forms.TextBox();
            this.BtnSearch = new System.Windows.Forms.Button();
            this.MenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // MenuStrip
            // 
            this.MenuStrip.BackColor = System.Drawing.Color.LightGray;
            this.MenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NewItem,
            this.UpdateItem,
            this.DeleteItem,
            this.ClearSearchItem,
            this.ViewItem,
            this.ExitItem,
            this.AboutUsItem});
            this.MenuStrip.Location = new System.Drawing.Point(0, 0);
            this.MenuStrip.Name = "MenuStrip";
            this.MenuStrip.Size = new System.Drawing.Size(800, 24);
            this.MenuStrip.TabIndex = 0;
            this.MenuStrip.Text = "Menu";
            // 
            // NewItem
            // 
            this.NewItem.Name = "NewItem";
            this.NewItem.Size = new System.Drawing.Size(43, 20);
            this.NewItem.Text = "New";
            this.NewItem.Click += new System.EventHandler(this.NewItem_Click);
            // 
            // UpdateItem
            // 
            this.UpdateItem.Name = "UpdateItem";
            this.UpdateItem.Size = new System.Drawing.Size(57, 20);
            this.UpdateItem.Text = "Update";
            this.UpdateItem.Click += new System.EventHandler(this.UpdateItem_Click);
            // 
            // DeleteItem
            // 
            this.DeleteItem.Name = "DeleteItem";
            this.DeleteItem.Size = new System.Drawing.Size(52, 20);
            this.DeleteItem.Text = "Delete";
            this.DeleteItem.Click += new System.EventHandler(this.DeleteItem_Click);
            // 
            // ClearSearchItem
            // 
            this.ClearSearchItem.Name = "ClearSearchItem";
            this.ClearSearchItem.Size = new System.Drawing.Size(115, 20);
            this.ClearSearchItem.Text = "Clear Search/Filter";
            this.ClearSearchItem.Click += new System.EventHandler(this.ClearSearchItem_Click);
            // 
            // ViewItem
            // 
            this.ViewItem.Name = "ViewItem";
            this.ViewItem.Size = new System.Drawing.Size(44, 20);
            this.ViewItem.Text = "View";
            this.ViewItem.Click += new System.EventHandler(this.ViewItem_Click);
            // 
            // ExitItem
            // 
            this.ExitItem.Name = "ExitItem";
            this.ExitItem.Size = new System.Drawing.Size(38, 20);
            this.ExitItem.Text = "Exit";
            this.ExitItem.Click += new System.EventHandler(this.ExitItem_Click);
            // 
            // AboutUsItem
            // 
            this.AboutUsItem.Name = "AboutUsItem";
            this.AboutUsItem.Size = new System.Drawing.Size(68, 20);
            this.AboutUsItem.Text = "About Us";
            this.AboutUsItem.Click += new System.EventHandler(this.AboutUsItem_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SrNumber,
            this.Prefix,
            this.FirstName,
            this.MiddleName,
            this.LastName,
            this.DOB,
            this.DOJ,
            this.Qualification,
            this.CurrentAddress,
            this.CurrentCompany});
            this.dataGridView1.Location = new System.Drawing.Point(0, 27);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(800, 424);
            this.dataGridView1.TabIndex = 1;
            // 
            // SrNumber
            // 
            this.SrNumber.HeaderText = "Sr No.";
            this.SrNumber.Name = "SrNumber";
            this.SrNumber.Width = 30;
            // 
            // Prefix
            // 
            this.Prefix.HeaderText = "Prefix";
            this.Prefix.Name = "Prefix";
            this.Prefix.Width = 55;
            // 
            // FirstName
            // 
            this.FirstName.HeaderText = "First Name";
            this.FirstName.Name = "FirstName";
            this.FirstName.Width = 85;
            // 
            // MiddleName
            // 
            this.MiddleName.HeaderText = "Middle Name";
            this.MiddleName.Name = "MiddleName";
            this.MiddleName.Width = 95;
            // 
            // LastName
            // 
            this.LastName.HeaderText = "Last Name";
            this.LastName.Name = "LastName";
            this.LastName.Width = 85;
            // 
            // DOB
            // 
            this.DOB.HeaderText = "DOB";
            this.DOB.Name = "DOB";
            this.DOB.Width = 70;
            // 
            // DOJ
            // 
            this.DOJ.HeaderText = "DOJ";
            this.DOJ.Name = "DOJ";
            this.DOJ.Width = 70;
            // 
            // Qualification
            // 
            this.Qualification.HeaderText = "Qualification";
            this.Qualification.Name = "Qualification";
            // 
            // CurrentAddress
            // 
            this.CurrentAddress.HeaderText = "Current Address";
            this.CurrentAddress.Name = "CurrentAddress";
            // 
            // CurrentCompany
            // 
            this.CurrentCompany.HeaderText = "Current Company";
            this.CurrentCompany.Name = "CurrentCompany";
            // 
            // SearchTextbox
            // 
            this.SearchTextbox.Location = new System.Drawing.Point(503, 0);
            this.SearchTextbox.Multiline = true;
            this.SearchTextbox.Name = "SearchTextbox";
            this.SearchTextbox.Size = new System.Drawing.Size(110, 24);
            this.SearchTextbox.TabIndex = 2;
            // 
            // BtnSearch
            // 
            this.BtnSearch.BackColor = System.Drawing.Color.DarkGray;
            this.BtnSearch.Location = new System.Drawing.Point(619, 1);
            this.BtnSearch.Name = "BtnSearch";
            this.BtnSearch.Size = new System.Drawing.Size(60, 23);
            this.BtnSearch.TabIndex = 3;
            this.BtnSearch.Text = "Search";
            this.BtnSearch.UseVisualStyleBackColor = false;
            this.BtnSearch.Click += new System.EventHandler(this.BtnSearch_Click);
            // 
            // FHPUIForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.BtnSearch);
            this.Controls.Add(this.SearchTextbox);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.MenuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.MenuStrip;
            this.Name = "FHPUIForm";
            this.Text = "File Handling Program";
            this.MenuStrip.ResumeLayout(false);
            this.MenuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip MenuStrip;
        private System.Windows.Forms.ToolStripMenuItem NewItem;
        private System.Windows.Forms.ToolStripMenuItem UpdateItem;
        private System.Windows.Forms.ToolStripMenuItem DeleteItem;
        private System.Windows.Forms.ToolStripMenuItem ClearSearchItem;
        private System.Windows.Forms.ToolStripMenuItem ViewItem;
        private System.Windows.Forms.ToolStripMenuItem ExitItem;
        private System.Windows.Forms.ToolStripMenuItem AboutUsItem;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn SrNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn Prefix;
        private System.Windows.Forms.DataGridViewTextBoxColumn FirstName;
        private System.Windows.Forms.DataGridViewTextBoxColumn MiddleName;
        private System.Windows.Forms.DataGridViewTextBoxColumn LastName;
        private System.Windows.Forms.DataGridViewTextBoxColumn DOB;
        private System.Windows.Forms.DataGridViewTextBoxColumn DOJ;
        private System.Windows.Forms.DataGridViewTextBoxColumn Qualification;
        private System.Windows.Forms.DataGridViewTextBoxColumn CurrentAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn CurrentCompany;
        private System.Windows.Forms.TextBox SearchTextbox;
        private System.Windows.Forms.Button BtnSearch;
    }
}