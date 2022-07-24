using System.Linq;
using Assets.Scripts.Models.Towers;
using Assets.Scripts.Unity.Display;
using BTD_Mod_Helper.Api.Display;
using BTD_Mod_Helper.Extensions;
using MelonLoader;

namespace MonkeySeeker.Displays
{
    public class MonkeySeekerDisplay : ModTowerDisplay<MonkeySeeker>
    {
        public override string BaseDisplay => GetDisplay("BoomerangMonkey", 5);

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