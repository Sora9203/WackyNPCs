using Terraria.ID;
using Terraria.ModLoader;

namespace WackyNPCs.Items.Blocks
{
    public class bigegg1 : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Big Egg1");
            Tooltip.SetDefault("A big egg. It probably won't hatch");
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
            item.createTile = mod.TileType("bigegg1");
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
			recipe.AddTile(TileID.WorkBenches);
            recipe.AddIngredient(ItemID.Feather, 10);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}