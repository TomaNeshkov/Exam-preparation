using System;
using System.Linq;
class Program
{
    static void Main(string[] args)
    {
        int[] lilies = Console.ReadLine()
            .Split(", ")
            .Select(int.Parse)
            .ToArray();

        int[] roses = Console.ReadLine()
            .Split(", ")
            .Select(int.Parse)
            .ToArray();

        int wreathsCount = MakeWreaths(lilies, roses);

        if (wreathsCount >= 5)
        {
            Console.WriteLine($"You made it, you are going to the competition with {wreathsCount} wreaths!");
        }
        else
        {
            int wreathsNeeded = 5 -wreathsCount;
            Console.WriteLine($"You didn't make it, you need {wreathsNeeded} wreaths more!");
        }
    }

    static int MakeWreaths(int[] lilies, int[] roses)
    {
        int wreathsCount = 0;
        int storedFlowers = 0;

        for (int i = lilies.Length - 1, j = 0; i >= 0 && j < roses.Length;)
        {
            int sum = lilies[i] + roses[j];

            if (sum == 15)
            {
                wreathsCount++;
                i--;
                j++;
            }
            else if (sum > 15)
            {
                lilies[i] -= 2;
            }
            else
            {
                storedFlowers += sum;
                i--;
                j++;
            }
        }

        wreathsCount += storedFlowers/15;

        return wreathsCount;
    }
}
