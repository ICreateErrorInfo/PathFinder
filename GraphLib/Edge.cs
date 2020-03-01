using System;

namespace GraphLib {

    public class Edge: IEquatable<Edge> {

        public Edge(Node node1, Node node2) {

            if (node1 == node2) {
                throw new ArgumentException("Start node equals end node!");
            }

            Node1 = node1;
            Node2 = node2;

        }

        public Node Node1 { get; }
        public Node Node2 { get; }

        public override string ToString() {
            return $"{Node1} -> {Node2}";
        }

        public Edge Reverese() {
            return new Edge(Node2, Node1);
        }

        public bool Equals(Edge other) {
            if (ReferenceEquals(null, other)) {
                return false;
            }

            if (ReferenceEquals(this, other)) {
                return true;
            }

            if (Node1.Equals(other.Node1) && Node2.Equals(other.Node2)) {
                return true;
            }

            if (Node1.Equals(other.Node2) && Node2.Equals(other.Node1)) {
                return true;
            }

            return false;
        }

        public override bool Equals(object obj) {

            if (ReferenceEquals(null, obj)) {
                return false;
            }

            if (ReferenceEquals(this, obj)) {
                return true;
            }

            if (obj.GetType() != GetType()) {
                return false;
            }

            return Equals((Edge) obj);
        }

        public override int GetHashCode() {
            return HashCode.Combine(Node1, Node2);
        }

        public static bool operator ==(Edge left, Edge right) {
            return Equals(left, right);
        }

        public static bool operator !=(Edge left, Edge right) {
            return !Equals(left, right);
        }

    }

}