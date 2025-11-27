using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;

namespace Application.Features;
public class DealDocumentResponseHandler : ResponseHandler, IRequestByIdHandler<DealDocumentResponse>
{
    private readonly IUnitOfWork _unitOfWork;

    public DealDocumentResponseHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public IResponse<DealDocumentResponse> Handle(int id)
    {
        var entity = _unitOfWork.GenericRepository<DealDocument>().GetById(id);

        var result = DealDocumentResponse.FromEntity(entity);

        return Success(result);
    }
}

