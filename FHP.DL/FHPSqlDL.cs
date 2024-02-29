using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FHP.VO;

namespace FHP.DL
{
    public class FHPSqlDL
    {
        public FHPSqlDL()
        { 
            string connectionString= @"Data Source=UPLC; Database = FHPDatabase; Integrated Security=True;TrustServerCertificate=True";
            string queryString = "SELECT* FROM Employee;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                List<RecordVO> RecordList = new List<RecordVO>();
                while (reader.Read())
                {
                    RecordVO record = new RecordVO();
                    record.SrNo = Convert.ToInt32(reader["SrNo"]);
                    record.Prefix = reader["Prefix"].ToString();
                    record.FirstName = reader["FirstName"].ToString();
                    record.MiddleName = reader["MiddleName"].ToString();
                    record.LastName = reader["LastName"].ToString();
                    record.Qualification = reader["Qualification"].ToString();
                    record.DOJ = Convert.ToDateTime(reader["DOJ"]);
                    record.CurrentCompany = reader["CurrentCompany"].ToString();
                    record.CurrentAddress = reader["CurrentAddress"].ToString();
                    record.DOB = Convert.ToDateTime(reader["DOB"]);
                    RecordList.Add(record);
                }

                reader.Close();
            }
        }
    }
}
