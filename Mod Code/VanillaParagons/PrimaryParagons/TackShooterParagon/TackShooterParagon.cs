using Assets.Scripts.Models.Towers;
using BTD_Mod_Helper.Api.Towers;

namespace VanillaParagons.PrimaryParagons.TackShooterParagon
{
    public class TackShooterParagonBase : ModVanillaParagon
    {
        public override string BaseTower => "TackShooter-205";
    }
    public class TackShooterParagon : ModParagonUpgrade<TackShooterParagonBase>
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