﻿using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using CalamityMod.Items.Armor;
using CalamityMod.Items.Accessories;
using CalamityMod.Items.Weapons.Rogue;
using CalamityMod.CalPlayer;
using CalamityMod;
using CalamityMod.Items.Weapons.Summon;
using CalamityMod.Items.Pets;
using CalamityMod.Buffs.Pets;
using CalamityMod.Projectiles.Pets;

namespace FargowiltasSoulsDLC.Calamity.Enchantments
{
    public class SulphurousEnchant : ModItem
    {
        private readonly Mod calamity = ModLoader.GetMod("CalamityMod");

        public override bool IsLoadingEnabled(Mod mod)/* tModPorter Suggestion: If you return false for the purposes of manual loading, use the [Autoload(false)] attribute on your class instead */
        {
            return ModLoader.GetMod("CalamityMod") != null;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Sulphurous Enchantment");
            Tooltip.SetDefault(
@"''
Attacking and being attacked by enemies inflicts poison
Grants a sulphurous bubble jump that applies venom on hit
Slightly reduces breath loss in the abyss
Effects of Sand Cloak and Alluring Bait");
            DisplayName.AddTranslation(GameCulture.Chinese, "硫磺魔石");
            Tooltip.AddTranslation(GameCulture.Chinese, 
@"''
攻击敌人或被敌人攻击赋予他们中毒减益
获得一段硫磺泡泡跳跃，击中敌人赋予毒液减益
稍微减轻深渊带来的呼吸困难
拥有沙尘披风和诱惑鱼饵的效果
召唤丹尼·德维托和辐射海参宠物");
        }

        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 20;
            Item.accessory = true;
            ItemID.Sets.ItemNoGravity[Item.type] = true;
            Item.rare = 2;
            Item.value = 50000;
        }

        /*public override void ModifyTooltips(List<TooltipLine> list)
        {
            foreach (TooltipLine tooltipLine in list)
            {
                if (tooltipLine.mod == "Terraria" && tooltipLine.Name == "ItemName")
                {
                    tooltipLine.overrideColor = new Color(70, 63, 69);
                }
            }
        }*/

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            if (!FargowiltasSoulsDLC.Instance.CalamityLoaded) return;

            CalamityPlayer calamityPlayer = player.Calamity();
            calamityPlayer.sulfurSet = true;
            player.hasJumpOption_Sandstorm = true;
            //calamity.Call("SetSetBonus", player, "sulphur", true); hopefully soon
            calamity.GetItem("SandCloak").UpdateAccessory(player, hideVisual);
            calamity.GetItem("AlluringBait").UpdateAccessory(player, hideVisual);
        }

        public override void AddRecipes()
        {
            if (!FargowiltasSoulsDLC.Instance.CalamityLoaded) return;

            Recipe recipe = CreateRecipe();

            recipe.AddIngredient(ModContent.ItemType<SulfurHelmet>());
            recipe.AddIngredient(ModContent.ItemType<SulfurBreastplate>());
            recipe.AddIngredient(ModContent.ItemType<SulfurLeggings>());
            recipe.AddIngredient(ModContent.ItemType<SandCloak>());
            recipe.AddIngredient(ModContent.ItemType<AlluringBait>());
            recipe.AddIngredient(ModContent.ItemType<CausticCroakerStaff>());


            recipe.AddTile(TileID.DemonAltar);
            recipe.Register();
        }
    }
}
