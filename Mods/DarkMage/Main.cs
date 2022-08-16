using BTD_Mod_Helper;
using BTD_Mod_Helper.Api.ModOptions;
using MelonLoader;

[assembly: MelonInfo(typeof(DarkMage.Main), "Dark Mage", "1.0.0", "Mani_Dev")]
[assembly: MelonGame("Ninja Kiwi", "BloonsTD6")]

namespace DarkMage
{
    public class Main : BloonsTD6Mod
    {
        public static readonly ModSettingBool ParagonOverPowered = true;

        public override string MelonInfoCsURL =>
            "https://github.com/Mani-cwaf/BTD6Mods/blob/main/DarkMage/DarkMage.cs";

        public override string LatestURL =>
            "https://github.com/Mani-cwaf/BTD6Mods/blob/main/DarkMage/DarkMage.dll?raw=true";

    }

}
