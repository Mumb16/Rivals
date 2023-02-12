using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Rivals.Common.GlobalItems
{

    public class OrchaliumSword : GlobalItem
    {
        // Here we make sure to only instance this GlobalItem for the Copper Shortsword, by checking item.type
        public override bool AppliesToEntity(Item item, bool lateInstatiation)
        {
            return item.type == ItemID.OrichalcumSword;
        }

        public override void SetDefaults(Item item)
        {
            item.damage = 79;
            item.scale = 2f;
        }


    }
}
