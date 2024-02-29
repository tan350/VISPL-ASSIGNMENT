using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using FHP.RES;
using FHP.VO;
using FHP.DL;


namespace FHP.BL
{
    public class ValidationBL
    {
        Education_Level msg = new Education_Level();   

        FileHandlingDL recordFileManager = new FileHandlingDL();  


        public bool CheckRecorddata(RecordVO employeeData, ref byte enumindex)
        {
            if (string.IsNullOrEmpty(employeeData.FirstName))
            {
                Education_Level.Message ValidationMessage = Education_Level.Message.FirstNameEmpty;
                enumindex = msg.GetValidationMessageAsByte(ValidationMessage);
                return false;
            }
            else if (string.IsNullOrEmpty(employeeData.DOJ.ToString()))
            {
                Education_Level.Message ValidationMessage = Education_Level.Message.DOJEmpty;
                enumindex = msg.GetValidationMessageAsByte(ValidationMessage);
                return false;
            }
            else if (string.IsNullOrEmpty(employeeData.CurrentCompany))
            {
                Education_Level.Message ValidationMessage = Education_Level.Message.CurrentCompanyEmpty;
                enumindex = msg.GetValidationMessageAsByte(ValidationMessage);
                return false;
            }

            else
            {
                return true;
            }
        }

        public void AddData(RecordVO employeeData)
        {
            recordFileManager.AddRecord(employeeData);
        }

        public void UpdateData(long SrNo, RecordVO employeeData)
        {
            recordFileManager.UpdateRecord(SrNo, employeeData);
        }

        public List<RecordVO> ReadAllRecordsData()
        {
            return recordFileManager.ReadAllRecords();
        }


    }

}
