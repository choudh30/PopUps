using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace PopUps
{
    public partial class Form1 : Form
    {

        // String array for our rtf files
        string[] mRTFFiles;
        // Counter to keep track of the current rtf file.
        int mCurrentFileCounter;
        // Keep track of time passed by the counter event.
        double mTimeTracker;
        // Time threshold for switching document viewed.
        const double mTimeThreshold = 3.0;

        public Form1()
        {

            InitializeComponent();
            // Get the file names from a given directory.
            mRTFFiles = Directory.GetFiles("../../../TestRTFs/");
            //Start our timer
            timer1.Start();

            mCurrentFileCounter = 0;
            mTimeTracker = 0.0;
 
            // Load the first document
            richTextBox1.LoadFile(mRTFFiles[mCurrentFileCounter]);
        }

        /** Open button click event handler.
         */
        private void openRTF_Click_1(object sender, EventArgs e)
        {

            // Our open file dialog
            OpenFileDialog ofd = new OpenFileDialog() { Filter = "Rich Text Format|*.rtf", ValidateNames = true, Multiselect = false };
            {
                // If the diaglog exited successfully load the file into our rtf viewer.
                if (ofd.ShowDialog() == DialogResult.OK)
                    richTextBox1.LoadFile(ofd.FileName);
            }

        }

        /** A timer event that is called every .1 seconds */
        private void timer1_Tick(object sender, EventArgs e)
        {

            mTimeTracker += .1;
            if (mTimeTracker >= mTimeThreshold)
            {
                CycleViewedDocument();
                mTimeTracker = 0.0;
            }

        }

        /** Cycle the document that is to be viewed based on the pool of documents in mRTFFiles array */
        private void CycleViewedDocument()
        {
            mCurrentFileCounter = (mCurrentFileCounter + 1) % mRTFFiles.Length;
            // Clear the text box of the last file loaded
            richTextBox1.Clear();
            // Load the next rtf file 
            richTextBox1.LoadFile(mRTFFiles[mCurrentFileCounter]);
        }
    }

}
