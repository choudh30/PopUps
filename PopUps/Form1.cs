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

        // The class to handle file selection.
        RTFLoader mRTFLoader;

        public Form1()
        {

            InitializeComponent();
            mRTFLoader = new RTFLoader();

            // Load the first document
            richTextBox1.LoadFile(mRTFLoader.GetInitialFile());
            // Populate the list on startup.
            PopulateListView(listView1, "../../../TestRTFs/", "*.rtf");

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
//      private void timer1_Tick(object sender, EventArgs e)
//      {

//          mTimeTracker += .1;
//          // When our counter reaches the threshold, cycle the document.
//          if (mTimeTracker >= mTimeThreshold)
//          {
//              richTextBox1.Clear();
//              richTextBox1.LoadFile(mRTFLoader.NextDocument());
//              mTimeTracker = 0.0;
//          }

//      }

        /** Called when the previous button is clicked */
        private void PrevButton_Click(object sender, EventArgs e)
        {
            richTextBox1.LoadFile(mRTFLoader.PreviousDocument());
        }

        /** Called when the next button is clicked */
        private void NextButton_Click(object sender, EventArgs e)
        {
            richTextBox1.LoadFile(mRTFLoader.NextDocument());
        }

        /** Used by refresh button to populate the listView with the name of the file and its path*/
        private void PopulateListView(ListView lvi, string Folder, string FileType)
        {
            DirectoryInfo dinfo = new DirectoryInfo(Folder);
            FileInfo[] Files = dinfo.GetFiles(FileType);
            foreach (FileInfo file in Files)
            {
                ListViewItem item = new ListViewItem(file.Name);
                item.SubItems.Add(file.FullName);
                lvi.Items.Add(item);
            }
        }

        /** PopulateListView is called when refresh button is clicked*/
        private void RefreshButton_Click(object sender, EventArgs e)
        {
            PopulateListView(listView1, "../../../TestRTFs/", "*.rtf");
        }

        /** Button that will load the selected item within listView into the RTFViewer */
        private void LoadButton_Click(object sender, EventArgs e)
        {
            richTextBox1.LoadFile(listView1.SelectedItems[0].SubItems[1].Text);
        }
    }

}
