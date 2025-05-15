using Application.Contracts.DTOs;
using Application.Contracts.Persistences;
using Application.Contracts.Services;
using Application.DTOs.Common;
using Application.Model.Notifications;
using Application.Wrappers;
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
                        response = new DropDownResponse { items = categories };
                        return Success(response);

                    case "part":
                        var parts = _unitOfWork.GenericRepository<Part>().GetDropdownOptionsList(columnNames);
                        response = new DropDownResponse { items = parts };
                        return Success(response);

                    case "product":
                        var products = _unitOfWork.GenericRepository<Product>().GetDropdownOptionsList(columnNames);
                        response = new DropDownResponse { items = products };
                        return Success(response);

                    case "property":
                        var properties = _unitOfWork.GenericRepository<Property>().GetDropdownOptionsList(columnNames);
                        response = new DropDownResponse { items = properties };
                        return Success(response);

                    case "role":
                        var roles = _unitOfWork.GenericRepository<Role>().GetDropdownOptionsList(columnNames);
                        response = new DropDownResponse { items = roles };
                        return Success(response);

                    case "service":
                        var services = _unitOfWork.GenericRepository<Service>().GetDropdownOptionsList(columnNames);
                        response = new DropDownResponse { items = services };
                        return Success(response);

                    case "supplier":
                        var suppliers = _unitOfWork.GenericRepository<Supplier>().GetDropdownOptionsList(columnNames);
                        response = new DropDownResponse { items = suppliers };
                        return Success(response);

                    case "supplierdocument":
                        var supplierDocs = _unitOfWork.GenericRepository<SupplierDocument>().GetDropdownOptionsList(columnNames);
                        response = new DropDownResponse { items = supplierDocs };
                        return Success(response);

                    case "user":
                        var users = _unitOfWork.GenericRepository<User>().GetDropdownOptionsList(columnNames);
                        response = new DropDownResponse { items = users };
                        return Success(response);

                    case "zone":
                        var zones = _unitOfWork.GenericRepository<Zone>().GetDropdownOptionsList(columnNames);
                        response = new DropDownResponse { items = zones };
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
