using SplashKitSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace OuroborosAdventure
{
    public abstract class Skill
    {
        private SplashKitSDK.Timer _activeTimer;
        private SplashKitSDK.Timer _cooldownTimer;
        public Skill(string name, float duration, float cooldown)
        {
            Name = name;
            Duration = duration;
            Cooldown = cooldown;
            IsActive = false;
            IsOnCooldown = false;

            _activeTimer = SplashKit.CreateTimer("skill_active_" + name + "_" + DateTime.Now.Ticks);
            _cooldownTimer = SplashKit.CreateTimer("skill_cooldown_" + name + "_" + DateTime.Now.Ticks);
        }
        public virtual bool CanUse()
        {
            return !IsActive && !IsOnCooldown;
        }
        public virtual void Activate()
        {
            if (!CanUse()) return;

            IsActive = true;
            SplashKit.StartTimer(_activeTimer);
            OnActivate();
        }
        public virtual void Update()
        {
            // Check if skill duration is over
            if (IsActive && SplashKit.TimerTicks(_activeTimer) >= Duration * 1000)
            {
                IsActive = false;
                IsOnCooldown = true;
                SplashKit.StopTimer(_activeTimer);
                SplashKit.ResetTimer(_activeTimer);
                SplashKit.StartTimer(_cooldownTimer);
                OnDeactivate();
            }
            // Check if cooldown is over
            if (IsOnCooldown && SplashKit.TimerTicks(_cooldownTimer) >= Cooldown * 1000)
            {
                IsOnCooldown = false;
                SplashKit.StopTimer(_cooldownTimer);
                SplashKit.ResetTimer(_cooldownTimer);
            }

            if (IsActive)
            {
                OnUpdate();
            }
        }
        public float GetCooldownProgress()
        {
            if (!IsOnCooldown) return 0f;
            return Math.Min(1f, SplashKit.TimerTicks(_cooldownTimer) / (Cooldown * 1000f));
        }

        public float GetActiveProgress()
        {
            if (!IsActive) return 0f;
            return Math.Min(1f, SplashKit.TimerTicks(_activeTimer) / (Duration * 1000f));
        }
        protected abstract void OnActivate();
        protected abstract void OnDeactivate();
        protected virtual void OnUpdate() { }
        public string Name { get; protected set; }
        public float Duration { get; protected set; }
        public float Cooldown { get; protected set; }
        public bool IsActive { get; protected set; }
        public bool IsOnCooldown { get; protected set; }
    }
}
