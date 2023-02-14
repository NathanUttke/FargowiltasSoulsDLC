using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Terraria;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

namespace FargowiltasSoulsDLC.Base.NPCs.Ceiling
{
    public class CeilingProj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ceiling of Moon Lord");
        }

        public override void SetDefaults()
        {
            Projectile.width = 420;
            Projectile.height = 190;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = false;
            Projectile.hide = true;
            //projectile.GetGlobalProjectile<Projectiles.FargoGlobalProjectile>().TimeFreezeImmune = true;
        }

        public override void DrawBehind(int index, List<int> behindNPCsAndTiles, List<int> behindNPCs, List<int> behindProjectiles, List<int> overPlayers, List<int> overWiresUI)
        {
            if (Projectile.hide)
                drawCacheProjsBehindNPCs.Add(index);
        }

        public override void AI()
        {
            int ai1 = (int)Projectile.ai[1];
            if (Projectile.ai[1] >= 0f && Projectile.ai[1] < 200f &&
                Main.npc[ai1].active && Main.npc[ai1].type == ModContent.NPCType<CeilingOfMoonLord>())
            {
                Projectile.Center = Main.npc[ai1].Center;
                Projectile.timeLeft = 2;
            }
            else
            {
                Projectile.Kill();
                return;
            }
        }

        public override bool? CanDamage()/* tModPorter Suggestion: Return null instead of true */
        {
            return false;
        }

        public override Color? GetAlpha(Color lightColor)
        {
            return Color.White;
        }

        public override bool PreDraw(ref Color lightColor)
        {
            Texture2D texture2D13 = TextureAssets.Projectile[Projectile.type].Value;
            int num156 = TextureAssets.Projectile[Projectile.type].Value.Height / Main.projFrames[Projectile.type]; //ypos of lower right corner of sprite to draw
            int y3 = num156 * Projectile.frame; //ypos of upper left corner of sprite to draw
            Rectangle rectangle = new Rectangle(0, y3, texture2D13.Width, num156);
            Vector2 origin2 = rectangle.Size() / 2f;

            for (int i = 0; i < Main.screenWidth; i += 210)
            {
                Vector2 drawPos = new Vector2(Main.screenPosition.X + i, Projectile.Center.Y - 50);
                Main.spriteBatch.Draw(texture2D13, drawPos - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY), new Microsoft.Xna.Framework.Rectangle?(rectangle), Projectile.GetAlpha(lightColor), Projectile.rotation, origin2, Projectile.scale, SpriteEffects.None, 0f);
            }
            return false;
        }
    }
}