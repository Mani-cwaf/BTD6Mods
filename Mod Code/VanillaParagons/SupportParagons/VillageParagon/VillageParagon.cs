using Assets.Scripts.Models.Towers;
using Assets.Scripts.Models.Towers.Behaviors;
using Assets.Scripts.Models.Towers.Behaviors.Attack;
using Assets.Scripts.Models.Towers.TowerFilters;
using Assets.Scripts.Unity;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using UnhollowerBaseLib;

namespace VanillaParagons.SupportParagons.VillageParagon
{
    public class VillageParagonBase : ModVanillaParagon
    {
        public override string BaseTower => "MonkeyVillage-250";
    }
    public class VillageParagon : ModParagonUpgrade<VillageParagonBase>
    {
        public override string DisplayName => "Fortress Of Defence";
        public override int Cost => 645000;
        public override string Description => "Extremely powerful defence mechanisms allow the fortress to greatly enhance the capabilities of all towers.";
        //public override string Icon => "";
        //public override string Portrait => "";
        public override void ApplyUpgrade(TowerModel tower)
        {
            tower.AddBehavior(new RangeSupportModel("GodBoostingRange", true, 0, 10, "RangeMutator", null, false, "EnderGodBoost", "BuffIconTempleSunGod4xx"));
            tower.AddBehavior(new RateSupportModel("GodBoostingAttackSpeed", .5f, true, "AttackSpeedMutator", false, 0, null, "EnderGodBoost", "BuffIconTempleSunGod4xx"));
            tower.AddBehavior(new DamageSupportModel("GodBoostingDamage", true, 10, "DamageMutator", null, false, false, 0.0f));
            tower.AddBehavior(new PierceSupportModel("GodBoostingPierce", true, 20, "PierceMutator", null, false, "EnderGodBoost", "BuffIconTempleSunGod4xx"));
            tower.AddBehavior(new MonkeyCityIncomeSupportModel("GodBoostingIncome", true, 1.5f, null, "EnderGodBoost", "BuffIconTempleSunGod4xx"));
            tower.AddBehavior(new CashbackZoneModel("CashBackMrEnderTowerV4", 0.3f, 1, "MrEnderTowerV4", 1));
            tower.AddBehavior(new DiscountZoneModel("DiscountMrEnderTowerV4", 0.25f, 1, "DiscountZoneMrEnderTowerV4", "MrEnderTowerV4", true, 6, "EnderGodBoost", "BuffIconTempleSunGod4xx"));
            tower.AddBehavior(new VisibilitySupportModel("CamoMrEnderTowerV4", true, "CamoMutatorMrEnderTowerV4", new Il2CppReferenceArray<TowerFilterModel>(0), "EnderGodBoost", "BuffIconTempleSunGod4xx"));
            tower.AddBehavior(new DamageTypeSupportModel("BloonPropertiesMrEnderTowerV4", true, "BloonPropertiesMutatorMrEnderTowerV4", BloonProperties.None, new Il2CppReferenceArray<TowerFilterModel>(0), "EnderGodBoost", "BuffIconTempleSunGod4xx"));
            var ballistaAttack = Game.instance.model.GetTower(TowerType.MonkeyVillage, 5).GetBehaviors<AttackModel>()[1].Duplicate();
            tower.AddBehavior(ballistaAttack);
            var weapon = tower.GetWeapon();
            weapon.projectile.GetDamageModel().damage = 10000;
        }
    }
}