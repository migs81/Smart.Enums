using System;

namespace Smart.Enums
{
    /// <summary>
    /// Attribute to append additional data to enumerations.
    /// </summary>
    /// <seealso cref="Attribute" />
    [AttributeUsage(AttributeTargets.Field)]
    public class SmartEnumAttribute : Attribute
    {
        public string Name { get; }
        public string Description { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SmartEnumAttribute"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="description">The description.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public SmartEnumAttribute(string name, string description)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Description = description ?? throw new ArgumentNullException(nameof(description));
        }
    }
}