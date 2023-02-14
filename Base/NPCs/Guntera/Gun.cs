using Terraria;
using Terraria.ModLoader;
using Terraria.Localization;

namespace FargowiltasSoulsDLC.Base.NPCs.Guntera
{
    public class Gun : ModBuff
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("gun");
            Description.SetDefault("gun");
            Main.debuff[Type] = true;
            Main.buffNoSave[Type] = true;
            longerExpertDebuff/* tModPorter Note: Removed. Use BuffID.Sets.LongerExpertDebuff instead */ = false;
            canBeCleared/* tModPorter Note: Removed. Use BuffID.Sets.NurseCannotRemoveDebuff instead, and invert the logic */ = true;
        }
    }
}