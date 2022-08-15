using Assets.Scripts.Models.Towers;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using Assets.Scripts.Models.Towers.Behaviors;

namespace MrEnderTower.Upgrades.BottomPath
{
    public class AuraOfInfinity : ModUpgrade<MrEnderTower>
    {
        public override int Path => MIDDLE;
        public override int Tier => 5;
        public override int Cost => 840000;
        public override string Description => "Buffs become global and improve greatly";
        public override void ApplyUpgrade(TowerModel tower)
        {
            tower.GetBehavior<RateSupportModel>().isGlobal = true;
            tower.GetBehavior<DamageSupportModel>().isGlobal = true;
            tower.GetBehavior<PierceSupportModel>().isGlobal = true;
            tower.GetBehavior<RangeSupportModel>().isGlobal = true;
            tower.GetBehavior<MonkeyCityIncomeSupportModel>().isGlobal = true;
            tower.GetBehavior<SupportShinobiTacticsModel>().isGlobalRange = true;
        }
    }
}