using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRovers
{
    class Rover
    {
        // Rover values X, Y, and DIR.
        public int X { get; set; }
        public int Y { get; set; }
        public string DIR { get; set; }

        // Rover function to initialize a new Rover when Rover is called.
        public Rover(int x_pos = 0, int y_pos = 0, string direction = "N")
        {
            X = x_pos;
            Y = y_pos;
            DIR = direction;
        }

        // Function to return the rover's current position.
        public string Position()
        {
            string position = ("Current Rover location: " + X + " " + Y + " " + DIR);
            return position;
        }

        // Function to move the rover forward and updating the correct axis value based on the direction it's facing.
        public void MoveForward()
        {
            if (DIR == "N") { Y += 1; }
            else if (DIR == "E") { X += 1; }
            else if (DIR == "S") { Y -= 1; }
            else if (DIR == "W") { X -= 1; }
        }

        // Function to command the rover to turn left, updating DIR based on the current direction.
        public void TurnLeft()
        {
            if (DIR == "N") { DIR = "W"; }
            else if (DIR == "E") { DIR = "N"; }
            else if (DIR == "S") { DIR = "E"; }
            else if (DIR == "W") { DIR = "S"; }
        }

        // Function to command the rover to turn right, updating DIR based on the current direction.
        public void TurnRight()
        {
            if (DIR == "N") { DIR = "E"; }
            else if (DIR == "E") { DIR = "S"; }
            else if (DIR == "S") { DIR = "W"; }
            else if (DIR == "W") { DIR = "N"; }
        }
    }
}
