using System.Reflection;
using System.Security.Claims;

namespace Domain.Constants;

public static class PermissionConstants
{
    // Claims OTP 
    public const string USER_OTP_TYPE = "Claims.IsOtpVerified";

    //Customer
    public const string USER_VIEW = "Users.Menu.User.View";
    public const string USER_GET = "Users.Button.User.Get";
    public const string USER_CREATE = "Users.Button.User.Create";
    public const string USER_EDIT = "Users.Button.User.Edit";
    public const string USER_DELETE = "Users.Button.User.Delete";

    //Roles
    public const string ROLE_VIEW = "Users.Menu.Role.View";
    public const string ROLE_GET = "Users.Button.Role.Get";
    public const string ROLE_CREATE = "Users.Button.Role.Create";
    public const string ROLE_EDIT = "Users.Button.Role.Edit";
    public const string ROLE_DELETE = "Users.Button.Role.Delete";




    // Permissions
    public const string PERMISSION_VIEW = "Users.Menu.Permissions.View";
    //public const string PERMISSION_GET = "Permissions.Permission.Get";
    //public const string PERMISSION_CREATE = "Permissions.Permission.Create";

    //public const string DACHBOARD_LIST = "Dashboard.Menu.Dashboard.LIST";




    // Category permissions
    public const string CATEGORY_VIEW = "Organization.Menu.Category.View";
    public const string CATEGORY_GET = "Organization.Button.Category.Get";
    public const string CATEGORY_CREATE = "Organization.Button.Category.Create";
    public const string CATEGORY_EDIT = "Organization.Button.Category.Edit";
    public const string CATEGORY_DELETE = "Organization.Button.Category.Delete";
    public const string CATEGORY_TITLE = "Organization.Button.Category.Title";


    // Company Category permissions
    public const string COMPANY_CATEGORY_MULTISELECT = "Organization.Button.Category.MultiSelect";
    public const string COMPANY_CATEGORY_VIEW = "Organization.Button.Category.View";

    // Add/Edit Category permissions
    public const string ADDEDITCATEGORY_SELECT = "Organization.AddEditCategory.Category.Select";
    public const string ADDEDITCATEGORY_TITLE = "Organization.AddEditCategory.Category.Title";

    // Document Types permissions

    public const string PREDOCUMENT_VIEW = "Organization.Menu.PreDocuments.View";
    public const string PREDOCUMENT_GET = "Organization.Button.PreDocuments.Get";
    public const string PREDOCUMENT_CREATE = "Organization.Button.PreDocuments.Create";
    public const string PREDOCUMENT_EDIT = "Organization.Button.PreDocuments.Edit";
    public const string PREDOCUMENT_DELETE = "Organization.Button.PreDocuments.Delete";


    // Service permissions

    public const string SERVICE_VIEW = "Offers.Menu.Service.View";
    public const string SERVICE_GET = "Offers.Button.Service.Get";
    public const string SERVICE_CREATE = "Offers.Button.Service.Create";
    public const string SERVICE_EDIT = "Offers.Button.Service.Edit";
    public const string SERVICE_DELETE = "Offers.Button.Service.Delete";



    // Workflow permissions

    public const string WORKFLOW_VIEW = "Offers.Menu.Workflow.View";
    public const string WORKFLOW_GET = "Offers.Button.Workflow.Get";
    public const string WORKFLOW_CREATE = "Offers.Button.Workflow.Create";
    public const string WORKFLOW_EDIT = "Offers.Button.Workflow.Edit";
    public const string WORKFLOW_DELETE = "Offers.Button.Workflow.Delete";



    // Action permissions
    public const string ACTION_VIEW = "Offers.Menu.Action.View";
    public const string ACTION_GET = "Offers.Button.Action.Get";
    public const string ACTION_CREATE = "Offers.Button.Action.Create";
    public const string ACTION_EDIT = "Offers.Button.Action.Edit";
    public const string ACTION_DELETE = "Offers.Button.Action.Delete";


    // Offer permissions
    public const string OFFER_VIEW = "Offers.Menu.Offer.View";
    public const string OFFER_GET = "Offers.Button.Offer.Get";
    public const string OFFER_CREATE = "Offers.Button.Offer.Create";
    public const string OFFER_EDIT = "Offers.Button.Offer.Edit";
    public const string OFFER_DELETE = "Offers.Button.Offer.Delete";
    public const string OFFER_DEAL_ADD = "Offers.Offer.Deal.Create";

    // Deal permissions
    public const string DEAL_VIEW = "Offers.Button.Deal.View";
    public const string DEAL_GET = "Offers.Button.Deal.Get";
    public const string DEAL_CREATE = "Offers.Button.Deal.Create";
    public const string DEAL_EDIT = "Offers.Button.Deal.Edit";
    public const string DEAL_DELETE = "Offers.Button.Deal.Delete";

    // Supplier permissions
    public const string SUPPLIER_VIEW = "Suppliers.Menu.Supplier.View";
    public const string SUPPLIER_GET = "Suppliers.Button.Supplier.Get";
    public const string SUPPLIER_CREATE = "Suppliers.Button.Supplier.Create";
    public const string SUPPLIER_EDIT = "Suppliers.Button.Supplier.Edit";
    public const string SUPPLIER_DELETE = "Suppliers.Button.Supplier.Delete";


    // Supplier Category permissions
    public const string SUPPLIERCATEGORY_VIEW = "Suppliers.Buuton.SupplierCategory.View";
    public const string SUPPLIERCATEGORY_GET = "Suppliers.Button.SupplierCategory.Get";
    public const string SUPPLIERCATEGORY_CREATE = "Suppliers.Button.SupplierCategory.Create";
    public const string SUPPLIERCATEGORY_EDIT = "Suppliers.Button.SupplierCategory.Edit";
    public const string SUPPLIERCATEGORY_DELETE = "Suppliers.Button.SupplierCategory.Delete";

    // Supplier Document permissions

    public const string DOCUMENTYPE_VIEW = "Organization.Menu.PreDocuments.View";
    public const string DOCUMENTYPE_CREATE = "Organization.Button.PreDocuments.Create";
    public const string DOCUMENTYPE_GET = "Organization.Button.PreDocuments.Get";
    public const string DOCUMENTYPE_EDIT = "Organization.Button.PreDocuments.Edit";

    // Supplier Document permissions

    public const string SUPPLIERDOCUMENT_VIEW = "Organization.Menu.SupplierDocument.View";
    public const string SUPPLIERDOCUMENT_CREATE = "Organization.Button.SupplierDocument.Create";
    public const string SUPPLIERDOCUMENT_GET = "Organization.Button.SupplierDocument.Get";
    public const string SUPPLIERDOCUMENT_EDIT = "Organization.Button.SupplierDocument.Edit";


    // Company permissions
    public const string COMPANY_VIEW = "Organization.Menu.Company.View";
    public const string COMPANY_GET = "Organization.Button.Company.Get";
    public const string COMPANY_CREATE = "Organization.Button.Company.Create";
    public const string COMPANY_EDIT = "Organization.Button.Company.Edit";
    public const string COMPANY_DELETE = "Organization.Button.Company.Delete";


    public static Claim[] GetBasePermissions()
    {
        Type permissionsType = typeof(PermissionConstants);
        FieldInfo[] fields = permissionsType.GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy);

        List<string> permissionsList = new List<string>();
        foreach (FieldInfo field in fields)
        {
            if (field.FieldType == typeof(string))
            {
                string value = (string)field.GetValue(null)!;
                permissionsList.Add(value);
            }
        }
        return permissionsList.Select(c => new Claim(c, AppConstants.Permission)).ToArray();
    }
    public static string[] GetAllPermissions()
    {
        Type permissionsType = typeof(PermissionConstants);
        FieldInfo[] fields = permissionsType.GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy);

        List<string> permissionsList = new List<string>();
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
    public static string[] GetAllPermissionsAdmin()
    {
        Type permissionsType = typeof(PermissionConstants);
        FieldInfo[] fields = permissionsType.GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy);

        List<string> permissionsList = new List<string>();
        foreach (FieldInfo field in fields)
        {
            if (field.FieldType == typeof(string))
            {
                string value = (string)field.GetValue(null)!;
                if (!value.Contains("Create") && !value.Contains("VendorDocument"))
                {
                    permissionsList.Add(value);
                }
            }
        }
        return permissionsList.Concat([COMPANY_CREATE]).ToArray();
    }

    public static string[] GetCompanyAdminPermissions()
    {

        return new string[]{DEAL_VIEW,
            DEAL_GET,
            DEAL_EDIT,
            DEAL_DELETE,
            SUPPLIER_VIEW,
            SUPPLIER_GET,
            SUPPLIER_EDIT,
            SUPPLIER_DELETE,
            SUPPLIER_CREATE,
            SUPPLIERCATEGORY_VIEW,
            SUPPLIERCATEGORY_GET,
            SUPPLIERCATEGORY_EDIT,
            SUPPLIERCATEGORY_DELETE,
            SUPPLIERCATEGORY_CREATE,
            ACTION_VIEW,
            ACTION_EDIT,
            ACTION_GET,
            SERVICE_VIEW,
            SERVICE_GET,
            SERVICE_CREATE,
            SERVICE_EDIT,
            SERVICE_DELETE };

    }

    public static string[] GetVendorAdminPermissions()
    {
        return GetAllPermissions().Where(p => p.Contains("User") || p.Contains("Permission") || p.Contains("Role")
        || p.Contains(PERMISSION_VIEW)).
        Concat([OFFER_VIEW,
            OFFER_DEAL_ADD,
            DEAL_VIEW,
            DEAL_GET,
            DEAL_CREATE,
            DEAL_EDIT,
            DEAL_DELETE,
            SUPPLIERDOCUMENT_VIEW,
            SUPPLIERDOCUMENT_GET,
            SUPPLIERDOCUMENT_EDIT,
            SUPPLIERDOCUMENT_CREATE,
            CATEGORY_CREATE ,
            CATEGORY_EDIT ,
            CATEGORY_DELETE ,
            CATEGORY_TITLE,
        ]).Where(p => !p.Contains("Company")).Distinct().ToArray();
    }

}
