using Assets.Scripts.Models.Towers;
using Assets.Scripts.Models.Towers.Behaviors.Abilities;
using Assets.Scripts.Models.Towers.Behaviors.Abilities.Behaviors;
using Assets.Scripts.Models.Towers.Behaviors.Attack.Behaviors;
using Assets.Scripts.Models.Towers.Behaviors.Emissions;
using Assets.Scripts.Models.Towers.Weapons.Behaviors;
using Assets.Scripts.Unity;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using DarkMage.Upgrades.MiddlePath;
using MelonLoader;

namespace DarkMage.Upgrades.BottomPath
{
    public class ControlledChaos : ModUpgrade<DarkMage>
    {
        public override int Path => MIDDLE;
        public override int Tier => 4;
        public override int Cost => 7800;
        public override string Description => "Ability: dark pulse attack gets extreme attack speed for a short time.";
        public override void ApplyUpgrade(TowerModel tower)
        {
            var darkPulse = tower.GetWeapon();
            var abilityModel = new AbilityModel("AbilityModel_ControlledChaos", "Controlled Chaos", "dark pulse attack gets extreme attack speed for a short time.", 1, 0, GetSpriteReference(Icon), 30f, null, false, false, null, 0, 0, 9999999, false, false);
            tower.AddBehavior(abilityModel);
            darkPulse.projectile.GetDamageModel().immuneBloonProperties = BloonProperties.None;

            if (tower.tier == 5)
            {
                abilityModel.AddBehavior(new TurboModel("DamageModel", 15f, 0.05f, null, 0, 0.5f, false));
            }
            else
            {
                abilityModel.AddBehavior(new TurboModel("DamageModel", 15f, 0.5f, null, 5, 0f, false));
            }
        }
    }
}