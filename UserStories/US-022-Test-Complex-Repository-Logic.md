# US-022: Write Unit Tests for Complex Repository Logic

**As a** Developer  
**I want to** write unit tests for repositories with complex queries or logic  
**So that** data access behavior is validated and regression is prevented

## Acceptance Criteria

1. Identify repositories with complex or custom logic
2. For each complex repository:
   - Create test class
   - Use in-memory database or mock DbContext
   - Test complex query methods
   - Test custom filtering logic
   - Test data aggregations
   - Test edge cases (empty results, null handling)
   - Verify correct data is returned
3. Target 80%+ coverage for repositories with custom logic
4. All tests pass
5. Tests use appropriate isolation (in-memory DB vs mocking)
6. Update tracking document

## Definition of Done

- All complex repositories have unit tests
- Custom query logic is validated
- Coverage targets are met
- All tests pass
- Test isolation strategy is appropriate

## Priority

**High** - Complex logic requires validation

## Estimated Effort

2-3 weeks

