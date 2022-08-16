using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Models.Towers;
using Assets.Scripts.Models.Towers.Behaviors;
using BTD_Mod_Helper;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using MelonLoader;

namespace MrEnderTower
{
    /// <summary>
    /// The main class that adds the core tower to the game
    /// </summary>
    public class MrEnderTower : ModTower
    {
        // public override string Portrait => "Don't need to override this, using the default of Name-Portrait";
        // public override string Icon => "Don't need to override this, using the default of Name-Icon";

        public override string TowerSet => SUPPORT;

        public override string BaseTower => TowerType.EngineerMonkey;
        public override int Cost => 88500;

        public override int TopPathUpgrades => 0;
        public override int MiddlePathUpgrades => 5;
        public override int BottomPathUpgrades => 0;
        public override string Description => "Gives insane stats to nearby towers";

        // public override string DisplayName => "Don't need to override this, the default turns it into 'Card Monkey'"

        public override ParagonMode ParagonMode => ParagonMode.Base000;

        public override void ModifyBaseTowerModel(TowerModel tower)
        {
            var attackModel = tower.GetAttackModel();
            var projectile = attackModel.weapons[0].projectile;
            foreach (var weapon in tower.GetWeapons())
            {
                weapon.rate *= 0.3f;
                weapon.projectile.GetDamageModel().damage += 50;
            }
            tower.range -= 5;
            attackModel.range -= 10;
            projectile.pierce += 55;



        }

        /// <summary>
        /// Make Card Monkey go right after the Boomerang Monkey in the shop
        /// <br/>
        /// If we didn't have this, it would just put it at the end of the Primary section
        /// </summary>

        /// <summary>
        /// Support the Ultimate Crosspathing Mod by generating all the Tower Tiers if the mod exists
        /// <br/>
        /// That mod will handle actually allowing the upgrades to happen in the UI
        /// </summary>
        public override IEnumerable<int[]> TowerTiers()
        {
            if (MelonHandler.Mods.OfType<BloonsTD6Mod>().Any(m => m.GetModName() == "UltimateCrosspathing"))
            {
                for (var top = 0; top <= TopPathUpgrades; top++)
                {
                    for (var mid = 0; mid <= MiddlePathUpgrades; mid++)
                    {
                        for (var bot = 0; bot <= BottomPathUpgrades; bot++)
                        {
                            yield return new[] { top, mid, bot };
                        }
                    }
                }
            }
            else
            {
                foreach (var towerTier in base.TowerTiers())
                {
                    yield return towerTier;
                }
            }
        }
    }
}