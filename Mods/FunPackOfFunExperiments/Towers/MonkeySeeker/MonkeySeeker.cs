using Assets.Scripts.Models.Towers;
using Assets.Scripts.Models.Towers.Projectiles.Behaviors;
using Assets.Scripts.Unity;
using BTD_Mod_Helper.Api.Enums;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using System.Linq;
using static FunPackOfFunExperiments.Main;

namespace MonkeySeeker
{
    public class MonkeySeeker : ModTower
    {
        public override string TowerSet => TowerSetType.Magic;
        public override string BaseTower => TowerType.DartMonkey;
        public override int Cost => 1265;
        public override int TopPathUpgrades => 1;
        public override int MiddlePathUpgrades => 0;
        public override int BottomPathUpgrades => 0;
        public override string Description => "Attacks with seeking ultrafast crystals";
        //public override SpriteReference IconReference => new SpriteReference("MonkeyIcons[GlueGunnerIcon]");
        //public override SpriteReference PortraitReference => new SpriteReference("4cf5ed7ac85b3ad4cb921bf7b7a24e16");
        public override bool DontAddToShop => !MonkeySeekerEnabled == true;
        public override ParagonMode ParagonMode => ParagonMode.Base000;
        public override void ModifyBaseTowerModel(TowerModel tower)
        {
            var weapon = tower.GetWeapon();
            var projectile = weapon.projectile;
            projectile.pierce = 10;
            projectile.AddBehavior(Game.instance.model.GetTower(TowerType.BoomerangMonkey, 3).GetWeapon().projectile.behaviors.First(a => a.name.Contains("RetargetOnContactModel_")).Cast<RetargetOnContactModel>().Duplicate());
            projectile.GetBehavior<TravelStraitModel>().speed = 800;
            projectile.GetBehavior<TravelStraitModel>().lifespan = 4;
        }
    }
    public class DenseCrystals : ModUpgrade<MonkeySeeker>
    {
        public override string DisplayName => "Dense Crystals";
        public override string Description => "projectiles move slower allowing for more precision and deals more damage";
        public override int Cost => 1200;
        public override int Path => TOP;
        public override int Tier => 1;
        public override void ApplyUpgrade(TowerModel tower)
        {
            var attackModel = tower.GetAttackModel();
            var weapon = tower.GetWeapon();
            var projectile = weapon.projectile;
            projectile.GetBehavior<TravelStraitModel>().speed *= 0.6f;
            projectile.GetDamageModel().damage = 3;
        }
    }
}