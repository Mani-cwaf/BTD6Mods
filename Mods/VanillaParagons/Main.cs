using Assets.Scripts.Models;
using Assets.Scripts.Models.Towers;
using Assets.Scripts.Models.Towers.Behaviors;
using Assets.Scripts.Models.Towers.Projectiles.Behaviors;
using Assets.Scripts.Models.Towers.Upgrades;
using Assets.Scripts.Models.Towers.Weapons.Behaviors;
using Assets.Scripts.Simulation.Towers.Behaviors;
using Assets.Scripts.Utils;
using BTD_Mod_Helper;
using BTD_Mod_Helper.Api.ModOptions;
using BTD_Mod_Helper.Extensions;
using HarmonyLib;
using MelonLoader;
using System;
using System.Collections.Generic;

[assembly: MelonInfo(typeof(VanillaParagons.Main), "Vanilla Paragons", "1.0.0", "Mani_Dev")]
[assembly: MelonGame("Ninja Kiwi", "BloonsTD6")]
namespace VanillaParagons
{
    class Main : BloonsTD6Mod
    {
        public override string MelonInfoCsURL => "https://github.com/Mani-cwaf/BTD6Mods/raw/main/VanillaParagons/Mod%20Code/Main.cs";
        public override string LatestURL => "https://github.com/Mani-cwaf/BTD6Mods/raw/main/VanillaParagons/Mod%20File/VanillaParagons.dll";

        static Dictionary<string, Type> Paragons = new Dictionary<string, Type>()
        {
            { "WizardMonkey", typeof(MagicParagons.WizardMonkeyParagon.WizardMonkeyParagon) },
            { "SuperMonkey", typeof(MagicParagons.SuperMonkeyParagon.SuperMonkeyParagon) },
            { "Druid", typeof(MagicParagons.DruidParagon.DruidParagon) },
            { "Alchemist", typeof(MagicParagons.AlchemistParagon.AlchemistParagon) },
            { "DartlingGunner", typeof(MilitaryParagons.DartlingGunnerParagon.DartlingGunnerParagon) },
            { "MonkeyAce", typeof(MilitaryParagons.MonkeyAceParagon.MonkeyAceParagon) },
            { "MonkeySub", typeof(MilitaryParagons.MonkeySubParagon.MonkeySubParagon) },
            { "MortarMonkey", typeof(MilitaryParagons.MortarMonkeyParagon.MortarMonkeyParagon) },
            { "HeliPilot", typeof(MilitaryParagons.HeliPilotParagon.HeliPilotParagon) },
            { "SniperMonkey", typeof(MilitaryParagons.SniperParagon.SniperParagon) },
            { "BombShooter", typeof(PrimaryParagons.BombShooterParagon.BombShooterParagon) },
            { "GlueGunner", typeof(PrimaryParagons.GlueGunnerParagon.GlueGunnerParagon) },
            { "IceMonkey", typeof(PrimaryParagons.IceMonkeyParagon.IceMonkeyParagon) },
            { "TackShooter", typeof(PrimaryParagons.TackShooterParagon.TackShooterParagon) },
            { "BananaFarm", typeof(SupportParagons.BananaFarmParagon.BananaFarmParagon) },
            { "EngineerMonkey", typeof(SupportParagons.EngineerMonkeyParagon.EngineerMonkeyParagon) },
            { "SpikeFactory", typeof(SupportParagons.SpikeFactoryParagon.SpikeFactoryParagon) },
            { "MonkeyVillage", typeof(SupportParagons.VillageParagon.VillageParagon) }
        };

        public static ModSettingBool EnableParagons = new ModSettingBool(false) { displayName = "Paragons enabled? (Requires restart.)" };
        public static ModSettingBool EnableBuffableParagons = new ModSettingBool(false) { displayName = "Buffable Versions of Paragons enabled? (Requires restart.)" };

        [HarmonyPatch(typeof(ParagonTower), nameof(ParagonTower.UpdateDegree))]
        class UpdateDegreePatch
        {
            [HarmonyPostfix]
            internal static void Postfix(ParagonTower __instance)
            {
                var tower = __instance.tower;
                var towerModel = tower.towerModel;
                var degree = tower.GetTowerBehavior<ParagonTower>().GetCurrentDegree();
                if (towerModel.baseId == "BananaFarm")
                {
                    if (degree % 5 == 0)
                    {
                        towerModel.GetBehavior<EmissionsPerRoundFilterModel>().count += degree / 5;
                    }
                    towerModel.GetBehavior<PerRoundCashBonusTowerModel>().cashPerRound += 950 * degree;
                }
                if (towerModel.baseId == "GlueGunner")
                {
                    if (degree >= 1)
                    {
                        if (degree >= 50)
                        {
                            towerModel.GetBehavior<SlowModel>().multiplier = 0.75f;
                        }
                        if (degree >= 75)
                        {
                            towerModel.GetBehavior<SlowModel>().multiplier = 0.7f;
                        }
                        if (degree >= 100)
                        {
                            towerModel.GetBehavior<SlowModel>().multiplier = 0.65f;
                        }
                    }
                }
                if (towerModel.baseId == "MonkeyVillage")
                {
                    if (degree >= 1)
                    {
                        towerModel.GetBehavior<RangeSupportModel>().additive += (float)degree / 10;
                        towerModel.GetBehavior<RateSupportModel>().multiplier *= (float)1 / (degree / 40);
                        towerModel.GetBehavior<DamageSupportModel>().increase += (float)degree / 10;
                        towerModel.GetBehavior<PierceSupportModel>().pierce += (float)degree / 5;

                        if (degree >= 75)
                        {
                            towerModel.GetBehavior<MonkeyCityIncomeSupportModel>().incomeModifier = 1.75f;
                        }
                        if (degree >= 100)
                        {
                            towerModel.GetBehavior<MonkeyCityIncomeSupportModel>().incomeModifier = 2;
                        }
                    }
                }
            }
        }
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