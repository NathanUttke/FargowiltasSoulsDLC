using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using Microsoft.Xna.Framework.Graphics;

namespace FargowiltasSoulsDLC.Base.NPCs.Guntera
{
    public class GunMagnum : GunCelebration
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Venus Magnum");
        }

        public override void SetDefaults()
        {
            base.SetDefaults();
            NPC.width = 52;
            NPC.height = 28;
        }

        public override void Offset(NPC guntera)
        {
            NPC.Center = guntera.Center + new Vector2(-36, -42).RotatedBy(guntera.rotation);
        }
    }
}