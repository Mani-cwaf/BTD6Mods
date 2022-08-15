using Assets.Scripts.Models.Bloons.Behaviors;
using Assets.Scripts.Models.Towers;
using Assets.Scripts.Models.Towers.Behaviors.Emissions;
using Assets.Scripts.Models.Towers.Filters;
using Assets.Scripts.Models.Towers.Projectiles.Behaviors;
using Assets.Scripts.Unity.Display;
using Assets.Scripts.Unity.Towers.Mods;
using BTD_Mod_Helper.Api.Display;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using System.Linq;

namespace VanillaParagons.PrimaryParagons.GlueGunnerParagon
{
    public class GlueGunnerParagonBase : ModVanillaParagon
    {
        public override string BaseTower => "GlueGunner-025";
    }
    public class GlueGunnerParagon : ModParagonUpgrade<GlueGunnerParagonBase>
    {
        public override string DisplayName => "Ultimate Adhesive";
        public override int Cost => 920000;
        public override string Description => "Adhesive no bloon can begin to escape.";
        //public override string Icon => "";
        //public override string Portrait => "";
        public override void ApplyUpgrade(TowerModel tower)
        {
            var weapon = tower.GetWeapon();
            var projectile = weapon.projectile;
            weapon.rate *= 0.5f;
            projectile.AddBehavior(new SlowModel("GlueParagonSlowModelWeak", 0.8f, 5, "", 999999, "GlueStronger", true, false, null, true, false, false , 100));
            projectile.pierce += 2;
            projectile.maxPierce = 999999;
            projectile.AddBehavior(new AddBonusDamagePerHitToBloonModel("GlueParagonAddBonusDamagePerHitToBloonModel", "", 2, 20, 999999, true, false, true));
            projectile.GetBehaviors<AddBehaviorToBloonModel>()[1].GetBehavior<DamageOverTimeModel>().damage = 100;
            projectile.GetBehaviors<AddBehaviorToBloonModel>()[1].GetBehavior<DamageOverTimeModel>().Interval = 0.05f;
            projectile.RemoveBehaviors<SlowModifierForTagModel>();
            projectile.RemoveBehaviors<SlowForBloonModel>();
            tower.GetDescendants<FilterInvisibleModel>().ForEach(model => model.isActive = false);
        }
        public class UltimateAdhesiveDisplay : ModTowerDisplay<GlueGunnerParagonBase>
        {
            public override string BaseDisplay => GetDisplay(TowerType.GlueGunner, 0, 0, 5);

            public override bool UseForTower(int[] tiers)
            {
                return IsParagon(tiers);
            }

            public override int ParagonDisplayIndex => 0;

            public override void ModifyDisplayNode(UnityDisplayNode node)
            {
                foreach (var renderer in node.genericRenderers)
                {
                    //renderer.material.mainTexture = GetTexture("SuperbGlue_Display");
                    //node.SaveMeshTexture();
                }
            }
        }
    }
}