﻿/* ****************************************************************************
 *
 * Copyright (c) Microsoft Corporation. 
 *
 * This source code is subject to terms and conditions of the Apache License, Version 2.0. A 
 * copy of the license can be found in the License.html file at the root of this distribution. If 
 * you cannot locate the Apache License, Version 2.0, please send an email to 
 * vspython@microsoft.com. By using this source code in any fashion, you are agreeing to be bound 
 * by the terms of the Apache License, Version 2.0.
 *
 * You must not remove this notice, or any other, from this software.
 *
 * ***************************************************************************/

using System;
using System.Runtime.InteropServices;
using Microsoft.VisualStudio.Shell.Interop;
using Microsoft.VisualStudioTools.Navigation;
using Microsoft.VisualStudioTools.Project;

namespace Microsoft.NodejsTools.Project {

    /// <summary>
    /// Implementation of the service that builds the information to expose to the symbols
    /// navigation tools (class view or object browser) from the Python files inside a
    /// hierarchy.
    /// </summary>
    [Guid("1CCB584B-2876-4416-99B0-60C91B938147")]
    internal class NodejsLibraryManager : LibraryManager {
        private readonly NodePackage/*!*/ _package;

        public NodejsLibraryManager(NodePackage/*!*/ package)
            : base(package) {
            _package = package;
        }

        protected override LibraryNode CreateLibraryNode(IScopeNode subItem, string namePrefix, IVsHierarchy hierarchy, uint itemid) {
            return new NodeLibraryNode(subItem, namePrefix, hierarchy, itemid);
        }

        public override LibraryNode CreateFileLibraryNode(HierarchyNode hierarchy, string name, string filename, LibraryNodeType libraryNodeType) {
            return new NodeFileLibraryNode(hierarchy, hierarchy.Caption, filename, libraryNodeType);
        }

        protected override void OnNewFile(LibraryTask task) {
        }
    }
}