using System;
using System.Collections.Generic;

namespace PlanYourHeist2
{
    class Program
    {
        static void Main()
        {
            Muscle matthew = new Muscle("Matthew McDonald", 50, 15);
            Muscle chris = new Muscle("Chris Hanson", 1, 10);
            Hacker logan = new Hacker("Logan Gray", 65, 20);
            Hacker marek = new Hacker("Marek Snyder", 60, 18);
            LockSpecialist kaci = new LockSpecialist("Kaci Wooldrige", 50, 17);
            LockSpecialist morgan = new LockSpecialist("Morgan Ero", 55, 18);

            List<IRobber> rolodex = new List<IRobber>()
            {
                matthew, chris, logan, marek, kaci, morgan
            };

            Console.WriteLine($"Current # of operatives in rolodex = {rolodex.Count}");
            IRobber newRobber = CreateNewRobber();

            while (newRobber != null)
            {
                rolodex.Add(newRobber);
                Console.WriteLine();
                Console.WriteLine($"Current # of operatives in rolodex = {rolodex.Count}");
                newRobber = CreateNewRobber();
            }
        }

        static IRobber CreateNewRobber()
        {
            Console.WriteLine();
            Console.Write($"Enter a name for your new team member: ");
            string name = Console.ReadLine().Trim();
            if (name == "")
            {
                return null;
            }

            // TODO this is a good opportunity to write a function that validates a number input
            int specialty;
            while (true)
            {
                Console.WriteLine();
                Console.Write(
                    $@"Select a specialty for {name}
    1) Hacker (disables alarms)
    2) Muscle (disarms guards)
    3) Lock Specialist (cracks vault)
: "
                );

                string specialtyAnswer = Console.ReadLine().Trim();
                bool isNumber = int.TryParse(specialtyAnswer, out specialty);

                if (isNumber && specialty >= 1 && specialty <= 3)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Please enter a number: 1, 2, or 3.");
                }
            }

            int skillLevel;
            while (true)
            {
                Console.WriteLine();
                Console.Write($"Enter a skill level (1-100) for {name}: ");
                string skillAnswer = Console.ReadLine().Trim();
                bool isNumber = int.TryParse(skillAnswer, out skillLevel);

                if (isNumber && skillLevel >= 1 && skillLevel <= 100)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Please enter a number between 1 and 100.");
                }
            }

            int percentageCut;
            while (true)
            {
                Console.WriteLine();
                Console.Write($"Enter a percentage cut (1-100) for {name}: ");
                string cutAnswer = Console.ReadLine().Trim();
                bool isNumber = int.TryParse(cutAnswer, out percentageCut);

                if (isNumber && percentageCut >= 1 && percentageCut <= 100)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Please enter a number between 1 and 100.");
                }
            }

            // TODO it may be better to change these to strings above, then ex. specialty = 'hacker' etc.
            switch (specialty)
            {
                case 1:
                    return new Hacker(name, skillLevel, percentageCut);
                case 2:
                    return new Muscle(name, skillLevel, percentageCut);
                case 3:
                    return new LockSpecialist(name, skillLevel, percentageCut);
                // default case required, can return null to break loop
                default:
                    return null;
            }
        }
    }
}
