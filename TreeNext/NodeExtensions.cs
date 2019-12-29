﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace TreeNext
{
    public static class NodeExtensions
    {
        private static IDictionary<Node, int> _nodePositions;

        public static Node Next(this Node node)
        {
            if (node.Children.Count() > 0)
            {
                if (_nodePositions == null) _nodePositions = new Dictionary<Node, int>();
                return GetChildAndSetPosition(node, 0);
            }

            if (node.Parent != null)
            {
                var currentPosition = _nodePositions[node];
                return GetChildAt(node.Parent, currentPosition + 1);
            }

            return null;
        }

        private static Node GetChildAt(Node node, int position)
        {
            if (node.Children.Count() > position)
            {
                return GetChildAndSetPosition(node, position);
            }

            if (node.Parent != null)
            {
                var currentPosition = _nodePositions[node];
                return GetChildAt(node.Parent, currentPosition + 1);
            }

            return null;
        }

        private static Node GetChildAndSetPosition(Node node, int position)
        {
            var child = node.Children.ElementAt(position);
            _nodePositions.Add(child, position);
            return child;
        }
    }
}
