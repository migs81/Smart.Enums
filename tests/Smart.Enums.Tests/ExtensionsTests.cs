using Xunit;

namespace Smart.Enums.Tests
{
    public class ExtensionsTests
    {
        private const string Name = "Test";
        private const string Description = "Just a test";

        private enum Default
        {
            [SmartEnum(Name, Description)]
            None,
        }

        private enum Color
        {
            [SmartEnum(Name, Description)]
            None = 0,

            [SmartEnum(Name, Description)]
            Black = 1,

            [SmartEnum(Name, Description)]
            Red = 2,

            [SmartEnum(Name, Description)]
            Green = 4,

            [SmartEnum(Name, Description)]
            Blue = 8
        }

        [Fact]
        [Trait("Category", "Extension")]
        public void GetAttribute_DefaultEnum_ShouldBeEqual()
        {
            Assert.Equal(Name, Default.None.GetAttribute<SmartEnumAttribute>().Name);
            Assert.Equal(Description, Default.None.GetAttribute<SmartEnumAttribute>().Description);
        }

        [Fact]
        [Trait("Category", "Extension")]
        public void GetAttribute_FlaggedEnum_ShouldBeEqual()
        {
            Assert.Equal(Name, Color.Black.GetAttribute<SmartEnumAttribute>().Name);
            Assert.Equal(Description, Color.Blue.GetAttribute<SmartEnumAttribute>().Description);
        }
    }
}
