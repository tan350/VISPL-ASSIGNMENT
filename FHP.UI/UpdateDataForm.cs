using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FHP.RES;
using FHP.BL;
using FHP.VO;

namespace FHP.UI
{
    public class UpdateDataForm : Form
    {


        public Button Add;
        public Button Clear;
        public Label SrNo;
        public Label Prefix;
        public Label FirstName;
        public Label MiddleName;
        public Label LastName;
        public Label Qualification;
        public Label CurrentAddress;
        public Label DOJ;
        public Label DOB;
        public Label CurrentCompany;
        public TextBox SrNoText;
        public TextBox PrifixText;
        public TextBox FirstNameText;
        public TextBox MiddleNameText;
        public TextBox LastNameText;
        public TextBox CurrentAddressText;
        public TextBox CurrentCompanyText;
        public DateTimePicker DOBPicker1;
        public DateTimePicker DOJPicker1;
        public ComboBox QualificationcomboBox1;
        public Button Edit;


        Education_Level msg = new Education_Level();
        ValidationBL entityHandle = new ValidationBL();


        public UpdateDataForm()
        {
            InitializeComponent();
            LoadQualificationEnum();
            SrNoText.Text = FHPUIForm.serialNum.ToString();
            SrNoText.ReadOnly = true;

        }
        private void LoadQualificationEnum()
        {
            Array values = Enum.GetValues(typeof(Education_Level.EducationLevel));
            QualificationcomboBox1.DataSource = values;
        }

        public void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UpdateDataForm));
            this.Add = new System.Windows.Forms.Button();
            this.Edit = new System.Windows.Forms.Button();
            this.Clear = new System.Windows.Forms.Button();
            this.SrNo = new System.Windows.Forms.Label();
            this.Prefix = new System.Windows.Forms.Label();
            this.FirstName = new System.Windows.Forms.Label();
            this.MiddleName = new System.Windows.Forms.Label();
            this.LastName = new System.Windows.Forms.Label();
            this.Qualification = new System.Windows.Forms.Label();
            this.CurrentAddress = new System.Windows.Forms.Label();
            this.DOJ = new System.Windows.Forms.Label();
            this.DOB = new System.Windows.Forms.Label();
            this.CurrentCompany = new System.Windows.Forms.Label();
            this.SrNoText = new System.Windows.Forms.TextBox();
            this.PrifixText = new System.Windows.Forms.TextBox();
            this.FirstNameText = new System.Windows.Forms.TextBox();
            this.MiddleNameText = new System.Windows.Forms.TextBox();
            this.LastNameText = new System.Windows.Forms.TextBox();
            this.CurrentAddressText = new System.Windows.Forms.TextBox();
            this.CurrentCompanyText = new System.Windows.Forms.TextBox();
            this.DOBPicker1 = new System.Windows.Forms.DateTimePicker();
            this.DOJPicker1 = new System.Windows.Forms.DateTimePicker();
            this.QualificationcomboBox1 = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // Add
            // 
            this.Add.BackColor = System.Drawing.Color.DarkGray;
            this.Add.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Add.Location = new System.Drawing.Point(170, 360);
            this.Add.Name = "Add";
            this.Add.Size = new System.Drawing.Size(102, 45);
            this.Add.TabIndex = 0;
            this.Add.Text = "Add";
            this.Add.UseVisualStyleBackColor = false;
            this.Add.Click += new System.EventHandler(this.Add_Click);
            // 
            // Edit
            // 
            this.Edit.BackColor = System.Drawing.Color.DarkGray;
            this.Edit.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Edit.Location = new System.Drawing.Point(293, 360);
            this.Edit.Name = "Edit";
            this.Edit.Size = new System.Drawing.Size(107, 45);
            this.Edit.TabIndex = 1;
            this.Edit.Text = "Edit";
            this.Edit.UseVisualStyleBackColor = false;
            this.Edit.Click += new System.EventHandler(this.Edit_Click);
            // 
            // Clear
            // 
            this.Clear.BackColor = System.Drawing.Color.DarkGray;
            this.Clear.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Clear.Location = new System.Drawing.Point(424, 360);
            this.Clear.Name = "Clear";
            this.Clear.Size = new System.Drawing.Size(81, 45);
            this.Clear.TabIndex = 2;
            this.Clear.Text = "Clear";
            this.Clear.UseVisualStyleBackColor = false;
            this.Clear.Click += new System.EventHandler(this.Clear_Click);
            // 
            // SrNo
            // 
            this.SrNo.AutoSize = true;
            this.SrNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SrNo.Location = new System.Drawing.Point(40, 58);
            this.SrNo.Name = "SrNo";
            this.SrNo.Size = new System.Drawing.Size(43, 13);
            this.SrNo.TabIndex = 3;
            this.SrNo.Text = "Sr No.";
            // 
            // Prefix
            // 
            this.Prefix.AutoSize = true;
            this.Prefix.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Prefix.Location = new System.Drawing.Point(40, 100);
            this.Prefix.Name = "Prefix";
            this.Prefix.Size = new System.Drawing.Size(39, 13);
            this.Prefix.TabIndex = 3;
            this.Prefix.Text = "Prefix";
            // 
            // FirstName
            // 
            this.FirstName.AutoSize = true;
            this.FirstName.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FirstName.Location = new System.Drawing.Point(40, 142);
            this.FirstName.Name = "FirstName";
            this.FirstName.Size = new System.Drawing.Size(72, 13);
            this.FirstName.TabIndex = 3;
            this.FirstName.Text = "First Name*";
            // 
            // MiddleName
            // 
            this.MiddleName.AutoSize = true;
            this.MiddleName.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MiddleName.Location = new System.Drawing.Point(40, 196);
            this.MiddleName.Name = "MiddleName";
            this.MiddleName.Size = new System.Drawing.Size(80, 13);
            this.MiddleName.TabIndex = 3;
            this.MiddleName.Text = "Middle Name";
            // 
            // LastName
            // 
            this.LastName.AutoSize = true;
            this.LastName.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LastName.Location = new System.Drawing.Point(40, 253);
            this.LastName.Name = "LastName";
            this.LastName.Size = new System.Drawing.Size(67, 13);
            this.LastName.TabIndex = 3;
            this.LastName.Text = "Last Name";
            // 
            // Qualification
            // 
            this.Qualification.AutoSize = true;
            this.Qualification.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Qualification.Location = new System.Drawing.Point(380, 139);
            this.Qualification.Name = "Qualification";
            this.Qualification.Size = new System.Drawing.Size(83, 13);
            this.Qualification.TabIndex = 3;
            this.Qualification.Text = "Qualification*";
            // 
            // CurrentAddress
            // 
            this.CurrentAddress.AutoSize = true;
            this.CurrentAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CurrentAddress.Location = new System.Drawing.Point(380, 229);
            this.CurrentAddress.Name = "CurrentAddress";
            this.CurrentAddress.Size = new System.Drawing.Size(97, 13);
            this.CurrentAddress.TabIndex = 3;
            this.CurrentAddress.Text = "Current Address";
            // 
            // DOJ
            // 
            this.DOJ.AutoSize = true;
            this.DOJ.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DOJ.Location = new System.Drawing.Point(380, 96);
            this.DOJ.Name = "DOJ";
            this.DOJ.Size = new System.Drawing.Size(36, 13);
            this.DOJ.TabIndex = 3;
            this.DOJ.Text = "DOJ*";
            // 
            // DOB
            // 
            this.DOB.AutoSize = true;
            this.DOB.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DOB.Location = new System.Drawing.Point(383, 58);
            this.DOB.Name = "DOB";
            this.DOB.Size = new System.Drawing.Size(33, 13);
            this.DOB.TabIndex = 3;
            this.DOB.Text = "DOB";
            // 
            // CurrentCompany
            // 
            this.CurrentCompany.AutoSize = true;
            this.CurrentCompany.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CurrentCompany.Location = new System.Drawing.Point(380, 180);
            this.CurrentCompany.Name = "CurrentCompany";
            this.CurrentCompany.Size = new System.Drawing.Size(108, 13);
            this.CurrentCompany.TabIndex = 3;
            this.CurrentCompany.Text = "Current Company*";
            // 
            // SrNoText
            // 
            this.SrNoText.Location = new System.Drawing.Point(144, 52);
            this.SrNoText.Multiline = true;
            this.SrNoText.Name = "SrNoText";
            this.SrNoText.Size = new System.Drawing.Size(49, 34);
            this.SrNoText.TabIndex = 4;
            // 
            // PrifixText
            // 
            this.PrifixText.Location = new System.Drawing.Point(144, 95);
            this.PrifixText.Multiline = true;
            this.PrifixText.Name = "PrifixText";
            this.PrifixText.Size = new System.Drawing.Size(86, 38);
            this.PrifixText.TabIndex = 4;
            // 
            // FirstNameText
            // 
            this.FirstNameText.Location = new System.Drawing.Point(144, 139);
            this.FirstNameText.Multiline = true;
            this.FirstNameText.Name = "FirstNameText";
            this.FirstNameText.Size = new System.Drawing.Size(141, 35);
            this.FirstNameText.TabIndex = 4;
            // 
            // MiddleNameText
            // 
            this.MiddleNameText.Location = new System.Drawing.Point(144, 193);
            this.MiddleNameText.Multiline = true;
            this.MiddleNameText.Name = "MiddleNameText";
            this.MiddleNameText.Size = new System.Drawing.Size(141, 35);
            this.MiddleNameText.TabIndex = 4;
            // 
            // LastNameText
            // 
            this.LastNameText.Location = new System.Drawing.Point(144, 250);
            this.LastNameText.Multiline = true;
            this.LastNameText.Name = "LastNameText";
            this.LastNameText.Size = new System.Drawing.Size(141, 35);
            this.LastNameText.TabIndex = 4;
            // 
            // CurrentAddressText
            // 
            this.CurrentAddressText.Location = new System.Drawing.Point(505, 226);
            this.CurrentAddressText.Multiline = true;
            this.CurrentAddressText.Name = "CurrentAddressText";
            this.CurrentAddressText.Size = new System.Drawing.Size(145, 59);
            this.CurrentAddressText.TabIndex = 4;
            // 
            // CurrentCompanyText
            // 
            this.CurrentCompanyText.Location = new System.Drawing.Point(505, 177);
            this.CurrentCompanyText.Multiline = true;
            this.CurrentCompanyText.Name = "CurrentCompanyText";
            this.CurrentCompanyText.Size = new System.Drawing.Size(145, 32);
            this.CurrentCompanyText.TabIndex = 4;
            // 
            // DOBPicker1
            // 
            this.DOBPicker1.Location = new System.Drawing.Point(505, 52);
            this.DOBPicker1.Name = "DOBPicker1";
            this.DOBPicker1.Size = new System.Drawing.Size(141, 20);
            this.DOBPicker1.TabIndex = 5;
            // 
            // DOJPicker1
            // 
            this.DOJPicker1.Location = new System.Drawing.Point(505, 93);
            this.DOJPicker1.Name = "DOJPicker1";
            this.DOJPicker1.Size = new System.Drawing.Size(141, 20);
            this.DOJPicker1.TabIndex = 6;
            // 
            // QualificationcomboBox1
            // 
            this.QualificationcomboBox1.FormattingEnabled = true;
            this.QualificationcomboBox1.Location = new System.Drawing.Point(505, 131);
            this.QualificationcomboBox1.Name = "QualificationcomboBox1";
            this.QualificationcomboBox1.Size = new System.Drawing.Size(141, 21);
            this.QualificationcomboBox1.TabIndex = 7;
            // 
            // UpdateDataForm
            // 
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(699, 415);
            this.Controls.Add(this.QualificationcomboBox1);
            this.Controls.Add(this.DOJPicker1);
            this.Controls.Add(this.DOBPicker1);
            this.Controls.Add(this.LastNameText);
            this.Controls.Add(this.MiddleNameText);
            this.Controls.Add(this.CurrentCompanyText);
            this.Controls.Add(this.FirstNameText);
            this.Controls.Add(this.CurrentAddressText);
            this.Controls.Add(this.PrifixText);
            this.Controls.Add(this.SrNoText);
            this.Controls.Add(this.Qualification);
            this.Controls.Add(this.LastName);
            this.Controls.Add(this.MiddleName);
            this.Controls.Add(this.FirstName);
            this.Controls.Add(this.CurrentCompany);
            this.Controls.Add(this.DOJ);
            this.Controls.Add(this.DOB);
            this.Controls.Add(this.Prefix);
            this.Controls.Add(this.CurrentAddress);
            this.Controls.Add(this.SrNo);
            this.Controls.Add(this.Clear);
            this.Controls.Add(this.Edit);
            this.Controls.Add(this.Add);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "UpdateDataForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        public static Education_Level.EducationLevel GetEducationLevelFromIndex(byte index)
        {
            if (index >= 0 && index < Enum.GetNames(typeof(Education_Level.EducationLevel)).Length)
            {
                return (Education_Level.EducationLevel)index;
            }
            else
            {
                throw new ArgumentOutOfRangeException(nameof(index), "Index is out of range for the EducationLevel enum.");
            }
        }

        private void Add_Click(object sender, EventArgs e)
        {

            long SrNo = FHPUIForm.serialNum;
            string firstName = FirstNameText.Text;
            string middleName = MiddleNameText.Text;
            string lastName = LastNameText.Text;
            string prefix = PrifixText.Text;
            DateTime dob = (DOBPicker1.Value);  // Convert to DateTime
            DateTime doj = (DOJPicker1.Value);
            string CurrentAdd = CurrentAddressText.Text;
            string CurrentCompany = CurrentCompanyText.Text;
            byte qualification = (byte)QualificationcomboBox1.SelectedIndex;


            string dobFormatted = DOBPicker1.Value.ToString("dd-MM-yyyy");
            string dojFormatted = DOJPicker1.Value.ToString("dd-MM-yyyy");
            // Create a Record instance
            RecordVO newRecord = new RecordVO
            {

                SrNo = SrNo,
                FirstName = firstName,
                MiddleName = middleName,
                LastName = lastName,
                Prefix = prefix,
                DOB = dob,
                DOJ = doj,
                CurrentAddress = CurrentAdd,
                CurrentCompany = CurrentCompany,
                Qualification = GetEducationLevelFromIndex(qualification).ToString(),

            };
            byte s = 0;
            if (entityHandle.CheckRecorddata(newRecord, ref s))
            {


                entityHandle.AddData(newRecord);
                MessageBox.Show("Data Added Successfully");
                UpdateDataForm dataUpdateForm = new UpdateDataForm();
                dataUpdateForm.Close();
            }
            else
            {
                // MessageBox.Show("Please fill mandatory fields");              
                MessageBox.Show(msg.GetDescriptionStringFromByte(s));
            }



        }

        private void Edit_Click(object sender, EventArgs e)
        {

            long SrNo = Convert.ToInt64(SrNoText.Text);
            string firstName = FirstNameText.Text;
            string middleName = MiddleNameText.Text;
            string lastName = LastNameText.Text;
            string prefix = PrifixText.Text;
            DateTime dob = (DOBPicker1.Value);  // Convert to DateTime
            DateTime doj = (DOJPicker1.Value);
            string CurrentAdd = CurrentAddressText.Text;
            string CurrentCompany = CurrentCompanyText.Text;
            byte qualification = (byte)QualificationcomboBox1.SelectedIndex;

            RecordVO newRecord = new RecordVO
            {

                SrNo = SrNo,
                FirstName = firstName,
                MiddleName = middleName,
                LastName = lastName,
                Prefix = prefix,
                DOB = dob,
                DOJ = doj,
                CurrentAddress = CurrentAdd,
                CurrentCompany = CurrentCompany,
                Qualification = GetEducationLevelFromIndex(qualification).ToString(),

            };
            byte s = 0;
            if (entityHandle.CheckRecorddata(newRecord, ref s))
            {

                entityHandle.UpdateData(SrNo, newRecord);
                MessageBox.Show("Edit Successfully");
            }
            else
            {
                // MessageBox.Show("Please fill mandatory fields");
                MessageBox.Show(msg.GetDescriptionStringFromByte(s));
            }

        }

        private void Clear_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to clear the data?", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            DateTime dob = DOBPicker1.Value;
            DateTime doj = DOJPicker1.Value;
            if (result == DialogResult.OK)
            {

                FirstNameText.Clear();
                MiddleNameText.Clear();
                LastNameText.Clear();
                PrifixText.Clear();
                CurrentAddressText.Clear();
                CurrentCompanyText.Clear();
                dob = (DateTime.Now);  // Convert to DateTime
                doj = (DateTime.Now);
                //byte qualification = QualificationText.Text;
            }
            else
            {
            }
        }

    }
}
