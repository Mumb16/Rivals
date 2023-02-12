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

	public class WofEye : GlobalNPC
	{
		// Here we make sure to only instance this GlobalItem for the Copper Shortsword, by checking item.type
		public override bool AppliesToEntity(NPC npc, bool lateInstatiation)
		{
			return npc.type == NPCID.WallofFleshEye;
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
		

				Timer++;
				if (Timer > 1000 && Main.masterMode && npc.life <= 8000)
				{


				for (int i = 0; i < 360; i += 5)
				{
					Vector2 circular = new Vector2(12, 0).RotatedBy(MathHelper.ToRadians(i));
					Vector2 dustVelo = circular * 4f;
					Dust dust = Dust.NewDustDirect(npc.Center - new Vector2(5) + circular, 0, 0, DustID.CorruptTorch, 0, 0, npc.alpha);
					dust.velocity *= 1f;
					dust.velocity += dustVelo;
					dust.scale = 2f;
					dust.noGravity = true;
				}
				if (Main.netMode != NetmodeID.MultiplayerClient)
				{
					for (int i = 0; i < 360; i += 36)
					{
						Projectile.NewProjectile(npc.GetSource_FromAI(), npc.Center, new Vector2(-3, 0).RotatedBy(MathHelper.ToRadians(i)), ProjectileID.DemonSickle, npc.damage, 0, Main.myPlayer);
				 	}
			   	}

				Timer = 0;

				}
			}

		}
	}

