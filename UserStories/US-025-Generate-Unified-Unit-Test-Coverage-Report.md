# US-025: Generate Unified Coverage Report for All Layers

**As a** Developer  
**I want to** generate a single comprehensive coverage report across all layers  
**So that** I can view overall unit test coverage for the entire solution

## Acceptance Criteria

1. Configure test execution to run all unit test projects together
2. Merge coverage data from Domain, Application, and Persistence test projects
3. Generate a unified HTML coverage report showing:
   - Overall solution coverage percentage
   - Per-layer coverage breakdown
   - Per-namespace coverage
   - Per-class coverage
4. Report is generated to `./test-results/coverage-report/`
5. Report includes summary statistics for all three layers
6. Docker configuration generates unified report
7. Verify overall unit test coverage meets 80%+ threshold
8. Document how to generate unified report
9. Update any scripts or commands for unified execution

## Definition of Done

- Unified coverage report is generated successfully
- Report shows accurate coverage across all layers
- Overall coverage threshold is met
- Docker generates same unified report
- Documentation is clear
- Process is repeatable and automated

## Priority

**High** - Provides complete view of unit test coverage

## Estimated Effort

4-6 hours

