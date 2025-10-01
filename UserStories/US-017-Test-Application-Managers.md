# US-017: Write Unit Tests for Application Managers

**As a** Developer  
**I want to** write unit tests for custom managers (AppUserManager, AppRoleManager, etc.)  
**So that** identity and role management logic is validated

## Acceptance Criteria

1. Identify all custom manager classes:
   - AppUserManager
   - AppRoleManager
   - AppSignInManager
   - Any other custom managers
2. For each manager:
   - Create test class
   - Mock underlying dependencies (UserStore, RoleStore, etc.)
   - Test all custom methods (beyond base class methods)
   - Test business logic specific to the application
   - Test error handling
3. Focus on custom behavior, not framework-provided functionality
4. Achieve 80%+ coverage for custom logic
5. All tests pass
6. Update tracking document

## Definition of Done

- All custom manager classes have unit tests
- Custom logic is thoroughly tested
- Framework base methods are not unnecessarily tested
- Coverage targets are met
- All tests pass

## Priority

**Medium** - Important for identity management

## Estimated Effort

1-2 weeks

