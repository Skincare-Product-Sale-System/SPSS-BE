# Script to run EF Core migrations on Azure SQL Database using Azure CLI
# Prerequisites: Azure CLI must be installed and logged in
# Usage: .\run-migration-azure-cli.ps1 -ResourceGroupName "your-rg" -AppName "spssapi"

param(
    [Parameter(Mandatory=$true)]
    [string]$ResourceGroupName,
    
    [Parameter(Mandatory=$true)]
    [string]$AppName
)

Write-Host "Retrieving connection string from Azure App Service..." -ForegroundColor Green

# Get connection string from Azure App Service
$connectionString = az webapp config connection-string show `
    --resource-group $ResourceGroupName `
    --name $AppName `
    --connection-string-type SQLAzure `
    --query "value" `
    --output tsv

if (-not $connectionString) {
    Write-Host "Failed to retrieve connection string. Trying alternative method..." -ForegroundColor Yellow
    
    # Alternative: Get from app settings
    $connectionString = az webapp config appsettings list `
        --resource-group $ResourceGroupName `
        --name $AppName `
        --query "[?name=='SPSS_CONNECTION_STRING'].value" `
        --output tsv
}

if (-not $connectionString) {
    Write-Host "Error: Could not retrieve connection string from Azure." -ForegroundColor Red
    Write-Host "Please ensure:" -ForegroundColor Yellow
    Write-Host "1. Azure CLI is installed and you are logged in (az login)" -ForegroundColor Yellow
    Write-Host "2. Connection string is set in App Service Configuration" -ForegroundColor Yellow
    Write-Host "3. Resource group and app name are correct" -ForegroundColor Yellow
    exit 1
}

Write-Host "Connection string retrieved successfully." -ForegroundColor Green
Write-Host "Running database migration..." -ForegroundColor Yellow

# Navigate to the solution directory
$scriptPath = Split-Path -Parent $MyInvocation.MyCommand.Path
Set-Location $scriptPath

# Run EF Core migration
dotnet ef database update --project BusinessObjects --startup-project API --context SPSSContext --connection $connectionString

if ($LASTEXITCODE -eq 0) {
    Write-Host "Database migration completed successfully!" -ForegroundColor Green
} else {
    Write-Host "Database migration failed!" -ForegroundColor Red
    exit 1
}
