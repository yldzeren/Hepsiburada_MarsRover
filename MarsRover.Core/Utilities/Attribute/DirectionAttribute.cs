using System;

namespace Mars.Core
{
    [AttributeUsage(AttributeTargets.Field)]
    public class InformationAttribute : Attribute
    {
        public string Value { get; set; }
        public string Description { get; set; }
        public string Axle { get; set; }
    }
}
