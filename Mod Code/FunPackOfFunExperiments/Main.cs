using Assets.Scripts.Simulation.Towers;
using BTD_Mod_Helper;
using BTD_Mod_Helper.Api.ModOptions;
using HarmonyLib;
using MelonLoader;

[assembly: MelonInfo(typeof(FunPackOfFunExperiments.Main), "Fun Pack Of Fun Experiments", "1.0.0", "Mani_Dev")]
[assembly: MelonGame("Ninja Kiwi", "BloonsTD6")]

namespace FunPackOfFunExperiments
{
    public class Main : BloonsTD6Mod
    {
        public static readonly ModSettingBool AssassinMonkeyEnabled = true;
        public static readonly ModSettingBool BombTurretBuilderEnabled = true;
        public static readonly ModSettingBool FireSniperEnabled = true;
        public static readonly ModSettingBool MonkeySeekerEnabled = true;
        public static readonly ModSettingBool GrandFatherOfQuincyEnabled = true;
    }
}