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

            List<IRobber> rolodex = new List<IRobber>();
            rolodex.Add(matthew);
            rolodex.Add(chris);
            rolodex.Add(logan);
            rolodex.Add(marek);
            rolodex.Add(kaci);
            rolodex.Add(morgan);

            Console.WriteLine($"Current # operatives in rolodex = {rolodex.Count}");

            IRobber newRobber = CreateNewRobber();
            while (newRobber != null)
            {
                rolodex.Add(newRobber);
                Console.WriteLine($"Current # operatives in rolodex = {rolodex.Count}");
                newRobber = CreateNewRobber();
            }
        }

        static IRobber CreateNewRobber()
        {
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
            }

            int skillLevel;
            while (true)
            {
                Console.Write($"Enter a skill level (1-100) for {name}: ");
                string skillAnswer = Console.ReadLine().Trim();
                bool isNumber = int.TryParse(skillAnswer, out skillLevel);

                if (isNumber && skillLevel >= 1 && skillLevel <= 100)
                {
                    break;
                }
            }

            int percentageCut;
            while (true)
            {
                Console.Write($"Enter a percentage cut (1-100) for {name}: ");
                string cutAnswer = Console.ReadLine().Trim();
                bool isNumber = int.TryParse(cutAnswer, out percentageCut);

                if (isNumber && percentageCut >= 1 && percentageCut <= 100)
                {
                    break;
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
                default:
                    return null;
            }
        }
    }
}
