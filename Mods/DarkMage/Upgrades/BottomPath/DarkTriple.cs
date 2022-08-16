using Assets.Scripts.Models.Towers;
using Assets.Scripts.Models.Towers.Behaviors.Emissions;
using Assets.Scripts.Models.Towers.Weapons.Behaviors;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using MelonLoader;

namespace DarkMage.Upgrades.BottomPath
{
    public class DarkTriple : ModUpgrade<DarkMage>
    {
        public override int Path => BOTTOM;
        public override int Tier => 4;
        public override int Cost => 9000;
        public override string Description => "Attacks triple as fast and fires three projectiles";
        public override void ApplyUpgrade(TowerModel tower)
        {
            var darkBolt = tower.GetWeapon();

            darkBolt.emission = new ArcEmissionModel("ArcEmissionModel_", 3, 0, 10, null, false);
            darkBolt.rate *= .333333f;
        }
    }
}