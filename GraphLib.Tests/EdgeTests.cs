using System;

using NUnit.Framework;

namespace GraphLib.Tests {

    [TestFixture]
    public class EdgeTests {

        [Test]
        public void EdgeEqualityTest() {

            var n1 = new Node(1, 5);
            var n2 = new Node(3, 2);

            var e1 = new Edge(n1, n2);
            var e2 = new Edge(n2, n1);

            Assert.That(e1, Is.EqualTo(e2));
        }

        [Test]
        public void EdgeNotEqualTest() {

            var n1 = new Node(1,  5);
            var n2 = new Node(3,  2);
            var n3 = new Node(11, 6);

            var e1 = new Edge(n1, n2);
            var e2 = new Edge(n1, n3);

            Assert.That(e1, Is.Not.EqualTo(e2));
        }

        [Test]
        public void TestSameStartAndEndNode() {

            var n = new Node(1, 5);

            Assert.Throws<ArgumentException>(
                () => {
                    var _ = new Edge(n, n);
                });
        }

    }

}