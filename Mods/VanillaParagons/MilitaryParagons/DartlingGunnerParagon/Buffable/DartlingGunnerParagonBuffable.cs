using Assets.Scripts.Models.GenericBehaviors;
using Assets.Scripts.Models.Towers;
using Assets.Scripts.Models.Towers.Behaviors;
using Assets.Scripts.Models.Towers.Behaviors.Attack;
using Assets.Scripts.Models.Towers.Behaviors.Emissions;
using Assets.Scripts.Models.Towers.Projectiles.Behaviors;
using Assets.Scripts.Models.TowerSets;
using Assets.Scripts.Unity;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using SubTowers.LordPhenix;
using System.Collections.Generic;
using System.Linq;
using static VanillaParagons.Main;

namespace VanillaParagons.MilitaryParagons.DartlingGunnerParagon.Buffable
{
    public class DartlingGunnerParagonBuffable : ModTower
    {
        public override string DisplayName => "Buffable Ray of Annihilation";
        public override string TowerSet => MAGIC;
        public override bool DontAddToShop => !EnableBuffableParagons;
        public override string BaseTower => "DartlingGunner-250";
        public override int Cost => 900000;
        public override int TopPathUpgrades => 0;
        public override int MiddlePathUpgrades => 1;
        public override int BottomPathUpgrades => 0;
        public override string Description => "Buffable version of the Ray of Annihilation";
        public override void ModifyBaseTowerModel(TowerModel tower)
        {
            var attackModel = tower.GetAttackModel();
            var weapon = tower.GetWeapon();
            var projectile = weapon.projectile;
            weapon.emission = new RandomEmissionModel("DartlingGunnerEmissionModel", 1, 2, 0, null, false, 1, 1, 0, false);
            weapon.rate *= .015f;
            projectile.AddBehavior(new KnockbackModel("DartlingGunnerKnockbackModel", 1.1f, 1.1f, 1.1f, 0.4f, "KnockbackKnockback", null));
            projectile.GetBehavior<DamageModifierForTagModel>().damageAddative = 35;
            projectile.GetDamageModel().damage = 5;
            projectile.GetDamageModel().immuneBloonProperties = BloonProperties.None;
            projectile.pierce = 10;
        }
        public override int GetTowerIndex(List<TowerDetailsModel> towerSet)
        {
            return towerSet.First(model => model.towerId == TowerType.DartlingGunner).towerIndex + 1;
        }
        public class DartlingGunnerParagonBuffableDegree100 : ModUpgrade<DartlingGunnerParagonBuffable>
        {
            public override string DisplayName => "Degree 100";
            public override string Description => "Degree 100";
            public override int Cost => 0;
            public override int Path => MIDDLE;
            public override int Tier => 1;
            public override void ApplyUpgrade(TowerModel tower)
            {
                var weapon = tower.GetWeapon();
                var projectile = weapon.projectile;
                weapon.rate *= 0.642857f;
                projectile.GetDamageModel().damage *= 2.5f;
                projectile.pierce *= 2.5f;
            }
        }
    }
}
