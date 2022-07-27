using Assets.Scripts.Models.GenericBehaviors;
using Assets.Scripts.Models.Towers;
using Assets.Scripts.Models.Towers.Filters;
using Assets.Scripts.Models.Towers.Projectiles.Behaviors;
using Assets.Scripts.Utils;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using static FunPackOfFunExperiments.Main;

namespace BloonChipper
{
    public class BloonChipper : ModTower
    {

        public override string TowerSet => PRIMARY;
        public override string BaseTower => "DartMonkey";
        public override int Cost => 1855;
        public override int TopPathUpgrades => 0;
        public override int MiddlePathUpgrades => 0;
        public override int BottomPathUpgrades => 0;
        public override string Description => "Sucks in bloons popping them and pushes them back";
        public override SpriteReference IconReference => new SpriteReference("MonkeyIcons[GlueGunnerIcon]");
        public override SpriteReference PortraitReference => new SpriteReference("4cf5ed7ac85b3ad4cb921bf7b7a24e16");
        public override bool DontAddToShop => !AssassinMonkeyEnabled == true;
        public override ParagonMode ParagonMode => ParagonMode.Base000;

        //actual tower abilities
        public override void ModifyBaseTowerModel(TowerModel tower)
        {
            var attackModel = tower.GetAttackModel();
            var weapon = tower.GetWeapon();
            var projectile = weapon.projectile;
            projectile.GetBehavior<DisplayModel>().display = null;
            projectile.AddBehavior(new WindModel("BloonChipperWindModel", 75, 75, 1, false, "Wind", 0, "", 2));
            tower.range += 10;
            attackModel.range += 10;
        }
    }
}