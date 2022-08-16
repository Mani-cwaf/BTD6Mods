using Assets.Scripts.Models.Towers;
using Assets.Scripts.Models.Towers.Behaviors;
using Assets.Scripts.Models.Towers.Behaviors.Abilities.Behaviors;
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

namespace VanillaParagons.MilitaryParagons.MonkeyAceParagon.Buffable
{
    public class MonkeyAceParagonBuffable : ModTower
    {
        public override string DisplayName => "Buffable Rain of Fire";
        public override string TowerSet => MAGIC;
        public override bool DontAddToShop => !EnableBuffableParagons;
        public override string BaseTower => "MonkeyAce-502";
        public override int Cost => 900000;
        public override int TopPathUpgrades => 0;
        public override int MiddlePathUpgrades => 1;
        public override int BottomPathUpgrades => 0;
        public override string Description => "Buffable version of the Rain of Fire";
        public override void ModifyBaseTowerModel(TowerModel tower)
        {
            var weapon = tower.GetWeapon();
            var projectile = weapon.projectile;
            var groundzeroAbility = Game.instance.model.GetTower(TowerType.MonkeyAce, 0, 5).GetAbility().Duplicate();
            var goundzeroAbilityAttackModel = Game.instance.model.GetTower(TowerType.MonkeyAce, 0, 5).GetAbility().GetBehavior<ActivateAttackModel>().Duplicate();
            var seekingBehavior = new TrackTargetModel("MonkeyAceParagonTrackTargetModel", 9999999, true, false, 360, true, 800, false, false);
            projectile.AddBehavior(new DamageModifierForTagModel("DamageModifierForTagModel_Moabs", "Moabs", 1, 2f, false, false));
            projectile.AddBehavior(seekingBehavior);
            projectile.GetDamageModel().damage += 2;
            projectile.pierce += 50;
            weapon.emission = new ArcEmissionModel("MonkeyAceParagonArcEmissionModel", 128, 180, 360, null, false);
            weapon.rate *= 0.5f;
            tower.AddBehavior(groundzeroAbility);
            groundzeroAbility.AddBehavior(goundzeroAbilityAttackModel);
            tower.GetDescendants<FilterInvisibleModel>().ForEach(model => model.isActive = false);
        }
        public override int GetTowerIndex(List<TowerDetailsModel> towerSet)
        {
            return towerSet.First(model => model.towerId == TowerType.MonkeyAce).towerIndex + 1;
        }
        public class MonkeyAceParagonBuffableDegree100 : ModUpgrade<MonkeyAceParagonBuffable>
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
