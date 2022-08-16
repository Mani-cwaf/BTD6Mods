using BTD_Mod_Helper;
using BTD_Mod_Helper.Api.ModOptions;
using MelonLoader;

[assembly: MelonInfo(typeof(MrEnderTower.Main), "Mr Ender Tower", "1.0.0", "Mani_Dev")]
[assembly: MelonGame("Ninja Kiwi", "BloonsTD6")]

namespace MrEnderTower
{
    public class Main : BloonsTD6Mod
    {
        public override string MelonInfoCsURL =>
            "https://github.com/Mani-cwaf/BTD6Mods/blob/main/MrEnderTower/Mod%20Code/Main.cs";

        public override string LatestURL =>
            "https://github.com/Mani-cwaf/BTD6Mods/raw/main/MrEnderTower/Mod%20File/MrEnderTower.dll";

    }

}
