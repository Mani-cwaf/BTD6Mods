using Assets.Scripts.Models.Towers;
using Assets.Scripts.Models.Towers.Behaviors;
using Assets.Scripts.Models.Towers.Behaviors.Emissions;
using Assets.Scripts.Utils;
using BTD_Mod_Helper.Api.Display;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using System.Linq;
using static OPTowers.Main;

namespace ShaggyTower
{
    public class ShaggyTower : ModTower
    {

        public override string TowerSet => PRIMARY;
        public override string BaseTower => "Sauda";
        public override int Cost => 855;
        public override int TopPathUpgrades => 0;
        public override int MiddlePathUpgrades => 0;
        public override int BottomPathUpgrades => 0;
        public override string Description => "ultimate power";
        public override string Icon => Name;
        public override string Portrait => Name;
        public override bool DontAddToShop => !ShaggyTowerEnabled == true;
        public override bool Use2DModel => true;
        public override float PixelsPerUnit => 10;
        public override string Get2DTexture(int[] tiers)
        {
            return Name;
        }
        public override ParagonMode ParagonMode => ParagonMode.Base000;

        //actual tower abilities
        public override void ModifyBaseTowerModel(TowerModel tower)
        {
            tower.RemoveBehavior<HeroModel>();
            var weapon = tower.GetWeapon();
            var projectile = weapon.projectile;
            projectile.GetDamageModel().damage += 2000000000;
            projectile.display = "";
        }
    }
}