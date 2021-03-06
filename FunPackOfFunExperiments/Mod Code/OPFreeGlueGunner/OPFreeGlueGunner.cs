using Assets.Scripts.Models.Bloons.Behaviors;
using Assets.Scripts.Models.Towers;
using Assets.Scripts.Models.Towers.Behaviors.Attack.Behaviors;
using Assets.Scripts.Models.Towers.Filters;
using Assets.Scripts.Models.Towers.Projectiles.Behaviors;
using Assets.Scripts.Models.TowerSets;
using Assets.Scripts.Utils;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using System.Collections.Generic;
using System.Linq;
using static FunPackOfFunExperiments.Main;

namespace OPFreeGlueGunner
{
    public class OPFreeGlueGunner : ModTower
    {
        public override string TowerSet => PRIMARY;
        public override string BaseTower => "GlueGunner-200";
        public override int Cost => 0;
        public override int TopPathUpgrades => 0;
        public override int MiddlePathUpgrades => 0;
        public override int BottomPathUpgrades => 0;
        public override string Description => "Totally just a free glue gunner";
        public override string DisplayName => "\"Free\" Glue Gunner";
        public override SpriteReference IconReference => new SpriteReference("MonkeyIcons[GlueGunnerIcon]");
        public override SpriteReference PortraitReference => new SpriteReference("4cf5ed7ac85b3ad4cb921bf7b7a24e16");
        public override bool DontAddToShop => !OPFreeGlueGunnerEnabled == true;
        public override ParagonMode ParagonMode => ParagonMode.Base000;
        public override void ModifyBaseTowerModel(TowerModel tower)
        {
            var attackModel = tower.GetAttackModel();
            var weapon = tower.GetWeapon();
            var projectile = weapon.projectile;
            attackModel.range += 1000;
            tower.range += 1000;
            tower.RemoveBehaviors<AttackFilterModel>();
            projectile.RemoveBehaviors<SlowModifierForTagModel>();
            projectile.RemoveBehaviors<ProjectileFilterModel>();
            projectile.RemoveBehaviors<SlowModel>();
            projectile.AddBehavior(new SlowModel("OPFreeGlueGunnerSlowModel", 0.25f, 11, "", 999999, "GlueBasic", true, false, null, true, false, false, 100));
            projectile.GetBehavior<TravelStraitModel>().lifespan = 5;
            var DOT = projectile.GetBehavior<AddBehaviorToBloonModel>().GetBehavior<DamageOverTimeModel>();
            DOT.damage = 2000000000;
            DOT.interval = 0.01f;
            tower.GetDescendants<FilterInvisibleModel>().ForEach(invisibleModel => invisibleModel.isActive = false);
        }
        public override int GetTowerIndex(List<TowerDetailsModel> towerSet)
        {
            return towerSet.First(model => model.towerId == TowerType.GlueGunner).towerIndex + 1;
        }
    }
}