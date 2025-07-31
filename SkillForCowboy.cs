using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OuroborosAdventure
{
    public class SkillForCowboy : Skill
    {
        private bool _wasImmortalBefore;
        public SkillForCowboy() : base("Immortality", 3f, 10f)
        {
            _wasImmortalBefore = false;
        }
        protected override void OnActivate()
        {
            Console.WriteLine("Cowboy Immortality activated! Player is immortal!");
        }
        protected override void OnDeactivate()
        {
            Console.WriteLine("Cowboy Immortality deactivated! Player is mortal again!");
        }
        public void ApplyImmortality(Player player)
        {
            if (IsActive)
            {
                if (!_wasImmortalBefore)
                {
                    _wasImmortalBefore = player.IsImmortal;
                }
                player.IsImmortal = true;
            }
            else if (!IsOnCooldown)
            {
                // Only reset if player not in cooldown and set it
                player.IsImmortal = _wasImmortalBefore;
                _wasImmortalBefore = false;
            }
        }
    }
}
