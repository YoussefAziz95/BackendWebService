using Domain;
using Domain.Enums;
using FluentAssertions;
using Xunit;
using System.Collections.Generic;
using System.Linq;

namespace BackendWebService.Domain.UnitTests;

public class CollectionAndNavigationTests
{
    #region Collection Initialization Tests

    [Fact]
    public void User_UserRolesCollection_ShouldBeNullByDefault()
    {
        // Arrange & Act
        var user = new User();

        // Assert
        user.UserRoles.Should().BeNull("UserRoles collection should be null! by default");
    }

    [Fact]
    public void User_UserRolesCollection_ShouldBeInitializable()
    {
        // Arrange
        var user = new User();

        // Act
        user.UserRoles = new List<UserRole>();

        // Assert
        user.UserRoles.Should().NotBeNull("UserRoles collection should be initializable");
        user.UserRoles.Should().BeEmpty("New collection should be empty");
    }

    [Fact]
    public void User_UserRolesCollection_ShouldAllowAdd()
    {
        // Arrange
        var user = new User();
        user.UserRoles = new List<UserRole>();
        var userRole = new UserRole { UserId = 1, RoleId = 1 };

        // Act
        user.UserRoles.Add(userRole);

        // Assert
        user.UserRoles.Should().HaveCount(1);
        user.UserRoles.Should().Contain(userRole);
    }

    [Fact]
    public void User_UserRolesCollection_ShouldAllowRemove()
    {
        // Arrange
        var user = new User();
        user.UserRoles = new List<UserRole>();
        var userRole = new UserRole { UserId = 1, RoleId = 1 };
        user.UserRoles.Add(userRole);

        // Act
        user.UserRoles.Remove(userRole);

        // Assert
        user.UserRoles.Should().BeEmpty();
    }

    [Fact]
    public void User_UserRolesCollection_ShouldAllowClear()
    {
        // Arrange
        var user = new User();
        user.UserRoles = new List<UserRole>();
        user.UserRoles.Add(new UserRole { UserId = 1, RoleId = 1 });
        user.UserRoles.Add(new UserRole { UserId = 1, RoleId = 2 });

        // Act
        user.UserRoles.Clear();

        // Assert
        user.UserRoles.Should().BeEmpty();
    }

    [Fact]
    public void User_UserRolesCollection_ShouldAllowMultipleAdds()
    {
        // Arrange
        var user = new User();
        user.UserRoles = new List<UserRole>();
        var userRole1 = new UserRole { UserId = 1, RoleId = 1 };
        var userRole2 = new UserRole { UserId = 1, RoleId = 2 };

        // Act
        user.UserRoles.Add(userRole1);
        user.UserRoles.Add(userRole2);

        // Assert
        user.UserRoles.Should().HaveCount(2);
        user.UserRoles.Should().Contain(userRole1);
        user.UserRoles.Should().Contain(userRole2);
    }

    [Fact]
    public void User_UserRolesCollection_ShouldAllowLinqOperations()
    {
        // Arrange
        var user = new User();
        user.UserRoles = new List<UserRole>();
        user.UserRoles.Add(new UserRole { UserId = 1, RoleId = 1 });
        user.UserRoles.Add(new UserRole { UserId = 1, RoleId = 2 });
        user.UserRoles.Add(new UserRole { UserId = 1, RoleId = 3 });

        // Act
        var adminRoles = user.UserRoles.Where(ur => ur.RoleId == 1).ToList();
        var roleCount = user.UserRoles.Count();

        // Assert
        adminRoles.Should().HaveCount(1);
        roleCount.Should().Be(3);
    }

    #endregion

    #region Navigation Property Tests

    [Fact]
    public void User_OrganizationNavigation_ShouldBeNullByDefault()
    {
        // Arrange & Act
        var user = new User();

        // Assert
        user.Organization.Should().BeNull("Organization navigation should be null! by default");
    }

    [Fact]
    public void User_OrganizationNavigation_ShouldBeSettable()
    {
        // Arrange
        var user = new User();
        var organization = new Organization { Id = 1, Name = "Test Organization" };

        // Act
        user.Organization = organization;

        // Assert
        user.Organization.Should().Be(organization);
        user.Organization.Name.Should().Be("Test Organization");
    }

    [Fact]
    public void User_OrganizationNavigation_ShouldBeNullAfterSetToNull()
    {
        // Arrange
        var user = new User();
        var organization = new Organization { Id = 1, Name = "Test Organization" };
        user.Organization = organization;

        // Act
        user.Organization = null!;

        // Assert
        user.Organization.Should().BeNull();
    }

    [Fact]
    public void User_OrganizationId_ShouldMatchOrganizationId()
    {
        // Arrange
        var user = new User();
        var organization = new Organization { Id = 123, Name = "Test Organization" };

        // Act
        user.Organization = organization;
        user.OrganizationId = organization.Id;

        // Assert
        user.OrganizationId.Should().Be(organization.Id);
    }

    #endregion

    #region Complex Collection Tests

    [Fact]
    public void Organization_AddressesCollection_ShouldBeNullByDefault()
    {
        // Arrange & Act
        var organization = new Organization();

        // Assert
        organization.Addresses.Should().BeNull("Addresses collection should be null! by default");
    }

    [Fact]
    public void Organization_AddressesCollection_ShouldBeInitializable()
    {
        // Arrange
        var organization = new Organization();

        // Act
        organization.Addresses = new List<Address>();

        // Assert
        organization.Addresses.Should().NotBeNull();
        organization.Addresses.Should().BeEmpty();
    }

    [Fact]
    public void Organization_AddressesCollection_ShouldAllowAdd()
    {
        // Arrange
        var organization = new Organization();
        organization.Addresses = new List<Address>();
        var address = new Address { Id = 1, FullAddress = "123 Main St" };

        // Act
        organization.Addresses.Add(address);

        // Assert
        organization.Addresses.Should().HaveCount(1);
        organization.Addresses.Should().Contain(address);
    }

    [Fact]
    public void Organization_ContactsCollection_ShouldBeNullByDefault()
    {
        // Arrange & Act
        var organization = new Organization();

        // Assert
        organization.Contacts.Should().BeNull("Contacts collection should be null! by default");
    }

    [Fact]
    public void Organization_ContactsCollection_ShouldBeInitializable()
    {
        // Arrange
        var organization = new Organization();

        // Act
        organization.Contacts = new List<Contact>();

        // Assert
        organization.Contacts.Should().NotBeNull();
        organization.Contacts.Should().BeEmpty();
    }

    [Fact]
    public void Department_ParentDepartmentNavigation_ShouldBeNullByDefault()
    {
        // Arrange & Act
        var department = new Department();

        // Assert
        department.ParentDepartment.Should().BeNull("ParentDepartment navigation should be null! by default");
    }

    [Fact]
    public void Department_ParentDepartmentNavigation_ShouldBeSettable()
    {
        // Arrange
        var department = new Department();
        var parentDepartment = new Department { Id = 1, Name = "Parent Department" };

        // Act
        department.ParentDepartment = parentDepartment;

        // Assert
        department.ParentDepartment.Should().Be(parentDepartment);
    }

    [Fact]
    public void Department_SubDepartmentsCollection_ShouldBeNullByDefault()
    {
        // Arrange & Act
        var department = new Department();

        // Assert
        department.SubDepartments.Should().BeNull("SubDepartments collection should be null! by default");
    }

    [Fact]
    public void Department_SubDepartmentsCollection_ShouldBeInitializable()
    {
        // Arrange
        var department = new Department();

        // Act
        department.SubDepartments = new List<Department>();

        // Assert
        department.SubDepartments.Should().NotBeNull();
        department.SubDepartments.Should().BeEmpty();
    }

    #endregion

    #region Inventory Collection Tests

    [Fact]
    public void Inventory_StorageUnitsCollection_ShouldBeNullByDefault()
    {
        // Arrange & Act
        var inventory = new Inventory();

        // Assert
        inventory.StorageUnits.Should().BeNull("StorageUnits collection should be null! by default");
    }

    [Fact]
    public void Inventory_StorageUnitsCollection_ShouldBeInitializable()
    {
        // Arrange
        var inventory = new Inventory();

        // Act
        inventory.StorageUnits = new List<StorageUnit>();

        // Assert
        inventory.StorageUnits.Should().NotBeNull();
        inventory.StorageUnits.Should().BeEmpty();
    }

    [Fact]
    public void Inventory_ItemsCollection_ShouldBeNullByDefault()
    {
        // Arrange & Act
        var inventory = new Inventory();

        // Assert
        inventory.Items.Should().BeNull("Items collection should be null! by default");
    }

    [Fact]
    public void Inventory_ItemsCollection_ShouldBeInitializable()
    {
        // Arrange
        var inventory = new Inventory();

        // Act
        inventory.Items = new List<Item>();

        // Assert
        inventory.Items.Should().NotBeNull();
        inventory.Items.Should().BeEmpty();
    }

    [Fact]
    public void Inventory_StorageUnitsCollection_ShouldAllowAdd()
    {
        // Arrange
        var inventory = new Inventory();
        inventory.StorageUnits = new List<StorageUnit>();
        var storageUnit = new StorageUnit { Id = 1, FullQuantity = 100 };

        // Act
        inventory.StorageUnits.Add(storageUnit);

        // Assert
        inventory.StorageUnits.Should().HaveCount(1);
        inventory.StorageUnits.Should().Contain(storageUnit);
    }

    [Fact]
    public void Inventory_ItemsCollection_ShouldAllowAdd()
    {
        // Arrange
        var inventory = new Inventory();
        inventory.Items = new List<Item>();
        var item = new Item { Id = 1, Name = "Test Item" };

        // Act
        inventory.Items.Add(item);

        // Assert
        inventory.Items.Should().HaveCount(1);
        inventory.Items.Should().Contain(item);
    }

    #endregion

    #region Client Collection Tests

    [Fact]
    public void Client_ClientPropertiesCollection_ShouldBeNullByDefault()
    {
        // Arrange & Act
        var client = new Client();

        // Assert
        client.ClientProperties.Should().BeNull("ClientProperties collection should be null! by default");
    }

    [Fact]
    public void Client_ClientPropertiesCollection_ShouldBeInitializable()
    {
        // Arrange
        var client = new Client();

        // Act
        client.ClientProperties = new List<ClientProperty>();

        // Assert
        client.ClientProperties.Should().NotBeNull();
        client.ClientProperties.Should().BeEmpty();
    }


    #endregion

    #region Customer Collection Tests

    [Fact]
    public void Customer_CustomerServicesCollection_ShouldBeInitializedByDefault()
    {
        // Arrange & Act
        var customer = new Customer();

        // Assert
        customer.CustomerServices.Should().NotBeNull("CustomerServices collection should be initialized by default");
        customer.CustomerServices.Should().BeEmpty("New collection should be empty");
    }

    [Fact]
    public void Customer_CustomerServicesCollection_ShouldAllowAdd()
    {
        // Arrange
        var customer = new Customer();
        var customerService = new CustomerService { Id = 1, ServiceId = 1 };

        // Act
        customer.CustomerServices.Add(customerService);

        // Assert
        customer.CustomerServices.Should().HaveCount(1);
        customer.CustomerServices.Should().Contain(customerService);
    }

    [Fact]
    public void Customer_CustomerPaymentMethodsCollection_ShouldBeInitializedByDefault()
    {
        // Arrange & Act
        var customer = new Customer();

        // Assert
        customer.CustomerPaymentMethods.Should().NotBeNull("CustomerPaymentMethods collection should be initialized by default");
        customer.CustomerPaymentMethods.Should().BeEmpty("New collection should be empty");
    }

    [Fact]
    public void Customer_CustomerPaymentMethodsCollection_ShouldAllowAdd()
    {
        // Arrange
        var customer = new Customer();
        var customerPaymentMethod = new CustomerPaymentMethod { Id = 1, PaymentMethodId = 1 };

        // Act
        customer.CustomerPaymentMethods.Add(customerPaymentMethod);

        // Assert
        customer.CustomerPaymentMethods.Should().HaveCount(1);
        customer.CustomerPaymentMethods.Should().Contain(customerPaymentMethod);
    }

    #endregion

    #region Supplier Collection Tests

    [Fact]
    public void Supplier_SupplierCategoriesCollection_ShouldBeNullByDefault()
    {
        // Arrange & Act
        var supplier = new Supplier();

        // Assert
        supplier.SupplierCategories.Should().BeNull("SupplierCategories collection should be null! by default");
    }

    [Fact]
    public void Supplier_SupplierCategoriesCollection_ShouldBeInitializable()
    {
        // Arrange
        var supplier = new Supplier();

        // Act
        supplier.SupplierCategories = new List<SupplierCategory>();

        // Assert
        supplier.SupplierCategories.Should().NotBeNull();
        supplier.SupplierCategories.Should().BeEmpty();
    }

    [Fact]
    public void Supplier_SupplierCategoriesCollection_ShouldAllowAdd()
    {
        // Arrange
        var supplier = new Supplier();
        supplier.SupplierCategories = new List<SupplierCategory>();
        var supplierCategory = new SupplierCategory { Id = 1, CategoryId = 1 };

        // Act
        supplier.SupplierCategories.Add(supplierCategory);

        // Assert
        supplier.SupplierCategories.Should().HaveCount(1);
        supplier.SupplierCategories.Should().Contain(supplierCategory);
    }

    #endregion

    #region Consumer Collection Tests

    [Fact]
    public void Consumer_ConsumerCustomersCollection_ShouldBeNullByDefault()
    {
        // Arrange & Act
        var consumer = new Consumer();

        // Assert
        consumer.ConsumerCustomers.Should().BeNull("ConsumerCustomers collection should be null! by default");
    }

    [Fact]
    public void Consumer_ConsumerCustomersCollection_ShouldBeInitializable()
    {
        // Arrange
        var consumer = new Consumer();

        // Act
        consumer.ConsumerCustomers = new List<ConsumerCustomer>();

        // Assert
        consumer.ConsumerCustomers.Should().NotBeNull();
        consumer.ConsumerCustomers.Should().BeEmpty();
    }

    [Fact]
    public void Consumer_ConsumerCustomersCollection_ShouldAllowAdd()
    {
        // Arrange
        var consumer = new Consumer();
        consumer.ConsumerCustomers = new List<ConsumerCustomer>();
        var consumerCustomer = new ConsumerCustomer { Id = 1, ConsumerId = 1, CategoryId = 1 };

        // Act
        consumer.ConsumerCustomers.Add(consumerCustomer);

        // Assert
        consumer.ConsumerCustomers.Should().HaveCount(1);
        consumer.ConsumerCustomers.Should().Contain(consumerCustomer);
    }

    [Fact]
    public void Consumer_ConsumerAccountsCollection_ShouldBeNullByDefault()
    {
        // Arrange & Act
        var consumer = new Consumer();

        // Assert
        consumer.ConsumerAccounts.Should().BeNull("ConsumerAccounts collection should be null! by default");
    }

    [Fact]
    public void Consumer_ConsumerAccountsCollection_ShouldBeInitializable()
    {
        // Arrange
        var consumer = new Consumer();

        // Act
        consumer.ConsumerAccounts = new List<ConsumerAccount>();

        // Assert
        consumer.ConsumerAccounts.Should().NotBeNull();
        consumer.ConsumerAccounts.Should().BeEmpty();
    }

    [Fact]
    public void Consumer_ConsumerAccountsCollection_ShouldAllowAdd()
    {
        // Arrange
        var consumer = new Consumer();
        consumer.ConsumerAccounts = new List<ConsumerAccount>();
        var consumerAccount = new ConsumerAccount { Id = 1, CompanyId = 1 };

        // Act
        consumer.ConsumerAccounts.Add(consumerAccount);

        // Assert
        consumer.ConsumerAccounts.Should().HaveCount(1);
        consumer.ConsumerAccounts.Should().Contain(consumerAccount);
    }

    #endregion

    #region Collection Relationship Tests

    [Fact]
    public void User_WithOrganization_ShouldMaintainBidirectionalRelationship()
    {
        // Arrange
        var user = new User { Id = 1, UserName = "testuser" };
        var organization = new Organization { Id = 1, Name = "Test Org" };
        organization.Addresses = new List<Address>();

        // Act
        user.Organization = organization;
        user.OrganizationId = organization.Id;

        // Assert
        user.Organization.Should().Be(organization);
        user.OrganizationId.Should().Be(organization.Id);
    }

    [Fact]
    public void Department_WithParentAndSubDepartments_ShouldMaintainHierarchy()
    {
        // Arrange
        var parentDept = new Department { Id = 1, Name = "Parent Department" };
        var childDept1 = new Department { Id = 2, Name = "Child Department 1" };
        var childDept2 = new Department { Id = 3, Name = "Child Department 2" };
        
        parentDept.SubDepartments = new List<Department>();
        childDept1.ParentDepartment = parentDept;
        childDept2.ParentDepartment = parentDept;

        // Act
        parentDept.SubDepartments.Add(childDept1);
        parentDept.SubDepartments.Add(childDept2);

        // Assert
        parentDept.SubDepartments.Should().HaveCount(2);
        childDept1.ParentDepartment.Should().Be(parentDept);
        childDept2.ParentDepartment.Should().Be(parentDept);
    }

    [Fact]
    public void Inventory_WithStorageUnitsAndItems_ShouldMaintainCollections()
    {
        // Arrange
        var inventory = new Inventory { Id = 1, Name = "Test Inventory" };
        inventory.StorageUnits = new List<StorageUnit>();
        inventory.Items = new List<Item>();

        var storageUnit = new StorageUnit { Id = 1, FullQuantity = 100 };
        var item = new Item { Id = 1, Name = "Test Item" };

        // Act
        inventory.StorageUnits.Add(storageUnit);
        inventory.Items.Add(item);

        // Assert
        inventory.StorageUnits.Should().HaveCount(1);
        inventory.Items.Should().HaveCount(1);
        inventory.StorageUnits.Should().Contain(storageUnit);
        inventory.Items.Should().Contain(item);
    }

    #endregion

    #region Collection Performance Tests

    [Fact]
    public void User_UserRolesCollection_ShouldHandleLargeNumberOfItems()
    {
        // Arrange
        var user = new User();
        user.UserRoles = new List<UserRole>();
        var userRoles = new List<UserRole>();

        // Act
        for (int i = 0; i < 1000; i++)
        {
            var userRole = new UserRole { UserId = 1, RoleId = i };
            userRoles.Add(userRole);
        }

        foreach (var userRole in userRoles)
        {
            user.UserRoles.Add(userRole);
        }

        // Assert
        user.UserRoles.Should().HaveCount(1000);
        user.UserRoles.Should().OnlyContain(ur => ur.UserId == 1);
    }

    [Fact]
    public void Organization_AddressesCollection_ShouldHandleLargeNumberOfItems()
    {
        // Arrange
        var organization = new Organization();
        organization.Addresses = new List<Address>();

        // Act
        for (int i = 0; i < 500; i++)
        {
            var address = new Address { Id = i, FullAddress = $"Address {i}" };
            organization.Addresses.Add(address);
        }

        // Assert
        organization.Addresses.Should().HaveCount(500);
        organization.Addresses.Should().OnlyContain(a => a.FullAddress.StartsWith("Address"));
    }

    #endregion

    #region Collection Validation Tests

    [Fact]
    public void User_UserRolesCollection_ShouldNotAllowDuplicateRoles()
    {
        // Arrange
        var user = new User();
        user.UserRoles = new List<UserRole>();
        var userRole1 = new UserRole { UserId = 1, RoleId = 1 };
        var userRole2 = new UserRole { UserId = 1, RoleId = 1 }; // Same role

        // Act
        user.UserRoles.Add(userRole1);
        user.UserRoles.Add(userRole2); // This should be allowed by the collection

        // Assert
        user.UserRoles.Should().HaveCount(2); // List allows duplicates
        user.UserRoles.Should().Contain(userRole1);
        user.UserRoles.Should().Contain(userRole2);
    }

    [Fact]
    public void User_UserRolesCollection_ShouldAllowSameRoleDifferentUsers()
    {
        // Arrange
        var user = new User();
        user.UserRoles = new List<UserRole>();
        var userRole1 = new UserRole { UserId = 1, RoleId = 1 };
        var userRole2 = new UserRole { UserId = 2, RoleId = 1 }; // Different user, same role

        // Act
        user.UserRoles.Add(userRole1);
        user.UserRoles.Add(userRole2);

        // Assert
        user.UserRoles.Should().HaveCount(2);
        user.UserRoles.Should().Contain(userRole1);
        user.UserRoles.Should().Contain(userRole2);
    }

    #endregion
}
