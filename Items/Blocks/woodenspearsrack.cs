using Terraria.ID;
using Terraria.ModLoader;

namespace WackyNPCs.Items.Blocks
{
    public class woodenspearsrack : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Wooden spear rack");
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
            item.createTile = mod.TileType("woodenspearsrack");
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddTile(TileID.Sawmill);
            recipe.AddIngredient(ItemID.Wood, 12);
            recipe.AddIngredient(ItemID.IronBar,3);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}