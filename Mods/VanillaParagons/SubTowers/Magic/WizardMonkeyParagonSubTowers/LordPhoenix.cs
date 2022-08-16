using Assets.Scripts.Models.Towers;
using Assets.Scripts.Models.Towers.Behaviors;
using Assets.Scripts.Models.Towers.Behaviors.Attack;
using Assets.Scripts.Models.Towers.Behaviors.Attack.Behaviors;
using Assets.Scripts.Models.Towers.Filters;
using Assets.Scripts.Models.Towers.Projectiles.Behaviors;
using Assets.Scripts.Models.TowerSets;
using Assets.Scripts.Unity;
using Assets.Scripts.Unity.Display;
using BTD_Mod_Helper.Api;
using BTD_Mod_Helper.Api.Display;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using MelonLoader;
using System.Collections.Generic;
using UnhollowerBaseLib;
using UnityEngine;
using System.Linq;
using Assets.Scripts.Models.Towers.Weapons.Behaviors;

namespace SubTowers.LordPhenix
{
    class LordPhoenix : ModTower
    {
        public override string Name => "WizardParagonLordPheonix";
        public override string TowerSet => MAGIC;
        public override string BaseTower => "LordPhoenix";
        public override int Cost => 0;

        public override int TopPathUpgrades => 0;
        public override int MiddlePathUpgrades => 0;
        public override int BottomPathUpgrades => 0;

        public override string DisplayName => "Yin-Yang";
        public override string Description => "";
        public override bool DontAddToShop => true;

        public override void ModifyBaseTowerModel(TowerModel tower)
        {
            tower.ApplyDisplay<LordPhoenixDisplay>();
            var weapon = tower.GetWeapon();
            var projectile = weapon.projectile;
            var fireballweapon = tower.GetWeapon(1);
            var fireballprojectile = fireballweapon.projectile;
            var fireballprojectilealternate = fireballweapon.GetBehavior<AlternateProjectileModel>().projectile;
            fireballprojectile.AddBehavior(new TrackTargetModel("WizardParagonLordPheonixTrackTargetModel", 999999, true, true, 360, true, 800, false, false));
            fireballprojectile.AddBehavior(new DamageModifierForTagModel("DamageModifierForTagModel_Moabs", "Moabs", 1, 50, false, false));
            fireballprojectile.GetDamageModel().damage = 150;
            fireballprojectilealternate.AddBehavior(new TrackTargetModel("WizardParagonLordPheonixTrackTargetModel", 999999, true, true, 360, true, 800, false, false));
            fireballprojectilealternate.AddBehavior(new DamageModifierForTagModel("DamageModifierForTagModel_Moabs", "Moabs", 1, 50, false, false));
            fireballprojectilealternate.GetDamageModel().damage = 150;
            projectile.GetDamageModel().damage = 50;
            tower.RemoveBehavior<TowerExpireModel>();
        }
        public class LordPhoenixDisplay : ModTowerDisplay<LordPhoenix>
        {
            public override string BaseDisplay => GetDisplay(TowerType.WizardLordPhoenix);

            public override bool UseForTower(int[] tiers)
            {
                return IsParagon(tiers);
            }

            public override int ParagonDisplayIndex => 0;

            public override void ModifyDisplayNode(UnityDisplayNode node)
            {
                foreach (var renderer in node.genericRenderers)
                {
                }
            }
        }
    }
}
