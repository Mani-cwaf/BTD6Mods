using Assets.Scripts.Models.Towers;
using BTD_Mod_Helper.Api.Towers;

namespace VanillaParagons.MilitaryParagons.MortarMonkeyParagon
{
    public class MortarMonkeyParagonBase : ModVanillaParagon
    {
        public override string BaseTower => "MortarMonkey-502";
    }
    public class MortarMonkeyParagon : ModParagonUpgrade<MortarMonkeyParagonBase>
    {
        public override string DisplayName => "Vengeful Terror Of The Night";
        public override int Cost => 2000000;
        public override string Description => "Power no one should posses.";
        //public override string Icon => "";
        //public override string Portrait => "";
        public override void ApplyUpgrade(TowerModel towerModel)
        {

        }
    }
}