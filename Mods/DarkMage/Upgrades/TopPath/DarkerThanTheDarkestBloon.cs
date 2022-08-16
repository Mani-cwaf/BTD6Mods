using Assets.Scripts.Models.Towers;
using Assets.Scripts.Models.Towers.Behaviors.Abilities;
using Assets.Scripts.Models.Towers.Behaviors.Emissions;
using Assets.Scripts.Models.Towers.Filters;
using Assets.Scripts.Models.Towers.Projectiles.Behaviors;
using Assets.Scripts.Models.Towers.Weapons.Behaviors;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using MelonLoader;
using System.Linq;

namespace DarkMage.Upgrades.TopPath
{
    public class DarkerThanTheDarkestBloon : ModUpgrade<DarkMage>
    {
        public override int Path => TOP;
    public override int Tier => 4;
    public override int Cost => 32500;

    public override string Description => "gains extreme damage against moabs, fortified bloons, and ceramics";

        public override void ApplyUpgrade(TowerModel tower)
        {
            if (tower.tier == 5)
            {
                foreach (var projectile in tower.GetWeapons().Select(weaponModel => weaponModel.projectile))
                {
                    projectile.AddBehavior(new DamageModifierForTagModel("DamageModifierForTagModel_Moabs", "Moabs", 1, 105, false, false));
                    projectile.AddBehavior(new DamageModifierForTagModel("DamageModifierForTagModel_Ceramic", "Ceramic", 1, 75, false, false));
                    projectile.AddBehavior(new DamageModifierForTagModel("DamageModifierForTagModel_Fortified", "Fortified", 1, 115, false, false));
                }
                foreach (var weaponModel in tower.GetWeapons())
                {
                    weaponModel.rate *= 0.70f;
                }
            }
            else
            {
                foreach (var projectile in tower.GetWeapons().Select(weaponModel => weaponModel.projectile))
                {
                    projectile.GetDamageModel().damage += 5;
                    projectile.AddBehavior(new DamageModifierForTagModel("DamageModifierForTagModel_Moabs", "Moabs", 1, 15, false, false));
                    projectile.AddBehavior(new DamageModifierForTagModel("DamageModifierForTagModel_Ceramic", "Ceramic", 1, 10, false, false));
                    projectile.AddBehavior(new DamageModifierForTagModel("DamageModifierForTagModel_Fortified", "Fortified", 1, 20, false, false));
                }
                foreach (var weaponModel in tower.GetWeapons())
                {
                    weaponModel.rate *= 0.85f;
                }
            }
        }
    }
}