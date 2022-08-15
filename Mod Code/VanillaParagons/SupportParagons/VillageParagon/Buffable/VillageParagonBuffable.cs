using Assets.Scripts.Models.Towers;
using Assets.Scripts.Models.Towers.Behaviors;
using Assets.Scripts.Models.Towers.Behaviors.Attack;
using Assets.Scripts.Models.Towers.Behaviors.Emissions;
using Assets.Scripts.Models.Towers.Projectiles.Behaviors;
using Assets.Scripts.Models.Towers.TowerFilters;
using Assets.Scripts.Models.TowerSets;
using Assets.Scripts.Unity;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using SubTowers.LordPhenix;
using System.Collections.Generic;
using System.Linq;
using UnhollowerBaseLib;
using static VanillaParagons.Main;

namespace VanillaParagons.SupportParagons.VillageParagon.Buffable
{
    public class VillageParagonBuffable : ModTower
    {
        public override string DisplayName => "Buffable Fortress Of Defence";
        public override string TowerSet => SUPPORT;
        public override bool DontAddToShop => !EnableBuffableParagons;
        public override string BaseTower => "MonkeyVillage-250";
        public override int Cost => 900000;
        public override int TopPathUpgrades => 0;
        public override int MiddlePathUpgrades => 1;
        public override int BottomPathUpgrades => 0;
        public override string Description => "Buffable version of the Fortress Of Defence";
        public override void ModifyBaseTowerModel(TowerModel tower)
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
        public override int GetTowerIndex(List<TowerDetailsModel> towerSet)
        {
            return towerSet.First(model => model.towerId == TowerType.MonkeyVillage).towerIndex + 1;
        }
        public class VillageParagonBuffableDegree100 : ModUpgrade<VillageParagonBuffable>
        {
            public override string DisplayName => "Degree 100";
            public override string Description => "Degree 100";
            public override int Cost => 0;
            public override int Path => MIDDLE;
            public override int Tier => 1;
            public override void ApplyUpgrade(TowerModel tower)
            {
                var weapon = tower.GetWeapon();
                var projectile = weapon.projectile;
                weapon.rate *= 0.642857f;
                projectile.GetDamageModel().damage *= 2.5f;
                projectile.pierce *= 2.5f;
                tower.GetBehavior<RangeSupportModel>().additive += 10;
                tower.GetBehavior<RateSupportModel>().multiplier *= 0.4f;
                tower.GetBehavior<DamageSupportModel>().increase += 10;
                tower.GetBehavior<PierceSupportModel>().pierce += 20;
                tower.GetBehavior<MonkeyCityIncomeSupportModel>().incomeModifier = 2;
            }
        }
    }
}
