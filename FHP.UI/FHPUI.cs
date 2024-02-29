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
using FHP.VO;
using FHP.BL;
using FHP.RES;

namespace FHP.UI
{
    public partial class FHPUIForm : Form
    {
        ValidationBL entityHandle;
        FileInfoRES file;
        public string filePath;
        UserValidationBL validate;
        UserAuthentication userValidationForm;
        AboutUs aboutUsForm;
        UserVO currentUser;
        ValidationObjectsVO vo;

        public static int serialNum = 1;

        Dictionary<string, bool> currentUserPermissions;
        public FHPUIForm()
        {
            vo = new ValidationObjectsVO();
            currentUser = new UserVO();
            validate = new UserValidationBL();
            userValidationForm = new UserAuthentication(currentUser, validate);
            userValidationForm.ShowDialog();

            userValidationForm = new UserAuthentication(currentUser, validate);
            entityHandle = new ValidationBL();
            file = new FileInfoRES();
            aboutUsForm = new AboutUs();
            filePath = file.FilePath();
            currentUserPermissions = validate.GetUserPermission(currentUser);
            InitializeComponent();
            foreach (var kvp in currentUserPermissions)
            {
                string key = kvp.Key;
                bool havePermission = currentUserPermissions[key];
                if (currentUser.UserRole == "SuperAdmin")
                {

                }
                if (currentUser.UserRole == "Admin")
                {

                }
                if (currentUser.UserRole == "Guest")
                {
                    UpdateItem.Visible = false;
                    DeleteItem.Visible = false;
                    NewItem.Visible = false;
                }
                if (currentUser.UserRole == "Self")
                {

                }


            }
            LoadDataIntoGridView();
            dataGridView1.RowHeaderMouseClick += dataGridView1_RowHeaderMouseClick;
            dataGridView1.RowHeaderMouseDoubleClick += dataGridView1_RowHeaderMouseDoubleClick;

        }

        private void NewItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count - 2 >= 0)
            {
                object cellValue = dataGridView1.Rows[dataGridView1.Rows.Count - 2].Cells["SrNumber"].Value;   //    set  serialnum
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

        private void UpdateItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0 && dataGridView1.SelectedRows[0].Index > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                
                long id = Convert.ToInt64(selectedRow.Cells["SrNumber"].Value);
                RecordVO recordToUpdate = records.FirstOrDefault(record => record.SrNo == id);
                UpdateDataForm dataUpdateForm = new UpdateDataForm();
                DisplayRecord(recordToUpdate);
                dataUpdateForm.ShowDialog();
                LoadDataIntoGridView();

                void DisplayRecord(RecordVO record)
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

        private void DeleteItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to Delete Row Data?", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (result == DialogResult.OK)
            {
                if (dataGridView1.SelectedRows.Count > 0 && dataGridView1.SelectedRows[0].Index > 0)
                {
                    DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];                                    // Extract data from the selected row
                    long id = Convert.ToInt64(selectedRow.Cells["SrNumber"].Value);                                     // Remove the row from the DataGridView
                    dataGridView1.Rows.Remove(selectedRow);
                    RecordVO recordToRemove = records.FirstOrDefault(record => record.SrNo == id);               // Remove the record from the allRecords list              
                    records.Remove(recordToRemove);
                    UpdateFile();

                }
                else
                {
                    MessageBox.Show("Please select a row to delete.");
                }
            }
        }

        private void ClearSearchItem_Click(object sender, EventArgs e)
        {
            LoadDataIntoGridView();
        }

        private void ViewItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int rowIndex = dataGridView1.SelectedRows[0].Index;
                HandleRowDoubleClick(rowIndex);
            }
        }

        private void ExitItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to exit the application?", "Exit Application", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Environment.Exit(0);
            }
        }

        private void AboutUsItem_Click(object sender, EventArgs e)
        {

            aboutUsForm.ShowDialog();
            LoadDataIntoGridView();
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            string searchText = SearchTextbox.Text;
            LoadDataIntoGridView1(ApplyFilterForAll(searchText));
        }

        public void LoadDataIntoGridView1(List<RecordVO> filterrecord)
        {
            for (int rowIdx = dataGridView1.Rows.Count - 2; rowIdx > 0; rowIdx--)
            {
                dataGridView1.Rows.RemoveAt(rowIdx);
            }

            dataGridView1.RowCount = 2;
            dataGridView1.Rows.AddRange(filterrecord.Select(record => CreateDataGridViewRow(record)).ToArray());

        }
        
        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == 0 && e.ColumnIndex >= 0)
            {
                string changedColumnName = dataGridView1.Columns[e.ColumnIndex].Name;
                filterRecord = ApplyFilterForColumn(dataGridView1.Rows[0].Cells[e.ColumnIndex].Value?.ToString(), changedColumnName);
                LoadDataIntoGridView1(filterRecord);
            }
        }

        private List<RecordVO> ApplyFilterForColumn(string filterText, string columnName)
        {

            if (columnName == "SrNumber")
            {
                if (string.IsNullOrEmpty(filterText))
                {
                    return filterRecord;
                }
                else
                {
                    return filterRecord.Where(t => t.SrNo == long.Parse(filterText)).ToList();
                }
            }
            else if (columnName == "Prefix")
            {
                return filterRecord.Where(t => t.Prefix.Contains(filterText)).ToList();
            }
            else if (columnName == "FirstName")
            {
                return filterRecord.Where(t => t.FirstName.Contains(filterText)).ToList();
            }
            else if (columnName == "MiddleName")
            {
                return filterRecord.Where(t => t.MiddleName.Contains(filterText)).ToList();
            }
            else if (columnName == "Lastname")
            {
                return filterRecord.Where(t => t.LastName.Contains(filterText)).ToList();
            }
            /*else if (columnName == "DOB")
            {
                return filterRecord.Where(t => t.DOB.Contains(filterText)).ToList();
            }*/
            else if (columnName == "CurrentAddress")
            {
                return filterRecord.Where(t => t.CurrentAddress.Contains(filterText)).ToList();
            }
            else if (columnName == "CurrentCompany")
            {
                return filterRecord.Where(t => t.CurrentCompany.Contains(filterText)).ToList();
            }
            /* else if (columnName == "Qualification")
             {
                 return filterRecord.Where(t => t.Qualification.Contains(filterText)).ToList();
             }*/
            else
            {
                return null;
            }
        }

        public List<RecordVO> records;   
        List<RecordVO> filterRecord;     
        
        public void LoadDataIntoGridView()
        {
            dataGridView1.Rows.Clear();
            records = entityHandle.ReadAllRecordsData();
            filterRecord = records;
            dataGridView1.RowCount = 2;
            dataGridView1.Rows.AddRange(records.Select(record => CreateDataGridViewRow(record)).ToArray());
            for (int row = 1; row < records.Count; row++)
            {
                dataGridView1.Rows[row].ReadOnly = true;
            }
            dataGridView1.Refresh();
        }

        private DataGridViewRow CreateDataGridViewRow(RecordVO record)
        {
            DataGridViewRow row = new DataGridViewRow();
            row.CreateCells(dataGridView1);

            
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
        
        private void UpdateFile()
        {
            File.WriteAllText(filePath, string.Empty);
            foreach (var record in records)
            {
                entityHandle.AddData(record);
            }
            MessageBox.Show("Record deleted successfully.");
        }

        private void HandleRowDoubleClick(int rowIndex)
        {
            vo.user.ViewMode = true;
            if (rowIndex == 0)
            {
                // Handle case when the first row is double-clicked
            }
            else if (rowIndex < dataGridView1.RowCount - 1)
            {
                // Handle case when a row other than the first or last is double-clicked
                ViewDataForm viewForm = new ViewDataForm(rowIndex - 1, records);
                viewForm.ShowDialog();
            }
            else
            {
                // Handle case when the last row is double-clicked
                int serialNum;
                if (dataGridView1.Rows.Count - 2 >= 0)
                {
                    object cellValue = dataGridView1.Rows[dataGridView1.Rows.Count - 2].Cells["SrNumber"].Value;
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
                else
                {
                    serialNum = 1;
                }

                UpdateDataForm dataUpdateForm = new UpdateDataForm();
                dataUpdateForm.Edit.Enabled = false;
                dataUpdateForm.ShowDialog();
                LoadDataIntoGridView();
            }
        }

        private void dataGridView1_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            HandleRowDoubleClick(e.RowIndex);
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int rowIndex = e.RowIndex;
            if (rowIndex == dataGridView1.Rows.Count - 1)
            {
                NewItem.Enabled = true;
                UpdateItem.Enabled = false;
                DeleteItem.Enabled = false;
            }
            else
            {
                NewItem.Enabled = false;
                UpdateItem.Enabled = true;
                DeleteItem.Enabled = true;
            }
        }

        private List<RecordVO> ApplyFilterForAll(string filterText)
        {
            return records.Where(record =>
        record.Prefix.Contains(filterText) ||
        record.FirstName.Contains(filterText) ||
        record.MiddleName.Contains(filterText) ||
        record.LastName.Contains(filterText) ||
        record.DOB.ToString().Contains(filterText) ||
        record.Qualification.ToString().Contains(filterText) ||
        record.CurrentAddress.Contains(filterText) ||
        record.CurrentCompany.Contains(filterText) ||
        record.DOJ.ToString().Contains(filterText)).ToList();
        }

        
    }
}
