using Assets.Scripts.Models.Towers;
using BTD_Mod_Helper.Api.Towers;

namespace VanillaParagons.MilitaryParagons.MonkeySubParagon
{
    public class MonkeySubParagonBase : ModVanillaParagon
    {
        public override string BaseTower => "MonkeySub-250";
    }
    public class MonkeySubParagon : ModParagonUpgrade<MonkeySubParagonBase>
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