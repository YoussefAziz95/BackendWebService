# Domain Entity Analysis for Unit Testing

## Selected Entity: PaymentMethod

**Location**: `BackendWebService.Domain/Entities/InventoryModule/PaymentMethods/PaymentMethod.cs`

## Entity Overview

The `PaymentMethod` entity represents a user's payment method in the system. It's a core business entity that handles various payment types including credit cards, debit cards, mobile payments, and cryptocurrency.

## Why PaymentMethod Was Selected

### ✅ Meets All Selection Criteria

1. **Has Validation Logic**: 
   - Multiple `[Required]` attributes
   - `[MaxLength]` constraints on string properties
   - Business rules for expiry dates and verification status

2. **Moderate Complexity**: 
   - 12 properties (not too simple, not overwhelming)
   - Clear business logic without excessive relationships
   - Good balance of data and behavior

3. **Minimal External Dependencies**: 
   - Only depends on `User` entity (via `UserId`)
   - No complex navigation properties or circular dependencies
   - Self-contained business logic

4. **Core Business Entity**: 
   - Essential for payment processing
   - Critical for e-commerce functionality
   - High business value

## Entity Structure Analysis

```csharp
public class PaymentMethod : BaseEntity, IEntity, ITimeModification
{
    // Required Properties
    public int UserId { get; set; }
    public string MethodType { get; set; }        // MaxLength(50)
    public string Provider { get; set; }          // MaxLength(50)
    public string AccountNumber { get; set; }     // MaxLength(100)
    public string Name { get; set; }              // MaxLength(50)
    public PaymentEnum Type { get; set; }
    
    // Optional Properties with Defaults
    public bool IsDefault { get; set; } = false;
    public bool IsVerified { get; set; } = false;
    public DateTime? ExpiryDate { get; set; }
    
    // Computed Properties
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }
}
```

## Testable Behaviors

### 1. Constructor Validation Rules
- **Default Values**: `IsDefault = false`, `IsVerified = false`, `CreatedAt = DateTime.UtcNow`
- **Required Field Validation**: All `[Required]` properties must be set
- **String Length Validation**: MaxLength constraints on string properties

### 2. Property Setters with Validation
- **MethodType**: Required, MaxLength(50)
- **Provider**: Required, MaxLength(50) 
- **AccountNumber**: Required, MaxLength(100)
- **Name**: Required, MaxLength(50)
- **Type**: Required, must be valid PaymentEnum value

### 3. Business Logic Methods (Implicit)
- **Expiry Date Logic**: Can be null or future date
- **Verification Status**: Can be set to true/false
- **Default Status**: Only one payment method can be default per user
- **Update Timestamp**: Should be set when entity is modified

### 4. Computed Properties
- **CreatedAt**: Automatically set to current UTC time
- **UpdatedAt**: Null initially, set when modified
- **IsExpired**: Computed property based on ExpiryDate (if implemented)

### 5. Business Rules
- **Account Number Format**: Should be validated based on payment type
- **Expiry Date Validation**: Must be future date if provided
- **Provider-MethodType Consistency**: Certain providers only support specific method types
- **Default Payment Method**: Only one can be default per user

## Test Scenarios Outline

### Constructor Tests
1. **Default Values**: Verify all default values are set correctly
2. **Required Properties**: Ensure required properties are properly initialized
3. **Inheritance**: Verify inheritance from BaseEntity works correctly

### Property Validation Tests
4. **MethodType Validation**: 
   - Valid values (Credit Card, Debit Card, etc.)
   - Null/empty validation
   - MaxLength(50) validation
5. **Provider Validation**:
   - Valid providers (Visa, MasterCard, PayPal, etc.)
   - Null/empty validation
   - MaxLength(50) validation
6. **AccountNumber Validation**:
   - Valid account number formats
   - Null/empty validation
   - MaxLength(100) validation
7. **Name Validation**:
   - Valid names
   - Null/empty validation
   - MaxLength(50) validation
8. **Type Validation**:
   - Valid PaymentEnum values
   - Invalid enum values

### Business Logic Tests
9. **Expiry Date Logic**:
   - Valid future dates
   - Past dates (should be invalid)
   - Null expiry date (valid)
10. **Verification Status**:
    - Can be set to true/false
    - Default value is false
11. **Default Status**:
    - Can be set to true/false
    - Default value is false
12. **Timestamp Management**:
    - CreatedAt is set on creation
    - UpdatedAt is null initially
    - UpdatedAt is set on modification

### Business Rules Tests
13. **Account Number Format Validation**:
    - Credit card format validation
    - Debit card format validation
    - Mobile payment format validation
14. **Provider-MethodType Consistency**:
    - Visa only with CreditCard type
    - PayPal only with OnlinePayment type
    - Apple Pay only with MobilePayment type
15. **Expiry Date Business Rules**:
    - Must be future date if provided
    - Cannot be more than 10 years in future
16. **Default Payment Method Rules**:
    - Only one default per user
    - Cannot set default if not verified

### Edge Cases
17. **Boundary Value Testing**:
    - MaxLength boundary values
    - Date boundary values
    - Enum boundary values
18. **Null Handling**:
    - Null string properties
    - Null expiry date
    - Null user ID
19. **Special Characters**:
    - Account numbers with special characters
    - Names with unicode characters
    - Provider names with special characters

## Estimated Test Cases

### Total Estimated Test Cases: **25-30**

**Breakdown:**
- Constructor Tests: 3 test cases
- Property Validation Tests: 8 test cases  
- Business Logic Tests: 4 test cases
- Business Rules Tests: 4 test cases
- Edge Cases: 6-11 test cases

### Test Coverage Goals
- **Line Coverage**: 95%+
- **Branch Coverage**: 90%+
- **Method Coverage**: 100%

## Test Implementation Strategy

### Phase 1: Basic Validation (8 test cases)
- Constructor default values
- Required property validation
- String length validation
- Enum validation

### Phase 2: Business Logic (6 test cases)
- Expiry date logic
- Verification status
- Default status
- Timestamp management

### Phase 3: Business Rules (6 test cases)
- Account number format validation
- Provider-method type consistency
- Expiry date business rules
- Default payment method rules

### Phase 4: Edge Cases (5-10 test cases)
- Boundary value testing
- Null handling
- Special character handling

## Benefits of Testing PaymentMethod

1. **High Business Value**: Payment processing is critical functionality
2. **Good Learning Example**: Demonstrates various testing patterns
3. **Real-world Complexity**: Actual business rules and validation
4. **Maintainable**: Clear, focused entity without excessive dependencies
5. **Comprehensive Coverage**: Multiple testing scenarios in one entity

## Next Steps

1. Create `PaymentMethodTests` class
2. Implement test cases in phases
3. Verify coverage meets goals
4. Document test patterns for other entities
5. Use as template for testing other domain entities
