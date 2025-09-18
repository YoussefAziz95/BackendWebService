namespace Application.Contracts.Features;

public interface IRequest<TResponse> { }

public interface IRequestByIdHandler<TResponse>
{
    IResponse<TResponse> Handle(int request);
}
public interface IRequestHandler<in TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    IResponse<TResponse> Handle(TRequest request);
}
public interface IRequestHandlerAsync<in TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    Task<IResponse<TResponse>> HandleAsync(TRequest request);
}
