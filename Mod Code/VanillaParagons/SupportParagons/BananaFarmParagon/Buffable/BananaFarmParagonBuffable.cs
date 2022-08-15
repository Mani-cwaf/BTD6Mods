using Assets.Scripts.Models.Towers;
using Assets.Scripts.Models.Towers.Behaviors;
using Assets.Scripts.Models.Towers.Behaviors.Attack;
using Assets.Scripts.Models.Towers.Behaviors.Emissions;
using Assets.Scripts.Models.Towers.Projectiles.Behaviors;
using Assets.Scripts.Models.Towers.TowerFilters;
using Assets.Scripts.Models.Towers.Weapons.Behaviors;
using Assets.Scripts.Models.TowerSets;
using Assets.Scripts.Unity;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using SubTowers.LordPhenix;
using System.Collections.Generic;
using System.Linq;
using UnhollowerBaseLib;
using VanillaParagons.SupportParagons.BananaFarmParagon.Displays;
using static VanillaParagons.Main;

namespace VanillaParagons.SupportParagons.BananaFarmParagon.Buffable
{
    public class BananaFarmParagonBuffable : ModTower
    {
        public override string DisplayName => "Buffable Banana Monopoly";
        public override string TowerSet => SUPPORT;
        public override bool DontAddToShop => !EnableBuffableParagons;
        public override string BaseTower => "BananaFarm-500";
        public override int Cost => 1257500;
        public override int TopPathUpgrades => 0;
        public override int MiddlePathUpgrades => 1;
        public override int BottomPathUpgrades => 0;
        public override string Description => "Buffable version of the Banana Monopoly";
        public override void ModifyBaseTowerModel(TowerModel tower)
        {
            var weapon = tower.GetWeapon();
            var projectile = weapon.projectile;
            weapon.GetBehavior<EmissionsPerRoundFilterModel>().count = 30;
            projectile.GetBehavior<CashModel>().minimum = 5550;
            projectile.GetBehavior<CashModel>().maximum = 5550;
            projectile.ApplyDisplay<BananaCrateDisplay>();
            tower.AddBehavior(new PerRoundCashBonusTowerModel("BananaFarmParagonPerRoundCashBonusTowerModel", 165000, 0, 1, "80178409df24b3b479342ed73cffb63d", false));
        }
        public override int GetTowerIndex(List<TowerDetailsModel> towerSet)
        {
            return towerSet.First(model => model.towerId == TowerType.BananaFarm).towerIndex + 1;
        }
        public class BananaFarmParagonBuffableDegree100 : ModUpgrade<BananaFarmParagonBuffable>
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
                weapon.GetBehavior<EmissionsPerRoundFilterModel>().count += 20;
                tower.GetBehavior<PerRoundCashBonusTowerModel>().cashPerRound *= 1.5f;
            }
        }
    }
}
