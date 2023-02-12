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

	public class TheHungry : GlobalNPC
	{
		// Here we make sure to only instance this GlobalItem for the Copper Shortsword, by checking item.type
		public override bool AppliesToEntity(NPC npc, bool lateInstatiation)
		{
			return npc.type == NPCID.TheHungry;
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
				if (Timer > 1000 && Main.masterMode)
				{

			
					for (int i = 0; i < 1; i++)
					{
						int type = ProjectileID.BloodShot;

					


						npc.TargetClosest(true);
						Vector2 direction = (target.Center - npc.Center).SafeNormalize(Vector2.UnitY);
						direction = direction.RotatedByRandom(MathHelper.ToRadians(40));
						int damage = npc.damage = 12;



						int projectile = Projectile.NewProjectile(npc.GetSource_FromAI(), npc.Center, direction * 2, type, damage, 10f, Main.myPlayer);



					}
				


					Timer = 0;

				}
			}

		}
	}

