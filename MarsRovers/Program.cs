using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MarsRovers
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Rover rover = new Rover();

            Console.WriteLine("To exit the program at any time, simply enter 'exit'.\n");

            string[] boundsArray = Input.Bounds();
            int bx = Convert.ToInt32(boundsArray[0]);
            int by = Convert.ToInt32(boundsArray[1]);

            while (true)
            {
                Console.WriteLine(rover.Position());
                string movement = Input.Movement();

                for (int i=0; i < movement.Length; i++)
                {
                    if(movement[i].ToString() == "M")
                    {
                        rover.MoveForward();
                        if (rover.X > bx)
                        {
                            rover.X -= 1;
                            Console.WriteLine("Rover hit x-axis boundary, rover cannot go further this direction.");
                        }
                        if (rover.X < 0)
                        {
                            rover.X += 1;
                            Console.WriteLine("Rover hit x-axis boundary, rover cannot go further this direction.");
                        }
                        if (rover.Y > by)
                        {
                            rover.Y -= 1;
                            Console.WriteLine("Rover hit y-axis boundary, rover cannot go further this direction.");
                        }
                        if (rover.Y < 0)
                        {
                            rover.Y += 1;
                            Console.WriteLine("Rover hit y-axis boundary, rover cannot go further this direction.");
                        }
                    }
                    else if(movement[i].ToString() == "L") { rover.TurnLeft(); }
                    else if(movement[i].ToString() == "R") { rover.TurnRight(); }
                }
            }

        }
        public static void Exit()
        {
            Console.WriteLine("The program will now close in 3 seconds...");
            Thread.Sleep(3000);
            Environment.Exit(0);
        }
    }
}
