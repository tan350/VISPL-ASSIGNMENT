using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FHP.VO;

namespace FHP.DL
{
    public class UserInfoHandlingDL
    {
        public void setvalue(UserVO user)
        {
            string filePath = "C:\\Users\\user\\source\\repos\\FHPLayered\\FHP.DL\\Resources\\UserInfo.txt";
            List<string> lines = ReadDataFile(filePath);
            bool match = false;
            foreach (var line in lines)
            {
                string[] word = line.Split(' ');
                if (user.UserName == word[0] && user.Password == word[1] && user.UserRole == word[2])
                {
                    match = true;
                }
            }
            if (!match)
            {
                user.ErrorMessage = "Credential not valid";
            }
        }

        public List<string> ReadDataFile(string filePath)
        {
            List<string> lines = new List<string>();

            try
            {
                lines.AddRange(File.ReadAllLines(filePath));
            }
            catch (IOException e)
            {
                Console.WriteLine($"An error occurred while reading the file: {e.Message}");
            }
            return lines;
        }


    }
}
