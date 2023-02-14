﻿using CalamityMod.Buffs.Pets;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace FargowiltasSoulsDLC
{
    class FargoDLCGlobalProjectile : GlobalProjectile
    {
        public override bool InstancePerEntity
        {
            get
            {
                return true;
            }
        }

        private readonly Mod calamity = ModLoader.GetMod("CalamityMod");

        public int ModProjID;

        public override void SetDefaults(Projectile projectile)
        {
            FargowiltasSoulsDLC.ModProjDict.TryGetValue(projectile.type, out ModProjID);
        }


        private void KillPet(Projectile projectile, Player player, int buff, bool enchant, bool toggle, bool minion = false)
        {
            FargoDLCPlayer modPlayer = player.GetModPlayer<FargoDLCPlayer>();

            if (player.FindBuffIndex(buff) == -1)
            {
                if (player.dead || !enchant || !SoulConfig.Instance.GetValue(toggle) || (!modPlayer.PetsActive && !minion))
                    projectile.Kill();
            }
        }

        public override void OnHitNPC(Projectile projectile, NPC target, int damage, float knockback, bool crit)
        {
            if (FargowiltasSoulsDLC.Instance.ThoriumLoaded) ThoriumOnHit(projectile, crit);
        }

        private void ThoriumOnHit(Projectile projectile, bool crit)
        {
            Player player = Main.player[Main.myPlayer];
            FargoDLCPlayer modPlayer = player.GetModPlayer<FargoDLCPlayer>();

            if (SoulConfig.Instance.GetValue(SoulConfig.Instance.thoriumToggles.JesterBell))
            {
                //jester effect
                if (modPlayer.JesterEnchant && crit)
                {
                    for (int m = 0; m < 1000; m++)
                    {
                        Projectile projectile2 = Main.projectile[m];
                        if (projectile2.active && projectile2.type == thorium.Find<ModProjectile>("JestersBell").Type)
                        {
                            return;
                        }
                    }
                    SoundEngine.PlaySound(SoundID.Item35, projectile.position);
                    Projectile.NewProjectile(player.Center.X, player.Center.Y - 50f, 0f, 0f, thorium.Find<ModProjectile>("JestersBell").Type, 0, 0f, projectile.owner, 0f, 0f);
                    Projectile.NewProjectile(player.Center.X, player.Center.Y, 0f, 0f, thorium.Find<ModProjectile>("JestersBell2").Type, 0, 0f, projectile.owner, 0f, 0f);
                }
            }
        }

        public static Projectile[] XWay(int num, Vector2 pos, int type, float speed, int damage, float knockback)
        {
            Projectile[] projs = new Projectile[num];
            double spread = 2 * Math.PI / num;
            for (int i = 0; i < num; i++)
                projs[i] = NewProjectileDirectSafe(pos, new Vector2(speed, speed).RotatedBy(spread * i), type, damage, knockback, Main.myPlayer);
            return projs;
        }

        public static Projectile NewProjectileDirectSafe(Vector2 pos, Vector2 vel, int type, int damage, float knockback, int owner = 255, float ai0 = 0f, float ai1 = 0f)
        {
            int p = Projectile.NewProjectile(pos, vel, type, damage, knockback, owner, ai0, ai1);
            return (p < 1000) ? Main.projectile[p] : null;
        }
    }
}
