namespace Application.DTOs.Auth.Response
{
    /// <summary>
    /// Represents the response object for authentication operations.
    /// </summary>
    public class AuthResponse
    {

        public int? OrganizationId { get; set; }
        public int? CompanyId { get; set; }
        public int? SupplierAccountId { get; set; }
        public int RoleId { get; set; }
        public string OrganizationType { get; set; }
        public string Username { get; set; }
        public int UserId { get; set; }
        public int? GroupId { get; set; }

        /// <summary>
        /// Gets or sets the ID of the Supplier.
        /// </summary>
        public int? SupplierId { get; set; }


        /// <summary>
        /// Gets or sets a value indicating whether the user is authenticated.
        /// </summary>
        public bool IsAuthenticated { get; set; }


        /// <summary>
        /// Gets or sets the email address of the user.
        /// </summary>
        public string? Email { get; set; }

        /// <summary>
        /// Gets or sets the roles assigned to the user.
        /// </summary>
        public List<string>? Roles { get; set; }

        /// <summary>
        /// Gets or sets the authentication token.
        /// </summary>
        public string? Token { get; set; }

        /// <summary>
        /// Gets or sets the expiration date and time of the authentication token.
        /// </summary>
        public DateTime? ExpiresOn { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the user has OTP (One-Time Password) authentication enabled.
        /// </summary>
        public bool HasOtp { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the OTP verification is successful.
        /// </summary>
        public bool IsOtpVerfied { get; set; }

        /// <summary>
        /// Gets or sets the refresh token used for token refresh.
        /// </summary>
        public string? RefreshToken { get; set; }

        /// <summary>
        /// Gets or sets the expiration date and time of the refresh token.
        /// </summary>
        public DateTime RefreshTokenExpiration { get; set; }

        /// <summary>
        /// Gets or sets the ID of the user type.
        /// </summary>
        public string? MainRole { get; set; }
    }
}
