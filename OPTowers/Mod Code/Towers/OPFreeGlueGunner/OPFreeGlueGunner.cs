using Assets.Scripts.Models.Bloons.Behaviors;
using Assets.Scripts.Models.Towers;
using Assets.Scripts.Models.Towers.Behaviors.Attack.Behaviors;
using Assets.Scripts.Models.Towers.Filters;
using Assets.Scripts.Models.Towers.Projectiles.Behaviors;
using Assets.Scripts.Models.TowerSets;
using Assets.Scripts.Unity.Display;
using Assets.Scripts.Utils;
using BTD_Mod_Helper.Api.Display;
using BTD_Mod_Helper.Api.Enums;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using System.Collections.Generic;
using System.Linq;
using static OPTowers.Main;

namespace OPFreeGlueGunner
{
    public class OPFreeGlueGunner : ModTower
    {
        public override string TowerSet => TowerSetType.Primary;
        public override string BaseTower => "GlueGunner-200";
        public override int Cost => 0;
        public override int TopPathUpgrades => 0;
        public override int MiddlePathUpgrades => 0;
        public override int BottomPathUpgrades => 0;
        public override string Description => "Totally just a free glue gunner";
        public override string DisplayName => "\"Free Glue Gunner\"";
        public override string Icon => "OPFreeGlueGunner-Icon";
        public override string Portrait => "OPFreeGlueGunner-Portrait";
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
            projectile.pierce = 100;
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
    public class OPFreeGlueGunnerDisplay : ModTowerDisplay<OPFreeGlueGunner>
    {
        public override string BaseDisplay => GetDisplay("GlueGunner");

        public override bool UseForTower(int[] tiers)
        {
            return tiers.Sum() == 0;
        }

        public override void ModifyDisplayNode(UnityDisplayNode node)
        {
            SetMeshTexture(node, Name);
        }
    }
}