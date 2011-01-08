// Guids.cs
// MUST match guids.h
using System;

namespace BinaryFinery.MonoFlave2010
{
    static class GuidList
    {
        public const string guidMonoFlave2010PkgString = "04cd35f2-1f09-4ef9-b7f7-577761e322ab";
        public const string guidMonoFlave2010CmdSetString = "7ce152a7-8884-49ae-b3a2-29c61935193f";

        public static readonly Guid guidMonoFlave2010CmdSet = new Guid(guidMonoFlave2010CmdSetString);
    };
}