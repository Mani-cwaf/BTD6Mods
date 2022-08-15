using Assets.Scripts.Simulation.Towers;
using HarmonyLib;
using static VanillaParagons.Main;

namespace VanillaParagons
{
    [HarmonyPatch(typeof(TowerManager), nameof(TowerManager.IsParagonLocked))]
    internal static class TowerManager_IsParagonLocked
    {
        [HarmonyPostfix]
        private static void Postfix(Tower tower, ref bool __result)
        {
            if (EnableParagons == false)
            {
                __result = true;
            }
        }
    }
}
