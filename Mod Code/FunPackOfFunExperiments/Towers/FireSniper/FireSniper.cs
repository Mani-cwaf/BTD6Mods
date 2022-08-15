using Assets.Scripts.Models.Bloons.Behaviors;
using Assets.Scripts.Models.Effects;
using Assets.Scripts.Models.Towers;
using Assets.Scripts.Models.Towers.Behaviors.Emissions;
using Assets.Scripts.Models.Towers.Filters;
using Assets.Scripts.Models.Towers.Projectiles;
using Assets.Scripts.Models.Towers.Projectiles.Behaviors;
using Assets.Scripts.Unity;
using Assets.Scripts.Utils;
using BTD_Mod_Helper.Api.Enums;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using System.Linq;
using static FunPackOfFunExperiments.Main;


namespace FireSniper
{
    public class FireSniper : ModTower
    {
        public override string TowerSet => TowerSetType.Military;
        public override string BaseTower => "SniperMonkey";
        public override int Cost => 965;
        public override int TopPathUpgrades => 5;
        public override int MiddlePathUpgrades => 0;
        public override int BottomPathUpgrades => 1;
        public override string Description => "Shoots incendiary rounds at bloons.";
        public override bool DontAddToShop => !FireSniperEnabled == true;
        public override ParagonMode ParagonMode => ParagonMode.Base000;
        public override void ModifyBaseTowerModel(TowerModel tower)
        {
            var weapon = tower.GetWeapon();
            var projectile = weapon.projectile;
            var DOT = new DamageOverTimeModel("FireSniperDamageOverTimeModel", 1, 1, BloonProperties.Purple, null, 2, false, 0, false, 0, false, true, null);
            var DOTModel = new AddBehaviorToBloonModel("FireSniperAddBehaviorToBloonModel", "", 2, 999999, null, null, null, "Fire", true, false, true, false, 0, true, 0);
            DOTModel.AddBehavior(DOT);
            projectile.AddBehavior(DOTModel);
            projectile.collisionPasses = new int[] { -1, 0, 1 };
            projectile.GetDamageModel().immuneBloonProperties = BloonProperties.None;
        }
    }
    public class EnhancedScope : ModUpgrade<FireSniper>
    {
        public override string DisplayName => "Enhanced Scope";
        public override string Description => "Can target camo bloons and deals much more fire damage to them";
        public override int Cost => 1350;
        public override int Path => BOTTOM;
        public override int Tier => 1;
        public override void ApplyUpgrade(TowerModel tower)
        {
            var attackmodel = tower.GetAttackModel();
            var weapon = tower.GetWeapon();
            var projectile = weapon.projectile;
            tower.GetDescendants<FilterInvisibleModel>().ForEach(invisibleModel => invisibleModel.isActive = false);
            attackmodel.GetDescendants<ProjectileModel>().ForEach(projectileModel => projectileModel.GetBehavior<AddBehaviorToBloonModel>().GetBehavior<DamageOverTimeModel>().damageModifierModels = new[] { new DamageModifierForTagModel("DamageModifierForBloonTagModel", "Camo", 1, 4, true, true) });
        }
    }

    public class ExplosiveBullets : ModUpgrade<FireSniper>
    {
        public override string DisplayName => "Combusting bullets";
        public override string Description => "bullets now create firey explosions";
        public override int Cost => 2800;
        public override int Path => TOP;
        public override int Tier => 1;
        public override void ApplyUpgrade(TowerModel tower)
        {
            var attackModel = tower.GetAttackModel();
            var weapon = tower.GetWeapon();
            var projectile = weapon.projectile;
            var explosion = Game.instance.model.GetTower(TowerType.MortarMonkey, 0, 0, 2).GetDescendants<ProjectileModel>().ToIl2CppList().First(a => a.name.Contains("ProjectileModel_Explosion")).Duplicate();
            projectile.AddBehavior(new CreateProjectileOnContactModel("FireSniperCreateProjectileOnContactModel", explosion, new SingleEmissionModel("FireSniperSingleEmissionModel", null), false, false, true));
            explosion.AddBehavior(new CreateEffectOnContactModel("FireSniperCreateEffectOnContactModel", new EffectModel("", "6d84b13b7622d2744b8e8369565bc058", 0.6f, 1, false, false, false, false, false, false, false)));
            explosion.GetBehavior<AddBehaviorToBloonModel>().lifespan = 1.5f;
            explosion.GetBehavior<AddBehaviorToBloonModel>().GetBehavior<DamageOverTimeModel>().displayLifetime = 1.5f;
            explosion.GetBehavior<AddBehaviorToBloonModel>().GetBehavior<DamageOverTimeModel>().interval = 0.5f;
            explosion.GetDamageModel().immuneBloonProperties = BloonProperties.None;
            projectile.collisionPasses = new int[] { -1, 0, 1 };
        }
    }
    public class StunningExplosiveBullets : ModUpgrade<FireSniper>
    {
        public override string DisplayName => "Heat Shock bullets";
        public override string Description => "explosions stun bloons for a short time";
        public override int Cost => 6750;
        public override int Path => TOP;
        public override int Tier => 2;
        public override void ApplyUpgrade(TowerModel tower)
        {
            var attackModel = tower.GetAttackModel();
            var weapon = tower.GetWeapon();
            var projectile = weapon.projectile;
            var explosion = attackModel.GetDescendants<ProjectileModel>().ToIl2CppList()[1];
            explosion.AddBehavior(Game.instance.model.GetTower(TowerType.BombShooter, 4).GetDescendants<ProjectileModel>().ToIl2CppList()[1].GetBehavior<SlowModel>().Duplicate());
            explosion.GetBehavior<SlowModel>().lifespan *= 0.4f;
        }
    }
    public class RocketBullets : ModUpgrade<FireSniper>
    {
        public override string DisplayName => "Rocket Bullets";
        public override string Description => "bullets now have much more attack speed and fire ticks faster";
        public override int Cost => 10800;
        public override int Path => TOP;
        public override int Tier => 3;
        public override void ApplyUpgrade(TowerModel tower)
        {
            var attackModel = tower.GetAttackModel();
            var weapon = tower.GetWeapon();
            var projectile = weapon.projectile;
            var explosion = attackModel.GetDescendants<ProjectileModel>().ToIl2CppList()[1];
            attackModel.GetDescendants<ProjectileModel>().ForEach(projectileModel => projectileModel.GetBehavior<AddBehaviorToBloonModel>().GetBehavior<DamageOverTimeModel>().interval *= 0.75f);
            weapon.rate *= 0.4f;
            explosion.GetBehavior<SlowModel>().lifespan *= 1.25f;
        }
    }
    public class AHundredDegrees : ModUpgrade<FireSniper>
    {
        public override string DisplayName => "A Hundred Degrees";
        public override string Description => "Fire and bullets deal more moab damage";
        public override int Cost => 18575;
        public override int Path => TOP;
        public override int Tier => 4;
        public override void ApplyUpgrade(TowerModel tower)
        {
            var attackModel = tower.GetAttackModel();
            var weapon = tower.GetWeapon();
            var projectile = weapon.projectile;
            var explosion = attackModel.GetDescendants<ProjectileModel>().ToIl2CppList()[1];
            tower.GetDescendants<FilterInvisibleModel>().ForEach(invisibleModel => invisibleModel.isActive = false);
            attackModel.GetDescendants<ProjectileModel>().ForEach(projectileModel => projectileModel.GetBehavior<AddBehaviorToBloonModel>().GetBehavior<DamageOverTimeModel>().damageModifierModels = new[] { new DamageModifierForTagModel("DamageModifierForBloonTagModel", "Moabs", 1, 26, true, true) });
            explosion.pierce += 20;
            explosion.GetBehavior<SlowModel>().lifespan *= 1.35f;
        }
    }
    public class AThousandDegrees : ModUpgrade<FireSniper>
    {
        public override string DisplayName => "A Thousand Degrees";
        public override string Description => "Fire, explosions, and bullets deal more moab, ceramic, and fortified damage.";
        public override int Cost => 65750;
        public override int Path => TOP;
        public override int Tier => 5;
        public override void ApplyUpgrade(TowerModel tower)
        {
            var attackModel = tower.GetAttackModel();
            var weapon = tower.GetWeapon();
            var projectile = weapon.projectile;
            var explosion = attackModel.GetDescendants<ProjectileModel>().ToIl2CppList()[1];
            tower.GetDescendants<FilterInvisibleModel>().ForEach(invisibleModel => invisibleModel.isActive = false);
            attackModel.GetDescendants<ProjectileModel>().ForEach(projectileModel => projectileModel.GetBehavior<AddBehaviorToBloonModel>().GetBehavior<DamageOverTimeModel>().damageModifierModels = new[] { new DamageModifierForTagModel("DamageModifierForBloonTagModel", "Fortified", 1, 25, true, true) });
            attackModel.GetDescendants<ProjectileModel>().ForEach(projectileModel => projectileModel.GetBehavior<AddBehaviorToBloonModel>().GetBehavior<DamageOverTimeModel>().damageModifierModels = new[] { new DamageModifierForTagModel("DamageModifierForBloonTagModel", "Ceramic", 1, 38, true, true) });
            attackModel.GetDescendants<ProjectileModel>().ForEach(projectileModel => projectileModel.GetBehavior<AddBehaviorToBloonModel>().GetBehavior<DamageOverTimeModel>().damageModifierModels = new[] { new DamageModifierForTagModel("DamageModifierForBloonTagModel", "Moabs", 1, 48, true, true) });
            projectile.AddBehavior(new DamageModifierForTagModel("BaseProjectileDamageModifierForTagModel", "Fortified", 1, 35, false, true));
            projectile.AddBehavior(new DamageModifierForTagModel("BaseProjectileDamageModifierForTagModel", "Ceramic", 1, 20, false, true));
            projectile.AddBehavior(new DamageModifierForTagModel("BaseProjectileDamageModifierForTagModel", "Moabs", 1, 50, false, true));
            explosion.GetDamageModel().damage += 30;
            explosion.AddBehavior(new DamageModifierForTagModel("BaseProjectileDamageModifierForTagModel", "Fortified", 1, 20f, false, true));
            explosion.AddBehavior(new DamageModifierForTagModel("BaseProjectileDamageModifierForTagModel", "Ceramic", 1, 20, false, true));
            explosion.AddBehavior(new DamageModifierForTagModel("BaseProjectileDamageModifierForTagModel", "Moabs", 1, 30, false, true));
            explosion.GetDamageModel().damage += 20;
            explosion.pierce += 40;
            explosion.radius += 5;
            explosion.GetBehavior<CreateEffectOnContactModel>().effectModel.scale = 1;
            explosion.GetBehavior<SlowModel>().lifespan *= 4;
        }
    }
}