using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Contracts.Services;
using Application.Features.Common;
using Application.Model.Notifications;
using Application.Wrappers;
using Domain;
using Domain;

namespace Application.Implementations.Common
{
    public class DropdownService : ResponseHandler, IDropdownService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserInfo _userInfo;

        public DropdownService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _userInfo = IClientRepository._userInfo;
        }

        public async Task<IResponse<DropDownResponse>> GetDropdownOptions(string tableName, string[] columnNames)
        {
            try
            {
                DropDownResponse response;

                switch (tableName.ToLower())
                {
                    case "category":
                        var categories = _unitOfWork.GenericRepository<Category>().GetDropdownOptionsList(columnNames);
                        response = new DropDownResponse(Items: categories);
                        return Success(response);

                    case "part":
                        var parts = _unitOfWork.GenericRepository<Part>().GetDropdownOptionsList(columnNames);
                        response = new DropDownResponse(Items: parts);
                        return Success(response);

                    case "product":
                        var products = _unitOfWork.GenericRepository<Product>().GetDropdownOptionsList(columnNames);
                        response = new DropDownResponse(Items: products);
                        return Success(response);

                    case "property":
                        var properties = _unitOfWork.GenericRepository<Property>().GetDropdownOptionsList(columnNames);
                        response = new DropDownResponse(Items: properties);
                        return Success(response);

                    case "role":
                        var roles = _unitOfWork.GenericRepository<Role>().GetDropdownOptionsList(columnNames);
                        response = new DropDownResponse(Items: roles);
                        return Success(response);

                    case "service":
                        var services = _unitOfWork.GenericRepository<Service>().GetDropdownOptionsList(columnNames);
                        response = new DropDownResponse(Items: services);
                        return Success(response);

                    case "supplier":
                        var suppliers = _unitOfWork.GenericRepository<Supplier>().GetDropdownOptionsList(columnNames);
                        response = new DropDownResponse(Items: suppliers);
                        return Success(response);

                    case "supplierdocument":
                        var supplierDocs = _unitOfWork.GenericRepository<SupplierDocument>().GetDropdownOptionsList(columnNames);
                        response = new DropDownResponse(Items: supplierDocs);
                        return Success(response);

                    case "user":
                        var users = _unitOfWork.GenericRepository<User>().GetDropdownOptionsList(columnNames);
                        response = new DropDownResponse(Items: users);
                        return Success(response);

                    case "zone":
                        var zones = _unitOfWork.GenericRepository<Zone>().GetDropdownOptionsList(columnNames);
                        response = new DropDownResponse(Items: zones);
                        return Success(response);

                    default:
                        throw new ArgumentException($"DropdownService.GetDropdownOptions() : Table '{tableName}' not found.");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
