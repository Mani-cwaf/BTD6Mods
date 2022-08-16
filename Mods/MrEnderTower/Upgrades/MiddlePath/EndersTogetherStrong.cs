using Assets.Scripts.Models.Towers;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using Assets.Scripts.Models.Towers.Behaviors;
using Assets.Scripts.Models.Towers.TowerFilters;
using UnhollowerBaseLib;
using Assets.Scripts.Unity;
using System.Text.RegularExpressions;

namespace MrEnderTower.Upgrades.BottomPath
{
    public class EndersTogetherStrong : ModUpgrade<MrEnderTower>
    {
        public override int Path => MIDDLE;
        public override int Tier => 1;
        public override int Cost => 67800;
        public override string Description => "Gives all nearby towers more attack speed the more of them there are in range, stacks indefinately";
        public override void ApplyUpgrade(TowerModel tower)
        {
            tower.AddBehavior(Game.instance.model.GetTower(TowerType.NinjaMonkey, 0, 3).GetBehavior<SupportShinobiTacticsModel>().Duplicate());
            tower.GetBehavior<SupportShinobiTacticsModel>().multiplier = 0.75f;
            tower.GetBehavior<SupportShinobiTacticsModel>().maxStacks = 999;
            tower.GetBehavior<SupportShinobiTacticsModel>().buffIconName = "BuffIconTempleSunGod4xx";
            var b = tower.GetBaseId();
            var a = tower.GetBehavior<SupportShinobiTacticsModel>().filters[0].Cast<FilterInBaseTowerIdModel>();
            a.baseIds[0] = b;
        }
    }
}