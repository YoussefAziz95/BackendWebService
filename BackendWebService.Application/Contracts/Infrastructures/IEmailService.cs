using Application.Model.EmailDto;

namespace Application.Contracts.Infrastructures;

public interface IEmailService
{
    int Send(EmailDto emailDto);
}
