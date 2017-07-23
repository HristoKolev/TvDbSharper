namespace TvDbSharper.Tests
{
    using System;

    using TvDbSharper.Clients.Authentication;

    using Xunit;

    public class AuthenticationDataTest
    {
        [Fact]

        // ReSharper disable once InconsistentNaming
        public void AuthenticationResponse_Has_Empty_Constructor()
        {
            new AuthenticationResponse();
        }

        [Fact]

        // ReSharper disable once InconsistentNaming
        public void Has_Empty_Constructor()
        {
            new AuthenticationData();
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData("  ")]
        [InlineData("\t")]
        [InlineData("\r")]
        [InlineData("\n")]

        // ReSharper disable once InconsistentNaming
        public void Throws_If_API_KEY_is_falsy(string value)
        {
            Assert.Throws<ArgumentException>(() => new AuthenticationData(value, "d", "d"));
        }

        [Fact]

        // ReSharper disable once InconsistentNaming
        public void Throws_If_API_KEY_is_null()
        {
            Assert.Throws<ArgumentNullException>(() => new AuthenticationData(null, "d", "d"));
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData("  ")]
        [InlineData("\t")]
        [InlineData("\r")]
        [InlineData("\n")]

        // ReSharper disable once InconsistentNaming
        public void Throws_If_Inline_API_KEY_is_falsy(string value)
        {
            Assert.Throws<ArgumentException>(() => new AuthenticationData(value));
        }

        [Fact]

        // ReSharper disable once InconsistentNaming
        public void Throws_If_Inline_API_KEY_is_null()
        {
            Assert.Throws<ArgumentNullException>(() => new AuthenticationData(null));
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData("  ")]
        [InlineData("\t")]
        [InlineData("\r")]
        [InlineData("\n")]

        // ReSharper disable once InconsistentNaming
        public void Throws_If_USERKEY_is_falsy(string value)
        {
            Assert.Throws<ArgumentException>(() => new AuthenticationData("d", "d", value));
        }

        [Fact]

        // ReSharper disable once InconsistentNaming
        public void Throws_If_USERKEY_is_null()
        {
            Assert.Throws<ArgumentNullException>(() => new AuthenticationData("d", "d", null));
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData("  ")]
        [InlineData("\t")]
        [InlineData("\r")]
        [InlineData("\n")]

        // ReSharper disable once InconsistentNaming
        public void Throws_If_USERNAME_is_falsy(string value)
        {
            Assert.Throws<ArgumentException>(() => new AuthenticationData("d", value, "d"));
        }

        [Fact]

        // ReSharper disable once InconsistentNaming
        public void Throws_If_USERNAME_is_null()
        {
            Assert.Throws<ArgumentNullException>(() => new AuthenticationData("d", null, "d"));
        }
    }
}