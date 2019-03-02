////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Question.cs
//
// summary:	Implements the question class
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
    /// <summary>   A question. </summary>
    ///
    /// <remarks>   Pureza, 9/16/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    class Question
    {
        /// <summary>   The first number. </summary>
        public int firstNumber;
       
        /// <summary>   The second number. </summary>
        public int secondNumber;
        
        /// <summary>   The symbol. </summary>
        public string Symbol;
        
        /// <summary>   The answer. </summary>
        public int answer;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Pureza, 9/16/2018. </remarks>
        ///
        /// <param name="firstNum">     The first number. </param>
        /// <param name="secondNum">    The second number. </param>
        /// <param name="symbol">       The symbol. </param>
        /// <param name="result">       The result. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public Question(int firstNum, int secondNum, string symbol, int result)
        {
            firstNumber = firstNum;
            secondNumber = secondNum;
            Symbol = symbol;
            answer = result;
        }
    }
}
