using System;

namespace GraphLib {

    public struct Node: IEquatable<Node> {

        public Node(double x, double y) {
            X = x;
            Y = y;

        }

        public double X { get; }
        public double Y { get; }

        public override string ToString() {
            return $"({X}, {Y})";
        }

        public bool Equals(Node other) {
            return X.Equals(other.X) && Y.Equals(other.Y);
        }

        public override bool Equals(object obj) {
            return obj is Node other && Equals(other);
        }

        public override int GetHashCode() {
            return HashCode.Combine(X, Y);
        }

        public static bool operator ==(Node left, Node right) {
            return left.Equals(right);
        }

        public static bool operator !=(Node left, Node right) {
            return !left.Equals(right);
        }

    }

}