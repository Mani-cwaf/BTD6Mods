using Assets.Scripts.Models.Towers;
using Assets.Scripts.Models.Towers.Behaviors;
using Assets.Scripts.Models.Towers.Behaviors.Abilities;
using Assets.Scripts.Models.Towers.Behaviors.Abilities.Behaviors;
using Assets.Scripts.Models.Towers.Behaviors.Emissions;
using Assets.Scripts.Models.Towers.Filters;
using Assets.Scripts.Models.TowerSets;
using Assets.Scripts.Utils;
using BTD_Mod_Helper.Api.Enums;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using System.Collections.Generic;
using System.Linq;
using static FunPackOfFunExperiments.Main;

namespace QuincyGrandfatherOfQuincy
{
    public class QuincyGrandfatherOfQuincy : ModTower
    {

        public override string TowerSet => TowerSetType.Primary;
        public override string BaseTower => "Quincy 20";
        public override int Cost => 855;
        public override int TopPathUpgrades => 0;
        public override int MiddlePathUpgrades => 0;
        public override int BottomPathUpgrades => 0;
        public override string Description => "";
        public override SpriteReference IconReference => new SpriteReference("MonkeyIcons[QuincyIcon]");
        public override SpriteReference PortraitReference => new SpriteReference("f49307e95b921974cb9e1baadf2352fb");
        public override bool DontAddToShop => !GrandFatherOfQuincyEnabled == true;
        //actual tower abilities
        public override void ModifyBaseTowerModel(TowerModel tower)
        {
            tower.RemoveBehavior<HeroModel>();
            var weapon = tower.GetWeapon();
            var projectile = weapon.projectile;
            projectile.pierce = 250;
            projectile.GetDamageModel().damage += 1100;
            weapon.rate *= 0.008f;
            weapon.emission = new RandomArcEmissionModel("QuincyGrandfatherOfQuincyArcEmissionModel", 10, 0, 5, 5, 0, null);
            projectile.GetDamageModel().immuneBloonProperties = BloonProperties.None;
            tower.GetDescendants<FilterInvisibleModel>().ForEach(invisibleModel => invisibleModel.isActive = false);
            tower.RemoveBehaviors<AbilityModel>();
        }
        public override int GetTowerIndex(List<TowerDetailsModel> towerSet)
        {
            return towerSet.First().towerIndex;
        }
    }
}