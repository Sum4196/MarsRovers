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
        /// Mars Rovers application that allows for control of mars rovers using a movement string based on the rovers' position.
        /// </summary>

        [STAThread]
        static void Main()
        {
            // Shows text so the user knows how to exit the program properly.
            Console.WriteLine("To exit the program at any time, simply enter 'exit'.\n");

            // Gets input from the user for the rover boundary and creates a string array from the output.
            string[] boundsArray = Input.Bounds();

            // Converts the values in the boundsArray to integers for the x and y coordinates for the NorthEast boundary point.
            int bx = Convert.ToInt32(boundsArray[0]);
            int by = Convert.ToInt32(boundsArray[1]);

            // Main loop to keep input going until otherwise specified by the user.
            while (true)
            {
                // Gets the input from the user given the boundary points to ensure the position is within the boundary.
                string pos = Input.Position(bx, by);

                // String list to store the x, y, and direction information of the rover.
                List<string> posList = new List<string>();
                for (int i = 0; i < pos.Length; i++) { posList.Add(pos[i].ToString()); }

                // Creates new instance of the Rover class given the position information to be set.
                Rover rover = new Rover(int.Parse(posList[0]), int.Parse(posList[1]), posList[2]);

                // Shows user the current rover position.
                Console.WriteLine(rover.Position());

                // Gets user input to command the current rover to move.
                string movement = Input.Movement();

                // Loop to iterate through the movement command string and execute those commands to the current rover.
                for (int i = 0; i < movement.Length; i++)
                {
                    if (movement[i].ToString() == "M")
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
                    else if (movement[i].ToString() == "L") { rover.TurnLeft(); }
                    else if (movement[i].ToString() == "R") { rover.TurnRight(); }
                }

                // Shows the user the new rover position after the movement commands.
                Console.WriteLine(rover.Position());
            }

        }

        // Exit function to properly shut down the program.
        public static void Exit()
        {
            Console.WriteLine("The program will now close in 3 seconds...");
            Thread.Sleep(3000);
            Environment.Exit(0);
        }
    }
}
