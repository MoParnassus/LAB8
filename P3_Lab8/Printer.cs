using System;
using System.Collections.Generic;
using System.Linq;

namespace P3Lab7
{
    public class Printer
    {
        private List<Ink> Inks;
        private int PaperCount;
        public event EventHandler OutOfPaperEvent;
        public event EventHandler<OutOfInkEventArgs> OutOfInkEvent;      
        public event EventHandler PrintCompleteEvent;
        public Printer(int pages, List<Ink> inks)
        {
            PaperCount = pages;
            Inks = inks;
            OutOfPaperEvent += OutOfPaperEventHandler;
            OutOfInkEvent += OutOfInkEventHandler;
            PrintCompleteEvent += PrintCompleteEventHandler;
        }
        public void Print(int pages)
        {
            var InkNeededForPage = new Random();
            Console.WriteLine("Printing: ");
          
            if (PaperCount-pages < 0)
            {
                OutOfPaperEvent.Invoke(this, EventArgs.Empty);
                return ;
            }
            PaperCount -= pages;
            Console.WriteLine("");
            for (int pageNo = 0; pageNo < pages; pageNo++)
            {
                foreach (var ink in Inks)
                {
                    ink.InkLeft -= Math.Min(ink.InkLeft, InkNeededForPage.Next(0, 5));
                    if (ink.InkLeft == 0)
                    {
                        OutOfInkEvent.Invoke(this,
                            new OutOfInkEventArgs(ink.Colour, pageNo));
                        return;
                    }
                }
            }
            PrintCompleteEvent.Invoke(this, EventArgs.Empty);                       
        }
        public void BuyNewInk()
        {
            Inks = Ink.EconomyInkSet();
        }
        private void OutOfPaperEventHandler(object sender, EventArgs args)
        {
            Console.WriteLine(
                $"{DateTime.Now.ToShortDateString()} " +
                $"{DateTime.Now.ToShortTimeString()} |[Printerlog]: Out of paper");
        }
        private void OutOfInkEventHandler(object sender, OutOfInkEventArgs args)
        {
            Console.WriteLine(
               $"{DateTime.Now.ToShortDateString()} " +
               $"{DateTime.Now.ToShortTimeString()} " + 
               "|[Printerlog]: Out of {0} ink (printing stopped at page: {1})",
               args.Colour,args.PageNumber);
        }       
        private void PrintCompleteEventHandler(object sender, EventArgs args)
        {
            Console.WriteLine(
                $"{DateTime.Now.ToShortDateString()} " +
                $"{DateTime.Now.ToShortTimeString()} " + 
                "|[Printerlog]: Printing task completed");
        }
    }    
}
