# PaymentMethod Unit Test Plan

## Test Class: PaymentMethodTests

**Target Entity**: `BackendWebService.Domain/Entities/InventoryModule/PaymentMethods/PaymentMethod.cs`

## Test Categories and Scenarios

### 1. Constructor Tests (3 test cases)

#### 1.1 Default Values Test
```csharp
[Fact]
public void PaymentMethod_Constructor_ShouldSetDefaultValues()
```
**Purpose**: Verify all default values are set correctly
**Assertions**:
- `IsDefault` should be `false`
- `IsVerified` should be `false`
- `CreatedAt` should be close to `DateTime.UtcNow`
- `UpdatedAt` should be `null`

#### 1.2 Required Properties Test
```csharp
[Fact]
public void PaymentMethod_Constructor_ShouldInitializeRequiredProperties()
```
**Purpose**: Verify required properties are properly initialized
**Assertions**:
- All `[Required]` properties are accessible
- Properties can be set without exceptions

#### 1.3 Inheritance Test
```csharp
[Fact]
public void PaymentMethod_ShouldInheritFromBaseEntity()
```
**Purpose**: Verify inheritance from BaseEntity works correctly
**Assertions**:
- Should implement `IEntity` interface
- Should implement `ITimeModification` interface
- Should have access to BaseEntity properties

### 2. Property Validation Tests (8 test cases)

#### 2.1 MethodType Validation
```csharp
[Theory]
[InlineData("Credit Card", true)]
[InlineData("Debit Card", true)]
[InlineData("Mobile Payment", true)]
[InlineData("", false)]
[InlineData(null, false)]
[InlineData("A".PadRight(51), false)]
public void PaymentMethod_MethodType_ShouldValidateCorrectly(string methodType, bool isValid)
```
**Purpose**: Test MethodType property validation
**Assertions**:
- Valid values should be accepted
- Empty/null values should be rejected
- Values exceeding MaxLength(50) should be rejected

#### 2.2 Provider Validation
```csharp
[Theory]
[InlineData("Visa", true)]
[InlineData("MasterCard", true)]
[InlineData("PayPal", true)]
[InlineData("", false)]
[InlineData(null, false)]
[InlineData("A".PadRight(51), false)]
public void PaymentMethod_Provider_ShouldValidateCorrectly(string provider, bool isValid)
```
**Purpose**: Test Provider property validation
**Assertions**:
- Valid providers should be accepted
- Empty/null values should be rejected
- Values exceeding MaxLength(50) should be rejected

#### 2.3 AccountNumber Validation
```csharp
[Theory]
[InlineData("1234567890123456", true)]
[InlineData("4111-1111-1111-1111", true)]
[InlineData("", false)]
[InlineData(null, false)]
[InlineData("A".PadRight(101), false)]
public void PaymentMethod_AccountNumber_ShouldValidateCorrectly(string accountNumber, bool isValid)
```
**Purpose**: Test AccountNumber property validation
**Assertions**:
- Valid account numbers should be accepted
- Empty/null values should be rejected
- Values exceeding MaxLength(100) should be rejected

#### 2.4 Name Validation
```csharp
[Theory]
[InlineData("My Credit Card", true)]
[InlineData("Primary Payment", true)]
[InlineData("", false)]
[InlineData(null, false)]
[InlineData("A".PadRight(51), false)]
public void PaymentMethod_Name_ShouldValidateCorrectly(string name, bool isValid)
```
**Purpose**: Test Name property validation
**Assertions**:
- Valid names should be accepted
- Empty/null values should be rejected
- Values exceeding MaxLength(50) should be rejected

#### 2.5 Type Validation
```csharp
[Theory]
[InlineData(PaymentEnum.CreditCard, true)]
[InlineData(PaymentEnum.DebitCard, true)]
[InlineData(PaymentEnum.MobilePayment, true)]
[InlineData(PaymentEnum.Cash, true)]
[InlineData(PaymentEnum.OnlinePayment, true)]
[InlineData(PaymentEnum.Crypto, true)]
public void PaymentMethod_Type_ShouldAcceptValidEnumValues(PaymentEnum type, bool isValid)
```
**Purpose**: Test Type property validation
**Assertions**:
- All valid PaymentEnum values should be accepted
- Invalid enum values should be rejected

### 3. Business Logic Tests (4 test cases)

#### 3.1 Expiry Date Logic
```csharp
[Theory]
[InlineData("2025-12-31", true)]
[InlineData("2030-01-01", true)]
[InlineData("2020-01-01", false)]
[InlineData(null, true)]
public void PaymentMethod_ExpiryDate_ShouldValidateCorrectly(DateTime? expiryDate, bool isValid)
```
**Purpose**: Test expiry date business logic
**Assertions**:
- Future dates should be valid
- Past dates should be invalid
- Null expiry date should be valid

#### 3.2 Verification Status
```csharp
[Fact]
public void PaymentMethod_VerificationStatus_ShouldBeMutable()
```
**Purpose**: Test verification status can be changed
**Assertions**:
- Can be set to `true`
- Can be set to `false`
- Default value is `false`

#### 3.3 Default Status
```csharp
[Fact]
public void PaymentMethod_DefaultStatus_ShouldBeMutable()
```
**Purpose**: Test default status can be changed
**Assertions**:
- Can be set to `true`
- Can be set to `false`
- Default value is `false`

#### 3.4 Timestamp Management
```csharp
[Fact]
public void PaymentMethod_Timestamps_ShouldBeManagedCorrectly()
```
**Purpose**: Test timestamp management
**Assertions**:
- `CreatedAt` is set on creation
- `UpdatedAt` is null initially
- `UpdatedAt` is set on modification

### 4. Business Rules Tests (4 test cases)

#### 4.1 Account Number Format Validation
```csharp
[Theory]
[InlineData("4111111111111111", PaymentEnum.CreditCard, true)]
[InlineData("4111-1111-1111-1111", PaymentEnum.CreditCard, true)]
[InlineData("1234567890", PaymentEnum.DebitCard, true)]
[InlineData("invalid", PaymentEnum.CreditCard, false)]
public void PaymentMethod_AccountNumberFormat_ShouldValidateBasedOnType(string accountNumber, PaymentEnum type, bool isValid)
```
**Purpose**: Test account number format validation based on payment type
**Assertions**:
- Credit card numbers should follow credit card format
- Debit card numbers should follow debit card format
- Invalid formats should be rejected

#### 4.2 Provider-MethodType Consistency
```csharp
[Theory]
[InlineData("Visa", PaymentEnum.CreditCard, true)]
[InlineData("MasterCard", PaymentEnum.CreditCard, true)]
[InlineData("PayPal", PaymentEnum.OnlinePayment, true)]
[InlineData("Apple Pay", PaymentEnum.MobilePayment, true)]
[InlineData("Visa", PaymentEnum.DebitCard, false)]
[InlineData("PayPal", PaymentEnum.CreditCard, false)]
public void PaymentMethod_ProviderMethodTypeConsistency_ShouldBeValidated(string provider, PaymentEnum type, bool isValid)
```
**Purpose**: Test provider-method type consistency
**Assertions**:
- Valid provider-type combinations should be accepted
- Invalid provider-type combinations should be rejected

#### 4.3 Expiry Date Business Rules
```csharp
[Theory]
[InlineData("2025-12-31", true)]
[InlineData("2035-01-01", false)] // More than 10 years
[InlineData("2020-01-01", false)] // Past date
public void PaymentMethod_ExpiryDateBusinessRules_ShouldBeEnforced(DateTime expiryDate, bool isValid)
```
**Purpose**: Test expiry date business rules
**Assertions**:
- Future dates within 10 years should be valid
- Dates more than 10 years in future should be invalid
- Past dates should be invalid

#### 4.4 Default Payment Method Rules
```csharp
[Fact]
public void PaymentMethod_DefaultPaymentMethodRules_ShouldBeEnforced()
```
**Purpose**: Test default payment method business rules
**Assertions**:
- Only verified payment methods can be default
- Only one payment method can be default per user
- Cannot set default if not verified

### 5. Edge Cases Tests (6 test cases)

#### 5.1 Boundary Value Testing
```csharp
[Theory]
[InlineData(50, true)]  // MaxLength for MethodType
[InlineData(51, false)] // Exceeds MaxLength for MethodType
[InlineData(100, true)] // MaxLength for AccountNumber
[InlineData(101, false)] // Exceeds MaxLength for AccountNumber
public void PaymentMethod_BoundaryValues_ShouldBeHandledCorrectly(int length, bool isValid)
```
**Purpose**: Test boundary values for string length constraints
**Assertions**:
- Values at MaxLength should be valid
- Values exceeding MaxLength should be invalid

#### 5.2 Null Handling
```csharp
[Fact]
public void PaymentMethod_NullValues_ShouldBeHandledCorrectly()
```
**Purpose**: Test null value handling
**Assertions**:
- Required string properties should reject null
- Optional properties should accept null
- ExpiryDate should accept null

#### 5.3 Special Characters
```csharp
[Theory]
[InlineData("Visa®", true)]
[InlineData("MasterCard™", true)]
[InlineData("PayPal (Official)", true)]
[InlineData("", false)]
public void PaymentMethod_SpecialCharacters_ShouldBeHandledCorrectly(string provider, bool isValid)
```
**Purpose**: Test special character handling
**Assertions**:
- Valid special characters should be accepted
- Empty strings should be rejected

## Test Data Setup

### Test Fixtures
```csharp
public class PaymentMethodTestData
{
    public static IEnumerable<object[]> ValidPaymentMethods => new[]
    {
        new object[] { "Credit Card", "Visa", "4111111111111111", "My Visa Card", PaymentEnum.CreditCard },
        new object[] { "Debit Card", "MasterCard", "5555555555554444", "My Debit Card", PaymentEnum.DebitCard },
        new object[] { "Mobile Payment", "Apple Pay", "1234567890", "Apple Pay", PaymentEnum.MobilePayment }
    };
    
    public static IEnumerable<object[]> InvalidPaymentMethods => new[]
    {
        new object[] { "", "Visa", "4111111111111111", "My Visa Card", PaymentEnum.CreditCard },
        new object[] { "Credit Card", "", "4111111111111111", "My Visa Card", PaymentEnum.CreditCard },
        new object[] { "Credit Card", "Visa", "", "My Visa Card", PaymentEnum.CreditCard }
    };
}
```

## Test Coverage Goals

- **Line Coverage**: 95%+
- **Branch Coverage**: 90%+
- **Method Coverage**: 100%

## Implementation Timeline

### Phase 1: Basic Tests (Week 1)
- Constructor tests
- Basic property validation tests
- Estimated: 8 test cases

### Phase 2: Business Logic (Week 2)
- Business logic tests
- Timestamp management tests
- Estimated: 4 test cases

### Phase 3: Business Rules (Week 3)
- Business rules tests
- Validation logic tests
- Estimated: 4 test cases

### Phase 4: Edge Cases (Week 4)
- Edge case tests
- Boundary value tests
- Estimated: 6 test cases

## Success Criteria

1. All 25-30 test cases pass
2. Coverage goals are met
3. Tests run in under 1 second
4. Tests are maintainable and readable
5. Tests serve as template for other entities
