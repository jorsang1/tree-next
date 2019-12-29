using System.Collections.Generic;
using System.Linq;

namespace TreeNext
{
    public static class NodeExtensions
    {
        private static IDictionary<Node, int> _nodePositions;

        public static Node Next(this Node node, int position = 0)
        {
            InitializeNodePositions();

            if (node.Children.Count() > position)
            {
                return GetChildAndSavePosition(node, position);
            }

            return GetNextSibiling(node);
        }

        private static void InitializeNodePositions()
        {
            if (_nodePositions == null) _nodePositions = new Dictionary<Node, int>();
        }

        private static Node GetChildAndSavePosition(Node node, int position)
        {
            var child = node.Children.ElementAt(position);
            AddNodePosition(position, child);
            return child;
        }

        private static void AddNodePosition(int position, Node child)
        {
            if (!_nodePositions.ContainsKey(child)) _nodePositions.Add(child, position);
        }

        private static Node GetNextSibiling(Node node)
        {
            if (node.Parent != null)
            {
                var currentParentPosition = _nodePositions[node];
                return node.Parent.Next(currentParentPosition + 1);
            }
            return null;
        }
    }
}
