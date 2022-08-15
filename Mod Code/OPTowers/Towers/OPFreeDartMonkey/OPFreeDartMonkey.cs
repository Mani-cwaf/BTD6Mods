using Assets.Scripts.Models.Towers;
using Assets.Scripts.Models.Towers.Behaviors;
using Assets.Scripts.Models.Towers.Behaviors.Attack;
using Assets.Scripts.Models.Towers.Behaviors.Emissions;
using Assets.Scripts.Models.Towers.Filters;
using Assets.Scripts.Models.Towers.Projectiles.Behaviors;
using Assets.Scripts.Models.TowerSets;
using Assets.Scripts.Unity;
using Assets.Scripts.Unity.Display;
using Assets.Scripts.Utils;
using BTD_Mod_Helper.Api.Display;
using BTD_Mod_Helper.Api.Enums;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using System.Collections.Generic;
using System.Linq;
using static OPTowers.Main;

namespace OPFreeDartMonkey
{
    public class OPFreeDartMonkey : ModTower
    {
        public override string TowerSet => TowerSetType.Primary;
        public override string BaseTower => TowerType.DartMonkey;
        public override int Cost => 0;
        public override int TopPathUpgrades => 5;
        public override int MiddlePathUpgrades => 5;
        public override int BottomPathUpgrades => 5;
        public override string Description => "Totally just a free dart monkey";
        public override string DisplayName => "\"Free Dart Monkey\"";
        public override string Icon => "OPFreeDartMonkey-Icon";
        public override string Portrait => "OPFreeDartMonkey-Portrait";
        public override bool DontAddToShop => !OPFreeDartMonkeyEnabled == true;
        public override ParagonMode ParagonMode => ParagonMode.Base000;
        public override void ModifyBaseTowerModel(TowerModel tower)
        {
            var attackModel = tower.GetAttackModel();
            var weapon = tower.GetWeapon();
            var projectile = weapon.projectile;
            attackModel.range += 1000;
            tower.range += 1000;
            projectile.pierce = 10;
            projectile.GetDamageModel().damage = 2140000000;
            projectile.GetBehavior<TravelStraitModel>().lifespan = 5;
            weapon.emission = new ArcEmissionModel("OPFreeDartMonkeyArcEmissionModel", 230, 0, 0, null, false);
            weapon.rate *= 0.85f;
            projectile.GetDamageModel().immuneBloonProperties = BloonProperties.None;
            projectile.GetDamageModel().distributeToChildren = true;
            tower.GetDescendants<FilterInvisibleModel>().ForEach(invisibleModel => invisibleModel.isActive = false);
        }
        public override int GetTowerIndex(List<TowerDetailsModel> towerSet)
        {
            return towerSet.First(model => model.towerId == TowerType.DartMonkey).towerIndex + 1;
        }
    }
    public class MONKEtop : ModUpgrade<OPFreeDartMonkey>
    {
        public override string DisplayName => "MONKE";
        public override string Description => "MONKE";
        public override int Cost => 0;
        public override int Path => TOP;
        public override int Tier => 1;
        public override void ApplyUpgrade(TowerModel tower)
        {
        }
    }
    public class MONKEMONKEtop : ModUpgrade<OPFreeDartMonkey>
    {
        public override string DisplayName => "MONKE MONKE";
        public override string Description => "MONKE MONKE";
        public override int Cost => 0;
        public override int Path => TOP;
        public override int Tier => 2;
        public override void ApplyUpgrade(TowerModel tower)
        {
        }
    }
    public class MONKEMONKEMONKEtop : ModUpgrade<OPFreeDartMonkey>
    {
        public override string DisplayName => "MONKE MONKE MONKE";
        public override string Description => "MONKE MONKE MONKE";
        public override int Cost => 0;
        public override int Path => TOP;
        public override int Tier => 3;
        public override void ApplyUpgrade(TowerModel tower)
        {
        }
    }
    public class MONKEMONKEMONKEMONKEtop : ModUpgrade<OPFreeDartMonkey>
    {
        public override string DisplayName => "MONKE MONKE MONKE MONKE";
        public override string Description => "MONKE MONKE MONKE MONKE";
        public override int Cost => 0;
        public override int Path => TOP;
        public override int Tier => 4;
        public override void ApplyUpgrade(TowerModel tower)
        {
        }
    }
    public class MONKEMONKEMONKEMONKEMONKEtop : ModUpgrade<OPFreeDartMonkey>
    {
        public override string DisplayName => "MONKE MONKE MONKE MONKE MONKE";
        public override string Description => "MONKE MONKE MONKE MONKE MONKE";
        public override int Cost => 0;
        public override int Path => TOP;
        public override int Tier => 5;
        public override void ApplyUpgrade(TowerModel tower)
        {
        }
    }
    public class MONKEbottom : ModUpgrade<OPFreeDartMonkey>
    {
        public override string DisplayName => "MONKE";
        public override string Description => "MONKE";
        public override int Cost => 0;
        public override int Path => BOTTOM;
        public override int Tier => 1;
        public override void ApplyUpgrade(TowerModel tower)
        {
        }
    }
    public class MONKEMONKEbottom : ModUpgrade<OPFreeDartMonkey>
    {
        public override string DisplayName => "MONKE MONKE";
        public override string Description => "MONKE MONKE";
        public override int Cost => 0;
        public override int Path => BOTTOM;
        public override int Tier => 2;
        public override void ApplyUpgrade(TowerModel tower)
        {
        }
    }
    public class MONKEMONKEMONKEbottom : ModUpgrade<OPFreeDartMonkey>
    {
        public override string DisplayName => "MONKE MONKE MONKE";
        public override string Description => "MONKE MONKE MONKE";
        public override int Cost => 0;
        public override int Path => BOTTOM;
        public override int Tier => 3;
        public override void ApplyUpgrade(TowerModel tower)
        {
        }
    }
    public class MONKEMONKEMONKEMONKEbottom : ModUpgrade<OPFreeDartMonkey>
    {
        public override string DisplayName => "MONKE MONKE MONKE MONKE";
        public override string Description => "MONKE MONKE MONKE MONKE";
        public override int Cost => 0;
        public override int Path => BOTTOM;
        public override int Tier => 4;
        public override void ApplyUpgrade(TowerModel tower)
        {
        }
    }
    public class MONKEMONKEMONKEMONKEMONKEbottom : ModUpgrade<OPFreeDartMonkey>
    {
        public override string DisplayName => "MONKE MONKE MONKE MONKE MONKE";
        public override string Description => "MONKE MONKE MONKE MONKE MONKE";
        public override int Cost => 0;
        public override int Path => BOTTOM;
        public override int Tier => 5;
        public override void ApplyUpgrade(TowerModel tower)
        {
        }
    }
    public class MONKEmid : ModUpgrade<OPFreeDartMonkey>
    {
        public override string DisplayName => "MONKE";
        public override string Description => "MONKE";
        public override int Cost => 0;
        public override int Path => MIDDLE;
        public override int Tier => 1;
        public override void ApplyUpgrade(TowerModel tower)
        {
        }
    }
    public class MONKEMONKEmid : ModUpgrade<OPFreeDartMonkey>
    {
        public override string DisplayName => "MONKE MONKE";
        public override string Description => "MONKE MONKE";
        public override int Cost => 0;
        public override int Path => MIDDLE;
        public override int Tier => 2;
        public override void ApplyUpgrade(TowerModel tower)
        {
        }
    }
    public class MONKEMONKEMONKEmid : ModUpgrade<OPFreeDartMonkey>
    {
        public override string DisplayName => "MONKE MONKE MONKE";
        public override string Description => "MONKE MONKE MONKE";
        public override int Cost => 0;
        public override int Path => MIDDLE;
        public override int Tier => 3;
        public override void ApplyUpgrade(TowerModel tower)
        {
        }
    }
    public class MONKEMONKEMONKEMONKEmid : ModUpgrade<OPFreeDartMonkey>
    {
        public override string DisplayName => "MONKE MONKE MONKE MONKE";
        public override string Description => "MONKE MONKE MONKE MONKE";
        public override int Cost => 0;
        public override int Path => MIDDLE;
        public override int Tier => 4;
        public override void ApplyUpgrade(TowerModel tower)
        {
        }
    }
    public class MONKEMONKEMONKEMONKEMONKEmid : ModUpgrade<OPFreeDartMonkey>
    {
        public override string DisplayName => "MONKE MONKE MONKE MONKE MONKE";
        public override string Description => "MONKE MONKE MONKE MONKE MONKE";
        public override int Cost => 0;
        public override int Path => MIDDLE;
        public override int Tier => 5;
        public override void ApplyUpgrade(TowerModel tower)
        {
        }
    }
    public class MONKEMONKEMONKEMONKEMONKEMONKEMONKEMONKEMONKEMONKEMONKEMONKEMONKEMONKEMONKEMONKEMONKEMONKEMONKEMONKE : ModParagonUpgrade<OPFreeDartMonkey>
    {
        public override int Cost => 8400000;
        public override string Description => "<b>MONKE MONKE MONKE MONKE MONKE MONKE MONKE MONKE MONKE MONKE MONKE MONKE MONKE MONKE MONKE MONKE MONKE MONKE MONKE MONKE<b>";
        public override string DisplayName => "<b>MONKE<b>";

        public override void ApplyUpgrade(TowerModel tower)
        {
            tower.display = Game.instance.model.GetTower(TowerType.DartMonkey).display;
            var weapon = tower.GetWeapon();
            var fireStorm = Game.instance.model.GetTower(TowerType.WizardMonkey, 1, 2, 0).behaviors.First(a => a.name.Contains("Wall")).Cast<AttackModel>().Duplicate();
            fireStorm.weapons[0].projectile.GetBehavior<AgeModel>().lifespan = 2f;
            fireStorm.weapons[0].projectile.RemoveBehaviors<CreateEffectOnExhaustedModel>();
            fireStorm.weapons[0].projectile.GetDamageModel().damage = 2000000000;
            fireStorm.weapons[0].projectile.radius += 15;
            fireStorm.weapons[0].projectile.display = "";
            fireStorm.weapons[0].Rate *= .0016f;
            tower.AddBehavior(fireStorm);
            tower.AddBehavior(new SlowBloonsZoneModel("MONKESlowBloonsZoneModel", 0, "", true, null, 0.925f, 0, true, 0, "", true, null));
        }
    }
    public class OPFreeDartMonkeyDisplay : ModTowerDisplay<OPFreeDartMonkey>
    {
        public override string BaseDisplay => GetDisplay("DartMonkey");

        public override bool UseForTower(int[] tiers)
        {
            return tiers.Sum() == 0;
        }

        public override void ModifyDisplayNode(UnityDisplayNode node)
        {
            SetMeshTexture(node, Name);
        }
    }
    public class MONKEMONKEMONKEMONKEMONKEMONKEMONKEMONKEMONKEMONKEMONKEMONKEMONKEMONKEMONKEMONKEMONKEMONKEMONKEMONKEDisplay : ModTowerDisplay<OPFreeDartMonkey>
    {
        public override string BaseDisplay => GetDisplay(TowerType.DartMonkey);
        public override float Scale => 1.15f;

        public override bool UseForTower(int[] tiers)
        {
            return IsParagon(tiers);
        }

        public override int ParagonDisplayIndex => 0;

        public override void ModifyDisplayNode(UnityDisplayNode node)
        {
            SetMeshTexture(node, "OPFreeDartMonkeyDisplay");
        }
    }
}