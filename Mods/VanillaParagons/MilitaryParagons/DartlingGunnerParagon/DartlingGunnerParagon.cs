using Assets.Scripts.Models;
using Assets.Scripts.Models.GenericBehaviors;
using Assets.Scripts.Models.Towers;
using Assets.Scripts.Models.Towers.Behaviors.Attack.Behaviors;
using Assets.Scripts.Models.Towers.Behaviors.Emissions;
using Assets.Scripts.Models.Towers.Projectiles.Behaviors;
using Assets.Scripts.Simulation;
using Assets.Scripts.Simulation.Behaviors;
using Assets.Scripts.Simulation.Towers;
using Assets.Scripts.Unity.Display;
using BTD_Mod_Helper.Api.Display;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;

namespace VanillaParagons.MilitaryParagons.DartlingGunnerParagon
{
    public class DartlingGunnerParagonBase : ModVanillaParagon
    {
        public override string BaseTower => "DartlingGunner-250";
    }
    public class DartlingGunnerParagon : ModParagonUpgrade<DartlingGunnerParagonBase>
    {
        public override string DisplayName => "Ray of Annihilation";
        public override int Cost => 860000;
        public override string Description => "A solid ray of extreme moab popping power.";
        //public override string Icon => "";
        //public override string Portrait => "";
        public override void ApplyUpgrade(TowerModel tower)
        {
            var attackModel = tower.GetAttackModel();
            var weapon = tower.GetWeapon();
            var projectile = weapon.projectile;
            weapon.emission = new RandomEmissionModel("DartlingGunnerEmissionModel", 1, 2, 0, null, false, 1, 1, 0, false);
            weapon.rate *= .015f;
            projectile.AddBehavior(new KnockbackModel("DartlingGunnerKnockbackModel", 1.1f, 1.1f, 1.1f, 0.4f, "KnockbackKnockback", null));
            projectile.GetBehavior<DamageModifierForTagModel>().damageAddative = 35;
            projectile.GetDamageModel().damage = 5;
            projectile.GetDamageModel().immuneBloonProperties = BloonProperties.None;
            projectile.pierce = 10;
        }
        public class DestructionOfDoomDisplay : ModTowerDisplay<DartlingGunnerParagonBase>
        {
            public override string BaseDisplay => GetDisplay(TowerType.DartlingGunner, 5);

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
                    node.PrintInfo();
                }
            }
        }
        public class DestructionOfDoomProjectileDisplay : ModDisplay
        {
            public override string BaseDisplay => "17d97a491cfa0154095f42ec1c5dae2d";
            public override void ModifyDisplayNode(UnityDisplayNode node)
            {
                foreach (var renderer in node.genericRenderers)
                {
                    //node.GetComponent
                    //renderer.material.mainTexture = GetTexture("SuperbGlue_Display");
                    //node.SaveMeshTexture();
                    node.PrintInfo();
                }
            }
        }
    }
}