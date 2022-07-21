using Assets.Scripts.Models.Towers;
using Assets.Scripts.Unity.Display;
using BTD_Mod_Helper.Api.Display;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VanillaParagons.SupportParagons.BananaFarmParagon.Buffable;

namespace VanillaParagons.SupportParagons.BananaFarmParagon.Displays
{
    public class BananaFarmParagonDisplay : ModTowerDisplay<BananaFarmParagonBase>
    {
        public override string BaseDisplay => GetDisplay(TowerType.BananaFarm, 5);

        public override bool UseForTower(int[] tiers)
        {
            return IsParagon(tiers);
        }

        public override int ParagonDisplayIndex => 0;

        public override void ModifyDisplayNode(UnityDisplayNode node)
        {
            SetMeshTexture(node, Name);
        }
    }
    public class BananaFarmParagonBuffableDisplay : ModTowerDisplay<BananaFarmParagonBuffable>
    {
        public override string BaseDisplay => GetDisplay(TowerType.BananaFarm, 5);

        public override bool UseForTower(int[] tiers)
        {
            return tiers.Sum() == 0;
        }
        public override void ModifyDisplayNode(UnityDisplayNode node)
        {
            SetMeshTexture(node, "BananaFarmParagonDisplay");
        }
    }
    public class BananaCrateDisplay : ModDisplay
    {
        public override string BaseDisplay => "88442e0b3684e3446aaa70a036da69c9";

        public override void ModifyDisplayNode(UnityDisplayNode node)
        {
            SetMeshTexture(node, Name);
        }
    }
}