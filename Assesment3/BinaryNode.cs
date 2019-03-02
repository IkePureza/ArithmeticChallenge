////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	BinaryNode.cs
//
// summary:	Implements the binary node class
////////////////////////////////////////////////////////////////////////////////////////////////////
/*
 *      Student Number: 450402607
 *      Name:           Henrique Pureza
 *      Date:           16/09/2018
 *      Purpose:        Student form
 *      Known Bugs:     
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assesment3
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A binary node. </summary>
    ///
    /// <remarks>   Pureza, 9/16/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    class BinaryNode
    {
        /// <summary>   The equation. </summary>
        public Question equation;
        /// <summary>   The left. </summary>
        public BinaryNode left;
        /// <summary>   The right. </summary>
        public BinaryNode right;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Pureza, 9/16/2018. </remarks>
        ///
        /// <param name="val">  The value. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public BinaryNode(Question val)
        {
            equation = val;
            left = null;
            right = null;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Node to string. </summary>
        ///
        /// <remarks>   Pureza, 9/16/2018. </remarks>
        ///
        /// <returns>   A string. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public string NodeToString()
        {
            return equation.answer.ToString() + "(" + equation.firstNumber.ToString() + equation.Symbol + equation.secondNumber.ToString() + "), ";
        }
    }
}
