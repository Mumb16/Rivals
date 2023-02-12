using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Terraria.ModLoader.IO;
using System.IO;
using Rivals.Content.NPCs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.Utilities;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.ItemDropRules;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;
using Terraria.GameContent.Personalities;

//Related to GlobalProjectile: ProjectileWithGrowingDamage
namespace Rivals.Common.GlobalItems
{
	public class WeaponWithGrowingDamage : GlobalItem
	{
		public int experience;
		public static int experiencePerLevel = 100000;
		private int bonusValuePerItem;
		public int level => experience / experiencePerLevel;

		public override bool InstancePerEntity => true;

		public override bool AppliesToEntity(Item entity, bool lateInstantiation)
		{
			//Apply to weapons
			return entity.damage > 0;
		}
		public override void LoadData(Item item, TagCompound tag)
		{
			experience = 0;
			GainExperience(item, tag.Get<int>("experience"));//Load experience tag
		}

		public override void SaveData(Item item, TagCompound tag)
		{
			tag["experience"] = experience;//Save experience tag
		}

		public override void NetSend(Item item, BinaryWriter writer)
		{
			writer.Write(experience);
		}

		public override void NetReceive(Item item, BinaryReader reader)
		{

			experience = 0;
			GainExperience(item, reader.ReadInt32());
		}

		public override void OnHitNPC(Item item, Player player, NPC target, int damage, float knockBack, bool crit)
		{
			OnHitNPCGeneral(player, target, damage, knockBack, crit, item);
		}

		public void OnHitNPCGeneral(Player player, NPC target, int damage, float knockBack, bool crit, Item item = null, Projectile projectile = null)
		{
			//The weapon gains experience when hitting an npc.
			int xp = damage;
			if (projectile != null)
			{
				xp /= 2;
			}

			GainExperience(item, xp);
		}

		public void GainExperience(Item item, int xp)
		{
			experience += xp;

			UpdateValue(item);
		}

		public void UpdateValue(Item item, int stackChange = 0)
		{
			if (item == null)
			{
				return;
			}

			item.value -= bonusValuePerItem;
			int stack = item.stack + stackChange;
			if (stack == 0)
			{
				bonusValuePerItem = 0;
			}
			else
			{
				bonusValuePerItem = experience * 5 / stack;
			}

			item.value += bonusValuePerItem;
		}

		public override void UpdateInventory(Item item, Player player)
		{
			UpdateValue(item);
		}

		public override void ModifyWeaponDamage(Item item, Player player, ref StatModifier damage)
		{
			//Gain 1% multiplicative damage for every level on the weapon.
			damage *= 1f + (float)level / 100f;
		}

		public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
		{
			if (experience > 0)
			{
				tooltips.Add(new TooltipLine(Mod, "level", $"Level: {level}") { OverrideColor = Color.LightGreen });
				string levelString = $" ({(level + 1) * experiencePerLevel - experience} to next level)";
				tooltips.Add(new TooltipLine(Mod, "experience", $"Experience: {experience}{levelString}") { OverrideColor = Color.Cyan});

			}
		}

		public override void OnCreate(Item item, ItemCreationContext context)
		{
			if (item.type == ItemID.Snowball)
			{
				GainExperience(item, item.stack); // snowballs come with 1xp, for testing :)
			}

			if (context is RecipeCreationContext rContext)
			{
				foreach (Item ingredient in rContext.ConsumedItems)
				{
					if (ingredient.TryGetGlobalItem(out WeaponWithGrowingDamage ingredientGlobal))
					{
						//Transfer all experience from consumed items to the crafted item.
						GainExperience(item, ingredientGlobal.experience);
					}
				}
			}
		}

	

		private void TransferExperience(Item increase, Item decrease, WeaponWithGrowingDamage weapon2, int numberToBeTransfered)
		{
			//Transfer experience and value to increase.
			experience += weapon2.experience;
			UpdateValue(increase, numberToBeTransfered);

			if (decrease.stack > numberToBeTransfered)
			{
				//Prevent duplicating the experience by clearing it on decrease if decrease will still exist.
				weapon2.experience = 0;
				weapon2.UpdateValue(decrease, -numberToBeTransfered);
			}
		}
	}
	public class SnowBallShop : GlobalNPC
	{
		public override void SetupShop(int type, Chest shop, ref int nextSlot)
		{
			if (type != ModContent.NPCType<Archer>())
			{
				return;
			}

			Item item = shop.item[nextSlot++];
			item.SetDefaults(ItemID.PlatinumBow);
			if (item.TryGetGlobalItem(out WeaponWithGrowingDamage weapon))
			{
				weapon.GainExperience(item, 100000); // can buy snowballs with 2xp!
			}
		}
	}
}