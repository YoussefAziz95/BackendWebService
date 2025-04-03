using System;

namespace Application.Model.EmailDto;
public class EmailDto
{
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
    public string Subject { get; set; }
    public string Body { get; set; }
    public string To { get; set; }
    public string CC { get; set; }
    public DateTime SentAt { get; set; }
    public int SenderId { get; set; }
    public string BCC { get; set; }
}

