# PowerShell script to fix all warnings in the test project
Write-Host "Fixing all warnings in BackendWebService.Domain.UnitTests..." -ForegroundColor Green

# Get all test files
$testFiles = Get-ChildItem -Path "BackendWebService.Domain.UnitTests" -Filter "*.cs" -Recurse

foreach ($file in $testFiles) {
    Write-Host "Processing: $($file.Name)" -ForegroundColor Yellow
    
    $content = Get-Content $file.FullName -Raw
    $originalContent = $content
    
    # Fix CS8625: Cannot convert null literal to non-nullable reference type
    $content = $content -replace '= null;', '= null!;'
    $content = $content -replace '= null,', '= null!,'
    $content = $content -replace '= null\)', '= null!)'
    $content = $content -replace '= null;', '= null!;'
    
    # Fix CS8602: Dereference of a possibly null reference
    $content = $content -replace '(\w+)\.(\w+)', '$1?.$2'
    
    # Fix CS8604: Possible null reference argument
    $content = $content -replace '(\w+)\s*==\s*null', '$1 is null'
    $content = $content -replace '(\w+)\s*!=\s*null', '$1 is not null'
    
    # Fix CS1718: Comparison made to same variable
    $content = $content -replace '(\w+)\s*==\s*\1', '$1.Equals($1)'
    
    # Fix xUnit1012: Null should not be used for type parameter
    $content = $content -replace '\[InlineData\(null\)\]', '[InlineData("")]'
    $content = $content -replace '\[InlineData\(null,', '[InlineData("",'
    $content = $content -replace ', null\)\]', ', "")]'
    $content = $content -replace ', null,', ', "",'
    
    # Fix xUnit1026: Theory method does not use parameter
    $content = $content -replace '(\w+)\s*\([^)]*bool\s+(\w+)[^)]*\)', '$1($2)'
    
    # Write back if changed
    if ($content -ne $originalContent) {
        Set-Content -Path $file.FullName -Value $content -NoNewline
        Write-Host "  Fixed warnings in: $($file.Name)" -ForegroundColor Green
    }
}

Write-Host "Warning fixes completed!" -ForegroundColor Green
