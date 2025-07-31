using SplashKitSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OuroborosAdventure
{
    public static class SkillIntegration
    {
        public static void UpdateSkillSystem(SkillManager skillManager, Player player, HashSet<Character> characters)
        {
            skillManager.UpdateSkills(player, characters);
        }
        public static void HandleAlchemistMultiShot(SkillManager skillManager, HashSet<Projectile> projectiles,
                                                   ProjectileFactory projectileFactory, Player player,
                                                   RangeWeapon weapon, bool isSameRoom)
        {
            if (skillManager.GetCharacterType() == "alchemist")
            {
                skillManager.OnPlayerShoot(projectiles, projectileFactory, player, weapon, isSameRoom);
            }
        }
        public static bool HandleSkillInput(SkillManager skillManager)
        {
            if (SplashKit.KeyTyped(KeyCode.SpaceKey))
            {
                if (skillManager.CanUseSkill())
                {
                    skillManager.UseSkill();
                    return true;
                }
            }
            return false;
        }
    }
}
