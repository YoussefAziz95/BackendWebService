namespace Application.Model.EmailDto
{
    /// <summary>
    /// Represents an email data transfer object.
    /// </summary>
    public class EmailDto
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EmailDto"/> class.
        /// </summary>
        /// <param name="subject">The subject of the email.</param>
        /// <param name="body">The body of the email.</param>
        /// <param name="to">The recipient of the email.</param>
        /// <param name="cC">The carbon copy recipients of the email.</param>
        /// <param name="bCC">The blind carbon copy recipients of the email.</param>
        public EmailDto(string subject, string body, string to, string cC, string bCC, DateTime sentAt, int senderId)
        {
            Subject = subject;
            Body = body;
            To = to;
            CC = cC;
            BCC = bCC;
            SentAt = sentAt;
            SenderId = senderId;
        }

        /// <summary>
        /// Gets or sets the subject of the email.
        /// </summary>
        public string Subject { get; set; }

        /// <summary>
        /// Gets or sets the body of the email.
        /// </summary>
        public string Body { get; set; }

        /// <summary>
        /// Gets or sets the recipient of the email.
        /// </summary>
        public string To { get; set; }

        /// <summary>
        /// Gets or sets the carbon copy recipients of the email.
        /// </summary>
        public string CC { get; set; }

        public DateTime SentAt { get; set; }

        public int SenderId { get; set; }
        /// <summary>
        /// Gets or sets the blind carbon copy recipients of the email.
        /// </summary>
        public string BCC { get; set; }
    }
}
