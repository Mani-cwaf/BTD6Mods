using Assets.Scripts.Unity.Display;
using BTD_Mod_Helper.Api.Display;
using System.Linq;

namespace OPFreeDartMonkey.Displays
{
    public class OPFreeDartMonkeyDisplay : ModTowerDisplay<OPFreeDartMonkey>
    {
        public override string BaseDisplay => GetDisplay("DartMonkey");

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