using System;
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

        [Fact]
        public void should_throw_argument_exception_when_expression_is_not_a_member_expression()
        {
            var objectBuilder = new ObjectBuilder<Person>();
            var actualException = Assert.Throws<ArgumentException>(() => objectBuilder.With(_ => "something", "John Smith"));
            Assert.NotNull(actualException);
            Assert.Equal("propertySelector", actualException.Message);
        }
    }
}