using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.ItemDropRules;
using Microsoft.Xna.Framework;
using Terraria.ModLoader.Utilities;
using Rivals.Content.Tiles;
using Rivals.Content.Items;
using Rivals.Content.Items.Weapons;
using System.IO;
using Rivals.Content.Projectiles;
using Terraria.Audio;
namespace Rivals.Common.GlobalItems
{

	public class BrainOfCthulhu : GlobalNPC
	{
		// Here we make sure to only instance this GlobalItem for the Copper Shortsword, by checking item.type
		public override bool AppliesToEntity(NPC npc, bool lateInstatiation)
		{
			return npc.type == NPCID.BrainofCthulhu;
		}

		public override void SetDefaults(NPC npc)
		{
		
		
		}
		public override bool InstancePerEntity => true;

		private int attackCounter;
		public int Timer;
       public override void AI(NPC npc)
       {

			Player player = Main.player[npc.target];

			Player target = Main.player[npc.target];
			if (Main.netMode != NetmodeID.MultiplayerClient && Main.masterMode)
			{
			
				if (attackCounter > 0)
				{
					attackCounter--;
				}

		

				if (attackCounter <= 0 && npc.life <= 2709)
				{
					for (int i = 0; i < 360; i += 5)
					{
						Vector2 circular = new Vector2(12, 0).RotatedBy(MathHelper.ToRadians(i));
						Vector2 dustVelo = circular * 4f;
						Dust dust = Dust.NewDustDirect(npc.Center - new Vector2(5) + circular, 0, 0, DustID.RedTorch, 0, 0, npc.alpha);
						dust.velocity *= 1f;
						dust.velocity += dustVelo;
						dust.scale = 2f;
						dust.noGravity = true;
					}
					if (Main.netMode != NetmodeID.MultiplayerClient)
					{
						for (int i = 0; i < 360; i += 72)
						{
							Projectile.NewProjectile(npc.GetSource_FromAI(), npc.Center, new Vector2(-10, 0).RotatedBy(MathHelper.ToRadians(i)), ProjectileID.BloodNautilusShot, npc.damage, 0, Main.myPlayer);
						}
					}
					SoundEngine.PlaySound(SoundID.Roar, npc.position);
					npc.position = player.position + new Vector2(0, -500);
					attackCounter = 1000;
				
				}

				Timer++;
				if (Timer > 500 && npc.life <= 1200)
				{

					npc.position = player.position + new Vector2(700, -300);
					for (int i = 0; i < 6; i++)
					{
						int type = ProjectileID.GoldenShowerHostile;

					


						npc.TargetClosest(true);
						Vector2 direction = (target.Center - npc.Center).SafeNormalize(Vector2.UnitY);
						direction = direction.RotatedByRandom(MathHelper.ToRadians(360));
						int damage = npc.damage = 12;



						int projectile = Projectile.NewProjectile(npc.GetSource_FromAI(), npc.Center, direction * 10, type, damage, 10f, Main.myPlayer);



					}
				


					Timer = 0;

				}
			}

		}


	}
}
