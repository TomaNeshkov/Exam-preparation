using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        List<string> mealsList = Console.ReadLine().Split().ToList();
        List<int> dailyCalories = Console.ReadLine().Split().Select(int.Parse).ToList();

        int mealCount = 0;

        while (mealsList.Count > 0 && dailyCalories.Count > 0)
        {
            int mealCalories = GetCalories(mealsList[0]);
            int remainingDailyCalories = dailyCalories[0];

            if (mealCalories <= remainingDailyCalories)
            {
                mealsList.RemoveAt(0);
                dailyCalories[0] -= mealCalories;

                if (dailyCalories[0] == 0)
                {
                    dailyCalories.RemoveAt(0);
                }
            }
            else
            {
                mealsList[0] = AdjustCalories(mealsList[0], remainingDailyCalories);
                dailyCalories.RemoveAt(0);
            }

            mealCount++;
        }

        if (mealsList.Count == 0)
        {
            Console.WriteLine($"John had {mealCount} meals.");
            Console.WriteLine($"For the next few days, he can eat {string.Join(", ", dailyCalories)} calories.");
        }
        else
        {
            Console.WriteLine($"John ate enough, he had {mealCount} meals.");
            Console.WriteLine($"Meals left: {string.Join(", ", mealsList)}.");
        }
    }

    static int GetCalories(string meal)
    {
        switch (meal)
        {
            case "salad": return 350;
            case "soup": return 490;
            case "pasta": return 680;
            case "steak": return 790;
            default: return 0;
        }
    }

    static string AdjustCalories(string meal, int remainingCalories)
    {
        int mealCalories = GetCalories(meal);
        int remaining = mealCalories - remainingCalories;

        if (remaining <= 0)
        {
            return "none";
        }

        return $"{meal.Substring(0, meal.Length - 1)} {remaining}";
    }
}
