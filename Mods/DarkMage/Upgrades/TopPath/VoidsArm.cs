using Assets.Scripts.Models;
using Assets.Scripts.Models.Towers;
using Assets.Scripts.Models.Towers.Behaviors.Attack;
using Assets.Scripts.Models.Towers.Behaviors.Attack.Behaviors;
using Assets.Scripts.Models.Towers.Behaviors.Emissions;
using Assets.Scripts.Models.Towers.Behaviors.Emissions.Behaviors;
using Assets.Scripts.Models.Towers.Filters;
using Assets.Scripts.Models.Towers.Projectiles;
using Assets.Scripts.Models.Towers.Projectiles.Behaviors;
using Assets.Scripts.Models.Towers.Weapons.Behaviors;
using Assets.Scripts.Unity;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using MelonLoader;

namespace DarkMage.Upgrades.TopPath
{
       public class  VoidsArm: ModUpgrade<DarkMage>
       {
       public override int Path => TOP;
       public override int Tier => 3;
       public override int Cost => 10800;

       public override string Description => "attacks seek nearby bloons";

       public override void ApplyUpgrade(TowerModel tower)
       {
            var darkPulse = tower.GetWeapon();
            var seekingBehavior = Game.instance.model.GetTower(TowerType.BoomerangMonkey, 4).GetDescendants<ProjectileModel>().ToList()[0].GetBehavior<RetargetOnContactModel>().Duplicate();

            seekingBehavior.distance = 2000;
            darkPulse.projectile.AddBehavior(seekingBehavior);
            tower.GetDescendants<ProjectileModel>().ToList()[0].GetBehavior<TravelStraitModel>().speed = 300f;
            tower.GetDescendants<ProjectileModel>().ToList()[0].GetBehavior<TravelStraitModel>().lifespan = 4f;
            tower.GetDescendants<ProjectileModel>().ToList()[0].pierce = 75f;
        }
    }
}