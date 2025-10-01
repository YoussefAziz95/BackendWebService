# Application Layer Components Catalog

## Overview

This document provides a comprehensive inventory of all Application layer components in the BackendWebService project, categorized by type and prioritized for testing.

## Component Categories

### 1. Feature Handlers (Commands/Queries)

#### AdministrationModule
- **CompanyFeature**
  - Company (11 files): Add, Update, Delete, Get operations
  - CompanyCategory (11 files): CRUD operations
  - Manager (12 files): Manager management operations
- **ConsumerFeature**
  - Consumer (12 files): Consumer management
  - ConsumerAccount (12 files): Account management
  - ConsumerCustomer (12 files): Customer relationships
  - ConsumerDocument (12 files): Document management
- **Identity** (Authentication & Authorization)
  - ConfirmPhoneNumber (2 files)
  - ConfirmResetPassword (2 files)
  - ExternalLogin (2 files)
  - Login (1 file)
  - LoginAuthenticator (2 files)
  - LoginEmail (2 files)
  - LoginPhone (2 files)
  - Mfa (2 files)
  - MfaVerify (2 files)
  - OtpVerify (2 files)
  - PhoneNumber (2 files)
  - RecoveryCode (2 files)
  - RefreshToken (3 files)
  - ResetPassword (2 files)
  - ResetPasswordAuth (2 files)
  - RoleAssign (2 files)
  - SignUp (2 files)
  - TwoFactor (2 files)
  - VerifyEmail (2 files)
- **OrganizationFeature**
  - Address (12 files)
  - Administrator (12 files)
  - Contact (12 files)
  - Department (12 files)
  - GoogleConfig (12 files)
  - LDAPConfig (12 files)
  - MicrosoftConfig (12 files)
  - Organization (12 files)
- **SupplierFeature**
  - PreDocument (12 files)
  - Supplier (13 files)
  - SupplierAccount (12 files)
  - SupplierCategory (12 files)
  - SupplierDocument (12 files)

#### ClientModule
- **ClientFeature**
  - Client (12 files)
  - ClientAccount (12 files)
  - ClientProperty (12 files)
  - ClientService (12 files)
- **DealFeature**
  - Deal (12 files)
  - DealDetails (12 files)
  - DealDocument (13 files)
  - GetOfferDealDetails (4 files)
- **PropertyFeature**
  - Property (13 files)

#### CustomerModule
- **Customers**
  - Customer (12 files)
  - CustomerPaymentMethod (12 files)
  - CustomerService (17 files)
- **OrderCQRS**
  - AddOrder (2 files)
  - DeleteUserOrders (2 files)
  - GetAllOrders (3 files)
  - GetUserOrders (3 files)
  - UpdateUserOrder (2 files)
- **Orders**
  - Order (12 files)
  - OrderItem (12 files)
  - Receipt (12 files)

#### EmployeeModule
- **BrancheFeature**
  - Branch (12 files)
  - BranchContact (12 files)
  - BranchEmployee (12 files)
  - BranchLocation (12 files)
  - BranchService (12 files)
  - BranchWorkingHour (12 files)
- **EmployeeFeature**
  - Employee (12 files)
  - EmployeeAccount (12 files)
  - EmployeeAssignment (12 files)
  - EmployeeCertification (12 files)
  - EmployeeJob (12 files)
- **JobFeature**
  - Job (12 files)
  - JobVerification (12 files)
- **OfferFeature**
  - Criteria (12 files)
  - Offer (14 files)
  - OfferItem (12 files)
  - OfferObject (12 files)
- **ServiceFeature**
  - EmployeeService (12 files)
  - Service (12 files)
  - TimeSlot (12 files)

#### IdentityModule
- **GroupFeature**
  - AddGroup (2 files)
  - DeleteGroup (2 files)
  - GetGroup (3 files)
  - GetGroupAll (3 files)
  - UpdateGroupContact (2 files)
- **RoleClaimFeature**
  - AddRoleClaim (2 files)
  - DeleteRoleClaim (2 files)
  - GetRoleClaim (2 files)
  - GetRoleClaimAll (3 files)
  - UpdateRoleClaimContact (2 files)
- **RoleFeature**
  - AddRole (2 files)
  - DeleteRole (2 files)
  - GetRole (3 files)
  - GetRoleAll (3 files)
  - UpdateRoleContact (2 files)
- **UserClaimFeature**
  - AddUserClaim (2 files)
  - DeleteUserClaim (2 files)
  - GetUserClaim (3 files)
  - GetUserClaimAll (3 files)
  - UpdateUserClaimContact (2 files)
- **UserFeature**
  - User (16 files)
  - UserLogin (12 files)
  - UserRefreshToken (12 files)
  - UserRole (12 files)
  - UserToken (12 files)
- **UserGroupFeature**
  - AddUserGroup (2 files)
  - DeleteUserGroup (2 files)
  - GetUserGroup (3 files)
  - GetUserGroupAll (3 files)
  - UpdateUserGroupContact (2 files)

#### InventoryModule
- **InventoryFeature**
  - Inventory (12 files)
  - StorageUnit (12 files)
- **ItemFeature**
  - Item (12 files)
  - Portion (12 files)
  - PortionItem (12 files)
  - PortionType (12 files)
- **PaymentMethodFeature**
  - PaymentMethod (12 files)
  - Transaction (12 files)
- **ProductFeature**
  - Part (12 files)
  - Product (12 files)
  - Spare (12 files)
  - SparePart (12 files)

#### SystemModule
- **CategoryFeature**
  - AddCategory (2 files)
  - CategoryHasChild (1 file)
  - CategoryWithFile (1 file)
  - DeleteCategory (2 files)
  - GetCategory (3 files)
  - GetCategoryAll (3 files)
  - UpdateCategory (2 files)
- **EmailFeature**
  - Attachment (12 files)
  - EmailLog (12 files)
  - Recipient (12 files)
- **FileFeature**
  - File (3 files)
  - FileFieldValidator (12 files)
  - FileLog (12 files)
  - FileType (12 files)
- **LoggingFeature** (12 files)
- **NotificationFeature**
  - Notification (13 files)
  - NotificationDetail (12 files)
- **TranslationKeyFeature** (12 files)
- **ZoneFeature** (12 files)

#### WorkflowModule
- **ActorFeature** (36 files)
- **CaseFeature**
  - Case (12 files)
  - CaseAction (12 files)
- **WorkflowCQRS** (1 file)
- **WorklfowFeature** (22 files)

### 2. Service Implementations

#### High Priority Services
- **AuthenticationFactory.cs** - Authentication factory
- **JwtProvider.cs** - JWT token provider
- **UserService.cs** - User management service
- **CategoryService.cs** - Category management
- **CompanyService.cs** - Company management
- **OrganizationService.cs** - Organization management
- **PreDocumentService.cs** - Pre-document management
- **SupplierService.cs** - Supplier management
- **SupplierDocumentService.cs** - Supplier document management
- **ServiceImplementation.cs** - Main service implementation

#### Common Services
- **DropdownService.cs** - Dropdown data service
- **ExceptionLogService.cs** - Exception logging
- **FileSystemService.cs** - File system operations
- **JwtService.cs** - JWT operations
- **LoggingService.cs** - Application logging
- **OtpService.cs** - OTP operations
- **ValidateCommandBehavior.cs** - Command validation behavior

#### Authentication Services
- **GoogleAuthenticationService.cs** - Google authentication
- **MicrosoftAuthenticationService.cs** - Microsoft authentication

### 3. Custom Managers

#### High Priority Managers
- **AppUserManager.cs** - Custom user manager with business logic
- **AppRoleManager.cs** - Custom role manager
- **AppSignInManager.cs** - Custom sign-in manager
- **AppErrorDescriber.cs** - Custom error descriptions

### 4. Utilities

#### Infrastructure Utilities
- **EmailService.cs** - Email sending service
- **FileHandler.cs** - File handling utilities

### 5. Middleware Components

#### Exception Handling
- **ExceptionHandlingMiddleware.cs** - Global exception handling
- **GlobalExceptionHandler.cs** - Exception handler
- **OtpVerificationMiddleware.cs** - OTP verification middleware
- **FileDownloadMiddleware.cs** - File download middleware

### 6. Authorization & Permissions

#### Permission System
- **PermissionAuthorizationHandler.cs** - Permission authorization
- **PermissionPolicyProvider.cs** - Permission policy provider
- **PermissionRequirement.cs** - Permission requirements

### 7. Common Components

#### Shared Features
- **Mediator.cs** - Custom mediator implementation
- **Response.cs** - Response wrapper
- **PaginatedResponse.cs** - Paginated response wrapper
- **DropDownResponse.cs** - Dropdown response
- **GetPaginatedRequest.cs** - Pagination request
- **ExceptionDto.cs** - Exception data transfer object
- **Logger.cs** - Logging utility

## Component Dependencies Analysis

### Repository Dependencies
Most feature handlers depend on repository interfaces for data access:
- User repositories
- Role repositories
- Company repositories
- Organization repositories
- Category repositories
- Supplier repositories
- Product repositories
- Order repositories
- Customer repositories
- Employee repositories
- Branch repositories
- Service repositories
- Offer repositories
- Inventory repositories
- Item repositories
- Payment method repositories
- Actor repositories
- Case repositories
- Workflow repositories
- Notification repositories
- File repositories
- Logging repositories

### External Service Dependencies
- Identity framework (UserManager, RoleManager, SignInManager)
- JWT services
- Email services
- File system services
- OTP services
- Logging services
- Notification services
- Authentication providers (Google, Microsoft)

### Other Application Service Dependencies
- Mediator for command/query handling
- Validation services
- Authorization services
- Exception handling services

## Testing Priority Matrix

### Priority 1 (Critical - Must Test First)
1. **Authentication & Identity Services**
   - AppUserManager
   - AppRoleManager
   - AppSignInManager
   - JwtProvider
   - AuthenticationFactory
   - Identity feature handlers (SignUp, Login, etc.)

2. **Core Business Services**
   - UserService
   - CompanyService
   - OrganizationService
   - CategoryService

3. **Critical Feature Handlers**
   - User management handlers
   - Authentication handlers
   - Company management handlers
   - Organization management handlers

### Priority 2 (High - Test Soon)
1. **Data Management Services**
   - SupplierService
   - PreDocumentService
   - SupplierDocumentService
   - ServiceImplementation

2. **Common Services**
   - DropdownService
   - ExceptionLogService
   - FileSystemService
   - JwtService
   - LoggingService
   - OtpService

3. **Customer & Order Management**
   - Customer feature handlers
   - Order CQRS handlers
   - Order management handlers

### Priority 3 (Medium - Test Later)
1. **Employee Management**
   - Employee feature handlers
   - Branch feature handlers
   - Job feature handlers
   - Service feature handlers
   - Offer feature handlers

2. **Inventory Management**
   - Inventory feature handlers
   - Item feature handlers
   - Payment method feature handlers
   - Product feature handlers

3. **System Features**
   - Category feature handlers
   - Email feature handlers
   - File feature handlers
   - Notification feature handlers

### Priority 4 (Low - Test Last)
1. **Workflow Management**
   - Actor feature handlers
   - Case feature handlers
   - Workflow feature handlers

2. **Client Management**
   - Client feature handlers
   - Deal feature handlers
   - Property feature handlers

3. **Utilities & Middleware**
   - EmailService
   - FileHandler
   - Middleware components
   - Permission components

## Testing Effort Estimation

### By Module
- **AdministrationModule**: 3-4 weeks (High complexity, many features)
- **IdentityModule**: 2-3 weeks (Critical for security)
- **CustomerModule**: 2-3 weeks (Business critical)
- **EmployeeModule**: 2-3 weeks (Medium complexity)
- **InventoryModule**: 2-3 weeks (Medium complexity)
- **SystemModule**: 1-2 weeks (Supporting features)
- **ClientModule**: 1-2 weeks (Lower priority)
- **WorkflowModule**: 1-2 weeks (Lower priority)

### By Component Type
- **Feature Handlers**: 8-12 weeks (Largest effort)
- **Service Implementations**: 2-3 weeks
- **Custom Managers**: 1-2 weeks
- **Utilities**: 1 week
- **Middleware**: 1 week
- **Permissions**: 1 week

## Total Component Count

### Feature Handlers
- **Total Files**: ~1,225 files
- **Estimated Handlers**: ~400-500 handlers
- **Modules**: 8 major modules

### Service Implementations
- **Total Services**: 19 services
- **High Priority**: 10 services
- **Common Services**: 7 services
- **Authentication Services**: 2 services

### Custom Managers
- **Total Managers**: 4 managers
- **All High Priority**: 4 managers

### Utilities
- **Total Utilities**: 2 utilities
- **Infrastructure**: 2 utilities

### Middleware
- **Total Middleware**: 4 components
- **Exception Handling**: 3 components
- **File Handling**: 1 component

### Permissions
- **Total Components**: 3 components
- **All High Priority**: 3 components

## Coverage Targets

### Overall Targets
- **Line Coverage**: 80% minimum
- **Branch Coverage**: 80% minimum
- **Method Coverage**: 80% minimum

### By Priority
- **Priority 1**: 90%+ coverage
- **Priority 2**: 85%+ coverage
- **Priority 3**: 80%+ coverage
- **Priority 4**: 70%+ coverage

## Next Steps

1. **Start with Priority 1 components** (Authentication & Identity)
2. **Create test classes** for each component type
3. **Implement comprehensive mocking** for all dependencies
4. **Write tests systematically** by priority order
5. **Track progress** using this catalog as reference
6. **Update coverage reports** regularly
7. **Refactor and optimize** test code as needed

## Notes

- Many feature handlers follow similar patterns (CRUD operations)
- Repository dependencies can be mocked using the provided utilities
- External service dependencies should be mocked for unit tests
- Integration tests will be needed for complex workflows
- Some components may need refactoring to improve testability
