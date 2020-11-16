using Terraria.ID;
using Terraria.ModLoader;

namespace WackyNPCs.Items.Blocks
{
    public class emperor : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Emperor");
			Tooltip.SetDefault("An emperor on his throne");
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
            item.createTile = mod.TileType("emperor");
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Throne, 1);
			recipe.AddIngredient(ItemID.DynastyWood, 20);
            recipe.AddIngredient(ItemID.GoldCoin, 99);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}