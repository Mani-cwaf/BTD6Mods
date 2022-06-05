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
        public override int Cost => 166000;
        public override string Description => "Uses forbidden explosive magic crush all bloons that crosses it's path";
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

            ultraPulse.projectile.AddBehavior(new DamageModifierForTagModel("DamageModifierForTagModel_Moabs", "Moabs", 1, 100f, false, false));
            ultraPulse.projectile.GetBehavior<TravelStraitModel>().Speed += 100;
            ultraPulse.projectile.GetDamageModel().damage = 100f;
            ultraPulse.projectile.pierce = 100f;
            ultraPulse.projectile.radius *= 2f;
            ultraPulse.Rate = 2.5f;


            tower.GetAttackModel().AddWeapon(ultraPulse);

            darkPulse.projectile.AddBehavior(new DamageModifierForTagModel("DamageModifierForTagModel_Ceramic", "Ceramic", 1, 50f, false, false));
            darkPulse.emission = new ArcEmissionModel("ArcEmissionModel_", 5, 0, 10, null, false);
            darkPulse.projectile.GetDamageModel().immuneBloonProperties = BloonProperties.None;
            darkPulse.projectile.pierce += 5f;
            darkPulse.Rate *= .666666f;
        }
    }
}