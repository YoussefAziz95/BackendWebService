using System.Reflection;
using System.Security.Claims;

namespace Domain.Constants;

public static class PermissionConstants
{
    // Claims OTP New List
    public const string CATEGORIES = "Main.Menu.Categories.View";
    public const string COMPANIES = "Main.Menu.Companies.View";
    public const string CUSTOMERCATEGORY = "Main.Menu.CustomerCategory.View";
    public const string CUSTOMER = "Main.Menu.Customer.View";
    public const string DROPDOWN = "Main.Menu.DropDown.View";
    public const string FILESYSTEM = "Main.Menu.FileSystem.View";
    public const string NOTIFICATION = "Main.Menu.Notification.View";
    public const string ORGANIZATION = "Main.Menu.Organization.View";
    public const string PART = "Main.Menu.Part.View";
    public const string PERMISSIONS = "Main.Menu.Permissions.View";
    public const string PREDOCUMENTS = "Main.Menu.PreDocuments.View";
    public const string PRODUCT = "Main.Menu.Product.View";
    public const string PROPERTY = "Main.Menu.Property.View";
    public const string ROLE = "Main.Menu.Role.View";
    public const string SERVICE = "Main.Menu.Service.View";
    public const string SUPPLIER = "Main.Menu.Supplier.View";
    public const string SUPPLIERDOCUMENT = "Main.Menu.SupplierDocument.View";
    public const string USER = "Main.Menu.User.View";
    public const string UTILITY = "Main.Menu.Utility.View";
    public const string ZONE = "Main.Menu.Zone.View";

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
    //            if (!value.Contains("Create") && !value.Contains("VendorDocument"))
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

    //public static string[] GetVendorAdminPermissions()
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
