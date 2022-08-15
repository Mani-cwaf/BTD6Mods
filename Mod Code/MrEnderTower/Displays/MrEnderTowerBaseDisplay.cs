using System.Linq;
using Assets.Scripts.Models.Towers;
using Assets.Scripts.Unity.Display;
using BTD_Mod_Helper.Api.Display;
using BTD_Mod_Helper.Extensions;
using MelonLoader;

namespace MrEnderTower.Displays
{
    public class MrEnderTowerBaseDisplay : ModTowerDisplay<MrEnderTower>
    {
        // Copy the Boomerang Monkey display
        public override string BaseDisplay => GetDisplay(TowerType.EngineerMonkey);

        public override bool UseForTower(int[] tiers)
        {
            return tiers.Sum() == 0;
        }

        public override void ModifyDisplayNode(UnityDisplayNode node)
        {
            SetMeshTexture(node, Name);
            // Make it not hold the Boomerang
            node.RemoveBone("SuperMonkeyRig:Dart");
        }
    }
}