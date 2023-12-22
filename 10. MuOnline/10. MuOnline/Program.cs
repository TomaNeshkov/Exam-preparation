using System;

class Program
{
    static void Main(string[] args)
    {
        string[] rooms = Console.ReadLine().Split("|");
        string[] temp = new string[2];

        int playerHealth = 100;
        int playerBitcoins = 0;
        int healed = 0;

        for (int i = 0; i < rooms.Length; i++)
        {
            temp = rooms[i].Split();
            if (temp[0] == "chest")
            {
                playerBitcoins += int.Parse(temp[1]);
                Console.WriteLine($"You found {temp[1]} bitcoins.");
            }
            else if (temp[0] == "potion")
            {
                healed = playerHealth;
                playerHealth += int.Parse(temp[1]);
                if (playerHealth > 100)
                {
                    playerHealth = 100;
                }
                healed = -1 * (healed - playerHealth);
                Console.WriteLine($"You healed for {healed} hp.");
                Console.WriteLine($"Current health: {playerHealth} hp.");
            }
            else
            {
                if (int.Parse(temp[1]) >= playerHealth)
                {
                    Console.WriteLine($"You died! Killed by {temp[0]}.");
                    Console.WriteLine($"Best room: {i + 1}");
                    break;
                }
                else
                {
                    playerHealth -= int.Parse(temp[1]);
                    Console.WriteLine($"You slayed {temp[0]}.");
                }
            }
            if (i == rooms.Length - 1)
            {
                Console.WriteLine("You've made it!");
                Console.WriteLine($"Bitcoins: {playerBitcoins}");
                Console.WriteLine($"Health: {playerHealth}");
            }
        }
    }
}
