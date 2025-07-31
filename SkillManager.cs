using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OuroborosAdventure
{
    public class SkillManager
    {
        private Dictionary<string, Skill> _skills;
        private string _currentCharacterType;
        public SkillManager()
        {
            _skills = new Dictionary<string, Skill>();
            InitializeSkills();
            _currentCharacterType = "alchemist"; // Default
        }
        private void InitializeSkills()
        {
            _skills["alchemist"] = new SkillForAlchemist();
            _skills["wizard"] = new SkillForWizard();
            _skills["cowboy"] = new SkillForCowboy();
        }
        public void SetCharacterType(string characterType)
        {
            _currentCharacterType = characterType.ToLower();
        }
        public string GetCharacterType()
        {
            return _currentCharacterType;
        }
        public Skill GetCurrentSkill()
        {
            if (_skills.ContainsKey(_currentCharacterType))
            {
                return _skills[_currentCharacterType];
            }
            return _skills["alchemist"]; // Default fallback
        }
        public void UseSkill()
        {
            GetCurrentSkill().Activate();
        }
        public void UpdateSkills(Player player, HashSet<Character> characters)
        {
            foreach (var skill in _skills.Values)
            {
                skill.Update();
            }

            // Apply active skill effects
            if (_skills["wizard"] is SkillForWizard wizardSkill)
            {
                wizardSkill.ApplyFreeze(characters);
            }

            if (_skills["cowboy"] is SkillForCowboy cowboySkill)
            {
                cowboySkill.ApplyImmortality(player);
                if (!cowboySkill.IsActive && cowboySkill.IsOnCooldown && player.IsImmortal)
                {
                    player.IsImmortal = false;
                }
            }
        }
        public void OnPlayerShoot(HashSet<Projectile> projectiles, ProjectileFactory projectileFactory,
                                 Player player, RangeWeapon weapon, bool isSameRoom)
        {
            if (_skills["alchemist"] is SkillForAlchemist alchemistSkill && _currentCharacterType == "alchemist")
            {
                alchemistSkill.TriggerMultiShot(projectiles, projectileFactory, player, weapon, isSameRoom);
            }
        }
        public string GetSkillStatus()
        {
            Skill currentSkill = GetCurrentSkill();
            if (currentSkill.IsActive)
            {
                float remaining = currentSkill.Duration - (currentSkill.GetActiveProgress() * currentSkill.Duration);
                return $"{currentSkill.Name}: ACTIVE ({remaining:F1}s)";
            }
            else if (currentSkill.IsOnCooldown)
            {
                float remaining = currentSkill.Cooldown - (currentSkill.GetCooldownProgress() * currentSkill.Cooldown);
                return $"{currentSkill.Name}: COOLDOWN ({remaining:F1}s)";
            }
            else
            {
                return $"{currentSkill.Name}: READY";
            }
        }
        public bool CanUseSkill()
        {
            return GetCurrentSkill().CanUse();
        }
    }
}
