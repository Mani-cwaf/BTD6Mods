using Assets.Scripts.Models.Towers;
using Assets.Scripts.Unity.Display;
using BTD_Mod_Helper.Api.Display;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VanillaParagons.PrimaryParagons.IceMonkeyParagon.Buffable;

namespace VanillaParagons.PrimaryParagons.IceMonkeyParagon.Displays
{
    public class IceMonkeyParagonDisplay : ModTowerDisplay<IceMonkeyParagonBase>
    {
        public override string BaseDisplay => GetDisplay(TowerType.IceMonkey, 0, 0, 5);

        public override bool UseForTower(int[] tiers)
        {
            return IsParagon(tiers);
        }

        public override int ParagonDisplayIndex => 0;

        public override void ModifyDisplayNode(UnityDisplayNode node)
        {
            //SetMeshTexture(node, Name);
        }
    }
    public class BananaFarmParagonBuffableDisplay : ModTowerDisplay<IceMonkeyParagonBuffable>
    {
        public override string BaseDisplay => GetDisplay(TowerType.IceMonkey, 0, 0, 5);

        public override bool UseForTower(int[] tiers)
        {
            return tiers.Sum() == 0;
        }
        public override void ModifyDisplayNode(UnityDisplayNode node)
        {
            //SetMeshTexture(node, "BananaFarmParagonDisplay");
        }
    }
}