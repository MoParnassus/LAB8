using System;
using System.Collections.Generic;
using System.Text;

namespace P3_Lab8
{
    public class OutOfPaperEventArgs : EventArgs
    {
        public OutOfPaperEventArgs(int pageNumber)
        {
            this.pageNumber = pageNumber;
        }

        public int pageNumber { get; set; }
    }
}
