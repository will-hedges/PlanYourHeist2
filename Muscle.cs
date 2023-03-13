using System;

namespace PlanYourHeist2
{
    public class Muscle : IRobber
    {
        public string Name { get; set; }
        public int SkillLevel { get; set; }
        public int PercentageCut { get; set; }

        void PerformSkill(Bank bank)
        {
            bank.SecurityGuardScore -= SkillLevel;
            Console.WriteLine(
                $"{Name} is disarming the security guards. Guard security level reduced by {SkillLevel} points."
            );

            if (bank.SecurityGuardScore <= 0)
            {
                Console.WriteLine($"{Name} has disarmed the security guards!");
            }
        }

        public Muscle(string name, int skillLevel, int percentageCut)
        {
            Name = name;
            SkillLevel = skillLevel;
            PercentageCut = percentageCut;
        }
    }
}
