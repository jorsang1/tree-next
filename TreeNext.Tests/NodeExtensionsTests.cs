using Microsoft.VisualStudio.TestTools.UnitTesting;

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

        [TestMethod]
        public void Next_WHEN_TreeHasDifferentChildren_THEN_returnAllChildrenInDeep()
        {
            var sut = new Node(1,
                new Node(2,
                    new Node(3,
                        new Node(4))));

            var result = sut.Next();
            Assert.AreEqual(result.Data, 2);

            result = result.Next();
            Assert.AreEqual(result.Data, 3);

            result = result.Next();
            Assert.AreEqual(result.Data, 4);
        }

        [TestMethod]
        public void Next_WHEN_OneNodeHasSibilings_THEN_returnAllSibilings()
        {
            var sut = new Node(1,
                new Node(2,
                    new Node(3),
                    new Node(4),
                    new Node(5)));

            var result = sut.Next();
            Assert.AreEqual(result.Data, 2);

            result = result.Next();
            Assert.AreEqual(result.Data, 3);

            result = result.Next();
            Assert.AreEqual(result.Data, 4);

            result = result.Next();
            Assert.AreEqual(result.Data, 5);
        }

        [TestMethod]
        public void Next_WHEN_OneNodeHasChildrenAndSibilings_THEN_returnChildrenFisrtAndThenAllSibilings()
        {
            var sut = new Node(1,
                new Node(2,
                    new Node(3),
                    new Node(4),
                    new Node(5)),
                new Node(6));

            var result = sut.Next();
            Assert.AreEqual(result.Data, 2);

            result = result.Next();
            Assert.AreEqual(result.Data, 3);

            result = result.Next();
            Assert.AreEqual(result.Data, 4);

            result = result.Next();
            Assert.AreEqual(result.Data, 5);

            result = result.Next();
            Assert.AreEqual(result.Data, 6);
        }

        [TestMethod]
        public void Next_WHEN_CompleteTreeWithDifferentLevels_THEN_exploreInDeepFirstAndGetNullAtTheEnd()
        {
            var sut = new Node(1,
                new Node(2,
                    new Node(3),
                    new Node(4,
                        new Node(41),
                        new Node(42)),
                    new Node(5)),
                new Node(6),
                new Node(7));

            var result = sut.Next();
            Assert.AreEqual(result.Data, 2);

            result = result.Next();
            Assert.AreEqual(result.Data, 3);

            result = result.Next();
            Assert.AreEqual(result.Data, 4);

            result = result.Next();
            Assert.AreEqual(result.Data, 41);

            result = result.Next();
            Assert.AreEqual(result.Data, 42);

            result = result.Next();
            Assert.AreEqual(result.Data, 5);

            result = result.Next();
            Assert.AreEqual(result.Data, 6);

            result = result.Next();
            Assert.AreEqual(result.Data, 7);

            result = result.Next();
            Assert.IsNull(result);
        }

        [TestMethod]
        public void Next_WHEN_ExploringATreeTwice_THEN_bothExplorationsAreOk()
        {
            var sut = new Node(1,
                new Node(2,
                    new Node(3)),
                new Node(4));

            var result = sut.Next();
            Assert.AreEqual(result.Data, 2);

            result = result.Next();
            Assert.AreEqual(result.Data, 3);

            result = result.Next();
            Assert.AreEqual(result.Data, 4);

            result = result.Next();
            Assert.IsNull(result);

            result = sut.Next();
            Assert.AreEqual(result.Data, 2);

            result = result.Next();
            Assert.AreEqual(result.Data, 3);

            result = result.Next();
            Assert.AreEqual(result.Data, 4);

            result = result.Next();
            Assert.IsNull(result);
        }
    }
}
