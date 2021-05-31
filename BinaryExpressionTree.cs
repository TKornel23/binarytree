using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSTUTU_BinárisFa
{
    
    class BinaryExpressionTree
    {
        private abstract class Node
        {
            public char Data { get; set; }
            public Node Left { get; set; }
            public Node Right { get; set; }
            public Node(char data, Node left, Node right)
            {
                this.Data = data;
                this.Left = left;
                this.Right = right;
            }

            public Node(char data)
                : this(data, null, null)
            {

            }
        }
        private class OperatorNode : Node
        {
            public Operator Operator { get; }

            public OperatorNode(char data, Node left, Node right)
                : base(data, left, right)
            {
                this.Operator = (Operator)data;
            }

        }
        private class OperandNode : Node
        {
            public OperandNode(char data)
                : base(data)
            {

            }
        }

        private Node Root { get; }

        private BinaryExpressionTree(Node root)
        {
            this.Root = root;
        }

        public static BinaryExpressionTree Build(string expression)
        {
            char[] characterArray = expression.ToCharArray();

            return Build(characterArray);
        }

        private static BinaryExpressionTree Build(char[] characterArray)
        {
            Stack<Node> verem = new Stack<Node>();

            for(int i = 0; i < characterArray.Length; i++)
            {
                if (Char.IsDigit(characterArray[i]))
                {
                    verem.Push(new OperandNode(characterArray[i]));
                }
                else if(characterArray[i] == 43 || characterArray[i] == 45 || characterArray[i] == 42 || characterArray[i] == 47 || characterArray[i] == 94)
                {
                    Node right = verem.Pop();
                    Node left = verem.Pop();
                    verem.Push(new OperatorNode(characterArray[i], left, right));
                }
                else
                {
                    string errorMsg = "";
                    for (int j = 0; j < characterArray.Length; j++)
                    {
                        errorMsg += characterArray[j];
                    }
                    throw new InvalidExpressionException(errorMsg,i);
                }
            }

            return new BinaryExpressionTree(verem.Pop());
        }

        public override string ToString()
        {
            if(Root == null)
            {
                return "";
            }
            return ToString(Root);
        }

        private string ToString(Node root)
        {
            string result = "";
            if(root != null)
            {
                result += ToString(root.Left);
                result += ToString(root.Right);
                result += root.Data;
            }

            return result;
        }

        public string Convert()
        {
            if(Root == null)
            {
                return "";
            }
            return Convert(Root);
        }

        private string Convert(Node root)
        {
            string order = "";

            if (root == null)
            {
                return "";
            }

            if (root is OperatorNode)
            {
                order += "(";
            }
            order += Convert(root.Left);
            order += root.Data;
            order += Convert(root.Right);
            if (root is OperatorNode)
            {
                order += ")";
            }

            return order;
        }

        public double Evaluate()
        {
            if(Root == null)
            {
                return 0;
            }

            return Evaluate(Root);
        }

        private double Evaluate(Node root)
        {
            if(root == null)
            {
                return 0;
            }
            else if(root is OperandNode)
            {
                return double.Parse(root.Data.ToString());
            }
            else
            {
                double left = Evaluate(root.Left);
                double right = Evaluate(root.Right);

                switch (root.Data)
                {
                        case '+':
                            return left + right;
                        case '-':
                            return left - right;
                        case '*':
                            return left * right;
                        case '/':
                            return left / right;
                        case '^':
                            return Math.Pow(left, right);
                    default:
                        return 0;
                }
            }            
        }
    }
}
