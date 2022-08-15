using Assets.Scripts.Models.Towers;
using Assets.Scripts.Unity.Display;
using BTD_Mod_Helper.Api.Display;
using BTD_Mod_Helper.Extensions;

namespace DarkMage.Displays.Tier5
{
    public class UltimatePowerDisplay : ModTowerDisplay<DarkMage>
    {
        public override string BaseDisplay => GetDisplay(TowerType.BoomerangMonkey, 5, 0, 0);

        public override bool UseForTower(int[] tiers)
        {
            return tiers[0] == 5;
        }

        public override void ModifyDisplayNode(UnityDisplayNode node)
        {
            //node.PrintInfo();
            //node.SaveMeshTexture();
            node.RemoveBone("SuperMonkeyRig:Dart");

            // PrintInfo() showed this has multiple SkinnedMeshRenderers, so have to specify the index
        }
    }
}