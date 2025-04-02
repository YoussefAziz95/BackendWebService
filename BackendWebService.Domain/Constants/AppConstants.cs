namespace Domain.Constants
{
    public static class AppConstants
    {
        public const string Permission = "Permission";

        public const string roles = "roles";

        public const string descending = "descending";

        public const string ascending = "ascending";

        public static string BaseUrl = "https://localhost:7197/";
        /// <summary>
        /// wwwroot constant.
        /// </summary>
        public static string WWWRoot = "wwwroot\\";

        public static string downloadfile = "C:\\Temp\\";

        /// <summary>
        /// Image upload path constant.
        /// </summary>
        public static string ImgUploadPath = "C:\\Images";

        /// <summary>
        /// Temporary upload path constant.
        /// </summary>
        public static string TempUploadPath = "C:\\Temp";

        /// <summary>
        /// Allowed extensions for files.
        /// </summary>
        public static string FileAllowedExtensions = "image/png";

        /// <summary>
        /// Maximum allowed size for files.
        /// </summary>
        public static int FileMaxAllowedSize = 1024 * 1024 * 5;

        /// <summary>
        /// Customer OTP type constant.
        /// </summary>
        public static string UserOtpType = "Claims.IsOtpVerified";

        /// <summary>
        /// Allowed extensions for documents.
        /// </summary>
        public static string DocumentAllowedExtensions = "application/pdf";

        /// <summary>
        /// Allowed extensions for images.
        /// </summary>
        public static string ImageAllowedExtensions = "image/png";

        /// <summary>
        /// Maximum allowed size for documents.
        /// </summary>
        public static int DocumentMaxAllowedSize = 1024 * 1024 * 5;

        /// <summary>
        /// Maximum allowed size for images.
        /// </summary>
        public static int ImageMaxAllowedSize = 1024 * 1024 * 1;

        /// <summary>
        /// Offer upload path constant.
        /// </summary>
        public static string OfferUploadPath = "C:\\IntCafeWeb";

        public static string wwwroot = "wwwroot\\";

    }
}