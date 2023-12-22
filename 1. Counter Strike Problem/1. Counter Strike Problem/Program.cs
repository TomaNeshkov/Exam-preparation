using System;

class Program
{
    static void Main(string[] args)
    {
        int energyLevel = int.Parse(Console.ReadLine());

        int victories = 0;

        while (true)
        {
            string userInput = Console.ReadLine();

            if (userInput == "End of battle")
            {
                Console.WriteLine($"Triumphs: {victories}. Energy remaining: {energyLevel}");
                break;
            }

            int distance = int.Parse(userInput);

            if (energyLevel >= distance)
            {
                energyLevel -= distance;
                victories++;

                if (victories % 3 == 0)
                {
                    energyLevel += victories;
                }
            }
            else
            {
                Console.WriteLine($"Insufficient energy! The game concludes with {victories} triumphs and {energyLevel} energy");
                break;
            }
        }
    }
}
