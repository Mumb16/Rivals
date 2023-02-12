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

namespace Rivals.Common.GlobalItems
{

	public class LostSoul : GlobalProjectile
	{
		// Here we make sure to only instance this GlobalItem for the Copper Shortsword, by checking item.type
		public override bool AppliesToEntity(Projectile projectile, bool lateInstatiation)
		{
			return projectile.type == ProjectileID.LostSoulFriendly;
		}

		public override void SetDefaults(Projectile projectile)
		{
	
		}

	
	}
}
