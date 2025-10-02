using Application.Contracts.Infrastructures;
using Application.Model.EmailDto;

namespace BackendWebService.IntegrationTests.Infrastructure;

/// <summary>
/// Test double for IEmailService that can simulate various failure scenarios
/// </summary>
public class EmailServiceTestDouble : IEmailService
{
    public EmailServiceBehavior Behavior { get; set; } = EmailServiceBehavior.Success;
    public int CallCount { get; private set; } = 0;
    public List<EmailDto> SentEmails { get; private set; } = new();

    public int Send(EmailDto emailDto)
    {
        CallCount++;
        SentEmails.Add(emailDto);

        return Behavior switch
        {
            EmailServiceBehavior.Success => 1,
            EmailServiceBehavior.SmtpUnavailable => -1,
            EmailServiceBehavior.AuthenticationFailure => -1,
            EmailServiceBehavior.NetworkTimeout => -1,
            EmailServiceBehavior.RateLimited => CallCount > 5 ? -1 : 1, // Fail after 5 calls
            EmailServiceBehavior.InvalidEmail => IsInvalidEmail(emailDto.To) ? -1 : 1,
            EmailServiceBehavior.EmptyContent => string.IsNullOrEmpty(emailDto.To) || string.IsNullOrEmpty(emailDto.Subject) ? -1 : 1,
            EmailServiceBehavior.ServiceUnavailable => -1,
            _ => 1 // Default to success
        };
    }

    public void Reset()
    {
        CallCount = 0;
        SentEmails.Clear();
        Behavior = EmailServiceBehavior.Success;
    }

    public void SimulateFailure(EmailServiceBehavior failureType)
    {
        Behavior = failureType;
    }

    private static bool IsInvalidEmail(string email)
    {
        if (string.IsNullOrEmpty(email))
            return true;
            
        // Simple email validation - check for common invalid patterns
        return !email.Contains("@") || 
               email.StartsWith("@") || 
               email.EndsWith("@") ||
               email.Contains("invalid") ||
               email.Contains("..") ||
               !email.Contains(".") ||
               email.Contains("@.") ||
               email.Contains(".@") ||
               email.Split('@').Length != 2 ||
               email.Split('@')[1].Split('.').Length < 2;
    }
}

/// <summary>
/// Enumeration of email service behaviors for testing
/// </summary>
public enum EmailServiceBehavior
{
    Success,
    SmtpUnavailable,
    AuthenticationFailure,
    NetworkTimeout,
    RateLimited,
    InvalidEmail,
    EmptyContent,
    ServiceUnavailable
}
