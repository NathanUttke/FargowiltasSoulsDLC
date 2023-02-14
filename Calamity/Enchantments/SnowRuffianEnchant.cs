using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria.Localization;
using CalamityMod.Items.Armor;
using CalamityMod.Items.Fishing.BrimstoneCragCatches;
using CalamityMod.Items.Weapons.Ranged;
using CalamityMod.Items.Weapons.Melee;
using CalamityMod.Items.Weapons.Summon;
using CalamityMod.Items.Weapons.Rogue;
using CalamityMod.Items.Fishing.FishingRods;
using CalamityMod.Items.Pets;
using CalamityMod.Items.Accessories;
using CalamityMod.Items.Weapons.Magic;

namespace FargowiltasSoulsDLC.Calamity.Enchantments
{
    public class SnowRuffianEnchant : ModItem
    {
        private readonly Mod calamity = ModLoader.GetMod("CalamityMod");
        private bool shouldBoost;

        public override bool IsLoadingEnabled(Mod mod)/* tModPorter Suggestion: If you return false for the purposes of manual loading, use the [Autoload(false)] attribute on your class instead */
        {
            return ModLoader.GetMod("CalamityMod") != null;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Snow Ruffian Enchantment");
            Tooltip.SetDefault(
@"''
You can glide to negate fall damage
Effects of Scuttler's Jewel");
            DisplayName.AddTranslation(GameCulture.Chinese, "雪境暴徒魔石");
            Tooltip.AddTranslation(GameCulture.Chinese, 
@"''
你可以缓降来消除坠落伤害
拥有潜遁者宝石的效果");
        }

        /*public override void ModifyTooltips(List<TooltipLine> list)
        {
            foreach (TooltipLine tooltipLine in list)
            {
                if (tooltipLine.mod == "Terraria" && tooltipLine.Name == "ItemName")
                {
                    tooltipLine.overrideColor = new Color(191, 68, 59);
                }
            }
        }*/

        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 20;
            Item.accessory = true;
            ItemID.Sets.ItemNoGravity[Item.type] = true;
            Item.rare = 2;
            Item.value = 10000;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            if (!FargowiltasSoulsDLC.Instance.CalamityLoaded) return;

            //set bonus
            if (SoulConfig.Instance.GetValue(SoulConfig.Instance.calamityToggles.SnowRuffianWings))
            {
                calamity.Call("SetSetBonus", player, "snowruffian", true);
                if (player.controlJump)
            {
                player.noFallDmg = true;
                player.UpdateJumpHeight();
                if (this.shouldBoost)
                {
                    player.velocity.X = player.velocity.X * 1.3f;
                    this.shouldBoost = false;
                    return;
                }
            }
            else if (!this.shouldBoost && player.velocity.Y == 0f)
            {
                this.shouldBoost = true;
            }
            }

            calamity.GetItem("ScuttlersJewel").UpdateAccessory(player, hideVisual);
        }

        public override void AddRecipes()
        {
            if (!FargowiltasSoulsDLC.Instance.CalamityLoaded) return;

            Recipe recipe = CreateRecipe();

            recipe.AddIngredient(calamity.Find<ModItem>("SnowRuffianMask").Type); //private REE, fix later
            recipe.AddIngredient(calamity.Find<ModItem>("SnowRuffianChestplate").Type);
            recipe.AddIngredient(calamity.Find<ModItem>("SnowRuffianGreaves").Type);
            recipe.AddIngredient(ModContent.ItemType<ScuttlersJewel>());
            recipe.AddIngredient(ModContent.ItemType<Waraxe>());
            recipe.AddIngredient(calamity.Find<ModItem>("TundraLeash").Type);

            recipe.AddTile(TileID.DemonAltar);
            recipe.Register();
        }
    }
}
