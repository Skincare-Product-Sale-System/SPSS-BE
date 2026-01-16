# Script to run EF Core migrations on Azure SQL Database
# Usage: .\run-migration-azure.ps1 -ConnectionString "your-azure-connection-string"

param(
    [Parameter(Mandatory=$true)]
    [string]$ConnectionString
)

Write-Host "Starting database migration on Azure..." -ForegroundColor Green

# Set the connection string as environment variable
$env:ConnectionStrings__SPSS = $ConnectionString

# Navigate to the solution directory
$scriptPath = Split-Path -Parent $MyInvocation.MyCommand.Path
Set-Location $scriptPath

# Run EF Core migration
Write-Host "Running database update..." -ForegroundColor Yellow
dotnet ef database update --project BusinessObjects --startup-project API --context SPSSContext --connection $ConnectionString

if ($LASTEXITCODE -eq 0) {
    Write-Host "Database migration completed successfully!" -ForegroundColor Green
} else {
    Write-Host "Database migration failed!" -ForegroundColor Red
    exit 1
}
