namespace Application.Model.Jwt
{
    /// <summary>
    /// Represents options for JWT (JSON Web Token) configuration.
    /// </summary>
    public class JwtOptions
    {
        /// <summary>
        /// Gets or sets the required key used to sign the JWT.
        /// </summary>
        public required string Key { get; set; }

        /// <summary>
        /// Gets or sets the required issuer of the JWT.
        /// </summary>
        public required string Issuer { get; set; }

        /// <summary>
        /// Gets or sets the required audience of the JWT.
        /// </summary>
        public required string Audience { get; set; }

        /// <summary>
        /// Gets or sets the duration of validity for the JWT, in hours.
        /// </summary>
        public int DurationInHours { get; set; }
    }
}
