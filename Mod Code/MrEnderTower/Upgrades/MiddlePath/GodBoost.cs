using Assets.Scripts.Models.Towers;
using Assets.Scripts.Models.Towers.Behaviors;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;

namespace MrEnderTower.Upgrades.MiddlePath
{
    public class GodBoost : ModUpgrade<MrEnderTower>
    {
        public override int Path => MIDDLE;
        public override int Tier => 3;
        public override int Cost => 375000;

        public override string Description => "Increases stats by a large amount";

        public override void ApplyUpgrade(TowerModel tower)
        {
            tower.GetBehavior<RateSupportModel>().multiplier *= 0.55f;
            tower.GetBehavior<DamageSupportModel>().increase += 5;
            tower.GetBehavior<PierceSupportModel>().pierce += 10;
            tower.GetBehavior<RangeSupportModel>().additive += 10;
        }
    }
}