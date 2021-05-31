using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSTUTU_BinárisFa
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Test 'number' is only node..");
                BinaryExpressionTree tree = BinaryExpressionTree.Build("7");
                Console.WriteLine(tree.ToString() + "\t \t \t = " + tree.Convert() + "\t \t \t = " + tree.Evaluate());
                Console.WriteLine();
                Console.WriteLine("Test 'simple' operators..");
                BinaryExpressionTree tree1 = BinaryExpressionTree.Build("28+");
                Console.WriteLine(tree1.ToString() + "\t \t \t = " + tree1.Convert() + "\t \t \t  = " + tree1.Evaluate());

                BinaryExpressionTree tree2 = BinaryExpressionTree.Build("28-");
                Console.WriteLine(tree2.ToString() + "\t \t \t = " + tree2.Convert() + "\t \t \t  = " + tree2.Evaluate());

                BinaryExpressionTree tree3 = BinaryExpressionTree.Build("28*");
                Console.WriteLine(tree3.ToString() + "\t \t \t = " + tree3.Convert() + "\t \t \t  = " + tree3.Evaluate());

                BinaryExpressionTree tree4 = BinaryExpressionTree.Build("28/");
                Console.WriteLine(tree4.ToString() + "\t \t \t = " + tree4.Convert() + "\t \t \t  = " + tree4.Evaluate());

                BinaryExpressionTree tree5 = BinaryExpressionTree.Build("28^");
                Console.WriteLine(tree5.ToString() + "\t \t \t = " + tree5.Convert() + "\t \t \t  = " + tree5.Evaluate());
                Console.WriteLine();
                Console.WriteLine("Test 'example' expressions..");

                BinaryExpressionTree tree6 = BinaryExpressionTree.Build("234*+");
                Console.WriteLine(tree6.ToString() + "\t \t \t = " + tree6.Convert() + "\t \t \t  = " + tree6.Evaluate());

                BinaryExpressionTree tree7 = BinaryExpressionTree.Build("23*4+");
                Console.WriteLine(tree7.ToString() + "\t \t \t = " + tree7.Convert() + "\t \t  \t  = " + tree7.Evaluate());

                BinaryExpressionTree tree8 = BinaryExpressionTree.Build("23*45*+");
                Console.WriteLine(tree8.ToString() + "\t \t \t = " + tree8.Convert() + "\t \t  = " + tree8.Evaluate());

                BinaryExpressionTree tree9 = BinaryExpressionTree.Build("23+45-/");
                Console.WriteLine(tree9.ToString() + "\t \t \t = " + tree9.Convert() + "\t \t  = " + tree9.Evaluate());

                BinaryExpressionTree tree10 = BinaryExpressionTree.Build("23+4*5+67^8+/");
                Console.WriteLine(tree10.ToString() + "\t \t = " + tree10.Convert() + "\t  = " + tree10.Evaluate());
                Console.WriteLine();

                BinaryExpressionTree tree11 = BinaryExpressionTree.Build("12-3-A-45");
                Console.WriteLine(tree11.ToString() + "\t \t \t = " + tree11.Convert() + "\t \t = " + tree11.Evaluate());

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }    
        }
    }
}
