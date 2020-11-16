using Terraria.ID;
using Terraria.ModLoader;

namespace WackyNPCs.Items.Blocks
{
    public class snowman4 : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Snowman4");
            Tooltip.SetDefault("A decorative snowman");
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
            item.createTile = mod.TileType("snowman4");
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.SnowBlock, 10);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}