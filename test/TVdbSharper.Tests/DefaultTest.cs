namespace TVdbSharper.Tests
{
    using Xunit;

    public class DefaultTest
    {
        [Fact]
        public void FailingTest()
        {
            Assert.True(false);
        }

        [Fact]
        public void PassingTest()
        {
            Assert.True(true);
        }
    }
}