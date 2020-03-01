using System;

using NUnit.Framework;

namespace GraphLib.Tests {

    [TestFixture]
    public class NodeTests {

        [Test]
        public void TestNodeEqality() {

            var n1 = new Node(0, 0);
            var n2 = new Node(0, 0);

            Assert.That(n1, Is.EqualTo(n2));
        }

    }

}