using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using Simulator;

namespace SpreadsheetApp
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (args.Length != 4)
            {
                Console.WriteLine("Not funny... Please do as follow : Simulator <rows> <cols> <nThreads> <nOperations>");
                return;
            }

            int rows = int.Parse(args[0]);
            int cols = int.Parse(args[1]);
            int nThreads = int.Parse(args[2]);
            int nOperation = int.Parse(args[3]);

            //int rows = 5;
            //int cols = 5;
            //int nThreads = 5;
            //int nOperation = 10;

            try
            {
                Run_Simulator run = new Run_Simulator(rows, cols, nThreads, nOperation);
                Application.Run(new Form1());
            }
            catch (Exception e)
            {
                Console.WriteLine(" :-(");
            }
        }       
    }
}