using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FHP.VO;
using FHP.BL;
using FHP.RES;

namespace FHP.UI
{
    public partial class UserAuthentication : Form
    {


        UserValidationBL validatUser;
        UserVO user;
        bool IsUserExist;

        public UserAuthentication(UserVO currentUser, UserValidationBL validate)
        {
            InitializeComponent();
            LoadUserRoleEnum();
            this.FormClosing += UserAuthentication_FormClosing;
            //PasswordTextbox.UseSystemPasswordChar = true;
            //UserNameTextbox.UseSystemPasswordChar = true;
            validatUser = validate;
            user = currentUser;
        }

        private void LoadUserRoleEnum()
        {
            Array values = Enum.GetValues(typeof(Education_Level.UserRole));
            userTypeComboBox.DataSource = values;
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            user.UserName = UserNameTextbox.Text;
            user.Password = PasswordTextbox.Text;
            user.UserRole = userTypeComboBox.SelectedItem.ToString();

            IsUserExist = validatUser.isUserPresent(user);
            if (IsUserExist)
            {
                this.Close();
            }
            else
            {
                MessageBox.Show("invalid User");
                user.ErrorMessage = string.Empty;
            }
        }
        
        private void UserAuthentication_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!IsUserExist)
            {
                DialogResult result = MessageBox.Show("Are you want to Exit?", "Exit", MessageBoxButtons.YesNo);
                if (result == DialogResult.No)
                {
                    e.Cancel = true;
                }
                else
                {
                    Application.Exit();
                }
            }
        }



    }
}
