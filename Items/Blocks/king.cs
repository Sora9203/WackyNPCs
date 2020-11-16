using Terraria.ID;
using Terraria.ModLoader;

namespace WackyNPCs.Items.Blocks
{
    public class king : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("King");
			Tooltip.SetDefault("A king on his throne");
        }


        public override void SetDefaults()
        {
            item.width = 38;
            item.height = 58;
            item.maxStack = 999;
            item.useTurn = true;
            item.autoReuse = true;
            item.useAnimation = 15;
            item.useTime = 10;
            item.useStyle = 1;
            item.consumable = true;
            item.value = 0;
            item.createTile = mod.TileType("king");
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Throne, 1);
            recipe.AddIngredient(ItemID.GoldCoin, 99);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}