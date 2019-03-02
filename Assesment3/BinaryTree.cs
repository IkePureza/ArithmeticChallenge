////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	BinaryTree.cs
//
// summary:	Implements the binary tree class
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
    /// <summary>   A binary tree. </summary>
    ///
    /// <remarks>   Pureza, 9/16/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    class BinaryTree
    {
        /// <summary>   The top. </summary>
        public BinaryNode top;
        /// <summary>   The print string. </summary>
        private static string printStr = "";

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Print pre order. </summary>
        ///
        /// <remarks>   Pureza, 9/16/2018. </remarks>
        ///
        /// <param name="tree"> The tree. </param>
        ///
        /// <returns>   A string. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public string printPreOrder(BinaryTree tree)
        {
            printStr = "";
            PreOrder(tree.top);
            return printStr;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Pre order. </summary>
        ///
        /// <remarks>   Pureza, 9/16/2018. </remarks>
        ///
        /// <param name="Root"> The root. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void PreOrder(BinaryNode Root)
        {
            if (Root == null)
            {
                return;
            }
            else
            {
                printStr += Root.NodeToString();
                PreOrder(Root.left);
                PreOrder(Root.right);
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Print in order. </summary>
        ///
        /// <remarks>   Pureza, 9/16/2018. </remarks>
        ///
        /// <param name="tree"> The tree. </param>
        ///
        /// <returns>   A string. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public string printInOrder(BinaryTree tree)
        {
            printStr = "";
            InOrder(tree.top);
            return printStr;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   In order. </summary>
        ///
        /// <remarks>   Pureza, 9/16/2018. </remarks>
        ///
        /// <param name="Root"> The root. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void InOrder(BinaryNode Root)
        {
            if (Root == null)
            {
                return;
            }
            else
            {
                InOrder(Root.left);
                if (!printStr.Contains(Root.NodeToString()))
                {
                    printStr += Root.NodeToString();
                }
                InOrder(Root.right);
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Print post order. </summary>
        ///
        /// <remarks>   Pureza, 9/16/2018. </remarks>
        ///
        /// <param name="tree"> The tree. </param>
        ///
        /// <returns>   A string. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public string printPostOrder(BinaryTree tree)
        {
            printStr = "";
            PostOrder(tree.top);
            return printStr;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Posts an order. </summary>
        ///
        /// <remarks>   Pureza, 9/16/2018. </remarks>
        ///
        /// <param name="Root"> The root. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void PostOrder(BinaryNode Root)
        {
            if (Root == null)
            {
                return;
            }
            PreOrder(Root.left);
            PreOrder(Root.right);
            printStr += Root.NodeToString();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Pureza, 9/16/2018. </remarks>
        ///
        /// <param name="answerVal">    The answer value. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public BinaryTree(Question answerVal)
        {
            top = new BinaryNode(answerVal);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Pureza, 9/16/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public BinaryTree()
        {
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Adds quest. </summary>
        ///
        /// <remarks>   Pureza, 9/16/2018. </remarks>
        ///
        /// <param name="quest">    The Question to add. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void Add(Question quest)
        {
            //nonrecursive
            if (top == null)
            {
                //the tree is empty
                top = new BinaryNode(quest);
                return;
            }
            BinaryNode currentNode = top;
            bool insert = false;

            do
            {
                //if the inserted value is less than current
                if (quest.answer < currentNode.equation.answer)
                {
                    //insert left
                    if (currentNode.left == null)
                    {
                        //end node
                        currentNode.left = new BinaryNode(quest);
                        insert = true;
                    }
                    else
                    {
                        //move left
                        currentNode = currentNode.left;
                    }

                    //if the inserted value is greeated than or equal to current
                    if (quest.answer >= currentNode.equation.answer)
                    {
                        //insert right
                        if (currentNode.right == null)
                        {
                            //end node
                            currentNode.right = new BinaryNode(quest);
                            insert = true;
                        }
                        else
                        {
                            //move right
                            currentNode = currentNode.right;
                        }
                    }
                    else
                    {

                    }
                }
            } while (!insert);
        }
    }
}
