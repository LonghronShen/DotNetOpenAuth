﻿//-----------------------------------------------------------------------
// <copyright file="AssemblyInfo.cs" company="Outercurve Foundation">
//     Copyright (c) Outercurve Foundation. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

// We DON'T put an AssemblyVersionAttribute in here because it is generated in the build.

using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// General Information about an assembly is controlled through the following 
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
[assembly: AssemblyCopyright("Copyright © 2012 Outercurve Foundation")]
[assembly: CLSCompliant(true)]

// Setting ComVisible to false makes the types in this assembly not visible 
// to COM components.  If you need to access a type in this assembly from 
// COM, set the ComVisible attribute to true on that type.
[assembly: ComVisible(false)]

// The following GUID is for the ID of the typelib if this project is exposed to COM
[assembly: Guid("7d73990c-47c0-4256-9f20-a893add9e289")]

#if StrongNameSigned
// See comment at top of this file.  We need this so that strong-naming doesn't
// keep this assembly from being useful to shared host (medium trust) web sites.
[assembly: AllowPartiallyTrustedCallers]

[assembly: InternalsVisibleTo("Org.Mentalis.Security.Cryptography, PublicKey=0024000004800000140100000602000000240000525341310008000001000100ff61f0ffd86a577730128d6b9daed5195c2ec729115934b8da0763ac4f12ae2416a11657976a3adc5fec78fe98b8e4f65b2f29b1c116eb761111315f4f10d7a9a827615610b49ae262fa8dd52d8181b54b2fcba7e2d81723f7922e65154482dd208f98c084c59fe028f5bcb227022acfe03aef64ac6ed80e86093ebe2dafbbb00583321b3ec81d275c65077310dfcb837f6c1ec85a3554ac0d04892bdc76647973fce74f9cbd1435d6adba79942eb4ce60b923a62dbb8eebfed3283dfce3aa8123ee108c095a7a70be3ca2e92059223e0bfbfb56302b90906ef8e4f649cd42eb436dd9ee1173fd141af9b3f5def5eefd15771e24c3de9ea1f2b0985cd3756199")]
#else
[assembly: InternalsVisibleTo("Org.Mentalis.Security.Cryptography")]
#endif
