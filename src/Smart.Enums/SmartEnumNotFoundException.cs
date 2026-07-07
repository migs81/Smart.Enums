using System;

namespace Smart.Enums
{
    public class SmartEnumNotFoundException : Exception
    {
        public SmartEnumNotFoundException()
        {
        }

        public SmartEnumNotFoundException(string? message) 
            : base(message)
        {
        }

        public SmartEnumNotFoundException(string? message, Exception? innerException) 
            : base(message, innerException)
        {
        }

        public SmartEnumNotFoundException(Type attributeType, Enum value)
            : base($"Could not find the requested '{attributeType.Name}' for '{value.GetType().Name}.{value}'!")
        {
        }
    }
}
