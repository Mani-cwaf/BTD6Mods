using Assets.Scripts.Models.Towers;
using Assets.Scripts.Models.Towers.Behaviors.Emissions;
using Assets.Scripts.Models.Towers.Weapons.Behaviors;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using MelonLoader;

namespace DarkMage.Upgrades.BottomPath
{
    public class DarkDouble : ModUpgrade<DarkMage>
    {
        public override int Path => BOTTOM;
        public override int Tier => 3;
        public override int Cost => 4200;
        public override string Description => "Attacks double as fast, and doubles projectiles";
        public override void ApplyUpgrade(TowerModel tower)
        {
            var darkBolt = tower.GetWeapon();

            darkBolt.emission = new ArcEmissionModel("ArcEmissionModel_", 2, 0, 10, null, false);
            darkBolt.rate *= .5f;
        }
    }
}