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

namespace FileHandlingProgram
{
    public partial class FileHandlingProgramForm : Form
    {
        //public static long serialNumber = 1;
        public static long nextSerialNumber = 1;
        public static bool BoolNewButton=false;
        public static bool BoolUpdateButton = false;
        public static bool BoolDeleteButton = false;
        public static bool RowHeaderSelected = false;
        private DataRowView SelectedRowData = null;
        private int SelectedRowIndex = -1;
        private long serialNumberToDelete;
        public static long serialNumberForUpdation;
        public static long serialNumberForRowData;


        public FileHandlingProgramForm()
        {
            InitializeComponent();

            PopulateDataGridView();
            
        }


        private const string FilePath = @"E:\FileHandlingProgram.txt";
        private const char FieldDelimiter = '|';
        private const int FieldsPerRecord = 10;

        public static long GetNextSerialNumber()
        {
            //long nextSerialNumber = 1; // Default value if no records exist

            if (File.Exists(FilePath))
            {
                try
                {
                    // Read the entire file content
                    string fileContent = File.ReadAllText(FilePath);

                    // Split the content by the delimiter
                    string[] fields = fileContent.Split(FieldDelimiter);

                    // Calculate the number of records
                    int recordCount = fields.Length / FieldsPerRecord;

                    // The last serial number + 1 is the next serial number
                    nextSerialNumber = recordCount + 1;
                }
                catch (IOException ex)
                {
                    Console.WriteLine($"An error occurred while reading from the file: {ex.Message}");
                }
            }

            return nextSerialNumber;
        }

        private void NewButton_Click(object sender, EventArgs e)
        {
            BoolNewButton = true;
            RowDataForm rowDataForm = new RowDataForm(false);

            if (rowDataForm.ShowDialog() == DialogResult.OK)
            {
                GetNextSerialNumber();
            }
        }

        private void dataGridView1_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dataGridView1.Rows.Count - 1) 
            {
               DataRowView selectedRow = (DataRowView)dataGridView1.Rows[e.RowIndex].DataBoundItem;
                

                serialNumberForRowData = Convert.ToInt64(dataGridView1.Rows[e.RowIndex].Cells["Sr No."].Value);
                RowDataForm rDataForm = new RowDataForm(serialNumberForRowData,true);
                rDataForm.SetData(selectedRow);
                rDataForm.ShowDialog();
            }
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dataGridView1.Rows.Count - 1)
            {
                SelectedRowData = (DataRowView)dataGridView1.Rows[e.RowIndex].DataBoundItem;
                SelectedRowIndex = e.RowIndex;
                serialNumberToDelete = Convert.ToInt64(dataGridView1.Rows[e.RowIndex].Cells["Sr No."].Value);
                serialNumberForUpdation = Convert.ToInt64(dataGridView1.Rows[e.RowIndex].Cells["Sr No."].Value);
                RowHeaderSelected = true;
            }
        }




        public void PopulateDataGridView()
        {

            string filePath = @"E:\FileHandlingProgram.txt";

            if (File.Exists(filePath) && new FileInfo(filePath).Length > 0)
            {
                DataTable dataTable = new DataTable();
                dataTable.Columns.Add("Sr No.");
                dataTable.Columns.Add("Prefix");
                dataTable.Columns.Add("First Name");
                dataTable.Columns.Add("Middle Name");
                dataTable.Columns.Add("Last Name");
                dataTable.Columns.Add("Qualification");
                dataTable.Columns.Add("Joining Date");
                dataTable.Columns.Add("Current Company");
                dataTable.Columns.Add("Current Address");
                dataTable.Columns.Add("Date Of Birth");

                try
                {
                    using (StreamReader reader = new StreamReader(filePath))
                    {
                        string line;
                        while ((line = reader.ReadLine()) != null)
                        {
                            string[] records = line.Split('|');

                            for (int i = 0; i < records.Length; i += 10) // Assuming each record has 10 fields
                            {
                                if (i + 10 <= records.Length) // Ensure enough fields for a complete record
                                {
                                    string[] fields = new string[10];
                                    Array.Copy(records, i, fields, 0, 10); // Copy 10 fields to a new array
                                    dataTable.Rows.Add(fields);
                                }
                                else
                                {
                                    Console.WriteLine("Invalid data format: Incomplete record found.");
                                }
                            }
                        }
                    }
                }
                catch (IOException ex)
                {
                    Console.WriteLine($"An error occurred while reading from the file: {ex.Message}");
                }

                dataGridView1.DataSource = dataTable;
            }
        }


        public void RefreshMainForm()
        {
            PopulateDataGridView();
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            BoolUpdateButton = true;
            // Check if a row is selected for editing
            if (RowHeaderSelected && SelectedRowData != null)
            {
                // Create an instance of RowDataForm and pass the serial number to update
                RowDataForm rowDataForm = new RowDataForm(false, serialNumberForUpdation);
                rowDataForm.SetData(SelectedRowData); // Set data to the form
                rowDataForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please select a row before clicking Update.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            BoolDeleteButton = true;
            // Check if a SerialNumber is selected for deletion
            if (serialNumberToDelete != 0)
            {
                // Call the method to delete the record by SerialNumber
                DeleteRecordBySerialNumber(serialNumberToDelete);

                // Reset the SerialNumberToDelete after deletion
                serialNumberToDelete = 0;
            }
            else
            {
                MessageBox.Show("Please select a row to delete.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void DeleteRecordBySerialNumber(long serialNumber)
        {
            string filePath = @"E:\FileHandlingProgram.txt";

            try
            {
                string fileContent = File.ReadAllText(filePath);
                string[] records = fileContent.Split('|');

                bool recordDeleted = false;
                for (int i = 0; i < records.Length; i += 10) // Assuming each record has 10 fields
                {
                    if (i + 10 <= records.Length)
                    {
                        if (long.TryParse(records[i], out long recordSerialNumber) && recordSerialNumber == serialNumber)
                        {
                            // Remove the record along with its delimiters
                            Array.Clear(records, i, 10);
                            for (int j = i; j < i + 9; j++)
                            {
                                records[j] = null;
                            }
                            recordDeleted = true;
                            break;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Invalid data format: Incomplete record found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                if (!recordDeleted)
                {
                    MessageBox.Show("Record not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Write the modified content back to the file
                File.WriteAllText(filePath, string.Join("|", records.Where(r => r != null)));

                // Refresh DataGridView
                PopulateDataGridView();
            }
            catch (IOException ex)
            {
                MessageBox.Show($"An error occurred while deleting the record: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }





    }
}
