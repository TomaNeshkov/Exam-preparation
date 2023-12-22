using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        List<int> bombEffects = Console.ReadLine()
            .Split(", ")
            .Select(int.Parse)
            .ToList();
        List<int> bombCasings = Console.ReadLine()
            .Split(", ")
            .Select(int.Parse)
            .ToList();

        Dictionary<string, int> explosiveDevices = new Dictionary<string, int>
        {
            { "Apple Blasters", 0 },
            { "Orange Detonators", 0 },
            { "Banana Smoke Screens", 0 }
        };

        while (bombEffects.Count > 0 && bombCasings.Count > 0)
        {
            int sum = bombEffects.First() + bombCasings.Last();

            if (IsExplosiveDeviceCreated(sum))
            {
                string type = GetExplosiveDeviceType(sum);
                explosiveDevices[type]++;
                bombEffects.RemoveAt(0);
                bombCasings.RemoveAt(bombCasings.Count - 1);
            }
            else
            {
                bombCasings[bombCasings.Count - 1] -= 5;
            }

            if (AreExplosiveDevicesReady(explosiveDevices))
            {
                Console.WriteLine("Excellent! You have successfully assembled the explosive devices!");
                PrintRemainingItems("Bomb Effects", bombEffects);
                PrintRemainingItems("Bomb Casings", bombCasings);
                PrintExplosiveDevices(explosiveDevices);
                return;
            }
        }

        Console.WriteLine("You don't have sufficient materials to assemble the explosive devices.");
        PrintRemainingItems("Bomb Effects", bombEffects);
        PrintRemainingItems("Bomb Casings", bombCasings);
        PrintExplosiveDevices(explosiveDevices);
    }

    static bool IsExplosiveDeviceCreated(int sum)
    {
        return sum == 40 || sum == 60 || sum == 120;
    }

    static string GetExplosiveDeviceType(int sum)
    {
        switch (sum)
        {
            case 40: return "Banana Smoke Screens";
            case 60: return "Apple Blasters";
            case 120: return "Orange Detonators";
            default: return string.Empty;
        }
    }

    static bool AreExplosiveDevicesReady(Dictionary<string, int> explosiveDevices)
    {
        return explosiveDevices.Values.All(count => count >= 3);
    }

    static void PrintRemainingItems(string itemType, List<int> items)
    {
        Console.WriteLine($"{itemType}: {(items.Count == 0 ? "empty" : string.Join(", ", items))}");
    }

    static void PrintExplosiveDevices(Dictionary<string, int> explosiveDevices)
    {
        foreach (var kvp in explosiveDevices.OrderBy(e => e.Key))
        {
            Console.WriteLine($"{kvp.Key}: {kvp.Value}");
        }
    }
}
