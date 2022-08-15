using Assets.Scripts.Models.Towers;
using Assets.Scripts.Models.Towers.Behaviors;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;

namespace MrEnderTower.Upgrades.MiddlePath
{
    public class TowerBoost : ModUpgrade<MrEnderTower>
    {
        public override int Path => MIDDLE;
        public override int Tier => 2;
        public override int Cost => 195000;

        public override string Description => "Further increases attack speed, and bolts fly even faster";

        public override void ApplyUpgrade(TowerModel tower)
        {
            tower.AddBehavior(new RangeSupportModel("GodBoostingRange", true, 0, 5, "RangeMutator", null, false, "EnderGodBoost", "BuffIconTempleSunGod4xx"));
            tower.AddBehavior(new RateSupportModel("GodBoostingAttackSpeed", .333333f, true, "AttackSpeedMutator", false, 0, null, "EnderGodBoost", "BuffIconTempleSunGod4xx"));
            tower.AddBehavior(new DamageSupportModel("GodBoostingDamage", true, 4, "DamageMutator", null, false, false, 0.0f));
            tower.AddBehavior(new PierceSupportModel("GodBoostingPierce", true, 10, "PierceMutator", null, false, "EnderGodBoost", "BuffIconTempleSunGod4xx"));

        }
    }
}