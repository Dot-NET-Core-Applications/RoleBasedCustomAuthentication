using System;
using System.Collections.Generic;


namespace RoleBasedCustomAuthentication.Models
{
    public class UserCredential
    {
        /// <summary>
        /// User Name.
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Password.
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// User Roles.
        /// </summary>
        public IList<string> Roles { get; set; }
    }
}
