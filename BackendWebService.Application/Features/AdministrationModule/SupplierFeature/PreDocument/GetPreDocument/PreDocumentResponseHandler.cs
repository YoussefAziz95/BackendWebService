using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;

namespace Application.Features;
public class PreDocumentResponseHandler : ResponseHandler, IRequestByIdHandler<PreDocumentResponse>
{
    private readonly IUnitOfWork _unitOfWork;

    public PreDocumentResponseHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public IResponse<PreDocumentResponse> Handle(int id)
    {
        var entity = _unitOfWork.GenericRepository<PreDocument>().GetById(id);

        var result = PreDocumentResponse.FromEntity(entity);

        return Success(result);
    }
}

