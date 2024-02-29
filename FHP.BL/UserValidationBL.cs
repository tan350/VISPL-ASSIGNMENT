using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FHP.DL;
using FHP.VO;

namespace FHP.BL
{
    public class UserValidationBL
    {

        UserInfoHandlingDL readUser;
        public UserValidationBL()
        {
            readUser = new UserInfoHandlingDL();
        }

        private bool SetUserRole(UserVO user)
        {
            readUser.setvalue(user);

            if (user.ErrorMessage.Length > 0)
            {
                return false;
            }
            GetUserPermission(user);
            return true;
        }

        public bool isUserPresent(UserVO user)
        {
            return SetUserRole(user);
        }

        public Dictionary<string, bool> GetUserPermission(UserVO user)
        {
            Dictionary<string, bool> permissions = new Dictionary<string, bool>();

            permissions.Add("CanDownGrade", false);
            permissions.Add("CanEdit", false);
            permissions.Add("CanDelete", false);
            permissions.Add("CanRead", false);
            permissions.Add("CanUpdate", false);
            permissions.Add("CanCreateUsers", false);


            if (user.UserName == "SUPERADMIN")
            {
                permissions["CanDownGrade"] = true;
                permissions["CanEdit"] = true;
                permissions["CanDelete"] = true;
                permissions["CanRead"] = true;
                permissions["CanUpdate"] = true;
                permissions["CanCreateUsers"] = true;
            }

            else if (user.UserName == "ADMIN")
            {
                permissions["CanDownGrade"] = true;
                permissions["CanEdit"] = true;
                permissions["CanDelete"] = true;
                permissions["CanRead"] = true;
                permissions["CanUpdate"] = true;
            }

            else if (user.UserName == "GUEST")
            {
                permissions["CanRead"] = true;
            }

            else if (user.UserName == "SELF")
            {
                permissions["CanEdit"] = true;
                permissions["CanDelete"] = true;
                permissions["CanRead"] = true;
                permissions["CanUpdate"] = true;
            }

            return permissions;
        }


    }
}
