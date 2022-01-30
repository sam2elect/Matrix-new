using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Matrix_new
{
    
    public partial class matrix : Form
    {
        public int m_width;
        public int m_height;
        public int m_rows;
        public int m_columns;
        public int m_Xoffset;
        public int m_Yoffset;
        public int m_counter = 2;
        public int m_size = 8;

    
        public const int DEFAULT_X_OFFSET = 60;
        public const int DEFAULT_Y_OFFSET = 100;
        public const int DEFAULT_NO_ROWS = 2;
        public const int DEFAULT_NO_COLUMNS = 2;
        public const int DEFAULT__WIDTH = 60;
        public const int DEFAULT_HEIGHT = 60;
        public matrix()
        {
            InitializeComponent();
            Intialize();
            
        }
       
        private void Start_Click(object sender, EventArgs e)
        {
            Matrix_new = new Thread(ThreadCounter);
            Matrix_new.Start();
        }

        private void gridSizeToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            m_size = 3;
            this.Refresh();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            m_size = 4;
            this.Refresh();
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            m_size = 5;
            this.Refresh();
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            m_size = 6;
            this.Refresh();
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            m_size = 7;
            this.Refresh();
        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            m_size = 8;
            this.Refresh();
        }

        private void OnLoad(object sender, EventArgs e)
        {
            DrawGrid();
        }
        public void Intialize()
        {
            m_rows = DEFAULT_NO_ROWS;
            m_columns = DEFAULT_NO_COLUMNS;
            m_width = DEFAULT__WIDTH;
            m_height = DEFAULT_HEIGHT;
            m_Xoffset = DEFAULT_X_OFFSET;
            m_Yoffset = DEFAULT_Y_OFFSET;
        }
        private void DrawGrid()
        {
            Graphics boardLayout = this.CreateGraphics();
            Pen layoutPen = new Pen(Color.Red);
            Pen layoutPen1 = new Pen(Color.Black);
            layoutPen.Width = 6;
            layoutPen1.Width = 6;

            // boardLayout.DrawLine(layoutPen, 0, 0, 100, 0);
            int X = DEFAULT_X_OFFSET;
            int Y = DEFAULT_Y_OFFSET;

            for (int i = 0; i <= m_counter; i++)
            {
                boardLayout.DrawLine(layoutPen1, X, Y, X + this.m_width * this.m_counter, Y);
                Y = Y + this.m_height;
            }
            X = DEFAULT_X_OFFSET;
            Y = DEFAULT_Y_OFFSET;

            for (int j = 0; j <= m_counter; j++)
            {
                boardLayout.DrawLine(layoutPen, X, Y, X, Y + this.m_height * this.m_counter);
                X = X + this.m_width;
            }
        }
        public void ThreadCounter()
        {
            try
            {
                while (true)
                {
                    m_counter++;
                    if (m_counter > m_size)
                    {
                        m_counter=2; 
                    }
                    Invalidate();
                    Thread.Sleep(500);
                    if (_pause)
                    {
                        lock (_threadLock)
                        {
                            Monitor.Wait(_threadLock);
                        }
                    }
                }
                
            }
            catch (Exception ex)
            { }           
        }

        private bool _pause = false;
        private object _threadLock = new object();

        private void button2_Click(object sender, EventArgs e)
        {
            _pause = true;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            _pause = false;
            lock (_threadLock)
            {
                Monitor.Pulse(_threadLock);
            }
        }
    }
}
