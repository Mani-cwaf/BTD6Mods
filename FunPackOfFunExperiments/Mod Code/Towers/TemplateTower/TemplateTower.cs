using Assets.Scripts.Models.Towers;
using Assets.Scripts.Utils;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using static FunPackOfFunExperiments.Main;

namespace TemplateTower
{
    public class TemplateTower : ModTower
    {

        public override string TowerSet => PRIMARY;
        public override string BaseTower => "";
        public override int Cost => 855;
        public override int TopPathUpgrades => 0;
        public override int MiddlePathUpgrades => 0;
        public override int BottomPathUpgrades => 0;
        public override string Description => "";
        public override SpriteReference IconReference => new SpriteReference("MonkeyIcons[GlueGunnerIcon]");
        public override SpriteReference PortraitReference => new SpriteReference("4cf5ed7ac85b3ad4cb921bf7b7a24e16");
        public override bool DontAddToShop => !AssassinMonkeyEnabled == true;
        public override ParagonMode ParagonMode => ParagonMode.Base000;

        //actual tower abilities
        public override void ModifyBaseTowerModel(TowerModel tower)
        {
        }
    }
    public class TemplateUpgrade : ModUpgrade<TemplateTower>
    {
        public override string DisplayName => "";
        public override string Description => "";
        public override int Cost => 0;
        public override int Path => TOP;
        public override int Tier => 1;
        public override void ApplyUpgrade(TowerModel tower)
        {
        }
    }
}