using Assets.Scripts.Models.GenericBehaviors;
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
using Assets.Scripts.Models.Towers.Filters;


namespace DarkMage.Upgrades.BottomPath
{
    public class UltimateChaos : ModUpgrade<DarkMage>
    {
        public override int Path => MIDDLE;
        public override int Tier => 5;
        public override int Cost => 84000;
        public override string Description => "Ability achieves ultimate form and destroys everything in it's path";
        public override void ApplyUpgrade(TowerModel tower)
        {
            var darkPulse = tower.GetWeapon();

            darkPulse.projectile.GetDamageModel().immuneBloonProperties = BloonProperties.None;
            tower.GetDescendants<FilterInvisibleModel>().ForEach(model => model.isActive = false);
            foreach (var weaponModel in tower.GetWeapons())
            {
                weaponModel.rate *= .5f;
                weaponModel.projectile.GetDamageModel().damage += 10;
            }
        }
    }
}