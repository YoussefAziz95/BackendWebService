using Application.Model.EmailDto;
using System.Threading.Tasks;


namespace Application.Contracts.Infrastructure;

/// <summary>
/// Interface for sending emails.
/// </summary>
public interface IEmailService
{
    /// <summary>
    /// Sends an email using the provided EmailDto.
    /// </summary>
    /// <param name="emailDto">The EmailDto containing email details.</param>
    /// <returns>A task representing the asynchronous operation, returning true if the email is sent successfully, otherwise false.</returns>
    Task<int> Send(EmailDto emailDto);
}
