using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;

namespace FargowiltasSoulsDLC
{
    public partial class FargoDLCPlayer : ModPlayer
    {
        public bool PetsActive = true;

        public override void ResetEffects()
        {
          
            if (FargowiltasSoulsDLC.Instance.CalamityLoaded)
                CalamityResetEffects();

            PetsActive = true;
        }

        public override void PostUpdate()
        {

        }

        public override void ModifyHitNPCWithProj(Projectile proj, NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
        {
          
        }

        public override void ModifyHitNPC(Item item, NPC target, ref int damage, ref float knockback, ref bool crit)
        {
           
        }

        public override void OnHitNPCWithProj(Projectile proj, NPC target, int damage, float knockback, bool crit)
        {
          
        }

        public override void OnHitNPC(Item item, NPC target, int damage, float knockback, bool crit)
        {

        }

        public void AllDamageUp(float dmg)
        {
            Player.GetDamage(DamageClass.Magic) += dmg;
            Player.GetDamage(DamageClass.Melee) += dmg;
            Player.GetDamage(DamageClass.Ranged) += dmg;
            Player.GetDamage(DamageClass.Summon) += dmg;

           
        }

        public void AllCritUp(int crit)
        {
            Player.GetCritChance(DamageClass.Generic) += crit;
            Player.GetCritChance(DamageClass.Ranged) += crit;
            Player.GetCritChance(DamageClass.Magic) += crit;

           
        }

        public void AddPet(bool toggle, bool vanityToggle, int buff, int proj)
        {
            if (vanityToggle)
            {
                PetsActive = false;
                return;
            }

            if (SoulConfig.Instance.GetValue(toggle) && Player.FindBuffIndex(buff) == -1 && Player.ownedProjectileCounts[proj] < 1)
            {
                Projectile.NewProjectile(Player.Center.X, Player.Center.Y, 0f, -1f, proj, 0, 0f, Player.whoAmI);
            }
        }

        public void AddMinion(bool toggle, int proj, int damage, float knockback)
        {
            if (Player.ownedProjectileCounts[proj] < 1 && Player.whoAmI == Main.myPlayer && SoulConfig.Instance.GetValue(toggle))
                Projectile.NewProjectile(Player.Center, 0f, -1f, proj, damage, knockback, Main.myPlayer);
        }
    }
}
