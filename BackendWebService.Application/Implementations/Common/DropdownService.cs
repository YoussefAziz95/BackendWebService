using Application.Contracts.DTOs;
using Application.Contracts.Persistence;
using Application.Contracts.Persistence.Identities;
using Application.Contracts.Services;
using Application.DTOs.Common;
using Application.Model.Notifications;
using Application.Wrappers;
using Domain;
using Domain.Enums;
using System;
using System.Linq;
using System.Threading.Tasks;
namespace Application.Implementations.Common
{
    /// <summary>
    /// Services implementation for managing dropdown options.
    /// </summary>
    public class DropdownService : ResponseHandler, IDropdownService
    {
        private readonly IUnitOfWork _unitOfwork;
        private readonly UserInfo _userInfo;

        public DropdownService(IUnitOfWork unitOfWork)
        {
            _unitOfwork = unitOfWork;
            _userInfo = IClientRepository._userInfo;
        }
        /// <inheritdoc/>
        public async Task<IResponse<DropDownResponse>> GetDropdownOptions(string tableName, string[] columnNames)
        {
            try
            {
                string[] langs = ["en", "ar"];
                switch (tableName.ToLower())
                {
                    case "company":
                        var c = _unitOfwork.GenericRepository<Organization>().GetAll(x => x.OrganizationId == _userInfo.OrganizationId && _userInfo.CompanyId != null).ToList();
                        return Success(_unitOfwork.GenericRepository<Organization>().GetDropdownOptions(c, columnNames));
                    case "supplier":
                        var v = _unitOfwork.GenericRepository<Organization>().GetAll(x => x.OrganizationId == _userInfo.OrganizationId && _userInfo.CompanyId != null && _userInfo.SupplierId != null).ToList();
                        return Success(_unitOfwork.GenericRepository<Organization>().GetDropdownOptions(v, columnNames));
                    case "offersupplier":
                        var tv = _unitOfwork.GenericRepository<Organization>().GetAll(x => x.Type == OrganizationEnum.Supplier).ToList();
                        return Success(_unitOfwork.GenericRepository<Organization>().GetDropdownOptions(tv, columnNames));
                    case "category":
                        return Success(_unitOfwork.GenericRepository<Category>().GetDropdownOptions(columnNames));
                    case "organization":
                        var ten = _unitOfwork.GenericRepository<Organization>().GetAll(t => t.IsActive == true && t.IsDeleted == false).ToList();
                        return Success(_unitOfwork.GenericRepository<Organization>().GetDropdownOptions(ten, columnNames));

                    case "role":
                        var name = Enum.GetName(typeof(RoleEnum), _userInfo.RoleId);
                        var r = _unitOfwork.GenericRepository<Role>().GetAll(x => x.ParentId == _userInfo.RoleId).ToList();
                        return Success(_unitOfwork.GenericRepository<Role>().GetDropdownOptions(r, columnNames));
                    case "roleuser":
                        var ru = _unitOfwork.GenericRepository<Role>().GetAll(x => x.ParentId == _userInfo.RoleParentId).ToList();
                        return Success(_unitOfwork.GenericRepository<Role>().GetDropdownOptions(ru, columnNames));
                    case "user":
                    case "workflowuser":
                        var u = _unitOfwork.GenericRepository<User>().GetAll(x => x.OrganizationId == _userInfo.OrganizationId).ToList();
                        return Success(_unitOfwork.GenericRepository<User>().GetDropdownOptions(u, columnNames));
                    case "group":
                        return Success(_unitOfwork.GenericRepository<Group>().GetDropdownOptions(columnNames));
                    case "filetypes":
                        return Success(_unitOfwork.GenericRepository<FileType>().GetDropdownOptions(columnNames));
                    case "materials":
                        return Success(_unitOfwork.GenericRepository<Service>().GetDropdownOptions(columnNames));
                    case "predocument":
                        return Success(_unitOfwork.GenericRepository<PreDocument>().GetDropdownOptions(columnNames));
                    case "actortype":
                        return Success(GetDropDownOptionsDummy(langs, Enum.GetNames(typeof(ActorEnum))));
                    case "actiontype":
                        return Success(GetDropDownOptionsDummy(langs, Enum.GetNames(typeof(ActionEnum))));
                    case "predocumentowner":
                        return Success(new DropDownResponse(["Offer", "Suppliers"]));
                    case "currency":
                        return Success(GetDropDownOptionsDummy(langs, Enum.GetNames(typeof(CurrencyEnum))));


                    default:
                        throw new ArgumentException($"DropdownService.GetDropdownOptions() : Table '{tableName}' not found.");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static DropDownResponse GetDropDownOptionsDummy(string[] langs, string[] options)
        {
            var dropDownOptions = new DropDownResponse();
            for (int i = 0; i < options.Length; i++)
            {
                dropDownOptions.items.Add(i, options[i]);
            }
            return dropDownOptions;
        }
    }
}
