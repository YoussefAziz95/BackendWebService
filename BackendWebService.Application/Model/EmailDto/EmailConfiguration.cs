namespace Application.Model.EmailDto
{
    /// <summary>
    /// Provides configuration settings for sending emails.
    /// </summary>
    public static class EmailConfiguration
    {
        /// <summary>
        /// The email address from which emails are sent.
        /// </summary>
        public static string From = "youssef.ite.user@gmail.com";

        /// <summary>
        /// The password for the email account used for sending emails.
        /// </summary>
        public static string Password = "pfrp szet uboa vlpy";

        /// <summary>
        /// The host address for the email server.
        /// </summary>
        public static string Host = "mail.ipi.gov.eg";

        /// <summary>
        /// The port number for the email server.
        /// </summary>
        public static int Port = 587;

        /// <summary>
        /// The host address for the Gmail SMTP server.
        /// </summary>
        public static string GmailHost = "smtp.gmail.com";

        /// <summary>
        /// The name of the company associated with the email.
        /// </summary>
        public static string CompanyName = "ITE Corp";

        /// <summary>
        /// The name of the sender of the email.
        /// </summary>
        public static string SenderName = "SuperAdmin";

        /// <summary>
        /// Generates an HTML email template with provided content.
        /// </summary>
        /// <param name="recipientName">The name of the recipient.</param>
        /// <param name="content">The content of the email.</param>
        /// <returns>The generated HTML email template.</returns>
        public static string generateTemplate(string recipientName, string content)
        {
            var body = @"<body><div class='email-container'>
                        <div class='header'>
                          <h1>" + CompanyName + @"</h1>
                        </div>    
                        <div class=""content"">
                            <p>Hello " + recipientName + @",</p>
                            <p>" + content + @"</p>
                            <p>Best regards,<br>" + SenderName + @"</p>
                        </div>
                        <div class=""footer"">
                            <p>&copy; 2024 " + CompanyName + @". All rights reserved.</p>
                        </div>";

            var html = @"<!DOCTYPE html><html lang='en'>" + head + body + "</html>";

            return html;
        }

        private static string style = @"<style>
                                        /* Reset some default styles for email compatibility */
                                        body, table, td, a {
                                            font-family: Arial, sans-serif;
                                            font-size: 14px;
                                            line-height: 1.6;
                                            color: #333333;
                                            text-decoration: none;
                                        }

                                        /* Style the email container */
                                        .email-container {
                                            max-width: 600px;
                                            margin: 0 auto;
                                            padding: 20px;
                                        }

                                        /* Style the header */
                                        .header {
                                            background-color: #f2f2f2;
                                            padding: 10px;
                                            text-align: center;
                                        }

                                        /* Style the main content */
                                        .content {
                                            padding: 20px;
                                            background-color: #ffffff;
                                            border: 1px solid #dddddd;
                                        }

                                        /* Style the footer */
                                        .footer {
                                            background-color: #f2f2f2;
                                            padding: 10px;
                                            text-align: center;
                                        }
                                        </style>";

        private static string head = @"<head>
                                      <meta charset='UTF-8'>
                                      <meta name='viewport' content='width=device-width, initial-scale=1.0'>
                                      " + style + @"</head>";
    }
}
