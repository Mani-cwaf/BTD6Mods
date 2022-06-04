using Assets.Scripts.Models.Towers;
using Assets.Scripts.Models.Towers.Behaviors.Abilities;
using Assets.Scripts.Models.Towers.Behaviors.Attack;
using Assets.Scripts.Models.Towers.Behaviors.Emissions;
using Assets.Scripts.Models.Towers.Filters;
using Assets.Scripts.Models.Towers.Projectiles.Behaviors;
using Assets.Scripts.Models.Towers.Weapons.Behaviors;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using MelonLoader;

namespace DarkMage.Upgrades.TopPath
{
    public class UltimatePower : ModUpgrade<DarkMage>
    {
        public override int Path => TOP;
        public override int Tier => 5;
        public override int Cost => 166000;

        public override string Description => "every time the attack bounces it creates a second projectile";

        public override void ApplyUpgrade(TowerModel tower)
        {
            var darkPulse = tower.GetWeapon();
            darkPulse.projectile.GetDamageModel().immuneBloonProperties = BloonProperties.None;
            tower.GetDescendants<FilterInvisibleModel>().ForEach(model => model.isActive = false);
        }
    }
}