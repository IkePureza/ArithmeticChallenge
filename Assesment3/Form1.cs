////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Form1.cs
//
// summary:	Implements the form 1 class
////////////////////////////////////////////////////////////////////////////////////////////////////

/*
 *      Student Number: 450402607
 *      Name:           Henrique Pureza
 *      Date:           16/09/2018
 *      Purpose:        Instructor form
 *      Known Bugs:     nill
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assesment3
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A form 1. </summary>
    ///
    /// <remarks>   Pureza, 9/16/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public partial class Form1 : Form
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Callback, called when the set text. </summary>
        ///
        /// <remarks>   Pureza, 9/16/2018. </remarks>
        ///
        /// <param name="text"> The text. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        delegate void SetTextCallback(string text);
        //for listening for connection
        /// <summary>   The listener. </summary>
        TcpListener listener;
        //for client
        /// <summary>   The client. </summary>
        TcpClient client;
        //for the stream of data passed between server and client
        /// <summary>   The ns. </summary>
        NetworkStream ns;
        //for the thread
        /// <summary>   A Thread to process. </summary>
        Thread t = null;
        //for the double link list
        /// <summary>   The list of nodes. </summary>
        NodeList listOfNodes = new NodeList();
        //for the binary tree
        /// <summary>   my tree. </summary>
        BinaryTree myTree = new BinaryTree();
        /// <summary>   The equation. </summary>
        Question equation;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Pureza, 9/16/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public Form1()
        {
            InitializeComponent();
            comboOperator.Items.Add("+");
            comboOperator.Items.Add("-");
            comboOperator.Items.Add("x");
            comboOperator.Items.Add("/");
            listener = new TcpListener(8888);
            listener.Start();
            client = listener.AcceptTcpClient();
            ns = client.GetStream();
            t = new Thread(DoWork);
            t.Start();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Text changed. </summary>
        ///
        /// <remarks>   Pureza, 9/16/2018. </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void textChanged(object sender, EventArgs e)
        {
            //call method
            autoAnswer();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Automatic answer. </summary>
        ///
        /// <remarks>   Pureza, 9/16/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void autoAnswer()
        {
            int first;
            int second;
            if (comboOperator.SelectedIndex == 0)
            {
                int.TryParse(txtInputFNumber.Text, out first);
                int.TryParse(textInputSNumber.Text, out second);
                textInputAnswer.Text = (first + second).ToString();
            }
            else if (comboOperator.SelectedIndex == 1)
            {
                int.TryParse(txtInputFNumber.Text, out first);
                int.TryParse(textInputSNumber.Text, out second);
                textInputAnswer.Text = (first - second).ToString();
            }
            else if (comboOperator.SelectedIndex == 2)
            {
                int.TryParse(txtInputFNumber.Text, out first);
                int.TryParse(textInputSNumber.Text, out second);
                textInputAnswer.Text = (first * second).ToString();
            }
            else if (comboOperator.SelectedIndex == 3)
            {
                if (textInputSNumber.Text == "0" || textInputSNumber.Text == "")
                {
                    textInputAnswer.Text = "0";
                }
                else
                {
                    int.TryParse(txtInputFNumber.Text, out first);
                    int.TryParse(textInputSNumber.Text, out second);
                    textInputAnswer.Text = (first / second).ToString();
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Saves the equation. </summary>
        ///
        /// <remarks>   Pureza, 9/16/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void saveEquation()
        {
            string firstNum = txtInputFNumber.Text;
            string operation = comboOperator.Text;
            string secondNum = textInputSNumber.Text;
            string equals = "=";
            string Answer = textInputAnswer.Text;
            DataGridViewRow row = (DataGridViewRow)dataGridQuestions.RowTemplate.Clone();
            row.CreateCells(dataGridQuestions, firstNum, operation, secondNum, equals, Answer);
            dataGridQuestions.Rows.Add(row);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Event handler. Called by btnSend for click events. </summary>
        ///
        /// <remarks>   Pureza, 9/16/2018. </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void btnSend_Click(object sender, EventArgs e)
        {
            int first = Convert.ToInt32(txtInputFNumber.Text);
            string operation = comboOperator.Text;
            int second = Convert.ToInt32(textInputSNumber.Text);
            if (second == 0)
            {
                MessageBox.Show("Cannot divide by zero");
                return;
            }
            string equals = "=";
            byte[] byteTime = Encoding.ASCII.GetBytes(first + " " + operation + " " + second + " " + equals);
            ns.Write(byteTime, 0, byteTime.Length);
            btnSend.Enabled = false;
            saveEquation();

        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Executes the work operation. </summary>
        ///
        /// <remarks>   Pureza, 9/16/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void DoWork()
        {
            byte[] bytes = new byte[1024];
            try
            {
                while (true)
                {
                    int bytesRead = ns.Read(bytes, 0, bytes.Length);
                    this.SetText(Encoding.ASCII.GetString(bytes, 0, bytesRead));
                }
            }
            catch (Exception)
            {
                return;
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Sets a text. </summary>
        ///
        /// <remarks>   Pureza, 9/16/2018. </remarks>
        ///
        /// <param name="text"> The text. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void SetText(string text)
        {
            //InvokeRequired required compares the thread ID of the
            //calling thread to the thread ID of the creating thread.
            //if these thread are different, it returns true.
            if (this.richLinkList.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                //if the text recieved is incorrect add it to the link list
                if (text != textInputAnswer.Text)
                {
                    int num;
                    bool answer = int.TryParse(textInputAnswer.Text, out num);
                    listOfNodes.addAtFrontOfNodeList(new Node(num));
                    richLinkList.Text = listOfNodes.printLinkList(listOfNodes);
                    listOfNodes.linkListTable(listOfNodes);
                }
                equation = new Question(Convert.ToInt32(txtInputFNumber.Text), Convert.ToInt32(textInputSNumber.Text), comboOperator.Text, Convert.ToInt32(textInputAnswer.Text));
                binaryTree();
                btnSend.Enabled = true;
                clearEquation();
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Binary tree. </summary>
        ///
        /// <remarks>   Pureza, 9/16/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void binaryTree()
        {
            //if the tree is null
            if (myTree.top == null)
            {
                //create new node equation at the top of the tree
                myTree.top = new BinaryNode(equation);
            }
            else
            {
                //otherwise add another equation to the tree
                myTree.Add(equation);
            }
            richBinaryTree.Clear();
            richBinaryTree.Text = "IN-ORDER: ";
            richBinaryTree.Text += myTree.printInOrder(myTree);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Clears the equation. </summary>
        ///
        /// <remarks>   Pureza, 9/16/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void clearEquation()
        {
            txtInputFNumber.Text = null;
            comboOperator.Text = null;
            textInputSNumber.Text = null;
            textInputAnswer.Text = null;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Event handler. Called by buttonSearch for click events. </summary>
        ///
        /// <remarks>   Pureza, 9/16/2018. </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            try
            {
                int searchValue = Convert.ToInt32(textSearch.Text);
                int? search = listOfNodes.binarySearch(searchValue);


                if (search == null)
                {
                    textSearch.Text = "Not Found";
                }
                else
                {
                    textSearch.Text = "Found!";
                }
            }
            catch (Exception)
            {

                MessageBox.Show("PLease input a integer");
            }
              
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Event handler. Called by dataGridQuestions for selection changed events.
        /// </summary>
        ///
        /// <remarks>   Pureza, 9/16/2018. </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void dataGridQuestions_SelectionChanged(object sender, EventArgs e)
        {
            dataGridQuestions.ClearSelection();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Event handler. Called by button1 for click events. </summary>
        ///
        /// <remarks>   Pureza, 9/16/2018. </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridQuestions.Sort(dataGridQuestions.Columns[4], ListSortDirection.Ascending);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Event handler. Called by buttonSort2 for click events. </summary>
        ///
        /// <remarks>   Pureza, 9/16/2018. </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void buttonSort2_Click(object sender, EventArgs e)
        {
            dataGridQuestions.Sort(dataGridQuestions.Columns[4], ListSortDirection.Descending);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Event handler. Called by btnSort3 for click events. </summary>
        ///
        /// <remarks>   Pureza, 9/16/2018. </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void btnSort3_Click(object sender, EventArgs e)
        {
            dataGridQuestions.Sort(dataGridQuestions.Columns[1], ListSortDirection.Ascending);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Event handler. Called by btnMinimize for click events. </summary>
        ///
        /// <remarks>   Pureza, 9/16/2018. </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Event handler. Called by btnExit for click events. </summary>
        ///
        /// <remarks>   Pureza, 9/16/2018. </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
            t.Abort();
            client.Close();
        }
        /// <summary>   The tog move. </summary>
        int TogMove;
        /// <summary>   The value x coordinate. </summary>
        int MValX;
        /// <summary>   The value y coordinate. </summary>
        int MValY;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Event handler. Called by panelTop for mouse down events. </summary>
        ///
        /// <remarks>   Pureza, 9/16/2018. </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Mouse event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void panelTop_MouseDown(object sender, MouseEventArgs e)
        {
            TogMove = 1;
            MValX = e.X;
            MValY = e.Y;

        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Event handler. Called by panelTop for mouse up events. </summary>
        ///
        /// <remarks>   Pureza, 9/16/2018. </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Mouse event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void panelTop_MouseUp(object sender, MouseEventArgs e)
        {
            TogMove = 0;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Event handler. Called by panelTop for mouse move events. </summary>
        ///
        /// <remarks>   Pureza, 9/16/2018. </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Mouse event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void panelTop_MouseMove(object sender, MouseEventArgs e)
        {
            if (TogMove == 1)
            {
                this.SetDesktopLocation(MousePosition.X - MValX, MousePosition.Y - MValY);
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Event handler. Called by Form1 for load events. </summary>
        ///
        /// <remarks>   Pureza, 9/16/2018. </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void Form1_Load(object sender, EventArgs e)
        {
         

        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Event handler. Called by btnDisplayPre for click events. </summary>
        ///
        /// <remarks>   Pureza, 9/16/2018. </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void btnDisplayPre_Click(object sender, EventArgs e)
        {
            richBinaryTree.Clear();
            richBinaryTree.Text = "PRE-ORDER: ";
            richBinaryTree.Text += myTree.printPreOrder(tree: myTree);

        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Event handler. Called by btnSavePre for click events. </summary>
        ///
        /// <remarks>   Pureza, 9/16/2018. </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void btnSavePre_Click(object sender, EventArgs e)
        {
            string preOrderPath = "PreOrder.txt";

            using (StreamWriter sw = File.AppendText(preOrderPath))
            {
                sw.WriteLine("PRE-ORDER: " + myTree.printPreOrder(myTree));
                sw.Close();
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Event handler. Called by btnDisplayIn for click events. </summary>
        ///
        /// <remarks>   Pureza, 9/16/2018. </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void btnDisplayIn_Click(object sender, EventArgs e)
        {
            richBinaryTree.Clear();
            richBinaryTree.Text = "IN-ORDER: ";
            richBinaryTree.Text += myTree.printInOrder(tree: myTree);

        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Event handler. Called by btnSaveIn for click events. </summary>
        ///
        /// <remarks>   Pureza, 9/16/2018. </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void btnSaveIn_Click(object sender, EventArgs e)
        {
            string inOrderPath = "InOrder.txt";

            using (StreamWriter sw = File.AppendText(inOrderPath))
            {
                sw.WriteLine("IN-ORDER: " + myTree.printPreOrder(myTree));
                sw.Close();
            }

        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Event handler. Called by btnDisplayPost for click events. </summary>
        ///
        /// <remarks>   Pureza, 9/16/2018. </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void btnDisplayPost_Click(object sender, EventArgs e)
        {
            richBinaryTree.Clear();
            richBinaryTree.Text = "POST-ORDER: ";
            richBinaryTree.Text += myTree.printPostOrder(tree: myTree);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Event handler. Called by btnSavePost for click events. </summary>
        ///
        /// <remarks>   Pureza, 9/16/2018. </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void btnSavePost_Click(object sender, EventArgs e)
        {
            string PostOrderPath = "PostOrder.txt";

            using (StreamWriter sw = File.AppendText(PostOrderPath))
            {
                sw.WriteLine("POST-ORDER: " + myTree.printPreOrder(myTree));
                sw.Close();
            }

        }

        
    }
}
