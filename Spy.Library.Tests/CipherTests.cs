using NUnit.Framework;
using Shouldly;
using Spy.Library.Repository;
using Spy.Library.Services;

namespace Spy.Library.Tests
{
    [TestFixture]
    public class CipherTests
    {
        public ICipherService GetSubjectUnderTest()
        {
            return new CipherService(new SpyRepository());
        }

        [TestCase("1, 2, 4, 0, 0, 7, 5", "James Bond", true)]
        [TestCase("0, 2, 2, 0, 4, 7, 0", "James Bond", true)]
        [TestCase("1, 2, 0, 7, 4, 4, 0", "James Bond", false)]
        [TestCase(" 3, 6, 0, 1, 2, 6, 4", "Ethan Hunt", true)]
        [TestCase("3, 3, 1, 5, 1, 4, 4", "Ethan Hunt", true)]
        [TestCase("4, 1, 3, 8, 4, 3, 1", "Ethan Hunt", false)]
        public void Should_decode_message_and_return_true_if_spy_name_is_in_message(string message, string spyName, bool output)
        {
            var response = GetSubjectUnderTest().Decode(message, spyName);
            response.Success.ShouldBe(output);
        }


        [TestCase("4, 1, 3, 8, 4, 3, 1", "Simon")]
        public void Should_not_throw_exception_if_spy_name_not_found(string message, string spyName)
        {
            var subject = GetSubjectUnderTest();
            ShouldThrowExtensions.ShouldNotThrow(() => subject.Decode(message, spyName));
        }
    }
}