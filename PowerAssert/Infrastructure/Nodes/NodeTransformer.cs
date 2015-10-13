using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PowerAssert.Infrastructure.Nodes
{
    internal class NodeTransformer
    {
        public virtual Node Transform(Node node)
        {
            return TransformNode((dynamic)node);
        }

        protected virtual Node TransformNode(ArrayIndexNode node) { return node; }
        protected virtual Node TransformNode(BinaryNode node) { return node; }
        protected virtual Node TransformNode(ConditionalNode node) { return node; }
        protected virtual Node TransformNode(ConstantNode node) { return node; }
        protected virtual Node TransformNode(InvocationNode node) { return node; }
        protected virtual Node TransformNode(MemberAccessNode node) { return node; }
        protected virtual Node TransformNode(MethodCallNode node) { return node; }
        protected virtual Node TransformNode(NewArrayNode node) { return node; }
        protected virtual Node TransformNode(NewObjectNode node) { return node; }
        protected virtual Node TransformNode(MemberInitNode node) { return node; }
        protected virtual Node TransformNode(ListInitNode node) { return node; }
        protected virtual Node TransformNode(MemberAssignmentNode node) { return node; }
        protected virtual Node TransformNode(UnaryNode node) { return node; }
        protected virtual Node TransformNode(NewAnonymousTypeNode node) { return node; }
    }
}
