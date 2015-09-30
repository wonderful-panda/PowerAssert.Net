using JetBrains.Annotations;

namespace PowerAssert.Infrastructure.Nodes
{
    class MemberAccessNode : Node
    {
        [NotNull]
        public Node Container { get; set; }

        [NotNull]
        public string MemberName { get; set; }

        [NotNull]
        public string MemberValue { get; set; }

        internal override void Walk(NodeWalker walker, int depth, bool wrap)
        {
            var constant = Container as ConstantNode;
            var isSpecialContainer = constant != null && constant.Text.StartsWith("$PAssert");
            if (!isSpecialContainer)
            {
                Container.Walk(walker, depth + 1, Priority < Container.Priority);
            }
            if (MemberName == "get_Item")
            {
                walker("[", MemberValue, depth);
            }
            else
            {
                if (!isSpecialContainer)
                {
                    walker(".");
                }
                walker(MemberName, MemberValue, depth);
            }
        }
    }
}
