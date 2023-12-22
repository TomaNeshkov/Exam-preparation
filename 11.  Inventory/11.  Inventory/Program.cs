using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        List<string> items = Console.ReadLine().Split(", ").ToList();

        string[] command = Console.ReadLine().Split(" - ");
        string[] temp = new string[2];

        while (command[0] != "Craft!")
        {
            switch (command[0])
            {
                case "Collect":
                    if (!items.Contains(command[1]))
                    {
                        items.Add(command[1]);
                    }
                    break;
                case "Drop":
                    items.Remove(command[1]);
                    break;
                case "Combine Items":
                    temp = command[1].Split(":");
                    if (items.Contains(temp[0]))
                    {
                        items.Insert(items.FindIndex(x => x == temp[0]) + 1, temp[1]);
                    }
                    break;
                case "Renew":
                    if (items.Contains(command[1]))
                    {
                        items.Remove(command[1]);
                        items.Add(command[1]);
                    }
                    break;
            }

            command = Console.ReadLine().Split(" - ");
        }

        Console.WriteLine(string.Join(", ", items));
    }
}
