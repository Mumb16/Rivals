
using Rivals.Content;
using System;
using Terraria;
using Terraria.ModLoader;
using Rivals.Content.Projectiles.Minions;
using System.Collections.Generic;
using Rivals.Common.Systems;
using Microsoft.Xna.Framework;
using Rivals.Content.Items.Accesories;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Rivals.Content.Items.Weapons.Whips;
using Rivals.Content.Items.Placeable;
using Rivals.Content.Items.Consumables;
using Rivals.Content.Items.Armor.Vanity;
using Rivals.Content.NPCs.Bosses;
using System.IO;
using Rivals.Content.Items.Weapons;
using Rivals.Content.Items;
using Rivals.Content.Items.Tools;
using Rivals.Content.NPCs.Bosses.MiniBosses;
using Terraria.Achievements;
namespace Rivals
{
	// This is a partial class, meaning some of its parts were split into other files. See ExampleMod.*.cs for other portions.
	public class Rivals : Mod
	{
	

		public override void PostSetupContent()
		{
		

			Mod bossChecklist = ModLoader.GetMod("BossChecklist");
			if (bossChecklist != null)
			{
				bossChecklist.Call(
					"AddBoss",
					2.5f,
					new List<int> { ModContent.NPCType<Illusio>(), ModContent.NPCType<Illusio>() },
					this, // Mod
					"Illusio",
					(Func<bool>)(() => DownedSystemIllusio.downedIllusio),
					ModContent.ItemType<ConfusingLookingRune>(),

					new List<int> { ModContent.ItemType<Scarab>(),  ModContent.ItemType<SandStoneWhip>(),  ModContent.ItemType<Woestijn>(), ItemID.HealingPotion, ItemID.SandstorminaBottle, ModContent.ItemType<AncientStone>(), ModContent.ItemType<HeatWave>(), ModContent.ItemType<SunKnifes>(), ModContent.ItemType<Sandcanon>(), ModContent.ItemType<IllusioScrap>() },
				   	$"Use a [i:{ModContent.ItemType<ConfusingLookingRune>()}] in the desert"


				);
			
			}
			if (bossChecklist != null)
			{
				bossChecklist.Call(
					"AddBoss",
					5.5f,
					new List<int> { ModContent.NPCType<Blizzard>(), ModContent.NPCType<Blizzard>() },
					this, // Mod
					"Blizzard",
					(Func<bool>)(() => DownedBossSystem.downedBlizzard),
					ModContent.ItemType<IceRelic>(),
					new List<int> { ModContent.ItemType<IceStrike>(), ModContent.ItemType<IceShot>(), ModContent.ItemType<FrostyStaff>(), ModContent.ItemType<IceHamaxe>(),  ModContent.ItemType<Blizzardium>(), ModContent.ItemType<IcetaniumBar>(), ItemID.LesserHealingPotion},
					$"Use a [i:{ModContent.ItemType<IceRelic>()}] in the snow biome at night"


				);

			}
			if (bossChecklist != null)
			{
				bossChecklist.Call(
					"AddBoss",
					8.5f,
					new List<int> { ModContent.NPCType<Shadow>(), ModContent.NPCType<Shadow>() },
					this, // Mod
					"Shadecrystal apprentice",
					(Func<bool>)(() => DownedShadow.downedShadow),
					ModContent.ItemType<RustySchaduw>(),
					new List<int> { ModContent.ItemType<ShadecrystalKnife>(), ModContent.ItemType<ShadecrystalRing>(), ItemID.GreaterHealingPotion },
					$"Use a [i:{ModContent.ItemType<RustySchaduw>()}] in space"


				);

			}
			if (bossChecklist != null)
			{
				bossChecklist.Call(
					"AddBoss",
					11.5f,
					new List<int> { ModContent.NPCType<VoltHead>(), ModContent.NPCType<VoltHead>() },
					this, // Mod
					"Volt",
					(Func<bool>)(() => DownedSystemVolt.downedVolt),
					ModContent.ItemType<ConnectionProbe>(),
					new List<int> { ModContent.ItemType<PlasmarangItem>(), ModContent.ItemType<RicochetPistol>(), ModContent.ItemType<VoltBow>(), ModContent.ItemType<Prismal>(), ModContent.ItemType<NeutronFragment>(), ModContent.ItemType<VolticJuice>(), ItemID.GreaterHealingPotion },
					$"Use a [i:{ModContent.ItemType<ConnectionProbe>()}] in space"


				);

			}
			if (bossChecklist != null)
			{
				bossChecklist.Call(
					"AddBoss",
					13.5f,
					new List<int> { ModContent.NPCType<Ignifier>(), ModContent.NPCType<Ignifier>() },
					this, // Mod
					"Ignifier",
					(Func<bool>)(() => DownedIgnifier.ignifier),
					ModContent.ItemType<CandleOfHell>(),
					new List<int> { ModContent.ItemType<Meltdown>(), ModContent.ItemType<Burnent>(), ModContent.ItemType<IgnifierStaff>(), ModContent.ItemType<HelltaniumRifle>(), ModContent.ItemType<BurnedSkull>(), ModContent.ItemType<Hellcore>(), ModContent.ItemType<MagtaniumSkull>(), ItemID.GreaterHealingPotion },
					$"Use a [i:{ModContent.ItemType<CandleOfHell>()}] in the underworld"


				);

			}
			if (bossChecklist != null)
			{
				bossChecklist.Call(
					"AddBoss",
					17.5f,
					new List<int> { ModContent.NPCType<ShadowBoss>(), ModContent.NPCType<ShadowBoss>() },
					this, // Mod
					"Shadecrystal guardian",
					(Func<bool>)(() => DownedShadeBoss.downedShadeBoss),
					ModContent.ItemType<Schaduw>(),
					new List<int> { ModContent.ItemType<ShadowOrbLauncher>(), ModContent.ItemType<Dusk>(), ModContent.ItemType<Luminator>(), ModContent.ItemType<MiniErebusStaff>(), ModContent.ItemType<Shadecrystal>(), ModContent.ItemType<Darksoul>(), ItemID.SuperHealingPotion },
					$"Use a [i:{ModContent.ItemType<Schaduw>()}] at night"


				);

			}
			if (bossChecklist != null)
			{
				bossChecklist.Call(
					"AddBoss",
					20.5f,
					new List<int> { ModContent.NPCType<GalactaBoss>(), ModContent.NPCType<GalactaBoss>() },
					this, // Mod
					"Galacta",
					(Func<bool>)(() => DownedGalacta.galacta),
					ModContent.ItemType<HeartOfTheSea>(),
					new List<int> { ModContent.ItemType<Galactium>(), ModContent.ItemType<GalacticRailgun>(), ModContent.ItemType<GalacticThrow>(), ModContent.ItemType<GalacticSkyfall>(), ModContent.ItemType<GalacticCrusher>(), ModContent.ItemType<Globber>(), ModContent.ItemType<GalacticEnergy>(), ItemID.SuperHealingPotion },
					$"Use a [i:{ModContent.ItemType<HeartOfTheSea>()}] at night"


				);

			}
			if (bossChecklist != null)
			{
				bossChecklist.Call(
					"AddBoss",
					3.5f,
					new List<int> { ModContent.NPCType<JungleBoss>(), ModContent.NPCType<JungleBoss>() },
					this, // Mod
					"Sactus",
					(Func<bool>)(() => DownedSystemToxican.toxican),
					ModContent.ItemType<InfectedRemote>(),
					new List<int> { ItemID.JungleSpores, ModContent.ItemType<Biohazard>(), ModContent.ItemType<InfectedSpiritStaff>(), ModContent.ItemType<StaffOfInfection>(), ModContent.ItemType<InfectedBow>(), ModContent.ItemType<BookOPulse>(), ModContent.ItemType<Wasteland>(), ItemID.HealingPotion },
					$"Use a [i:{ModContent.ItemType<Schaduw>()}] at night"


				);

			}

		

		
		}

	
		
		
		
	}

}

