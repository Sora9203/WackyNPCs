using Terraria.ID;
using Terraria.ModLoader;

namespace WackyNPCs.Items.Blocks
{
    public class teapot : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Teapot");
            Tooltip.SetDefault("A decorative teapot");
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
            item.createTile = mod.TileType("teapot");
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddTile(TileID.Furnaces);
            recipe.AddIngredient(ItemID.ClayBlock, 6);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}