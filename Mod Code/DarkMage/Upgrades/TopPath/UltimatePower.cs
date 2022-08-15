using Assets.Scripts.Models.Towers;
using Assets.Scripts.Models.Towers.Behaviors.Abilities;
using Assets.Scripts.Models.Towers.Behaviors.Attack;
using Assets.Scripts.Models.Towers.Behaviors.Emissions;
using Assets.Scripts.Models.Towers.Filters;
using Assets.Scripts.Models.Towers.Projectiles.Behaviors;
using Assets.Scripts.Models.Towers.Weapons.Behaviors;
using Assets.Scripts.Unity;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using MelonLoader;

namespace DarkMage.Upgrades.TopPath
{
    public class UltimatePower : ModUpgrade<DarkMage>
    {
        public override int Path => TOP;
        public override int Tier => 5;
        public override int Cost => 108600;

        public override string Description => "attacks do extra damage and can stun bloons it hits";

        public override void ApplyUpgrade(TowerModel tower)
        {
            var darkPulse = tower.GetWeapon();

            var bomb = Game.instance.model.GetTower(TowerType.BombShooter, 3).GetWeapon().projectile.Duplicate();
            var pb = bomb.GetBehavior<CreateProjectileOnContactModel>();
            var sound = bomb.GetBehavior<CreateSoundOnProjectileCollisionModel>();
            var effect = bomb.GetBehavior<CreateEffectOnContactModel>();

            var behavior = new CreateProjectileOnExhaustFractionModel("CreateProjectileOnExhaustFractionModel_", pb.projectile, pb.emission, 1f, 1f, true);
            darkPulse.projectile.AddBehavior(behavior);

            var soundBehavior = new CreateSoundOnProjectileExhaustModel("CreateSoundOnProjectileExhaustModel_", sound.sound1, sound.sound2, sound.sound3, sound.sound4, sound.sound5);
            darkPulse.projectile.AddBehavior(soundBehavior);

            var eB = new CreateEffectOnExhaustedModel("CreateEffectOnExhaustedModel_", "", 0f, false, false, effect.effectModel);
            darkPulse.projectile.AddBehavior(eB);

            darkPulse.projectile.GetDamageModel().immuneBloonProperties = BloonProperties.None;
            tower.GetDescendants<FilterInvisibleModel>().ForEach(model => model.isActive = false);
        }
    }
}