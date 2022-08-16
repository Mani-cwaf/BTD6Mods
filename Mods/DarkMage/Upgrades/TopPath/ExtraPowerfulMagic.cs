using Assets.Scripts.Models.Towers;
using Assets.Scripts.Models.Towers.Behaviors.Emissions;
using Assets.Scripts.Models.Towers.Filters;
using Assets.Scripts.Models.Towers.Weapons.Behaviors;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using MelonLoader;

namespace DarkMage.Upgrades.TopPath
{
    public class ExtraPowerfulMagic : ModUpgrade<DarkMage>
    {
        public override int Path => TOP;
        public override int Tier => 2;
        public override int Cost => 550;

        public override string Description => "Attacks pop a further two layers and are strong enough to penetrate lead bloons";

        public override void ApplyUpgrade(TowerModel tower)
        {
            var darkPulse = tower.GetWeapon();
            darkPulse.projectile.GetDamageModel().immuneBloonProperties = BloonProperties.Purple;

            foreach (var weaponModel in tower.GetWeapons())
            {
                weaponModel.projectile.GetDamageModel().damage += 2;
            }
        }
    }
}