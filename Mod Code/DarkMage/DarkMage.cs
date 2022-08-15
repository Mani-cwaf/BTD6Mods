﻿using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Models.Towers;
using Assets.Scripts.Models.TowerSets;
using BTD_Mod_Helper;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using MelonLoader;

namespace DarkMage
{
    /// <summary>
    /// The main class that adds the core tower to the game
    /// </summary>
    public class DarkMage : ModTower
    {
        // public override string Portrait => "Don't need to override this, using the default of Name-Portrait";
        // public override string Icon => "Don't need to override this, using the default of Name-Icon";

        public override string TowerSet => MAGIC;

        public override string BaseTower => TowerType.WizardMonkey;
        public override int Cost => 750;

        public override int TopPathUpgrades => 5;
        public override int MiddlePathUpgrades => 5;
        public override int BottomPathUpgrades => 5;
        public override string Description => "Accesses dark magic to use against the bloons";

        // public override string DisplayName => "Don't need to override this, the default turns it into 'Card Monkey'"

        public override ParagonMode ParagonMode => ParagonMode.Base000;

        public override void ModifyBaseTowerModel(TowerModel towerModel)
        {
            towerModel.range += 10;
            var attackModel = towerModel.GetAttackModel();
            attackModel.range += 10;
            foreach (var weaponModel in towerModel.GetWeapons())
            {
                weaponModel.rate = 1f;
                weaponModel.projectile.GetDamageModel().damage += 1;
            }


            var projectile = attackModel.weapons[0].projectile;
            //projectile.ApplyDisplay<ultraPulseDisplay>(); // Make the projectiles look like Cards
            projectile.pierce += 2;
        }

        /// <summary>
        /// Make Card Monkey go right after the Boomerang Monkey in the shop
        /// <br/>
        /// If we didn't have this, it would just put it at the end of the Primary section
        /// </summary>
        
        public override int GetTowerIndex(List<TowerDetailsModel> towerSet)
        {
            return towerSet.First(model => model.towerId == TowerType.WizardMonkey).towerIndex + 1;
        }

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