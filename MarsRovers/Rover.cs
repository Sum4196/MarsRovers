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
        public Rover(int x_pos=0, int y_pos=0, string direction="N")
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
            if (DIR == "N") { X += 1; }
            if (DIR == "E") { Y += 1; }
            if (DIR == "S") { X -= 1; }
            if (DIR == "W") { Y -= 1; }
        }
        public void TurnLeft()
        {
            if (DIR == "N") { DIR = "W"; }
            if (DIR == "E") { DIR = "N"; }
            if (DIR == "S") { DIR = "E"; }
            if (DIR == "W") { DIR = "S"; }
        }
        public void TurnRight()
        {
            if (DIR == "N") { DIR = "E"; }
            if (DIR == "E") { DIR = "S"; }
            if (DIR == "S") { DIR = "W"; }
            if (DIR == "W") { DIR = "N"; }
        }
    }
}
