using Assets.Scripts.Models.Towers;
using Assets.Scripts.Models.Towers.Behaviors.Emissions;
using Assets.Scripts.Models.Towers.Filters;
using Assets.Scripts.Models.Towers.Projectiles.Behaviors;
using Assets.Scripts.Models.Towers.Weapons.Behaviors;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using MelonLoader;

namespace DarkMage.Upgrades.MiddlePath
{
    public class FastBolts : ModUpgrade<DarkMage>
    {
        public override int Path => MIDDLE;
        public override int Tier => 1;
        public override int Cost => 500;

        public override string Description => "Increases attack speed, and bolts fly faster";

        public override void ApplyUpgrade(TowerModel tower)
        {
            var darkPulse = tower.GetWeapon();
            darkPulse.projectile.GetBehavior<TravelStraitModel>().Speed += 50;

            foreach (var weaponModel in tower.GetWeapons())
            {
                weaponModel.rate *= .85f;
            }
        }
    }
}