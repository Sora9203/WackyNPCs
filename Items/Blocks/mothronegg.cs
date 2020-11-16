using Terraria.ID;
using Terraria.ModLoader;

namespace WackyNPCs.Items.Blocks
{
    public class mothronegg : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Mothron egg");
            Tooltip.SetDefault("A deco mothron egg. Hopefully won't hatch");
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
            item.createTile = mod.TileType("mothronegg");
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