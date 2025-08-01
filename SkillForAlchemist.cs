using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OuroborosAdventure
{
    public class SkillForAlchemist : Skill
    {
        private int _extraBullets;
        private bool _nextShotTriggered;
        public SkillForAlchemist() : base("Multi Shot", 3f, 8f)
        {
            _extraBullets = 4;
            _nextShotTriggered = false;
        }
        protected override void OnActivate()
        {
            _nextShotTriggered = false;
            Console.WriteLine("Alchemist Multi Shot activated!");
        }
        protected override void OnDeactivate()
        {
            Console.WriteLine("Alchemist Multi Shot deactivated!");
        }
        public void TriggerMultiShot(HashSet<Projectile> projectiles, ProjectileFactory projectileFactory,
                                   Player player, RangeWeapon weapon, bool isSameRoom)
        {
            if (!IsActive) return;
            //_nextShotTriggered = true;

            // Get the projectile type from the weapon
            string projectileType = GetProjectileTypeFromWeapon(weapon.Name);
            if (projectileType == null) return;
            //Console.WriteLine("Outside loop Multishot");
            // Create additional projectiles at different angles
            for (int i = 1; i <= _extraBullets; i++)
            {
                double angleOffset = (i % 2 == 0 ? 1 : -1) * (i * 0.14); // ±8° (0.14 rad)
                double newAngle = weapon.Angle + angleOffset;
                if(player.Energy - weapon.EnergyCost * _extraBullets < 0)
                {
                    Console.WriteLine("Not enough energy yet to trigger multi shot.");
                    return;
                } else
                {
                    //Console.WriteLine("I am called Multi Shot");
                    //Console.WriteLine("Current Energy: " + player.Energy);
                    //Console.WriteLine("Energy Cost: " + weapon.EnergyCost * _extraBullets);
                    player.EnergyChanged(-weapon.EnergyCost * _extraBullets);
                    _nextShotTriggered = true;
                    Projectile? newProjectile = projectileFactory.Create(
                        projectileType,
                        player.X + player.Width / 2 - 50, // Center of player
                        player.Y + player.Height / 2 - 50,
                        false, // isCritical 
                        (float)newAngle,
                        weapon.Width, // weaponWidth
                        CharacterType.Player,
                        isSameRoom
                    );
                    if (newProjectile != null)
                    {
                        projectiles.Add(newProjectile);
                    }
                    weapon.TriggerShot();
                }
            }
        }
        private string? GetProjectileTypeFromWeapon(string weaponName)
        {
            // Map weapon names to their projectile types
            switch (weaponName.ToLower())
            {
                case "revolver":
                    return "pistolBullet";
                case "shotgun":
                    return "shotgunBullet";
                case "sniper":
                    return "sniperBullet";
                case "rifle":
                    return "rifleBullet";
                case "snipezooka":
                    return "snipezookaBullet";
                case "flamethrower":
                    return "fireBullet";
                case "glassgun":
                    return "Glass";
                case "fireparticle":
                    return "fireParticle";
                case "plutonium":
                    return "Plutoniumball";
                default:
                    return "pistolBullet"; // Default fallback
            }
        }
    }
}
