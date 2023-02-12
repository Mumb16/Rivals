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

	public class KingSlime : GlobalNPC
	{
		// Here we make sure to only instance this GlobalItem for the Copper Shortsword, by checking item.type
		public override bool AppliesToEntity(NPC npc, bool lateInstatiation)
		{
			return npc.type == NPCID.KingSlime;
		}

		public override void SetDefaults(NPC npc)
		{
		
		
		}
		public override bool InstancePerEntity => true;

		private int attackCounter;
		public int Timer;
       public override void AI(NPC npc)
       {



			if (Main.netMode != NetmodeID.MultiplayerClient && Main.masterMode)
			{
			
				if (attackCounter > 0)
				{
					attackCounter--;
				}

				Player player = Main.player[npc.target];

				if (attackCounter <= 0 && npc.life <= 1785)
				{
				
					if (Main.netMode != NetmodeID.MultiplayerClient)
					{
						for (int i = 0; i < 180; i += 4)
						{
							Projectile.NewProjectile(npc.GetSource_FromAI(), npc.Center, new Vector2(-10, 0).RotatedBy(MathHelper.ToRadians(i)), ProjectileID.SpikedSlimeSpike, npc.damage, 0, Main.myPlayer);
						}
					}
					SoundEngine.PlaySound(SoundID.Roar, npc.position);
					npc.position = player.position + new Vector2(0, -850);
					attackCounter = 1000;
				
				}


			}

		}


	}
}
