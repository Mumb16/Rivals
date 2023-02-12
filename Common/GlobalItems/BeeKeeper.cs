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

	public class BeeKeeper : GlobalItem
	{
		// Here we make sure to only instance this GlobalItem for the Copper Shortsword, by checking item.type
		public override bool AppliesToEntity(Item item, bool lateInstatiation)
		{
			return item.type == ItemID.BeeKeeper;
		}

		public override void SetDefaults(Item item)
		{
			item.damage = 38;
		    item.scale = 1.60f;
		}

	
	}
}
