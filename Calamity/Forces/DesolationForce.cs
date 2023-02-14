﻿using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using FargowiltasSoulsDLC.Calamity.Enchantments;

namespace FargowiltasSoulsDLC.Calamity.Forces
{
    public class DesolationForce : ModItem
    {
        private readonly Mod calamity = ModLoader.GetMod("CalamityMod");

        public override bool IsLoadingEnabled(Mod mod)/* tModPorter Suggestion: If you return false for the purposes of manual loading, use the [Autoload(false)] attribute on your class instead */
        {
            return ModLoader.GetMod("CalamityMod") != null;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Force of Desolation");
            Tooltip.SetDefault(
@"'When the world is barren and cold, you will be all that remains'
All armor bonuses from Daedalus, Snow Ruffian, Umbraphile, and Astral
All armor bonuses from Omega Blue, Mollusk, Victide, Fathom Swarmer, and Sulphurous
Effects of Scuttler's Jewel, Permafrost's Concoction, and Regenator
Effects of Thief's Dime, Vampiric Talisman, and Momentum Capacitor
Effects of the Astral Arcanum and Gravistar Sabaton
Effects of the Abyssal Diving Suit and Mutated Truffle
Effects of Giant Pearl and Amidias' Pendant
Effects of Aquatic Emblem and Enchanted Pearl
Effects of Ocean's Crest and Luxor's Gift
Effects of Corrosive Spine and Lumenous Amulet
Effects of Sand Cloak and Alluring Bait");
            DisplayName.AddTranslation(GameCulture.Chinese, "荒芜之力");
            Tooltip.AddTranslation(GameCulture.Chinese,
@"'你将成为这个荒芜寒冷世界的最后幸存者'
拥有代达罗斯, 雪境暴徒，日影和星幻的套装效果
拥有欧米伽蓝，软壳，胜潮，幻渊鱼群和硫磺的套装效果
拥有潜遁者宝石，佩码·福洛斯特之秘药和再生冰盾的效果
拥有盗贼铸币，吸血鬼符咒和动量电容器的效果
拥有星辉秘术，星神隐壳和引力靴的效果
拥有深渊潜游服，突变松露和硫海遗爵之鳞的效果
拥有大珍珠和阿米迪亚斯之垂饰的效果
拥有海波纹章和附魔珍珠的效果
拥有海波项链，深潜者，变压护符和卢克索的礼物的效果
拥有腐蚀脊椎和流明护身符的效果
拥有沙尘披风和诱惑鱼饵的效果
召唤几个宠物");
        }

        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 20;
            Item.accessory = true;
            ItemID.Sets.ItemNoGravity[Item.type] = true;
            Item.rare = 11;
            Item.value = 600000;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            if (!FargowiltasSoulsDLC.Instance.CalamityLoaded) return;

            Mod.GetItem("MolluskEnchant").UpdateAccessory(player, hideVisual);
            Mod.GetItem("FathomSwarmerEnchant").UpdateAccessory(player, hideVisual);
            Mod.GetItem("DaedalusEnchant").UpdateAccessory(player, hideVisual);
            Mod.GetItem("UmbraphileEnchant").UpdateAccessory(player, hideVisual);
            Mod.GetItem("AstralEnchant").UpdateAccessory(player, hideVisual);
            Mod.GetItem("OmegaBlueEnchant").UpdateAccessory(player, hideVisual);
        }

        public override void AddRecipes()
        {
            if (!FargowiltasSoulsDLC.Instance.CalamityLoaded) return;

            Recipe recipe = CreateRecipe();

            recipe.AddIngredient(ModContent.ItemType<MolluskEnchant>());
            recipe.AddIngredient(ModContent.ItemType<FathomSwarmerEnchant>());
            recipe.AddIngredient(null, "DaedalusEnchant");
            recipe.AddIngredient(null, "UmbraphileEnchant");
            recipe.AddIngredient(null, "AstralEnchant");
            recipe.AddIngredient(null, "OmegaBlueEnchant");

            recipe.AddTile(ModLoader.GetMod("Fargowiltas").Find<ModTile>("CrucibleCosmosSheet").Type);
            recipe.Register();
        }
    }
}
