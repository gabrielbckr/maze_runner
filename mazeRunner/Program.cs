using System;
using System.Threading;
using mazeRunner.Field;
using mazeRunner.Explorer;
using System.Collections;



namespace mazeRunner {
    public class Program {
        public static MazeField maze = new MazeField();
        public static Stack validPositions = new Stack();
        public static int numberOfThreads = 0;
        public static bool exitAllThreads = false;
        public static void Main()
        {
            string filename = 
                "C:/Code/training_csharp/maze/mazeRunner/mazeRunner/maze2.txt";
            Position initalPosition = maze.load(filename);
            maze.Display();


            /*       TRHEADING        */
            Thread firstStepThread = 
                new Thread(() => Walker.Walk(initalPosition));
            firstStepThread.Start();
            // firstStepThread.Join();
            while (!Program.exitAllThreads)
            {
                Thread.Sleep(10);
                maze.Display();
            }
            Console.WriteLine("vicory!!!!");//*/


            Console.Read(); Console.Read();
        }
    }
}   
