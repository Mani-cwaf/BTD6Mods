using Assets.Scripts.Models.Bloons.Behaviors;
using Assets.Scripts.Models.Towers;
using Assets.Scripts.Models.Towers.Behaviors;
using Assets.Scripts.Models.Towers.Behaviors.Attack;
using Assets.Scripts.Models.Towers.Behaviors.Emissions;
using Assets.Scripts.Models.Towers.Filters;
using Assets.Scripts.Models.Towers.Projectiles.Behaviors;
using Assets.Scripts.Models.TowerSets;
using Assets.Scripts.Unity;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using SubTowers.LordPhenix;
using System.Collections.Generic;
using System.Linq;
using static VanillaParagons.Main;

namespace VanillaParagons.PrimaryParagons.GlueGunnerParagon.Buffable
{
    public class GlueGunnerParagonBuffable : ModTower
    {
        public override string DisplayName => "Buffable Ultimate Adhesive";
        public override string TowerSet => MAGIC;
        public override bool DontAddToShop => !EnableBuffableParagons;
        public override string BaseTower => "GlueGunner-025";
        public override int Cost => 900000;
        public override int TopPathUpgrades => 0;
        public override int MiddlePathUpgrades => 1;
        public override int BottomPathUpgrades => 0;
        public override string Description => "Buffable version of the Grand Mage";
        public override void ModifyBaseTowerModel(TowerModel tower)
        {
            var weapon = tower.GetWeapon();
            var projectile = weapon.projectile;
            weapon.rate *= 0.5f;
            projectile.AddBehavior(new SlowModel("GlueParagonSlowModelWeak", 0.8f, 5, "", 999999, "GlueStronger", true, false, null, true, false, false, 100));
            projectile.pierce += 2;
            projectile.maxPierce = 999999;
            projectile.AddBehavior(new AddBonusDamagePerHitToBloonModel("GlueParagonAddBonusDamagePerHitToBloonModel", "", 2, 20, 999999, true, false, true));
            projectile.GetBehaviors<AddBehaviorToBloonModel>()[1].GetBehavior<DamageOverTimeModel>().damage = 100;
            projectile.GetBehaviors<AddBehaviorToBloonModel>()[1].GetBehavior<DamageOverTimeModel>().Interval = 0.05f;
            projectile.RemoveBehaviors<SlowModifierForTagModel>();
            projectile.RemoveBehaviors<SlowForBloonModel>();
            tower.GetDescendants<FilterInvisibleModel>().ForEach(model => model.isActive = false);
        }
        public override int GetTowerIndex(List<TowerDetailsModel> towerSet)
        {
            return towerSet.First(model => model.towerId == TowerType.GlueGunner).towerIndex + 1;
        }
        public class GlueGunnerParagonBuffableDegree100 : ModUpgrade<GlueGunnerParagonBuffable>
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
                projectile.GetBehaviors<AddBehaviorToBloonModel>()[1].GetBehavior<DamageOverTimeModel>().damage *= 2.5f;
                projectile.pierce *= 2.5f;
            }
        }
    }
}
