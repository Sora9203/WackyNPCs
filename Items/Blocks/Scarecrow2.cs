using Terraria.ID;
using Terraria.ModLoader;

namespace WackyNPCs.Items.Blocks
{
    public class Scarecrow2 : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Scarecrow2");
            Tooltip.SetDefault("A decorative scarecrow");
        }


        public override void SetDefaults()
        {
            item.width = 38;
            item.height = 52;
            item.maxStack = 999;
            item.useTurn = true;
            item.autoReuse = true;
            item.useAnimation = 15;
            item.useTime = 10;
            item.useStyle = 1;
            item.consumable = true;
            item.value = 0;
            item.createTile = mod.TileType("Scarecrow2");
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddTile(TileID.Sawmill);
            recipe.AddIngredient(ItemID.Wood, 20);
            recipe.AddIngredient(ItemID.Hay, 50);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}