using Application.Model.EmailDto;

namespace Application.Contracts.Infrastructures;

public interface IEmailService
{
    Task<int> Send(EmailDto emailDto);
}
