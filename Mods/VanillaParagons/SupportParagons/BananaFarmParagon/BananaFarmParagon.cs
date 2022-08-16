using Assets.Scripts.Models.Towers;
using Assets.Scripts.Models.Towers.Behaviors;
using Assets.Scripts.Models.Towers.Projectiles.Behaviors;
using Assets.Scripts.Models.Towers.Weapons.Behaviors;
using Assets.Scripts.Unity.Display;
using BTD_Mod_Helper.Api.Display;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using VanillaParagons.SupportParagons.BananaFarmParagon.Displays;

namespace VanillaParagons.SupportParagons.BananaFarmParagon
{
    public class BananaFarmParagonBase : ModVanillaParagon
    {
        public override string BaseTower => "BananaFarm-500";
    }
    public class BananaFarmParagon : ModParagonUpgrade<BananaFarmParagonBase>
    {
        public override string DisplayName => "Banana Monopoly";
        public override int Cost => 1257500;
        public override string Description => "banana";
        //public override string Icon => "";
        //public override string Portrait => "";
        public override void ApplyUpgrade(TowerModel tower)
        {
            var weapon = tower.GetWeapon();
            var projectile = weapon.projectile;
            weapon.GetBehavior<EmissionsPerRoundFilterModel>().count = 30;
            projectile.GetBehavior<CashModel>().minimum = 5550;
            projectile.GetBehavior<CashModel>().maximum = 5550;
            projectile.ApplyDisplay<BananaCrateDisplay>();
            tower.AddBehavior(new PerRoundCashBonusTowerModel("BananaFarmParagonPerRoundCashBonusTowerModel", 165000, 0, 1, "80178409df24b3b479342ed73cffb63d", false));

        }
        public class BananaMonopolyDisplay : ModTowerDisplay<BananaFarmParagonBase>
        {
            public override string BaseDisplay => GetDisplay(TowerType.BananaFarm, 5, 2, 0);

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