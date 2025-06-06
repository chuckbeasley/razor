﻿// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT license. See License.txt in the project root for license information.

using Microsoft.CodeAnalysis.Razor.Workspaces.Settings;

namespace Microsoft.VisualStudio.Razor.Settings;

internal interface IClientSettingsChangedTrigger
{
    void Initialize(IClientSettingsManager editorSettingsManager);
}
