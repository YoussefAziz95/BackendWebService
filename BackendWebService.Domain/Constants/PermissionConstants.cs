using System.Reflection;

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
    public static string[] GetCustomerPermissions()
    {
        return new[]
        {
                CUSTOMERUSER,
                CUSTOMERROLE,
                CUSTOMERPERMISSIONS,
                CUSTOMER,
                PROPERTY,
                CUSTOMERSERVICE,
                CUSTOMERPRODUCT,
        };
    }
    public static string[] GetEmployeePermissions()
    {
        return new[]
        {
                EMPLOYEEUSER,
                EMPLOYEEROLE,
                EMPLOYEEPERMISSIONS,
                EMPLOYEE,
                EMPLOYEEPART,
                SERVICE,
                EMPLOYEEPRODUCT,
                PREDOCUMENT,
        };
    }
    public static string[] GetAdminPermissions()
    {
        return new[]
        {
                USER,
                ROLE,
                PERMISSIONS,
                WORKFLOW,
                ACTION,
                OFFER,
                DEAL,
                CATEGORY,
                ZONE,
                PERMISSION,
                ORGANIZATION,
        };
    }
    public static string[] GetCompanyPermissions()
    {
        return new[]
        {
                COMPANY,
                PREDOCUMENTS,
                UTILITY,
                SUPPLIER,
                SUPPLIERDOCUMENT
        };
    }
}
