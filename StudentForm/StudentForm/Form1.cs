////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Form1.cs
//
// summary:	Implements the form 1 class
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
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentForm
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A form 1. </summary>
    ///
    /// <remarks>   Pureza, 9/16/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public partial class Form1 : Form
    {
        /// <summary>   The port number. </summary>
        private const int portNum = 8888;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Callback, called when the set text. </summary>
        ///
        /// <remarks>   Pureza, 9/16/2018. </remarks>
        ///
        /// <param name="text"> The text. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        delegate void SetTextCallback(string text);
        /// <summary>   The client. </summary>
        TcpClient client;
        /// <summary>   The ns. </summary>
        NetworkStream ns;
        /// <summary>   A Thread to process. </summary>
        Thread t = null;
        /// <summary>   The answer. </summary>
        int answer = 0;
        /// <summary>   Name of the host. </summary>
        private const string hostName = "localhost";

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Pureza, 9/16/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public Form1()
        {
            InitializeComponent();
            client = new TcpClient(hostName, portNum);
            ns = client.GetStream();
            string s = "";
            byte[] byteTime = Encoding.ASCII.GetBytes(s);
            ns.Write(byteTime, 0, byteTime.Length);
            t = new Thread(DoWork);
            t.Start();
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
            this.Close();
            t.Abort();
            client.Close();
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
        /// <summary>   Event handler. Called by btnSubmit for click events. </summary>
        ///
        /// <remarks>   Pureza, 9/16/2018. </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            string s = textAnswer.Text;
            if (s.ToString() == null || s.ToString() == "")
            {
                MessageBox.Show("Please enter an answer!");
                return;
            }
            if (s.ToString() != answer.ToString())
            {
                MessageBox.Show("Incorrect");
            }
            else
            {
                MessageBox.Show("Correct");
            }
            byte[] byteTime = Encoding.ASCII.GetBytes(s);
            ns.Write(byteTime, 0, byteTime.Length);
            textQuestion.Text = null;
            textAnswer.Text = null;

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
            string[] pieces;
            if (this.textQuestion.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText);
                this.Invoke(d, new object[] { text });
                if (text.Contains("+"))
                {
                    answer = 0;
                    pieces = text.Split(' ');
                    answer = Convert.ToInt32(pieces[0]) + Convert.ToInt32(pieces[2]);
                }
                if (text.Contains("-"))
                {
                    answer = 0;
                    pieces = text.Split(' ');
                    answer = Convert.ToInt32(pieces[0]) - Convert.ToInt32(pieces[2]);
                }
                if (text.Contains("x"))
                {
                    answer = 0;
                    pieces = text.Split(' ');
                    answer = Convert.ToInt32(pieces[0]) * Convert.ToInt32(pieces[2]);
                }
                if (text.Contains("/"))
                {
                    answer = 0;
                    pieces = text.Split(' ');
                    answer = Convert.ToInt32(pieces[0]) / Convert.ToInt32(pieces[2]);
                }
            }
            else
            {
                this.textQuestion.Text = this.textQuestion.Text + text;
            }
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


    }
}
