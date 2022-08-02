using Assets.Scripts.Simulation.Towers;
using BTD_Mod_Helper;
using BTD_Mod_Helper.Api.ModOptions;
using HarmonyLib;
using MelonLoader;

[assembly: MelonInfo(typeof(OPTowers.Main), "OP Towers", "1.0.0", "Mani_Dev")]
[assembly: MelonGame("Ninja Kiwi", "BloonsTD6")]

namespace OPTowers
{
    public class Main : BloonsTD6Mod
    {
        public static readonly ModSettingBool ShaggyTowerEnabled = true;
        public static readonly ModSettingBool OPFreeDartMonkeyEnabled = false;
        public static readonly ModSettingBool OPFreeGlueGunnerEnabled = false;
    }
}