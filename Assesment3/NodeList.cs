////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	NodeList.cs
//
// summary:	Implements the node list class
////////////////////////////////////////////////////////////////////////////////////////////////////

/*
 *      Student Number: 450402607
 *      Name:           Henrique Pureza
 *      Date:           16/09/2018
 *      Purpose:        Student form
 *      Known Bugs:     
 */
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assesment3
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   List of nodes. </summary>
    ///
    /// <remarks>   Pureza, 9/16/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    class NodeList
    {
        /// <summary>   The tail node. </summary>
        public Node CurrentNode = null, HeadNode = null, TailNode = null;

        /// <summary>   Number of. </summary>
        static int count = 0;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Pureza, 9/16/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public NodeList()
        {

        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Pureza, 9/16/2018. </remarks>
        ///
        /// <param name="aNode">    The node. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public NodeList(Node aNode)
        {
            HeadNode = aNode;
            CurrentNode = aNode;
            TailNode = aNode;
            count++;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets current node. </summary>
        ///
        /// <remarks>   Pureza, 9/16/2018. </remarks>
        ///
        /// <returns>   The current node. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public Node getCurrentNode() { return CurrentNode; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets head node. </summary>
        ///
        /// <remarks>   Pureza, 9/16/2018. </remarks>
        ///
        /// <returns>   The head node. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public Node getHeadNode() { return HeadNode; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets tail node. </summary>
        ///
        /// <remarks>   Pureza, 9/16/2018. </remarks>
        ///
        /// <returns>   The tail node. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public Node getTailNode() { return TailNode; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Sets current node. </summary>
        ///
        /// <remarks>   Pureza, 9/16/2018. </remarks>
        ///
        /// <param name="aNode">    The node. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void setCurrentNode(Node aNode) { CurrentNode = aNode; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Sets head node. </summary>
        ///
        /// <remarks>   Pureza, 9/16/2018. </remarks>
        ///
        /// <param name="aNode">    The node. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void setHeadNode(Node aNode) { HeadNode = aNode; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Sets tail node. </summary>
        ///
        /// <remarks>   Pureza, 9/16/2018. </remarks>
        ///
        /// <param name="aNode">    The node. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void setTailNode(Node aNode) { TailNode = aNode; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Adds at front of node list. </summary>
        ///
        /// <remarks>   Pureza, 9/16/2018. </remarks>
        ///
        /// <param name="aNode">    The node. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void addAtFrontOfNodeList(Node aNode)
        {
            if (HeadNode == null && CurrentNode == null && TailNode == null)
            {
                HeadNode = aNode;
                CurrentNode = aNode;
                TailNode = aNode;
                count++;
            }
            else
            {
                CurrentNode = aNode;
                HeadNode.setPrevious(aNode);
                CurrentNode.setNext(HeadNode);
                setHeadNode(CurrentNode);
                count++;
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Sort list. </summary>
        ///
        /// <remarks>   Pureza, 9/16/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void SortList()
        {
            Node current = HeadNode;
            for (Node i = current; i.getNext() != null; i = i.getNext())
            {
                for (Node j = i.getNext(); j != null; j = j.getNext())
                {
                    if (i.getValue() > j.getValue())
                    {
                        int Temp = j.getValue();
                        j.setMyValue(i.getValue());
                        i.setMyValue(Temp);
                    }
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Binary search. </summary>
        ///
        /// <remarks>   Pureza, 9/16/2018. </remarks>
        ///
        /// <param name="searchValue">  The search value. </param>
        ///
        /// <returns>   An int. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public int binarySearch(int searchValue)
        {
            this.SortList();
            Node current = HeadNode;
            ArrayList myTempList = new ArrayList();
            for (Node i = current; i != null; i = i.getNext())
            {
                myTempList.Add(i.getValue());
            }
            return myTempList.BinarySearch(searchValue);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Print link list. </summary>
        ///
        /// <remarks>   Pureza, 9/16/2018. </remarks>
        ///
        /// <param name="aNode">    The node. </param>
        ///
        /// <returns>   A string. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public string printLinkList(NodeList aNode)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("HEAD");
            if (aNode.HeadNode.getNext() == null)
            {
                sb.Append(" <-> " + aNode.HeadNode.tostring());
            }
            else if (aNode.HeadNode.getNext() != null)
            {
                sb.Append(" <-> " + aNode.HeadNode.tostring());
                aNode.CurrentNode = aNode.HeadNode.getNext();
                while (aNode.CurrentNode != null)
                {
                    sb.Append(" <-> " + aNode.CurrentNode.tostring());
                    aNode.CurrentNode = aNode.CurrentNode.getNext();
                }
            }
            sb.Append(" <-> TAIL");
            return sb.ToString();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Links a list table. </summary>
        ///
        /// <remarks>   Pureza, 9/16/2018. </remarks>
        ///
        /// <param name="aNode">    The node. </param>
        ///
        /// <returns>   A Hashtable. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public Hashtable linkListTable(NodeList aNode)
        {
            Hashtable table = new Hashtable();
            int counter = 1;

            for (Node i = aNode.HeadNode; i.getNext() != null; i = i.getNext())
            {
                table.Add(counter.ToString(), i);
                counter++;
            }
            return table;
        }
    }
}
