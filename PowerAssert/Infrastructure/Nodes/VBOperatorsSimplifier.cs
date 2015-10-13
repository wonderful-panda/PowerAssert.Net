using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PowerAssert.Infrastructure.Nodes
{
    class VBOperatorsSimplifier : NodeTransformer
    {
        bool IsConstantNodeOf(Node node, string text)
        {
            var constant = node as ConstantNode;
            return constant != null && constant.Text == text;
        }

        protected override Node TransformNode(BinaryNode node)
        {
            var method = node.Left as MethodCallNode;
            if (method == null || !IsConstantNodeOf(method.Container, "$PAssert.VBOperators"))
                return base.TransformNode(node);

            switch (method.MemberName)
            {
                case "CompareString":
                    // CompareString(string left, string right, bool compareText)
                    if (!new[] { "==", "!=", "<", ">", "=<", "=>" }.Contains(node.Operator))
                        break;
                    if (!IsConstantNodeOf(node.Right, "0"))
                        break;
                    if (method.Parameters.Count != 3)
                        break;
                    if (!IsConstantNodeOf(method.Parameters[2], "False"))
                        break;
                    return new BinaryNode
                    {
                        Operator = node.Operator,
                        Left = method.Parameters[0],
                        Right = method.Parameters[1],
                        Value = node.Value
                    };
                default:
                    break;
            }
            return base.TransformNode(node);
        }
    }
}
