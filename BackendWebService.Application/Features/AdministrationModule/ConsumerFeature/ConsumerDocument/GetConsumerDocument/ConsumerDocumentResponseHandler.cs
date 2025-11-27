using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;

namespace Application.Features;
public class ConsumerDocumentResponseHandler : ResponseHandler, IRequestByIdHandler<ConsumerDocumentResponse>
{
    private readonly IUnitOfWork _unitOfWork;

    public ConsumerDocumentResponseHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public IResponse<ConsumerDocumentResponse> Handle(int id)
    { 
        var entity = _unitOfWork.GenericRepository<ConsumerDocument>().GetById(id);

        var result = ConsumerDocumentResponse.FromEntity(entity);

        return Success(result);
    }
}

