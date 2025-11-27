# PowerShell script to fix duplicate InlineData warnings
Write-Host "Fixing duplicate InlineData warnings..." -ForegroundColor Green

# Get all test files
$testFiles = Get-ChildItem -Path "BackendWebService.Domain.UnitTests" -Filter "*.cs" -Recurse

foreach ($file in $testFiles) {
    Write-Host "Processing: $($file.Name)" -ForegroundColor Yellow
    
    $content = Get-Content $file.FullName -Raw
    $originalContent = $content
    
    # Fix duplicate InlineData entries
    $content = $content -replace '(\[InlineData\(""\)\]\s*){2,}', '[InlineData("")]'
    $content = $content -replace '(\[InlineData\(null\)\]\s*){2,}', '[InlineData(null)]'
    $content = $content -replace '(\[InlineData\(true\)\]\s*){2,}', '[InlineData(true)]'
    $content = $content -replace '(\[InlineData\(false\)\]\s*){2,}', '[InlineData(false)]'
    
    # Write back if changed
    if ($content -ne $originalContent) {
        Set-Content -Path $file.FullName -Value $content -NoNewline
        Write-Host "  Fixed duplicates in: $($file.Name)" -ForegroundColor Green
    }
}

Write-Host "Duplicate InlineData fixes completed!" -ForegroundColor Green
