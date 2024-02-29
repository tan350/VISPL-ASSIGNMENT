using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FHP.RES
{
    public class FileRES
    {
        static string directoryPath = Directory.GetCurrentDirectory();
        const string fileName = "Data1.bin";

        public string FilePath()
        {
            string filePath = Path.Combine(directoryPath, fileName);
            try
            {
                if (!File.Exists(filePath))
                {
                    // If the file does not exist, create it
                    using (FileStream fs = File.Create(filePath))
                    {
                        //you can write initial content to the file if needed
                    }
                }
                return filePath;

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error checking/creating file: {ex.Message}");
                return null;
            }
        }
    }
}
