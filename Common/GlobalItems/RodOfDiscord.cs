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

	public class RodOfDiscord : GlobalItem
	{
		public override bool AppliesToEntity(Item item, bool lateInstatiation)
		{
			return item.type == ItemID.RodofDiscord;
		}

		public override void SetDefaults(Item item)
		{
		
;
		}


	
	}
    
}
