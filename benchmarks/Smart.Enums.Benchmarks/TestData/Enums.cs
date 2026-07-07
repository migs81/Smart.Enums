namespace Smart.Enums.Benchmarks.TestData
{
    public static class MyEnums
    {
        public enum NameType
        {
            [SmartEnum(name: "Test", description: "Just a test")]
            FirstName = 0,

            [SmartEnum(name: "Test", description: "Just a test")]
            MiddleName,

            [SmartEnum(name: "Test", description: "Just a test")]
            LastName,

            FullName
        }

        public enum Color
        {
            [Color(name: "Test", description: "Just a test", code: "T")]
            None = 0,

            [Color(name: "Blue", description: "The color blue.", code: "B")]
            Blue,
        }
    }
}
