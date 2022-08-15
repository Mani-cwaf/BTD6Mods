using Assets.Scripts.Models.Towers;
using Assets.Scripts.Models.Towers.Behaviors;
using Assets.Scripts.Models.Towers.Behaviors.Emissions;
using Assets.Scripts.Models.Towers.Filters;
using Assets.Scripts.Models.Towers.Weapons.Behaviors;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using MelonLoader;

namespace MrEnderTower.Upgrades.MiddlePath
{
    public class UltimateBoost : ModUpgrade<MrEnderTower>
    {
        public override int Path => MIDDLE;
        public override int Tier => 4;
        public override int Cost => 550000;

        public override string Description => "More powerful boosts to increase income";

        public override void ApplyUpgrade(TowerModel tower)
        {
            tower.GetBehavior<RateSupportModel>().multiplier *= 0.55f;
            tower.GetBehavior<DamageSupportModel>().increase += 5;
            tower.GetBehavior<PierceSupportModel>().pierce += 10;
            tower.GetBehavior<RangeSupportModel>().additive += 10;
            tower.AddBehavior(new MonkeyCityIncomeSupportModel("GodBoostingPierce", true, 1.5f, null, "EnderGodBoost", "BuffIconTempleSunGod4xx"));

        }
    }
}