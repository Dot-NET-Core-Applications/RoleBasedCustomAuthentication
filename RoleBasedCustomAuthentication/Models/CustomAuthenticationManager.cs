using System;
using System.Linq;
using System.Collections.Generic;


namespace RoleBasedCustomAuthentication.Models
{
    public class CustomAuthenticationManager : ICustomAuthenticationManager
    {
        // <summary>
        /// List of user credentials.
        /// </summary>
        private readonly IList<UserCredential> users;

        /// <summary>
        /// Dictionary mapping of tokens with usernames.
        /// </summary>
        private readonly IDictionary<string, UserCredential> tokens;

        public IDictionary<string, UserCredential> Tokens => tokens;

        /// <summary>
        /// Instance of CustomAuthenticationManager.
        /// </summary>
        /// <param name="users">Dictionary of users.</param>
        /// <param name="tokens">Mapping list of tokens to usernames.</param>
        public CustomAuthenticationManager(IList<UserCredential> users, IDictionary<string, UserCredential> tokens)
        {
            this.users = users;
            this.tokens = tokens;
        }

        /// <summary>
        /// Authenticate user.
        /// </summary>
        /// <param name="username">Username.</param>
        /// <param name="password">Password.</param>
        /// <returns>Custom token string.</returns>
        public string Authenticate(string username, string password)
        {
            if (users.Any<UserCredential>(user => user.UserName.Equals(username) && user.Password.Equals(password)))
            {
                var token = Guid.NewGuid().ToString();
                UserCredential user = users.FirstOrDefault<UserCredential>(user =>
                    user.UserName.Equals(username) && user.Password.Equals(password));
                tokens.Add(token, user);
                return token;
            }
            return default;
        }
    }
}
