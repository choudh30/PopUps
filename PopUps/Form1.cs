using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PopUps
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void openRTF_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog() { Filter = "Rich Text Format|*.rtf", ValidateNames = true, Multiselect = false };
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                    richTextBox1.LoadFile(ofd.FileName);
            }
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
    }

}
