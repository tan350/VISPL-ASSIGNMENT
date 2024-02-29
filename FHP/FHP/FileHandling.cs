using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FHP
{
    internal class FileHandling
    {
    }

    public enum EducationLevel : byte
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

    public class Record
    {
        public long SrNo { get; set; }
        public string Prefix { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public DateTime DOB { get; set; }
        public string Qualification { get; set; }
        public string CurrentAddress { get; set; }
        public string CurrentCompany { get; set; }
        public DateTime DOJ { get; set; }

        public override string ToString()
        {
            // Convert the record to a flat string representation
            return $"{SrNo}^{Prefix}^{FirstName}^{MiddleName}^{LastName}^{DOB}^{CurrentAddress}^{CurrentCompany}^{DOJ}^{Qualification}";
        }
    }



    public class RecordFileManager
    {
        private string filePath;
        public RecordFileManager(string filePath)
        {
            this.filePath = filePath;
            
            if (!File.Exists(filePath))
            {
                using (StreamWriter sw = File.CreateText(filePath))
                {

                }
            }
        }


        /*    public void AddRecord(Record record)
            {
                try
                {
                    using (FileStream fileStream = new FileStream(filePath, FileMode.Append))
                    using (BinaryWriter writer = new BinaryWriter(fileStream))
                    {
                        writer.Write(record.SrNo);
                        writer.Write(record.Prefix);
                        writer.Write(record.FirstName);
                        writer.Write(record.MiddleName);
                        writer.Write(record.LastName);
                        writer.Write(record.DOB.Ticks); // Writing ticks for DateTime
                        writer.Write(record.CurrentAddress);
                        writer.Write(record.CurrentCompany);
                        writer.Write(record.DOJ.Ticks); // Writing ticks for DateTime
                        writer.Write(record.Qualification); // Writing enum as byte
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error writing to file: {ex.Message}");
                }
            }*/

        /*   public List<Record> ReadAllRecords()
           {
               List<Record> records = new List<Record>();

               try
               {
                   using (FileStream fileStream = new FileStream(filePath, FileMode.Open))
                   using (BinaryReader reader = new BinaryReader(fileStream))
                   {
                       while (fileStream.Position < fileStream.Length)
                       {
                           Record record = new Record
                           {
                               SrNo = reader.ReadInt64(),
                               Prefix = reader.ReadString(),
                               FirstName = reader.ReadString(),
                               MiddleName = reader.ReadString(),
                               LastName = reader.ReadString(),
                               DOB = new DateTime(reader.ReadInt64()), // Reading ticks for DateTime
                               CurrentAddress = reader.ReadString(),
                               CurrentCompany = reader.ReadString(),
                               DOJ = new DateTime(reader.ReadInt64()), // Reading ticks for DateTime
                               Qualification = reader.ReadString() // Reading enum as byte
                           };

                           records.Add(record);
                       }
                   }
               }
               catch (Exception ex)
               {
                   Console.WriteLine($"Error reading from file: {ex.Message}");
               }

               return records;
           }*/


        

        //Add Record in Flat File
        public void AddRecord(Record record)
        {
            try
            {
                using (StreamWriter sw = File.AppendText(filePath))
                {
                    sw.Write("[" + record.ToString() + "]");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error writing to file: {ex.Message}");
            }
        }


        //Read All Records From Flat File
        public List<Record> ReadAllRecords()
        {
            List<Record> records = new List<Record>();

            try
            {
                string fileContent = File.ReadAllText(filePath);
                string[] recordStrings = fileContent.Split(new string[] { "][" }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string recordString in recordStrings)
                {
                    string cleanedRecordString = recordString.Replace("[", "0").Replace("]", "");
                    string[] values = cleanedRecordString.Split('^');
                    // Ensure that the line has the expected number of fields
                    if (values.Length == 10)
                    {
                        Record record = new Record
                        {
                            SrNo = Convert.ToInt64(values[0]),
                            Prefix = values[1],
                            FirstName = values[2],
                            MiddleName = values[3],
                            LastName = values[4],
                            DOB = DateTime.Parse(values[5]),
                            CurrentAddress = values[6],
                            CurrentCompany = values[7],
                            DOJ = DateTime.Parse(values[8]),
                            Qualification = (values[9])
                        };
                        records.Add(record);
                    }

                    else
                    {
                        Console.WriteLine($"Invalid line format: {recordString}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading from file: {ex.Message}");
            }
            return records;
        }

        //Update Record in Flat File
        public void UpdateRecord(long srNo, Record updatedRecord)
        {
            try
            {
                List<Record> allRecords = ReadAllRecords();

                int index = allRecords.FindIndex(record => record.SrNo == srNo);

                if (index != -1)
                {
                    allRecords[index] = updatedRecord;

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
