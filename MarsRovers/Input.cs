using System;
using System.Collections.Generic;

public class Input
{
    public static string[] Bounds()
    {
        bool done = false;
        string bounds = "";
        string[] boundsArray = bounds.Split();

        while (done == false)
        {
            Console.Write("Please enter NorthEast corner coordinates: ");
            bounds = Console.ReadLine();
            boundsArray = bounds.Split();

            if (bounds == "exit") {
                MarsRovers.Program.Exit();
            }
            else if (bounds.Split().Length > 2 || bounds.Split().Length < 2)
            {
                Console.WriteLine("Please enter TWO integers for NorthEast corner coordinates separated by spaces!");
            }
            else
            {
                try
                {
                    boundsArray = bounds.Split();
                    if (Convert.ToInt32(boundsArray[0]) > 9 || Convert.ToInt32(boundsArray[1]) > 9 || Convert.ToInt32(boundsArray[0]) < 0 || Convert.ToInt32(boundsArray[1]) < 0)
                    {
                        Console.WriteLine("Please make sure you enter integers 0-9.");
                        done = false;
                    }
                    else
                    {
                        Console.WriteLine("Bounds have been set to: " + boundsArray[0] + " " + boundsArray[1]);
                        done = true;
                    }
                }
                catch(FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("Please make sure you're entering integers.");
                }

            }

        }

        return boundsArray;

    }

    public static string Movement()
    {
        bool done = false;
        string movement = "";

        while (done == false)
        {
            Console.Write("Please enter movement commands: ");
            movement = Console.ReadLine();
            int trigger = 0;

            if(movement == "exit") { MarsRovers.Program.Exit(); }

            for (int i = 0; i < movement.Length; i++)
            {
                if (!(movement[i].ToString() == "L" || movement[i].ToString() == "R" || movement[i].ToString() == "M") && movement.Length > 0)
                {
                    Console.WriteLine("Please make sure you only use 'L','R', or 'M' for your command.");
                    trigger += 1;
                    Movement();
                }
            }

            if (trigger == 0) { done = true; }

        }

        return movement;
    }

    public static string Position(int bx, int by)
    {
        bool done = false;
        string pos = "";

        while (done == false)
        {
            Console.Write("Please enter the rover's position: ");
            pos = Console.ReadLine().Replace(" ", string.Empty);
            int trigger = 0;
            int val0 = 0;
            int val1 = 0;

            List<string> posList = new List<string>();
            for (int i = 0; i < pos.Length; i++) { posList.Add(pos[i].ToString()); }

            // Allows user to exit program when entering position.
            if (pos == "exit") { MarsRovers.Program.Exit(); }

            // Makes sure position is inside set bounds.
            if (Convert.ToInt32(posList[0]) > bx || Convert.ToInt32(posList[1]) > by)
            {
                Console.WriteLine("Values entered are larger than bounds. Please enter a value within 0-" + (bx).ToString() + " for x value and 0-" + (by).ToString() + " for y value.");
                return Position(bx, by);
            }

            for (int i = 0; i < pos.Length; i++)
            {
                if (!(int.TryParse(posList[0], out val0) == true && int.TryParse(posList[1], out val1) == true && pos.Length == 3 && (posList[2].ToString() == "N" || posList[2].ToString() == "E" || posList[2].ToString() == "S" || posList[2].ToString() == "W")))
                {
                    Console.WriteLine("Please make sure you only use integers 0-9 and a direction (N,E,S,W) for rover location.");
                    trigger += 1;
                    return Position(bx, by);
                }
            }

            if (trigger == 0) { done = true; }
        }

        return pos;
    }

}
