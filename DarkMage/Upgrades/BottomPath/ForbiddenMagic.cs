using Assets.Scripts.Models;
using Assets.Scripts.Models.Bloons.Behaviors;
using Assets.Scripts.Models.Towers;
using Assets.Scripts.Models.Towers.Behaviors.Attack;
using Assets.Scripts.Models.Towers.Behaviors.Attack.Behaviors;
using Assets.Scripts.Models.Towers.Behaviors.Emissions;
using Assets.Scripts.Models.Towers.Behaviors.Emissions.Behaviors;
using Assets.Scripts.Models.Towers.Projectiles.Behaviors;
using Assets.Scripts.Models.Towers.Weapons.Behaviors;
using Assets.Scripts.Unity;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using MelonLoader;

namespace DarkMage.Upgrades.BottomPath
{
    public class ForbiddenMagic : ModUpgrade<DarkMage>
    {
        public override int Path => BOTTOM;
        public override int Tier => 5;
        public override int Cost => 108600;
        public override string Description => "Uses Forbidden explosive magic crush all bloons that crosses it's path and boost it's attack speed";
        public override void ApplyUpgrade(TowerModel tower)
        {
            var darkPulse = tower.GetWeapon();
            var ultraPulse = darkPulse.Duplicate();

            var bomb = Game.instance.model.GetTower(TowerType.BombShooter, 3).GetWeapon().projectile.Duplicate();
            var pb = bomb.GetBehavior<CreateProjectileOnContactModel>();
            var sound = bomb.GetBehavior<CreateSoundOnProjectileCollisionModel>();
            var effect = bomb.GetBehavior<CreateEffectOnContactModel>();

            var behavior = new CreateProjectileOnExhaustFractionModel("CreateProjectileOnExhaustFractionModel_", pb.projectile, pb.emission, 1f, 1f, true);
            ultraPulse.projectile.AddBehavior(behavior);

            var soundBehavior = new CreateSoundOnProjectileExhaustModel("CreateSoundOnProjectileExhaustModel_", sound.sound1, sound.sound2, sound.sound3, sound.sound4, sound.sound5);
            ultraPulse.projectile.AddBehavior(soundBehavior);

            var eB = new CreateEffectOnExhaustedModel("CreateEffectOnExhaustedModel_", "", 0f, false, false, effect.effectModel);
            ultraPulse.projectile.AddBehavior(eB);

            ultraPulse.projectile.AddBehavior(new DamageModifierForTagModel("DamageModifierForTagModel_Moabs", "Moabs", 1, 1500f, false, false));
            ultraPulse.projectile.GetBehavior<TravelStraitModel>().Speed += 100;
            ultraPulse.projectile.GetDamageModel().damage = 500f;
            ultraPulse.projectile.pierce = 500f;
            ultraPulse.projectile.radius *= 2f;
            ultraPulse.Rate *= 4.0f;


            tower.GetAttackModel().AddWeapon(ultraPulse);

            darkPulse.emission = new ArcEmissionModel("ArcEmissionModel_", 4, 0, 10, null, false);
            darkPulse.projectile.GetDamageModel().immuneBloonProperties = BloonProperties.None;
            darkPulse.projectile.GetDamageModel().damage += 1;
            darkPulse.projectile.pierce += 3f;
            darkPulse.Rate *= .15f;
        }
    }
}