using Domain.Enums;
using FluentAssertions;
using System.ComponentModel.DataAnnotations;
using Xunit;

namespace BackendWebService.Domain.UnitTests;

public class EnumTests
{
    #region StatusEnum Tests

    [Theory]
    [InlineData(StatusEnum.Saved, 0)]
    [InlineData(StatusEnum.New, 1)]
    [InlineData(StatusEnum.Hold, 2)]
    [InlineData(StatusEnum.Active, 3)]
    [InlineData(StatusEnum.Scored, 4)]
    [InlineData(StatusEnum.Returned, 5)]
    [InlineData(StatusEnum.Accepted, 6)]
    [InlineData(StatusEnum.PendingApproval, 7)]
    [InlineData(StatusEnum.Disabled, 8)]
    [InlineData(StatusEnum.Suspended, 9)]
    [InlineData(StatusEnum.Deleted, 10)]
    [InlineData(StatusEnum.OnTheWay, 11)]
    [InlineData(StatusEnum.Arrived, 12)]
    [InlineData(StatusEnum.InProgress, 13)]
    [InlineData(StatusEnum.Completed, 14)]
    [InlineData(StatusEnum.IssueReported, 15)]
    [InlineData(StatusEnum.Pending, 16)]
    public void StatusEnum_ShouldHaveCorrectValues(StatusEnum status, int expectedValue)
    {
        // Act & Assert
        ((int)status).Should().Be(expectedValue);
    }

    [Fact]
    public void StatusEnum_ShouldHaveDisplayAttributes()
    {
        // Arrange
        var statusType = typeof(StatusEnum);
        var fields = statusType.GetFields().Where(f => f.IsLiteral);

        // Act & Assert
        foreach (var field in fields)
        {
            var displayAttribute = field.GetCustomAttributes(typeof(DisplayAttribute), false)
                .FirstOrDefault() as DisplayAttribute;
            
            displayAttribute.Should().NotBeNull($"Field {field.Name} should have DisplayAttribute");
            displayAttribute.Name.Should().NotBeNullOrEmpty($"Field {field.Name} should have Name");
            displayAttribute.Description.Should().NotBeNullOrEmpty($"Field {field.Name} should have Description");
        }
    }

    [Theory]
    [InlineData(StatusEnum.Saved, "Saved", "تم الحفظ")]
    [InlineData(StatusEnum.New, "New", "جديد")]
    [InlineData(StatusEnum.Hold, "Hold", "معلّق")]
    [InlineData(StatusEnum.Active, "Active", "نشط")]
    [InlineData(StatusEnum.Scored, "Scored", "تم التقييم")]
    [InlineData(StatusEnum.Returned, "Returned", "تم الإرجاع")]
    [InlineData(StatusEnum.Accepted, "Accepted", "تم القبول")]
    [InlineData(StatusEnum.PendingApproval, "PendingApproval", "بانتظار الموافقة")]
    [InlineData(StatusEnum.Disabled, "Disabled", "معطل")]
    [InlineData(StatusEnum.Suspended, "Suspended", "موقوف مؤقتاً")]
    [InlineData(StatusEnum.Deleted, "Deleted", "محذوف")]
    [InlineData(StatusEnum.OnTheWay, "OnTheWay", "في الطريق")]
    [InlineData(StatusEnum.Arrived, "Arrived", "تم الوصول")]
    [InlineData(StatusEnum.InProgress, "InProgress", "قيد التنفيذ")]
    [InlineData(StatusEnum.Completed, "Completed", "مكتمل")]
    [InlineData(StatusEnum.IssueReported, "IssueReported", "تم الإبلاغ عن مشكلة")]
    [InlineData(StatusEnum.Pending, "Pending", "قيد الانتظار")]
    public void StatusEnum_ShouldHaveCorrectDisplayAttributes(StatusEnum status, string expectedName, string expectedDescription)
    {
        // Arrange
        var field = typeof(StatusEnum).GetField(status.ToString());
        var displayAttribute = field.GetCustomAttributes(typeof(DisplayAttribute), false)
            .FirstOrDefault() as DisplayAttribute;

        // Act & Assert
        displayAttribute.Should().NotBeNull();
        displayAttribute.Name.Should().Be(expectedName);
        displayAttribute.Description.Should().Be(expectedDescription);
    }

    #endregion

    #region ActionEnum Tests

    [Theory]
    [InlineData(ActionEnum.Request, 1)]
    [InlineData(ActionEnum.Assign, 2)]
    [InlineData(ActionEnum.Forward, 3)]
    [InlineData(ActionEnum.Start, 4)]
    [InlineData(ActionEnum.Open, 5)]
    [InlineData(ActionEnum.Resume, 6)]
    [InlineData(ActionEnum.Reopen, 7)]
    [InlineData(ActionEnum.Pause, 8)]
    [InlineData(ActionEnum.Hold, 9)]
    [InlineData(ActionEnum.Unhold, 10)]
    [InlineData(ActionEnum.Suspend, 11)]
    [InlineData(ActionEnum.Review, 12)]
    [InlineData(ActionEnum.Score, 13)]
    [InlineData(ActionEnum.Approve, 14)]
    [InlineData(ActionEnum.Reject, 15)]
    [InlineData(ActionEnum.Complete, 16)]
    [InlineData(ActionEnum.Payment, 17)]
    [InlineData(ActionEnum.Withdraw, 18)]
    [InlineData(ActionEnum.Cancel, 19)]
    [InlineData(ActionEnum.Return, 20)]
    [InlineData(ActionEnum.Close, 21)]
    [InlineData(ActionEnum.Stop, 22)]
    public void ActionEnum_ShouldHaveCorrectValues(ActionEnum action, int expectedValue)
    {
        // Act & Assert
        ((int)action).Should().Be(expectedValue);
    }

    [Fact]
    public void ActionEnum_ShouldHaveDisplayAttributes()
    {
        // Arrange
        var actionType = typeof(ActionEnum);
        var fields = actionType.GetFields().Where(f => f.IsLiteral);

        // Act & Assert
        foreach (var field in fields)
        {
            var displayAttribute = field.GetCustomAttributes(typeof(DisplayAttribute), false)
                .FirstOrDefault() as DisplayAttribute;
            
            displayAttribute.Should().NotBeNull($"Field {field.Name} should have DisplayAttribute");
            displayAttribute.Name.Should().NotBeNullOrEmpty($"Field {field.Name} should have Name");
        }
    }

    #endregion

    #region TransactionEnum Tests

    [Theory]
    [InlineData(TransactionEnum.Subscription, 1)]
    [InlineData(TransactionEnum.Payment, 2)]
    [InlineData(TransactionEnum.Refund, 3)]
    [InlineData(TransactionEnum.Withdrawal, 4)]
    [InlineData(TransactionEnum.Deposit, 5)]
    [InlineData(TransactionEnum.Transfer, 6)]
    [InlineData(TransactionEnum.Adjustment, 7)]
    [InlineData(TransactionEnum.Charge, 8)]
    [InlineData(TransactionEnum.Fee, 9)]
    [InlineData(TransactionEnum.Interest, 10)]
    [InlineData(TransactionEnum.Dividend, 11)]
    [InlineData(TransactionEnum.Bonus, 12)]
    [InlineData(TransactionEnum.Rebate, 13)]
    [InlineData(TransactionEnum.Reward, 14)]
    [InlineData(TransactionEnum.Commission, 15)]
    [InlineData(TransactionEnum.Tax, 16)]
    [InlineData(TransactionEnum.Penalty, 17)]
    [InlineData(TransactionEnum.Fine, 18)]
    [InlineData(TransactionEnum.Loan, 19)]
    [InlineData(TransactionEnum.Repayment, 20)]
    [InlineData(TransactionEnum.Insurance, 21)]
    [InlineData(TransactionEnum.Claim, 22)]
    public void TransactionEnum_ShouldHaveCorrectValues(TransactionEnum transaction, int expectedValue)
    {
        // Act & Assert
        ((int)transaction).Should().Be(expectedValue);
    }

    [Fact]
    public void TransactionEnum_ShouldHaveDisplayAttributes()
    {
        // Arrange
        var transactionType = typeof(TransactionEnum);
        var fields = transactionType.GetFields().Where(f => f.IsLiteral);

        // Act & Assert
        foreach (var field in fields)
        {
            var displayAttribute = field.GetCustomAttributes(typeof(DisplayAttribute), false)
                .FirstOrDefault() as DisplayAttribute;
            
            displayAttribute.Should().NotBeNull($"Field {field.Name} should have DisplayAttribute");
            displayAttribute.Name.Should().NotBeNullOrEmpty($"Field {field.Name} should have Name");
            displayAttribute.Description.Should().NotBeNullOrEmpty($"Field {field.Name} should have Description");
        }
    }

    #endregion

    #region TableNameEnum Tests

    [Fact]
    public void TableNameEnum_ShouldHaveDisplayAttributes()
    {
        // Arrange
        var tableNameType = typeof(TableNameEnum);
        var fields = tableNameType.GetFields().Where(f => f.IsLiteral);

        // Act & Assert
        foreach (var field in fields)
        {
            var displayAttribute = field.GetCustomAttributes(typeof(DisplayAttribute), false)
                .FirstOrDefault() as DisplayAttribute;
            
            displayAttribute.Should().NotBeNull($"Field {field.Name} should have DisplayAttribute");
            displayAttribute.Name.Should().NotBeNullOrEmpty($"Field {field.Name} should have Name");
            displayAttribute.Description.Should().NotBeNullOrEmpty($"Field {field.Name} should have Description");
        }
    }

    [Theory]
    [InlineData(TableNameEnum.Logging, "Logging", "سجل الأحداث")]
    [InlineData(TableNameEnum.TranslationKey, "TranslationKey", "مفاتيح الترجمة")]
    [InlineData(TableNameEnum.Customer, "Customer", "العميل")]
    [InlineData(TableNameEnum.CustomerAccount, "CustomerAccount", "حساب العميل")]
    [InlineData(TableNameEnum.CustomerProperty, "CustomerProperty", "عقار العميل")]
    [InlineData(TableNameEnum.CustomerService, "CustomerService", "خدمة العميل")]
    [InlineData(TableNameEnum.Family, "Family", "الأسرة")]
    [InlineData(TableNameEnum.Member, "Member", "العضو")]
    [InlineData(TableNameEnum.Attachment, "Attachment", "المرفق")]
    [InlineData(TableNameEnum.EmailLog, "EmailLog", "سجل البريد الإلكتروني")]
    [InlineData(TableNameEnum.Recipient, "Recipient", "المستلم")]
    [InlineData(TableNameEnum.ExceptionLog, "ExceptionLog", "سجل الاستثناءات")]
    [InlineData(TableNameEnum.FileFieldValidator, "FileFieldValidator", "محقق صحة الحقول")]
    [InlineData(TableNameEnum.FileLog, "FileLog", "سجل الملفات")]
    [InlineData(TableNameEnum.FileType, "FileType", "نوع الملف")]
    [InlineData(TableNameEnum.UserRefreshToken, "UserRefreshToken", "رمز تجديد الدخول")]
    [InlineData(TableNameEnum.Category, "Category", "التصنيف")]
    [InlineData(TableNameEnum.Part, "Part", "الجزء")]
    [InlineData(TableNameEnum.Product, "Product", "المنتج")]
    [InlineData(TableNameEnum.Service, "Service", "الخدمة")]
    [InlineData(TableNameEnum.Spare, "Spare", "البديل")]
    public void TableNameEnum_ShouldHaveCorrectDisplayAttributes(TableNameEnum tableName, string expectedName, string expectedDescription)
    {
        // Arrange
        var field = typeof(TableNameEnum).GetField(tableName.ToString());
        var displayAttribute = field.GetCustomAttributes(typeof(DisplayAttribute), false)
            .FirstOrDefault() as DisplayAttribute;

        // Act & Assert
        displayAttribute.Should().NotBeNull();
        displayAttribute.Name.Should().Be(expectedName);
        displayAttribute.Description.Should().Be(expectedDescription);
    }

    #endregion

    #region ALLEnum Tests

    [Fact]
    public void ALLEnum_ShouldHaveDisplayAttributes()
    {
        // Arrange
        var allEnumType = typeof(ALLEnum);
        var fields = allEnumType.GetFields().Where(f => f.IsLiteral);

        // Act & Assert
        foreach (var field in fields)
        {
            var displayAttribute = field.GetCustomAttributes(typeof(DisplayAttribute), false)
                .FirstOrDefault() as DisplayAttribute;
            
            displayAttribute.Should().NotBeNull($"Field {field.Name} should have DisplayAttribute");
            displayAttribute.Description.Should().NotBeNullOrEmpty($"Field {field.Name} should have Description");
        }
    }

    [Theory]
    [InlineData(ALLEnum.ActionEnum, "الإجراءات")]
    [InlineData(ALLEnum.AccessEnum, "الصلاحيات")]
    [InlineData(ALLEnum.ActorEnum, "الجهة الفاعلة")]
    [InlineData(ALLEnum.ApiResultStatusCode, "كود نتيجة الواجهة")]
    [InlineData(ALLEnum.AvailabilityEnum, "التوافر")]
    [InlineData(ALLEnum.ConfigurationEnum, "الإعدادات")]
    [InlineData(ALLEnum.CurrencyEnum, "العملة")]
    [InlineData(ALLEnum.DisplayProperty, "خصائص العرض")]
    [InlineData(ALLEnum.ExceptionEnum, "أنواع الاستثناءات")]
    [InlineData(ALLEnum.FileTypeEnum, "أنواع الملفات")]
    [InlineData(ALLEnum.FilterEnum, "عامل التصفية")]
    [InlineData(ALLEnum.LanguageEnum, "اللغة")]
    [InlineData(ALLEnum.OrganizationEnum, "المنظمة")]
    [InlineData(ALLEnum.PaymentEnum, "الدفع")]
    [InlineData(ALLEnum.RoleEnum, "الأدوار")]
    [InlineData(ALLEnum.SizeEnum, "الحجم")]
    [InlineData(ALLEnum.StatusEnum, "الحالة")]
    [InlineData(ALLEnum.TableNameEnum, "اسم الجدول")]
    [InlineData(ALLEnum.TransactionEnum, "المعاملة")]
    [InlineData(ALLEnum.UnitEnum, "الوحدة")]
    [InlineData(ALLEnum.ValidatorEnum, "التحقق")]
    [InlineData(ALLEnum.VerificationEnum, "التوثيق")]
    [InlineData(ALLEnum.ContactEnum, "جهة الاتصال")]
    [InlineData(ALLEnum.ManagerEnum, "الإداريون")]
    public void ALLEnum_ShouldHaveCorrectDisplayAttributes(ALLEnum allEnum, string expectedDescription)
    {
        // Arrange
        var field = typeof(ALLEnum).GetField(allEnum.ToString());
        var displayAttribute = field.GetCustomAttributes(typeof(DisplayAttribute), false)
            .FirstOrDefault() as DisplayAttribute;

        // Act & Assert
        displayAttribute.Should().NotBeNull();
        displayAttribute.Description.Should().Be(expectedDescription);
    }

    #endregion

    #region Enum Conversion Tests

    [Theory]
    [InlineData(0, StatusEnum.Saved)]
    [InlineData(1, StatusEnum.New)]
    [InlineData(16, StatusEnum.Pending)]
    public void StatusEnum_ShouldConvertFromInt(int value, StatusEnum expectedStatus)
    {
        // Act
        var status = (StatusEnum)value;

        // Assert
        status.Should().Be(expectedStatus);
    }

    [Theory]
    [InlineData(StatusEnum.Saved, 0)]
    [InlineData(StatusEnum.New, 1)]
    [InlineData(StatusEnum.Pending, 16)]
    public void StatusEnum_ShouldConvertToInt(StatusEnum status, int expectedValue)
    {
        // Act
        var value = (int)status;

        // Assert
        value.Should().Be(expectedValue);
    }

    [Fact]
    public void StatusEnum_ShouldBeEnumerable()
    {
        // Act
        var statusValues = Enum.GetValues<StatusEnum>();

        // Assert
        statusValues.Should().HaveCount(17);
        statusValues.Should().Contain(StatusEnum.Saved);
        statusValues.Should().Contain(StatusEnum.Pending);
    }

    [Fact]
    public void ActionEnum_ShouldBeEnumerable()
    {
        // Act
        var actionValues = Enum.GetValues<ActionEnum>();

        // Assert
        actionValues.Should().HaveCount(22);
        actionValues.Should().Contain(ActionEnum.Request);
        actionValues.Should().Contain(ActionEnum.Stop);
    }

    [Fact]
    public void TransactionEnum_ShouldBeEnumerable()
    {
        // Act
        var transactionValues = Enum.GetValues<TransactionEnum>();

        // Assert
        transactionValues.Should().HaveCount(25);
        transactionValues.Should().Contain(TransactionEnum.Subscription);
        transactionValues.Should().Contain(TransactionEnum.Settlement);
    }

    #endregion

    #region Enum String Conversion Tests

    [Theory]
    [InlineData(StatusEnum.Saved, "Saved")]
    [InlineData(StatusEnum.New, "New")]
    [InlineData(StatusEnum.Active, "Active")]
    [InlineData(StatusEnum.Pending, "Pending")]
    public void StatusEnum_ShouldConvertToString(StatusEnum status, string expectedString)
    {
        // Act
        var stringValue = status.ToString();

        // Assert
        stringValue.Should().Be(expectedString);
    }

    [Theory]
    [InlineData("Saved", StatusEnum.Saved)]
    [InlineData("New", StatusEnum.New)]
    [InlineData("Active", StatusEnum.Active)]
    [InlineData("Pending", StatusEnum.Pending)]
    public void StatusEnum_ShouldParseFromString(string stringValue, StatusEnum expectedStatus)
    {
        // Act
        var status = Enum.Parse<StatusEnum>(stringValue);

        // Assert
        status.Should().Be(expectedStatus);
    }

    [Theory]
    [InlineData("INVALID_STATUS")]
    [InlineData("")]
    [InlineData(null)]
    public void StatusEnum_ShouldThrowOnInvalidString(string invalidString)
    {
        // Act & Assert
        var action = () => Enum.Parse<StatusEnum>(invalidString);
        action.Should().Throw<ArgumentException>();
    }

    #endregion
}
