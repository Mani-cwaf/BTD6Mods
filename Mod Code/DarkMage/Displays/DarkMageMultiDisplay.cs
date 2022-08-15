using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Models.Towers;
using Assets.Scripts.Unity.Display;
using BTD_Mod_Helper.Api;
using BTD_Mod_Helper.Api.Display;
using BTD_Mod_Helper.Extensions;
using MelonLoader;

namespace DarkMage.Displays
{
    /// <summary>
    /// This is a more complicated example of a ModTowerDisplay, one that loads multiple versions of itself that are
    /// slightly different in order to take advantage of many Boomerang Monkey variants all using the same sprite sheet
    /// </summary>
    public class DarkMageMultiDisplay : ModTowerDisplay<DarkMage>
    {
        private readonly int[] t;  // The tiers used for a particular instance of DarkMageBaseDisplay

        /// <summary>
        /// All classes that derive from ModContent MUST have a zero argument constructor to work
        /// </summary>
        public DarkMageMultiDisplay()
        {

        }

        public DarkMageMultiDisplay(int[] tiers)
        {
            t = tiers;
        }

        /// <summary>
        /// This is an example of loading multiple instances of the same ModDisplay with different values
        /// </summary>
        public override IEnumerable<ModContent> Load()
        {
            for (var i = 0; i <= 2; i++)
            {
                for (var j = 0; j <= 2; j++)
                {
                    for (var k = 0; k <= 2; k++)
                    {
                        var tiers = new[] { i, j, k };
                        if (tiers.IsValid())
                        {
                            yield return new DarkMageMultiDisplay(tiers);
                        }
                    }
                }
            }
        }

        /* Using the t value for various overrides */

        // Have to give each Display a different name based on the tiers
        public override string Name => nameof(DarkMageMultiDisplay) + "-" + t.Printed();

        // Copy the corresponding Boomerang Monkey display
        public override string BaseDisplay => GetDisplay(TowerType.WizardMonkey, t[0], t[1], t[2]);

        public override bool UseForTower(int[] tiers)
        {
            if (t.Sum() == 0)  // Temporarily use the base display for all tier 3-4 crosspaths
            {
                return /*tiers.Max() > 2 && */ tiers.Max() < 5;
            }

            return false; //tiers.SequenceEqual(t);
        }

        /// <summary>
        /// All the different nodes can be modified in the same way
        /// </summary>
        public override void ModifyDisplayNode(UnityDisplayNode node)
        {
            // Always set the MeshTexture to the same one, since all the cross-paths use the same original sprite atlas
            SetMeshTexture(node, nameof(DarkMageBaseDisplay));
            // Make it not hold the Boomerang, name found through the PrintInfo() method above
            node.RemoveBone("SuperMonkeyRig:Dart");
        }
    }
}