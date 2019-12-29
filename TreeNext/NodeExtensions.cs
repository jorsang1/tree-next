using System;
using System.Collections.Generic;
using System.Linq;

namespace TreeNext
{
    public static class NodeExtensions
    {
        private static IDictionary<Node, int> _nodePositions;

        public static Node Next(this Node node)
        {
            if (_nodePositions == null) _nodePositions = new Dictionary<Node, int>();

            return GetChildAt(node, 0);
        }

        private static Node GetChildAt(Node node, int position)
        {
            if (node.Children.Count() > position)
            {
                return GetChildAndSavePosition(node, position);
            }

            return GetNextSibiling(node);
        }

        private static Node GetChildAndSavePosition(Node node, int position)
        {
            var child = node.Children.ElementAt(position);
            if (!_nodePositions.ContainsKey(child)) _nodePositions.Add(child, position);
            return child;
        }

        private static Node GetNextSibiling(Node node)
        {
            if (node.Parent != null)
            {
                var currentParentPosition = _nodePositions[node];
                return GetChildAt(node.Parent, currentParentPosition + 1);
            }
            return null;
        }
    }
}
