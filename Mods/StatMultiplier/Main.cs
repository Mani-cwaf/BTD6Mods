using MelonLoader;
using Assets.Scripts.Simulation;
using BTD_Mod_Helper;
using BTD_Mod_Helper.Api.ModOptions;
using Assets.Scripts.Models;
using Assets.Scripts.Models.Towers.Mods;
using Il2CppSystem.Collections.Generic;
using BTD_Mod_Helper.Extensions;

[assembly: MelonInfo(typeof(StatMultiplier.StatMultiplierClass), "StatMultiplier", "1.0.0", "Mani_Dev")]
[assembly: MelonGame("Ninja Kiwi", "BloonsTD6")]
namespace StatMultiplier
{
	public class StatMultiplierClass : BloonsTD6Mod
    {

        public override string MelonInfoCsURL =>
            "https://github.com/Mani-cwaf/BTD6Mods/blob/main/StatMultiplier/Main.cs";

        public override string LatestURL =>
            "https://github.com/Mani-cwaf/BTD6Mods/blob/main/StatMultiplier/StatMultiplier.dll?raw=true";

        public override void OnMainMenu()
        {
            base.OnMainMenu();
        }

        public override void OnApplicationStart()
        {
            base.OnApplicationStart();
            MelonLogger.Msg("StatMultiplier Loaded!");
        }

        private static readonly ModSettingDouble Cash = new ModSettingDouble(1.0)
        {
            displayName = "Cash Multiplier (Min 0.1 Max 1000)",
            minValue = 0.1,
            maxValue = 1000.0,
            isSlider = false
        };

        private static readonly ModSettingDouble Damage = new ModSettingDouble(1.0)
        {
            displayName = "Damage Multiplier (Min 0.1 Max 1000)",
            minValue = 0.1,
            maxValue = 1000.0,
            isSlider = false
        };

        private static readonly ModSettingDouble Speed = new ModSettingDouble(1.0)
        {
            displayName = "Attack Speed Multiplier (Min 0.1 Max 1000)",
            minValue = 0.1,
            maxValue = 1000.0,
            isSlider = false
        };

        private static readonly ModSettingDouble Pierce = new ModSettingDouble(1.0)
        {
            displayName = "Pierce Multiplier (Min 0.1 Max 1000)",
            minValue = 0.1,
            maxValue = 1000.0,
            isSlider = false
        };

        private static readonly ModSettingDouble Range = new ModSettingDouble(1.0)
        {
            displayName = "Range Multiplier (Min 0.1 Max 5)",
            minValue = 0.1,
            maxValue = 5.0,
            isSlider = false
        };

        [HarmonyLib.HarmonyPatch(typeof(Simulation), "AddCash")]
        public class Mcash
        {
            [HarmonyLib.HarmonyPrefix]
            public static bool Prefix(ref double c, ref Simulation.CashSource source)
            {
                if (source != Simulation.CashSource.CoopTransferedCash && source != Simulation.CashSource.TowerSold) c *= Cash;
                return true;

            }
        }
        public override void OnNewGameModel(GameModel gameModel, List<ModModel> mods)
        {
            foreach (var towerModel in gameModel.towers)
            {
                towerModel.range *= (float)Range;

                if (towerModel.GetAttackModels().Count > 0)
                {
                    foreach (var attackModel in towerModel.GetAttackModels())
                    {
                        attackModel.range *= (float)Range;
                    }
                }

                if (towerModel.GetWeapons().Count > 0)
                {
                    foreach (var weapon in towerModel.GetWeapons())
                    {
                        if (weapon.projectile.GetDamageModel() != null)
                        {
                            weapon.projectile.GetDamageModel().damage *= (float)Damage;
                        }
                        weapon.rate *= (float)(1.0f / Speed);
                        weapon.projectile.pierce *= (float)Pierce;
                    }
                }
            }
        }
    }
}
    