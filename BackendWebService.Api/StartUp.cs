using Application.Contracts.Features;
using Application.Features;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Api;

public static class Startup
{
    public static IServiceCollection ConfigureGrpcPluginServices(this IServiceCollection services)
    {
        services.AddGrpc();
        services.AddApiVersioning(options =>
        {
            options.AssumeDefaultVersionWhenUnspecified = true;
            options.DefaultApiVersion = new ApiVersion(1, 0);
            options.ReportApiVersions = true;
        });

        services.AddVersionedApiExplorer(options =>
        {
            options.GroupNameFormat = "'v'VVV"; // e.g., v1, v2
            options.SubstituteApiVersionInUrl = true;
        });
        return services;
    }
    public static IServiceCollection ConfigureCQRS(this IServiceCollection services)
    {
        services.AddScoped<IMediator, Mediator>();
        services.AddScoped<IRequestHandlerAsync<LoginPhoneRequest, LoginResponse>, LoginPhoneRequestHandler>();
        services.AddScoped<IRequestHandlerAsync<LoginEmailRequest, LoginResponse>, LoginEmailRequestHandler>();
        services.AddScoped<IRequestHandlerAsync<SignUpRequest, LoginResponse>, SignUpRequestHandler>();
        services.AddScoped<IRequestHandlerAsync<RefreshTokenRequest, RefreshTokenResponse>, RefreshTokenRequestHandler>();
        //services.AddScoped<IRequestHandlerAsync<ResetPasswordRequest, LoginResponse>, ResetPasswordRequestHandler>();
        services.AddScoped<IRequestHandlerAsync<ConfirmResetPasswordRequest, LoginResponse>, ConfirmResetPasswordRequestHandler>();
        services.AddScoped<IRequestHandlerAsync<ConfirmPhoneNumberRequest, IdentityResult>, ConfirmPhoneNumberRequestHandler>();
        services.AddScoped<IRequestHandler<PhoneNumberRequest, LoginResponse>, PhoneNumberRequestHandler>();
        services.AddScoped<IRequestHandler<OtpVerifyRequest, LoginResponse>, OtpVerifyRequestHandler>();

        #region CompanyCategory

        services.AddScoped<IRequestHandlerAsync<DeleteCompanyCategoryRequest, string>, DeleteCompanyCategoryRequestHandler>();
        services.AddScoped<IRequestHandler<AddCompanyCategoryRequest, int>, AddCompanyCategoryRequestHandler>();
        services.AddScoped<IRequestByIdHandler<CompanyCategoryResponse>, CompanyCategoryResponseHandler>();
        services.AddScoped<IRequestHandler<CompanyCategoryAllRequest, List<CompanyCategoryAllResponse>>, CompanyCategoryAllResponseHandler>();
        services.AddScoped<IRequestHandler<UpdateCompanyCategoryRequest, int>, UpdateCompanyCategoryRequestHandler>();

        #endregion
        #region Company

        services.AddScoped<IRequestHandlerAsync<DeleteCompanyRequest, string>, DeleteCompanyRequestHandler>();
        services.AddScoped<IRequestHandler<AddCompanyRequest, int>, AddCompanyRequestHandler>();
        services.AddScoped<IRequestByIdHandler<CompanyResponse>, CompanyResponseHandler>();
        services.AddScoped<IRequestHandler<CompanyAllRequest, List<CompanyAllResponse>>, CompanyAllResponseHandler>();
        services.AddScoped<IRequestHandler<UpdateCompanyRequest, int>, UpdateCompanyRequestHandler>();

        #endregion
        #region Manager

        services.AddScoped<IRequestHandlerAsync<DeleteManagerRequest, string>, DeleteManagerRequestHandler>();
        services.AddScoped<IRequestHandler<AddManagerRequest, int>, AddManagerRequestHandler>();
        services.AddScoped<IRequestByIdHandler<ManagerResponse>, ManagerResponseHandler>();
        services.AddScoped<IRequestHandler<ManagerAllRequest, List<ManagerAllResponse>>, ManagerAllResponseHandler>();
        services.AddScoped<IRequestHandler<UpdateManagerRequest, int>, UpdateManagerRequestHandler>();

        #endregion
        


        #region ConsumerAccount

        services.AddScoped<IRequestHandlerAsync<DeleteConsumerAccountRequest, string>, DeleteConsumerAccountRequestHandler>();
        services.AddScoped<IRequestHandler<AddConsumerAccountRequest, int>, AddConsumerAccountRequestHandler>();
        services.AddScoped<IRequestByIdHandler<ConsumerAccountResponse>, ConsumerAccountResponseHandler>();
        services.AddScoped<IRequestHandler<ConsumerAccountAllRequest, List<ConsumerAccountAllResponse>>, ConsumerAccountAllResponseHandler>();
        services.AddScoped<IRequestHandler<UpdateConsumerAccountRequest, int>, UpdateConsumerAccountRequestHandler>();

        #endregion
        #region ConsumerCustomer

        services.AddScoped<IRequestHandlerAsync<DeleteConsumerCustomerRequest, string>, DeleteConsumerCustomerRequestHandler>();
        services.AddScoped<IRequestHandler<AddConsumerCustomerRequest, int>, AddConsumerCustomerRequestHandler>();
        services.AddScoped<IRequestByIdHandler<ConsumerCustomerResponse>, ConsumerCustomerResponseHandler>();
        services.AddScoped<IRequestHandler<ConsumerCustomerAllRequest, List<ConsumerCustomerAllResponse>>, ConsumerCustomerAllResponseHandler>();
        services.AddScoped<IRequestHandler<UpdateConsumerCustomerRequest, int>, UpdateConsumerCustomerRequestHandler>();

        #endregion
        #region ConsumerDocument

        services.AddScoped<IRequestHandlerAsync<DeleteConsumerDocumentRequest, string>, DeleteConsumerDocumentRequestHandler>();
        services.AddScoped<IRequestHandler<AddConsumerDocumentRequest, int>, AddConsumerDocumentRequestHandler>();
        services.AddScoped<IRequestByIdHandler<ConsumerDocumentResponse>, ConsumerDocumentResponseHandler>();
        services.AddScoped<IRequestHandler<ConsumerDocumentAllRequest, List<ConsumerDocumentAllResponse>>, ConsumerDocumentAllResponseHandler>();
        services.AddScoped<IRequestHandler<UpdateConsumerDocumentRequest, int>, UpdateConsumerDocumentRequestHandler>();

        #endregion
        #region Consumer

        services.AddScoped<IRequestHandlerAsync<DeleteConsumerRequest, string>, DeleteConsumerRequestHandler>();
        services.AddScoped<IRequestHandler<AddConsumerRequest, int>, AddConsumerRequestHandler>();
        services.AddScoped<IRequestByIdHandler<ConsumerResponse>, ConsumerResponseHandler>();
        services.AddScoped<IRequestHandler<ConsumerAllRequest, List<ConsumerAllResponse>>, ConsumerAllResponseHandler>();
        services.AddScoped<IRequestHandler<UpdateConsumerRequest, int>, UpdateConsumerRequestHandler>();

        #endregion

        #region Address

        services.AddScoped<IRequestHandlerAsync<DeleteAddressRequest, string>, DeleteAddressRequestHandler>();
        services.AddScoped<IRequestHandler<AddAddressRequest, int>, AddAddressRequestHandler>();
        services.AddScoped<IRequestByIdHandler<AddressResponse>, AddressResponseHandler>();
        services.AddScoped<IRequestHandler<AddressAllRequest, List<AddressAllResponse>>, AddressAllResponseHandler>();
        services.AddScoped<IRequestHandler<UpdateAddressRequest, int>, UpdateAddressRequestHandler>();

        #endregion
        #region Administrator

        services.AddScoped<IRequestHandlerAsync<DeleteAdministratorRequest, string>, DeleteAdministratorRequestHandler>();
        services.AddScoped<IRequestHandler<AddAdministratorRequest, int>, AddAdministratorRequestHandler>();
        services.AddScoped<IRequestByIdHandler<AdministratorResponse>, AdministratorResponseHandler>();
        services.AddScoped<IRequestHandler<AdministratorAllRequest, List<AdministratorAllResponse>>, AdministratorAllResponseHandler>();
        services.AddScoped<IRequestHandler<UpdateAdministratorRequest, int>, UpdateAdministratorRequestHandler>();

        #endregion
        #region Contact

        services.AddScoped<IRequestHandlerAsync<DeleteContactRequest, string>, DeleteContactRequestHandler>();
        services.AddScoped<IRequestHandler<AddContactRequest, int>, AddContactRequestHandler>();
        services.AddScoped<IRequestByIdHandler<ContactResponse>, ContactResponseHandler>();
        services.AddScoped<IRequestHandler<ContactAllRequest, List<ContactAllResponse>>, ContactAllResponseHandler>();
        services.AddScoped<IRequestHandler<UpdateContactRequest, int>, UpdateContactRequestHandler>();

        #endregion
        #region Department

        services.AddScoped<IRequestHandlerAsync<DeleteDepartmentRequest, string>, DeleteDepartmentRequestHandler>();
        services.AddScoped<IRequestHandler<AddDepartmentRequest, int>, AddDepartmentRequestHandler>();
        services.AddScoped<IRequestByIdHandler<DepartmentResponse>, DepartmentResponseHandler>();
        services.AddScoped<IRequestHandler<DepartmentAllRequest, List<DepartmentAllResponse>>, DepartmentAllResponseHandler>();
        services.AddScoped<IRequestHandler<UpdateDepartmentRequest, int>, UpdateDepartmentRequestHandler>();

        #endregion
        #region GoogleConfig

        services.AddScoped<IRequestHandlerAsync<DeleteGoogleConfigRequest, string>, DeleteGoogleConfigRequestHandler>();
        services.AddScoped<IRequestHandler<AddGoogleConfigRequest, int>, AddGoogleConfigRequestHandler>();
        services.AddScoped<IRequestByIdHandler<GoogleConfigResponse>, GoogleConfigResponseHandler>();
        services.AddScoped<IRequestHandler<GoogleConfigAllRequest, List<GoogleConfigAllResponse>>, GoogleConfigAllResponseHandler>();
        services.AddScoped<IRequestHandler<UpdateGoogleConfigRequest, int>, UpdateGoogleConfigRequestHandler>();

        #endregion
        #region LDAPConfig

        services.AddScoped<IRequestHandlerAsync<DeleteLDAPConfigRequest, string>, DeleteLDAPConfigRequestHandler>();
        services.AddScoped<IRequestHandler<AddLDAPConfigRequest, int>, AddLDAPConfigRequestHandler>();
        services.AddScoped<IRequestByIdHandler<LDAPConfigResponse>, LDAPConfigResponseHandler>();
        services.AddScoped<IRequestHandler<LDAPConfigAllRequest, List<LDAPConfigAllResponse>>, LDAPConfigAllResponseHandler>();
        services.AddScoped<IRequestHandler<UpdateLDAPConfigRequest, int>, UpdateLDAPConfigRequestHandler>();

        #endregion
        #region MicrosoftConfig

        services.AddScoped<IRequestHandlerAsync<DeleteMicrosoftConfigRequest, string>, DeleteMicrosoftConfigRequestHandler>();
        services.AddScoped<IRequestHandler<AddMicrosoftConfigRequest, int>, AddMicrosoftConfigRequestHandler>();
        services.AddScoped<IRequestByIdHandler<MicrosoftConfigResponse>, MicrosoftConfigResponseHandler>();
        services.AddScoped<IRequestHandler<MicrosoftConfigAllRequest, List<MicrosoftConfigAllResponse>>, MicrosoftConfigAllResponseHandler>();
        services.AddScoped<IRequestHandler<UpdateMicrosoftConfigRequest, int>, UpdateMicrosoftConfigRequestHandler>();

        #endregion
        #region Organization

        services.AddScoped<IRequestHandlerAsync<DeleteOrganizationRequest, string>, DeleteOrganizationRequestHandler>();
        services.AddScoped<IRequestHandler<AddOrganizationRequest, int>, AddOrganizationRequestHandler>();
        services.AddScoped<IRequestByIdHandler<OrganizationResponse>, OrganizationResponseHandler>();
        services.AddScoped<IRequestHandler<OrganizationAllRequest, List<OrganizationAllResponse>>, OrganizationAllResponseHandler>();
        services.AddScoped<IRequestHandler<UpdateOrganizationRequest, int>, UpdateOrganizationRequestHandler>();

        #endregion

        #region PreDocument

        services.AddScoped<IRequestHandlerAsync<DeletePreDocumentRequest, string>, DeletePreDocumentRequestHandler>();
        services.AddScoped<IRequestHandler<AddPreDocumentRequest, int>, AddPreDocumentRequestHandler>();
        services.AddScoped<IRequestByIdHandler<PreDocumentResponse>, PreDocumentResponseHandler>();
        services.AddScoped<IRequestHandler<PreDocumentAllRequest, List<PreDocumentAllResponse>>, PreDocumentAllResponseHandler>();
        services.AddScoped<IRequestHandler<UpdatePreDocumentRequest, int>, UpdatePreDocumentRequestHandler>();

        #endregion
        #region SupplierAccount

        services.AddScoped<IRequestHandlerAsync<DeleteSupplierAccountRequest, string>, DeleteSupplierAccountRequestHandler>();
        services.AddScoped<IRequestHandler<AddSupplierAccountRequest, int>, AddSupplierAccountRequestHandler>();
        services.AddScoped<IRequestByIdHandler<SupplierAccountResponse>, SupplierAccountResponseHandler>();
        services.AddScoped<IRequestHandler<SupplierAccountAllRequest, List<SupplierAccountAllResponse>>, SupplierAccountAllResponseHandler>();
        services.AddScoped<IRequestHandler<UpdateSupplierAccountRequest, int>, UpdateSupplierAccountRequestHandler>();

        #endregion
        #region SupplierCategory

        services.AddScoped<IRequestHandlerAsync<DeleteSupplierCategoryRequest, string>, DeleteSupplierCategoryRequestHandler>();
        services.AddScoped<IRequestHandler<AddSupplierCategoryRequest, int>, AddSupplierCategoryRequestHandler>();
        services.AddScoped<IRequestByIdHandler<SupplierCategoryResponse>, SupplierCategoryResponseHandler>();
        services.AddScoped<IRequestHandler<SupplierCategoryAllRequest, List<SupplierCategoryAllResponse>>, SupplierCategoryAllResponseHandler>();
        services.AddScoped<IRequestHandler<UpdateSupplierCategoryRequest, int>, UpdateSupplierCategoryRequestHandler>();

        #endregion
        #region SupplierDocument

        services.AddScoped<IRequestHandlerAsync<DeleteSupplierDocumentRequest, string>, DeleteSupplierDocumentRequestHandler>();
        services.AddScoped<IRequestHandler<AddSupplierDocumentRequest, int>, AddSupplierDocumentRequestHandler>();
        services.AddScoped<IRequestByIdHandler<SupplierDocumentResponse>, SupplierDocumentResponseHandler>();
        services.AddScoped<IRequestHandler<SupplierDocumentAllRequest, List<SupplierDocumentAllResponse>>, SupplierDocumentAllResponseHandler>();
        services.AddScoped<IRequestHandler<UpdateSupplierDocumentRequest, int>, UpdateSupplierDocumentRequestHandler>();

        #endregion
        #region Supplier

        services.AddScoped<IRequestHandlerAsync<DeleteSupplierRequest, string>, DeleteSupplierRequestHandler>();
        services.AddScoped<IRequestHandler<AddSupplierRequest, int>, AddSupplierRequestHandler>();
        services.AddScoped<IRequestByIdHandler<SupplierResponse>, SupplierResponseHandler>();
        services.AddScoped<IRequestHandler<SupplierAllRequest, List<SupplierAllResponse>>, SupplierAllResponseHandler>();
        services.AddScoped<IRequestHandler<UpdateSupplierRequest, int>, UpdateSupplierRequestHandler>();

        #endregion

        #region ClientAccount

        services.AddScoped<IRequestHandlerAsync<DeleteClientAccountRequest, string>, DeleteClientAccountRequestHandler>();
        services.AddScoped<IRequestHandler<AddClientAccountRequest, int>, AddClientAccountRequestHandler>();
        services.AddScoped<IRequestByIdHandler<ClientAccountResponse>, ClientAccountResponseHandler>();
        services.AddScoped<IRequestHandler<ClientAccountAllRequest, List<ClientAccountAllResponse>>, ClientAccountAllResponseHandler>();
        services.AddScoped<IRequestHandler<UpdateClientAccountRequest, int>, UpdateClientAccountRequestHandler>();

        #endregion
        #region ClientProperty

        services.AddScoped<IRequestHandlerAsync<DeleteClientPropertyRequest, string>, DeleteClientPropertyRequestHandler>();
        services.AddScoped<IRequestHandler<AddClientPropertyRequest, int>, AddClientPropertyRequestHandler>();
        services.AddScoped<IRequestByIdHandler<ClientPropertyResponse>, ClientPropertyResponseHandler>();
        services.AddScoped<IRequestHandler<ClientPropertyAllRequest, List<ClientPropertyAllResponse>>, ClientPropertyAllResponseHandler>();
        services.AddScoped<IRequestHandler<UpdateClientPropertyRequest, int>, UpdateClientPropertyRequestHandler>();

        #endregion
        #region ClientService

        services.AddScoped<IRequestHandlerAsync<DeleteClientServiceRequest, string>, DeleteClientServiceRequestHandler>();
        services.AddScoped<IRequestHandler<AddClientServiceRequest, int>, AddClientServiceRequestHandler>();
        services.AddScoped<IRequestByIdHandler<ClientServiceResponse>, ClientServiceResponseHandler>();
        services.AddScoped<IRequestHandler<ClientServiceAllRequest, List<ClientServiceAllResponse>>, ClientServiceAllResponseHandler>();
        services.AddScoped<IRequestHandler<UpdateClientServiceRequest, int>, UpdateClientServiceRequestHandler>();

        #endregion
        #region Client

        services.AddScoped<IRequestHandlerAsync<DeleteClientRequest, string>, DeleteClientRequestHandler>();
        services.AddScoped<IRequestHandler<AddClientRequest, int>, AddClientRequestHandler>();
        services.AddScoped<IRequestByIdHandler<ClientResponse>, ClientResponseHandler>();
        services.AddScoped<IRequestHandler<ClientAllRequest, List<ClientAllResponse>>, ClientAllResponseHandler>();
        services.AddScoped<IRequestHandler<UpdateClientRequest, int>, UpdateClientRequestHandler>();

        #endregion

        #region DealDetails

        services.AddScoped<IRequestHandlerAsync<DeleteDealDetailsRequest, string>, DeleteDealDetailsRequestHandler>();
        services.AddScoped<IRequestHandler<AddDealDetailsRequest, int>, AddDealDetailsRequestHandler>();
        services.AddScoped<IRequestByIdHandler<DealDetailsResponse>, DealDetailsResponseHandler>();
        services.AddScoped<IRequestHandler<DealDetailsAllRequest, List<DealDetailsAllResponse>>, DealDetailsAllResponseHandler>();
        services.AddScoped<IRequestHandler<UpdateDealDetailsRequest, int>, UpdateDealDetailsRequestHandler>();

        #endregion
        #region DealDocument

        services.AddScoped<IRequestHandlerAsync<DeleteDealDocumentRequest, string>, DeleteDealDocumentRequestHandler>();
        services.AddScoped<IRequestHandler<AddDealDocumentRequest, int>, AddDealDocumentRequestHandler>();
        services.AddScoped<IRequestByIdHandler<DealDocumentResponse>, DealDocumentResponseHandler>();
        services.AddScoped<IRequestHandler<DealDocumentAllRequest, List<DealDocumentAllResponse>>, DealDocumentAllResponseHandler>();
        services.AddScoped<IRequestHandler<UpdateDealDocumentRequest, int>, UpdateDealDocumentRequestHandler>();

        #endregion
        #region Deal

        services.AddScoped<IRequestHandlerAsync<DeleteDealRequest, string>, DeleteDealRequestHandler>();
        services.AddScoped<IRequestHandler<AddDealRequest, int>, AddDealRequestHandler>();
        services.AddScoped<IRequestByIdHandler<DealResponse>, DealResponseHandler>();
        services.AddScoped<IRequestHandler<DealAllRequest, List<DealAllResponse>>, DealAllResponseHandler>();
        services.AddScoped<IRequestHandler<UpdateDealRequest, int>, UpdateDealRequestHandler>();

        #endregion

        #region Property

        services.AddScoped<IRequestHandlerAsync<DeletePropertyRequest, string>, DeletePropertyRequestHandler>();
        services.AddScoped<IRequestHandler<AddPropertyRequest, int>, AddPropertyRequestHandler>();
        services.AddScoped<IRequestByIdHandler<PropertyResponse>, PropertyResponseHandler>();
        services.AddScoped<IRequestHandler<PropertyAllRequest, List<PropertyAllResponse>>, PropertyAllResponseHandler>();
        services.AddScoped<IRequestHandler<UpdatePropertyRequest, int>, UpdatePropertyRequestHandler>();

        #endregion

        #region CustomerPaymentMethod

        services.AddScoped<IRequestHandlerAsync<DeleteCustomerPaymentMethodRequest, string>, DeleteCustomerPaymentMethodRequestHandler>();
        services.AddScoped<IRequestHandler<AddCustomerPaymentMethodRequest, int>, AddCustomerPaymentMethodRequestHandler>();
        services.AddScoped<IRequestByIdHandler<CustomerPaymentMethodResponse>, CustomerPaymentMethodResponseHandler>();
        services.AddScoped<IRequestHandler<CustomerPaymentMethodAllRequest, List<CustomerPaymentMethodAllResponse>>, CustomerPaymentMethodAllResponseHandler>();
        services.AddScoped<IRequestHandler<UpdateCustomerPaymentMethodRequest, int>, UpdateCustomerPaymentMethodRequestHandler>();

        #endregion
        #region CustomerService

        services.AddScoped<IRequestHandlerAsync<DeleteCustomerServiceRequest, string>, DeleteCustomerServiceRequestHandler>();
        services.AddScoped<IRequestHandler<AddCustomerServiceRequest, int>, AddCustomerServiceRequestHandler>();
        services.AddScoped<IRequestByIdHandler<CustomerServiceResponse>, CustomerServiceResponseHandler>();
        services.AddScoped<IRequestHandler<CustomerServiceAllRequest, List<CustomerServiceAllResponse>>, CustomerServiceAllResponseHandler>();
        services.AddScoped<IRequestHandler<UpdateCustomerServiceRequest, int>, UpdateCustomerServiceRequestHandler>();

        #endregion
        #region Customer

        services.AddScoped<IRequestHandlerAsync<DeleteCustomerRequest, string>, DeleteCustomerRequestHandler>();
        services.AddScoped<IRequestHandler<AddCustomerRequest, int>, AddCustomerRequestHandler>();
        services.AddScoped<IRequestByIdHandler<CustomerResponse>, CustomerResponseHandler>();
        services.AddScoped<IRequestHandler<CustomerAllRequest, List<CustomerAllResponse>>, CustomerAllResponseHandler>();
        services.AddScoped<IRequestHandler<UpdateCustomerRequest, int>, UpdateCustomerRequestHandler>();

        #endregion

        #region OrderItem

        services.AddScoped<IRequestHandlerAsync<DeleteOrderItemRequest, string>, DeleteOrderItemRequestHandler>();
        services.AddScoped<IRequestHandler<AddOrderItemRequest, int>, AddOrderItemRequestHandler>();
        services.AddScoped<IRequestByIdHandler<OrderItemResponse>, OrderItemResponseHandler>();
        services.AddScoped<IRequestHandler<OrderItemAllRequest, List<OrderItemAllResponse>>, OrderItemAllResponseHandler>();
        services.AddScoped<IRequestHandler<UpdateOrderItemRequest, int>, UpdateOrderItemRequestHandler>();

        #endregion
        #region Order

        services.AddScoped<IRequestHandlerAsync<DeleteOrderRequest, string>, DeleteOrderRequestHandler>();
        services.AddScoped<IRequestHandler<AddOrderRequest, int>, AddOrderRequestHandler>();
        services.AddScoped<IRequestByIdHandler<OrderResponse>, OrderResponseHandler>();
        services.AddScoped<IRequestHandler<OrderAllRequest, List<OrderAllResponse>>, OrderAllResponseHandler>();
        services.AddScoped<IRequestHandler<UpdateOrderRequest, int>, UpdateOrderRequestHandler>();

        #endregion
        #region Receipt

        services.AddScoped<IRequestHandlerAsync<DeleteReceiptRequest, string>, DeleteReceiptRequestHandler>();
        services.AddScoped<IRequestHandler<AddReceiptRequest, int>, AddReceiptRequestHandler>();
        services.AddScoped<IRequestByIdHandler<ReceiptResponse>, ReceiptResponseHandler>();
        services.AddScoped<IRequestHandler<ReceiptAllRequest, List<ReceiptAllResponse>>, ReceiptAllResponseHandler>();
        services.AddScoped<IRequestHandler<UpdateReceiptRequest, int>, UpdateReceiptRequestHandler>();

        #endregion

        #region BranchContact

        services.AddScoped<IRequestHandlerAsync<DeleteBranchContactRequest, string>, DeleteBranchContactRequestHandler>();
        services.AddScoped<IRequestHandler<AddBranchContactRequest, int>, AddBranchContactRequestHandler>();
        services.AddScoped<IRequestByIdHandler<BranchContactResponse>, BranchContactResponseHandler>();
        services.AddScoped<IRequestHandler<BranchContactAllRequest, List<BranchContactAllResponse>>, BranchContactAllResponseHandler>();
        services.AddScoped<IRequestHandler<UpdateBranchContactRequest, int>, UpdateBranchContactRequestHandler>();

        #endregion
        #region BranchEmployee

        services.AddScoped<IRequestHandlerAsync<DeleteBranchEmployeeRequest, string>, DeleteBranchEmployeeRequestHandler>();
        services.AddScoped<IRequestHandler<AddBranchEmployeeRequest, int>, AddBranchEmployeeRequestHandler>();
        services.AddScoped<IRequestByIdHandler<BranchEmployeeResponse>, BranchEmployeeResponseHandler>();
        services.AddScoped<IRequestHandler<BranchEmployeeAllRequest, List<BranchEmployeeAllResponse>>, BranchEmployeeAllReponseHandler>();
        services.AddScoped<IRequestHandler<UpdateBranchEmployeeRequest, int>, UpdateBranchEmployeeRequestHandler>();

        #endregion
        #region BranchLocation

        services.AddScoped<IRequestHandlerAsync<DeleteBranchLocationRequest, string>, DeleteBranchLocationRequestHandler>();
        services.AddScoped<IRequestHandler<AddBranchLocationRequest, int>, AddBranchLocationRequestHandler>();
        services.AddScoped<IRequestByIdHandler<BranchLocationResponse>, BranchLocationResponseHandler>();
        services.AddScoped<IRequestHandler<BranchLocationAllRequest, List<BranchLocationAllResponse>>, BranchLocationAllResponseHandler>();
        services.AddScoped<IRequestHandler<UpdateBranchLocationRequest, int>, UpdateBranchLocationRequestHandler>();

        #endregion
        #region BranchService

        services.AddScoped<IRequestHandlerAsync<DeleteBranchServiceRequest, string>, DeleteBranchServiceRequestHandler>();
        services.AddScoped<IRequestHandler<AddBranchServiceRequest, int>, AddBranchServiceRequestHandler>();
        services.AddScoped<IRequestByIdHandler<BranchServiceResponse>, BranchServiceResponseHandler>();
        services.AddScoped<IRequestHandler<BranchServiceAllRequest, List<BranchServiceAllResponse>>, BranchServiceAllResponseHandler>();
        services.AddScoped<IRequestHandler<UpdateBranchServiceRequest, int>, UpdateBranchServiceRequestHandler>();

        #endregion
        #region BranchWorkingHour

        services.AddScoped<IRequestHandlerAsync<DeleteBranchWorkingHourRequest, string>, DeleteBranchWorkingHourRequestHandler>();
        services.AddScoped<IRequestHandler<AddBranchWorkingHourRequest, int>, AddBranchWorkingHourRequestHandler>();
        services.AddScoped<IRequestByIdHandler<BranchWorkingHourResponse>, BranchWorkingHourResponseHandler>();
        services.AddScoped<IRequestHandler<BranchWorkingHourAllRequest, List<BranchWorkingHourAllResponse>>, BranchWorkingHourAllResponseHandler>();
        services.AddScoped<IRequestHandler<UpdateBranchWorkingHourRequest, int>, UpdateBranchWorkingHourRequestHandler>();

        #endregion
        #region Branch

        services.AddScoped<IRequestHandlerAsync<DeleteBranchRequest, string>, DeleteBranchRequestHandler>();
        services.AddScoped<IRequestHandler<AddBranchRequest, int>, AddBranchRequestHandler>();
        services.AddScoped<IRequestByIdHandler<BranchResponse>, BranchResponseHandler>();
        services.AddScoped<IRequestHandler<BranchAllRequest, List<BranchAllResponse>>, BranchAllResponseHandler>();
        services.AddScoped<IRequestHandler<UpdateBranchRequest, int>, UpdateBranchRequestHandler>();

        #endregion

        #region EmployeeAccount

        services.AddScoped<IRequestHandlerAsync<DeleteEmployeeAccountRequest, string>, DeleteEmployeeAccountRequestHandler>();
        services.AddScoped<IRequestHandler<AddEmployeeAccountRequest, int>, AddEmployeeAccountRequestHandler>();
        services.AddScoped<IRequestByIdHandler<EmployeeAccountResponse>, EmployeeAccountResponseHandler>();
        services.AddScoped<IRequestHandler<EmployeeAccountAllRequest, List<EmployeeAccountAllResponse>>, EmployeeAccountAllResponseHandler>();
        services.AddScoped<IRequestHandler<UpdateEmployeeAccountRequest, int>, UpdateEmployeeAccountRequestHandler>();

        #endregion
        #region EmployeeAssignment

        services.AddScoped<IRequestHandlerAsync<DeleteEmployeeAssignmentRequest, string>, DeleteEmployeeAssignmentRequestHandler>();
        services.AddScoped<IRequestHandler<AddEmployeeAssignmentRequest, int>, AddEmployeeAssignmentRequestHandler>();
        services.AddScoped<IRequestByIdHandler<EmployeeAssignmentResponse>, EmployeeAssignmentResponseHandler>();
        services.AddScoped<IRequestHandler<EmployeeAssignmentAllRequest, List<EmployeeAssignmentAllResponse>>, EmployeeAssignmentAllResponseHandler>();
        services.AddScoped<IRequestHandler<UpdateEmployeeAssignmentRequest, int>, UpdateEmployeeAssignmentRequestHandler>();

        #endregion
        #region EmployeeCertification

        services.AddScoped<IRequestHandlerAsync<DeleteEmployeeCertificationRequest, string>, DeleteEmployeeCertificationRequestHandler>();
        services.AddScoped<IRequestHandler<AddEmployeeCertificationRequest, int>, AddEmployeeCertificationRequestHandler>();
        services.AddScoped<IRequestByIdHandler<EmployeeCertificationResponse>, EmployeeCertificationResponseHandler>();
        services.AddScoped<IRequestHandler<EmployeeCertificationAllRequest, List<EmployeeCertificationAllResponse>>, EmployeeCertificationAllResponseHandler>();
        services.AddScoped<IRequestHandler<UpdateEmployeeCertificationRequest, int>, UpdateEmployeeCertificationRequestHandler>();

        #endregion
        #region EmployeeJob

        services.AddScoped<IRequestHandlerAsync<DeleteEmployeeJobRequest, string>, DeleteEmployeeJobRequestHandler>();
        services.AddScoped<IRequestHandler<AddEmployeeJobRequest, int>, AddEmployeeJobRequestHandler>();
        services.AddScoped<IRequestByIdHandler<EmployeeJobResponse>, EmployeeJobResponseHandler>();
        services.AddScoped<IRequestHandler<EmployeeJobAllRequest, List<EmployeeJobAllResponse>>, EmployeeJobAllResponseHandler>();
        services.AddScoped<IRequestHandler<UpdateEmployeeJobRequest, int>, UpdateEmployeeJobRequestHandler>();

        #endregion
        #region Employee

        services.AddScoped<IRequestHandlerAsync<DeleteEmployeeRequest, string>, DeleteEmployeeRequestHandler>();
        services.AddScoped<IRequestHandler<AddEmployeeRequest, int>, AddEmployeeRequestHandler>();
        services.AddScoped<IRequestByIdHandler<EmployeeResponse>, EmployeeResponseHandler>();
        services.AddScoped<IRequestHandler<EmployeeAllRequest, List<EmployeeAllResponse>>, EmployeeAllResponseHandler>();
        services.AddScoped<IRequestHandler<UpdateEmployeeRequest, int>, UpdateEmployeeRequestHandler>();

        #endregion

        #region JobVerification

        services.AddScoped<IRequestHandlerAsync<DeleteJobVerificationRequest, string>, DeleteJobVerificationRequestHandler>();
        services.AddScoped<IRequestHandler<AddJobVerificationRequest, int>, AddJobVerificationRequestHandler>();
        services.AddScoped<IRequestByIdHandler<JobVerificationResponse>, JobVerificationResponseHandler>();
        services.AddScoped<IRequestHandler<JobVerificationAllRequest, List<JobVerificationAllResponse>>, JobVerificationAllResponseHandler>();
        services.AddScoped<IRequestHandler<UpdateJobVerificationRequest, int>, UpdateJobVerificationRequestHandler>();

        #endregion
        #region Job

        services.AddScoped<IRequestHandlerAsync<DeleteJobRequest, string>, DeleteJobRequestHandler>();
        services.AddScoped<IRequestHandler<AddJobRequest, int>, AddJobRequestHandler>();
        services.AddScoped<IRequestByIdHandler<JobResponse>, JobResponseHandler>();
        services.AddScoped<IRequestHandler<JobAllRequest, List<JobAllResponse>>, JobAllResponseHandler>();
        services.AddScoped<IRequestHandler<UpdateJobRequest, int>, UpdateJobRequestHandler>();

        #endregion

        #region Criteria

        services.AddScoped<IRequestHandlerAsync<DeleteCriteriaRequest, string>, DeleteCriteriaRequestHandler>();
        services.AddScoped<IRequestHandler<AddCriteriaRequest, int>, AddCriteriaRequestHandler>();
        services.AddScoped<IRequestByIdHandler<CriteriaResponse>, CriteriaResponseHandler>();
        services.AddScoped<IRequestHandler<CriteriaAllRequest, List<CriteriaAllResponse>>, CriteriaAllResponseHandler>();
        services.AddScoped<IRequestHandler<UpdateCriteriaRequest, int>, UpdateCriteriaRequestHandler>();

        #endregion
        #region OfferItem

        services.AddScoped<IRequestHandlerAsync<DeleteOfferItemRequest, string>, DeleteOfferItemRequestHandler>();
        services.AddScoped<IRequestHandler<AddOfferItemRequest, int>, AddOfferItemRequestHandler>();
        services.AddScoped<IRequestByIdHandler<OfferItemResponse>, OfferItemResponseHandler>();
        services.AddScoped<IRequestHandler<OfferItemAllRequest, List<OfferItemAllResponse>>, OfferItemAllResponseHandler>();
        services.AddScoped<IRequestHandler<UpdateOfferItemRequest, int>, UpdateOfferItemRequestHandler>();

        #endregion
        #region OfferObject

        services.AddScoped<IRequestHandlerAsync<DeleteOfferObjectRequest, string>, DeleteOfferObjectRequestHandler>();
        services.AddScoped<IRequestHandler<AddOfferObjectRequest, int>, AddOfferObjectRequestHandler>();
        services.AddScoped<IRequestByIdHandler<OfferObjectResponse>, OfferObjectResponseHandler>();
        services.AddScoped<IRequestHandler<OfferObjectAllRequest, List<OfferObjectAllResponse>>, OfferObjectAllResponseHandler>();
        services.AddScoped<IRequestHandler<UpdateOfferObjectRequest, int>, UpdateOfferObjectRequestHandler>();

        #endregion
        #region Offer

        services.AddScoped<IRequestHandlerAsync<DeleteOfferRequest, string>, DeleteOfferRequestHandler>();
        services.AddScoped<IRequestHandler<AddOfferRequest, int>, AddOfferRequestHandler>();
        services.AddScoped<IRequestByIdHandler<OfferResponse>, OfferResponseHandler>();
        services.AddScoped<IRequestHandler<OfferAllRequest, List<OfferAllResponse>>, OfferAllResponseHandler>();
        services.AddScoped<IRequestHandler<UpdateOfferRequest, int>, UpdateOfferRequestHandler>();

        #endregion

        #region EmployeeService

        services.AddScoped<IRequestHandlerAsync<DeleteEmployeeServiceRequest, string>, DeleteEmployeeServiceRequestHandler>();
        services.AddScoped<IRequestHandler<AddEmployeeServiceRequest, int>, AddEmployeeServiceRequestHandler>();
        services.AddScoped<IRequestByIdHandler<EmployeeServiceResponse>, EmployeeServiceResponseHandler>();
        services.AddScoped<IRequestHandler<EmployeeServiceAllRequest, List<EmployeeServiceAllResponse>>, EmployeeServiceAllResponseHandler>();
        services.AddScoped<IRequestHandler<UpdateEmployeeServiceRequest, int>, UpdateEmployeeServiceRequestHandler>();

        #endregion
        #region Service

        services.AddScoped<IRequestHandlerAsync<DeleteServiceRequest, string>, DeleteServiceRequestHandler>();
        services.AddScoped<IRequestHandler<AddServiceRequest, int>, AddServiceRequestHandler>();
        services.AddScoped<IRequestByIdHandler<ServiceResponse>, ServiceResponseHandler>();
        services.AddScoped<IRequestHandler<ServiceAllRequest, List<ServiceAllResponse>>, ServiceAllResponseHandler>();
        services.AddScoped<IRequestHandler<UpdateServiceRequest, int>, UpdateServiceRequestHandler>();

        #endregion
        #region TimeSlot

        services.AddScoped<IRequestHandlerAsync<DeleteTimeSlotRequest, string>, DeleteTimeSlotRequestHandler>();
        services.AddScoped<IRequestHandler<AddTimeSlotRequest, int>, AddTimeSlotRequestHandler>();
        services.AddScoped<IRequestByIdHandler<TimeSlotResponse>, TimeSlotResponseHandler>();
        services.AddScoped<IRequestHandler<TimeSlotAllRequest, List<TimeSlotAllResponse>>, TimeSlotAllResponseHandler>();
        services.AddScoped<IRequestHandler<UpdateTimeSlotRequest, int>, UpdateTimeSlotRequestHandler>();

        #endregion

        #region Group

        services.AddScoped<IRequestHandlerAsync<DeleteGroupRequest, string>, DeleteGroupRequestHandler>();
        services.AddScoped<IRequestHandler<AddGroupRequest, int>, AddGroupRequestHandler>();
        services.AddScoped<IRequestByIdHandler<GroupResponse>, GroupResponseHandler>();
        services.AddScoped<IRequestHandler<GroupAllRequest, List<GroupAllResponse>>, GroupAllResponseHandler>();
        services.AddScoped<IRequestHandler<UpdateGroupRequest, int>, UpdateGroupRequestHandler>();

        #endregion
        #region RoleClaim

        services.AddScoped<IRequestHandlerAsync<DeleteRoleClaimRequest, string>, DeleteRoleClaimRequestHandler>();
        services.AddScoped<IRequestHandler<AddRoleClaimRequest, int>, AddRoleClaimRequestHandler>();
        services.AddScoped<IRequestByIdHandler<RoleClaimResponse>, RoleClaimResponseHandler>();
        services.AddScoped<IRequestHandler<RoleClaimAllRequest, List<RoleClaimAllResponse>>, RoleClaimAllResponseHandler>();
        services.AddScoped<IRequestHandler<UpdateRoleClaimRequest, int>, UpdateRoleClaimRequestHandler>();

        #endregion
        #region Role

        services.AddScoped<IRequestHandlerAsync<DeleteRoleRequest, string>, DeleteRoleRequestHandler>();
        services.AddScoped<IRequestHandler<AddRoleRequest, int>, AddRoleRequestHandler>();
        services.AddScoped<IRequestByIdHandler<RoleResponse>, RoleResponseHandler>();
        services.AddScoped<IRequestHandler<RoleAllRequest, List<RoleAllResponse>>, RoleAllResponseHandler>();
        services.AddScoped<IRequestHandler<UpdateRoleRequest, int>, UpdateRoleRequestHandler>();

        #endregion
        #region UserClaim

        services.AddScoped<IRequestHandlerAsync<DeleteUserClaimRequest, string>, DeleteUserClaimRequestHandler>();
        services.AddScoped<IRequestHandler<AddUserClaimRequest, int>, AddUserClaimRequestHandler>();
        services.AddScoped<IRequestByIdHandler<UserClaimResponse>, UserClaimResponseHandler>();
        services.AddScoped<IRequestHandler<UserClaimAllRequest, List<UserClaimAllResponse>>, UserClaimAllResponseHandler>();
        services.AddScoped<IRequestHandler<UpdateUserClaimRequest, int>, UpdateUserClaimRequestHandler>();

        #endregion
        #region UserLogin

        services.AddScoped<IRequestHandlerAsync<DeleteUserLoginRequest, string>, DeleteUserLoginRequestHandler>();
        services.AddScoped<IRequestHandler<AddUserLoginRequest, int>, AddUserLoginRequestHandler>();
        services.AddScoped<IRequestByIdHandler<UserLoginResponse>, UserLoginResponseHandler>();
        services.AddScoped<IRequestHandler<UserLoginAllRequest, List<UserLoginAllResponse>>, UserLoginAllResponseHandler>();
        services.AddScoped<IRequestHandler<UpdateUserLoginRequest, int>, UpdateUserLoginRequestHandler>();

        #endregion
        #region UserRefreshToken

        services.AddScoped<IRequestHandlerAsync<DeleteUserRefreshTokenRequest, string>, DeleteUserRefreshTokenRequestHandler>();
        services.AddScoped<IRequestHandler<AddUserRefreshTokenRequest, Guid>, AddUserRefreshTokenRequestHandler>();
        services.AddScoped<IRequestByIdHandler<UserRefreshTokenResponse>, UserRefreshTokenResponseHandler>();
        services.AddScoped<IRequestHandler<UserRefreshTokenAllRequest, List<UserRefreshTokenAllResponse>>, UserRefreshTokenAllResponseHandler>();
        services.AddScoped<IRequestHandler<UpdateUserRefreshTokenRequest, Guid>, UpdateUserRefreshTokenRequestHandler>();

        #endregion
        #region UserRole

        services.AddScoped<IRequestHandlerAsync<DeleteUserRoleRequest, string>, DeleteUserRoleRequestHandler>();
        services.AddScoped<IRequestHandler<AddUserRoleRequest, int>, AddUserRoleRequestHandler>();
        services.AddScoped<IRequestByIdHandler<UserRoleResponse>, UserRoleResponseHandler>();
        services.AddScoped<IRequestHandler<UserRoleAllRequest, List<UserRoleAllResponse>>, UserRoleAllResponseHandler>();
        services.AddScoped<IRequestHandler<UpdateUserRoleRequest, int>, UpdateUserRoleRequestHandler>();

        #endregion
        #region UserToken

        services.AddScoped<IRequestHandlerAsync<DeleteUserTokenRequest, string>, DeleteUserTokenRequestHandler>();
        services.AddScoped<IRequestHandler<AddUserTokenRequest, int>, AddUserTokenRequestHandler>();
        services.AddScoped<IRequestByIdHandler<UserTokenResponse>, UserTokenResponseHandler>();
        services.AddScoped<IRequestHandler<UserTokenAllRequest, List<UserTokenAllResponse>>, UserTokenAllResponseHandler>();
        services.AddScoped<IRequestHandler<UpdateUserTokenRequest, int>, UpdateUserTokenRequestHandler>();

        #endregion
        #region User

        services.AddScoped<IRequestHandlerAsync<DeleteUserRequest, string>, DeleteUserRequestHandler>();
        services.AddScoped<IRequestHandler<AddUserRequest, int>, AddUserRequestHandler>();
        services.AddScoped<IRequestByIdHandler<UserResponse>, UserResponseHandler>();
        services.AddScoped<IRequestHandler<UserAllRequest, List<UserAllResponse>>, UserAllResponseHandler>();
        services.AddScoped<IRequestHandler<UpdateUserRequest, int>, UpdateUserRequestHandler>();

        #endregion
        #region UserGroup

        services.AddScoped<IRequestHandlerAsync<DeleteUserGroupRequest, string>, DeleteUserGroupRequestHandler>();
        services.AddScoped<IRequestHandler<AddUserGroupRequest, int>, AddUserGroupRequestHandler>();
        services.AddScoped<IRequestByIdHandler<UserGroupResponse>, UserGroupResponseHandler>();
        services.AddScoped<IRequestHandler<UserGroupAllRequest, List<UserGroupAllResponse>>, UserGroupAllResponseHandler>();
        services.AddScoped<IRequestHandler<UpdateUserGroupRequest, int>, UpdateUserGroupRequestHandler>();

        #endregion
        #region Inventory

        services.AddScoped<IRequestHandlerAsync<DeleteInventoryRequest, string>, DeleteInventoryRequestHandler>();
        services.AddScoped<IRequestHandler<AddInventoryRequest, int>, AddInventoryRequestHandler>();
        services.AddScoped<IRequestByIdHandler<InventoryResponse>, InventoryResponseHandler>();
        services.AddScoped<IRequestHandler<InventoryAllRequest, List<InventoryAllResponse>>, InventoryAllResponseHandler>();
        services.AddScoped<IRequestHandler<UpdateInventoryRequest, int>, UpdateInventoryRequestHandler>();

        #endregion
        #region StorageUnit

        services.AddScoped<IRequestHandlerAsync<DeleteStorageUnitRequest, string>, DeleteStorageUnitRequestHandler>();
        services.AddScoped<IRequestHandler<AddStorageUnitRequest, int>, AddStorageUnitRequestHandler>();
        services.AddScoped<IRequestByIdHandler<StorageUnitResponse>, StorageUnitResponseHandler>();
        services.AddScoped<IRequestHandler<StorageUnitAllRequest, List<StorageUnitAllResponse>>, StorageUnitAllResponseHandler>();
        services.AddScoped<IRequestHandler<UpdateStorageUnitRequest, int>, UpdateStorageUnitRequestHandler>();

        #endregion
        #region Item

        services.AddScoped<IRequestHandlerAsync<DeleteItemRequest, string>, DeleteItemRequestHandler>();
        services.AddScoped<IRequestHandler<AddItemRequest, int>, AddItemRequestHandler>();
        services.AddScoped<IRequestByIdHandler<ItemResponse>, ItemResponseHandler>();
        services.AddScoped<IRequestHandler<ItemAllRequest, List<ItemAllResponse>>, ItemAllResponseHandler>();
        services.AddScoped<IRequestHandler<UpdateItemRequest, int>, UpdateItemRequestHandler>();

        #endregion
        #region PortionItem

        services.AddScoped<IRequestHandlerAsync<DeletePortionItemRequest, string>, DeletePortionItemRequestHandler>();
        services.AddScoped<IRequestHandler<AddPortionItemRequest, int>, AddPortionItemRequestHandler>();
        services.AddScoped<IRequestByIdHandler<PortionItemResponse>, PortionItemResponseHandler>();
        services.AddScoped<IRequestHandler<PortionItemAllRequest, List<PortionItemAllResponse>>, PortionItemAllResponseHandler>();
        services.AddScoped<IRequestHandler<UpdatePortionItemRequest, int>, UpdatePortionItemRequestHandler>();

        #endregion
        #region PortionType

        services.AddScoped<IRequestHandlerAsync<DeletePortionTypeRequest, string>, DeletePortionTypeRequestHandler>();
        services.AddScoped<IRequestHandler<AddPortionTypeRequest, int>, AddPortionTypeRequestHandler>();
        services.AddScoped<IRequestByIdHandler<PortionTypeResponse>, PortionTypeResponseHandler>();
        services.AddScoped<IRequestHandler<PortionTypeAllRequest, List<PortionTypeAllResponse>>, PortionTypeAllResponseHandler>();
        services.AddScoped<IRequestHandler<UpdatePortionTypeRequest, int>, UpdatePortionTypeRequestHandler>();

        #endregion
        #region Portion

        services.AddScoped<IRequestHandlerAsync<DeletePortionRequest, string>, DeletePortionRequestHandler>();
        services.AddScoped<IRequestHandler<AddPortionRequest, int>, AddPortionRequestHandler>();
        services.AddScoped<IRequestByIdHandler<PortionResponse>, PortionResponseHandler>();
        services.AddScoped<IRequestHandler<PortionAllRequest, List<PortionAllResponse>>, PortionAllResponseHandler>();
        services.AddScoped<IRequestHandler<UpdatePortionRequest, int>, UpdatePortionRequestHandler>();

        #endregion
        #region PaymentMethod

        services.AddScoped<IRequestHandlerAsync<DeletePaymentMethodRequest, string>, DeletePaymentMethodRequestHandler>();
        services.AddScoped<IRequestHandler<AddPaymentMethodRequest, int>, AddPaymentMethodRequestHandler>();
        services.AddScoped<IRequestByIdHandler<PaymentMethodResponse>, PaymentMethodResponseHandler>();
        services.AddScoped<IRequestHandler<PaymentMethodAllRequest, List<PaymentMethodAllResponse>>, PaymentMethodAllResponseHandler>();
        services.AddScoped<IRequestHandler<UpdatePaymentMethodRequest, int>, UpdatePaymentMethodRequestHandler>();

        #endregion
        #region Transaction

        services.AddScoped<IRequestHandlerAsync<DeleteTransactionRequest, string>, DeleteTransactionRequestHandler>();
        services.AddScoped<IRequestHandler<AddTransactionRequest, int>, AddTransactionRequestHandler>();
        services.AddScoped<IRequestByIdHandler<TransactionResponse>, TransactionResponseHandler>();
        services.AddScoped<IRequestHandler<TransactionAllRequest, List<TransactionAllResponse>>, TransactionAllResponseHandler>();
        services.AddScoped<IRequestHandler<UpdateTransactionRequest, int>, UpdateTransactionRequestHandler>();

        #endregion
        #region Part

        services.AddScoped<IRequestHandlerAsync<DeletePartRequest, string>, DeletePartRequestHandler>();
        services.AddScoped<IRequestHandler<AddPartRequest, int>, AddPartRequestHandler>();
        services.AddScoped<IRequestByIdHandler<PartResponse>, PartResponseHandler>();
        services.AddScoped<IRequestHandler<PartAllRequest, List<PartAllResponse>>, PartAllResponseHandler>();
        services.AddScoped<IRequestHandler<UpdatePartRequest, int>, UpdatePartRequestHandler>();

        #endregion
        #region Product

        services.AddScoped<IRequestHandlerAsync<DeleteProductRequest, string>, DeleteProductRequestHandler>();
        services.AddScoped<IRequestHandler<AddProductRequest, int>, AddProductRequestHandler>();
        services.AddScoped<IRequestByIdHandler<ProductResponse>, ProductResponseHandler>();
        services.AddScoped<IRequestHandler<ProductAllRequest, List<ProductAllResponse>>, ProductAllResponseHandler>();
        services.AddScoped<IRequestHandler<UpdateProductRequest, int>, UpdateProductRequestHandler>();

        #endregion
        #region SparePart

        services.AddScoped<IRequestHandlerAsync<DeleteSparePartRequest, string>, DeleteSparePartRequestHandler>();
        services.AddScoped<IRequestHandler<AddSparePartRequest, int>, AddSparePartRequestHandler>();
        services.AddScoped<IRequestByIdHandler<SparePartResponse>, SparePartResponseHandler>();
        services.AddScoped<IRequestHandler<SparePartAllRequest, List<SparePartAllResponse>>, SparePartAllResponseHandler>();
        services.AddScoped<IRequestHandler<UpdateSparePartRequest, int>, UpdateSparePartRequestHandler>();

        #endregion
        #region Spare

        services.AddScoped<IRequestHandlerAsync<DeleteSpareRequest, string>, DeleteSpareRequestHandler>();
        services.AddScoped<IRequestHandler<AddSpareRequest, int>, AddSpareRequestHandler>();
        services.AddScoped<IRequestByIdHandler<SpareResponse>, SpareResponseHandler>();
        services.AddScoped<IRequestHandler<SpareAllRequest, List<SpareAllResponse>>, SpareAllResponseHandler>();
        services.AddScoped<IRequestHandler<UpdateSpareRequest, int>, UpdateSpareRequestHandler>();

        #endregion
        #region Category

        services.AddScoped<IRequestHandlerAsync<DeleteCategoryRequest, string>, DeleteCategoryRequestHandler>();
        services.AddScoped<IRequestHandler<AddCategoryRequest, int>, AddCategoryRequestHandler>();
        services.AddScoped<IRequestByIdHandler<CategoryResponse>, CategoryResponseHandler>();
        services.AddScoped<IRequestHandler<CategoryAllRequest, List<CategoryAllResponse>>, CategoryAllResponseHandler>();
        services.AddScoped<IRequestHandler<UpdateCategoryRequest, int>, UpdateCategoryRequestHandler>();

        #endregion
        #region Attachment

        services.AddScoped<IRequestHandlerAsync<DeleteAttachmentRequest, string>, DeleteAttachmentRequestHandler>();
        services.AddScoped<IRequestHandler<AddAttachmentRequest, int>, AddAttachmentRequestHandler>();
        services.AddScoped<IRequestByIdHandler<AttachmentResponse>, AttachmentResponseHandler>();
        services.AddScoped<IRequestHandler<AttachmentAllRequest, List<AttachmentAllResponse>>, AttachmentAllResponseHandler>();
        services.AddScoped<IRequestHandler<UpdateAttachmentRequest, int>, UpdateAttachmentRequestHandler>();

        #endregion
        #region EmailLog

        services.AddScoped<IRequestHandlerAsync<DeleteEmailLogRequest, string>, DeleteEmailLogRequestHandler>();
        services.AddScoped<IRequestHandler<AddEmailLogRequest, int>, AddEmailLogRequestHandler>();
        services.AddScoped<IRequestByIdHandler<EmailLogResponse>, EmailLogResponseHandler>();
        services.AddScoped<IRequestHandler<EmailLogAllRequest, List<EmailLogAllResponse>>, EmailLogAllResponseHandler>();
        services.AddScoped<IRequestHandler<UpdateEmailLogRequest, int>, UpdateEmailLogRequestHandler>();

        #endregion
        #region Recipient

        services.AddScoped<IRequestHandlerAsync<DeleteRecipientRequest, string>, DeleteRecipientRequestHandler>();
        services.AddScoped<IRequestHandler<AddRecipientRequest, int>, AddRecipientRequestHandler>();
        services.AddScoped<IRequestByIdHandler<RecipientResponse>, RecipientResponseHandler>();
        services.AddScoped<IRequestHandler<RecipientAllRequest, List<RecipientAllResponse>>, RecipientAllResponseHandler>();
        services.AddScoped<IRequestHandler<UpdateRecipientRequest, int>, UpdateRecipientRequestHandler>();

        #endregion
        #region FileFieldValidator

        services.AddScoped<IRequestHandlerAsync<DeleteFileFieldValidatorRequest, string>, DeleteFileFieldValidatorRequestHandler>();
        services.AddScoped<IRequestHandler<AddFileFieldValidatorRequest, int>, AddFileFieldValidatorRequestHandler>();
        services.AddScoped<IRequestByIdHandler<FileFieldValidatorResponse>, FileFieldValidatorResponseHandler>();
        services.AddScoped<IRequestHandler<FileFieldValidatorAllRequest, List<FileFieldValidatorAllResponse>>, FileFieldValidatorAllResponseHandler>();
        services.AddScoped<IRequestHandler<UpdateFileFieldValidatorRequest, int>, UpdateFileFieldValidatorRequestHandler>();

        #endregion
        #region FileLog

        services.AddScoped<IRequestHandlerAsync<DeleteFileLogRequest, string>, DeleteFileLogRequestHandler>();
        services.AddScoped<IRequestHandler<AddFileLogRequest, int>, AddFileLogRequestHandler>();
        services.AddScoped<IRequestByIdHandler<FileLogResponse>, FileLogResponseHandler>();
        services.AddScoped<IRequestHandler<FileLogAllRequest, List<FileLogAllResponse>>, FileLogAllResponseHandler>();
        services.AddScoped<IRequestHandler<UpdateFileLogRequest, int>, UpdateFileLogRequestHandler>();

        #endregion
        #region FileType

        services.AddScoped<IRequestHandlerAsync<DeleteFileTypeRequest, string>, DeleteFileTypeRequestHandler>();
        services.AddScoped<IRequestHandler<AddFileTypeRequest, int>, AddFileTypeRequestHandler>();
        services.AddScoped<IRequestByIdHandler<FileTypeResponse>, FileTypeResponseHandler>();
        services.AddScoped<IRequestHandler<FileTypeAllRequest, List<FileTypeAllResponse>>, FileTypeAllResponseHandler>();
        services.AddScoped<IRequestHandler<UpdateFileTypeRequest, int>, UpdateFileTypeRequestHandler>();

        #endregion
        #region Logging

        services.AddScoped<IRequestHandlerAsync<DeleteLoggingRequest, string>, DeleteLoggingRequestHandler>();
        services.AddScoped<IRequestHandler<AddLoggingRequest, int>, AddLoggingRequestHandler>();
        services.AddScoped<IRequestByIdHandler<LoggingResponse>, LoggingResponseHandler>();
        services.AddScoped<IRequestHandler<LoggingAllRequest, List<LoggingAllResponse>>, LoggingAllResponseHandler>();
        services.AddScoped<IRequestHandler<UpdateLoggingRequest, int>, UpdateLoggingRequestHandler>();

        #endregion
        #region NotificationDetail

        services.AddScoped<IRequestHandlerAsync<DeleteNotificationDetailRequest, string>, DeleteNotificationDetailRequestHandler>();
        services.AddScoped<IRequestHandler<AddNotificationDetailRequest, int>, AddNotificationDetailRequestHandler>();
        services.AddScoped<IRequestByIdHandler<NotificationDetailResponse>, NotificationDetailResponseHandler>();
        services.AddScoped<IRequestHandler<NotificationDetailAllRequest, List<NotificationDetailAllResponse>>, NotificationDetailAllResponseHandler>();
        services.AddScoped<IRequestHandler<UpdateNotificationDetailRequest, int>, UpdateNotificationDetailRequestHandler>();

        #endregion
        #region Notification

        services.AddScoped<IRequestHandlerAsync<DeleteNotificationRequest, string>, DeleteNotificationRequestHandler>();
        services.AddScoped<IRequestHandler<AddNotificationRequest, int>, AddNotificationRequestHandler>();
        services.AddScoped<IRequestByIdHandler<NotificationResponse>, NotificationResponseHandler>();
        services.AddScoped<IRequestHandler<NotificationAllRequest, List<NotificationAllResponse>>, NotificationAllResponseHandler>();
        services.AddScoped<IRequestHandler<UpdateNotificationRequest, int>, UpdateNotificationRequestHandler>();

        #endregion
        #region TranslationKey

        services.AddScoped<IRequestHandlerAsync<DeleteTranslationKeyRequest, string>, DeleteTranslationKeyRequestHandler>();
        services.AddScoped<IRequestHandler<AddTranslationKeyRequest, int>, AddTranslationKeyRequestHandler>();
        services.AddScoped<IRequestByIdHandler<TranslationKeyResponse>, TranslationKeyResponseHandler>();
        services.AddScoped<IRequestHandler<TranslationKeyAllRequest, List<TranslationKeyAllResponse>>, TranslationKeyAllResponseHandler>();
        services.AddScoped<IRequestHandler<UpdateTranslationKeyRequest, int>, UpdateTranslationKeyRequestHandler>();

        #endregion
        #region Zone

        services.AddScoped<IRequestHandlerAsync<DeleteZoneRequest, string>, DeleteZoneRequestHandler>();
        services.AddScoped<IRequestHandler<AddZoneRequest, int>, AddZoneRequestHandler>();
        services.AddScoped<IRequestByIdHandler<ZoneResponse>, ZoneResponseHandler>();
        services.AddScoped<IRequestHandler<ZoneAllRequest, List<ZoneAllResponse>>, ZoneAllResponseHandler>();
        services.AddScoped<IRequestHandler<UpdateZoneRequest, int>, UpdateZoneRequestHandler>();

        #endregion
        #region ActionActor

        services.AddScoped<IRequestHandlerAsync<DeleteActionActorRequest, string>, DeleteActionActorRequestHandler>();
        services.AddScoped<IRequestHandler<AddActionActorRequest, int>, AddActionActorRequestHandler>();
        services.AddScoped<IRequestByIdHandler<ActionActorResponse>, ActionActorResponseHandler>();
        services.AddScoped<IRequestHandler<ActionActorAllRequest, List<ActionActorAllResponse>>, ActionActorAllResponseHandler>();
        services.AddScoped<IRequestHandler<UpdateActionActorRequest, int>, UpdateActionActorRequestHandler>();

        #endregion
        #region ActionObject

        services.AddScoped<IRequestHandlerAsync<DeleteActionObjectRequest, string>, DeleteActionObjectRequestHandler>();
        services.AddScoped<IRequestHandler<AddActionObjectRequest, int>, AddActionObjectRequestHandler>();
        services.AddScoped<IRequestByIdHandler<ActionObjectResponse>, ActionObjectResponseHandler>();
        services.AddScoped<IRequestHandler<ActionObjectAllRequest, List<ActionObjectAllResponse>>, ActionObjectAllResponseHandler>();
        services.AddScoped<IRequestHandler<UpdateActionObjectRequest, int>, UpdateActionObjectRequestHandler>();

        #endregion
        #region Actor

        services.AddScoped<IRequestHandlerAsync<DeleteActorRequest, string>, DeleteActorRequestHandler>();
        services.AddScoped<IRequestHandler<AddActorRequest, int>, AddActorRequestHandler>();
        services.AddScoped<IRequestByIdHandler<ActorResponse>, ActorResponseHandler>();
        services.AddScoped<IRequestHandler<ActorAllRequest, List<ActorAllResponse>>, ActorAllResponseHandler>();
        services.AddScoped<IRequestHandler<UpdateActorRequest, int>, UpdateActorRequestHandler>();

        #endregion
        #region CaseAction

        services.AddScoped<IRequestHandlerAsync<DeleteCaseActionRequest, string>, DeleteCaseActionRequestHandler>();
        services.AddScoped<IRequestHandler<AddCaseActionRequest, int>, AddCaseActionRequestHandler>();
        services.AddScoped<IRequestByIdHandler<CaseActionResponse>, CaseActionResponseHandler>();
        services.AddScoped<IRequestHandler<CaseActionAllRequest, List<CaseActionAllResponse>>, CaseActionAllResponseHandler>();
        services.AddScoped<IRequestHandler<UpdateCaseActionRequest, int>, UpdateCaseActionRequestHandler>();

        #endregion
        #region Case

        services.AddScoped<IRequestHandlerAsync<DeleteCaseRequest, string>, DeleteCaseRequestHandler>();
        services.AddScoped<IRequestHandler<AddCaseRequest, int>, AddCaseRequestHandler>();
        services.AddScoped<IRequestByIdHandler<CaseResponse>, CaseResponseHandler>();
        services.AddScoped<IRequestHandler<CaseAllRequest, List<CaseAllResponse>>, CaseAllResponseHandler>();
        services.AddScoped<IRequestHandler<UpdateCaseRequest, int>, UpdateCaseRequestHandler>();

        #endregion
        #region WorkflowCycle

        services.AddScoped<IRequestHandlerAsync<DeleteWorkflowCycleRequest, string>, DeleteWorkflowCycleRequestHandler>();
        services.AddScoped<IRequestHandler<AddWorkflowCycleRequest, int>, AddWorkflowCycleRequestHandler>();
        services.AddScoped<IRequestByIdHandler<WorkflowCycleResponse>, WorkflowCycleResponseHandler>();
        services.AddScoped<IRequestHandler<WorkflowCycleAllRequest, List<WorkflowCycleAllResponse>>, WorkflowCycleAllResponseHandler>();
        services.AddScoped<IRequestHandler<UpdateWorkflowCycleRequest, int>, UpdateWorkflowCycleRequestHandler>();

        #endregion
        #region Workflow

        services.AddScoped<IRequestHandlerAsync<DeleteWorkflowRequest, string>, DeleteWorkflowRequestHandler>();
        services.AddScoped<IRequestHandler<AddWorkflowRequest, int>, AddWorkflowRequestHandler>();
        services.AddScoped<IRequestByIdHandler<WorkflowResponse>, WorkflowResponseHandler>();
        services.AddScoped<IRequestHandler<WorkflowAllRequest, List<WorkflowAllResponse>>, WorkflowAllResponseHandler>();
        services.AddScoped<IRequestHandler<UpdateWorkflowRequest, int>, UpdateWorkflowRequestHandler>();
        #endregion

        return services;
    }
    public static void ConfigureGrpcPipeline(this WebApplication app)
    {

    }
}
