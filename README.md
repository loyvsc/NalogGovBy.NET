# NalogGovBy.NET
C# library for interacting with nalog.gov.by API's

## Installation

[Download from NuGet](https://www.nuget.org/packages/NalogGovBy.NET/)

##### Package Manager

```powershell
NuGet\Install-Package NalogGovBy.NET -Version *version_number*
```

##### .NET CLI

```cmd
dotnet add package NalogGovBy.NET --version *version_number*
```

## Features
- Getting information about company by UNP code

## Usage
```C#
UnpReader reader = new UnpReader();
var info = await reader.GetCompanyInfoByUnp("100325912");
```
