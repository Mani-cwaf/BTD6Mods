using Assets.Scripts.Models.Towers;
using Assets.Scripts.Models.Towers.Filters;
using Assets.Scripts.Models.Towers.Projectiles.Behaviors;
using Assets.Scripts.Models.Towers.Weapons.Behaviors;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using MelonLoader;

namespace DarkMage.Upgrades.MiddlePath
{
    public class FasterBolts : ModUpgrade<DarkMage>
    {
        public override int Path => MIDDLE;
        public override int Tier => 2;
        public override int Cost => 550;

        public override string Description => "Further increases attack speed, and bolts fly even faster";

        public override void ApplyUpgrade(TowerModel tower)
        {
            var darkPulse = tower.GetWeapon();
            darkPulse.projectile.GetBehavior<TravelStraitModel>().Speed += 100;

            foreach (var weaponModel in tower.GetWeapons())
            {
                weaponModel.rate *= .85f;
            }
        }
    }
}