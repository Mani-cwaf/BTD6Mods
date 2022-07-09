using Assets.Scripts.Models;
using Assets.Scripts.Models.Towers;
using Assets.Scripts.Models.Towers.Upgrades;
using Assets.Scripts.Utils;
using BTD_Mod_Helper;
using BTD_Mod_Helper.Extensions;
using MelonLoader;


[assembly: MelonInfo(typeof(VanillaParagons.Main), "Vanilla Paragons", "1.0.0", "Mani_Dev")]
[assembly: MelonGame("Ninja Kiwi", "BloonsTD6")]
namespace VanillaParagons
{
    class Main : BloonsTD6Mod
    {
        public override void OnApplicationStart()
        {
            base.OnApplicationStart();
        }
        public override void OnGameModelLoaded(GameModel model)
        {
            base.OnGameModelLoaded(model);
        }
        public void CreateUpgrade(TowerModel towerModel, int price, SpriteReference icon, GameModel model)
        {
            UpgradeModel upgradeModel = new UpgradeModel(
            name: towerModel.baseId + " Paragon",
            cost: price,
            xpCost: 0,
            icon: icon,
            path: -1,
            tier: 5,
            locked: 0,
            confirmation: "Paragon",
            localizedNameOverride: ""
            );
            model.AddUpgrade(upgradeModel);
        }
    }
}