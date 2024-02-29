using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FHP.VO
{
    public class ValidationObjectsVO
    {
        public List<RecordVO> EmpList { get; set; }
        public bool IsDelete { get; set; } = false;
        public RecordVO employee { get; set; }

        public UserVO user { get; set; }

        public ValidationObjectsVO()
        {
            user = new UserVO();
        }
    }
}
