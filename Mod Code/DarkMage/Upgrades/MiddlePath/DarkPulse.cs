using Assets.Scripts.Models.Towers;
using Assets.Scripts.Models.Towers.Behaviors.Emissions;
using Assets.Scripts.Models.Towers.Filters;
using Assets.Scripts.Models.Towers.Weapons.Behaviors;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using MelonLoader;

namespace DarkMage.Upgrades.MiddlePath
{
    public class DarkPulse : ModUpgrade<DarkMage>
    {
        public override int Path => MIDDLE;
        public override int Tier => 3;
        public override int Cost => 8500;

        public override string Description => "creates an extra powerful pulse of magic";

        public override void ApplyUpgrade(TowerModel tower)
        {
            var darkPulse = tower.GetWeapon();
            darkPulse.projectile.GetDamageModel().immuneBloonProperties = BloonProperties.Purple;
            darkPulse.emission = new ArcEmissionModel("ArcEmissionModel_", 10, 0, 360, null, false);
            darkPulse.projectile.GetDamageModel().damage += 5;
        }
    }
}