using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace FargowiltasSoulsDLC.Calamity.Forces
{
    public class DevastationForce : ModItem
    {
        private readonly Mod calamity = ModLoader.GetMod("CalamityMod");

        public override bool IsLoadingEnabled(Mod mod)/* tModPorter Suggestion: If you return false for the purposes of manual loading, use the [Autoload(false)] attribute on your class instead */
        {
            return ModLoader.GetMod("CalamityMod") != null;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Force of Devastation");
            Tooltip.SetDefault(
@"'Rain hell down on those who resist your power'
All armor bonuses from Wulfrum, Reaver, Plague Reaper, and Demonshade
Effects of Trinket of Chi and Plague Hive
Effects of Plagued Fuel Pack, The Camper, and Profaned Soul Crystal");
            DisplayName.AddTranslation(GameCulture.Chinese, "毁灭之力");
            Tooltip.AddTranslation(GameCulture.Chinese,
@"'让那些反抗你的人下地狱吧'
拥有钨钢, 掠夺者，瘟疫死神和魔影的套装效果
拥有气功念珠，传说龟壳和瘟疫蜂巢的效果
拥有瘟疫燃料背包，蜜蜂护符，露营者和渎神魂晶的效果
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

            Mod.GetItem("WulfrumEnchant").UpdateAccessory(player, hideVisual);
            Mod.GetItem("ReaverEnchant").UpdateAccessory(player, hideVisual);
            Mod.GetItem("PlagueReaperEnchant").UpdateAccessory(player, hideVisual);
            Mod.GetItem("DemonShadeEnchant").UpdateAccessory(player, hideVisual);
        }

        public override void AddRecipes()
        {
            if (!FargowiltasSoulsDLC.Instance.CalamityLoaded) return;

            Recipe recipe = CreateRecipe();

            recipe.AddIngredient(null, "WulfrumEnchant");
            recipe.AddIngredient(null, "ReaverEnchant");
            recipe.AddIngredient(null, "PlagueReaperEnchant");
            recipe.AddIngredient(null, "DemonShadeEnchant");

            recipe.AddTile(ModLoader.GetMod("Fargowiltas").Find<ModTile>("CrucibleCosmosSheet").Type);
            recipe.Register();
        }
    }
}
