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
                $"{Name} is handling the security guards. Guard security level reduced by {SkillLevel} points."
            );

            if (bank.SecurityGuardScore <= 0)
            {
                Console.WriteLine($"{Name} has neutralized the security guards!");
            }
        }
    }
}
