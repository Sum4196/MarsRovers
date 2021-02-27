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
                    int bounds_x = Convert.ToInt32(boundsArray[0]);
                    int bounds_y = Convert.ToInt32(boundsArray[1]);
                    Console.WriteLine("Bounds have been set to: " + bounds_x + " " + bounds_y);
                    done = true;
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
}
