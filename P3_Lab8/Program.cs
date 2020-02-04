using System;

namespace P3Lab7
{
    class Program
    {
        static void Main(string[] args)
        {            
            var printer = new Printer(100, Ink.StandardInkSet());

            printer.OutOfPaperEvent += OutOfPaperEventHandler;
            printer.OutOfInkEvent += OutOfInkEventHandler;
            printer.PrintCompleteEvent += PrintCompleteEventHAndler;

            printer.Print(30);
            printer.Print(20);
            printer.Print(40);
            printer.BuyNewInk(); 
            printer.Print(30);
        }      
        static void OutOfPaperEventHandler(object sender, EventArgs args)
        {
            Console.WriteLine("Get me new paper!\n");
            Console.WriteLine("Printing not started.\n");
        }
        static void OutOfInkEventHandler(
            object sender, EventArgs args)
        {
            Console.WriteLine("I've got no ink!\n");
            Console.WriteLine("Printing not completed.\n");
        }  
        static void PrintCompleteEventHAndler(object sender, EventArgs args)
        {
            Console.WriteLine("Printing completed successfully.");
        }
    }
}
