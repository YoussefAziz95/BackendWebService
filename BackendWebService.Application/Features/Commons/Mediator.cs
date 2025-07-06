using Application.Contracts.Features;

namespace Application.Features;
public class Mediator : IMediator
{
    private readonly IServiceProvider _serviceProvider;

    public Mediator(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public TResponse Send<TResponse>(IRequest<TResponse> request)
    {
        var handlerType = typeof(IRequestHandler<,>)
            .MakeGenericType(request.GetType(), typeof(TResponse));

        dynamic handler = _serviceProvider.GetService(handlerType)
            ?? throw new InvalidOperationException($"No handler for {request.GetType()}");

        return handler.Handle((dynamic)request);
    }
}

