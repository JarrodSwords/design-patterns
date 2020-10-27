using System;

namespace DesignPatterns.Prototype.Domain
{
    [Flags]
    public enum CompatibleCharacters
    {
        None = 0,
        Mario = 1,
        Mallow = 1 << 1,
        Geno = 1 << 2,
        Bowser = 1 << 3,
        Toadstool = 1 << 4,
        All = Mario | Mallow | Geno | Bowser | Toadstool
    }
}
