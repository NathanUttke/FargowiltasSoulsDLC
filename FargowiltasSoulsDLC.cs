using CalamityMod.Items.Armor;
using CalamityMod.Items.Placeables.Furniture;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;


namespace FargowiltasSoulsDLC
{
    public class FargowiltasSoulsDLC : ModSystem
    {
        internal static FargowiltasSoulsDLC Instance;

        internal bool CalamityLoaded;


        internal static readonly Dictionary<int, int> ModProjDict = new Dictionary<int, int>();

        public override void Load()
        {
            Instance = this;

            if (!ModLoader.TryGetMod("CalamityMod", out Mod CalamityMod))
            {
                // TryGetMod returns false if the mod is not currently loaded, so if this is the case, we just return early
                return;
            }

            if (1)
            {
                AddToggle("CalamityHeader", "Calamity Toggles", "CalamitySoul", "ffffff");
                //AddToggle("CalamityElementalQuiverConfig", "Elemental Quiver", "SnipersSoul", "ffffff");

                AddToggle("AnnihilationForce", "Force of Annihilation", "AnnihilationForce", "ffffff");
                AddToggle("CalamityValkyrieMinionConfig", "Valkyrie Minion", "AerospecEnchant", "ffffff");
                AddToggle("CalamityGladiatorLocketConfig", "Gladiator's Locket", "AerospecEnchant", "ffffff");
                AddToggle("CalamityUnstablePrismConfig", "Unstable Prism", "AerospecEnchant", "ffffff");
                AddToggle("CalamityFungalSymbiote", "Fungal Symbiote", "StatigelEnchant", "ffffff");
                AddToggle("CalamityAtaxiaEffectsConfig", "Ataxia Effects", "AtaxiaEnchant", "ffffff");
                AddToggle("CalamityChaosMinionConfig", "Chaos Spirit Minion", "AtaxiaEnchant", "ffffff");
                AddToggle("CalamityHallowedRuneConfig", "Hallowed Rune", "AtaxiaEnchant", "ffffff");
                AddToggle("CalamityEtherealExtorterConfig", "Ethereal Extorter", "AtaxiaEnchant", "ffffff");
                AddToggle("CalamityXerocEffectsConfig", "Xeroc Effects", "XerocEnchant", "ffffff");
                
                AddToggle("CalamityStatisBeltOfCursesConfig", "Statis' Void Sash", "FearmongerEnchant", "ffffff");

                AddToggle("DevastationForce", "Force of Devastation", "DevastationForce", "ffffff");
                AddToggle("CalamityReaverEffectsConfig", "Reaver Effects", "ReaverEnchant", "ffffff");
                AddToggle("CalamityReaverMinionConfig", "Reaver Orb Minion", "ReaverEnchant", "ffffff");
                AddToggle("CalamityPlagueHiveConfig", "Plague Hive", "PlagueReaperEnchant", "ffffff");
                AddToggle("CalamityPlaguedFuelPackConfig", "Plague Fuel Pack", "PlagueReaperEnchant", "ffffff");
                AddToggle("CalamityTheCamperConfig", "The Camper", "PlagueReaperEnchant", "ffffff");
                AddToggle("CalamityDevilMinionConfig", "Red Devil Minion", "DemonShadeEnchant", "ffffff");
                AddToggle("CalamityProfanedSoulConfig", "Profaned Soul Crystal", "DemonShadeEnchant", "ffffff");


                AddToggle("DesolationForce", "Force of Desolation", "DesolationForce", "ffffff");
                AddToggle("CalamitySnowRuffianWingsConfig", "Snow Ruffian Wings", "SnowRuffianEnchant", "ffffff");
                AddToggle("CalamityDaedalusEffectsConfig", "Daedalus Effects", "DaedalusEnchant", "ffffff");
                AddToggle("CalamityDaedalusMinionConfig", "Daedalus Crystal Minion", "DaedalusEnchant", "ffffff");
                AddToggle("CalamityPermafrostPotionConfig", "Permafrost's Concoction", "DaedalusEnchant", "ffffff");

                AddToggle("CalamityAstralStarsConfig", "Astral Stars", "AstralEnchant", "ffffff");
                AddToggle("CalamityGravistarSabatonConfig", "GravistarSabaton", "AstralEnchant", "ffffff");

                AddToggle("CalamityOmegaTentaclesConfig", "Omega Blue Tentacles", "OmegaBlueEnchant", "ffffff");
                AddToggle("CalamityDivingSuitConfig", "Abyssal Diving Suit", "OmegaBlueEnchant", "ffffff");
                AddToggle("CalamityReaperToothNecklaceConfig", "Reaper Tooth Necklace", "OmegaBlueEnchant", "ffffff");
                AddToggle("CalamityMutatedTruffleConfig", "Mutated Truffle", "OmegaBlueEnchant", "ffffff");
                AddToggle("CalamityUrchinConfig", "Victide Sea Urchin", "VictideEnchant", "ffffff");
                AddToggle("CalamityLuxorGiftConfig", "Luxor's Gift", "VictideEnchant", "ffffff");

                AddToggle("CalamityBloodflareEffectsConfig", "Bloodflare Effects", "BloodflareEnchant", "ffffff");
                AddToggle("CalamityPolterMinesConfig", "Polterghast Mines", "BloodflareEnchant", "ffffff");

                AddToggle("CalamitySilvaEffectsConfig", "Silva Effects", "SilvaEnchant", "ffffff");
                AddToggle("CalamitySilvaMinionConfig", "Silva Crystal Minion", "SilvaEnchant", "ffffff");
                AddToggle("CalamityGodlyArtifactConfig", "Godly Soul Artifact", "SilvaEnchant", "ffffff");
                AddToggle("CalamityYharimGiftConfig", "Yharim's Gift", "SilvaEnchant", "ffffff");
                AddToggle("CalamityFungalMinionConfig", "Fungal Clump Minion", "SilvaEnchant", "ffffff");
                AddToggle("CalamityPoisonSeawaterConfig", "Poisonous Sea Water", "SilvaEnchant", "ffffff");

                AddToggle("CalamityGodSlayerEffectsConfig", "God Slayer Effects", "GodSlayerEnchant", "ffffff");
                AddToggle("CalamityMechwormMinionConfig", "Mechworm Minion", "GodSlayerEnchant", "ffffff");
                AddToggle("CalamityNebulousCoreConfig", "Nebulous Core", "GodSlayerEnchant", "ffffff");
                AddToggle("CalamityAuricEffectsConfig", "Auric Tesla Effects", "AuricEnchant", "ffffff");
                AddToggle("CalamityWaifuMinionsConfig", "Elemental Waifus", "AuricEnchant", "ffffff");

                AddToggle("CalamityShellfishMinionConfig", "Shellfish Minions", "MolluskEnchant", "ffffff");
                AddToggle("CalamityGiantPearlConfig", "Giant Pearl", "MolluskEnchant", "ffffff");

                AddToggle("CalamityTarragonEffectsConfig", "Tarragon Effects", "TarragonEnchant", "ffffff");

            }
            else
            {
                AddToggle("CalamityHeader", "Enable Calamity for these Toggles", "", "ffffff");
            }

        }

        public void AddToggle(String toggle, String name, String item, String color)
        {
            ModTranslation text = LocalizationLoader.CreateTranslation(this, toggle);
            text.SetDefault("[i:" + Instance.Find<ModItem>(item).Type + "][c/" + color + ": " + name + "]");
            LocalizationLoader.AddTranslation(text);
        }

        public override void PostSetupContent()
        {
            try
            {
                CalamityLoaded = ModLoader.GetMod("CalamityMod") != null;                        
            }
            catch (Exception e)
            {
                Logger.Error("FargowiltasSoulsDLC PostSetupContent Error: " + e.StackTrace + e.Message);
            }
        }

        public override void AddRecipes()/* tModPorter Note: Removed. Use ModSystem.AddRecipes */
        {        
            if (CalamityLoaded)
            {
                CalamityRecipes();
            }
        }

        
        private void CalamityRecipes()
        {

            //Aerospec
            RecipeGroup group = new RecipeGroup(() => Lang.misc[37] + " Aerospec Helmet", ModContent.ItemType<AerospecHat>(), ModContent.ItemType<AerospecHeadgear>(), ModContent.ItemType<AerospecHelm>(), ModContent.ItemType<AerospecHood>(), ModContent.ItemType<AerospecHelmet>());
            RecipeGroup.RegisterGroup("FargowiltasSoulsDLC:AnyAerospecHelmet", group);

            //Ataxia
            group = new RecipeGroup(() => Lang.misc[37] + " Ataxia Helmet", ModContent.ItemType<AtaxiaHeadgear>(), ModContent.ItemType<AtaxiaHelm>(), ModContent.ItemType<AtaxiaHood>(), ModContent.ItemType<AtaxiaHelmet>(), ModContent.ItemType<AtaxiaMask>());
            RecipeGroup.RegisterGroup("FargowiltasSoulsDLC:AnyAtaxiaHelmet", group);

            //Auric
            group = new RecipeGroup(() => Lang.misc[37] + " Auric Helmet", ModContent.ItemType<AuricTeslaHelm>(), ModContent.ItemType<AuricTeslaPlumedHelm>(), ModContent.ItemType<AuricTeslaHoodedFacemask>(), ModContent.ItemType<AuricTeslaSpaceHelmet>(), ModContent.ItemType<AuricTeslaWireHemmedVisage>());
            RecipeGroup.RegisterGroup("FargowiltasSoulsDLC:AnyAuricHelmet", group);

            //Bloodflare
            group = new RecipeGroup(() => Lang.misc[37] + " Bloodflare Helmet", ModContent.ItemType<BloodflareHelm>(), ModContent.ItemType<BloodflareHelmet>(), ModContent.ItemType<BloodflareHornedHelm>(), ModContent.ItemType<BloodflareHornedMask>(), ModContent.ItemType<BloodflareMask>());
            RecipeGroup.RegisterGroup("FargowiltasSoulsDLC:AnyBloodflareHelmet", group);

            //Daedalus
            group = new RecipeGroup(() => Lang.misc[37] + " Daedalus Helmet", ModContent.ItemType<DaedalusHelm>(), ModContent.ItemType<DaedalusHelmet>(), ModContent.ItemType<DaedalusHat>(), ModContent.ItemType<DaedalusHeadgear>(), ModContent.ItemType<DaedalusVisor>());
            RecipeGroup.RegisterGroup("FargowiltasSoulsDLC:AnyDaedalusHelmet", group);

            // Godslayer
            group = new RecipeGroup(() => Lang.misc[37] + " Godslayer Helmet", ModContent.ItemType<GodSlayerHelm>(), ModContent.ItemType<GodSlayerHelmet>(), ModContent.ItemType<GodSlayerVisage>(), ModContent.ItemType<GodSlayerHornedHelm>(), ModContent.ItemType<GodSlayerMask>());
            RecipeGroup.RegisterGroup("FargowiltasSoulsDLC:AnyGodslayerHelmet", group);

            // Reaver
            group = new RecipeGroup(() => Lang.misc[37] + " Reaver Helmet", ModContent.ItemType<ReaverHelm>(), ModContent.ItemType<ReaverVisage>(), ModContent.ItemType<ReaverMask>(), ModContent.ItemType<ReaverHelmet>(), ModContent.ItemType<ReaverCap>());
            RecipeGroup.RegisterGroup("FargowiltasSoulsDLC:AnyReaverHelmet", group);

            //Silva
            group = new RecipeGroup(() => Lang.misc[37] + " Silva Helmet", ModContent.ItemType<SilvaHelm>(), ModContent.ItemType<SilvaHornedHelm>(), ModContent.ItemType<SilvaMaskedCap>(), ModContent.ItemType<SilvaHelmet>(), ModContent.ItemType<SilvaMask>());
            RecipeGroup.RegisterGroup("FargowiltasSoulsDLC:AnySilvaHelmet", group);

            //Statigel
            group = new RecipeGroup(() => Lang.misc[37] + " Statigel Helmet", ModContent.ItemType<StatigelHelm>(), ModContent.ItemType<StatigelHeadgear>(), ModContent.ItemType<StatigelCap>(), ModContent.ItemType<StatigelHood>(), ModContent.ItemType<StatigelMask>());
            RecipeGroup.RegisterGroup("FargowiltasSoulsDLC:AnyStatigelHelmet", group);
            //evil effigy
            group = new RecipeGroup(() => Lang.misc[37] + " Evil Effigy", ModContent.ItemType<CorruptionEffigy>(), ModContent.ItemType<CrimsonEffigy>());
            RecipeGroup.RegisterGroup("FargowiltasSoulsDLC:AnyEvilEffigy", group);

            //Tarragon
            group = new RecipeGroup(() => Lang.misc[37] + " Tarragon Helmet", ModContent.ItemType<TarragonHelm>(), ModContent.ItemType<TarragonVisage>(), ModContent.ItemType<TarragonMask>(), ModContent.ItemType<TarragonHornedHelm>(), ModContent.ItemType<TarragonHelmet>());
            RecipeGroup.RegisterGroup("FargowiltasSoulsDLC:AnyTarragonHelmet", group);

            //Victide
            group = new RecipeGroup(() => Lang.misc[37] + " Victide Helmet", ModContent.ItemType<VictideHelm>(), ModContent.ItemType<VictideVisage>(), ModContent.ItemType<VictideMask>(), ModContent.ItemType<VictideHelmet>(), ModContent.ItemType<VictideHeadgear>());
            RecipeGroup.RegisterGroup("FargowiltasSoulsDLC:AnyVictideHelmet", group);

            //Wulfrum
            group = new RecipeGroup(() => Lang.misc[37] + " Wulfrum Helmet", ModContent.ItemType<WulfrumHelm>(), ModContent.ItemType<WulfrumHeadgear>(), ModContent.ItemType<WulfrumHood>(), ModContent.ItemType<WulfrumHelmet>(), ModContent.ItemType<WulfrumMask>());
            RecipeGroup.RegisterGroup("FargowiltasSoulsDLC:AnyWulfrumHelmet", group);
        }

        private void SoARecipes()
        {
            // Flarium
            RecipeGroup.RegisterGroup("FargowiltasSoulsDLC:AnyFlariumHelmet",
                new RecipeGroup(() => Lang.misc[37] + " Flarium Helmet",
                    ModContent.ItemType<FlariumCowl>(), ModContent.ItemType<FlariumHelmet>(), ModContent.ItemType<FlariumHood>(), ModContent.ItemType<FlariumCrown>(), ModContent.ItemType<FlariumMask>()));

            // Asthraltite
            RecipeGroup.RegisterGroup("FargowiltasSoulsDLC:AnyAstralHelmet",
                new RecipeGroup(() => Lang.misc[37] + " Asthraltite Helmet",
                    ModContent.ItemType<AsthralMelee>(), ModContent.ItemType<AsthralRanged>(), ModContent.ItemType<AsthralMage>(), ModContent.ItemType<AsthralSummon>(), ModContent.ItemType<AsthralThrown>()));
        }
    }
}