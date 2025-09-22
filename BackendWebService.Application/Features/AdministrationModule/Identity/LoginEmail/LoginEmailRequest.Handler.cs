using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;

namespace Application.Features;

public class LoginEmailRequestHandler : ResponseHandler, IRequestHandler<LoginEmailRequest, int>
{
    private readonly IUnitOfWork _unitOfWork;

    public LoginEmailRequestHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public IResponse<int> Handle(LoginEmailRequest request)
    {
        // 1. Get user by email
        var user = _unitOfWork.GenericRepository<User>().Get(u => u.Email == request.Email);

        if (user == null)
            return NotFound<int>("User not found with this email.");

        // 2. Verify password
        if (!VerifyPassword(user, request.Password))
            return Unauthorized<int>();

        // 3. Return success (for now just returning user Id)
        return Success(user.Id);
    }

    private bool VerifyPassword(User user, string password)
    {
        // TODO: plug in your hashing / password manager logic
        return user.PasswordHash == password;
    }
}
