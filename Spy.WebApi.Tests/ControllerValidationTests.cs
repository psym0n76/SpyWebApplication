using NUnit.Framework;
using Shouldly;

namespace Spy.WebApi.Tests
{
    [TestFixture]
    public class ControllerValidationTests
    {
        [TestCase(null, "James Bond")]
        public void Should_return_false_when_null_string_is_passed_to_message(string message, string spyName)
        {
            var result = ControllerValidation.Parse(message, spyName);
            result.ShouldBeFalse();
        }

        [TestCase("1,2,3", null)]
        public void Should_return_false_when_null_string_is_passed_to_spyName(string message, string spyName)
        {
            var result = ControllerValidation.Parse(message, spyName);
            result.ShouldBeFalse();
        }
    }
}