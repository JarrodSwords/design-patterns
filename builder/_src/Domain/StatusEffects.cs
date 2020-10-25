using System;

namespace DesignPatterns.Builder.Domain
{
    [Flags]
    public enum StatusEffects
    {
        None = 0,
        Fear = 1,
        Poison = 1 << 1,
        Sleep = 1 << 2,
        Silence = 1 << 3,
        Minor = Sleep | Silence,
        Major = Fear | Poison,
        All = Minor | Major
    }
}
