using Assets.Scripts.Models.Towers;
using Assets.Scripts.Utils;
using BTD_Mod_Helper.Api.Enums;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using static FunPackOfFunExperiments.Main;

namespace BombTurretBuilder
{
    public class BombTurretBuilder : ModTower
    {
        public override string TowerSet => TowerSetType.Support;
        public override string BaseTower => "EngineerMonkey-100";
        public override int Cost => 975;
        public override int TopPathUpgrades => 0;
        public override int MiddlePathUpgrades => 0;
        public override int BottomPathUpgrades => 0;
        public override string Description => "Creates turrets that place exploding bombs";
        public override SpriteReference IconReference => new SpriteReference("MonkeyIcons[GlueGunnerIcon]");
        public override SpriteReference PortraitReference => new SpriteReference("4cf5ed7ac85b3ad4cb921bf7b7a24e16");
        public override bool DontAddToShop => !BombTurretBuilderEnabled == true;
        public override ParagonMode ParagonMode => ParagonMode.Base000;
        public override void ModifyBaseTowerModel(TowerModel tower)
        {
            var attackModel = tower.GetAttackModel();
            tower.range += 10;
            attackModel.range += 10;
        }
    }
}