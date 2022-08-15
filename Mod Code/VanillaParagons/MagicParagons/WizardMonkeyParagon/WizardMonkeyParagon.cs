using Assets.Scripts.Models.Towers;
using Assets.Scripts.Models.Towers.Behaviors;
using Assets.Scripts.Models.Towers.Behaviors.Attack;
using Assets.Scripts.Models.Towers.Behaviors.Emissions;
using Assets.Scripts.Models.Towers.Filters;
using Assets.Scripts.Models.Towers.Projectiles.Behaviors;
using Assets.Scripts.Unity;
using Assets.Scripts.Unity.Display;
using BTD_Mod_Helper.Api.Display;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using SubTowers.LordPhenix;
using System.Linq;

namespace VanillaParagons.MagicParagons.WizardMonkeyParagon
{
    public class WizardMonkeyParagonBase : ModVanillaParagon
    {
        public override string BaseTower => "WizardMonkey-502";
    }
    public class WizardMonkeyParagon : ModParagonUpgrade<WizardMonkeyParagonBase>
    {
        public override string DisplayName => "Grand Mage";
        public override int Cost => 825000;
        public override string Description => "Controls insane levels of magic";
        public override void ApplyUpgrade(TowerModel tower)
        {
            var attackModel = tower.GetAttackModel();
            var dragonsBreathWeapon = tower.GetWeapon(2);
            var weapon = tower.GetWeapon();
            var projectile = weapon.projectile;
            var dragonsBreath = dragonsBreathWeapon.projectile;
            tower.AddBehavior(new TowerCreateTowerModel("CreateLordPhoenix", GetTowerModel<LordPhoenix>().Duplicate(), true));
            projectile.GetDamageModel().damage += 200;
            projectile.AddBehavior(new DamageModifierForTagModel("Boss", "Boss", 2.5f, 0, false, true));
            weapon.rate *= 0.5f;
            dragonsBreath.GetDamageModel().damage += 85;
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
        public class GrandMageDisplay : ModTowerDisplay<WizardMonkeyParagonBase>
        {
            public override string BaseDisplay => GetDisplay(TowerType.WizardMonkey, 5, 0, 2);

            public override bool UseForTower(int[] tiers)
            {
                return IsParagon(tiers);
            }

            public override int ParagonDisplayIndex => 0;

            public override void ModifyDisplayNode(UnityDisplayNode node)
            {
                foreach (var renderer in node.genericRenderers)
                {
                    //renderer.material.mainTexture = GetTexture("SuperbGlue_Display");
                    //node.SaveMeshTexture();
                }
            }
        }
    }
}