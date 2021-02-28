using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRovers
{
    class Rover
    {
        public int X { get; set; }
        public int Y { get; set; }
        public string DIR { get; set; }
        public Rover(int x_pos = 0, int y_pos = 0, string direction = "N")
        {
            X = x_pos;
            Y = y_pos;
            DIR = direction;
        }
        public string Position()
        {
            string position = ("Current Rover location: " + X + " " + Y + " " + DIR);
            return position;
        }
        public void MoveForward()
        {
            if (DIR == "N") { Y += 1; }
            else if (DIR == "E") { X += 1; }
            else if (DIR == "S") { Y -= 1; }
            else if (DIR == "W") { X -= 1; }
        }
        public void TurnLeft()
        {
            if (DIR == "N") { DIR = "W"; }
            else if (DIR == "E") { DIR = "N"; }
            else if (DIR == "S") { DIR = "E"; }
            else if (DIR == "W") { DIR = "S"; }
        }
        public void TurnRight()
        {
            if (DIR == "N") { DIR = "E"; }
            else if (DIR == "E") { DIR = "S"; }
            else if (DIR == "S") { DIR = "W"; }
            else if (DIR == "W") { DIR = "N"; }
        }
    }
}
