﻿// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT license. See License.txt in the project root for license information.

namespace Microsoft.CodeAnalysis.Razor.Workspaces.Protocol.ProjectSystem;

internal class ProjectInfoParams
{
    public required string[] ProjectKeyIds { get; init; }
    public required string?[] FilePaths { get; init; }
}
