using Assets.Scripts.Models.Towers;
using Assets.Scripts.Models.Towers.Behaviors.Emissions;
using Assets.Scripts.Models.Towers.Filters;
using Assets.Scripts.Models.Towers.Projectiles.Behaviors;
using Assets.Scripts.Models.TowerSets;
using Assets.Scripts.Utils;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using System.Collections.Generic;
using System.Linq;
using static FunPackOfFunExperiments.Main;

namespace OPFreeDartMonkey
{
    public class OPFreeDartMonkey : ModTower
    {
        public override string TowerSet => PRIMARY;
        public override string BaseTower => TowerType.DartMonkey;
        public override int Cost => 0;
        public override int TopPathUpgrades => 0;
        public override int MiddlePathUpgrades => 0;
        public override int BottomPathUpgrades => 0;
        public override string Description => "Totally just a free dart monkey";
        public override string DisplayName => "\"Free\" Dart Monkey";
        public override SpriteReference IconReference => new SpriteReference("MonkeyIcons[DartMonkeyIcon]");
        public override SpriteReference PortraitReference => new SpriteReference("8cac03eb4d5aa324ea7deeab89cc090e");
        public override bool DontAddToShop => !OPFreeDartMonkeyEnabled == true;
        public override ParagonMode ParagonMode => ParagonMode.Base000;
        public override void ModifyBaseTowerModel(TowerModel tower)
        {
            var attackModel = tower.GetAttackModel();
            var weapon = tower.GetWeapon();
            var projectile = weapon.projectile;
            attackModel.range += 1000;
            tower.range += 1000;
            projectile.GetDamageModel().damage = 2140000000;
            projectile.GetBehavior<TravelStraitModel>().lifespan = 5;
            weapon.emission = new ArcEmissionModel("OPFreeDartMonkeyArcEmissionModel", 200, 0, 0, null, false);
            projectile.GetDamageModel().immuneBloonProperties = BloonProperties.None;
            projectile.GetDamageModel().distributeToChildren = true;
            tower.GetDescendants<FilterInvisibleModel>().ForEach(invisibleModel => invisibleModel.isActive = false);
        }
        public override int GetTowerIndex(List<TowerDetailsModel> towerSet)
        {
            return towerSet.First(model => model.towerId == TowerType.DartMonkey).towerIndex + 1;
        }
    }
}