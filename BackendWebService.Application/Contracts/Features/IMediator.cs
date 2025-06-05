namespace Application.Contracts.Features;

public interface IMediator
{
    TResponse Send<TResponse>(IRequest<TResponse> request);
}
