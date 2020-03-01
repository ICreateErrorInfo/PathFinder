using System.Linq;

using NUnit.Framework;

namespace GraphLib.Tests {

    [TestFixture]
    public class PathTests {

        [Test]
        public void Basics() {

            var nodes = new[] {
                new Node(0, 2),
                new Node(3, 2),
                new Node(1, 5)
            };

            var p = new Path();
            foreach (var n in nodes) {
                p.AddNode(n);
            }

            var pathNodes = p.GetNodes();

            Assert.That(pathNodes, Is.EqualTo(nodes));

            var edges = p.GetEdges().ToList();

            Assert.That(edges.Count, Is.EqualTo(2));

            Assert.That(edges[0], Is.EqualTo(new Edge(nodes[0], nodes[1])));
            Assert.That(edges[1], Is.EqualTo(new Edge(nodes[1], nodes[2])));

        }

    }

}