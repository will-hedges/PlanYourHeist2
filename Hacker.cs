using System;

namespace PlanYourHeist2
{
    public class Hacker : IRobber
    {
        public string Name { get; set; }
        public int SkillLevel { get; set; }
        public int PercentageCut { get; set; }

        void PerformSkill(Bank bank)
        {
            bank.AlarmScore -= SkillLevel;
            Console.WriteLine(
                $"{Name} is disabling the alarm. Alarm security reduced by {SkillLevel} points."
            );

            if (bank.AlarmScore <= 0)
            {
                Console.WriteLine($"{Name} has disabled the alarm!");
            }
        }

        public Hacker(string name, int skillLevel, int percentageCut)
        {
            Name = name;
            SkillLevel = skillLevel;
            PercentageCut = percentageCut;
        }
    }
}
