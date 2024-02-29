using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using FHP.VO;
using FHP.RES;
using System.Runtime.InteropServices;

namespace FHP.DL
{
    public class FileHandlingDL
    {

        FileInfoRES file = new FileInfoRES();
        
        public void AddRecord(RecordVO record)
        {
            try
            {
                byte[] recordBytes = record.ToBytes();
                string filePath = file.FilePath();
                using (FileStream fileStream = new FileStream(filePath, FileMode.Append, FileAccess.Write))
                {
                    fileStream.Write(recordBytes, 0, recordBytes.Length);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error writing to file: {ex.Message}");
            }
        }

        public List<RecordVO> ReadAllRecords()
        {
            List<RecordVO> records = new List<RecordVO>();

            try
            {
                string filePath = file.FilePath();
                byte[] fileBytes = File.ReadAllBytes(filePath);

                for (int i = 0; i < fileBytes.Length; i += Marshal.SizeOf<RecordVO>())
                {
                    byte[] recordBytes = new byte[Marshal.SizeOf<RecordVO>()];
                    Array.Copy(fileBytes, i, recordBytes, 0, Marshal.SizeOf<RecordVO>());

                    RecordVO record = RecordVO.FromBytes(recordBytes);
                    records.Add(record);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading from file: {ex.Message}");
            }
            return records;
        }

        public void UpdateRecord(long srNo, RecordVO updatedRecord)
        {
            try
            {
                List<RecordVO> allRecords = ReadAllRecords();

                int index = allRecords.FindIndex(record => record.SrNo == srNo);

                if (index != -1)
                {
                    allRecords[index] = updatedRecord;
                    string filePath = file.FilePath();
                    File.WriteAllText(filePath, string.Empty);

                    foreach (var record in allRecords)
                    {
                        AddRecord(record);
                    }
                }
                else
                {
                    Console.WriteLine($"Record with SrNo {srNo} not found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating record: {ex.Message}");
            }
        }


    }

}
