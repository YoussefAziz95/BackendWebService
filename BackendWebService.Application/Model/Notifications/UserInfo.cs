namespace Application.Model.Notifications
{
    public class UserInfo
    {
        public string ConnectionId { get; set; }
        public string? Username { get; set; }
        public int UserId { get; set; }
        public int? GroupId { get; set; }
        public int RoleId { get; set; }
        public int? CompanyId { get; set; }
        public int? SupplierAccountId { get; set; }
        public int? SupplierId { get; set; }
        public int? OrganizationId { get; set; }
        public int RoleParentId { get; set; }
    }
}
