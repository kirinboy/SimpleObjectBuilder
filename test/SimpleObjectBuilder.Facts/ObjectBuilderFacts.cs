using Xunit;

namespace SimpleObjectBuilder.Facts
{
    public class ObjectBuilderFacts
    {
        [Fact]
        public void should_set_property_value_when_call_with_method()
        {
            var objectBuilder = new ObjectBuilder<Person>();
            objectBuilder.With(_ => _.Name, "John Smith");
            var actualPerson = objectBuilder.Build();
            Assert.Equal("John Smith", actualPerson.Name);
        }
    }
}