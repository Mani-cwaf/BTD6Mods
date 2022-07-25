using Assets.Scripts.Unity.Display;
using BTD_Mod_Helper.Api.Display;
using System.Linq;

namespace AssassinMonkey.Displays
{
    public class AssassinMonkeyDisplay : ModTowerDisplay<AssassinMonkey>
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