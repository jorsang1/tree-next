using System.Linq;

namespace TreeNext
{
    public static class NodeExtensions
    {
        public static Node Next(this Node node)
        {
            if (node.Children.Count() > 0)
                return node.Children.First();

            return null;
        }
    }
}
