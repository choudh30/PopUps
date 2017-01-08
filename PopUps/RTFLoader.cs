/**
 * A class to handle RTF loading 
 */

using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PopUps
{

    // A class to handle RTF loading
    public class RTFLoader
    {

        const string RTFSourceDirectory = "../../../TestRTFs/";
        // String array for our rtf files
        string[] mRTFFiles;
        // Counter to keep track of the current rtf file.
        int mCurrentFileCounter;

        // Constructor
        public RTFLoader()
        {

            // Get the file names from a given directory.
            mRTFFiles = Directory.GetFiles("../../../TestRTFs/");
            mCurrentFileCounter = 0;

        }

        /** Get the first RTF File 
         * (That'll be the Orginization Landing popup)
         * returns the filename of that file
         */
        public string GetInitialFile()
        {
            return mRTFFiles[0];
        }

        /** return the next document to be viewed */
        public string NextDocument()
        {
            mCurrentFileCounter = (mCurrentFileCounter + 1) % mRTFFiles.Length;
            return mRTFFiles[mCurrentFileCounter];
        }

        // Return the previously viewed document
        public string PreviousDocument()
        {
            /**
             * Decrement document counter by one. 
             * If the counter is at zero we cycle back 
             * to the very end document. 
             */
            if (mCurrentFileCounter > 0)
                mCurrentFileCounter = (mCurrentFileCounter - 1) % mRTFFiles.Length;
            else
                mCurrentFileCounter = mRTFFiles.Length - 1;
            
            return mRTFFiles[mCurrentFileCounter];
        }

        /** Get the list of rtf files */
        public string[] GetRTFFiles()
        {
            return mRTFFiles;
        }

    }
}
