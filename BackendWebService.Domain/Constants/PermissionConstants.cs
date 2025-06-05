using System.Reflection;
using System.Security.Claims;

namespace Domain.Constants;

public static class PermissionConstants
{
    // Claims OTP New List
    public const string ORGANIZATION = "Main.Menu.Organization.View";

    // Identity
    public const string USER = "User.Menu.User.View";
    public const string ROLE = "User.Menu.Role.View";
    public const string PERMISSIONS = "User.Menu.Permissions.View";

    // Customer
    public const string CUSTOMERUSER = "Customer.Menu.User.View";
    public const string CUSTOMERROLE = "Customer.Menu.Role.View";
    public const string CUSTOMERPERMISSIONS = "Customer.Menu.Permissions.View";
    public const string CUSTOMER = "Customer.Menu.Customer.View";
    public const string PROPERTY = "Main.Menu.Property.View";
    public const string CUSTOMERSERVICE = "Customer.Menu.Booking.View";
    public const string CUSTOMERPRODUCT = "Main.Menu.Product.View";

    // Technician
    public const string TECHNICIANUSER = "Technician.Menu.User.View";
    public const string TECHNICIANROLE = "Technician.Menu.Role.View";
    public const string TECHNICIANPERMISSIONS = "Technician.Menu.Permissions.View";
    public const string TECHNICIAN = "Technician.Menu.Technician.View";
    public const string TECHNICIANPART = "Main.Menu.Part.View";
    public const string SERVICE = "Main.Menu.Service.View";
    public const string TECHNICIANPRODUCT = "Main.Menu.Product.View";
    public const string PREDOCUMENT = "Main.Menu.PreDocument.View";



    //ERP
    public const string WORKFLOW = "Offers.Menu.Workflow.View";
    public const string ACTION = "Offers.Menu.Action.View";
    public const string OFFER = "Offers.Menu.Offer.View";

    //Organization
    public const string COMPANY = "Organization.Menu.Company.View";
    public const string PREDOCUMENTS = "Main.Menu.PreDocuments.View";
    public const string UTILITY = "Main.Menu.Utility.View";
    public const string SUPPLIER = "Main.Menu.Supplier.View";
    public const string SUPPLIERDOCUMENT = "Main.Menu.SupplierDocument.View";
    public const string CATEGORY = "Organization.Menu.Category.View";
    public const string ZONE = "Main.Menu.Zone.View";
    public const string PERMISSION = "Main.Menu.Permission.View";



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
    //public static string[] GetAllPermissionsAdmin()
    //{
    //    Type permissionsType = typeof(PermissionConstants);
    //    FieldInfo[] fields = permissionsType.GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy);

    //    List<string> permissionsList = new List<string>();
    //    foreach (FieldInfo field in fields)
    //    {
    //        if (field.FieldType == typeof(string))
    //        {
    //            string value = (string)field.GetValue(null)!;
    //            if (!value.Contains("Create") && !value.Contains("SupplierDocument"))
    //            {
    //                permissionsList.Add(value);
    //            }
    //        }
    //    }
    //    return permissionsList.Concat([COMPANY_CREATE]).ToArray();
    //}

    //public static string[] GetCompanyAdminPermissions()
    //{

    //    return new string[]{DEAL_VIEW,
    //        DEAL_GET,
    //        DEAL_EDIT,
    //        DEAL_DELETE,
    //        SUPPLIER_VIEW,
    //        SUPPLIER_GET,
    //        SUPPLIER_EDIT,
    //        SUPPLIER_DELETE,
    //        SUPPLIER_CREATE,
    //        SUPPLIERCATEGORY_VIEW,
    //        SUPPLIERCATEGORY_GET,
    //        SUPPLIERCATEGORY_EDIT,
    //        SUPPLIERCATEGORY_DELETE,
    //        SUPPLIERCATEGORY_CREATE,
    //        ACTION_VIEW,
    //        ACTION_EDIT,
    //        ACTION_GET,
    //        SERVICE_VIEW,
    //        SERVICE_GET,
    //        SERVICE_CREATE,
    //        SERVICE_EDIT,
    //        SERVICE_DELETE };

    //}

    //public static string[] GetSupplierAdminPermissions()
    //{
    //    return GetAllPermissions().Where(p => p.Contains("User") || p.Contains("Permission") || p.Contains("Role")
    //    || p.Contains(PERMISSION_VIEW)).
    //    Concat([OFFER_VIEW,
    //        OFFER_DEAL_ADD,
    //        DEAL_VIEW,
    //        DEAL_GET,
    //        DEAL_CREATE,
    //        DEAL_EDIT,
    //        DEAL_DELETE,
    //        SUPPLIERDOCUMENT_VIEW,
    //        SUPPLIERDOCUMENT_GET,
    //        SUPPLIERDOCUMENT_EDIT,
    //        SUPPLIERDOCUMENT_CREATE,
    //        CATEGORY_CREATE ,
    //        CATEGORY_EDIT ,
    //        CATEGORY_DELETE ,
    //        CATEGORY_TITLE,
    //    ]).Where(p => !p.Contains("Company")).Distinct().ToArray();
    //}

}
