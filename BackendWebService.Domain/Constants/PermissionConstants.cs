using System.Reflection;

namespace Domain.Constants;

public static class PermissionConstants
{
    // -----------------------------
    // CUSTOMER
    // -----------------------------
    public const string CUSTOMER_USER = "Customer.Menu.User.View";
    public const string CUSTOMER_ROLE = "Customer.Menu.Role.View";
    public const string CUSTOMER_PERMISSIONS = "Customer.Menu.Permissions.View";
    public const string CUSTOMER_CUSTOMER = "Customer.Menu.Customer.View";
    public const string CUSTOMER_PROPERTY = "Customer.Menu.Property.View";
    public const string CUSTOMER_BOOKING = "Customer.Menu.Booking.View";
    public const string CUSTOMER_PRODUCT = "Customer.Menu.Product.View";
    public const string CUSTOMER_CUSTOMERSERVICE = "Customer.Menu.CustomerService.View";
    public const string CUSTOMER_CUSTOMERPAYMENTMETHOD = "Customer.Menu.CustomerPaymentMethod.View";
    public const string CUSTOMER_ORDER = "Customer.Menu.Order.View";
    public const string CUSTOMER_ORDERITEM = "Customer.Menu.OrderItem.View";
    public const string CUSTOMER_RECEIPT = "Customer.Menu.Receipt.View";
    public const string CUSTOMER_CLIENT = "Customer.Menu.Client.View";
    public const string CUSTOMER_CLIENTACCOUNT = "Customer.Menu.ClientAccount.View";
    public const string CUSTOMER_CLIENTPROPERTY = "Customer.Menu.ClientProperty.View";
    public const string CUSTOMER_CLIENTSERVICE = "Customer.Menu.ClientService.View";
    public const string CUSTOMER_DEAL = "Customer.Menu.Deal.View";
    public const string CUSTOMER_DEALDETAILS = "Customer.Menu.DealDetails.View";
    public const string CUSTOMER_DEALDOCUMENT = "Customer.Menu.DealDocument.View";
    // -----------------------------
    // EMPLOYEE
    // -----------------------------
    public const string EMPLOYEE_USER = "Employee.Menu.User.View";
    public const string EMPLOYEE_ROLE = "Employee.Menu.Role.View";
    public const string EMPLOYEE_PERMISSIONS = "Employee.Menu.Permissions.View";
    public const string EMPLOYEE_EMPLOYEE = "Employee.Menu.Employee.View";
    public const string EMPLOYEE_EMPLOYEEACCOUNT = "Employee.Menu.EmployeeAccount.View";
    public const string EMPLOYEE_EMPLOYEEASSIGNMENT = "Employee.Menu.EmployeeAssignment.View";
    public const string EMPLOYEE_EMPLOYEEJOB = "Employee.Menu.EmployeeJob.View";
    public const string EMPLOYEE_EMPLOYEECERTIFICATION = "Employee.Menu.EmployeeCertification.View";
    public const string EMPLOYEE_JOB = "Employee.Menu.Job.View";
    public const string EMPLOYEE_JOBVERIFICATION = "Employee.Menu.JobVerification.View";
    public const string EMPLOYEE_PART = "Employee.Menu.Part.View";
    public const string EMPLOYEE_SERVICE = "Employee.Menu.Service.View";
    public const string EMPLOYEE_EMPLOYEESERVICE = "Employee.Menu.EmployeeService.View";
    public const string EMPLOYEE_TIMESLOT = "Employee.Menu.TimeSlot.View";
    public const string EMPLOYEE_PRODUCT = "Employee.Menu.Product.View";
    public const string EMPLOYEE_OFFER = "Employee.Menu.Offer.View";
    public const string EMPLOYEE_OFFERITEM = "Employee.Menu.OfferItem.View";
    public const string EMPLOYEE_OFFEROBJECT = "Employee.Menu.OfferObject.View";
    public const string EMPLOYEE_CRITERIA = "Employee.Menu.Criteria.View";
    public const string EMPLOYEE_BRANCH = "Employee.Menu.Branch.View";
    public const string EMPLOYEE_BRANCHCONTACT = "Employee.Menu.BranchContact.View";
    public const string EMPLOYEE_BRANCHLOCATION = "Employee.Menu.BranchLocation.View";
    public const string EMPLOYEE_BRANCHSERVICE = "Employee.Menu.BranchService.View";
    public const string EMPLOYEE_BRANCHWORKINGHOUR = "Employee.Menu.BranchWorkingHour.View";
    // -----------------------------
    // ORGANIZATION
    // -----------------------------
    public const string ORGANIZATION_USER = "Organization.Menu.User.View";
    public const string ORGANIZATION_ROLE = "Organization.Menu.Role.View";
    public const string ORGANIZATION_PERMISSIONS = "Organization.Menu.Permissions.View";
    public const string ORGANIZATION_ORGANIZATION = "Organization.Menu.Organization.View";
    public const string ORGANIZATION_DEPARTMENT = "Organization.Menu.Department.View";
    public const string ORGANIZATION_ADMINISTRATOR = "Organization.Menu.Administrator.View";
    public const string ORGANIZATION_GOOGLECONFIG = "Organization.Menu.GoogleConfig.View";
    public const string ORGANIZATION_LDAPCONFIG = "Organization.Menu.LDAPConfig.View";
    public const string ORGANIZATION_MICROSOFTCONFIG = "Organization.Menu.MicrosoftConfig.View";
    public const string ORGANIZATION_WORKFLOW = "Organization.Menu.Workflow.View";
    public const string ORGANIZATION_WORKFLOWCYCLE = "Organization.Menu.WorkflowCycle.View";
    public const string ORGANIZATION_CASE = "Organization.Menu.Case.View";
    public const string ORGANIZATION_CASEACTION = "Organization.Menu.CaseAction.View";
    public const string ORGANIZATION_ACTOR = "Organization.Menu.Actor.View";
    public const string ORGANIZATION_ACTIONACTOR = "Organization.Menu.ActionActor.View";
    public const string ORGANIZATION_ACTIONOBJECT = "Organization.Menu.ActionObject.View";
    public const string ORGANIZATION_OFFER = "Organization.Menu.Offer.View";
    public const string ORGANIZATION_DEAL = "Organization.Menu.Deal.View";
    public const string ORGANIZATION_CATEGORY = "Organization.Menu.Category.View";
    public const string ORGANIZATION_ZONE = "Organization.Menu.Zone.View";
    public const string ORGANIZATION_PERMISSION = "Organization.Menu.Permission.View";
    public const string ORGANIZATION_MANAGER = "Organization.Menu.Manager.View";
    public const string ORGANIZATION_CONTACT = "Organization.Menu.Contact.View";
    // -----------------------------
    // ADMIN
    // -----------------------------
    public const string ADMIN_COMPANY = "Admin.Menu.Company.View";
    public const string ADMIN_COMPANYCATEGORY = "Admin.Menu.CompanyCategory.View";
    public const string ADMIN_MANAGER = "Admin.Menu.Manager.View";
    public const string ADMIN_CONSUMER = "Admin.Menu.Consumer.View";
    public const string ADMIN_CONSUMERACCOUNT = "Admin.Menu.ConsumerAccount.View";
    public const string ADMIN_CONSUMERCUSTOMER = "Admin.Menu.ConsumerCustomer.View";
    public const string ADMIN_CONSUMERDOCUMENT = "Admin.Menu.ConsumerDocument.View";
    public const string ADMIN_SUPPLIER = "Admin.Menu.Supplier.View";
    public const string ADMIN_SUPPLIERACCOUNT = "Admin.Menu.SupplierAccount.View";
    public const string ADMIN_SUPPLIERCATEGORY = "Admin.Menu.SupplierCategory.View";
    public const string ADMIN_SUPPLIERDOCUMENT = "Admin.Menu.SupplierDocument.View";
    public const string ADMIN_PREDOCUMENT = "Admin.Menu.PreDocument.View";
    public const string ADMIN_ADDRESS = "Admin.Menu.Address.View";
    public const string ADMIN_UTILITY = "Admin.Menu.Utility.View";
    public const string ADMIN_FILELOG = "Admin.Menu.FileLog.View";
    public const string ADMIN_FILETYPE = "Admin.Menu.FileType.View";
    public const string ADMIN_FILEFIELDVALIDATOR = "Admin.Menu.FileFieldValidator.View";
    // -----------------------------
    // SYSTEM
    // -----------------------------
    public const string SYSTEM_LOGGING = "System.Menu.Logging.View";
    public const string SYSTEM_TRANSLATIONKEY = "System.Menu.TranslationKey.View";
    public const string SYSTEM_ATTACHMENT = "System.Menu.Attachment.View";
    public const string SYSTEM_EMAILLOG = "System.Menu.EmailLog.View";
    public const string SYSTEM_RECIPIENT = "System.Menu.Recipient.View";
    public const string SYSTEM_NOTIFICATION = "System.Menu.Notification.View";
    public const string SYSTEM_NOTIFICATIONDETAIL = "System.Menu.NotificationDetail.View";
    public const string SYSTEM_TRANSACTION = "System.Menu.Transaction.View";
    // -----------------------------
    // IDENTITY
    // -----------------------------
    public const string IDENTITY_GROUP = "Identity.Menu.Group.View";
    public const string IDENTITY_ROLE = "Identity.Menu.Role.View";
    public const string IDENTITY_ROLECLAIM = "Identity.Menu.RoleClaim.View";
    public const string IDENTITY_USER = "Identity.Menu.User.View";
    public const string IDENTITY_USERCLAIM = "Identity.Menu.UserClaim.View";
    public const string IDENTITY_USERGROUP = "Identity.Menu.UserGroup.View";
    public const string IDENTITY_USERLOGIN = "Identity.Menu.UserLogin.View";
    public const string IDENTITY_USERREFRESHTOKEN = "Identity.Menu.UserRefreshToken.View";
    public const string IDENTITY_USERROLE = "Identity.Menu.UserRole.View";
    public const string IDENTITY_USERTOKEN = "Identity.Menu.UserToken.View";
    // -----------------------------
    // INVENTORY
    // -----------------------------
    public const string INVENTORY_INVENTORY = "Inventory.Menu.Inventory.View";
    public const string INVENTORY_ITEM = "Inventory.Menu.Item.View";
    public const string INVENTORY_PORTIONS = "Inventory.Menu.Portions.View";
    public const string INVENTORY_PORTION = "Inventory.Menu.Portion.View";
    public const string INVENTORY_PORTIONITEM = "Inventory.Menu.PortionItem.View";
    public const string INVENTORY_PORTIONTYPE = "Inventory.Menu.PortionType.View";
    public const string INVENTORY_PAYMENTMETHOD = "Inventory.Menu.PaymentMethod.View";
    public const string INVENTORY_TRANSACTION = "Inventory.Menu.Transaction.View";
    public const string INVENTORY_PRODUCT = "Inventory.Menu.Product.View";
    public const string INVENTORY_PART = "Inventory.Menu.Part.View";
    public const string INVENTORY_SPARE = "Inventory.Menu.Spare.View";
    public const string INVENTORY_SPAREPART = "Inventory.Menu.SparePart.View";
    public const string INVENTORY_STORAGEUNIT = "Inventory.Menu.StorageUnit.View";


    // -----------------------------
    // Utility Method 
    // -----------------------------
    public static string[] GetAllPermissions()
    {
        Type permissionsType = typeof(PermissionConstants);
        FieldInfo[] fields = permissionsType.GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy);

        List<string> permissionsList = new();
        foreach (FieldInfo field in fields)
        {
            if (field.FieldType == typeof(string))
            {
                string value = (string)field.GetValue(null)!;
                permissionsList.Add(value);
            }
        }
        return permissionsList.ToArray();
    }

    public static string[] GetCustomerPermissions() =>
        new[]
        {
            CUSTOMER_USER,
            CUSTOMER_ROLE,
            CUSTOMER_PERMISSIONS,
            CUSTOMER_CUSTOMER,
            CUSTOMER_PROPERTY,
            CUSTOMER_BOOKING,
            CUSTOMER_PRODUCT,
            CUSTOMER_CUSTOMERSERVICE,
            CUSTOMER_CUSTOMERPAYMENTMETHOD,
            CUSTOMER_ORDER,
            CUSTOMER_ORDERITEM,
            CUSTOMER_RECEIPT,
            CUSTOMER_CLIENT,
            CUSTOMER_CLIENTACCOUNT,
            CUSTOMER_CLIENTPROPERTY,
            CUSTOMER_CLIENTSERVICE,
            CUSTOMER_DEAL,
            CUSTOMER_DEALDETAILS,
            CUSTOMER_DEALDOCUMENT
        };

    public static string[] GetEmployeePermissions() =>
        new[]
        {
            EMPLOYEE_USER,
            EMPLOYEE_ROLE,
            EMPLOYEE_PERMISSIONS,
            EMPLOYEE_EMPLOYEE,
            EMPLOYEE_EMPLOYEEACCOUNT,
            EMPLOYEE_EMPLOYEEASSIGNMENT,
            EMPLOYEE_EMPLOYEEJOB,
            EMPLOYEE_EMPLOYEECERTIFICATION,
            EMPLOYEE_JOB,
            EMPLOYEE_JOBVERIFICATION,
            EMPLOYEE_PART,
            EMPLOYEE_SERVICE,
            EMPLOYEE_EMPLOYEESERVICE,
            EMPLOYEE_TIMESLOT,
            EMPLOYEE_PRODUCT,
            EMPLOYEE_OFFER,
            EMPLOYEE_OFFERITEM,
            EMPLOYEE_OFFEROBJECT,
            EMPLOYEE_CRITERIA,
            EMPLOYEE_BRANCH,
            EMPLOYEE_BRANCHCONTACT,
            EMPLOYEE_BRANCHLOCATION,
            EMPLOYEE_BRANCHSERVICE,
            EMPLOYEE_BRANCHWORKINGHOUR
        };

    public static string[] GetOrganizationPermissions() =>
        new[]
        {
            ORGANIZATION_USER,
            ORGANIZATION_ROLE,
            ORGANIZATION_PERMISSIONS,
            ORGANIZATION_ORGANIZATION,
            ORGANIZATION_DEPARTMENT,
            ORGANIZATION_ADMINISTRATOR,
            ORGANIZATION_GOOGLECONFIG,
            ORGANIZATION_LDAPCONFIG,
            ORGANIZATION_MICROSOFTCONFIG,
            ORGANIZATION_WORKFLOW,
            ORGANIZATION_WORKFLOWCYCLE,
            ORGANIZATION_CASE,
            ORGANIZATION_CASEACTION,
            ORGANIZATION_ACTOR,
            ORGANIZATION_ACTIONACTOR,
            ORGANIZATION_ACTIONOBJECT,
            ORGANIZATION_OFFER,
            ORGANIZATION_DEAL,
            ORGANIZATION_CATEGORY,
            ORGANIZATION_ZONE,
            ORGANIZATION_PERMISSION,
            ORGANIZATION_MANAGER,
            ORGANIZATION_CONTACT
        };

    public static string[] GetAdminPermissions() =>
        new[]
        {
            ADMIN_COMPANY,
            ADMIN_COMPANYCATEGORY,
            ADMIN_MANAGER,
            ADMIN_CONSUMER,
            ADMIN_CONSUMERACCOUNT,
            ADMIN_CONSUMERCUSTOMER,
            ADMIN_CONSUMERDOCUMENT,
            ADMIN_SUPPLIER,
            ADMIN_SUPPLIERACCOUNT,
            ADMIN_SUPPLIERCATEGORY,
            ADMIN_SUPPLIERDOCUMENT,
            ADMIN_PREDOCUMENT,
            ADMIN_ADDRESS,
            ADMIN_UTILITY,
            ADMIN_FILELOG,
            ADMIN_FILETYPE,
            ADMIN_FILEFIELDVALIDATOR
        };

    public static string[] GetInventoryPermissions() =>
        new[]
        {
            INVENTORY_INVENTORY,
            INVENTORY_ITEM,
            INVENTORY_PORTIONS,
            INVENTORY_PORTION,
            INVENTORY_PORTIONITEM,
            INVENTORY_PORTIONTYPE,
            INVENTORY_PAYMENTMETHOD,
            INVENTORY_TRANSACTION,
            INVENTORY_PRODUCT,
            INVENTORY_PART,
            INVENTORY_SPARE,
            INVENTORY_SPAREPART,
            INVENTORY_STORAGEUNIT
        };

    public static string[] GetSystemPermissions() =>
        new[]
        {
            SYSTEM_LOGGING,
            SYSTEM_TRANSLATIONKEY,
            SYSTEM_ATTACHMENT,
            SYSTEM_EMAILLOG,
            SYSTEM_RECIPIENT,
            SYSTEM_NOTIFICATION,
            SYSTEM_NOTIFICATIONDETAIL,
            SYSTEM_TRANSACTION
        };

    public static string[] GetIdentityPermissions() =>
        new[]
        {
            IDENTITY_GROUP,
            IDENTITY_ROLE,
            IDENTITY_ROLECLAIM,
            IDENTITY_USER,
            IDENTITY_USERCLAIM,
            IDENTITY_USERGROUP,
            IDENTITY_USERLOGIN,
            IDENTITY_USERREFRESHTOKEN,
            IDENTITY_USERROLE,
            IDENTITY_USERTOKEN
        };
}
