using Assets.Scripts.Models.Towers;
using Assets.Scripts.Models.Towers.Behaviors.Attack;
using Assets.Scripts.Models.Towers.Behaviors.Emissions;
using Assets.Scripts.Models.Towers.Filters;
using Assets.Scripts.Models.Towers.Projectiles;
using Assets.Scripts.Models.Towers.Projectiles.Behaviors;
using Assets.Scripts.Simulation.Towers.Behaviors;
using Assets.Scripts.Unity;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using System.Linq;

namespace DarkMage.Upgrades
{
    public class AvatarOfDarkness : ModParagonUpgrade<DarkMage>
    {  
        public override int Cost => 8400000;
        public override string Description => "True darkness, derived from the source";
        public override string DisplayName => "Avatar Of Darkness";

        public override void ApplyUpgrade(TowerModel tower)
        {
            int paragonPowerLevel = 1;
            if (Main.ParagonOverPowered == true)
            {
                paragonPowerLevel = 10;
            }

            tower.range *= 2f;
            tower.GetAttackModel().range *= 2f;
            var darkPulse = tower.GetWeapon();
            var ultraPulse = darkPulse.Duplicate();
            var fireStorm = Game.instance.model.GetTower(TowerType.WizardMonkey, 1,2,0).behaviors.First(a => a.name.Contains("Wall")).Cast<AttackModel>().Duplicate();
            fireStorm.weapons[0].projectile.GetBehavior<AgeModel>().lifespan = 1.25f;
            fireStorm.weapons[0].projectile.RemoveBehaviors<CreateEffectOnExhaustedModel>();
            fireStorm.weapons[0].projectile.GetDamageModel().damage = 10000 * paragonPowerLevel;
            fireStorm.weapons[0].projectile.radius += 15;
            fireStorm.weapons[0].Rate *= .005f;
            
            tower.AddBehavior(fireStorm);
            tower.GetAttackModel().AddWeapon(ultraPulse);

            var bomb = Game.instance.model.GetTower(TowerType.BombShooter, 3).GetWeapon().projectile.Duplicate();
            var pb = bomb.GetBehavior<CreateProjectileOnContactModel>();
            var sound = bomb.GetBehavior<CreateSoundOnProjectileCollisionModel>();
            var effect = bomb.GetBehavior<CreateEffectOnContactModel>();

            ultraPulse.projectile.AddBehavior(new CreateProjectileOnExhaustFractionModel("CreateProjectileOnExhaustFractionModel_", pb.projectile, pb.emission, 1f, 1f, true));
            ultraPulse.projectile.AddBehavior(new CreateSoundOnProjectileExhaustModel("CreateSoundOnProjectileExhaustModel_", sound.sound1, sound.sound2, sound.sound3, sound.sound4, sound.sound5));
            ultraPulse.projectile.AddBehavior(new CreateEffectOnExhaustedModel("CreateEffectOnExhaustedModel_", "", 0, false, false, effect.effectModel));
            ultraPulse.projectile.AddBehavior(new DamageModifierForTagModel("DamageModifierForTagModel_Moabs", "Moabs", 1, 1200000 * paragonPowerLevel, false, false));
            ultraPulse.projectile.AddBehavior(new DamageModifierForTagModel("DamageModifierForTagModel_Fortified", "Fortified", 1, 1400000 * paragonPowerLevel, false, false));
            ultraPulse.projectile.GetDamageModel().distributeToChildren = true;
            ultraPulse.projectile.GetDamageModel().damage = 1000000 * paragonPowerLevel;
            ultraPulse.projectile.pierce = 1000;
            ultraPulse.projectile.radius *= 3;
            ultraPulse.Rate *= 2;

            darkPulse.projectile.AddBehavior(new DamageModifierForTagModel("DamageModifierForTagModel_Moabs", "Moabs", 1, 1575 * paragonPowerLevel, false, false));
            darkPulse.projectile.AddBehavior(new DamageModifierForTagModel("DamageModifierForTagModel_Ceramic", "Ceramic", 1, 325 * paragonPowerLevel, false, false));
            darkPulse.projectile.AddBehavior(new DamageModifierForTagModel("DamageModifierForTagModel_Fortified", "Fortified", 1, 1225 * paragonPowerLevel, false, false));
            darkPulse.emission = new ArcEmissionModel("ArcEmissionModel_", 15, 0, 25, null, false);
            darkPulse.projectile.GetDamageModel().immuneBloonProperties = BloonProperties.None;
            darkPulse.projectile.GetDamageModel().damage += 1625 * paragonPowerLevel;
            darkPulse.projectile.pierce += 500;
            darkPulse.Rate *= .0333333f;

            var seekingBehavior = Game.instance.model.GetTower(TowerType.BoomerangMonkey, 4).GetDescendants<ProjectileModel>().ToList()[0].GetBehavior<RetargetOnContactModel>().Duplicate();

            seekingBehavior.distance = 5000;
            darkPulse.projectile.AddBehavior(seekingBehavior);
            ultraPulse.projectile.AddBehavior(seekingBehavior);
            tower.GetDescendants<ProjectileModel>().ToList()[0].GetBehavior<TravelStraitModel>().speed = 450;
            tower.GetDescendants<ProjectileModel>().ToList()[0].GetBehavior<TravelStraitModel>().lifespan = 5;
            tower.GetDescendants<ProjectileModel>().ToList()[0].pierce = 500;

            tower.GetDescendants<FilterInvisibleModel>().ForEach(model => model.isActive = false);
            tower.GetAttackModel().RemoveWeapon(darkPulse);
            tower.GetAttackModel().RemoveWeapon(ultraPulse);
            //tower.RemoveBehavior(fireStorm);
        }
    }
}