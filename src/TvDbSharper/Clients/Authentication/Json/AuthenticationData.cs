namespace TvDbSharper.Clients.Authentication.Json
{
    /// <summary>
    /// Represents the data required for authentication
    /// </summary>
    public class AuthenticationData
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:TvDbSharper.Clients.Authentication.Json.AuthenticationData" /> class.
        /// </summary>
        /// <param name="apiKey">The ApiKey needed for authentication. Can be generated here: https://thetvdb.com/?tab=apiregister </param>
        /// <param name="username">The Username needed for authentication.</param>
        /// <param name="userKey">The UserKey or Account Identifier found in the account page of your thetvdb.com profile</param>
        public AuthenticationData(string apiKey, string username, string userKey)
        {
            this.ApiKey = apiKey;
            this.Username = username;
            this.UserKey = userKey;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:TvDbSharper.Clients.Authentication.Json.AuthenticationData" /> class.
        /// </summary>
        /// <param name="apiKey">The ApiKey needed for authentication. Can be generated here: https://thetvdb.com/?tab=apiregister </param>
        public AuthenticationData(string apiKey)
        {
            this.ApiKey = apiKey;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:TvDbSharper.Clients.Authentication.Json.AuthenticationData" /> class.
        /// </summary>
        public AuthenticationData()
        {
        }

        /// <summary>
        /// The ApiKey needed for authentication. Can be generated here: https://thetvdb.com/?tab=apiregister
        /// </summary>
        public string ApiKey { get; set; }

        /// <summary>
        /// The UserKey or Account Identifier found in the account page of your thetvdb.com profile
        /// </summary>
        public string UserKey { get; set; }

        /// <summary>
        /// The Username needed for authentication.
        /// </summary>
        public string Username { get; set; }
    }
}