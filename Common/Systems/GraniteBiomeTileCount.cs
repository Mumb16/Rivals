using System;
using Rivals.Content.Tiles;
using Terraria.ModLoader;
using Terraria;
using Terraria.ID;

namespace Rivals.Common.Systems
{
	public class GraniteBiomeTileCount : ModSystem
	{
		public int GraniteBlock;

		public override void TileCountsAvailable(ReadOnlySpan<int> tileCounts)
		{
			GraniteBlock = tileCounts[TileID.Granite];
		}
	}
}