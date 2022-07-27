﻿using Assets.Scripts.Unity.Display;
using BTD_Mod_Helper.Api.Display;
using System.Linq;

namespace BloonChipper.Displays
{
    public class BloonChipperDisplay : ModTowerDisplay<BloonChipper>
    {
        public override string BaseDisplay => GetDisplay("NinjaMonkey");

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