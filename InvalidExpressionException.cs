using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSTUTU_BinárisFa
{
    class InvalidExpressionException : Exception
    {
        public InvalidExpressionException(string expression, int index)
            :base($"Invalid character found at position: {index}, in the following expression: '{expression}'!")
        {

        }

        public override string ToString()
        {
            return $"InvalidExpressionException: {Message}";
        }
    }
}
