using System;

class Program
{
    static void Main(string[] args)
    {
        int days = int.Parse(Console.ReadLine());
        int dailyPlunder = int.Parse(Console.ReadLine());
        double expectedPlunder = double.Parse(Console.ReadLine());
        double totalPlunder = 0;

        for (int day = 1; day <= days; day++)
        {
            totalPlunder += dailyPlunder;

            if (day % 3 == 0)
            {
                totalPlunder += 0.5 * dailyPlunder;
            }

            if (day % 5 == 0)
            {
                totalPlunder -= 0.3 * totalPlunder;
            }
        }

        if (totalPlunder >= expectedPlunder)
        {
            Console.WriteLine($"Ahoy! {totalPlunder:F2} plunder gained.");
        }
        else
        {
            double percentage = (totalPlunder / expectedPlunder) * 100;
            Console.WriteLine($"Collected only {percentage:F2}% of the plunder.");
        }
    }
}
