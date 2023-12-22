using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        List<int> knightArmor = Console.ReadLine()
        .Split(',')
        .Select(int.Parse)
        .ToList();

        List<int> enemyStriking = Console.ReadLine()
            .Split(',')
            .Select(int.Parse)
            .ToList();

        int monstersKilled = 0;

        while (knightArmor.Any() && enemyStriking.Any())
        {
            int currentMonsterArmor = knightArmor.First();
            int currentStrike = enemyStriking.Last();

            if (currentStrike >= currentMonsterArmor)
            {
                knightArmor.RemoveAt(0);
                enemyStriking.RemoveAt(enemyStriking.Count - 1);

                int remainingImpact = currentStrike - currentMonsterArmor;

                if (enemyStriking.Any())
                {
                    enemyStriking[enemyStriking.Count - 1] += remainingImpact;
                }
            }
            else
            {
                knightArmor[0] -= currentStrike;
                enemyStriking.RemoveAt(enemyStriking.Count - 1);
                knightArmor.Add(knightArmor[0]);
                knightArmor.RemoveAt(0);
            }

            monstersKilled++;
        }

        if (knightArmor.Any())
        {
            Console.WriteLine("The soldier has been defeated.");
            Console.WriteLine($"Total monsters killed: {monstersKilled - 1}");
        }
        else
        {
            Console.WriteLine("All monsters have been exterminated!");
            Console.WriteLine($"Total monsters killed: {monstersKilled}");
        }
    }
}
