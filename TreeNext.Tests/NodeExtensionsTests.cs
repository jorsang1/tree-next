using Microsoft.VisualStudio.TestTools.UnitTesting;
using TreeNextKata;

namespace TreeNext.Tests
{
    [TestClass]
    public class NodeExtensionsTests
    {
        [TestMethod]
        public void Next_WHEN_TreeHasOnlyTheRootNode_THEN_returnNull()
        {
            var sut = new Node(1);
            var result = sut.Next();

            Assert.IsNull(result);
        }
    }
}
