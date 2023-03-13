using System;

namespace PlanYourHeist2
{
    public class LockSpecialist : IRobber
    {
        public string Name { get; set; }
        public int SkillLevel { get; set; }
        public int PercentageCut { get; set; }

        void PerformSkill(Bank bank)
        {
            bank.VaultScore -= SkillLevel;
            Console.WriteLine(
                $"{Name} is picking the vault lock. Vault security reduced by {SkillLevel} points."
            );

            if (bank.VaultScore <= 0)
            {
                Console.WriteLine($"{Name} has disabled the vault's lock!");
            }
        }
    }
}
