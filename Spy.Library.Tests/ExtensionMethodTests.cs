using NUnit.Framework;
using Shouldly;

namespace Spy.Library.Tests
{
    [TestFixture]
    public class ExtensionMethodTests
    {
        [Test]
        public void Should_convert_string_into_a_int_array()
        {
            const string message = "1,2,3";
            var result = message.ToIntArray();
            result.Length.ShouldBe(3);
        }

        [Test]
        public void Should_convert_string_into_a_int_array_with_three_elements()
        {
            const string message = "1,2,3";
            var result = message.ToIntArray();
            result.Length.ShouldNotBe(4);
        }
    }
}