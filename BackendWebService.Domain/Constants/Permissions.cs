namespace Domain.Constants
{
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

        public const string MATERIAL_VIEW = "Offers.Menu.Service.View";
        public const string MATERIAL_GET = "Offers.Button.Service.Get";
        public const string MATERIAL_CREATE = "Offers.Button.Service.Create";
        public const string MATERIAL_EDIT = "Offers.Button.Service.Edit";
        public const string MATERIAL_DELETE = "Offers.Button.Service.Delete";



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
        public const string VENDOR_VIEW = "Suppliers.Menu.Supplier.View";
        public const string VENDOR_GET = "Suppliers.Button.Supplier.Get";
        public const string VENDOR_CREATE = "Suppliers.Button.Supplier.Create";
        public const string VENDOR_EDIT = "Suppliers.Button.Supplier.Edit";
        public const string VENDOR_DELETE = "Suppliers.Button.Supplier.Delete";


        // Supplier Category permissions
        public const string VENDORCATEGORY_VIEW = "Suppliers.Buuton.SupplierCategory.View";
        public const string VENDORCATEGORY_GET = "Suppliers.Button.SupplierCategory.Get";
        public const string VENDORCATEGORY_CREATE = "Suppliers.Button.SupplierCategory.Create";
        public const string VENDORCATEGORY_EDIT = "Suppliers.Button.SupplierCategory.Edit";
        public const string VENDORCATEGORY_DELETE = "Suppliers.Button.SupplierCategory.Delete";

        // Supplier Document permissions

        public const string DOCUMENTYPE_VIEW = "Organization.Menu.PreDocuments.View";
        public const string DOCUMENTYPE_CREATE = "Organization.Button.PreDocuments.Create";
        public const string DOCUMENTYPE_GET = "Organization.Button.PreDocuments.Get";
        public const string DOCUMENTYPE_EDIT = "Organization.Button.PreDocuments.Edit";

        // Supplier Document permissions

        public const string VENDORDOCUMENT_VIEW = "Organization.Menu.SupplierDocument.View";
        public const string VENDORDOCUMENT_CREATE = "Organization.Button.SupplierDocument.Create";
        public const string VENDORDOCUMENT_GET = "Organization.Button.SupplierDocument.Get";
        public const string VENDORDOCUMENT_EDIT = "Organization.Button.SupplierDocument.Edit";


        // Company permissions
        public const string COMPANY_VIEW = "Organization.Menu.Company.View";
        public const string COMPANY_GET = "Organization.Button.Company.Get";
        public const string COMPANY_CREATE = "Organization.Button.Company.Create";
        public const string COMPANY_EDIT = "Organization.Button.Company.Edit";
        public const string COMPANY_DELETE = "Organization.Button.Company.Delete";


        // ????
        public const string COMPANYTYPE_GET = "Company.Button.RoleTypes.Get";
        public const string COMPANYTYPE_CREATE = "Company.Button.RoleTypes.Create";
        public const string COMPANYTYPE_EDIT = "Company.Button.RoleTypes.Edit";
        public const string COMPANYTYPE_DELETE = "Company.Button.RoleTypes.Delete";

    }
}
