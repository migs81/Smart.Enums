using System;

namespace Smart.Enums.Benchmarks.TestData
{
    [AttributeUsage(AttributeTargets.Field)]
    public class ColorAttribute : SmartEnumAttribute
    {
        public string Code { get; }

        public ColorAttribute(string name, string description, string code) : base(name, description)
        {
            Code = code;
        }

        public ColorAttribute(string name, string description) : base(name, description)
        {
            Code = "";
        }
    }
}
