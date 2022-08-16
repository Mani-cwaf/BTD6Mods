using Assets.Scripts.Models.Towers;
using Assets.Scripts.Models.Towers.Behaviors;
using Assets.Scripts.Models.Towers.Behaviors.Attack;
using Assets.Scripts.Models.Towers.Behaviors.Emissions;
using Assets.Scripts.Models.Towers.Filters;
using Assets.Scripts.Models.Towers.Projectiles.Behaviors;
using Assets.Scripts.Models.TowerSets;
using Assets.Scripts.Unity;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using SubTowers.LordPhenix;
using System.Collections.Generic;
using System.Linq;
using static VanillaParagons.Main;

namespace VanillaParagons.MagicParagons.WizardMonkeyParagon.Buffable
{
    public class WizardMonkeyParagonBuffable : ModTower
    {
        public override string DisplayName => "Buffable Grand Mage";
        public override string TowerSet => MAGIC;
        public override bool DontAddToShop => !EnableBuffableParagons;
        public override string BaseTower => "WizardMonkey-502";
        public override int Cost => 900000;
        public override int TopPathUpgrades => 0;
        public override int MiddlePathUpgrades => 1;
        public override int BottomPathUpgrades => 0;
        public override string Description => "Buffable version of the Grand Mage";
        public override void ModifyBaseTowerModel(TowerModel tower)
        {
            var attackModel = tower.GetAttackModel();
            var dragonsBreathWeapon = tower.GetWeapon(2);
            var weapon = tower.GetWeapon();
            var projectile = weapon.projectile;
            var dragonsBreath = dragonsBreathWeapon.projectile;
            tower.AddBehavior(new TowerCreateTowerModel("CreateLordPhoenix", GetTowerModel<LordPhoenix>().Duplicate(), true));
            projectile.GetDamageModel().damage += 150;
            projectile.AddBehavior(new DamageModifierForTagModel("MOAB", "Moabs", 1, 50, false, true));
            projectile.AddBehavior(new DamageModifierForTagModel("Boss", "Boss", 2.5f, 0, false, true));
            weapon.rate *= 0.5f;
            dragonsBreath.GetDamageModel().damage += 50;
            dragonsBreath.AddBehavior(new DamageModifierForTagModel("MOAB", "Moabs", 1, 35, false, true));
            dragonsBreath.AddBehavior(new DamageModifierForTagModel("Boss", "Boss", 2.5f, 0, false, true));
            dragonsBreathWeapon.rate *= 0.6f;
            tower.AddBehavior(Game.instance.model.GetTowerFromId("WizardMonkey-004").GetBehavior<NecromancerZoneModel>().Duplicate());
            tower.AddBehavior(Game.instance.model.GetTowerFromId("WizardMonkey-004").GetBehaviors<AttackModel>().First(a => a.name == "AttackModel_Attack Necromancer_").Duplicate());
            var SpawnUltraBloon = tower.GetAttackModel(3);
            var SpawnUltraBloonWeapon = SpawnUltraBloon.weapons[0];
            var SpawnUltraBloonProjectile = SpawnUltraBloonWeapon.projectile;
            SpawnUltraBloonProjectile.GetBehavior<TravelAlongPathModel>().lifespanFrames = 99999;
            SpawnUltraBloonProjectile.GetBehavior<TravelAlongPathModel>().disableRotateWithPathDirection = false;
            SpawnUltraBloonProjectile.GetDamageModel().damage = 1000;
            SpawnUltraBloonProjectile.radius = 10;
            SpawnUltraBloonProjectile.pierce = 100;
            SpawnUltraBloonWeapon.emission.Cast<NecromancerEmissionModel>().maxPiercePerBloon = 1;
            SpawnUltraBloonWeapon.fireWithoutTarget = true;
            SpawnUltraBloonWeapon.rate = 2;
            SpawnUltraBloon.range = 999;
            tower.GetBehavior<NecromancerZoneModel>().attackUsedForRangeModel.range = 999;
            var fireStorm = Game.instance.model.GetTower(TowerType.WizardMonkey, 1, 2, 0).behaviors.First(a => a.name.Contains("Wall")).Cast<AttackModel>().Duplicate();
            fireStorm.weapons[0].projectile.GetBehavior<AgeModel>().lifespan = 1.25f;
            fireStorm.weapons[0].projectile.GetDamageModel().damage = 500;
            fireStorm.weapons[0].Rate *= 0.1f;
            fireStorm.weapons[0].fireWithoutTarget = false;
            tower.AddBehavior(fireStorm);
            tower.GetDescendants<FilterInvisibleModel>().ForEach(model => model.isActive = false);
        }
        public override int GetTowerIndex(List<TowerDetailsModel> towerSet)
        {
            return towerSet.First(model => model.towerId == TowerType.WizardMonkey).towerIndex + 1;
        }
        public class WizardMonkeyParagonBuffableDegree100 : ModUpgrade<WizardMonkeyParagonBuffable>
        {
            public override string DisplayName => "Degree 100";
            public override string Description => "Degree 100";
            public override int Cost => 0;
            public override int Path => MIDDLE;
            public override int Tier => 1;
            public override void ApplyUpgrade(TowerModel tower)
            {
                var fireStorm = tower.behaviors.First(a => a.name.Contains("Wall")).Cast<AttackModel>().Duplicate();
                var dragonsBreathWeapon = tower.GetWeapon(2);
                var weapon = tower.GetWeapon();
                var projectile = weapon.projectile;
                var dragonsBreath = dragonsBreathWeapon.projectile;
                fireStorm.weapons[0].Rate *= 0.1f;
                weapon.rate *= 0.642857f;
                dragonsBreathWeapon.rate *= 0.642857f;
                projectile.GetDamageModel().damage *= 2.5f;
                dragonsBreath.GetDamageModel().damage *= 2.5f;
                fireStorm.weapons[0].projectile.GetDamageModel().damage *= 2.5f;
                projectile.pierce *= 2.5f;
                dragonsBreath.pierce *= 2.5f;
                fireStorm.weapons[0].projectile.GetBehavior<AgeModel>().lifespan *= 1.5f;
            }
        }
    }
}
