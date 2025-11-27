namespace Application.Contracts.Features;

// Marker for requests
public interface IRequest<TResponse> { }



// Delegate for pipeline chaining
public delegate Task<TResponse> RequestHandlerDelegate<TResponse>();

// Handler (sync)
public interface IRequestHandler<in TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    IResponse<TResponse> Handle(TRequest request);
}

// Handler (async)
public interface IRequestHandlerAsync<in TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    Task<IResponse<TResponse>> HandleAsync(TRequest request);
}

// Pipeline behavior (like MediatR)
public interface IPipelineBehavior<in TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken = default);
}
public interface IRequestByIdHandler<TResponse>
{
    IResponse<TResponse> Handle(int request);
}