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

	public class NightsEdge : GlobalItem
	{
		// Here we make sure to only instance this GlobalItem for the Copper Shortsword, by checking item.type
		public override bool AppliesToEntity(Item item, bool lateInstatiation)
		{
			return item.type == ItemID.NightsEdge;
		}

		public override void SetDefaults(Item item)
		{
			item.damage = 52;
		    item.scale = 2.10f;
		}

	
	}
}
