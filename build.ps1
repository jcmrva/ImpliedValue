
Set-Location .\src

dotnet build -c Release

dotnet test .\ImpliedValue.Tests\ --no-build

Set-Location ..