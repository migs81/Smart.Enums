using System;
using System.Collections.Concurrent;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace Smart.Enums
{
    /// <summary>
    /// Extension methods for enum attributes
    /// </summary>
    public static class Extensions
    {
        private static readonly ConcurrentDictionary<Enum, SmartEnumAttribute> Cache = new();

        /// <summary>
        /// Gets the attribute for the given enum considering the requested attribute type.
        /// </summary>
        /// <typeparam name="TAttr">The type of the enum attribute.</typeparam>
        /// <param name="source">The source enum.</param>
        /// <returns></returns>
        /// <exception>
        ///     <cref>EnumAttributeNotFoundException</cref>
        /// </exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TAttr GetAttribute<TAttr>(this Enum source) where TAttr : SmartEnumAttribute
        {
            if (!SmartEnumConfig.UseCache) 
                return GetAttribute<TAttr>(ref source);
            
            if (Cache.TryGetValue(source, out var attr))
                return (TAttr)attr;

            var attribute = GetAttribute<TAttr>(ref source);
            Cache.TryAdd(source, attribute);
            return attribute;
        }

        /// <summary>
        /// Gets the attribute.
        /// </summary>
        /// <typeparam name="TAttr">The type of the attribute.</typeparam>
        /// <param name="source">The source.</param>
        /// <returns></returns>
        /// <exception>
        ///     <cref>EnumAttributeNotFoundException</cref>
        /// </exception>
        private static TAttr GetAttribute<TAttr>(ref Enum source) where TAttr : SmartEnumAttribute
        {
            var type = source.GetType();
            var name = Enum.GetName(type, source) ?? throw new SmartEnumNotFoundException(typeof(TAttr), source);

            return type.GetField(name)?.GetCustomAttribute<TAttr>() ?? throw new SmartEnumNotFoundException(typeof(TAttr), source);
        }
    }
}