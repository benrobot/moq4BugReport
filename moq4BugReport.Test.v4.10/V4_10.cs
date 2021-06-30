using Moq;
using Xunit;

namespace moq4BugReport.Test.v4._10
{
    public class V4_10
    {
        [Fact]
        public void Test1()
        {
            var mockTwo = new Mock<IInterfaceTwo>();
            mockTwo.Setup(x => x.MethodTwo()).Returns(true);
            var mockOne = new Mock<IInterfaceOne>();
            mockOne.Setup(x => x.MethodOne()).Returns(mockTwo.Object);

            mockOne.Object.MethodOne();
            mockTwo.Object.MethodTwo();

            mockOne.Verify(x => x.MethodOne());
            mockOne.VerifyNoOtherCalls();
        }
    }

    public interface IInterfaceOne
    {
        IInterfaceTwo MethodOne();
    }

    public interface IInterfaceTwo
    {
        bool MethodTwo();
    }
}
