using Assets.Scripts.Models.Towers;
using Assets.Scripts.Unity;
using BTD_Mod_Helper.Api.Towers;
using Assets.Scripts.Simulation.Towers.Behaviors;
using Assets.Scripts.Models.Towers.Behaviors.Attack;
using Assets.Scripts.Models.Towers.Behaviors.Emissions;
using Assets.Scripts.Models.Towers.Filters;
using Assets.Scripts.Models.Towers.Projectiles;
using Assets.Scripts.Models.Towers.Projectiles.Behaviors;
using BTD_Mod_Helper.Extensions;
using System.Linq;
using UnhollowerBaseLib;
using Assets.Scripts.Models.Towers.Behaviors.Abilities.Behaviors;
using Assets.Scripts.Models.Towers.Weapons;

namespace VanillaParagons.MilitaryParagons.MonkeyAceParagon
{
    public class MonkeyAceParagonBase : ModVanillaParagon
    {
        public override string BaseTower => "MonkeyAce-502";
    }
    public class MonkeyAceParagon : ModParagonUpgrade<MonkeyAceParagonBase>
    {
        public override string DisplayName => "Rain of fire";
        public override int Cost => 967000;
        public override string Description => "why does this exist";
        //public override string Icon => "";
        //public override string Portrait => "";
        public override void ApplyUpgrade(TowerModel tower)
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
    }
}