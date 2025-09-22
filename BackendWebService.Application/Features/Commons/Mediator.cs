using Application.Contracts.Features;

namespace Application.Features;
public class Mediator : ICustomMediator
{
    private readonly IServiceProvider _serviceProvider;

    public Mediator(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    // ----------------------
    // SYNC HANDLER
    // ----------------------
    public IResponse<TResponse> Send<TResponse>(IRequest<TResponse> request)
    {
        var handlerType = typeof(IRequestHandler<,>)
            .MakeGenericType(request.GetType(), typeof(TResponse));

        var handler = _serviceProvider.GetService(handlerType);
        if (handler != null)
        {
            return ((dynamic)handler).Handle((dynamic)request);
        }

        throw new InvalidOperationException($"No handler found for request type {request.GetType().Name}");
    }

    // ----------------------
    // ASYNC HANDLER
    // ----------------------
    public async Task<IResponse<TResponse>> SendAsync<TResponse>(IRequest<TResponse> request)
    {
        var handlerType = typeof(IRequestHandlerAsync<,>)
            .MakeGenericType(request.GetType(), typeof(TResponse));

        var handler = _serviceProvider.GetService(handlerType);
        if (handler != null)
        {
            return await ((dynamic)handler).HandleAsync((dynamic)request);
        }

        // fallback: allow sync handlers in async pipeline
        var syncHandlerType = typeof(IRequestHandler<,>)
            .MakeGenericType(request.GetType(), typeof(TResponse));

        var syncHandler = _serviceProvider.GetService(syncHandlerType);
        if (syncHandler != null)
        {
            return ((dynamic)syncHandler).Handle((dynamic)request);
        }

        throw new InvalidOperationException($"No async handler found for request type {request.GetType().Name}");
    }

    // ----------------------
    // BY ID HANDLER
    // ----------------------
    public IResponse<TResponse> SendById<TResponse>(int id)
    {
        var handlerType = typeof(IRequestByIdHandler<>)
            .MakeGenericType(typeof(TResponse));

        var handler = _serviceProvider.GetService(handlerType);
        if (handler != null)
        {
            return ((dynamic)handler).Handle(id);
        }

        throw new InvalidOperationException($"No handler found for ID-based request of type {typeof(TResponse).Name}");
    }
}

