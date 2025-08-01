using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OuroborosAdventure
{
    public class SkillForWizard : Skill
    {
        private Dictionary<Character, float> _originalVelocities;
        public SkillForWizard() : base("Freeze Spell", 2f, 8f)
        {
            _originalVelocities = new Dictionary<Character, float>();
        }
        protected override void OnActivate()
        {
            Console.WriteLine("Freeze Spell activated! All enemies frozen!");
        }
        protected override void OnDeactivate()
        {
            // Restore original velocities
            foreach (var kvp in _originalVelocities)
            {
                if (kvp.Key.Exist)
                {
                    kvp.Key.Velocity = kvp.Value;
                }
            }
            _originalVelocities.Clear();
            Console.WriteLine("Freeze Spell deactivated! Enemies unfrozen!");
        }
        public void ApplyFreeze(HashSet<Character> characters)
        {
            if (!IsActive)
            {
                foreach (var character in characters)
                {
                    if ((character.Type == CharacterType.MeleeEnemy || character.Type == CharacterType.RangeEnemy))
                    {
                        character.IsFrozen = false;
                    }
                }
                return; // Exit early when not active
            }

            foreach (var character in characters)
            {
                if (character.Type == CharacterType.MeleeEnemy || character.Type == CharacterType.RangeEnemy)
                {
                    if (!_originalVelocities.ContainsKey(character))
                    {
                        // Store original velocity only once
                        _originalVelocities[character] = character.Velocity;
                    }
                    // Apply freeze when skill is active
                    character.Velocity = 0f;
                    character.IsFrozen = true;
                }
            }
        }
    }
}
