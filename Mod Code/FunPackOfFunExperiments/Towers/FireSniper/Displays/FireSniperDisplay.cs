using Assets.Scripts.Unity.Display;
using BTD_Mod_Helper.Api.Display;
using System.Linq;

namespace FireSniper.Displays
{
    public class FireSniperDisplay : ModTowerDisplay<FireSniper>
    {
        public override string BaseDisplay => GetDisplay("SniperMonkey");

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