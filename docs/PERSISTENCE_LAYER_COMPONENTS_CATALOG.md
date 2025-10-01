# Persistence Layer Components Catalog

This document provides a comprehensive inventory of all components in the BackendWebService.Persistence layer, organized by category and prioritized for testing.

## Overview

The Persistence layer contains 25+ components across 6 main categories, handling data access, repository patterns, identity management, and database operations.

## Component Categories

### 1. Core Data Access Components (Priority: HIGH)

#### ApplicationDbContext
- **File**: `Data/ApplicationDbContext.cs`
- **Type**: Main DbContext
- **Complexity**: HIGH
- **Testing Priority**: CRITICAL
- **Key Features**:
  - Inherits from `IdentityDbContext<User, Role, int, UserClaim, UserRole, UserLogin, RoleClaim, UserToken>`
  - Manages 20+ DbSets for various entities
  - Implements custom `SaveChanges()` with logging
  - String cleaning functionality for Persian characters
  - Entity change tracking and logging
- **Test Focus**: DbContext operations, entity tracking, change detection, logging

#### DbConnection
- **File**: `Data/DbConnection.cs`
- **Type**: Connection string management
- **Complexity**: LOW
- **Testing Priority**: MEDIUM
- **Key Features**: Static connection string configuration
- **Test Focus**: Connection string validation

### 2. Repository Pattern Components (Priority: HIGH)

#### GenericRepository<T>
- **File**: `Repositories/Common/GenericRepository.cs`
- **Type**: Generic repository implementation
- **Complexity**: VERY HIGH
- **Testing Priority**: CRITICAL
- **Key Features**:
  - Full CRUD operations (Add, Update, Delete, Get, GetAll)
  - Async and sync methods
  - Soft delete functionality
  - Entity activation/deactivation
  - Bulk operations (AddRange, DeleteRange, UpdateRange)
  - SQL execution capabilities
  - Dropdown options generation
  - Complex entity update logic with reflection
- **Test Focus**: All CRUD operations, soft delete, bulk operations, reflection-based updates

#### UnitOfWork
- **File**: `Repositories/Common/UnitOfWork.cs`
- **Type**: Unit of Work pattern implementation
- **Complexity**: HIGH
- **Testing Priority**: CRITICAL
- **Key Features**:
  - Transaction management (Begin, Commit, Rollback)
  - Generic repository factory
  - Async transaction support
  - Proper disposal pattern
- **Test Focus**: Transaction management, repository creation, disposal

#### SP_Call
- **File**: `Repositories/Common/SP_Call.cs`
- **Type**: Stored procedure execution
- **Complexity**: MEDIUM
- **Testing Priority**: HIGH
- **Key Features**:
  - Dapper-based stored procedure execution
  - Multiple result set handling
  - Single record and value retrieval
  - Dynamic parameter support
- **Test Focus**: Stored procedure execution, parameter handling, result mapping

### 3. Identity Management Components (Priority: HIGH)

#### UserRepository
- **File**: `Repositories/Identity/UserRepository.cs`
- **Type**: User-specific repository
- **Complexity**: HIGH
- **Testing Priority**: CRITICAL
- **Key Features**:
  - User querying with organization filtering
  - Action actor management
  - Workflow action retrieval
  - Actor type resolution
- **Test Focus**: User queries, organization filtering, workflow actions

#### RoleRepository
- **File**: `Repositories/Identity/RoleRepository.cs`
- **Type**: Role management repository
- **Complexity**: MEDIUM
- **Testing Priority**: HIGH
- **Key Features**: Role-specific operations
- **Test Focus**: Role CRUD operations

#### UserRefreshTokenRepository
- **File**: `Repositories/Identity/UserRefreshTokenRepository.cs`
- **Type**: Refresh token management
- **Complexity**: MEDIUM
- **Testing Priority**: HIGH
- **Key Features**: Token lifecycle management
- **Test Focus**: Token operations, expiration handling

#### ClientRepository
- **File**: `Repositories/Identity/ClientRepository.cs`
- **Type**: Client management repository
- **Complexity**: MEDIUM
- **Testing Priority**: MEDIUM
- **Key Features**: Client-specific operations
- **Test Focus**: Client CRUD operations

#### GroupRepository
- **File**: `Repositories/Identity/GroupRepository.cs`
- **Type**: Group management repository
- **Complexity**: MEDIUM
- **Testing Priority**: MEDIUM
- **Key Features**: Group-specific operations
- **Test Focus**: Group CRUD operations

#### ActorRepositoryFactory
- **File**: `Repositories/Identity/ActorRepositoryFactory.cs`
- **Type**: Actor repository factory
- **Complexity**: LOW
- **Testing Priority**: LOW
- **Key Features**: Factory pattern for actor repositories
- **Test Focus**: Factory creation logic

### 4. Organization Management Components (Priority: MEDIUM)

#### CompanyRepository
- **File**: `Repositories/Organizations/CompanyRepository.cs`
- **Type**: Company management repository
- **Complexity**: MEDIUM
- **Testing Priority**: MEDIUM
- **Key Features**:
  - Transaction-based operations
  - ID existence checking
  - Paginated queries (incomplete implementation)
  - Response mapping (incomplete)
- **Test Focus**: Transaction handling, CRUD operations, validation

#### OrganizationRepository
- **File**: `Repositories/Organizations/OrganizationRepository.cs`
- **Type**: Organization management repository
- **Complexity**: MEDIUM
- **Testing Priority**: MEDIUM
- **Key Features**: Organization-specific operations
- **Test Focus**: Organization CRUD operations

#### SupplierRepository
- **File**: `Repositories/Organizations/SupplierRepository.cs`
- **Type**: Supplier management repository
- **Complexity**: MEDIUM
- **Testing Priority**: MEDIUM
- **Key Features**: Supplier-specific operations
- **Test Focus**: Supplier CRUD operations

#### SupplierDocumentRepository
- **File**: `Repositories/Organizations/SupplierDocumentRepository.cs`
- **Type**: Supplier document management
- **Complexity**: MEDIUM
- **Testing Priority**: MEDIUM
- **Key Features**: Document-specific operations
- **Test Focus**: Document CRUD operations

#### PreDocumentRepository
- **File**: `Repositories/Organizations/PreDocumentRepository.cs`
- **Type**: Pre-document management
- **Complexity**: MEDIUM
- **Testing Priority**: MEDIUM
- **Key Features**: Pre-document operations
- **Test Focus**: Pre-document CRUD operations

### 5. Product Management Components (Priority: MEDIUM)

#### CategoryRepository
- **File**: `Repositories/Product/CategoryRepository.cs`
- **Type**: Category management repository
- **Complexity**: MEDIUM
- **Testing Priority**: MEDIUM
- **Key Features**:
  - Transaction-based updates
  - Parent-child relationship handling
  - Object type resolution
  - Response mapping (incomplete)
- **Test Focus**: Transaction handling, hierarchical operations

#### ServiceRepository
- **File**: `Repositories/Product/ServiceRepository.cs`
- **Type**: Service management repository
- **Complexity**: MEDIUM
- **Testing Priority**: MEDIUM
- **Key Features**: Service-specific operations
- **Test Focus**: Service CRUD operations

### 6. Workflow Management Components (Priority: LOW)

#### WorkflowRepository
- **File**: `Repositories/Workflows/WorkflowRepository.cs`
- **Type**: Workflow management repository
- **Complexity**: MEDIUM
- **Testing Priority**: LOW
- **Key Features**: Workflow-specific operations
- **Test Focus**: Workflow CRUD operations

#### WorkflowCycleRepository
- **File**: `Repositories/Workflows/WorkflowCycleRepository.cs`
- **Type**: Workflow cycle management
- **Complexity**: MEDIUM
- **Testing Priority**: LOW
- **Key Features**: Cycle-specific operations
- **Test Focus**: Cycle CRUD operations

#### WorkflowCaseRepository
- **File**: `Repositories/Workflows/WorkflowCaseRepository.cs`
- **Type**: Workflow case management
- **Complexity**: MEDIUM
- **Testing Priority**: LOW
- **Key Features**: Case-specific operations
- **Test Focus**: Case CRUD operations

#### WorkflowActionRepository
- **File**: `Repositories/Workflows/WorkflowActionRepository.cs`
- **Type**: Workflow action management
- **Complexity**: MEDIUM
- **Testing Priority**: LOW
- **Key Features**: Action-specific operations
- **Test Focus**: Action CRUD operations

### 7. Notification Components (Priority: MEDIUM)

#### NotificationRepository
- **File**: `Repositories/Notifications/NotificationRepository.cs`
- **Type**: Notification management repository
- **Complexity**: MEDIUM
- **Testing Priority**: MEDIUM
- **Key Features**: Notification-specific operations
- **Test Focus**: Notification CRUD operations

#### NotificationDetailsRepository
- **File**: `Repositories/Notifications/NotificationDetailsRepository.cs`
- **Type**: Notification details management
- **Complexity**: MEDIUM
- **Testing Priority**: MEDIUM
- **Key Features**: Details-specific operations
- **Test Focus**: Details CRUD operations

### 8. File System Components (Priority: MEDIUM)

#### FileRepository
- **File**: `Repositories/FileSystem/FileRepository.cs`
- **Type**: File management repository
- **Complexity**: MEDIUM
- **Testing Priority**: MEDIUM
- **Key Features**: File-specific operations
- **Test Focus**: File CRUD operations

### 9. Logging Components (Priority: LOW)

#### LoggingRepository
- **File**: `LoggingRepository.cs`
- **Type**: Logging management repository
- **Complexity**: LOW
- **Testing Priority**: LOW
- **Key Features**: Log-specific operations
- **Test Focus**: Log CRUD operations

### 10. Store Components (Priority: LOW)

#### AppUserStore
- **File**: `Store/AppUserStore.cs`
- **Type**: ASP.NET Identity user store
- **Complexity**: LOW
- **Testing Priority**: LOW
- **Key Features**: Identity framework integration
- **Test Focus**: Identity operations

#### RoleStore
- **File**: `Store/RoleStore.cs`
- **Type**: ASP.NET Identity role store
- **Complexity**: LOW
- **Testing Priority**: LOW
- **Key Features**: Identity framework integration
- **Test Focus**: Role operations

### 11. Factory Components (Priority: LOW)

#### WorkflowReviewRepositoryFactory
- **File**: `Repositories/WorkflowReviewRepositories/WorkflowReviewRepositoryFactory.cs`
- **Type**: Workflow review repository factory
- **Complexity**: LOW
- **Testing Priority**: LOW
- **Key Features**: Factory pattern implementation
- **Test Focus**: Factory creation logic

## Testing Priority Matrix

### CRITICAL Priority (Must Test First)
1. **GenericRepository<T>** - Core repository functionality
2. **UnitOfWork** - Transaction management
3. **ApplicationDbContext** - Database context operations
4. **UserRepository** - User management

### HIGH Priority (Test Early)
5. **SP_Call** - Stored procedure execution
6. **RoleRepository** - Role management
7. **UserRefreshTokenRepository** - Token management
8. **ClientRepository** - Client management
9. **GroupRepository** - Group management

### MEDIUM Priority (Test Later)
10. **CompanyRepository** - Company management
11. **OrganizationRepository** - Organization management
12. **SupplierRepository** - Supplier management
13. **CategoryRepository** - Category management
14. **ServiceRepository** - Service management
15. **NotificationRepository** - Notification management
16. **FileRepository** - File management

### LOW Priority (Test Last)
17. **WorkflowRepository** - Workflow management
18. **LoggingRepository** - Logging management
19. **Store components** - Identity stores
20. **Factory components** - Factory patterns

## Testing Strategy

### Phase 1: Core Infrastructure (US-022)
- Focus on GenericRepository<T> and UnitOfWork
- Test all CRUD operations, transactions, and error handling
- Verify soft delete and bulk operations

### Phase 2: Identity Management (US-023)
- Test UserRepository, RoleRepository, and related components
- Focus on organization filtering and security
- Test token management and refresh operations

### Phase 3: Business Logic (US-024)
- Test organization, product, and notification repositories
- Focus on complex business operations
- Test transaction handling and data integrity

### Phase 4: Specialized Components
- Test workflow, file system, and logging components
- Focus on edge cases and error scenarios
- Complete coverage verification

## Key Testing Considerations

1. **Transaction Management**: Many repositories use explicit transactions
2. **Organization Filtering**: Most queries filter by organization ID
3. **Soft Delete**: Many entities support soft delete functionality
4. **Reflection Usage**: GenericRepository uses reflection for entity updates
5. **Incomplete Implementations**: Some methods throw NotImplementedException
6. **Complex Queries**: Some repositories have complex LINQ queries
7. **Error Handling**: Transaction rollback and exception handling
8. **Async Operations**: Mix of sync and async methods

## Dependencies

- **Entity Framework Core**: For database operations
- **Dapper**: For stored procedure execution
- **ASP.NET Identity**: For user and role management
- **Application Layer**: For contracts and feature models
- **Domain Layer**: For entities and enums
- **SharedKernel**: For extensions and utilities

## Next Steps

1. **US-022**: Test Complex Repository Logic (GenericRepository, UnitOfWork)
2. **US-023**: Test Standard Repository Operations (CRUD operations)
3. **US-024**: Complete Persistence Layer Coverage (All remaining components)
