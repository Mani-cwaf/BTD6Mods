using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Models.Towers;
using Assets.Scripts.Models.Towers.Behaviors;
using Assets.Scripts.Models.TowerSets;
using BTD_Mod_Helper;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using MelonLoader;

namespace FireSniper
{
    public class FireSniper : ModTower
    {
        public override string TowerSet => MILITARY;
        public override string BaseTower => "SniperMonkey";
        public override int Cost => 815;
        public override int TopPathUpgrades => 0;
        public override int MiddlePathUpgrades => 0;
        public override int BottomPathUpgrades => 0;
        public override string Description => "Shoots incendiary rounds at bloons";
        public override ParagonMode ParagonMode => ParagonMode.Base000;
        public override void ModifyBaseTowerModel(TowerModel tower)
        {
            var attackModel = tower.GetAttackModel();
            tower.range += 10;
            attackModel.range += 10;
        }
    }
}