using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileHandlingProgram
{
    public partial class RowDataForm : Form
    {
        private long serialNumber = FileHandlingProgramForm.GetNextSerialNumber();
        private long serialNumberToUpdate;
        private bool isReadOnlyMode;
        private List<string> records; // Store all records from the file
        private int currentRecordIndex; // Track the index of the current record being displayed
        private char delimiter = '|'; // Assuming '|' is the delimiter

        public RowDataForm(bool isReadOnlyMode)
        {
            InitializeComponent();
            PopulateCombobox();
            this.isReadOnlyMode = isReadOnlyMode;
            SetFormMode();
        }

        public RowDataForm(bool isReadOnlyMode, long serialNumberToUpdate)
        {
            InitializeComponent();
            PopulateCombobox();
            this.isReadOnlyMode = isReadOnlyMode;
            this.serialNumberToUpdate = serialNumberToUpdate; // Assign the provided serial number
            SetFormMode();
            LoadRecordsFromFile();
        }

        private long selectedSerialNumber;

        public RowDataForm(long serialNumber, bool isReadOnlyMode)
        {
            InitializeComponent();
            PopulateCombobox();
            this.isReadOnlyMode = isReadOnlyMode;
            SetFormMode();
            this.selectedSerialNumber = serialNumber;
            LoadRecordBySerialNumber(selectedSerialNumber);
        }

        private void LoadRecordsFromFile()
        {
            string filePath = @"E:\FileHandlingProgram.txt";
            try
            {
                string fileContent = File.ReadAllText(filePath);
                records = fileContent.Split(delimiter).ToList();
            }
            catch (IOException ex)
            {
                MessageBox.Show($"An error occurred while reading the file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        

        private void SetFormMode()
        {
            foreach (Control control in Controls)
            {
                if (control is TextBox textBox)
                {
                    textBox.ReadOnly = isReadOnlyMode;
                }
            }

            if (isReadOnlyMode)
            {
                AddButton.Enabled = false;
                EditButton.Enabled = false;
                ClearButton.Enabled = false;
                FirstButton.Enabled = true;
                PreviousButton.Enabled = true;
                NextButton.Enabled = true;
                LastButton.Enabled = true;

            }
            else
            {
                if (FileHandlingProgramForm.BoolNewButton)
                {
                    FileHandlingProgramForm.BoolNewButton = false;
                    AddButton.Enabled = true;
                    EditButton.Enabled = false;
                    ClearButton.Enabled = true;
                    FirstButton.Enabled = false;
                    PreviousButton.Enabled = false;
                    NextButton.Enabled = false;
                    LastButton.Enabled = false;
                }

                if (FileHandlingProgramForm.BoolUpdateButton && FileHandlingProgramForm.RowHeaderSelected)
                {
                    FileHandlingProgramForm.BoolUpdateButton = false;
                    FileHandlingProgramForm.RowHeaderSelected = false;
                    AddButton.Enabled = false;
                    EditButton.Enabled = true;
                    ClearButton.Enabled = true;
                    FirstButton.Enabled = false;
                    PreviousButton.Enabled = false;
                    NextButton.Enabled = false;
                    LastButton.Enabled = false;
                }

            }
        }


        public void SetData(DataRowView rowData)
        {
            PrefixTextbox.Text = rowData["Prefix"].ToString();
            FirstNameTextbox.Text = rowData["First Name"].ToString();
            MiddleNameTextbox.Text = rowData["Middle Name"].ToString();
            LastNameTextbox.Text = rowData["Last Name"].ToString();
            qualificationCombobox.Text = rowData["Qualification"].ToString();
            JODdateTimePicker.Text = rowData["Joining Date"].ToString();
            CurrentCompanyTextbox.Text = rowData["Current Company"].ToString();
            CurrentAddressTextbox.Text = rowData["Current Address"].ToString();
            DOBdateTimePicker.Text = rowData["Date Of Birth"].ToString();

        }

        public void SetDataForRecord(DataRowView rowData)
        {
            string rowDataString = rowData.Row.ItemArray[0].ToString(); // Assuming the row data is stored in the first column of the DataRowView
            string[] fields = rowDataString.Split('|');

            if (fields.Length >= 10) // Assuming there are at least 10 fields in each record
            {
                PrefixTextbox.Text = fields[1];
                FirstNameTextbox.Text = fields[2];
                MiddleNameTextbox.Text = fields[3];
                LastNameTextbox.Text = fields[4];
                qualificationCombobox.Text = fields[5];
                JODdateTimePicker.Text = fields[6];
                CurrentCompanyTextbox.Text = fields[7];
                CurrentAddressTextbox.Text = fields[8];
                DOBdateTimePicker.Text = fields[9];
            }
            else
            {
                MessageBox.Show("Invalid record format.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void AddButton_Click(object sender, EventArgs e)
        {
            string field1 = PrefixTextbox.Text;
            string field2 = FirstNameTextbox.Text;
            string field3 = MiddleNameTextbox.Text;
            string field4 = LastNameTextbox.Text;
            string field5 = qualificationCombobox.Text;
            string field6 = JODdateTimePicker.Text;
            DateTime joiningDate;
            if (DateTime.TryParseExact(field6, "dd MMMM yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out joiningDate))
            {
                string formattedDate = joiningDate.ToString("dd/MM/yyyy");
                // Use formattedDate or joiningDate as needed
            }
            else
            {
                // Date parsing failed, handle the error
                MessageBox.Show("Invalid date format. Please enter the date in dd MMMM yyyy format.");
            }


            string field7 = CurrentCompanyTextbox.Text;
            string field8 = CurrentAddressTextbox.Text;
            string field9 = DOBdateTimePicker.Text;
            DateTime dob;
            if (DateTime.TryParseExact(field9, "dd MMMM yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dob))
            {
                string formattedDate = dob.ToString("dd/MM/yyyy");
                // Use formattedDate or dob as needed
            }
            else
            {
                MessageBox.Show("Invalid date format. Please enter the date in dd MMMM yyyy format.");
            }



            // Validate input, if necessary


            AddData(field1, field2, field3, field4, field5, field6, field7, field8, field9, serialNumber);
        }


        private void AddData(string field1, string field2, string field3, string field4, string field5, string field6, string field7, string field8, string field9, long serialNumber)
        {
            string filePath = @"E:\FileHandlingProgram.txt";
            try
            {
                bool fileExists = File.Exists(filePath);

                if (!fileExists)
                {
                    using (File.Create(filePath)) { }
                }

                using (StreamWriter writer = new StreamWriter(filePath, append: true))
                {
                    string data = $"{serialNumber}|{field1}|{field2}|{field3}|{field4}|{field5}|{field6}|{field7}|{field8}|{field9}|";
                    writer.Write(data);
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine($"An error occurred while writing to the file: {ex.Message}");
            }
        }


        private void ClearButton_Click(object sender, EventArgs e)
        {
            PrefixTextbox.Text = "";
            FirstNameTextbox.Text = "";
            MiddleNameTextbox.Text = "";
            LastNameTextbox.Text = "";
            foreach (var item in qualificationCombobox.Items)
            {
                if (item.ToString() == "Select Qualification")
                {
                    qualificationCombobox.SelectedItem = item;
                    break;
                }
            }
            JODdateTimePicker.Text = "";
            CurrentCompanyTextbox.Text = "";
            CurrentAddressTextbox.Text = "";
            DOBdateTimePicker.Text = "";
        }

        public enum Qualification
        {
            TenthGrade,
            TwelfthGrade,
            // Diplomas
            Diploma,
            PGDiploma,
            // Bachelor's Degrees
            BSc,
            BCA,
            BA,
            BTechCSE, // Bachelor of Technology in Computer Science and Engineering
            BTechCivil, // Bachelor of Technology in Civil Engineering
            BTechIT,
            BE,// Bachelor of Technology in Information Technology
            // Master's Degrees
            MSc,
            MCA
        }

        public void PopulateCombobox()
        {
            qualificationCombobox.Items.Add("Select Qualification");
            
            foreach (Qualification qualification in Enum.GetValues(typeof(Qualification)))
            {
                qualificationCombobox.Items.Add(qualification);
            }

            qualificationCombobox.SelectedIndex = 0;

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (qualificationCombobox.SelectedItem != null && qualificationCombobox.SelectedItem is Qualification)
            {
                Qualification selectedQualification = (Qualification)qualificationCombobox.SelectedItem;
            }
        }


        private void JODdateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            DateTime selectedJoiningDate = JODdateTimePicker.Value;
        }

        private void DOBdateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            DateTime selectedDOB = DOBdateTimePicker.Value;
        }

        private void RowDataForm_FormClosing(object sender, FormClosingEventArgs e)
        {
           // FileHandlingProgramForm f = new FileHandlingProgramForm();
            //f.PopulateDataGridView();
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            string field1 = PrefixTextbox.Text;
            string field2 = FirstNameTextbox.Text;
            string field3 = MiddleNameTextbox.Text;
            string field4 = LastNameTextbox.Text;
            string field5 = qualificationCombobox.Text;
            string field6 = JODdateTimePicker.Text;
            DateTime joiningDate;
            if (DateTime.TryParseExact(field6, "dd MMMM yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out joiningDate))
            {
                string formattedDate = joiningDate.ToString("dd/MM/yyyy");
                // Use formattedDate or joiningDate as needed
            }
            else
            {
                // Date parsing failed, handle the error
                MessageBox.Show("Invalid date format. Please enter the date in dd MMMM yyyy format.");
            }

            string field7 = CurrentCompanyTextbox.Text;
            string field8 = CurrentAddressTextbox.Text;
            string field9 = DOBdateTimePicker.Text;
            DateTime dob;
            if (DateTime.TryParseExact(field9, "dd MMMM yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dob))
            {
                string formattedDate = dob.ToString("dd/MM/yyyy");
                // Use formattedDate or dob as needed
            }
            else
            {
                MessageBox.Show("Invalid date format. Please enter the date in dd MMMM yyyy format.");
            }


            // Validate input, if necessary
            UpdateRecordBySerialNumber(serialNumberToUpdate, field1, field2, field3, field4, field5, field6, field7, field8, field9);
        }



        private void UpdateRecordBySerialNumber(long serialNumberToUpdate, string field1, string field2, string field3, string field4, string field5, string field6, string field7, string field8, string field9)
        {
            string filePath = @"E:\FileHandlingProgram.txt";

            try
            {
                string fileContent = File.ReadAllText(filePath);
                string[] records = fileContent.Split('|');

                bool recordUpdated = false;
                for (int i = 0; i < records.Length; i += 10) // Assuming each record has 10 fields
                {
                    if (i + 10 <= records.Length)
                    {
                        if (long.TryParse(records[i], out long recordSerialNumber) && recordSerialNumber == serialNumberToUpdate)
                        {
                            // Update the fields of the record
                            records[i + 1] = field1;
                            records[i + 2] = field2;
                            records[i + 3] = field3;
                            records[i + 4] = field4;
                            records[i + 5] = field5;
                            records[i + 6] = field6;
                            records[i + 7] = field7;
                            records[i + 8] = field8;
                            records[i + 9] = field9;

                            recordUpdated = true;
                            break;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Invalid data format: Incomplete record found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                if (!recordUpdated)
                {
                    MessageBox.Show("Record not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Write the modified content back to the file
                File.WriteAllText(filePath, string.Join("|", records));

                // Refresh DataGridView or perform any other necessary action
                //FileHandlingProgramForm.PopulateDataGridView();
            }
            catch (IOException ex)
            {
                MessageBox.Show($"An error occurred while updating the record: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void LoadRecordBySerialNumber(long serialNumber)
        {
            if (records != null && records.Count > 0)
            {
                int index = records.FindIndex(record => record.StartsWith(serialNumber.ToString()));
                if (index != -1)
                {
                    currentRecordIndex = index;
                    DisplayRecord(currentRecordIndex);
                }
            }
        }


        private void DisplayRecord(int index)
        {
            if (index >= 0 && index < records.Count)
            {
                string[] fields = records[index].Split(delimiter);
                // Display fields in the form controls, skipping the 0th field
                PrefixTextbox.Text = fields[1];
                FirstNameTextbox.Text = fields[2];
                MiddleNameTextbox.Text = fields[3];
                LastNameTextbox.Text = fields[4];
                qualificationCombobox.Text = fields[5];
                JODdateTimePicker.Text = fields[6];
                CurrentCompanyTextbox.Text = fields[7];
                CurrentAddressTextbox.Text = fields[8];
                DOBdateTimePicker.Text = fields[9];
            }
        }

        private void FirstButton_Click(object sender, EventArgs e)
        {
            NavigateToFirstRecord();
        }

        private void PreviousButton_Click(object sender, EventArgs e)
        {
            NavigateToRecord(currentRecordIndex - 1);
        }

        private void NextButton_Click(object sender, EventArgs e)
        {
            NavigateToRecord(currentRecordIndex + 1);
        }

        private void LastButton_Click(object sender, EventArgs e)
        {
            NavigateToLastRecord();
        }

        private void NavigateToFirstRecord()
        {
            if (records != null && records.Count > 0)
            {
                currentRecordIndex = 0;
                DisplayRecord(currentRecordIndex);
            }
        }

        private void NavigateToLastRecord()
        {
            if (records != null && records.Count > 0)
            {
                currentRecordIndex = records.Count - 1;
                DisplayRecord(currentRecordIndex);
            }
        }

        private void NavigateToRecord(int index)
        {
            if (records != null && records.Count > 0 && index >= 0 && index < records.Count)
            {
                currentRecordIndex = index;
                DisplayRecord(currentRecordIndex);
            }
        }



    }
}
