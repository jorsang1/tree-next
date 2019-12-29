using Microsoft.VisualStudio.TestTools.UnitTesting;
using TreeNext;

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

        [TestMethod]
        public void Next_WHEN_TreeHasOneChild_THEN_returnThisChild()
        {
            var sut = new Node(1,
                new Node(2));
            var result = sut.Next();

            Assert.AreEqual(result.Data, 2);
        }
    }
}
