using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.IO;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.Generation;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Terraria.WorldBuilding;
using Rivals.Content.Items.Weapons;
using Rivals.Content.Items.Accesories;
namespace Rivals
{
    public class Modworld : ModSystem
    {




		public override void PostWorldGen()
		{
		
			int[] itemsToPlaceInGoldenChests = { ModContent.ItemType<RockStaff>(), ModContent.ItemType<AncientBlade>(), ModContent.ItemType<AncientWoodBow>(), ModContent.ItemType<NecklaceOfLove>() };
			int itemsToPlaceInGoldenChestsChoice = 0;
			for (int chestIndex = 0; chestIndex < 1000; chestIndex++)
			{
				Chest chest = Main.chest[chestIndex];
				// If you look at the sprite for Chests by extracting Tiles_21.xnb, you'll see that the 12th chest is the Ice Chest. Since we are counting from 0, this is where 11 comes from. 36 comes from the width of each tile including padding. 
				if (chest != null && Main.tile[chest.x, chest.y].TileType == TileID.Containers && Main.tile[chest.x, chest.y].TileFrameX == 1 * 36)
				{
					for (int inventoryIndex = 0; inventoryIndex < 40; inventoryIndex++)
					{
						if (chest.item[inventoryIndex].type == ItemID.None)
						{
							chest.item[inventoryIndex].SetDefaults(itemsToPlaceInGoldenChests[itemsToPlaceInGoldenChestsChoice]);
							itemsToPlaceInGoldenChestsChoice = (itemsToPlaceInGoldenChestsChoice + 1) % itemsToPlaceInGoldenChests.Length;
							// Alternate approach: Random instead of cyclical: chest.item[inventoryIndex].SetDefaults(Main.rand.Next(itemsToPlaceInIceChests));
							break;
						}
					}
				}
			}
		}
	}
}
