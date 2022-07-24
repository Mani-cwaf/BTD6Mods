using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Models.Towers;
using Assets.Scripts.Models.Towers.Behaviors;
using Assets.Scripts.Models.TowerSets;
using BTD_Mod_Helper;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using MelonLoader;

namespace MonkeySeeker
{
    public class MonkeySeeker : ModTower
    {
        public override string TowerSet => MAGIC;
        public override string BaseTower => TowerType.DartMonkey;
        public override int Cost => 1265;
        public override int TopPathUpgrades => 0;
        public override int MiddlePathUpgrades => 0;
        public override int BottomPathUpgrades => 0;
        public override string Description => "Attacks with seeking shards";
        public override ParagonMode ParagonMode => ParagonMode.Base000;
        public override void ModifyBaseTowerModel(TowerModel tower)
        {
            var attackModel = tower.GetAttackModel();
            tower.range += 10;
            attackModel.range += 10;
        }
    }
}