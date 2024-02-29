using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace FHP
{
    public partial class Form1 : Form
    {


        public static int serialNum = 1;
        public Form1()
        {
            InitializeComponent();
            LoadDataIntoGridView();
        }

        public List<Record> records;
        public void LoadDataIntoGridView()
        {
            dataGridView1.Rows.Clear();
            string filePath  = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "records.bin");

            RecordFileManager recordFileManager = new RecordFileManager(filePath);
            records = recordFileManager.ReadAllRecords();                   // Fetch all records from the file
            dataGridView1.Rows.AddRange(records.Select(record => CreateDataGridViewRow(record)).ToArray());
            dataGridView1.Refresh();
        }

        private DataGridViewRow CreateDataGridViewRow(Record record)
        {
            DataGridViewRow row = new DataGridViewRow();
            row.CreateCells(dataGridView1);

            // Set cell values based on your column names
            row.Cells[0].Value = record.SrNo;
            row.Cells[1].Value = record.Prefix;
            row.Cells[2].Value = record.FirstName;
            row.Cells[3].Value = record.MiddleName;
            row.Cells[4].Value = record.LastName;
            row.Cells[5].Value = record.DOB.ToString("dd-MM-yyyy");
            row.Cells[6].Value = record.Qualification;
            row.Cells[7].Value = record.CurrentAddress;
            row.Cells[8].Value = record.CurrentCompany;
            row.Cells[9].Value = record.DOJ.ToString("dd-MM-yyyy");

            return row;
        }

        private void dataGridView1_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int rowIndex = e.RowIndex;
            if (rowIndex < dataGridView1.RowCount - 1)
            {
                ViewDataForm viewForm = new ViewDataForm(rowIndex, records);
                viewForm.ShowDialog();
            }
            else
            {
                if (dataGridView1.Rows.Count - 2 >= 0)
                {
                    object cellValue = dataGridView1.Rows[dataGridView1.Rows.Count - 2].Cells["SrNo"].Value;   //    set  serialnum
                    if (cellValue != null && int.TryParse(cellValue.ToString(), out int lastSrNo))
                    {
                        serialNum = Math.Max(dataGridView1.RowCount, lastSrNo);
                        if (lastSrNo >= dataGridView1.RowCount)
                        {
                            serialNum = serialNum + 1;
                        }
                    }
                    else
                    {
                        serialNum = dataGridView1.RowCount;
                    }
                }



                UpdateDataForm dataUpdateForm = new UpdateDataForm();
                dataUpdateForm.Edit.Enabled = false;
                dataUpdateForm.ShowDialog();
                LoadDataIntoGridView();
            }

        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int rowIndex = e.RowIndex;
            if (rowIndex == dataGridView1.Rows.Count - 1)
            {
                Add.Enabled = true;
                Update.Enabled = false;
                Delete.Enabled = false;
            }
            else
            {
                Add.Enabled = false;
                Update.Enabled = true;
                Delete.Enabled = true;
            }
        }


        private void Add_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count - 2 >= 0)
            {
                object cellValue = dataGridView1.Rows[dataGridView1.Rows.Count - 2].Cells["SrNo"].Value;   //    set  serialnum
                if (cellValue != null && int.TryParse(cellValue.ToString(), out int lastSrNo))
                {
                    serialNum = Math.Max(dataGridView1.RowCount, lastSrNo);
                    if (lastSrNo >= dataGridView1.RowCount)
                    {
                        serialNum = serialNum + 1;
                    }
                }
                else
                {
                    serialNum = dataGridView1.RowCount;
                }
            }

            UpdateDataForm dataUpdateForm = new UpdateDataForm();
            dataUpdateForm.Edit.Enabled = false;
            dataUpdateForm.ShowDialog();
            LoadDataIntoGridView();

        }

        private void Update_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                // Extract data from the selected row
                long id = Convert.ToInt64(selectedRow.Cells["SrNo"].Value);
                Record recordToUpdate = records.FirstOrDefault(record => record.SrNo == id);
                UpdateDataForm dataUpdateForm = new UpdateDataForm();
                DisplayRecord(recordToUpdate);
                dataUpdateForm.ShowDialog();
                LoadDataIntoGridView();

                void DisplayRecord(Record record)
                {
                    dataUpdateForm.Add.Enabled = false;
                    dataUpdateForm.SrNoText.Text = record.SrNo.ToString();
                    dataUpdateForm.FirstNameText.Text = record.FirstName;
                    dataUpdateForm.MiddleNameText.Text = record.MiddleName;
                    dataUpdateForm.LastNameText.Text = record.LastName;
                    dataUpdateForm.PrifixText.Text = record.Prefix;
                    dataUpdateForm.CurrentAddressText.Text = record.CurrentAddress;
                    dataUpdateForm.CurrentCompanyText.Text = record.CurrentCompany;
                    dataUpdateForm.DOBPicker1.Text = record.DOB.ToString();
                    dataUpdateForm.DOJPicker1.Text = record.DOB.ToString();
                    dataUpdateForm.QualificationcomboBox1.Text = record.Qualification.ToString();
                }
            }
        }

        private void UpdateFile()
        {
            string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "records.bin");

            RecordFileManager recordFileManager = new RecordFileManager(filePath);
            File.WriteAllText(filePath, string.Empty);
            foreach (var record in records)
            {
                recordFileManager.AddRecord(record);
            }
            MessageBox.Show("Record deleted successfully.");
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to Delete Row Data?", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (result == DialogResult.OK)
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                    
                    long id = Convert.ToInt64(selectedRow.Cells["SrNo"].Value);
                    
                    dataGridView1.Rows.Remove(selectedRow);
                    
                    Record recordToRemove = records.FirstOrDefault(record => record.SrNo == id);
                    if (recordToRemove != null)
                    {
                        records.Remove(recordToRemove);
                        UpdateFile();
                    }
                    else
                    {
                        MessageBox.Show("Record not found in the list.");
                    }
                }
                else
                {
                    MessageBox.Show("Please select a row to delete.");
                }
            }


        }

     

    }
}
