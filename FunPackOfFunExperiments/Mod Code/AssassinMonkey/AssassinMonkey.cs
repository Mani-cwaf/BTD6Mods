﻿using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Models.Towers;
using Assets.Scripts.Models.Towers.Behaviors;
using Assets.Scripts.Models.TowerSets;
using Assets.Scripts.Utils;
using BTD_Mod_Helper;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using MelonLoader;
using static FunPackOfFunExperiments.Main;

namespace AssassinMonkey
{
    public class AssassinMonkey : ModTower
    {

        public override string TowerSet => PRIMARY;
        public override string BaseTower => "NinjaMonkey";
        public override int Cost => 855;
        public override int TopPathUpgrades => 0;
        public override int MiddlePathUpgrades => 0;
        public override int BottomPathUpgrades => 0;
        public override string Description => "throws knives at bloons";
        public override SpriteReference IconReference => new SpriteReference("MonkeyIcons[GlueGunnerIcon]");
        public override SpriteReference PortraitReference => new SpriteReference("4cf5ed7ac85b3ad4cb921bf7b7a24e16");
        public override bool DontAddToShop => !OPFreeGlueGunnerEnabled == true;
        public override ParagonMode ParagonMode => ParagonMode.Base000;

        //actual tower abilities
        public override void ModifyBaseTowerModel(TowerModel tower)
        {
            var attackModel = tower.GetAttackModel();
            tower.range += 10;
            attackModel.range += 10;
        }
    }
}