using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        List<int> earthworms = Console.ReadLine().Split().Select(int.Parse).ToList();
        List<int> burrows = Console.ReadLine().Split().Select(int.Parse).ToList();

        int pairingsCount = 0;

        for (int i = earthworms.Count -1; i >= 0; i--)
        {
            if (burrows.Count == 0)
            {
                break;
            }

            int currentEarthworm = earthworms[i];
            int currentBurrow = burrows[0];

            if (currentEarthworm == currentBurrow)
            {
                pairingsCount++;
                earthworms.RemoveAt(i);
                burrows.RemoveAt(0);
            }
            else
            {
                burrows.RemoveAt(0);
                currentEarthworm -= 3;

                if (currentEarthworm > 0)
                {
                    earthworms[i] = currentEarthworm;
                }
                else
                {
                    earthworms.RemoveAt(i);
                }
            }
        }

        Console.WriteLine($"Pairings: {pairingsCount}");

        if (earthworms.Count == 0)
        {
            Console.WriteLine("Every earthworm found a suitable burrow!");
        }
        else
        {
            Console.WriteLine($"Earthworms left: {string.Join(", ", earthworms)}");
        }

        if (burrows.Count == 0)
        {
            Console.WriteLine("Burrows left: none");
        }
        else
        {
            Console.WriteLine($"Burrows left: {string.Join(", ", burrows)}");
        }
    }
}
