using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        const string AltitudeReached = "Bob has reached: Altitude {0}";
        const string AltitudeNotReached = "Bob did not reach: Altitude {0}";
        const string FailToReachTop = "Bob failed to reach the top.";

        Stack<int> fuelStart = new Stack<int>(Console.ReadLine()
            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray());

        Queue<int> consumptionIndexStart = new Queue<int>(Console.ReadLine()
            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray());

        int[] fuelNeededStart = Console.ReadLine()
            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        List<string> reachedAltitudes = new List<string>();

        bool reachedTop = true;

        for (int i = 1; i <= fuelNeededStart.Length; i++)
        {
            int fuel = fuelStart.Pop();
            int index = consumptionIndexStart.Dequeue();
            int neededFuel = fuelNeededStart[i - 1];

            int result = fuel - index;

            if (result >= neededFuel)
            {
                reachedAltitudes.Add($"Altitude {i}");
                Console.WriteLine(string.Format(AltitudeReached, i));
            }
            else
            {
                reachedTop = false;
                Console.WriteLine(string.Format(AltitudeNotReached, i));
                break;
            }
        }

        if (reachedTop == false)
        {
            Console.WriteLine(FailToReachTop);

            if (reachedAltitudes.Count == 0)
            {
                Console.WriteLine("Bob didn't reach any altitude.");
            }
            else
            {
                Console.WriteLine("Reached altitudes: " + string.Join(", ", reachedAltitudes));
            }
        }
        else
        {
            Console.WriteLine("Bob has reached all the altitudes and managed to reach the top!");
        }
    }
}
