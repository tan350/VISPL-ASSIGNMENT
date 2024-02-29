using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FHP.VO
{
    /// <summary>
    /// Represents a user entity containing user information.
    /// </summary>
    public class UserVO
    {
        /// <summary>
        /// Gets or sets the username of the user.
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Gets or sets the password of the user.
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets the role of the user.
        /// </summary>
        public string UserRole { get; set; }

        /// <summary>
        /// Gets or sets any error message associated with the user.
        /// </summary>
        public string ErrorMessage { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the user is in view mode.
        /// </summary>
        public bool ViewMode { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="UserVO"/> class.
        /// </summary>
        public UserVO()
        {
            // Initialize properties with default values
            UserName = string.Empty;
            Password = string.Empty;
            UserRole = string.Empty;
            ErrorMessage = string.Empty;
            ViewMode = false;
        }
    }
}
