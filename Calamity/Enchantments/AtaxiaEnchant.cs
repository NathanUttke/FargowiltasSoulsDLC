using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using CalamityMod.Items.Armor;
using CalamityMod.Items.Weapons.Rogue;
using CalamityMod.Items.Weapons.Ranged;
using CalamityMod.Items.Weapons.Magic;
using CalamityMod.Items.Weapons.Melee;
using CalamityMod.Items.Accessories;

namespace FargowiltasSoulsDLC.Calamity.Enchantments
{
    public class AtaxiaEnchant : ModItem
    {
        private readonly Mod calamity = ModLoader.GetMod("CalamityMod");

        public override bool IsLoadingEnabled(Mod mod)/* tModPorter Suggestion: If you return false for the purposes of manual loading, use the [Autoload(false)] attribute on your class instead */
        {
            return ModLoader.GetMod("CalamityMod") != null;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Hydrothermic Enchantment");
            Tooltip.SetDefault(
@"''
You have a 20% chance to emit a blazing explosion on hit
Melee attacks and projectiles cause chaos flames to erupt on enemy hits
You have a 50% chance to fire a homing chaos flare when using ranged weapons
Magic attacks summon damaging and healing flare orbs on hit
Summons a hydrothermic vent to protect you
Rogue weapons have a 10% chance to unleash a volley of chaos flames around the player
Effects of Hallowed Rune and Ethereal Extorter");
            DisplayName.AddTranslation(GameCulture.Chinese, "渊泉魔石");
            Tooltip.AddTranslation(GameCulture.Chinese, 
@"''
你受伤时有20%的几率在原地产生一场烈焰爆炸
近战攻击和弹幕在击中敌人时喷发出混沌火焰
使用远程武器时有50%的几率发射追踪的混沌火焰
魔法攻击产生伤害火球和治疗火球
召唤沸腾渊泉保护你
盗贼武器有10%的几率释放混沌火焰
拥有神圣符文和虚空掠夺者的效果");
        }

        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 20;
            Item.accessory = true;
            ItemID.Sets.ItemNoGravity[Item.type] = true;
            Item.rare = 8;
            Item.value = 1000000;
        }

        public override void ModifyTooltips(List<TooltipLine> list)
        {
            foreach (TooltipLine tooltipLine in list)
            {
                if (tooltipLine.Mod == "Terraria" && tooltipLine.Name == "ItemName")
                {
                    tooltipLine.OverrideColor = new Color(194, 89, 89);
                }
            }
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            if (!FargowiltasSoulsDLC.Instance.CalamityLoaded) return;

            if (SoulConfig.Instance.GetValue(SoulConfig.Instance.calamityToggles.AtaxiaEffects))
            {
                calamity.Call("SetSetBonus", player, "ataxia", true);
                calamity.Call("SetSetBonus", player, "ataxia_melee", true);
                calamity.Call("SetSetBonus", player, "ataxia_ranged", true);
                calamity.Call("SetSetBonus", player, "ataxia_magic", true);
                calamity.Call("SetSetBonus", player, "ataxia_rogue", true);
            }

            if (SoulConfig.Instance.calamityToggles.HallowedRune)
            {
                calamity.GetItem("HallowedRune").UpdateAccessory(player, hideVisual);
            }

            if (SoulConfig.Instance.calamityToggles.HallowedRune)
            {
                calamity.GetItem("EtherealExtorter").UpdateAccessory(player, hideVisual);
            } 

            if (SoulConfig.Instance.GetValue(SoulConfig.Instance.calamityToggles.ChaosMinion))
            {
                //summon
                calamity.Call("SetSetBonus", player, "ataxia_summon", true);
                if (player.whoAmI == Main.myPlayer)
                {
                    if (player.FindBuffIndex(calamity.Find<ModBuff>("ChaosSpirit").Type) == -1)
                    {
                        player.AddBuff(calamity.Find<ModBuff>("ChaosSpirit").Type, 3600, true);
                    }
                    if (player.ownedProjectileCounts[calamity.Find<ModProjectile>("ChaosSpirit").Type] < 1)
                    {
                        Projectile.NewProjectile(player.Center.X, player.Center.Y, 0f, -1f, calamity.Find<ModProjectile>("ChaosSpirit").Type, (int)(190f * player.GetDamage(DamageClass.Summon)), 0f, Main.myPlayer, 0f, 0f);
                    }
                }
            }
        }

        public override void AddRecipes()
        {
            if (!FargowiltasSoulsDLC.Instance.CalamityLoaded) return;

            Recipe recipe = CreateRecipe();

            recipe.AddRecipeGroup("FargowiltasSoulsDLC:AnyAtaxiaHelmet");
            recipe.AddIngredient(ModContent.ItemType<AtaxiaArmor>());
            recipe.AddIngredient(ModContent.ItemType<AtaxiaSubligar>());
            recipe.AddIngredient(ModContent.ItemType<HallowedRune>());
            recipe.AddIngredient(ModContent.ItemType<EtherealExtorter>());
            recipe.AddIngredient(ModContent.ItemType<BarracudaGun>());

            recipe.AddTile(TileID.CrystalBall);
            recipe.Register();
        }
    }
}
