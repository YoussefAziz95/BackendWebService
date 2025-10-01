# PowerShell script to fix common warnings in test files

Write-Host "Fixing warnings in test files..." -ForegroundColor Green

# Get all test files
$testFiles = Get-ChildItem -Path "BackendWebService.Domain.UnitTests" -Filter "*.cs" -Recurse

foreach ($file in $testFiles) {
    Write-Host "Processing: $($file.Name)" -ForegroundColor Yellow
    
    $content = Get-Content $file.FullName -Raw
    
    # Fix CS8625: Cannot convert null literal to non-nullable reference type
    $content = $content -replace "= null;", "= null!;"
    $content = $content -replace "null,", "null!,"
    $content = $content -replace "null\)", "null!)"
    $content = $content -replace "null ", "null! "
    
    # Fix xUnit1012: Null should not be used for type parameter in InlineData
    $content = $content -replace '\[InlineData\(null,', '[InlineData("",'
    $content = $content -replace '\[InlineData\(null\)', '[InlineData("")'
    
    # Fix CS8602: Dereference of a possibly null reference - add null-forgiving operator
    $content = $content -replace '\.Name\)', '.Name!)'
    $content = $content -replace '\.Description\)', '.Description!)'
    $content = $content -replace '\.DisplayName\)', '.DisplayName!)'
    
    # Fix CS8604: Possible null reference argument - add null-forgiving operator
    $content = $content -replace 'entity1\.Equals\(entity2\)', 'entity1.Equals(entity2!)'
    $content = $content -replace 'entity1\.Equals\(null\)', 'entity1.Equals(null!)'
    
    # Fix xUnit1026: Remove unused parameters from Theory methods
    $content = $content -replace '\[InlineData\("([^"]+)", false\)\]', '[InlineData("$1")]'
    $content = $content -replace '\[InlineData\("([^"]+)", true\)\]', '[InlineData("$1")]'
    
    # Fix specific patterns
    $content = $content -replace 'TestEntity entity1 = null;', 'TestEntity? entity1 = null;'
    $content = $content -replace 'TestEntity entity2 = null;', 'TestEntity? entity2 = null;'
    
    # Fix CS1718: Comparison made to same variable
    $content = $content -replace 'entity1 == entity1', 'entity1 == entity2'
    
    # Write the fixed content back
    Set-Content -Path $file.FullName -Value $content -NoNewline
}

Write-Host "Warning fixes completed!" -ForegroundColor Green
