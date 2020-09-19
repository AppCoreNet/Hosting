AppCore .NET Hosting
--------------------

[![Build Status](https://dev.azure.com/AppCoreNet/Logging/_apis/build/status/AppCoreNet.Hosting%20CI?branchName=dev)](https://dev.azure.com/AppCoreNet/Hosting/_build/latest?definitionId=7&branchName=dev)
![Azure DevOps tests (compact)](https://img.shields.io/azure-devops/tests/AppCoreNet/Hosting/7?compact_message)
![Azure DevOps coverage (branch)](https://img.shields.io/azure-devops/coverage/AppCoreNet/Hosting/7/dev)
![Nuget](https://img.shields.io/nuget/v/AppCore.Hosting.Abstractions)

This repository contains abstractions and implementations for application startup and hosting. It targets the .NET Framework and .NET Core.

All artifacts are licensed under the [MIT license](LICENSE). You are free to use them in open-source or commercial projects as long as you keep the copyright notice intact when redistributing or otherwise reusing our artifacts.

## Packages

Latest development packages can be found on [MyGet](https://www.myget.org/gallery/appcorenet).

Package                                           | Description
--------------------------------------------------|------------------------------------------------------------------------------------------------------
`AppCore.Hosting`                                 | Default implementation of the hosting API.
`AppCore.Hosting.Abstractions`                    | Provides the public API for the hosting API.
`AppCore.Hosting.Microsoft.Extensions`            | Integrates `Microsoft.Extensions.Hosting`.

## Contributing

Contributions, whether you file an issue, fix some bug or implement a new feature, are highly appreciated. The whole user community
will benefit from them.

Please refer to the [Contribution guide](CONTRIBUTING.md).
