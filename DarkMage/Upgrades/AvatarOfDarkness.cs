using Assets.Scripts.Models.Towers;
using Assets.Scripts.Models.Towers.Behaviors;
using Assets.Scripts.Models.Towers.Behaviors.Abilities;
using Assets.Scripts.Models.Towers.Behaviors.Abilities.Behaviors;
using Assets.Scripts.Models.Towers.Behaviors.Emissions;
using Assets.Scripts.Models.Towers.Filters;
using Assets.Scripts.Models.Towers.Projectiles;
using Assets.Scripts.Models.Towers.Projectiles.Behaviors;
using Assets.Scripts.Simulation.Towers;
using Assets.Scripts.Unity;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using MelonLoader;
using System.Linq;

namespace DarkMage.Upgrades
{
    public class AvatarOfDarkness : ModParagonUpgrade<DarkMage>
    {
        public override int Cost => 8000000;
        public override string Description => "True darkness, derived from the source";
        public override string DisplayName => "Avatar Of Darkness";

        public override void ApplyUpgrade(TowerModel tower)
        {
            tower.range *= 1.5f;
            tower.GetAttackModel().range *= 1.5f;
            var darkPulse = tower.GetWeapon();
            var ultraPulse = darkPulse.Duplicate();
            tower.GetAttackModel().AddWeapon(ultraPulse);

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

            ultraPulse.projectile.AddBehavior(new DamageModifierForTagModel("DamageModifierForTagModel_Moabs", "Moabs", 1, 2000000f, false, false));
            ultraPulse.projectile.AddBehavior(new DamageModifierForTagModel("DamageModifierForTagModel_Fortified", "Fortified", 1, 2850000f, false, false));
            ultraPulse.projectile.GetDamageModel().distributeToChildren = true;
            ultraPulse.projectile.GetDamageModel().damage = 1000000f;
            ultraPulse.projectile.pierce = 1000f;
            ultraPulse.projectile.radius *= 3f;
            ultraPulse.Rate *= 3f;


            darkPulse.projectile.AddBehavior(new DamageModifierForTagModel("DamageModifierForTagModel_Moabs", "Moabs", 1, 1950, false, false));
            darkPulse.projectile.AddBehavior(new DamageModifierForTagModel("DamageModifierForTagModel_Ceramic", "Ceramic", 1, 650, false, false));
            darkPulse.projectile.AddBehavior(new DamageModifierForTagModel("DamageModifierForTagModel_Fortified", "Fortified", 1, 1050, false, false));
            darkPulse.emission = new ArcEmissionModel("ArcEmissionModel_", 15, 0, 25, null, false);
            darkPulse.projectile.GetDamageModel().immuneBloonProperties = BloonProperties.None;
            darkPulse.projectile.GetDamageModel().damage += 1250;
            darkPulse.projectile.pierce += 500f;
            darkPulse.Rate *= .0333333f;

            var seekingBehavior = Game.instance.model.GetTower(TowerType.BoomerangMonkey, 4).GetDescendants<ProjectileModel>().ToList()[0].GetBehavior<RetargetOnContactModel>().Duplicate();

            seekingBehavior.distance = 5000;
            darkPulse.projectile.AddBehavior(seekingBehavior);
            ultraPulse.projectile.AddBehavior(seekingBehavior);
            tower.GetDescendants<ProjectileModel>().ToList()[0].GetBehavior<TravelStraitModel>().speed = 600f;
            tower.GetDescendants<ProjectileModel>().ToList()[0].GetBehavior<TravelStraitModel>().lifespan = 5f;
            tower.GetDescendants<ProjectileModel>().ToList()[0].pierce = 500f;

            tower.GetDescendants<FilterInvisibleModel>().ForEach(model => model.isActive = false);
        }
    }
}