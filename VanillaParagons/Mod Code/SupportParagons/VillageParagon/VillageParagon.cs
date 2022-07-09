using Assets.Scripts.Models.Towers;
using Assets.Scripts.Models.Towers.Behaviors;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;

namespace VanillaParagons.SupportParagons.VillageParagon
{
    public class VillageParagonBase : ModVanillaParagon
    {
        public override string BaseTower => "MonkeyVillage-250";
    }
    public class VillageParagon : ModParagonUpgrade<VillageParagonBase>
    {
        public override string DisplayName => "Vengeful Terror Of The Night";
        public override int Cost => 2000000;
        public override string Description => "Power no one should posses.";
        //public override string Icon => "";
        //public override string Portrait => "";
        public override void ApplyUpgrade(TowerModel tower)
        {
            tower.AddBehavior(new RangeSupportModel("GodBoostingRange", true, 0, 5, "RangeMutator", null, false, "EnderGodBoost", "BuffIconTempleSunGod4xx"));
            tower.AddBehavior(new RateSupportModel("GodBoostingAttackSpeed", .666666f, true, "AttackSpeedMutator", false, 0, null, "EnderGodBoost", "BuffIconTempleSunGod4xx"));
            tower.AddBehavior(new DamageSupportModel("GodBoostingDamage", true, 5, "DamageMutator", null, false, false, 0.0f));
            tower.AddBehavior(new PierceSupportModel("GodBoostingPierce", true, 10, "PierceMutator", null, false, "EnderGodBoost", "BuffIconTempleSunGod4xx"));
            tower.AddBehavior(new MonkeyCityIncomeSupportModel("GodBoostingPierce", true, 1.5f, null, "EnderGodBoost", "BuffIconTempleSunGod4xx"));
            tower.AddBehavior(new CashbackZoneModel("CashBackMrEnderTowerV4", 0.075f, 1, "MrEnderTowerV4", 4));
            tower.AddBehavior(new DiscountZoneModel("DiscountMrEnderTowerV4", 0.075f, 4, "DiscountZoneMrEnderTowerV4", "MrEnderTowerV4", true, 6, "EnderGodBoost", "BuffIconTempleSunGod4xx"));
            tower.AddBehavior(tower.GetAbility());
        }
    }
}