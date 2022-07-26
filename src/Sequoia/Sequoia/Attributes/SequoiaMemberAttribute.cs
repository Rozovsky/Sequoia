﻿namespace Sequoia.Attributes
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
    /// <summary>
    /// Registers the current assembly for use in the kernel libraries
    /// </summary>
    public class SequoiaMemberAttribute : Attribute
    {
    }
}
