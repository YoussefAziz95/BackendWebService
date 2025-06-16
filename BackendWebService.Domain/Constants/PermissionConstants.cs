using System.Reflection;
using System.Security.Claims;

namespace Domain.Constants;

public static class PermissionConstants
{

    // Customer
    public const string CUSTOMERUSER = "Customer.Menu.User.View";
    public const string CUSTOMERROLE = "Customer.Menu.Role.View";
    public const string CUSTOMERPERMISSIONS = "Customer.Menu.Permissions.View";
    public const string CUSTOMER = "Customer.Menu.Customer.View";
    public const string PROPERTY = "Customer.Menu.Property.View";
    public const string CUSTOMERSERVICE = "Customer.Menu.Booking.View";
    public const string CUSTOMERPRODUCT = "Customer.Menu.Product.View";

    // Employee
    public const string EMPLOYEEUSER = "Employee.Menu.User.View";
    public const string EMPLOYEEROLE = "Employee.Menu.Role.View";
    public const string EMPLOYEEPERMISSIONS = "Employee.Menu.Permissions.View";
    public const string EMPLOYEE = "Employee.Menu.Employee.View";
    public const string EMPLOYEEPART = "Employee.Menu.Part.View";
    public const string SERVICE = "Employee.Menu.Service.View";
    public const string EMPLOYEEPRODUCT = "Employee.Menu.Product.View";
    public const string PREDOCUMENT = "Employee.Menu.PreDocument.View";


    // Identity
    public const string USER = "Organization.Menu.User.View";
    public const string ROLE = "Organization.Menu.Role.View";
    public const string PERMISSIONS = "Organization.Menu.Permissions.View";
    public const string WORKFLOW = "Organization.Menu.Workflow.View";
    public const string ACTION = "Organization.Menu.Action.View";
    public const string OFFER = "Organization.Menu.Offer.View";
    public const string DEAL = "Organization.Menu.Deal.View";
    public const string CATEGORY = "Organization.Menu.Category.View";
    public const string ZONE = "Organization.Menu.Zone.View";
    public const string PERMISSION = "Organization.Menu.Permission.View";
    public const string ORGANIZATION = "Organization.Menu.Organization.View";

    //Organization
    public const string COMPANY = "Admin.Menu.Company.View";
    public const string PREDOCUMENTS = "Admin.Menu.PreDocuments.View";
    public const string UTILITY = "Admin.Menu.Utility.View";
    public const string SUPPLIER = "Admin.Menu.Supplier.View";
    public const string SUPPLIERDOCUMENT = "Admin.Menu.SupplierDocument.View";



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
