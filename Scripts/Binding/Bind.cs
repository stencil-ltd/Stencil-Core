using System;

namespace Binding
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class Bind : Attribute
    {
    }
}