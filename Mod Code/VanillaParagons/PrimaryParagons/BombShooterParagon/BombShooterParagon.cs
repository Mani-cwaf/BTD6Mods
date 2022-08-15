using Assets.Scripts.Models.Towers;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;

namespace VanillaParagons.PrimaryParagons.BombShooterParagon
{
    public class BombShooterParagonBase : ModVanillaParagon
    {
        public override string BaseTower => "BombShooter-025";
    }
    public class BombShooterParagon : ModParagonUpgrade<BombShooterParagonBase>
    {
        public override string DisplayName => "Vengeful Terror Of The Night";
        public override int Cost => 2000000;
        public override string Description => "Power no one should posses.";
        //public override string Icon => "";
        //public override string Portrait => "";
        public override void ApplyUpgrade(TowerModel tower)
        {
        }
    }
}