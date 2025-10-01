# Domain Entities Catalog

## Overview

This document catalogs all 96 domain entities in the BackendWebService project, categorized by complexity and prioritized for testing based on business criticality, complexity, and risk exposure.

**Total Entities**: 96  
**Catalog Date**: October 1, 2025

## Complexity Categories

### Simple Entities (Data Containers)
- **Characteristics**: Primarily data containers with minimal business logic
- **Testing Focus**: Constructor, property validation, basic business rules
- **Coverage Target**: 90%+

### Moderate Entities (Some Validation and Business Rules)
- **Characteristics**: Contains validation logic, business rules, and some complex relationships
- **Testing Focus**: Validation rules, business logic, relationship handling
- **Coverage Target**: 95%+

### Complex Entities (Significant Business Logic)
- **Characteristics**: Complex business logic, multiple relationships, custom methods
- **Testing Focus**: All business logic, complex scenarios, edge cases
- **Coverage Target**: 100%+

## Entity Catalog by Module

### 1. SystemModule (4 entities)

| Entity | Complexity | Priority | Business Criticality | Dependencies | Testing Effort |
|--------|------------|----------|---------------------|--------------|----------------|
| **BaseEntity** | Complex | High | Critical | None | 2 days |
| **Category** | Simple | Medium | High | None | 1 day |
| **Logging** | Simple | Low | Medium | None | 0.5 days |
| **TranslationKey** | Simple | Low | Low | None | 0.5 days |
| **Zone** | Simple | Low | Low | None | 0.5 days |

### 2. IdentityModule (10 entities)

| Entity | Complexity | Priority | Business Criticality | Dependencies | Testing Effort |
|--------|------------|----------|---------------------|--------------|----------------|
| **User** | Complex | High | Critical | Organization, Role | 3 days |
| **UserRole** | Simple | High | Critical | User, Role | 1 day |
| **UserClaim** | Simple | High | Critical | User | 1 day |
| **UserGroup** | Simple | Medium | Medium | User, Group | 1 day |
| **UserLogin** | Simple | Medium | Medium | User | 1 day |
| **UserRefreshToken** | Simple | Medium | Medium | User | 1 day |
| **UserToken** | Simple | Medium | Medium | User | 1 day |
| **Group** | Simple | Medium | Medium | None | 1 day |
| **Role** | Simple | High | Critical | None | 1 day |
| **RoleClaim** | Simple | High | Critical | Role | 1 day |

### 3. InventoryModule (12 entities)

| Entity | Complexity | Priority | Business Criticality | Dependencies | Testing Effort |
|--------|------------|----------|---------------------|--------------|----------------|
| **PaymentMethod** | Moderate | High | Critical | User | 2 days ✅ |
| **Transaction** | Moderate | High | Critical | PaymentMethod | 2 days |
| **Product** | Moderate | High | High | Category, FileLog | 2 days |
| **Part** | Moderate | High | High | Product | 2 days |
| **Spare** | Moderate | High | High | Product | 2 days |
| **SparePart** | Moderate | High | High | Spare, Part | 2 days |
| **Item** | Moderate | High | High | Category | 2 days |
| **Portion** | Moderate | Medium | Medium | StorageUnit, PortionType | 1.5 days |
| **PortionItem** | Simple | Medium | Medium | Portion, Item | 1 day |
| **PortionType** | Simple | Low | Low | None | 0.5 days |
| **Inventory** | Moderate | High | High | None | 2 days |
| **StorageUnit** | Simple | Medium | Medium | Inventory | 1 day |

### 4. EmployeeModule (18 entities)

| Entity | Complexity | Priority | Business Criticality | Dependencies | Testing Effort |
|--------|------------|----------|---------------------|--------------|----------------|
| **Employee** | Complex | High | Critical | User, Organization | 3 days |
| **EmployeeAccount** | Moderate | High | High | Employee | 2 days |
| **EmployeeAssignment** | Moderate | Medium | Medium | Employee | 1.5 days |
| **EmployeeCertification** | Moderate | Medium | Medium | Employee | 1.5 days |
| **EmployeeJob** | Moderate | Medium | Medium | Employee, Job | 1.5 days |
| **Branch** | Moderate | High | High | Organization | 2 days |
| **BranchContact** | Simple | Medium | Medium | Branch | 1 day |
| **BranchEmployee** | Simple | Medium | Medium | Branch, Employee | 1 day |
| **BranchLocation** | Moderate | Medium | Medium | Branch | 1.5 days |
| **BranchService** | Simple | Medium | Medium | Branch, Service | 1 day |
| **BranchWorkingHour** | Simple | Low | Low | Branch | 0.5 days |
| **Job** | Simple | Medium | Medium | None | 1 day |
| **JobVerification** | Simple | Medium | Medium | Job | 1 day |
| **Offer** | Complex | High | Critical | Organization, Company, Customer | 3 days |
| **Criteria** | Moderate | High | High | Offer | 2 days |
| **OfferItem** | Moderate | High | High | Offer, Item | 2 days |
| **OfferObject** | Moderate | High | High | Offer | 2 days |
| **Service** | Simple | Medium | Medium | None | 1 day |
| **EmployeeService** | Simple | Medium | Medium | Employee, Service | 1 day |
| **TimeSlot** | Simple | Medium | Medium | Service | 1 day |

### 5. CustomerModule (6 entities)

| Entity | Complexity | Priority | Business Criticality | Dependencies | Testing Effort |
|--------|------------|----------|---------------------|--------------|----------------|
| **Customer** | Moderate | High | Critical | Organization | 2 days |
| **CustomerPaymentMethod** | Moderate | High | Critical | Customer, PaymentMethod | 2 days |
| **CustomerService** | Simple | Medium | Medium | Customer, Service | 1 day |
| **Order** | Complex | High | Critical | Customer, Employee | 3 days |
| **OrderItem** | Moderate | High | High | Order, Item | 2 days |
| **Receipt** | Moderate | High | High | Order | 2 days |

### 6. ClientModule (7 entities)

| Entity | Complexity | Priority | Business Criticality | Dependencies | Testing Effort |
|--------|------------|----------|---------------------|--------------|----------------|
| **Client** | Moderate | High | High | Organization | 2 days |
| **ClientAccount** | Moderate | High | High | Client, Company | 2 days |
| **ClientProperty** | Simple | Medium | Medium | Client | 1 day |
| **ClientService** | Simple | Medium | Medium | Client, Service | 1 day |
| **Deal** | Complex | High | Critical | Client, Organization | 3 days |
| **DealDetails** | Moderate | High | High | Deal | 2 days |
| **DealDocument** | Moderate | High | High | Deal, PreDocument | 2 days |
| **Property** | Simple | Medium | Medium | None | 1 day |

### 7. AdministratorModule (17 entities)

| Entity | Complexity | Priority | Business Criticality | Dependencies | Testing Effort |
|--------|------------|----------|---------------------|--------------|----------------|
| **Organization** | Complex | High | Critical | None | 3 days |
| **Address** | Simple | Medium | Medium | Organization | 1 day |
| **Contact** | Simple | Medium | Medium | Organization | 1 day |
| **Department** | Moderate | High | High | Organization | 2 days |
| **Administrator** | Moderate | High | High | Organization | 2 days |
| **GoogleConfig** | Simple | Low | Low | Organization | 0.5 days |
| **LDAPConfig** | Simple | Low | Low | Organization | 0.5 days |
| **MicrosoftConfig** | Simple | Low | Low | Organization | 0.5 days |
| **Company** | Moderate | High | High | Organization | 2 days |
| **CompanyCategory** | Simple | Medium | Medium | Company, Category | 1 day |
| **Manager** | Simple | Medium | Medium | Company | 1 day |
| **Consumer** | Moderate | High | High | Organization | 2 days |
| **ConsumerAccount** | Moderate | High | High | Consumer, Company | 2 days |
| **ConsumerCustomer** | Simple | Medium | Medium | Consumer, Category | 1 day |
| **ConsumerDocument** | Moderate | High | High | Consumer, PreDocument | 2 days |
| **Supplier** | Moderate | High | High | Organization | 2 days |
| **SupplierAccount** | Moderate | High | High | Supplier, Company | 2 days |
| **SupplierCategory** | Simple | Medium | Medium | Supplier, Category | 1 day |
| **SupplierDocument** | Moderate | High | High | Supplier, PreDocument | 2 days |
| **PreDocument** | Simple | Medium | Medium | None | 1 day |

### 8. SystemModule (8 entities)

| Entity | Complexity | Priority | Business Criticality | Dependencies | Testing Effort |
|--------|------------|----------|---------------------|--------------|----------------|
| **EmailLog** | Simple | Low | Low | None | 0.5 days |
| **Attachment** | Simple | Low | Low | EmailLog, FileLog | 0.5 days |
| **Recipient** | Simple | Low | Low | EmailLog | 0.5 days |
| **FileLog** | Simple | Medium | Medium | FileType | 1 day |
| **FileType** | Simple | Low | Low | None | 0.5 days |
| **FileFieldValidator** | Simple | Low | Low | FileType | 0.5 days |
| **Notification** | Simple | Medium | Medium | None | 1 day |
| **NotificationDetail** | Simple | Medium | Medium | Notification | 1 day |

### 9. WorkflowModule (6 entities)

| Entity | Complexity | Priority | Business Criticality | Dependencies | Testing Effort |
|--------|------------|----------|---------------------|--------------|----------------|
| **Workflow** | Complex | High | High | Organization | 3 days |
| **WorkflowCycle** | Moderate | High | High | Workflow | 2 days |
| **Case** | Complex | High | High | Workflow | 3 days |
| **CaseAction** | Moderate | High | High | Case | 2 days |
| **Actor** | Simple | Medium | Medium | None | 1 day |
| **ActionActor** | Simple | Medium | Medium | Actor, CaseAction | 1 day |
| **ActionObject** | Simple | Medium | Medium | CaseAction | 1 day |

## Priority Classification

### High Priority (Critical Business Logic) - 35 entities
**Testing Order**: 1-35
- **IdentityModule**: User, UserRole, UserClaim, Role, RoleClaim
- **InventoryModule**: PaymentMethod ✅, Transaction, Product, Part, Spare, SparePart, Item, Inventory
- **EmployeeModule**: Employee, Offer, Criteria, OfferItem, OfferObject, Branch
- **CustomerModule**: Customer, CustomerPaymentMethod, Order, OrderItem, Receipt
- **ClientModule**: Client, ClientAccount, Deal, DealDetails, DealDocument
- **AdministratorModule**: Organization, Department, Administrator, Company, Consumer, ConsumerAccount, ConsumerDocument, Supplier, SupplierAccount, SupplierDocument
- **WorkflowModule**: Workflow, WorkflowCycle, Case, CaseAction
- **SystemModule**: BaseEntity

### Medium Priority (Important Business Logic) - 45 entities
**Testing Order**: 36-80
- **IdentityModule**: UserGroup, UserLogin, UserRefreshToken, UserToken, Group
- **InventoryModule**: Portion, PortionItem, StorageUnit
- **EmployeeModule**: EmployeeAccount, EmployeeAssignment, EmployeeCertification, EmployeeJob, BranchContact, BranchEmployee, BranchLocation, BranchService, Job, JobVerification, Service, EmployeeService, TimeSlot
- **CustomerModule**: CustomerService
- **ClientModule**: ClientProperty, ClientService, Property
- **AdministratorModule**: Address, Contact, CompanyCategory, Manager, ConsumerCustomer, SupplierCategory, PreDocument
- **SystemModule**: FileLog, Notification, NotificationDetail
- **WorkflowModule**: Actor, ActionActor, ActionObject

### Low Priority (Supporting Logic) - 16 entities
**Testing Order**: 81-96
- **SystemModule**: Category, Logging, TranslationKey, Zone, EmailLog, Attachment, Recipient, FileType, FileFieldValidator
- **EmployeeModule**: BranchWorkingHour, PortionType
- **AdministratorModule**: GoogleConfig, LDAPConfig, MicrosoftConfig

## Testing Sequence

### Phase 1: High Priority Entities (US-009)
**Duration**: 2-4 weeks
**Entities**: 35 entities
**Focus**: Critical business logic, core functionality

### Phase 2: Medium Priority Entities (US-010)
**Duration**: 2-3 weeks  
**Entities**: 45 entities
**Focus**: Important business logic, supporting functionality

### Phase 3: Low Priority Entities (US-011)
**Duration**: 1-2 weeks
**Entities**: 16 entities
**Focus**: Supporting logic, utility classes

## Effort Estimation

### Total Testing Effort
- **High Priority**: 35 entities × 2.1 days average = 73.5 days
- **Medium Priority**: 45 entities × 1.3 days average = 58.5 days  
- **Low Priority**: 16 entities × 0.7 days average = 11.2 days
- **Total**: 143.2 days (≈ 28.6 weeks for 1 developer)

### Resource Planning
- **1 Developer**: 28.6 weeks
- **2 Developers**: 14.3 weeks
- **3 Developers**: 9.5 weeks
- **4 Developers**: 7.2 weeks

## Dependencies Analysis

### High Dependency Entities
- **User**: Depends on Organization, Role
- **Offer**: Depends on Organization, Company, Customer
- **Order**: Depends on Customer, Employee
- **Deal**: Depends on Client, Organization

### Independent Entities
- **BaseEntity**: No dependencies
- **Category**: No dependencies
- **Organization**: No dependencies
- **PaymentMethod**: Minimal dependencies

## Testing Strategy by Complexity

### Simple Entities
- **Focus**: Constructor, property validation, basic business rules
- **Coverage Target**: 90%+
- **Test Types**: Constructor, property validation, basic scenarios

### Moderate Entities  
- **Focus**: Validation rules, business logic, relationship handling
- **Coverage Target**: 95%+
- **Test Types**: Constructor, validation, business logic, relationships

### Complex Entities
- **Focus**: All business logic, complex scenarios, edge cases
- **Coverage Target**: 100%+
- **Test Types**: Comprehensive testing of all aspects

## Next Steps

1. **US-009**: Begin testing high-priority entities
2. **US-010**: Continue with medium-priority entities  
3. **US-011**: Complete with low-priority entities
4. **Track Progress**: Update this catalog as entities are tested
5. **Monitor Coverage**: Ensure coverage targets are met

---

*This catalog will be updated as testing progresses and new insights are gained about entity complexity and business criticality.*
