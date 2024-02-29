using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FHP.VO;

namespace FHP.UI
{
    public class ViewDataForm : UpdateDataForm
    {


        private Button First;
        private Button previous;
        private Button Next;
        private Button Last;

        public ViewDataForm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.First = new System.Windows.Forms.Button();
            this.previous = new System.Windows.Forms.Button();
            this.Next = new System.Windows.Forms.Button();
            this.Last = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Add
            // 
            this.Add.BackColor = System.Drawing.Color.DarkGray;
            // 
            // Clear
            // 
            this.Clear.BackColor = System.Drawing.Color.DarkGray;
            this.Clear.Location = new System.Drawing.Point(421, 360);
            this.Clear.Size = new System.Drawing.Size(107, 45);
            // 
            // Edit
            // 
            this.Edit.BackColor = System.Drawing.Color.DarkGray;
            // 
            // First
            // 
            this.First.BackColor = System.Drawing.Color.DarkGray;
            this.First.Location = new System.Drawing.Point(164, 347);
            this.First.Name = "First";
            this.First.Size = new System.Drawing.Size(75, 23);
            this.First.TabIndex = 0;
            this.First.Text = "First";
            this.First.UseVisualStyleBackColor = false;
            this.First.Click += new System.EventHandler(this.First_Click);
            // 
            // previous
            // 
            this.previous.BackColor = System.Drawing.Color.DarkGray;
            this.previous.Location = new System.Drawing.Point(271, 347);
            this.previous.Name = "previous";
            this.previous.Size = new System.Drawing.Size(75, 23);
            this.previous.TabIndex = 0;
            this.previous.Text = "Previous";
            this.previous.UseVisualStyleBackColor = false;
            this.previous.Click += new System.EventHandler(this.previous_Click);
            // 
            // Next
            // 
            this.Next.BackColor = System.Drawing.Color.DarkGray;
            this.Next.Location = new System.Drawing.Point(365, 347);
            this.Next.Name = "Next";
            this.Next.Size = new System.Drawing.Size(75, 23);
            this.Next.TabIndex = 0;
            this.Next.Text = "Next";
            this.Next.UseVisualStyleBackColor = false;
            this.Next.Click += new System.EventHandler(this.Next_Click);
            // 
            // Last
            // 
            this.Last.BackColor = System.Drawing.Color.DarkGray;
            this.Last.Location = new System.Drawing.Point(466, 347);
            this.Last.Name = "Last";
            this.Last.Size = new System.Drawing.Size(75, 23);
            this.Last.TabIndex = 0;
            this.Last.Text = "Last";
            this.Last.UseVisualStyleBackColor = false;
            this.Last.Click += new System.EventHandler(this.Last_Click);
            // 
            // ViewDataForm
            // 
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(693, 414);
            this.Controls.Add(this.Last);
            this.Controls.Add(this.Next);
            this.Controls.Add(this.previous);
            this.Controls.Add(this.First);
            this.Name = "ViewDataForm";
            this.Load += new System.EventHandler(this.ViewDataForm_Load);
            this.Controls.SetChildIndex(this.DOBPicker1, 0);
            this.Controls.SetChildIndex(this.DOJPicker1, 0);
            this.Controls.SetChildIndex(this.QualificationcomboBox1, 0);
            this.Controls.SetChildIndex(this.First, 0);
            this.Controls.SetChildIndex(this.previous, 0);
            this.Controls.SetChildIndex(this.Next, 0);
            this.Controls.SetChildIndex(this.Last, 0);
            this.Controls.SetChildIndex(this.Add, 0);
            this.Controls.SetChildIndex(this.Edit, 0);
            this.Controls.SetChildIndex(this.Clear, 0);
            this.Controls.SetChildIndex(this.SrNo, 0);
            this.Controls.SetChildIndex(this.CurrentAddress, 0);
            this.Controls.SetChildIndex(this.Prefix, 0);
            this.Controls.SetChildIndex(this.DOB, 0);
            this.Controls.SetChildIndex(this.DOJ, 0);
            this.Controls.SetChildIndex(this.CurrentCompany, 0);
            this.Controls.SetChildIndex(this.FirstName, 0);
            this.Controls.SetChildIndex(this.MiddleName, 0);
            this.Controls.SetChildIndex(this.LastName, 0);
            this.Controls.SetChildIndex(this.Qualification, 0);
            this.Controls.SetChildIndex(this.SrNoText, 0);
            this.Controls.SetChildIndex(this.PrifixText, 0);
            this.Controls.SetChildIndex(this.CurrentAddressText, 0);
            this.Controls.SetChildIndex(this.FirstNameText, 0);
            this.Controls.SetChildIndex(this.CurrentCompanyText, 0);
            this.Controls.SetChildIndex(this.MiddleNameText, 0);
            this.Controls.SetChildIndex(this.LastNameText, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void ViewDataForm_Load(object sender, EventArgs e)
        {
            SrNoText.ReadOnly = true;
            FirstNameText.ReadOnly = true;
            MiddleNameText.ReadOnly = true;
            LastNameText.ReadOnly = true;
            PrifixText.ReadOnly = true;
            CurrentAddressText.ReadOnly = true;
            CurrentCompanyText.ReadOnly = true;
            DOBPicker1.Enabled = false;
            DOJPicker1.Enabled = true;

            Add.Visible = false;
            Edit.Visible = false;
            Clear.Visible = false;
            QualificationcomboBox1.Enabled = false;


        }

        private int currentRecordIndex;
        private List<RecordVO> records;

        public ViewDataForm(int currentIndex, List<RecordVO> records)
        {
            InitializeComponent();
            this.records = records;

            currentRecordIndex = currentIndex;
            DisplayRecord(records[currentRecordIndex]);
        }

        private void DisplayRecord(RecordVO record)
        {
            SrNoText.Text = record.SrNo.ToString();
            FirstNameText.Text = record.FirstName;
            MiddleNameText.Text = record.MiddleName;
            LastNameText.Text = record.LastName;
            PrifixText.Text = record.Prefix;
            CurrentAddressText.Text = record.CurrentAddress;
            CurrentCompanyText.Text = record.CurrentCompany;
            string dobFormatted = record.DOB.ToString("dd-MM-yyyy");
            string dojFormatted = record.DOJ.ToString("dd-MM-yyyy");
            DOBPicker1.Text = dobFormatted;
            DOJPicker1.Text = dojFormatted;
            QualificationcomboBox1.Text = record.Qualification.ToString();

        }


        private void First_Click(object sender, EventArgs e)
        {
            currentRecordIndex = 0;
            DisplayRecord(records[currentRecordIndex]);
            previous.Enabled = false;
            Next.Enabled = true;
        }

        private void previous_Click(object sender, EventArgs e)
        {
            if (currentRecordIndex > 0)
            {
                currentRecordIndex--;
                DisplayRecord(records[currentRecordIndex]);
                Next.Enabled = true;
            }
        }

        private void Next_Click(object sender, EventArgs e)
        {
            if (currentRecordIndex < records.Count - 1)
            {
                currentRecordIndex++;
                DisplayRecord(records[currentRecordIndex]);
                previous.Enabled = true;
            }
        }

        private void Last_Click(object sender, EventArgs e)
        {
            currentRecordIndex = records.Count - 1;
            DisplayRecord(records[currentRecordIndex]);
            Next.Enabled = false;
            previous.Enabled = true;
        }



    }
}
