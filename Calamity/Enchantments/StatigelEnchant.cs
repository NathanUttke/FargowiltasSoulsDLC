﻿using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using CalamityMod.Items.Armor;
using CalamityMod.Items.Accessories;
using CalamityMod.Items.Weapons.Magic;
using CalamityMod.Items.Weapons.Melee;
using CalamityMod.Items.Weapons.Summon;

namespace FargowiltasSoulsDLC.Calamity.Enchantments
{
    public class StatigelEnchant : ModItem
    {
        private readonly Mod calamity = ModLoader.GetMod("CalamityMod");

        public override bool IsLoadingEnabled(Mod mod)/* tModPorter Suggestion: If you return false for the purposes of manual loading, use the [Autoload(false)] attribute on your class instead */
        {
            return ModLoader.GetMod("CalamityMod") != null;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Statigel Enchantment");
            Tooltip.SetDefault(
@"'Statis’ mystical power surrounds you…'
When you take over 100 damage in one hit you become immune to damage for an extended period of time
Grants an extra jump and increased jump height
Effects of Counter Scarf, Mana Overloader, and Fungal Symbiote");
            DisplayName.AddTranslation(GameCulture.Chinese, "斯塔提斯魔石");
            Tooltip.AddTranslation(GameCulture.Chinese, 
@"'斯塔提斯的神秘力量环绕着你...'
当你一次性受到超过100点伤害时，获得额外的无敌帧
增加跳跃高度，并获得一段额外跳跃
拥有反击围巾和真菌共生体的效果");
        }

        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 20;
            Item.accessory = true;
            ItemID.Sets.ItemNoGravity[Item.type] = true;
            Item.rare = 5;
            Item.value = 200000;
        }

        public override void ModifyTooltips(List<TooltipLine> list)
        {
            foreach (TooltipLine tooltipLine in list)
            {
                if (tooltipLine.Mod == "Terraria" && tooltipLine.Name == "ItemName")
                {
                    tooltipLine.OverrideColor = new Color(181, 0, 156);
                }
            }
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            if (!FargowiltasSoulsDLC.Instance.CalamityLoaded) return;

            FargoDLCPlayer modPlayer = player.GetModPlayer<FargoDLCPlayer>();
            calamity.Call("SetSetBonus", player, "statigel", true);
            player.hasJumpOption_Sail = true;
            player.jumpBoost = true;

            if (SoulConfig.Instance.calamityToggles.FungalSymbiote)
            {
                calamity.GetItem("FungalSymbiote").UpdateAccessory(player, hideVisual);
            }

            calamity.GetItem("ManaOverloader").UpdateAccessory(player, hideVisual);
            calamity.GetItem("CounterScarf").UpdateAccessory(player, hideVisual);
        }

        public override void AddRecipes()
        {
            if (!FargowiltasSoulsDLC.Instance.CalamityLoaded) return;

            Recipe recipe = CreateRecipe();

            recipe.AddRecipeGroup("FargowiltasSoulsDLC:AnyStatigelHelmet");
            recipe.AddIngredient(ModContent.ItemType<StatigelArmor>());
            recipe.AddIngredient(ModContent.ItemType<StatigelGreaves>());
            recipe.AddIngredient(ModContent.ItemType<CounterScarf>());
            recipe.AddIngredient(ModContent.ItemType<ManaOverloader>());
            recipe.AddIngredient(ModContent.ItemType<FungalSymbiote>());

            recipe.AddTile(TileID.DemonAltar);
            recipe.Register();
        }
    }
}
