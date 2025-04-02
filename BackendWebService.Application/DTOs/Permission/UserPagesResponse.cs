namespace Application.DTOs.Permission
{
    /// <summary>
    /// Represents a response model for user pages.
    /// </summary>
    public class UserPagesResponse
    {
        public int id {  get; set; }
        /// <summary>
        /// Gets or sets the Groups menu associated with the user page.
        /// </summary>
        public string? Groups { get; set; }
        /// <summary>
        /// Gets or sets the menu associated with the user page.
        /// </summary>
        public string? menu { get; set; }

        /// <summary>
        /// Gets or sets the page associated with the user page.
        /// </summary>
        public string? page { get; set; }

        /// <summary>
        /// Gets or sets the permission associated with the user page.
        /// </summary>
        public string? permission { get; set; }
    }
}
