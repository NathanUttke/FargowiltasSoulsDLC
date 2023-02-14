using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using CalamityMod.Items.Armor;
using CalamityMod.Items.Accessories;
using CalamityMod.Items.Weapons.Magic;
using CalamityMod.Items.Weapons.Ranged;
using CalamityMod.Items.Weapons.Melee;
using CalamityMod.Items.Fishing;

namespace FargowiltasSoulsDLC.Calamity.Enchantments
{
    public class WulfrumEnchant : ModItem
    {
        private readonly Mod calamity = ModLoader.GetMod("CalamityMod");

        public override bool IsLoadingEnabled(Mod mod)/* tModPorter Suggestion: If you return false for the purposes of manual loading, use the [Autoload(false)] attribute on your class instead */
        {
            return ModLoader.GetMod("CalamityMod") != null;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Wulfrum Enchantment");
            Tooltip.SetDefault(
@"'Not to be confused with Tungsten Enchantment…'
+5 defense when below 50% life
Effects of Trinket of Chi");
            DisplayName.AddTranslation(GameCulture.Chinese, "钨钢魔石");
            Tooltip.AddTranslation(GameCulture.Chinese, 
@"'别和钨金魔石搞混了...'
如果生命值低于50%增加5点防御力
拥有气功念珠的效果");
        }

        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 20;
            Item.accessory = true;
            ItemID.Sets.ItemNoGravity[Item.type] = true;
            Item.rare = 1;
            Item.value = 40000;
            Item.defense = 3;
        }

        public override void ModifyTooltips(List<TooltipLine> list)
        {
            foreach (TooltipLine tooltipLine in list)
            {
                if (tooltipLine.Mod == "Terraria" && tooltipLine.Name == "ItemName")
                {
                    tooltipLine.OverrideColor = new Color(129, 168, 109);
                }
            }
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            if (!FargowiltasSoulsDLC.Instance.CalamityLoaded) return;

            if (player.statLife <= (int)(player.statLifeMax2 * 0.5))
            {
                player.statDefense += 5;
            }
            //trinket of chi
            calamity.GetItem("TrinketofChi").UpdateAccessory(player, hideVisual);
        }

        public override void AddRecipes()
        {
            if (!FargowiltasSoulsDLC.Instance.CalamityLoaded) return;

            Recipe recipe = CreateRecipe();

            recipe.AddRecipeGroup("FargowiltasSoulsDLC:AnyWulfrumHelmet");
            recipe.AddIngredient(ModContent.ItemType<WulfrumArmor>());
            recipe.AddIngredient(ModContent.ItemType<WulfrumLeggings>());
            recipe.AddIngredient(ModContent.ItemType<TrinketofChi>());
            recipe.AddIngredient(ModContent.ItemType<SparkSpreader>());
            recipe.AddIngredient(ModContent.ItemType<Pumpler>());

            recipe.AddTile(TileID.DemonAltar);
            recipe.Register();
        }
    }
}
