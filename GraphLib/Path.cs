using System;
using System.Collections.Generic;
using System.Linq;

namespace GraphLib {

    public class Path {

        readonly List<Node> _nodes;

        public Path() {
            _nodes = new List<Node>();
        }

        public void AddNode(Node node) {

            if (_nodes.Any() && _nodes.Last() == node) {
                throw new InvalidOperationException();
            }

            _nodes.Add(node);
        }

        public IEnumerable<Node> GetNodes() {
            return _nodes;
        }

        public IEnumerable<Edge> GetEdges() {

            if (_nodes.Count < 2) {
                yield break;
            }

            var n1 = _nodes[0];
            for (int i = 1; i < _nodes.Count; i++) {

                var n2 = _nodes[i];

                yield return new Edge(n1, n2);

                n1 = n2;

            }

        }

    }

}