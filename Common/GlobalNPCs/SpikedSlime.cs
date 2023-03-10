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

	public class SpikedSlime : GlobalNPC
	{
		// Here we make sure to only instance this GlobalItem for the Copper Shortsword, by checking item.type
		public override bool AppliesToEntity(NPC npc, bool lateInstatiation)
		{
			return npc.type == NPCID.SlimeSpiked;
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
				int type = ProjectileID.SpikedSlimeSpike;

				Player target = Main.player[npc.target];


				if (attackCounter <= 0 && Main.netMode != NetmodeID.MultiplayerClient)
				{

					npc.TargetClosest(true);
					Vector2 direction = (target.Center - npc.Center).SafeNormalize(Vector2.UnitY);
					direction = direction.RotatedByRandom(MathHelper.ToRadians(10));
					int damage = npc.damage = 12;
					int projectile = Projectile.NewProjectile(npc.GetSource_FromAI(), npc.Center, direction * 12, type, damage, 40, Main.myPlayer);
					Main.projectile[projectile].timeLeft = 180;
					attackCounter = 200;
					npc.netUpdate = true;
				}
				npc.netUpdate = true;

			}

		}


	}
}
