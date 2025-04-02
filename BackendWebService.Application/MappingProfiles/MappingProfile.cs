using Application.DTOs.Auth.Request;
using Application.DTOs.Category;
using Application.DTOs.Common;
using Application.DTOs.Company.Request;
using Application.DTOs.Company.Response;
using Application.DTOs.ExceptionLog;
using Application.DTOs.Logging;
using Application.DTOs.Service;
using Application.DTOs.PreDocument;
using Application.DTOs.Role;
using Application.DTOs.User;
using Application.DTOs.Utility;
using Application.DTOs.Supplier.Request;
using Application.DTOs.Supplier.Responses;
using Application.DTOs.SupplierCategory;
using Application.DTOs.SupplierDocument;
using AutoMapper;
using Domain.Constants;



namespace Application.MappingProfiles
{
    /// <summary>
    /// Mapping profile for configuring AutoMapper mappings.
    /// </summary>
    public class MappingProfile : Profile, IProfileExpression
    {
        /// <summary>
        /// Mapping profile for configuring AutoMapper mappings.
        /// </summary>
        public MappingProfile()
        {

            //ApplicationUser
            CreateMap<User, UserResponse>();

            CreateMap<AddUserRequest, User>();
            CreateMap<Supplier, User>()
                .ForMember(dest => dest.Email, act => act.MapFrom(src => src.Organization.Email))
                .ForMember(dest => dest.FirstName, act => act.MapFrom(src => src.Organization.Name))
                  .ForMember(dest => dest.IsDefaultPassword, act => act.MapFrom(src => true))
                .ForMember(dest => dest.MainRole, act => act.MapFrom(src => 3))
                .ForMember(dest => dest.OrganizationId, act => act.MapFrom(src => src.OrganizationId));

            CreateMap<AddSupplierRequest, User>();



            //ApplicationRole
            CreateMap<Role, RolesResponse>();

            //Company
            CreateMap<AddCompanyRequest, Company>();
            CreateMap<AddCompanyRequest, Organization>();

            CreateMap<UpdateCompanyRequest, Company>();
            CreateMap<UpdateCompanyRequest, Organization>();

            CreateMap<Company, CompanyResponse>();

            //supplier
            CreateMap<AddSupplierRequest, Supplier>().ForMember(dest => dest.SupplierCategories, opt => opt.MapFrom(src => src.supplierCategories));
            CreateMap<AddSupplierCategoryRequest, SupplierCategory>();

            CreateMap<AddSupplierRequest, Organization>();

            CreateMap<UpdateSupplierRequest, Supplier>().ForMember(dest => dest.SupplierCategories, opt => opt.MapFrom(src => src.Categories));
            CreateMap<UpdateSupplierRequest, Organization>();
            CreateMap<UpdateSupplierCategoryRequest, SupplierCategory>();


            CreateMap<RegisterSupplierRequest, Supplier>();
            CreateMap<RegisterSupplierRequest, Organization>();

            CreateMap<Supplier, SupplierResponse>()
             .ForMember(dest => dest.Categories, opt => opt.MapFrom(src => src.SupplierCategories));
            CreateMap<Organization, SupplierResponse>();
            CreateMap<SupplierCategory, SupplierCategoryResponse>();






            //RoleType
            CreateMap<CreateRoleRequest, Role>();
            CreateMap<Role, RolesResponse>();
            CreateMap<UpdateRoleRequest, Role>();

            //Category
            CreateMap<AddCategoryRequest, Category>()
                .ForMember(dest => dest.Name, act => act.Ignore());
            CreateMap<ExceptionDto, ExceptionLog>()
                .ForMember(dest => dest.KeyExceptionMessage, act => act.Ignore());
            CreateMap<Category, CategoryResponse>();
            CreateMap<UpdateCategoryRequest, Category>();



            //SupplierCategory
            CreateMap<AddSupplierCategoryRequest, SupplierCategory>();
            CreateMap<UpdateSupplierCategoryRequest, SupplierCategory>();
            CreateMap<UpdateRangeSupplierCategoryRequest, SupplierCategory>();

            //PreDocument
            CreateMap<AddPreDocumentRequest, PreDocument>();
            CreateMap<PreDocument, PreDocumentResponse>();
            CreateMap<UpdatePreDocumentRequest, PreDocument>();



            //Offer





            //SupplierDocument 
            CreateMap<AddSupplierDocumentRequest, SupplierDocument>();
            CreateMap<SupplierDocument, SupplierDocumentResponse>();

            CreateMap<UpdateSupplierDocumentRequest, SupplierDocument>();




            //file 
            CreateMap<FileLog, FileResponse>();

            //deal


            //material 
            CreateMap<AddServiceRequest, Service>();
            CreateMap<UpdateServiceRequest, Service>();
            CreateMap<Service, ServiceResponse>();
            CreateMap<Logging, LoggingDto>().ReverseMap();



        }
        /// <summary>
        /// Constructs the image URL using the provided image name and application constants.
        /// </summary>
        /// <param name="imageName">The name of the image file.</param>
        /// <returns>The URL of the image.</returns>
        private static string GetImageUrl(string imageName)
        {
            return string.IsNullOrEmpty(imageName) ? "" : $"{AppConstants.BaseUrl}{AppConstants.ImgUploadPath}/{imageName}";
        }
    }
}