using Assets.Scripts.Models.Towers;
using Assets.Scripts.Models.Towers.Behaviors.Emissions;
using Assets.Scripts.Models.Towers.Weapons.Behaviors;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using MelonLoader;

namespace DarkMage.Upgrades.BottomPath
{
    public class ExtendedDarkness : ModUpgrade<DarkMage>
    {
        public override int Path => BOTTOM;
        public override int Tier => 1;
        public override int Cost => 400;

        public override string Description => "Increased attack range";

        public override void ApplyUpgrade(TowerModel tower)
        {
            tower.range += 15;
            tower.GetAttackModel().range += 15;
        }
    }
}
