using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FHP.RES
{
    public class FileInfoRES
    {
        static string directoryPath = Directory.GetCurrentDirectory();
        const string fileName = "Records.bin";

        public string FilePath()
        {
            string filePath = Path.Combine(directoryPath, fileName);
            try
            {
                if (!File.Exists(filePath))
                {
                    using (FileStream fs = File.Create(filePath))
                    {
                        //you can write initial content to the file if needed
                    }
                }
                return filePath;

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in checking existing/creating file: {ex.Message}");
                return null;
            }
        }
    }
}
