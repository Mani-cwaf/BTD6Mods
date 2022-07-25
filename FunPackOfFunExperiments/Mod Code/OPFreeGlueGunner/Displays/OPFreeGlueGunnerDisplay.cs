using Assets.Scripts.Unity.Display;
using BTD_Mod_Helper.Api.Display;
using System.Linq;

namespace OPFreeGlueGunner.Displays
{
    public class OPFreeGlueGunnerDisplay : ModTowerDisplay<OPFreeGlueGunner>
    {
        public override string BaseDisplay => GetDisplay("GlueGunner");

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